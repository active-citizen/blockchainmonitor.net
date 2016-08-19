﻿using System.Linq;

namespace BlockchainMonitor.DataAccess.Context
{
    public interface IRepository<TId, TItem> where TItem : class
    {
        TItem Create();

        void Delete(TItem item);

        void Delete(TId id);

        IQueryable<TItem> GetAll();

        TItem GetById(TId id);

        void Insert(TItem item);

        void Update(TItem item);
    }
}