using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGKS.Entities
{
    /// <summary>
    /// Class: Error Entity
    /// </summary>
    public class Error : IEntityBase
    {
        /// <summary>
        /// Int: ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// String: Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// String: StackTrace
        /// </summary>
        public string StackTrace { get; set; }

        /// <summary>
        /// DateTime: Time Occured
        /// </summary>
        public DateTime DateTimeOccured { get; set; }
    }
}
