using refactor_me.Data.Models.Products;
using refactor_me.Data.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace refactor_me.Data.Persistence.Implementation
{
    /// <summary>
    /// ProductStore
    /// </summary>
    public class ProductStore : IStore<Product>
    {
        //context
        private readonly RefactorMeContext _context;
        //Repository Interface
        private readonly IRepository _repository;

        public ProductStore()
        {
            _context = new RefactorMeContext();
            _repository = new Repository(_context);
        }

        //Create
        public void Create(Product item)
        {
            this._repository.Create(item);
        }

        //Delete
        public void Delete(Product item)
        {
            this._repository.Delete(item);
        }

        //Get
        public Product Get(Guid id)
        {
            return this._repository.GetById<Product>(id);
        }

        //Update
        public void Update(Product item)
        {
            this._repository.Update<Product>(item);
        }

        //Get All
        public List<Product> GetAll()
        {
            return this._repository.GetAll<Product>().ToList();
        }
        
        //Retrieve All
        public IEnumerable<Product> RetrieveAll(Expression<Func<Product, bool>> exp)
        {
            return this._repository.RetrieveAll<Product>(exp);
        }

        //Save all
        public void SaveAll()
        {
            this._repository.SaveAll();
        }
    }
}
