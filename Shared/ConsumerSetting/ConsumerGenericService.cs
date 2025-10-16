using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Shared.ConsumerSetting;

public abstract class ConsumerGenericService<TKey, TValue> : BackgroundService
{
    private readonly string _topic;
    private readonly ConsumerConfig _config;

    protected ConsumerGenericService(IConfiguration configuration, string topic, string groupId)
    {
        _topic = topic;
        _config = new ConsumerConfig
        {
            BootstrapServers = configuration["Kafka:BootstrapServers"],
            GroupId = groupId,
            AutoOffsetReset = AutoOffsetReset.Earliest,
            EnableAutoCommit = false
        };
    }

    protected abstract Task HandleMessage(TKey key, TValue value, long offset, int partition);

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var consumer = new ConsumerBuilder<TKey, string>(_config).Build();
        consumer.Subscribe(_topic);

        await Task.Delay(10, stoppingToken);

        try
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var cr = consumer.Consume(TimeSpan.FromSeconds(1));
                try
                {

                    //Console.WriteLine("Đang consume....");
                    if (cr == null)
                        continue;
                    // Deserialize string -> TValue
                    TValue deserialized = JsonSerializer.Deserialize<TValue>(cr.Message.Value);

                    await HandleMessage(cr.Message.Key, deserialized, cr.Offset.Value, cr.Partition.Value);
                    Console.WriteLine($"Offset: {cr.Offset}, Partition: {cr.Partition}");

                    consumer.Commit(cr);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi: {ex.ToString()}");
                    consumer.Commit(cr);
                }

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Lỗi: {ex.ToString()}");

        }


    }

}
