﻿using Infra.Repositories;
using System.Linq.Expressions;

namespace Infra.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        TEntity? Insert(TEntity obj);

        public bool Update(TEntity obj);

        TEntity? Find(Expression<Func<TEntity, bool>> where);
        
        List<TEntity>? FindAll(Expression<Func<TEntity, bool>> where);

        TEntity? FindById(int id);
    }
}
