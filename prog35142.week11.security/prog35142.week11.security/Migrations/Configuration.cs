namespace prog35142.week11.security.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<prog35142.week11.security.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(prog35142.week11.security.Models.ApplicationDbContext context)
        {
            var store = new RoleStore<IdentityRole>(context);
            var manager = new RoleManager<IdentityRole>(store);

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var role = new IdentityRole { Name = "Admin" };
                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Staff"))
            {
                var role = new IdentityRole { Name = "Staff" };
                manager.Create(role);
            }


            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            //  This method will be called after migrating to the latest version.
            if (!(context.Users.Any(u => u.UserName == "student@sheridancollege.ca")))
            {
                var userToInsert = new ApplicationUser { UserName = "student@sheridancollege.ca", PhoneNumber = "9055551234" };
                userManager.Create(userToInsert, "student20!4");
                userManager.AddToRole(userToInsert.Id, "Admin");
            }

            if (!(context.Users.Any(u => u.UserName == "staff@sheridancollege.ca")))
            {
                
                var userToInsert = new ApplicationUser { UserName = "staff@sheridancollege.ca", PhoneNumber = "4165557894" };
                userManager.Create(userToInsert, "password!");
                userManager.AddToRole(userToInsert.Id, "Staff");
            }
        }
    }
}
