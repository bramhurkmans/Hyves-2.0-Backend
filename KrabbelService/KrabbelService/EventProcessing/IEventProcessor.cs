namespace KrabbelService.EventProcessing
{
    public interface IEventProcessor
    {
        void ProcessEvent(string message);
    }
}