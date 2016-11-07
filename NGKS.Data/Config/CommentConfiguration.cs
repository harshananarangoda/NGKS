using NGKS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGKS.Data.Config
{
    public class CommentConfiguration : EntityBaseConfiguration<Comment>
    {
        public CommentConfiguration()
        {
            Property(cm => cm.PostID).IsRequired();
            Property(cm => cm.ParentCommentID).IsRequired();
            Property(cm => cm.Message).IsRequired().HasMaxLength(500);
            Property(cm => cm.AddedDate).IsRequired();
            Property(cm => cm.UserID).IsRequired();
            Property(cm => cm.UpdateTime);

        }
    }
}
