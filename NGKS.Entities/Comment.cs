using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGKS.Entities
{
    /// <summary>
    /// Class: Comment Entity
    /// </summary>
    public class Comment : IEntityBase
    {
        /// <summary>
        /// Int: ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Int: Post ID
        /// </summary>
        public int PostID { get; set; }

        /// <summary>
        /// Int: Parent Comment ID
        /// </summary>
        public int ParentCommentID { get; set; }

        /// <summary>
        /// String: Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Datetime: Added Date
        /// </summary>
        public DateTime AddedDate { get; set; }

        /// <summary>
        /// Int: User ID
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// DateTime: Update Time (Optional)
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// Navigation Property
        /// User: User
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// Navigation Property
        /// Post: Post
        /// </summary>
        public virtual Post Post { get; set; }
        
    }
}
