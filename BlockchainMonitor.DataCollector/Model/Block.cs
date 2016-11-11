using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;

namespace BlockchainMonitor.DataCollector.Model
{
    public class Block
    {
        /// <summary>
        /// The ID of the current block
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The merkle root hash of the world state
        /// </summary>
        public string StateHash { get; set; }

        /// <summary>
        /// The hash of the previous block
        /// </summary>
        public string PreviousBlockHash { get; set; }

        /// <summary>
        /// An array of Transaction messages
        /// </summary>
        public virtual List<Transaction> Transactions { get; set; }

        /// <summary>
        /// The NonHashData message is used to store block metadata
        /// </summary>
        public NonHashData NonHashData { get; set; }

    }

    public class NonHashData
    {
        public Timestamp LocalLedgerCommitTimestamp { get; set; }
    }
}

