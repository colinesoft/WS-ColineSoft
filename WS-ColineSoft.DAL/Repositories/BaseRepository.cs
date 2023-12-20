using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WS_ColineSoft.DAL.Context;
using WS_ColineSoft.Domain.Entities;
using WS_ColineSoft.Domain.Interfaces.Repositories;

namespace WS_ColineSoft.DAL.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity
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

        public TEntity? Insert(TEntity obj)
        {
            return _dbSet.Add(obj).Entity ?? null;
        }

        public void Insert(IEnumerable<TEntity> objs)
        {
            _dbSet.AddRange(objs);
        }

        public TEntity Update(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            return _dbSet.Update(obj).Entity;
        }

        public void Update(IEnumerable<TEntity> objs)
        {
            _dbSet.UpdateRange(objs);
        }

        public TEntity? Delete(TEntity obj)
        {
            return !obj.Padrao ? _dbSet.Remove(obj).Entity : null;
        }

        public TEntity? Delete(Guid id)
        {
            var obj = Get(id);
            if(obj != null)
                return Delete(obj) ?? null;
            return null;
        }

        public void Delete(IEnumerable<TEntity> objs)
        {
            var ret = objs.Where(e => !e.Padrao);
            _dbSet.RemoveRange(ret);
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
