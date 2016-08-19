using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockchainMonitor.DataModels.Blockchain;
using BlockchainMonitor.DataModels.Participants;
using System.Data.Entity.Migrations;

namespace BlockchainMonitor.DataAccess.Migrations
{
    internal partial class Configuration
    {
        void DefaultPartners(Context.BlockchainDbContext context)
        {
            Participant par = new Participant()
            {
                Name = "ДИТ",
                Description = "Департамент информационных технологий г. Москвы",
                WebSite = "http://dit.mos.ru",
                Icon = "/Content/img/dit.png",
            };
            Node node1 = new Node()
            {
                IPAddress = "127.0.0.1",
                Name = "ДИТ Сервер 1",
                IsValidator = true,
                Participant = par,
            };
            Node node2 = new Node()
            {
                IPAddress = "127.0.0.1",
                Name = "ДИТ Сервер 2",
                IsValidator = false,
                Participant = par,
            };
            par.Nodes = new List<Node>() { node1, node2, };
            context.Set<Participant>().AddOrUpdate(p => p.Name, par);

            par = new Participant()
            {
                Name = "Сбербанк",
                Description = "ОАО Сбербанк",
                WebSite = "http://sberbank.ru",
                Icon = "/Content/img/dit.png",
            };
            node1 = new Node()
            {
                IPAddress = "127.0.0.1",
                Name = "Сбербанк Сервер 1",
                IsValidator = true,
                Participant = par,
            };
            node2 = new Node()
            {
                IPAddress = "127.0.0.1",
                Name = "Сбербанк Сервер 2",
                IsValidator = false,
                Participant = par,
            };
            par.Nodes = new List<Node>() { node1, node2, };
            context.Set<Participant>().AddOrUpdate(p => p.Name, par);

            par = new Participant()
            {
                Name = "Почта",
                Description = "ОАО Почта России",
                WebSite = "http://pochta.ru",
                Icon = "/Content/img/dit.png",
            };
            node1 = new Node()
            {
                IPAddress = "127.0.0.1",
                Name = "Почта Сервер 1",
                IsValidator = true,
                Participant = par,
            };
            node2 = new Node()
            {
                IPAddress = "127.0.0.1",
                Name = "Почта Сервер 2",
                IsValidator = false,
                Participant = par,
            };
            par.Nodes = new List<Node>() { node1, node2, };
            context.Set<Participant>().AddOrUpdate(p => p.Name, par);

            par = new Participant()
            {
                Name = "Минкомсвязь",
                Description = "Министерство связи и массовых коммуникаций",
                WebSite = "http://minsvyaz.ru",
                Icon = "/Content/img/dit.png",
            };
            node1 = new Node()
            {
                IPAddress = "127.0.0.1",
                Name = "Минкомсвязь Сервер 1",
                IsValidator = true,
                Participant = par,
            };
            node2 = new Node()
            {
                IPAddress = "127.0.0.1",
                Name = "Минкомсвязь Сервер 2",
                IsValidator = false,
                Participant = par,
            };
            par.Nodes = new List<Node>() { node1, node2, };
            context.Set<Participant>().AddOrUpdate(p => p.Name, par);
        }

        void SampleBlocks(BlockchainMonitor.DataAccess.Context.BlockchainDbContext context)
        {
            Block bl = new Block()
            {
                Number = 1,
                Hash = "sdfgsfgiuh",
                IsClosed = true,
            };
            SmartContract sc = new SmartContract()
            {
                ChainCode = new byte[] { 123, 234, 45, 34 },
                ChainCodeId = new byte[] { 123, 234, 45, 34 },
            };
            Transaction tr1 = new Transaction()
            {
                Data = new byte[] { 123, 234, 45, 34 },
                Time = DateTime.Now,
                Block = bl,
                SmartContract = sc,
                Id = "agjhgkjhgqweruyg",
            };
            Transaction tr2 = new Transaction()
            {
                Data = new byte[] { 123, 234, 45, 34 },
                Time = DateTime.Now,
                Block = bl,
                SmartContract = sc,
                Id = "agjhgkjhgasdfasdfruyg",
            };
            bl.Transactions = sc.Transactions = new List<Transaction>() { tr1, tr2 };
            context.Set<Block>().AddOrUpdate(b => b.Hash, bl);
            context.Set<SmartContract>().AddOrUpdate(c => c.ChainCodeId, sc);

            bl = new Block()
            {
                Number = 2,
                Hash = "sdfhhg678sfgiuh",
                IsClosed = true,
            };
            tr1 = new Transaction()
            {
                Data = new byte[] { 123, 234, 45, 34 },
                Time = DateTime.Now,
                Block = bl,
                SmartContract = sc,
                Id = "agjhg734gqweruyg",
            };
            tr2 = new Transaction()
            {
                Data = new byte[] { 123, 234, 45, 34 },
                Time = DateTime.Now,
                Block = bl,
                SmartContract = sc,
                Id = "agjhgkjhgahjkd7g",
            };
            bl.Transactions = sc.Transactions = new List<Transaction>() { tr1, tr2 };
            context.Set<Block>().AddOrUpdate(b => b.Hash, bl);

            bl = new Block()
            {
                Number = 3,
                Hash = "sdfhhg676ghjuh",
                IsClosed = true,
            };
            tr1 = new Transaction()
            {
                Data = new byte[] { 123, 234, 45, 34 },
                Time = DateTime.Now,
                Block = bl,
                SmartContract = sc,
                Id = "ag422qweruyg",
            };
            tr2 = new Transaction()
            {
                Data = new byte[] { 123, 234, 45, 34 },
                Time = DateTime.Now,
                Block = bl,
                SmartContract = sc,
                Id = "atyur8gahjkd7g",
            };
            bl.Transactions = sc.Transactions = new List<Transaction>() { tr1, tr2 };
            context.Set<Block>().AddOrUpdate(b => b.Hash, bl);

            bl = new Block()
            {
                Number = 4,
                Hash = "787987j7ghjuh",
                IsClosed = true,
            };
            sc = new SmartContract()
            {
                ChainCode = new byte[] { 13, 234, 55, 34 },
                ChainCodeId = new byte[] { 13, 23, 5, 134 },
            };
            tr1 = new Transaction()
            {
                Data = new byte[] { 123, 234, 45, 34 },
                Time = DateTime.Now,
                Block = bl,
                SmartContract = sc,
                Id = "ag422945ruyg",
            };
            bl.Transactions = sc.Transactions = new List<Transaction>() { tr1 };
            context.Set<Block>().AddOrUpdate(b => b.Hash, bl);
            context.Set<SmartContract>().AddOrUpdate(c => c.ChainCodeId, sc);
        }
    }
}
