using System.Linq.Expressions;

namespace WS_ColineSoft.Domain.Interfaces.Services
{
    public interface IBaseService<TModel>
    {
        TModel? Get(Guid id);
        IEnumerable<TModel> GetAll();
        IQueryable<TModel> GetBy(Expression<Func<TModel, bool>> expression);
    }
}
