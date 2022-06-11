using KrabbelService.Dtos;

namespace KrabbelService.AsyncDataServices
{
    public interface IMessageBusClient
    {
        void PublishNewKrabbel(KrabbelPublishedDto krabbelPublishedDto);
    }
}