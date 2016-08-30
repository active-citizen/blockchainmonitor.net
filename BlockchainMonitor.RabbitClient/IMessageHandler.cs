using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainMonitor.RabbitClient
{
    public interface IMessageHandler<T> : IMessageHandler where T : class
    {
        void Handle(T message);
    }

    public interface IMessageHandler
    {
        void Handle(object message);
    }

    public abstract class MessageHandlerBase<T> : IMessageHandler<T> where T : class
    {
        public void Handle(object message)
        {
            Handle((T)message);
        }

        public abstract void Handle(T message);
    }
}
