using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace BlockchainMonitor.DataAccess.Context
{
    
    public class RepositoryBase<TId, TItem> : IRepository<TId, TItem> where TItem : class where TId : IEquatable<TId>
    {
        private readonly Expression<Func<TItem, TId>> idAccessor;
        private readonly DbContext dbContext;

        public RepositoryBase(DbContext dbContext, Expression<Func<TItem, TId>> idAccessor)
        {
            this.dbContext = dbContext;
            this.idAccessor = idAccessor;
        }

        public TItem GetById(TId id)
        {
            var set = dbContext.Set(typeof(TItem));

            var memberName = ((MemberExpression)idAccessor.Body).Member.Name;
            var parameterExpression = Expression.Parameter(typeof(TItem), "item");
            var propertyExpression = Expression.Property(parameterExpression, memberName);
            var constantExpression = Expression.Constant(id, typeof(TId));

            var matchById = Expression.Lambda<Func<TItem, bool>>(Expression.Equal(propertyExpression, constantExpression), parameterExpression);

            return set.Cast<TItem>().FirstOrDefault(matchById);
        }

        public IQueryable<TItem> GetAll()
        {
            try
            {
                var set = dbContext.Set(typeof(TItem));
                return set.Cast<TItem>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TItem Create()
        {
            var set = dbContext.Set(typeof(TItem));
            return (TItem)set.Create();
        }

        public void Insert(TItem item)
        {
            var set = dbContext.Set(typeof(TItem));
            set.Add(item);
            dbContext.SaveChanges();
        }

        public void Insert(IEnumerable<TItem> items)
        {
            var set = dbContext.Set(typeof(TItem));
            set.AddRange(items);
            dbContext.SaveChanges();
        }

        public void Update(TItem item)
        {
            var entry = dbContext.Entry(item);
            entry.State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        public void Delete(TItem item)
        {
            var set = dbContext.Set(typeof(TItem));
            set.Remove(item);
            dbContext.SaveChanges();
        }

        public void Delete(TId id)
        {
            var item = GetById(id);
            Delete(item);
        }
    }
}
