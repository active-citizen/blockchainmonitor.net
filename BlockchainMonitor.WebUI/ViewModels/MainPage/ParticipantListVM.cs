using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlockchainMonitor.WebUI.ViewModels.MainPage
{
    public class ParticipantListVM
    {
        public ParticipantListVM(string title)
        {
            Title = title;
        }

        public string Title { get; private set; }

        public List<ParticipantVM> Participants { get; set; }

    }
}