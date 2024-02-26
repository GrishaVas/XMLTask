using RabbitMQ.Client.Events;

namespace Services.Abstractions
{
    public interface IMessageBrokerService
    {
        public void OnRecieveMessage(string queueName, EventHandler<BasicDeliverEventArgs> exp);
        public void SendMessage(string queueName, string messageBody);
    }
}
