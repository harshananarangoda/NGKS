using NGKS.Web.Infrastructure.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace NGKS.Web.App_Start
{
    /// <summary>
    /// Class: Bootstrapper
    /// </summary>
    public class Bootstrapper
    {
        public static void Run()
        {
            // Autofac Config
            AutofacWebapiConfig.Initialize(GlobalConfiguration.Configuration);
            // Auto Mapper Config
            AutoMapperConfiguration.Configure();
        }
    }
}