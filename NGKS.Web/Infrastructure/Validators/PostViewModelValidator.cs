using FluentValidation;
using NGKS.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NGKS.Web.Infrastructure.Validators
{
    /// <summary>
    /// Class: PostViewModelValidator
    /// </summary>
    public class PostViewModelValidator: AbstractValidator<PostViewModel>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public PostViewModelValidator()
        {
            RuleFor(post => post.CategoryID).GreaterThan(0)
                .WithMessage("Please select a category");

            RuleFor(post => post.Name).NotEmpty().Length(0,250)
                .WithMessage("Please enter a POST name");

            RuleFor(post => post.Header).NotEmpty().Length(0, 250)
                .WithMessage("Please enter a POST header");

            RuleFor(post => post.Tags).NotEmpty()
                .WithMessage("Please enter tags");

            RuleFor(post => post.Content).NotEmpty()
                .WithMessage("Please enter a content");
        }
    }
}