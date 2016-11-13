using NGKS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NGKS.Data.Repositories
{
    /// <summary>
    /// Interface: IEntityRepository
    /// </summary>
    /// <typeparam name="T">T : Type of Class</typeparam>
    public interface IEntityRepository<T> where T : class, IEntityBase, new()
    {
        /// <summary>
        /// Get All with including 
        /// </summary>
        /// <param name="includeProperties">Linq expression to include</param>
        /// <returns>IQueryable<T></returns>
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);

        /// <summary>
        /// All Property
        /// </summary>
        IQueryable<T> All { get; }

        /// <summary>
        /// Get All
        /// </summary>
        /// <returns>IQueryable<T></returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Get Sigle object
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Object: T</returns>
        T GetSingle(int id);

        /// <summary>
        /// Find By
        /// </summary>
        /// <param name="predicate">Linq expression to find</param>
        /// <returns>Queryable<T></returns>
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="entity">Entity</param>
        void Add(T entity);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="entity">Entity</param>
        void Delete(T entity);

        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="entity">Entity</param>
        void Edit(T entity);
    }
}
