using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_EF.EF;
using DAL_Common.Models;
using System.Linq.Expressions;

namespace DAL_EF.Repositories
{
    public class BaseRepository<T> where T : Entity
    {
        public TestDbContext _context { get; private set; }
        protected DbSet<T> _dbSet;

        public BaseRepository(TestDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual void Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            _dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            T itemToUpdate = _dbSet.Find(entity.Id);

            if (itemToUpdate == null)
            {
                throw new ArgumentException();
            }

            _context.Entry(itemToUpdate).CurrentValues.SetValues(entity);
        }

        public virtual void Delete(int id)
        {
            T itemToDel = _dbSet.Find(id);

            if (itemToDel != null)
            {
                _dbSet.Remove(itemToDel);
            }
        }

        protected IEnumerable<T> GetManyByPredicate(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query.Where(predicate).ToList();
        }

        protected T GetSingleByPredicate(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query.FirstOrDefault(predicate);
        }

    }
}
