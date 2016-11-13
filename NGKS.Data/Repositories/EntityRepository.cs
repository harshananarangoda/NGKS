using NGKS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using NGKS.Data.Infrastructure;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace NGKS.Data.Repositories
{
    /// <summary>
    /// Class: EntityRepository
    /// </summary>
    public class EntityRepository<T> : IEntityRepository<T> where T : class, IEntityBase, new()
    {
        #region Properties

        /// <summary>
        /// Data context
        /// </summary>
        private NGKSContext dataContext;

        /// <summary>
        /// DBFactory
        /// </summary>
        protected IDbFactory DBFactory
        {
            get;
            private set;
        }

        /// <summary>
        /// DBContext
        /// </summary>
        protected NGKSContext dbContext
        {
            get { return dataContext ?? (dataContext = DBFactory.Init()); }
        }

        #endregion
        
        public EntityRepository(IDbFactory dbFactory)
        {
            DBFactory = dbFactory;
        }

        public IQueryable<T> All
        {
            get
            {
                return GetAll();
            }
        }

        public void Add(T entity)
        {
            DbEntityEntry dbEntityEntry = dbContext.Entry<T>(entity);
            dbContext.Set<T>().Add(entity);
        }

        public IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = dbContext.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public void Delete(T entity)
        {
            DbEntityEntry dbEntityEntry = dbContext.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Deleted;
        }

        public void Edit(T entity)
        {
            DbEntityEntry dbEntityEntry = dbContext.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Modified;
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return dbContext.Set<T>().Where(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return dbContext.Set<T>();
        }

        public T GetSingle(int id)
        {
            return GetAll().FirstOrDefault(x => x.ID == id);
        }
    }
}
