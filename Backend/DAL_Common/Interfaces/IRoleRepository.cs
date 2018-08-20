using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_Common.Models;

namespace DAL_Common.Interfaces
{
    public interface IRoleRepository : IRepository<Role>
    {
        Role GetRoleByTitle(string title);
    }
}
