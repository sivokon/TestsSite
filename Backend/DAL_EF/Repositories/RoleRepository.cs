using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_Common.Models;
using DAL_Common.Interfaces;
using DAL_EF.EF;

namespace DAL_EF.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(TestDbContext context) : base(context)
        {
        }

        Role IRoleRepository.GetRoleByTitle(string title)
        {
            return this.GetSingleByPredicate(role => role.Title == title);
        }

    }
}
