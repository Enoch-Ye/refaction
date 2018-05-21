using AutoMapper;
using Ninject.Modules;
using refactor_me.Infra.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace refactor_me.Infra.DependencyManagement
{
    /// <summary>
    /// AutoMapper Module
    /// </summary>
    public class AutoMapperModule : NinjectModule
    {
        //Load bind
        public override void Load()
        {
            Bind<IMapper>().ToMethod(AutoMapper).InSingletonScope();
        }

        //Bind method
        private IMapper AutoMapper(Ninject.Activation.IContext context)
        {
            var profiles =
                from t in typeof(ModelMappingProfile).Assembly.GetTypes()
                where typeof(Profile).IsAssignableFrom(t)
                select (Profile)Activator.CreateInstance(t);

            Mapper.Initialize(cfg =>
            {
                foreach (var profile in profiles)
                {
                    cfg.AddProfile(profile);
                }
            });

            Mapper.AssertConfigurationIsValid();
            return Mapper.Instance;
        }
    }
}