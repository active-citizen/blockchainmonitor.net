using Autofac;
using BlockchainMonitor.DataModels.Blockchain;
using BlockchainMonitor.RabbitClient;
using BlockchainMonitor.RabbitClient.Model;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlockchainMonitor.RabbitClient
{
    public class Subscriber : BaseClient, ISubscriber
    {
        private readonly IConnectionFactory _factory;
        private readonly IContainer _container;
        private IConnection _connection;
        private IModel _channel;
        private EventingBasicConsumer _consumer;

        public Subscriber(IConnectionFactory factory, IContainer container)
        {
            _factory = factory;
            _container = container;
        }

        private void Connect()
        {
            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();

            EnsureQueue(_channel, _blockchainQueue);

            _consumer = new EventingBasicConsumer(_channel);
            _consumer.Received += MessageReceivedInternal;

            _channel.BasicConsume(queue: _blockchainQueue,
                                    noAck: false,
                                    consumer: _consumer);
        }

        private void MessageReceivedInternal(object sender, BasicDeliverEventArgs args)
        {
            try
            {
                var body = args.Body;
                string json = Encoding.UTF8.GetString(body);
                var message = JsonConvert.DeserializeObject<RabbitMessage>(json);

                var handlerType = typeof(IMessageHandler<>).MakeGenericType(message.ObjType);
                if (!_container.IsRegistered(handlerType)) return;

                var handler = _container.Resolve(handlerType);
                handler.GetType().InvokeMember("Handle", 
                                                System.Reflection.BindingFlags.InvokeMethod,
                                                null,
                                                handler,
                                                new object [] { JsonConvert.DeserializeObject(
                                                                    message.JsonObject,
                                                                    message.ObjType)});
            }
            catch (Exception ex)
            {
                //TODO: log this error
            }
            finally
            {
                //TODO: manage poison messages
                _channel.BasicAck(args.DeliveryTag, false);
            }
        }

        public void Start()
        {
            Connect();
        }
    }
}
