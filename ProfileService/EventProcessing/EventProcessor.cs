using System;
using System.Text.Json;
using AutoMapper;
using ProfileService.Data;
using ProfileService.Dtos;
using ProfileService.Models;
using Microsoft.Extensions.DependencyInjection;

namespace ProfileService.EventProcessing
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
                case EventType.UserPublished:
                    AddUser(message);
                    break;
                default:
                    break;
            }
        }

        private void AddUser(string userPublishedMessage)
        {
            using(var scope = _scopeFactory.CreateScope())
            {
                var repo = scope.ServiceProvider.GetRequiredService<IUserRepo>();

                var UserPublishedDto = JsonSerializer.Deserialize<UserPublishedDto>(userPublishedMessage);

                try
                {
                    var user = _mapper.Map<User>(UserPublishedDto);

                    if(!repo.ExternalUserExists(user.ExternalId))
                    {
                        repo.CreateUser(user);
                        repo.SaveChanges();
                        Console.WriteLine("New user added!");
                    }
                    else
                    {
                        Console.WriteLine("User already exists...");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Could not add user to database... {ex}");
                }
            }
        }

        private EventType DetermineEvent(string notificationMessage)
        {
            Console.WriteLine("Determining event...");

            var eventType = JsonSerializer.Deserialize<GenericEventDto>(notificationMessage);
 
            switch(eventType.Event)
            {
                case "User_Published":
                    Console.WriteLine("User published event detected!");
                    return EventType.UserPublished;
                default:
                    Console.WriteLine("Unknown event detected!");
                    return EventType.Unknown;
            }
        }
    }

    enum EventType
    {
        UserPublished,
        Unknown
    }
}