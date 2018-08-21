using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Intrefaces
{
    public interface IUserService
    {
        IEnumerable<UserDTO> GetAll();
        UserDTO GetById(int id);
        void Add(UserDTO entity);
        void Update(UserDTO entity);
        void Delete(int id);

        UserDTO GetUserByName(string name);

        IEnumerable<UserDTO> GetUsersByUsernameKeyWord(string keyWord);
    }
}
