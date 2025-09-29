using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Shared.ProducerSetting;

class ProducerSettings : IProducerSettings
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

    public Task<DeliveryResult<string, string>> ProducerMessage<T>(string topic, string key, T message)
    {
        throw new Exception("");
        {

        };
    }
}
