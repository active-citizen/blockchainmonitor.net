using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using BlockchainMonitor.DataCollector.Model;
using RestSharp;

namespace BlockchainMonitor.DataCollector
{
    public class BlockchainAPIClient : IBlockchainAPIClient
    {
        private readonly IRestClient _client;

        public BlockchainAPIClient(IRestClient client)
        {
            _client = client;
        }

        public Block GetBlock(uint id)
        {
            var request = new RestRequest("chain/blocks/{id}", Method.GET);
            request.AddUrlSegment("id", id.ToString());

            var response = _client.Execute<Block>(request);

            if (response.ErrorException != null)
            {
                // TODO log it!!!
            }

            response.Data.Id = id;

            if (response.Data.Transactions != null)
            {
                foreach (Transaction transaction in response.Data.Transactions)
                {
                    transaction.BlockId = id;
                }
            }

            return response.Data;
        }

        public BlockchainState GetBlockchainState()
        {
            var request = new RestRequest("chain", Method.GET);

            var response = _client.Execute<BlockchainState>(request);

            return response.Data;
        }

        public Transaction GetTransaction(string id)
        {
            var request = new RestRequest("transactions/{id}", Method.GET);
            request.AddUrlSegment("id", id);

            var response = _client.Execute<Transaction>(request);

            return response.Data;
        }
    }
}
