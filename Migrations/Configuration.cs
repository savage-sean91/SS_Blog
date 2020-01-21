namespace SS_Blog.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using SS_Blog.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SS_Blog.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "SS_Blog.Models.ApplicationDbContext";
        }

        protected override void Seed(SS_Blog.Models.ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(context));
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }
           
            if (!context.Roles.Any(r => r.Name == "Moderator"))
            {
                roleManager.Create(new IdentityRole { Name = "Moderator" });
            }

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!context.Users.Any(u => u.Email == "sean.savage@coderfoundry.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "sean.savage@coderfoundry.com",
                    Email = "sean.savage@coderfoundry.com",
                    FirstName = "Sean",
                    LastName = "Savage",
                    DisplayName = "SeanSavage"
                }, "Abc&123!");
            }

            var userId = userManager.FindByEmail("sean.savage@coderfoundry.com").Id;
            userManager.AddToRole(userId, "Admin");

            if (!context.Users.Any(u => u.Email == "moderator@coderfoundry.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "moderator@coderfoundry.com",
                    Email = "moderator@coderfoundry.com",
                    FirstName = "CF",
                    LastName = "moderator",
                    DisplayName = "CFMOD"
                }, "Abc&123!");
            }

            userId = userManager.FindByEmail("moderator@coderfoundry.com").Id;
            userManager.AddToRole(userId, "Moderator");




            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
