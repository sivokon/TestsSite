using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Intrefaces
{
    public interface IRoleService
    {
        IEnumerable<RoleDTO> GetAll();
        RoleDTO GetById(int id);
        void Add(RoleDTO entity);
        void Update(RoleDTO entity);
        void Delete(int id);

        RoleDTO GetRoleByTitle(string title);
    }
}
