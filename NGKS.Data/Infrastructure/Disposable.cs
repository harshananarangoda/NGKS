using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGKS.Data.Infrastructure
{
    /// <summary>
    /// Class: Disposable
    /// </summary>
    public class Disposable : IDisposable
    {
        private bool isDisposed;

        ~Disposable()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);

        }

        private void Dispose(bool disposing)
        {
            if(!isDisposed && disposing)
            {
                DisposeCore();
            }

            isDisposed = true;
        }

        //Custom dispose objects
        protected virtual void DisposeCore()
        {
        }
    }
}
