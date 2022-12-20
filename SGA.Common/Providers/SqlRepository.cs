using Microsoft.EntityFrameworkCore;
using SGA.Common.Extensions;
using SGA.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SGA.Common.Providers
{
    /// <summary>
    /// Implementação base do Repository pattern para bancos de dados SQL.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public abstract class SqlRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        protected DbContext Context { get; }

        protected readonly DbSet<TEntity> DbSet;

        protected SqlRepository(DbContext dbContext)
        {
            Context = dbContext;
            DbSet = dbContext.Set<TEntity>();
        }

        public void Add(TEntity item)
        {
            DbSet.Add(item);

            Context.SaveChanges();
        }

        public void Delete(TEntity item)
        {
            DbSet.Remove(item);

            Context.SaveChanges();
        }

        public void DeleteById<T>(T id)
        {
            var entity = DbSet.Find(id);

            DbSet.Remove(entity);

            Context.SaveChanges();
        }

        public void CreateOrUpdate(TEntity item)
        {
            var entity = DbSet.Find(item.Id);

            if (entity != null)
                DbSet.Update(item);
            else
            {
                DbSet.Add(item);
                Context.SaveChanges();
            }
        }

        public void Update(TEntity item)
        {
            DbSet.Update(item);

            Context.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter, params string[] includeEntities)
        {
            return DbSet.Where(filter).IncludeMultiple(includeEntities).SingleOrDefault();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return DbSet.Where(filter).SingleOrDefault();
        }


        public IEnumerable<TEntity> GetAll(params string[] includeEntities)
        {
            return DbSet.IncludeMultiple(includeEntities).AsEnumerable();
        }

        public IEnumerable<TEntity> FindWhere(Expression<Func<TEntity, bool>> filter, params string[] includeEntities)
        {
            return DbSet.Where(filter).IncludeMultiple(includeEntities);
        }

        public bool HasAny(Func<TEntity, bool> predicate)
        {
            return DbSet.Any(predicate);
        }
    }

}
