using NGKS.Data.Config;
using NGKS.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGKS.Data
{
    class NGKSContext : DbContext
    {
        public NGKSContext() : base("NGKS")
        {
            Database.SetInitializer<NGKSContext>(null);
        }

        #region Entity Setes

        public IDbSet<User> UserSet { get; set; }
        public IDbSet<UserRole> UserRoleSet { get; set; }
        public IDbSet<Role> RoleSet { get; set; }
        public IDbSet<Post> PostSet { get; set; }
        public IDbSet<Category> CategorySet { get; set; }
        public IDbSet<Comment> CommentSet { get; set; }
        public IDbSet<Error> ErrorSet { get; set; }

        #endregion

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new UserRoleConfiguration());
            modelBuilder.Configurations.Add(new PostConfiguration());
            modelBuilder.Configurations.Add(new CommentConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
        }
    }
}
