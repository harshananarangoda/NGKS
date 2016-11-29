using AutoMapper;
using AutoMapper.Configuration;
using NGKS.Entities;
using NGKS.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NGKS.Web.Infrastructure.Mappings
{
    /// <summary>
    /// Class: DomainToViewModelMappingProfile
    /// </summary>
    public class DomainToViewModelMappingProfile : Profile
    {
        /// <summary>
        /// Overriding the profile name
        /// </summary>
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        /// <summary>
        /// Set Configurations
        /// </summary>
        /// <returns>Configuration</returns>
        public static MapperConfigurationExpression Config()
        {
            var cfg = new MapperConfigurationExpression();
            cfg.CreateMap<Post, PostViewModel>()
                .ForMember(vm => vm.Category, map => map.MapFrom(m => m.Category.Name))
                .ForMember(vm => vm.CategoryID, map => map.MapFrom(m => m.Category.ID))
                .ForMember(vm => vm.CaptionURL, map => map.MapFrom(m => string.IsNullOrEmpty(m.CaptionURL) == true ? "unknown.jpg" : m.CaptionURL));

            cfg.CreateMap<Category, CategoryViewModel>()
                .ForMember(vm => vm.NumberOfPosts, map => map.MapFrom(g => g.Posts.Count()));

            return cfg;
        }
    }
}