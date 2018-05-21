using refactor_me.Data.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace refactor_me.Data.Persistence.Implementation
{
    /// <summary>
    /// Generic Respository
    /// </summary>
    public class Repository : IRepository
    {
        private bool _disposedValue;

        private readonly RefactorMeContext _context;

        public Repository(RefactorMeContext context)
        {
            _context = context;
        }

        //Generic Create
        public void Create<T>(T item) where T : class
        {
            _context.Set<T>().Add(item);
            _context.SaveChanges();
        }

        //Generic Delete
        public void Delete<T>(T item, bool tracked = false) where T : class
        {
            if (!tracked)
            {
                _context.Set<T>().Attach(item);
            }
            _context.Set<T>().Remove(item);
            _context.SaveChanges();
        }

        //Generic GetById
        public T GetById<T>(Guid id) where T : class
        {
            var type = typeof(T);
            var property = type.GetProperty("Id");
            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var constantValue = Expression.Constant(id);
            var equality = Expression.Equal(propertyAccess, constantValue);

            return _context.Set<T>().First<T>(Expression.Lambda<Func<T, bool>>(equality, parameter));
        }

        //Generic Retrieve
        public T Retrieve<T>(Expression<Func<T, bool>> exp) where T : class
        {
            return _context.Set<T>().FirstOrDefault(exp);
        }

        //Generic Retrieve All
        public IEnumerable<T> RetrieveAll<T>(Expression<Func<T, bool>> exp) where T : class
        {
            return _context.Set<T>().Where<T>(exp);
        }

        //Save all
        public void SaveAll()
        {
            _context.SaveChanges();
        }

        //Generic Update
        public void Update<T>(T item) where T : class
        {
            _context.Set<T>().Attach(item);
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        //Dispose 
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                _disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
        }

        //Generic GetAll
        public IEnumerable<T> GetAll<T>() where T : class
        {
            return _context.Set<T>().AsEnumerable<T>();
        }
    }
}
