using MassTransit;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace CityRide.Infrastructure.ServiceBus
{
    internal sealed class BusManager : IBusManager
    {
        private readonly ISendEndpointProvider _sendEndpointProvider;
        private readonly IConfiguration _config;

        public BusManager(ISendEndpointProvider sendEndpointProvider, IConfiguration config)
        {
            _sendEndpointProvider = sendEndpointProvider;
            _config = config;
        }

        async Task IBusManager.SendMessage<T>(T message, string queueaName)
        {
            var endpoint = await _sendEndpointProvider.GetSendEndpoint(
                new Uri(_config.GetSection("RabbitMq:Endpoint").Value + "/" + queueaName));
            await endpoint.Send(message, x => { x.Durable = true; });
        }
    }
}
