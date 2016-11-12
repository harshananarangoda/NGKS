using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGKS.Data.Infrastructure
{
    /// <summary>
    /// Class: Unit of work
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// IDbFactory: DBFactory
        /// </summary>
        private readonly IDbFactory dbFactory;
        /// <summary>
        /// NGKSContext: dbContext
        /// </summary>
        private NGKSContext dbContext;

        /// <summary>
        /// Unit of work
        /// </summary>
        /// <param name="dbFactory">dbfactory</param>
        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        /// <summary>
        /// NGKSContext: DbContext
        /// </summary>
        public NGKSContext DbContext
        {
            get
            {
                return dbContext ?? (dbContext = dbFactory.Init());
            }
        }
        
        /// <summary>
        /// Commit
        /// </summary>
        public void Commit()
        {
            DbContext.Commit();
        }
    }
}
