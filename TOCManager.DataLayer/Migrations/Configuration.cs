using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOCManager.Entities;

namespace TOCManager.DataLayer.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<TOCManagerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TOCManagerContext context)
        {
            // create roles
            context.ProjectRoleSet.AddOrUpdate(r => r.RoleName, GenerateRoles());

            // username: chsakell, password: homecinema
            context.UserSet.AddOrUpdate(u => u.Email, new User[]{
                new User()
                {
                    Email="admin@tocmanager.com",
                    Username="admin",
                    HashedPassword ="XwAQoiq84p1RUzhAyPfaMDKVgSwnn80NCtsE8dNv3XI=",
                    Salt = "mNKLRbEFCH8y1xIyTXP4qA==",
                    IsLocked = false,
                    CreatedOn = DateTime.Now
                }
            });

            // // create user-admin for admin
            //context.UserProjectRoleSet.AddOrUpdate(new UserProjectRole[] {
            //    new UserProjectRole() {
            //        RoleId = 1, // admin
            //        UserId = 1  // admin
            //    }
            //});
        }

        private ProjectRole[] GenerateRoles()
        {
            ProjectRole[] _roles = new ProjectRole[]{
                new ProjectRole()
                {
                    RoleName="Admin"
                },
                new ProjectRole()
                {
                    RoleName="Owner"
                },
                new ProjectRole()
                {
                    RoleName="Manager"
                },
                new ProjectRole()
                {
                    RoleName="Salesman"
                },
                new ProjectRole()
                {
                    RoleName="Operator"
                }
            };

            return _roles;
        }
    }
}
