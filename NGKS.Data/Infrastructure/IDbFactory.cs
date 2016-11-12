using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGKS.Data.Infrastructure
{
    /// <summary>
    /// Interface: IDbFactory
    /// </summary>
    public interface IDbFactory : IDisposable
    {
        /// <summary>
        /// Init Implementation
        /// </summary>
        /// <returns>NGKS context</returns>
        NGKSContext Init();
    }
}
