using System;
using System.Text.Json;
using AutoMapper;
using CommandsService.Data;
using CommandsService.Dtos;
using CommandsService.Models;
using Microsoft.Extensions.DependencyInjection;

namespace CommandsService.EventProcessing
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IMapper _mapper;

        public EventProcessor(IServiceScopeFactory scopeFactory, IMapper mapper)
        {
            _scopeFactory = scopeFactory;
            _mapper = mapper;
        }
        public void ProcessEvent(string message)
        {
            var eventType = DetermineEvent(message);

            switch(eventType)
            {
                case EventType.PlatformPublished:
                    AddPlatform(message);
                    break;
                default:
                    break;
            }
        }

        private void AddPlatform(string platformPublishedMessage)
        {
            using(var scope = _scopeFactory.CreateScope())
            {
                var repo = scope.ServiceProvider.GetRequiredService<ICommandRepo>();

                var PlatformPublishedDto = JsonSerializer.Deserialize<PlatformPublishedDto>(platformPublishedMessage);

                try
                {
                    var platform = _mapper.Map<Platform>(PlatformPublishedDto);

                    if(!repo.ExternalPlatformExists(platform.ExternalId))
                    {
                        repo.CreatePlatform(platform);
                        repo.SaveChanges();
                        Console.WriteLine("Platform added! :D");
                    }
                    else
                    {
                        Console.WriteLine("Platform already exists...");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Could not add platform to database... {ex}");
                }
            }
        }

        private EventType DetermineEvent(string notificationMessage)
        {
            Console.WriteLine("Determining event...");

            var eventType = JsonSerializer.Deserialize<GenericEventDto>(notificationMessage);

            switch(eventType.Event)
            {
                case "Platform_Published":
                    Console.WriteLine("Platform published event detected!");
                    return EventType.PlatformPublished;
                default:
                    Console.WriteLine("Unknown event detected!");
                    return EventType.Unknown;
            }
        }
    }

    enum EventType
    {
        PlatformPublished,
        Unknown
    }
}