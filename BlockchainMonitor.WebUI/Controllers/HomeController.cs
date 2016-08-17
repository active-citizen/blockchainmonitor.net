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
using AutoMapper;

namespace BlockchainMonitor.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlockchainProvider _provider;
        private readonly IMapper _mapper;

        public HomeController(IBlockchainProvider provider, IMapper mapper)
        {
            _provider = provider;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var model = new BlockChainVM();
            var blocks = _provider.GetAllBlocks();
            model.AllBlocks = blocks.Select(block => _mapper.Map<BlockVM>(block)).ToList();

            Task.Run(() => {
                Thread.Sleep(10000);
                var hub = GlobalHost.ConnectionManager
                    .GetHubContext<BlockchainMonitor.WebUI.Hubs.BlockchainHub>()
                    .Clients.All.lastBlockTransactionCount(999);
            });
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}