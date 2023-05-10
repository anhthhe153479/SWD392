using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SWD392.Models.Models;

namespace SWD392.Repository.GenericRepository
{
    public class GennericRepository<TEntity> : IGennericRepository<TEntity> where TEntity : class
    {
        protected readonly SWD_Summer2023Context context;
        protected DbSet<TEntity> entities;

        public GennericRepository(SWD_Summer2023Context context = null)
        {
            this.context = context ?? new SWD_Summer2023Context();
            entities = context.Set<TEntity>();
        }
        /// <summary>
        /// Create entity 
        /// </summary>
        /// <param name="entity">the entity user want to create</param>
        public void Create(TEntity entity)
        {
            entities.Add(entity);
        }

        public void CreateRange(TEntity entity)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Delete entity 
        /// </summary>
        /// <param name="entity">the entity user want to Delete</param>
        public void Delete(TEntity entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                entities.Attach(entity);
            }
            entities.Remove(entity);
            context.SaveChanges();
        }
        /// <summary>
        /// Delete entity  by id
        /// </summary>
        /// <param name="id">the id of entity user want to Delete</param>
        public void Delete(int id)
        {
            TEntity entityToDelete = entities.Find(id);
            Delete(entityToDelete);

        }
        /// <summary>
        /// Find entity by id
        /// </summary>
        /// <param name="id">the id of entity user want to find</param>
        /// <returns>TEntity</returns>
        public TEntity Find(int id)
        {
            try
            {
                return entities.Find(id);
            }
            catch (Exception)
            {

                return null;

            }

        }
        /// <summary>
        /// Get all entity user want
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> GetAll()
        {
            return entities;
        }

        /// <summary>
        /// Update entity 
        /// </summary>
        /// <param name="entity">the entity user want to update</param>
        public void Update(TEntity entity)
        {
            entities.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public void UpdateRange(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
