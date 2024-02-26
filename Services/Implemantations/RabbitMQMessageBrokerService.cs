using System.Text;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Services.Abstractions;

namespace Services.Implemantations
{
    public class RabbitMQMessageBrokerService : IMessageBrokerService
    {
        private readonly IModel _channel;
        private readonly IConnection _connection;
        private readonly IConfiguration _config;

        public RabbitMQMessageBrokerService(IConfiguration config)
        {
            _config = config;

            var factory = new ConnectionFactory { HostName = _config["QueueHostName"] };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        public void OnRecieveMessage(string queueName, EventHandler<BasicDeliverEventArgs> exp)
        {
            _channel.QueueDeclare(queue: queueName,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += exp;

            _channel.BasicConsume(queue: queueName,
                                 autoAck: true,
                                 consumer: consumer);
        }

        public void SendMessage(string queueName, string messageBody)
        {
            _channel.QueueDeclare(queue: queueName,
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

            var body = Encoding.UTF8.GetBytes(messageBody);

            _channel.BasicPublish(exchange: string.Empty,
                                 routingKey: queueName,
                                 basicProperties: null,
                                 body: body);
        }
    }
}
