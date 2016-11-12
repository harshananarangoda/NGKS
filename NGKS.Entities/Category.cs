using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGKS.Entities
{
    /// <summary>
    /// Class: Category Entity
    /// </summary>
    public class Category : IEntityBase
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
        /// Navigation Property
        /// ICollection<Post>: Posts
        /// </summary>
        public virtual ICollection<Post> Posts { get; set; }
    }
}
