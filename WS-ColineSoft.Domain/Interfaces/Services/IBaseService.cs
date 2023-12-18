using System.Linq.Expressions;

namespace WS_ColineSoft.Domain.Interfaces.Services
{
    public interface IBaseService<TModel, TEntity>
    {
        #region BASE BANCO DE DADOS
        TModel? Get(Guid id);
        IEnumerable<TModel> GetAll();
        IQueryable<TModel> GetBy(Expression<Func<TEntity, bool>> expression); 

        void Insert(TModel obj);
        void Insert(IEnumerable<TModel> objs);

        void Update(TModel obj);
        void Update(IEnumerable<TModel> objs);

        void Delete(TModel obj);
        void Delete(Guid id);
        void Delete(IEnumerable<TModel> objs);

        int SaveChange();
        #endregion
    }
}
