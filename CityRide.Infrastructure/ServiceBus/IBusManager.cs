using System.Threading.Tasks;

namespace CityRide.Infrastructure.ServiceBus
{
    public interface IBusManager
    {
        Task SendMessage<T>(T message, string queueaName)
            where T : class;
    }
}
