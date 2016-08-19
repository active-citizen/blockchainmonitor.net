using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlockchainMonitor.WebUI.Controllers
{
    public class ParticipantsController : Controller
    {
        // GET: Participants
        public ActionResult Index()
        {
            return View();
        }
    }
}