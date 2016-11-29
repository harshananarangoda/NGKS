using AutoMapper;
using AutoMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NGKS.Web.Infrastructure.Mappings
{
    /// <summary>
    /// Class: AutoMapperConfiguration
    /// </summary>
    public class AutoMapperConfiguration
    {
        /// <summary>
        /// Automapper Configurations
        /// </summary>
        public static void Configure()
        {
            Mapper.Initialize(DomainToViewModelMappingProfile.Config());
        }
    }
}