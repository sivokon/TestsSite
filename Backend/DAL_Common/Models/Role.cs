using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Common.Models
{
    public class Role : Entity
    {
        public string Title { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
