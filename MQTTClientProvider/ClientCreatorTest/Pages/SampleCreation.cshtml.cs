using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using MQTT_ClientProvider;
using MQTTnet.Client;
using System.Configuration;

namespace ClientReceiverSample.Pages
{
    public class SampleCreationModel : PageModel
    {
        private readonly MqttClientProvider _myMqttClientProvider;

        public SampleCreationModel(MqttClientProvider myMqttClientProvider)
        {
            _myMqttClientProvider = myMqttClientProvider;
        }

        public async Task<IActionResult> OnGet()
        {
            return Page();
        }
    }
}
