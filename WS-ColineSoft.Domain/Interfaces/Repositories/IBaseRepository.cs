namespace WS_ColineSoft.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity>: IDisposable where TEntity : class
    {
        TEntity? Get(Guid id);
        IEnumerable<TEntity> GetAll();
    }
}
