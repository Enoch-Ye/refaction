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
    /// ProductOptionStore
    /// </summary>
    public class ProductOptionStore : IStore<ProductOption>
    {
        //Context
        private readonly RefactorMeContext _context;
        //Repository interface
        private readonly IRepository _repository;

        public ProductOptionStore()
        {
            _context = new RefactorMeContext();
            _repository = new Repository(_context);
        }

        //Create
        public void Create(ProductOption item)
        {
            this._repository.Create(item);
        }

        //Delete
        public void Delete(ProductOption item)
        {
            this._repository.Delete(item);
        }

        //Get
        public ProductOption Get(Guid id)
        {
            return this._repository.GetById<ProductOption>(id);
        }

        //Get All
        public List<ProductOption> GetAll()
        {
            return this._repository.GetAll<ProductOption>().ToList();
        }

        //Retrieve All
        public IEnumerable<ProductOption> RetrieveAll(Expression<Func<ProductOption, bool>> exp)
        {
            return this._repository.RetrieveAll<ProductOption>(exp);
        }

        //Save All
        public void SaveAll()
        {
            this._repository.SaveAll();
        }

        //Update
        public void Update(ProductOption item)
        {
            this._repository.Update<ProductOption>(item);
        }
    }
}
