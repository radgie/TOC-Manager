﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOCManager.Entities
{
    public class UserProjectRole : IProjectsEntityBase
    {
        public int ID { get; set; }

        public int UserId { get; set; }

        public int ProjectId { get; set; }

        public int ProjectRoleId { get; set; }

        public virtual ProjectRole Role { get; set; }
    }
}
