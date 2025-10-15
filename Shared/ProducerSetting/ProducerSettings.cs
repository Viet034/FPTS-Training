using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Shared.ProducerSetting;

public class ProducerSettings : IProducerSettings
{
    private readonly IProducer<string, string> _producer;

    public ProducerSettings(IProducer<string, string> producer)
    {
        _producer = producer;
    }

    public ProducerSettings(IConfiguration config)
    {
        var configs = new ProducerConfig
        {
            BootstrapServers = config["kafka:BootstrapServers"]
        };
        _producer = new ProducerBuilder<string, string>(configs).Build();
    }

    public async Task<DeliveryResult<string, string>> ProducerMessage<T>(string topic, string key, T message)
    {
        try
        {
            var value = System.Text.Json.JsonSerializer.Serialize(message);
            var result = await _producer.ProduceAsync(topic, new Message<string, string>
            {
                Key = key,
                Value = value
            });
            Console.WriteLine($"Key: {key}");
            Console.WriteLine($"Value: {value}");

            return result;
        }
        catch (Exception ex)
        {
            throw new Exception("Error");
        }
        
    }
}
