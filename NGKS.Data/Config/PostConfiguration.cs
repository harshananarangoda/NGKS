using NGKS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGKS.Data.Config
{
    public class PostConfiguration : EntityBaseConfiguration<Post>
    {
        public PostConfiguration()
        {
            Property(c => c.Name).IsRequired().HasMaxLength(50);
            Property(c => c.Header).IsRequired().HasMaxLength(50);
            Property(c => c.Tags).IsRequired();
            Property(c => c.Content).IsRequired();
            Property(c => c.CategoryID).IsRequired();
            Property(c => c.CreatedDate).IsRequired();
            Property(c => c.UserID).IsRequired();
            Property(c => c.UpdatedDate).IsOptional();
            Property(c => c.VideoURL).IsOptional();
            Property(c => c.CaptionURL).IsOptional();
            Property(c => c.UpVotes).IsOptional();
            Property(c => c.DownVotes).IsOptional();
            HasMany(c => c.Comments).WithRequired(r => r.Post).HasForeignKey(r => r.PostID);
        }
    }
}
