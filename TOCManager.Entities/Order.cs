using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOCManager.Entities
{
    public class Order : IProjectsEntityBase
    {
        public int ID { get; set; }

        public int ProjectId { get; set; }

        public int CustomerId { get; set; }
    }
}
