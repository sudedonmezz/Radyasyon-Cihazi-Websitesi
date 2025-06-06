using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories;
namespace Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T>
    where T: class,new()
    //temel sınıfların newlenmesini istemediğim için abstract classlar olmalı. baseclassı alan sınıflar newlenebilecek baseclass newlenemeyecek.
    {
        protected readonly RepositoryContext _context;
        protected RepositoryBase(RepositoryContext context)
        {
            _context=context;
        }
        public IQueryable<T> FindAll(bool trackChanges)
        {
            return trackChanges
            ? _context.Set<T>()
            : _context.Set<T>().AsNoTracking();
        }

       public  T? FindByCondition(Expression<Func<T,bool>> expression,bool trackChanges)
       {
            return trackChanges
            ? _context.Set<T>().Where(expression).SingleOrDefault()
            : _context.Set<T>().Where(expression).AsNoTracking().SingleOrDefault();
       }

       public void Create(T entity)
       {
        _context.Set<T>().Add(entity);
       }

       public void Remove(T entity)
       {
        _context.Set<T>().Remove(entity);
       }

      public void Update(T entity)
      {
        _context.Set<T>().Update(entity);
      }
    }
}