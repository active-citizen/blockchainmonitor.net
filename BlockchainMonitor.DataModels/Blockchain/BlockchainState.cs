using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainMonitor.DataModels.Blockchain
{
    public class BlockchainState
    {
        /// <summary>
        /// Number of blocks in the blockchain, including the genesis block
        /// </summary>
        public long Height { get; set; }

        /// <summary>
        /// The hash of the current or last block
        /// </summary>
        public string CurrentBlockHash { get; set; }

        /// <summary>
        /// The hash of the previous block
        /// </summary>
        public string PreviousBlockHash { get; set; }
    }
}
