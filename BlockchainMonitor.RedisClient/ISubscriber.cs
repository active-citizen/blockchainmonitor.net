using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainMonitor.RedisClient
{
    public delegate void ChangeValueDelegate(string key, string value);

    public interface ISubscriber
    {
        event ChangeValueDelegate ChangeValue;

        void Stop();
    }
}
