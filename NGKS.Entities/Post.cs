using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGKS.Entities
{
    public class Post : IEntityBase
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Header { get; set; }
        public string Tags { get; set; }
        public string Content { get; set; }
        public int CategoryID { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserID { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string VideoURL { get; set; }
        public string CaptionURL { get; set; }
        public int UpVotes { get; set; }
        public int DownVotes { get; set; }

        public virtual Category Category { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
