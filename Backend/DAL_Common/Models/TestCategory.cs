﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Common.Models
{
    public class TestCategory : Entity
    {
        public string Title { get; set; }

        public virtual ICollection<Test> Tests { get; set; }
    }
}
