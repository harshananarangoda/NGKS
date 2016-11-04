using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGKS.Entities
{
    public class Comment : IEntityBase
    {
        public int ID { get; set; }
        public int PostID { get; set; }
        public int ParentCommentID { get; set; }
        public string Message { get; set; }
        public DateTime AddedDate { get; set; }
        public int UserID { get; set; }

        public virtual User User { get; set; }
        public virtual Post Post { get; set; }
        public virtual Comment ParentComment { get; set; }
    }
}
