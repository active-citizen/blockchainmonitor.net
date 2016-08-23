using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlockchainMonitor.WebUI.ViewModels.MainPage;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.AspNet.SignalR;
using BlockchainMonitor.Infrastructure.Provider;
using BlockchainMonitor.Infrastructure.Monitor;
using AutoMapper;
using BlockchainMonitor.WebUI.Hubs;
using BlockchainMonitor.DataModels.Blockchain;

namespace BlockchainMonitor.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlockchainProvider _provider;
        private readonly IParticipantMonitor _monitor;
        private readonly IMapper _mapper;

        public HomeController(  IBlockchainProvider provider, 
                                IMapper mapper, 
                                IParticipantMonitor monitor)
        {
            _provider = provider;
            _mapper = mapper;
            _monitor = monitor;
        }

        public ActionResult Index()
        {
            var model = new BlockChainVM();

            var blocks = _provider.GetAllBlocks();
            model.AllBlocks = blocks.Select(block => _mapper.Map<BlockVM>(block)).ToList();

            var stat = _provider.GetAllStatistics();
            model.Statistics = _mapper.Map<StatisticsVM>(stat);

            var trans = _provider.GetLastTransactions();
            model.LastTransactions = trans.Select(t => _mapper.Map<TransactionVM>(t)).ToList();

            var parts = _monitor.GetParticipants(true);
            model.AliveParticipants = parts.Select(p => _mapper.Map<ParticipantVM>(p)).ToList();
            parts = _monitor.GetParticipants(false);
            model.DeadParticipants = parts.Select(p => _mapper.Map<ParticipantVM>(p)).ToList();

            IncreaseTransactionsCount();

            return View(model);
        }

        private void IncreaseTransactionsCount()
        {
            Task.Run(() => {
                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(1000);
                    var hub = GlobalHost.ConnectionManager
                        .GetHubContext<BlockchainHub>()
                        .Clients.All.updateLastBlockTransactionCount(i);
                }
            });
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult BecomeMember()
        {
            return View();
        }

        public ActionResult API()
        {
            return View();
        }
    }
}