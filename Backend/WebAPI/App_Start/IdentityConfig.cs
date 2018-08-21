using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using WebAPI.Models;

using WebAPI.IdentityCustomStorageProviders;
using Ninject;
using BLL.Intrefaces;
using WebAPI.App_Start;
using System.Web.Mvc;

namespace WebAPI
{
    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.

    // !!! All entities "<ApplicationUser>" were changed for "<CustomIdentityUser, int>"

    public class ApplicationUserManager : UserManager<CustomIdentityUser, int>
    {
        public ApplicationUserManager(IUserStore<CustomIdentityUser, int> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            //var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));
            var manager = new ApplicationUserManager(
                new CustomUserStore(
                    (IUserService)DependencyResolver.Current.GetService(typeof(IUserService)),
                    (IRoleService)DependencyResolver.Current.GetService(typeof(IRoleService))));

            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<CustomIdentityUser, int>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = false
            };
            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<CustomIdentityUser, int>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }
}
