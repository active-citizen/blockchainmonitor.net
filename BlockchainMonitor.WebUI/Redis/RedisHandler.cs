using Autofac;
using AutoMapper;
using BlockchainMonitor.RedisClient;
using BlockchainMonitor.WebUI.Hubs;
using BlockchainMonitor.WebUI.ViewModels.MainPage;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlockchainMonitor.WebUI.Redis
{
    public class RedisHandler
    {
        private readonly IRepository _redis;
        private readonly IMapper _mapper;
        IDictionary<string, Action<IHubContext>> _notificationEventsMap 
            = new Dictionary<string, Action<IHubContext>>();

        public RedisHandler(ISubscriber subscriber, IRepository redis, IMapper mapper)
        {
            _redis = redis;
            _mapper = mapper;

            _notificationEventsMap.Add(Repository.LastTransactions, NotifyLastTransactions);

            subscriber.ChangeValue += Subscriber_ChangeValue;
        }


        private void Subscriber_ChangeValue(string channel, string value)
        {
            if (value != "set") return;
            string key = GetKey(channel);
            if (string.IsNullOrEmpty(key)) return;
            if (!_notificationEventsMap.ContainsKey(key)) return;

            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<BlockchainHub>();
            _notificationEventsMap[key](context);
        }

        private string GetKey(string channel)
        {
            if (string.IsNullOrEmpty(channel)) return String.Empty;

            int index = channel.IndexOf(':');
            if (index == 0) return String.Empty;

            string key = channel.Substring(index + 1);

            return key;
        }

        void NotifyLastTransactions(IHubContext context)
        {
            var transactions = _redis.GetLastTransactions();
            
            var transactionsVM = transactions.Select(t => _mapper.Map<TransactionVM>(t)).ToList();

            context.Clients.All.updateLastTransactions(transactionsVM);
        }
    }
}