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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(TestDbContext context) : base(context)
        {
        }

        User IUserRepository.GetUserByName(string name)
        {
            return this.GetSingleByPredicate(user => user.UserName == name);
        }

        IEnumerable<User> IUserRepository.GetUsersByUsernameKeyWord(string keyWord)
        {
            return this.GetManyByPredicate(user => user.UserName.Contains(keyWord));
        }

        public override void Update(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException();
            }

            User userToUpdate = _dbSet.Find(user.Id);

            if (userToUpdate == null)
            {
                throw new ArgumentException();
            }

            _context.Entry(userToUpdate).CurrentValues.SetValues(user);

            userToUpdate.Roles = _dbSet.Select(role => this._context.Roles.Find(role.Id)).ToList();
        }

    }
}
