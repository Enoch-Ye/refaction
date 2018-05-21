using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace refactor_me.Data.Persistence.Interfaces
{
    /// <summary>
    /// IStore interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IStore<T> where T : class
    {
        //Get
        T Get(Guid Id);
        //Delete
        void Delete(T item);
        //Update
        void Update(T item);
        //Create
        void Create(T item);
        //GetAll
        List<T> GetAll();
        //Retrieve All
        IEnumerable<T> RetrieveAll(Expression<Func<T, bool>> exp);
        //Save All
        void SaveAll();
    }
}
