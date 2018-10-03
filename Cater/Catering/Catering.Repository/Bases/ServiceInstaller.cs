using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Catering.Repository.Bases
{
   public class ServiceInstaller: IWindsorInstaller
    {

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var dbRegistration =
                Component.For<MyEnt>().LifeStyle.PerWebRequest.UsingFactoryMethod(p => new MyEnt()).LifeStyle.Singleton;
            container.Register(dbRegistration);

            container.Register(
                Classes.FromAssemblyNamed("Catering.Repository")
                    .Where(t => t.Name.EndsWith("Repository"))
                    .WithService.DefaultInterfaces()
                    .LifestyleTransient());
        }
    }
}
