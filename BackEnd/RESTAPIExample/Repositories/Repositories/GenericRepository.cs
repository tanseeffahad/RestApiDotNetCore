using DatabaseManagement.Models;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, new()
    {
        protected readonly RESTAPIExample_DBContext _restAPIExample_DBContext;

        public GenericRepository(RESTAPIExample_DBContext restAPIExample_DBContext)
        {
            _restAPIExample_DBContext = restAPIExample_DBContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return _restAPIExample_DBContext.Set<TEntity>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                await _restAPIExample_DBContext.AddAsync(entity);
                await _restAPIExample_DBContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                _restAPIExample_DBContext.Update(entity);
                await _restAPIExample_DBContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _restAPIExample_DBContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> Deletesync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(Deletesync)} entity must not be null");
            }

            try
            {
                _restAPIExample_DBContext.Remove(entity);
                await _restAPIExample_DBContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be deleted: {ex.Message}");
            }
        }
    }

}
