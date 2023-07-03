using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTT_ClientProvider
{
    public class MqttClientSettings
    {
        public string BrokerUrl { get; set; }
        public int Port { get; set; }
        public string ClientId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Topic { get; set; }

        public static MqttClientSettings GetMqttClientSettings(IConfiguration configuration)
        {
            var mqttClientSettings = new MqttClientSettings();
            configuration.GetSection("MqttSettings").Bind(mqttClientSettings);
            return mqttClientSettings;
        }
    }
}

