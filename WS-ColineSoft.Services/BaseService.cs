using AutoMapper;
using System.Linq.Expressions;
using WS_ColineSoft.Domain.DTO.Defaults;
using WS_ColineSoft.Domain.Interfaces.Repositories;
using WS_ColineSoft.Domain.Interfaces.Services;

namespace WS_ColineSoft.Services
{
    public class BaseService<TModel, TEntity> : IBaseService<TModel, TEntity>
    {
        protected readonly IBaseRepository<TEntity> _repository;
        protected readonly IMapper _mapper;

        public BaseService(IBaseRepository<TEntity> repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public virtual TEntity? Delete(TModel obj)
        {
            return _repository.Delete(_mapper.Map<TEntity>(obj));
        }

        public virtual TEntity? Delete(Guid id)
        {
            return _repository.Delete(id);
        }

        public virtual void Delete(IEnumerable<TModel> objs)
        {
            _repository.Delete(_mapper.Map<IEnumerable<TEntity>>(objs));
        }

        public virtual TModel? Get(Guid id)
        {
            return _mapper.Map<TModel>(_repository.Get(id));
        }

        public virtual IEnumerable<TModel> GetAll()
        {
            var ret = _mapper.Map<IEnumerable<TModel>>(_repository.GetAll());
            return ret;
        }

        public virtual IEnumerable<TModel> GetBy(Expression<Func<TEntity, bool>> expression)
        {
            return _mapper.Map<IEnumerable<TModel>>(_repository.GetBy(expression));
        }

        public virtual TEntity? Insert(TModel obj)
        {
            return _repository.Insert(_mapper.Map<TEntity>(obj));           
        }

        public virtual void Insert(IEnumerable<TModel> objs)
        {
            _repository.Insert(_mapper.Map<IEnumerable<TEntity>>(objs));
        }

        public virtual TEntity? Update(TModel obj)
        {
            return _repository.Update(_mapper.Map<TEntity>(obj));
        }

        public virtual void Update(IEnumerable<TModel> objs)
        {
            _repository.Update(_mapper.Map<IEnumerable<TEntity>>(objs));
        }
        public virtual BaseResponse SaveChange()
        {
            try
            {
                _repository.SaveChange();
                return new BaseResponse
                {
                    Result = ResponseResultEnum.success
                };
            }
            catch (Exception e)
            {
                return new BaseResponse
                {
                    Messages = CheckMessage(e.InnerException?.Message ?? e.Message),
                    Result = ResponseResultEnum.fail                    
                };
            }
        }

        #region PRIVATES
        private string CheckMessage(string message)
        {
            if (message.Contains("PRIMARY KEY"))
                message = "PRIMARY KEY - Violação da restrição de Chave Primária. Não foi possível inserir";
            if (message.Contains("UNIQUE KEY"))
                message = "UNIQUE KEY - Violação da restrição de Unique Key. Não foi possível inserir";
            return message;
        }
        #endregion
    }
}
