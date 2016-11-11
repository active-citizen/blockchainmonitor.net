using BlockchainMonitor.DataModels.Blockchain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Type = BlockchainMonitor.DataModels.Blockchain.Type;

namespace BlockchainMonitor.TestData
{
    public class Examples
    {
        static Random _rnd = new Random((int)DateTime.Now.Ticks);
        public static Transaction RandomTransaction
        {
            get
            {
                Transaction tr = new Transaction()
                {
                    Payload = "fgdf45bq57dfghdd79fg86d7fgs568g6",
                    Timestamp = DateTime.Now,
                    TxID = "as6ds6g-" + _rnd.Next() + "-s7d6f8",
                    ChaincodeID = "s8d5f6s6fa6s5f8sa7065sf5as86dfa6s8d5f",
                    BlockId = 1,
                    Type = Type.CHAINCODE_DEPLOY
                };
                return tr;
            }
        }

    }
}
