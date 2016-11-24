using Autofac;
using BlockchainMonitor.DataModels.Blockchain;
using BlockchainMonitor.RabbitClient;
using BlockchainMonitor.RabbitClient.Model;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Framing.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EasyNetQ;
using RabbitMQ.Client.Apigen.Attributes;
using IConnectionFactory = RabbitMQ.Client.IConnectionFactory;
using IContainer = Autofac.IContainer;

namespace BlockchainMonitor.RabbitClient
{
    public class Subscriber : BaseClient, ISubscriber
    {
        private readonly IContainer _container;

        public Subscriber(IContainer container)
        {
            _container = container;
        }

        private void Recovery(object sender, EventArgs e)
        {
            //TODO: log
        }

        private void ConnectionShutdown(object sender, ShutdownEventArgs e)
        {
            //TODO: log
        }

        private void MessageReceived(byte[] body)
        {
            try
            {
                string json = Encoding.UTF8.GetString(body);
                var message = JsonConvert.DeserializeObject<RabbitMessage>(json);

                var handlerType = typeof(IMessageHandler<>).MakeGenericType(message.ObjType);
                if (!_container.IsRegistered(handlerType)) return;

                using (var scope = _container.BeginLifetimeScope())
                {
                    var handler = (IMessageHandler)scope.Resolve(handlerType);
                    handler.Handle(JsonConvert.DeserializeObject(message.JsonObject,
                        message.ObjType));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                // TODO log this error
            }
        }

        public void Start()
        {
            var bus = _container.Resolve<IAdvancedBus>();
            var queue = bus.QueueDeclare(_blockchainQueue);

            bus.Consume(queue, (body, properties, info) => MessageReceived(body));
        }



        public void Stop()
        {
            //try
            //{
            //    if (_connection != null)
            //    {
            //        _connection.ConnectionShutdown -= ConnectionShutdown;

            //        if (_connection is AutorecoveringConnection)
            //            ((AutorecoveringConnection)_connection).Recovery -= Recovery;
            //    }

            //    if (_consumer != null) _consumer.Received -= MessageReceivedInternal;
            //}
            //finally
            //{
            //    try
            //    {
            //        _channel?.Dispose();
            //    }
            //    finally
            //    {
            //        ((IDisposable)_connection)?.Dispose();
            //    }
            //}

        }
    }
}
