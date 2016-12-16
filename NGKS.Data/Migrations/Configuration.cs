namespace NGKS.Data.Migrations
{
    using Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NGKS.Data.NGKSContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NGKS.Data.NGKSContext context)
        {

            //  create genres
            context.CategorySet.AddOrUpdate(g => g.Name, GenerateCategories());

            // create movies
            context.PostSet.AddOrUpdate(m => m.Header, GeneratePosts());

            // create roles
            context.RoleSet.AddOrUpdate(r => r.Name, GenerateRoles());

            // username: harshana, password: homecinema
            context.UserSet.AddOrUpdate(u => u.Email, new User[]{
                new User()
                {
                    Email="harshanamcrox10@gmail.com",
                    Username="harshana",
                    Password ="XwAQoiq84p1RUzhAyPfaMDKVgSwnn80NCtsE8dNv3XI=",
                    Salt = "mNKLRbEFCH8y1xIyTXP4qA==",
                    IsLocked = false,
                    DateCreated = DateTime.Now
                }
            });

            // // create user-admin for chsakell
            context.UserRoleSet.AddOrUpdate(new UserRole[] {
                new UserRole() {
                    RoleID = 1, // admin
                    UserID = 1  // harshana
                }
            });

        }

        private Role[] GenerateRoles()
        {
            Role[] _roles = new Role[]{
                new Role()
                {
                    Name="Admin"
                }
            };

            return _roles;
        }

        private Category[] GenerateCategories()
        {
            Category[] _categories = new Category[]
            {
                new Category()
                {
                    Name = "ASP.NET"
                },
                new Category()
                {
                    Name = "Angular JS"
                },
                new Category()
                {
                    Name = "ASP.NET MVC"
                }
            };

            return _categories;
        }

        private Post[] GeneratePosts()
        {
            Post[] _posts = new Post[]
            {
                new Post()
                {
                    CaptionURL = "http://www.ocalaitpros.com/wp-content/uploads/2015/02/31dfef58-1812-4523-ab35-c8bf20fcfd83.png",
                    CategoryID = 10,
                    Content = @"There are a number of ways to build a website and all of them have their advantages depending on the type of site that you’re trying to design. The one that I’ll talk about here is Microsoft’s contribution to the world of web design – ASP.NET.
ASP.NET is a development framework for designing dynamic websites and web applications.The word framework indicates that it’s a development system which includes one or more languages along with various tools for working with those languages.A framework can also allow for additional tools and code libraries to be added onto it by third parties.In this case, the ASP.NET framework includes all of the.NET languages, typically either C# or VB.NET, and a powerful IDE in the form of Microsoft Visual Studio, a free download from Microsoft.",
                    CreatedDate = (DateTime)DateTime.Now,
                    DownVotes = 0,
                    Header = "ASP.Net tutorial",
                    Name = "ASP.Net tutorial",
                    Tags = "ASP.Net, AngularJS, MVC",
                    UpVotes = 0,
                    UserID = 1,
                   UpdatedDate = DateTime.Now                    
                }
            };

            return _posts;
        }
    }
}
