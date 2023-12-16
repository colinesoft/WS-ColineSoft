using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WS_ColineSoft.DAL.Context;
using WS_ColineSoft.Domain.Interfaces.Repositories;

namespace WS_ColineSoft.DAL.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly ColineSoftContext _context;
        protected readonly DbSet<TEntity> _dbSet;
        public BaseRepository(ColineSoftContext context)
        {
            _context = context;            
            _dbSet = _context.Set<TEntity>();
        }
        public TEntity? Get(Guid id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public IQueryable<TEntity> GetBy(Expression<Func<TEntity, bool>> expression)
        {
            return _dbSet.Where(expression);
        }

        public void Insert(TEntity obj)
        {
            _dbSet.Add(obj);
        }

        public void Insert(IEnumerable<TEntity> objs)
        {
            _dbSet.AddRange(objs);
        }

        public void Update(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _dbSet.Update(obj);
        }

        public void Update(IEnumerable<TEntity> objs)
        {
            _dbSet.UpdateRange(objs);
        }

        public void Delete(TEntity obj)
        {
            _dbSet.Remove(obj);
        }

        public void Delete(Guid id)
        {
            var obj = Get(id);
            if(obj != null)
                Delete(obj);
        }

        public void Delete(IEnumerable<TEntity> objs)
        {
            _dbSet.RemoveRange(objs);
        }

        public int SaveChange()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
