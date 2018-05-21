using Ninject.Modules;
using refactor_me.Data.Models.Products;
using refactor_me.Data.Persistence.Implementation;
using refactor_me.Data.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refactor_me.Data.Infra.DependencyManagement
{
    /// <summary>
    /// Data Module
    /// </summary>
    public class DataModule : NinjectModule
    {
        //Load binding
        public override void Load()
        {
            Bind<IRepository>().To<Repository>();
            Bind<IStore<Product>>().To<ProductStore>();
        }
    }
}
