﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public abstract class TaskBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public abstract TaskStatus Status { get; }
        public abstract DateTime? StartedOn { get; }
        public abstract DateTime? CompletedOn { get; }
    }
}
