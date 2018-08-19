using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using WebAPI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

[assembly: OwinStartup(typeof(WebAPI.Startup))]

namespace WebAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndAdmin();
        }

        private void CreateRolesAndAdmin()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
  
            if (!roleManager.RoleExists("Admin"))
            { 
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                // admin user
                ApplicationUser user = new ApplicationUser();
                user.UserName = "admin@ukr.net";
                user.Email = "admin@ukr.net";

                string password = "123@Admin";

                IdentityResult createUser = UserManager.Create(user, password);
  
                if (createUser.Succeeded)
                {
                    UserManager.AddToRole(user.Id, "Admin");
                }
            }
   
            if (!roleManager.RoleExists("Editor"))
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Editor";
                roleManager.Create(role);
            }
 
            if (!roleManager.RoleExists("User"))
            {
                IdentityRole role = new IdentityRole();
                role.Name = "User";
                roleManager.Create(role);
            }
        }

    }
}
