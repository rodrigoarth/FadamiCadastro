using Infra.Interfaces;
using System.Linq.Expressions;

namespace Infra.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        public readonly IRepository<TEntity> _repository;

        public BaseService(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public bool Update(TEntity obj) => _repository.Update(obj);

        public TEntity? Find(Expression<Func<TEntity, bool>> where) => _repository.Find(where);

        public List<TEntity>? FindAll(Expression<Func<TEntity, bool>> where) => _repository.FindAll(where);

        public TEntity? FindById(int id) => _repository.FindById(id);

        public TEntity? Insert(TEntity obj) => _repository.Create(obj);
    }
}
