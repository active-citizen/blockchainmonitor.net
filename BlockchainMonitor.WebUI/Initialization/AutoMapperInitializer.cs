using Autofac;
using AutoMapper;
using BlockchainMonitor.DataModels.Blockchain;
using BlockchainMonitor.WebUI.ViewModels.MainPage;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlockchainMonitor.WebUI.Initialization
{
    public class AutoMapperInitializer
    {
        public static void Initialize(ContainerBuilder builder, IAppBuilder app)
        {
            // Mapper
            builder.RegisterInstance(InitializeMapping()).SingleInstance();

            // Settings
            //builder.RegisterType<AppSettings>().As<IAppSettings>();
        }

        static IMapper InitializeMapping()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Block, BlockVM>().ForMember(blockVM => blockVM.TransactionsCount,
                    blockConfig => blockConfig.MapFrom(block => block.Transactions.Count));
                //.ForMember(vm => vm.CategoryId, li => li.MapFrom(vm => vm.Category.Id));
            });
            return config.CreateMapper();
        }
    }
}