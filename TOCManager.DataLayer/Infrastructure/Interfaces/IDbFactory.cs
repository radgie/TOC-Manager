using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOCManager.DataLayer.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        TOCManagerContext Init();
    }
}
