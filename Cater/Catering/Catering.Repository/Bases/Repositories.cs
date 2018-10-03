using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catering.Repository.Interfaces;

namespace Catering.Repository.Bases
{
    public class Repositories
    {
     
        public static IIletisimRepository IletisimRepository
        {
            get { return ServiceIoc.Container.Resolve<IIletisimRepository>(); }
        }
        public static IAdminRepository AdminRepository
        {
            get { return ServiceIoc.Container.Resolve<IAdminRepository>(); }
        }
        public static MyEnt UnitOfWorkCurrent
        {
            get { return ServiceIoc.Container.Resolve<MyEnt>(); }
        }

    }
}
