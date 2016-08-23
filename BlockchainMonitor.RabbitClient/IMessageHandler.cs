using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainMonitor.RabbitClient
{
    public interface IMessageHandler<T> where T : class
    {
        void Handle(T message);
    }
}
