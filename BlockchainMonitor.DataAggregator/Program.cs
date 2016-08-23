﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainMonitor.DataAggregator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string [] args)
        {
            if (Environment.UserInteractive)
            {
                DataAggregatorService service = new DataAggregatorService();
                service.ServiceStartAndStop();
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                new DataAggregatorService()
                };
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}
