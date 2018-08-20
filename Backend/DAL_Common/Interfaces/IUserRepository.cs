using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_Common.Models;

namespace DAL_Common.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByName(string name);
        IEnumerable<User> GetUsersByUsernameKeyWord(string keyWord);
    }
}
