using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ProducerSetting;

public interface IProducerSettings
{
     Task<DeliveryResult<string, string>> ProducerMessage<T>(string topic, string key, T message);
}
