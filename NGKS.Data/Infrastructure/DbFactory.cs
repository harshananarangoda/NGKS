using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGKS.Data.Infrastructure
{
    /// <summary>
    /// Class: DbFactory
    /// </summary>
    public class DbFactory : Disposable, IDbFactory
    {
        /// <summary>
        /// NGKS Context
        /// </summary>
        NGKSContext dbContext;

        /// <summary>
        /// Init Implementation
        /// </summary>
        /// <returns>NGKS Context</returns>
        public NGKSContext Init()
        {
            return dbContext ?? (dbContext = new NGKSContext());
        }

        /// <summary>
        /// Dispose Core
        /// </summary>
        protected override void DisposeCore()
        {
            if(dbContext != null)
            {
                dbContext.Dispose();
            }
        }
    }
}
