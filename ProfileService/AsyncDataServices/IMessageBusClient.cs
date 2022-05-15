using ProfileService.Dtos;

namespace ProfileService.AsyncDataServices
{
    public interface IMessageBusClient
    {
        void PublishNewProfile(ProfilePublishedDto profilePublishedDto);
    }
}