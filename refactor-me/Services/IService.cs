using refactor_me.Data.Models.Products;
using refactor_me.Models.ProductOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace refactor_me.Services
{
    /// <summary>
    /// IService
    /// </summary>
    /// <typeparam name="T">DTO</typeparam>
    /// <typeparam name="R">Domain Entity</typeparam>
    /// <typeparam name="C">Children DTO</typeparam>
    public interface IService<T, R, C> where T : class where R : class where C : class
    {
        //Create
        void Create(T item);
        //Update
        void Update(Guid id, T item);
        //Get
        T Get(Guid id);
        //Delete
        void Delete(Guid id);
        //GetAll
        List<T> GetAll();
        //RetrieveAll
        List<T> RetrieveAll(Expression<Func<R, bool>> exp);
        //CreateChild
        void CreateChild(Guid id, C child);
        //UpdateChild
        void UpdateChild(Guid id, Guid childId, C child);
        //DeleteChild
        void DeleteChild(Guid id, Guid childId);
        //GetChildren
        List<C> GetChildren(Guid id, Guid child);
    }
}
