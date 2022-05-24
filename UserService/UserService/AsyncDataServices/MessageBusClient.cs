using System;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using UserService.Dtos;

namespace UserService.AsyncDataServices
{
    public class MessageBusClient : IMessageBusClient
    {
        private readonly IConfiguration _config;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public MessageBusClient(IConfiguration config)
        {
            _config = config;
            var factory = new ConnectionFactory() { HostName = _config["RabbitMQHost"],
                Port = int.Parse(_config["RabbitMQPort"]) };
            
            Console.WriteLine("Trying to connect...");

            try
            {
                _connection = factory.CreateConnection();
                _channel = _connection.CreateModel();

                _channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);

                _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;

                Console.WriteLine("Succesfully connected to RabbitMQ!");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Could not connect to RabbitMQ: {ex.Message}");
            }
        }
        public void PublishNewPlatform(UserPublishedDto platformPublishedDto)
        {
            var message = JsonSerializer.Serialize(platformPublishedDto);

            if(_connection.IsOpen)
            {
                Console.WriteLine($"Sending to RabbitMQ...");
                SendMessage(message);
                return;
            }

            Console.WriteLine("Connection is closed, not sending message");
        }

        private void SendMessage(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(exchange: "trigger",
                            routingKey: "",
                            basicProperties: null,
                            body: body);

            Console.WriteLine($"Sent message to RabbitMQ: {message}");
        }

        private void RabbitMQ_ConnectionShutdown(object sender, ShutdownEventArgs e)
        {
            Console.WriteLine("RabbitMQ connection has been shut down");
        }

        public void Dispose()
        {
            Console.WriteLine("Messagebus disposed");
            if(_channel.IsOpen)
            {
                _channel.Close();
                _connection.Close();
            }
        }

        public void Config()
        {
            Console.WriteLine("Messagebus configured!");
        }
    }
}