using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Common.Models
{
    public class User : Entity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
