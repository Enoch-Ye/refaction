using Ninject.Modules;
using refactor_me.Data.Models.Products;
using refactor_me.Data.Persistence.Implementation;
using refactor_me.Data.Persistence.Interfaces;
using refactor_me.Models;
using refactor_me.Models.ProductOptions;
using refactor_me.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace refactor_me.Infra.DependencyManagement
{
    /// <summary>
    /// Web Module 
    /// </summary>
    public class WebModule : NinjectModule
    {
        //Bind load
        public override void Load()
        {
            Bind<IStore<Product>>().To<ProductStore>();
            Bind<IStore<ProductOption>>().To<ProductOptionStore>();
            Bind<IService<ProductDTO, Product, ProductOptionDTO>>().To<ProductService>();
        }
    }
}