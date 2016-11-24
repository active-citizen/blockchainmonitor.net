using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Google.Protobuf.WellKnownTypes;

namespace BlockchainMonitor.DataModels.Blockchain
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
        [Key]
        public string TxID { get; set; }

        /// <summary>
        /// The type of the transaction
        /// </summary>
        public Type Type { get; set; }

        /// <summary>
        /// A timestamp of when the transaction request was received by the peer
        /// </summary>
        //public Timestamp Timestamp { get; set; }
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// The ID of the parent block
        /// </summary>
        //[ForeignKey("Block")]
        public long BlockId { get; set; }

        //public virtual Block Block { get; set; }
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