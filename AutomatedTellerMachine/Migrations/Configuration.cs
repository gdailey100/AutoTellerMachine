namespace AutomatedTellerMachine.Migrations
{
    //using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using AutomatedTellerMachine.Models;
    using AutomatedTellerMachine.Services;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<AutomatedTellerMachine.Models.IApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "AutomatedTellerMachine.Models.ApplicationDbContext";
        }

        protected override void Seed(AutomatedTellerMachine.Models.IApplicationDbContext context)
        {
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            if (!context.Users.Any(t=>t.UserName =="admin2@mvcatm.com"))
            {
                var user = new ApplicationUser { UserName = "admin2@mvcatm.com", Email = "admin2@mvcatm.com" };
                userManager.Create(user, "passW0rd!");
                var service = new CheckingAccountService(context);
                service.CreateCheckingAccount("admin", "user", user.Id, 1000);

                context.Roles.AddOrUpdate(r => r.Name, new IdentityRole { Name = "Admin" } );

                context.SaveChanges();

                userManager.AddToRole(user.Id, "Admin");
            }
            context.Transactions.Add(new Transaction { Amount = 75, CheckingAccountId = 9 });
            context.Transactions.Add(new Transaction { Amount = -25, CheckingAccountId = 9 });
            context.Transactions.Add(new Transaction { Amount = 100000, CheckingAccountId = 9 });
            context.Transactions.Add(new Transaction { Amount = 19.99m, CheckingAccountId = 9 });
            context.Transactions.Add(new Transaction { Amount = 64.40m, CheckingAccountId = 9 });
            context.Transactions.Add(new Transaction { Amount = 100, CheckingAccountId = 9 });
            context.Transactions.Add(new Transaction { Amount = -300, CheckingAccountId = 9 });
            context.Transactions.Add(new Transaction { Amount = 255.75m, CheckingAccountId = 9 });
            context.Transactions.Add(new Transaction { Amount = 198, CheckingAccountId = 9 });
            context.Transactions.Add(new Transaction { Amount = 2, CheckingAccountId = 9 });
            context.Transactions.Add(new Transaction { Amount = 50, CheckingAccountId = 9 });
            context.Transactions.Add(new Transaction { Amount = -1.50m, CheckingAccountId = 9 });
            context.Transactions.Add(new Transaction { Amount = 6100, CheckingAccountId = 9 });
            context.Transactions.Add(new Transaction { Amount = 164.84m, CheckingAccountId = 9 });
            context.Transactions.Add(new Transaction { Amount = .01m, CheckingAccountId = 9 });

        }

    }
}
