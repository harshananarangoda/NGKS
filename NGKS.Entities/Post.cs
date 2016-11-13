using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGKS.Entities
{
    /// <summary>
    /// Class: Post Entity
    /// </summary>
    public class Post : IEntityBase
    {
        /// <summary>
        /// Int: ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// String: Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// String: Header
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// String: Tags
        /// </summary>
        public string Tags { get; set; }

        /// <summary>
        /// String: Content
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Int: Category ID
        /// </summary>
        public int CategoryID { get; set; }

        /// <summary>
        /// DateTime:CreatedDate
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Inr: User ID
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// DateTime: Updated Date
        /// </summary>
        public DateTime UpdatedDate { get; set; }

        /// <summary>
        /// String: Video URL
        /// </summary>
        public string VideoURL { get; set; }

        /// <summary>
        /// String: Caption URL
        /// </summary>
        public string CaptionURL { get; set; }

        /// <summary>
        /// Int: No of Upvotes
        /// </summary>
        public int UpVotes { get; set; }

        /// <summary>
        /// Int: No of Downvotes
        /// </summary>
        public int DownVotes { get; set; }

        /// <summary>
        /// Navigation Property
        /// Category: Category
        /// </summary>
        public virtual Category Category { get; set; }

        /// <summary>
        /// Navigation Property
        /// User: User
        /// </summary>
        public virtual User User { get; set; }
        
    }
}
