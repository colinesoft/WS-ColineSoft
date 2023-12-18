using AutoMapper;
using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using WS_ColineSoft.DAL.Context;
using WS_ColineSoft.Domain.Interfaces.Repositories;
using WS_ColineSoft.Domain.Interfaces.Services;

namespace WS_ColineSoft.Services
{
    public class BaseService<TModel, TEntity> : IBaseService<TModel, TEntity>  where TEntity : class 
    {
        protected readonly IBaseRepository<TEntity> _repository;
        protected readonly IMapper _mapper;

        public BaseService(IBaseRepository<TEntity> repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public void Delete(TModel obj)
        {
            _repository.Delete(_mapper.Map<TEntity>(obj));
        }

        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }

        public void Delete(IEnumerable<TModel> objs)
        {
            _repository.Delete(_mapper.Map<IEnumerable<TEntity>>(objs));
        }

        public TModel? Get(Guid id)
        {
            return _mapper.Map<TModel>(_repository.Get(id));
        }

        public IEnumerable<TModel> GetAll()
        {
            return _mapper.Map<IEnumerable<TModel>>(_repository.GetAll());
        }

        public IQueryable<TModel> GetBy(Expression<Func<TEntity, bool>> expression)
        {
            return _mapper.Map<IQueryable<TModel>>(expression);
        }

        public void Insert(TModel obj)
        {
            _repository.Insert(_mapper.Map<TEntity>(obj));
        }

        public void Insert(IEnumerable<TModel> objs)
        {
            _repository.Insert(_mapper.Map<IEnumerable<TEntity>>(objs));
        }

        public void Update(TModel obj)
        {
            _repository.Update(_mapper.Map<TEntity>(obj));
        }

        public void Update(IEnumerable<TModel> objs)
        {
            _repository.Update(_mapper.Map<IEnumerable<TEntity>>(objs));
        }
        public int SaveChange()
        {
            return _repository.SaveChange();
        }
    }
}
