﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOCManager.Entities.Interfaces;

namespace TOCManager.Entities
{
    public class Customer : IEntityBase
    {
        public int ID { get; set; }

        public string Name { get; set; }
    }
}