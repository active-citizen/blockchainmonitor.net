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
        //private readonly IConnectionFactory _factory;
        private readonly IContainer _container;
        //private IConnection _connection;
        //private IModel _channel;
        //private EventingBasicConsumer _consumer;


        private readonly IAdvancedBus _bus;

        public Subscriber(IContainer container, IAdvancedBus bus)
        {
            //_factory = factory;
            _bus = bus;
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

        private void MessageReceivedInternal(object sender, BasicDeliverEventArgs args)
        {
            try
            {
                var body = args.Body;
                string json = Encoding.UTF8.GetString(body);
                var message = JsonConvert.DeserializeObject<RabbitMessage>(json);

                var handlerType = typeof(IMessageHandler<>).MakeGenericType(message.ObjType);
                if (!_container.IsRegistered(handlerType)) return;

                var handler = (IMessageHandler)_container.Resolve(handlerType);
                handler.Handle(JsonConvert.DeserializeObject(message.JsonObject,
                                                             message.ObjType));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                //TODO: log this error
            }
            finally
            {
                //TODO: manage poison messages
                //_channel.BasicAck(args.DeliveryTag, false);
            }
        }

        private void MessageReceived(byte[] body)
        {
            try
            {
                string json = Encoding.UTF8.GetString(body);
                var message = JsonConvert.DeserializeObject<RabbitMessage>(json);

                var handlerType = typeof(IMessageHandler<>).MakeGenericType(message.ObjType);
                if (!_container.IsRegistered(handlerType)) return;

                using (_container.BeginLifetimeScope())
                {
                    var handler = (IMessageHandler)_container.Resolve(handlerType);
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
            //var connection = _factory.CreateConnection();
            var queue = _bus.QueueDeclare(_blockchainQueue);

            //EnsureQueue(_bus, _blockchainQueue);

            _bus.Consume(queue, (body, properties, info) => MessageReceived(body));

            //_connection = connection as AutorecoveringConnection;

            //if (_connection != null)
            //{
            //    ((AutorecoveringConnection)_connection).Recovery += Recovery;
            //}
            //else
            //{
            //    _connection = (Connection)connection;
            //}

            //_connection.ConnectionShutdown += ConnectionShutdown;

            //_channel = _connection.CreateModel();

            //EnsureQueue(_channel, _blockchainQueue);

            //_consumer = new EventingBasicConsumer(_channel);
            //_consumer.Received += MessageReceivedInternal;

            //_channel.BasicConsume(queue: _blockchainQueue,
            //                        noAck: false,
            //                        consumer: _consumer);
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
