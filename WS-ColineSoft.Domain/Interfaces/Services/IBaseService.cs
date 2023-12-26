using FluentValidation;
using FluentValidation.Results;
using System.Linq.Expressions;
using WS_ColineSoft.Domain.DTO.Defaults;

namespace WS_ColineSoft.Domain.Interfaces.Services
{
    public interface IBaseService<TModel, TEntity>
    {
        #region BASE BANCO DE DADOS
        TModel? Get(Guid id);
        IEnumerable<TModel> GetAll();
        IEnumerable<TModel> GetBy(Expression<Func<TEntity, bool>> expression); 

        TEntity? Insert(TModel obj);
        void Insert(IEnumerable<TModel> objs);

        TEntity? Update(TModel obj);
        void Update(IEnumerable<TModel> objs);

        TEntity? Delete(TModel obj);
        TEntity? Delete(Guid id);
        void Delete(IEnumerable<TModel> objs);

        BaseResponse SaveChange();
        #endregion
    }
}
