﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class RoleDTO : EntityDTO
    {
        public string Title { get; set; }
        public int UserId { get; set; }
    }
}
