using FadamiCadastroInfra.Context;
using FadamiCadastroInfra.Entities;
using Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infra.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        protected readonly PrincipalContext _context;

        protected DbSet<TEntity> DbSet
        {
            get
            {
                return _context.Set<TEntity>();
            }
        }

        public Repository(PrincipalContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> where)//(Expression<Func<TEntity, bool>>)Faz com que para chamar o metodo tenha que usar uma Expressão Lambda
        {
            try
            {
                return DbSet.AsNoTracking().Where(where);
            }
            catch
            {
                throw;
            }
        }

        public TEntity? Find(Expression<Func<TEntity, bool>> where)//(Expression<Func<TEntity, bool>>)Faz com que para chamar o metodo tenha que usar uma Expressão Lambda
        {
            try
            {
                return DbSet.AsNoTracking().FirstOrDefault(where);//O AsNoTracking tbm serve para que possamos atualizar um dado
            }
            catch
            {
                throw;
            }
        }

        public bool Update(TEntity model)
        {
            try
            {
                var entry = _context.Entry(model);

                DbSet.Attach(model);

                entry.State = EntityState.Modified;

                return Save() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TEntity? FindById(int id)
        {
            try
            {
                return _context.Set<TEntity>().Find(id);
            }
            catch
            {
                throw;
            }
        }

        public List<TEntity>? FindAll(Expression<Func<TEntity, bool>> where) => DbSet.AsNoTracking().Where(where).ToList();

        public TEntity Create(TEntity entity)
        {

            DbSet.Add(entity);

            Save();

            return entity;
        }

        public int Save()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void Dispose()
        {
            try
            {
                if (_context != null)
                    _context.Dispose();

                GC.SuppressFinalize(this);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}