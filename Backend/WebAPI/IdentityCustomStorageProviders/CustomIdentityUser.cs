using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using BLL.Intrefaces;
using BLL.DTO;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.AspNet.Identity.Owin;
using System.Security.Claims;

namespace WebAPI.IdentityCustomStorageProviders
{

    //public class CustomAppUserManager : UserManager<CustomIdentityUser, int>
    //{
    //    public CustomAppUserManager(IUserStore<CustomIdentityUser, int> store)
    //        : base(store)
    //    {
    //    }

    //    public static ApplicationUserManager Create(IdentityFactoryOptions<CustomAppUserManager> options, IOwinContext context)
    //    {
    //        var manager = new ApplicationUserManager(new CustomUserStore(context.Get<ApplicationDbContext>()));

    //        return manager;
    //    }
    //}



    public class CustomIdentityUser : UserDTO, IUser<int>
    {
        public static CustomIdentityUser ConvertToCustomIdentityUser(UserDTO userDTO)
        {
            if (userDTO == null)
            {
                return null;
            }

            CustomIdentityUser user = new CustomIdentityUser()
            {
                Id = userDTO.Id,
                UserName = userDTO.UserName,
                Email = userDTO.Email,
                HashedPassword = userDTO.HashedPassword,
                Roles = userDTO.Roles
            };

            return user;
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<CustomIdentityUser, int> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class CustomUserStore : IUserStore<CustomIdentityUser, int>, IUserPasswordStore<CustomIdentityUser, int>, IUserRoleStore<CustomIdentityUser, int>
    {
        private IUserService userService;
        private IRoleService roleService;

        public CustomUserStore(IUserService userService, IRoleService roleService)
        {
            this.userService = userService;
            this.roleService = roleService;
        }

        public Task CreateAsync(CustomIdentityUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            this.userService.Add(user);

            return Task.FromResult<object>(null);
        }

        public Task DeleteAsync(CustomIdentityUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            this.userService.Delete(user.Id);

            return Task.FromResult<object>(null);
        }

        public Task<CustomIdentityUser> FindByIdAsync(int userId)
        {
            UserDTO userDTO = this.userService.GetById(userId);

            CustomIdentityUser user = CustomIdentityUser.ConvertToCustomIdentityUser(userDTO);

            return Task.FromResult<CustomIdentityUser>(user);
        }

        public Task<CustomIdentityUser> FindByNameAsync(string userName)
        {
            UserDTO userDTO = this.userService.GetUserByName(userName);

            CustomIdentityUser user = CustomIdentityUser.ConvertToCustomIdentityUser(userDTO);

            return Task.FromResult<CustomIdentityUser>(user);
        }

        public Task UpdateAsync(CustomIdentityUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            this.userService.Update(user);

            return Task.FromResult<object>(null);
        }


        public Task SetPasswordHashAsync(CustomIdentityUser user, string passwordHash)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            user.HashedPassword = passwordHash;

            return Task.FromResult<object>(null);
        }

        public Task<string> GetPasswordHashAsync(CustomIdentityUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            return Task.FromResult<string>(user.HashedPassword);
        }

        public Task<bool> HasPasswordAsync(CustomIdentityUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            return Task.FromResult<bool>(user.HashedPassword != null);
        }


        public Task AddToRoleAsync(CustomIdentityUser user, string roleName)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            if (String.IsNullOrEmpty(roleName))
            {
                throw new ArgumentNullException("roleName");
            }

            RoleDTO roleDTO = this.roleService.GetRoleByTitle(roleName);
            if (roleDTO == null)
            {
                Task.FromResult<object>(null);
            }

            if (user.Roles == null)
            {
                user.Roles = new List<RoleDTO>() { roleDTO };
            }
            else if (!user.Roles.Any(role => role.Id == roleDTO.Id))
            {
                user.Roles.Add(roleDTO);
                this.userService.Update(user);
            }

            return Task.FromResult<object>(null);
        }

        public Task RemoveFromRoleAsync(CustomIdentityUser user, string roleName)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            if (String.IsNullOrEmpty(roleName))
            {
                throw new ArgumentNullException("roleName");
            }

            RoleDTO roleDTO = this.roleService.GetRoleByTitle(roleName);
            bool userIsInRole = user.Roles.Any(role => role.Id == roleDTO.Id);

            if (roleDTO != null && userIsInRole)
            {
                user.Roles.Remove(roleDTO);
                this.userService.Update(user);
            }

            return Task.FromResult<object>(null);
        }

        public Task<IList<string>> GetRolesAsync(CustomIdentityUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            List<string> userRoles = user.Roles.Select(role => role.Title).ToList();

            return Task.FromResult<IList<string>>(userRoles);
        }

        public Task<bool> IsInRoleAsync(CustomIdentityUser user, string roleName)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            if (String.IsNullOrEmpty(roleName))
            {
                throw new ArgumentNullException("roleName");
            }

            RoleDTO roleDTO = this.roleService.GetRoleByTitle(roleName);
            bool userIsInRole = user.Roles.Any(role => role.Id == roleDTO.Id);

            return Task.FromResult<bool>(userIsInRole);
        }


        public void Dispose()
        {

        }

    }
}