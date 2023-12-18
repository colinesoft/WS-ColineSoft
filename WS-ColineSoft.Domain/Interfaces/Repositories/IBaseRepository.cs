using System.Linq.Expressions;

namespace WS_ColineSoft.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity>: IDisposable where TEntity : class
    {
        TEntity? Get(Guid id);
        IEnumerable<TEntity> GetAll();
        IQueryable<TEntity> GetBy(Expression<Func<TEntity, bool>> expression);

        TEntity? Insert(TEntity obj);
        void Insert(IEnumerable<TEntity> objs);

        TEntity Update(TEntity obj);
        void Update(IEnumerable<TEntity> objs);

        TEntity? Delete(TEntity obj);
        TEntity? Delete(Guid id);
        void Delete(IEnumerable<TEntity> objs);

        int SaveChange();
    }
}
