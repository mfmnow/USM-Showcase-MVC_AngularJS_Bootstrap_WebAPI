namespace USM.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<USM.DAL.USMContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            //AutomaticMigrationDataLossAllowed = true;

            //if (System.Diagnostics.Debugger.IsAttached == false)
            //    System.Diagnostics.Debugger.Launch();
        }

        protected override void Seed(USM.DAL.USMContext context)
        {
              //This method will be called after migrating to the latest version.

              //You can use the DbSet<T>.AddOrUpdate() helper extension method 
              //to avoid creating duplicate seed data. E.g.

                context.UserRoles.AddOrUpdate(
                      p => p.Name,
                      new USM.DAL.Models.UserRole
                      {
                          Name = "Administrator",
                          IsDeleted = 0,
                          CreateDate = DateTime.Now,
                          LastUpdateDate = DateTime.Now,
                          ID = 1
                      },
                      new USM.DAL.Models.UserRole
                      {
                          Name = "User",
                          IsDeleted = 0,
                          CreateDate = DateTime.Now,
                          LastUpdateDate = DateTime.Now,
                          ID = 2
                      }
                    );

                context.Users.AddOrUpdate(
                  p => p.FullName,
                  new USM.DAL.Models.User { Username="mfm", 
                      Password="123", IsDeleted=0, UserIsDisabled=0, CreateDate=DateTime.Now, 
                      LastUpdateDate=DateTime.Now, RoleID=1, FullName = "Mohamed Farouk" }                      
                );
                for (int i = 0; i < 100; i++)
                {
                    context.Users.AddOrUpdate(
                      p => p.FullName,
                      new USM.DAL.Models.User
                      {
                          Username = "mfm" + i,
                          Password = "123",
                          IsDeleted = 0,
                          UserIsDisabled = 0,
                          CreateDate = DateTime.Now,
                          LastUpdateDate = DateTime.Now,
                          RoleID = 2,
                          FullName = "Mohamed" + i + " Farouk" + i
                      }
                    );
                }
            
            USMDatabaseDataInit _dbInit = new USMDatabaseDataInit();
            _dbInit.SeedData(context);
        }
    }
}
