using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace refactor_me.Data.Persistence.Interfaces
{
    /// <summary>
    /// IRepository
    /// </summary>
    public interface IRepository : IDisposable
    {
        //Get By Id
        T GetById<T>(Guid id) where T : class;
        //Get All
        IEnumerable<T> GetAll<T>() where T : class;
        //Create item 
        void Create<T>(T item) where T : class;
        //Retrieve item
        T Retrieve<T>(Expression<Func<T, bool>> exp) where T : class;
        //Retrieve all
        IEnumerable<T> RetrieveAll<T>(Expression<Func<T, bool>> exp) where T : class;
        //Delete item
        void Delete<T>(T item, bool tracked = false) where T : class;
        //Update item
        void Update<T>(T item) where T : class;
        //Save context
        void SaveAll();
    }

}
