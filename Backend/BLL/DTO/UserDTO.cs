using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class UserDTO : EntityDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }

        public List<RoleDTO> Roles { get; set; }
    }
}
