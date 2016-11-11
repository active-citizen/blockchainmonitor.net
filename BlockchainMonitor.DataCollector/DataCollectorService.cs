using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Autofac;
using AutoMapper;
using BlockchainMonitor.DataCollector.AutofacModules;
using BlockchainMonitor.DataCollector.Model;
using BlockchainMonitor.RabbitClient;
using BlockchainMonitor.RabbitClient.AutofacModules;
using RabbitMQ.Client;

namespace BlockchainMonitor.DataCollector
{
    public partial class DataCollectorService : ServiceBase
    {
        private IBlockchainAPIClient _apiClient;
        private IContainer _container;
        private IPublisher _publisher;

        public DataCollectorService()
        {
            InitializeComponent();
        }

        internal void ServiceStartAndStop()
        {
            OnStart(null);
            Console.WriteLine("DataCollectorService started");
            Console.ReadLine();
            OnStop();
            Console.WriteLine("DataCollectorService stopped");
        }

        protected override void OnStart(string[] args)
        {
            RegisterDependencies();

            //_factory = _container.Resolve<IConnectionFactory>();
            _apiClient = _container.Resolve<IBlockchainAPIClient>();
            _publisher = _container.Resolve<IPublisher>();

            Mapper.Initialize(
                cfg =>
                {
                    cfg.CreateMap<Block, DataModels.Blockchain.Block>()
                        .ForMember(m => m.Timestamp,
                            opt => opt.MapFrom(src => src.NonHashData.LocalLedgerCommitTimestamp.ToDateTime()));

                    cfg.CreateMap<Transaction, DataModels.Blockchain.Transaction>()
                        .ForMember(m => m.Timestamp, opt => opt.MapFrom(src => src.Timestamp.ToDateTime()));
                });

            Timer timer = new Timer(10000);
            timer.Elapsed += OnTimerElapsed;
            timer.Start();

            //Test();
        }

        public void Test()
        {
            string path = @"./blocksCounter.txt";

            if (!File.Exists(path))
            {
                using (FileStream fs = File.Create(path))
                {
                    Byte[] text = new UTF8Encoding(true).GetBytes("0");

                    fs.Write(text, 0, text.Length);
                }
            }

            long savedBlocksCount = Convert.ToInt64(File.ReadAllText(path));

            Console.WriteLine(DateTime.Now + " - Read from file: {0} blocks started", savedBlocksCount);

            long blockchainHeight = _apiClient.GetBlockchainState().Height;

            long blockCicleCount = Convert.ToInt64(ConfigurationManager.AppSettings["count"]);

            if (blockchainHeight - savedBlocksCount <= blockCicleCount)
            {
                blockCicleCount = blockchainHeight - savedBlocksCount;
            }

            long countToSave;

            for (countToSave = savedBlocksCount; countToSave < savedBlocksCount + blockCicleCount; ++countToSave)
            {
                var block = _apiClient.GetBlock(Convert.ToUInt32(countToSave));

                try
                {
                    //Mapper.Initialize(
                    //    cfg =>
                    //    {
                    //        cfg.CreateMap<Block, DataModels.Blockchain.Block>()
                    //            .ForMember(m => m.Timestamp,
                    //                opt => opt.MapFrom(src => src.NonHashData.LocalLedgerCommitTimestamp.ToDateTime()));

                    //        cfg.CreateMap<Transaction, DataModels.Blockchain.Transaction>()
                    //            .ForMember(m => m.Timestamp, opt => opt.MapFrom(src => src.Timestamp.ToDateTime()));
                    //    });

                    var blockForDb = Mapper.Map<Block, DataModels.Blockchain.Block>(block);

                    _publisher.PublishMessage(blockForDb);

                    if (block.Transactions != null)
                    {
                        var transactions =
                            Mapper.Map<IEnumerable<Transaction>, List<DataModels.Blockchain.Transaction>>(
                                block.Transactions);

                        _publisher.PublishMessage(transactions);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            using (FileStream fs = File.OpenWrite(path))
            {
                Byte[] text = new UTF8Encoding(true).GetBytes(countToSave.ToString());

                fs.Write(text, 0, text.Length);
            }

            Console.WriteLine(DateTime.Now + " - Write to file: {0} blocks finished", countToSave);
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            Test();
        }

        protected override void OnStop()
        {
        }

        private void RegisterDependencies()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new BlockchainAPIClientModule());
            builder.RegisterModule(new RabbitClientModule());
            _container = builder.Build();
        }
    }
}
