using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGKS.Data.Infrastructure
{
    /// <summary>
    /// Interface: IUnitOfWork
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Commit 
        /// </summary>
        void Commit();
    }
}
