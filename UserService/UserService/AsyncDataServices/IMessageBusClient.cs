using UserService.Dtos;

namespace UserService.AsyncDataServices
{
    public interface IMessageBusClient
    {
        void PublishNewPlatform(UserPublishedDto userPublishedDto);

        void Config();
    }
}