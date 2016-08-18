using BlockchainMonitor.DataModels.Participants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainMonitor.Infrastructure.Monitor
{
    public interface IParticipantMonitor
    {
        List<Participant> GetParticipants(bool isAlive);
    }
}
