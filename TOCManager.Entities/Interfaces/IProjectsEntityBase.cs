using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOCManager.Entities
{
    public interface IProjectsEntityBase : IEntityBase
    {
        int ProjectId { get; set; }
    }
}
