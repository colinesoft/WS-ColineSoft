using Microsoft.EntityFrameworkCore;
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
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
