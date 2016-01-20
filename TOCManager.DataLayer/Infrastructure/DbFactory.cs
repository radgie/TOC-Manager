using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOCManager.DataLayer.Infrastructure
{
    public class DbFactory : IDisposable, IDbFactory
    {
        private TOCManagerContext dbContext;

        private bool isDisposed;

        public TOCManagerContext Init()
        {
            return dbContext ?? (dbContext = new TOCManagerContext());
        }

        ~DbFactory()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                if (dbContext != null)
                {
                    dbContext.Dispose();
                }  
            }

            isDisposed = true;
        }
    }
}
