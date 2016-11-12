using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGKS.Entities
{
    /// <summary>
    /// Class: Role Entity
    /// </summary>
    public class Role : IEntityBase
    {
        /// <summary>
        /// Int: ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// String: Name
        /// </summary>
        public string Name { get; set; }
    }
}
