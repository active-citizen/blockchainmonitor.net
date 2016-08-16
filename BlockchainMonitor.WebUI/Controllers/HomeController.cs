using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlockchainMonitor.WebUI.ViewModels.MainPage;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.AspNet.SignalR;

namespace BlockchainMonitor.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new BlockChainVM();
            model.AllBlocks = new List<BlockVM>() {
                new BlockVM() { Number = 1987, TransactionsCount = 10000 },
                new BlockVM() { Number = 1988, TransactionsCount = 10000 },
                new BlockVM() { Number = 1989, TransactionsCount = 10000 },
                new BlockVM() { Number = 1990, TransactionsCount = 10000 },
                new BlockVM() { Number = 1991, TransactionsCount = 10000 },
                new BlockVM() { Number = 1992, TransactionsCount = 67 },
            };
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