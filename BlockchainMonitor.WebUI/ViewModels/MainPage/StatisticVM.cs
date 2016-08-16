using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BlockchainMonitor.WebUI.ViewModels.MainPage
{
    public class StatisticVM
    {
        [Description("Всего блоков")]
        public int BlocksCount { get; set; }

        [Description("Всего транзакций")]
        public int TransactionsCount { get; set; }

        [Description("Размер базы данных")]
        public double DataBaseSizeGB { get; set; }

        [Description("Всего смартконтрактов")]
        public int SmartContractsCount { get; set; }

        [Description("Валидирующих нод")]
        public int ValidatingNodesCount { get; set; }

        [Description("Не валидирующих нод")]
        public int NonValidatingNodesCount { get; set; }
    }
}