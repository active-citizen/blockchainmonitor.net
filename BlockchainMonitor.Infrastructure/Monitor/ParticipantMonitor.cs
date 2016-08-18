using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockchainMonitor.DataModels.Participants;
using BlockchainMonitor.Infrastructure.Provider;

namespace BlockchainMonitor.Infrastructure.Monitor
{
    class ParticipantMonitor : IParticipantMonitor
    {
        private readonly IBlockchainProvider _provider;
        public ParticipantMonitor(IBlockchainProvider provider)
        {
            _provider = provider;
        }

        public List<Participant> GetParticipants(bool isAlive)
        {
            var parts = _provider.GetAllParticipants();
            //TODO: ping IPs every 60 seconds
            return parts;
        }
    }
}
