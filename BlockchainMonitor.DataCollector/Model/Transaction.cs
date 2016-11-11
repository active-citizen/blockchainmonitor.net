using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;

namespace BlockchainMonitor.DataCollector.Model
{
    public class Transaction
    {

        /// <summary>
        /// The ID of a chaincode which is a hash of the chaincode source, path to the source code, constructor function, and parameters.
        /// </summary>
        public string ChaincodeID { get; set; }

        /// <summary>
        /// The payload of the transaction
        /// </summary>
        public string Payload { get; set; }

        /// <summary>
        /// An unique ID for the transaction
        /// </summary>
        public string TxID { get; set; }

        /// <summary>
        /// The type of the transaction
        /// </summary>
        public Type Type { get; set; }

        /// <summary>
        /// A timestamp of when the transaction request was received by the peer
        /// </summary>
        public Timestamp Timestamp { get; set; }

        /// <summary>
        /// The ID of the parent block
        /// </summary>
        public long BlockId { get; set; }

    }

    public enum Type : byte
    {
        UNDEFINED,
        CHAINCODE_DEPLOY,
        CHAINCODE_INVOKE,
        CHAINCODE_QUERY,
        CHAINCODE_TERMINATE
    }

}
