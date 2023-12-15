using WS_ColineSoft.Domain.Interfaces.Repositories;
using WS_ColineSoft.Domain.Interfaces.Services;

namespace WS_ColineSoft.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        protected readonly IBaseRepository<TEntity> repository;
        public BaseService(IBaseRepository<TEntity> repository)
        {
            this.repository = repository;
        }
        public TEntity? Get(Guid id)
        {
            return repository.Get(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return repository.GetAll();
        }
    }
}
