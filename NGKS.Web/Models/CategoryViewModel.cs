using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NGKS.Web.Models
{
    /// <summary>
    /// Class: CategoryViewModel
    /// </summary>
    public class CategoryViewModel 
    {
        /// <summary>
        /// Category ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Category Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Number of posts related to category
        /// </summary>
        public int NumberOfPosts { get; set; }
    }
}