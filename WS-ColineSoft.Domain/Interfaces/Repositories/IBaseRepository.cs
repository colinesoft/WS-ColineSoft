using System.Linq.Expressions;

namespace WS_ColineSoft.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity>: IDisposable where TEntity : class
    {
        TEntity? Get(Guid id);
        IEnumerable<TEntity> GetAll();
        IQueryable<TEntity> GetBy(Expression<Func<TEntity, bool>> expression);

        void Insert(TEntity obj);
        void Insert(IEnumerable<TEntity> objs);

        void Update(TEntity obj);
        void Update(IEnumerable<TEntity> objs);

        void Delete(TEntity obj);
        void Delete(Guid id);
        void Delete(IEnumerable<TEntity> objs);

        int SaveChange();
    }
}
