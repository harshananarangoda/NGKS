using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NGKS.Web.Models
{
    /// <summary>
    /// Class: PostViewModel
    /// </summary>
    public class PostViewModel: IValidatableObject
    {
        /// <summary>
        /// Post ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Post Title
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Post Header Details
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// Tag List of the post
        /// </summary>
        public string Tags { get; set; }

        /// <summary>
        /// Content of the post
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Category ID
        /// </summary>
        public int CategoryID { get; set; }

        /// <summary>
        /// Post Created Date
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// User ID
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Post Updated Date
        /// </summary>
        public DateTime UpdateDate { get; set; }

        /// <summary>
        /// Video URl
        /// </summary>
        public string VideoURL { get; set; }

        /// <summary>
        /// Caption URL
        /// </summary>
        public string CaptionURL { get; set; }

        /// <summary>
        /// UpVotes
        /// </summary>
        public int UpVotes { get; set; }

        /// <summary>
        /// DownVotes
        /// </summary>
        public int DownVotes { get; set; }

        /// <summary>
        /// Validate object
        /// </summary>
        /// <param name="validationContext">validation context</param>
        /// <returns>validation results</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new PostViewModelValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }
}