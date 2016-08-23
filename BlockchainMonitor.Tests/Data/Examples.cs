using BlockchainMonitor.DataModels.Blockchain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainMonitor.Tests.Data
{
    class Examples
    {
        static Random _rnd = new Random((int)DateTime.Now.Ticks);
        public static Transaction RandomTransaction
        {
            get
            {
                Transaction tr = new Transaction()
                {
                    Data = new byte[] { 123, 234, 45, 34 },
                    Time = DateTime.Now,
                    Id = "agjhgkjhgg" + _rnd.Next().ToString(),
                };
                return tr;
            }
        }
    }
}
