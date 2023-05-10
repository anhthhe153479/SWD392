using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.Repository.GenericRepository
{
    public interface IGennericRepository<TEntity> where TEntity : class
    {
        void Create(TEntity entity);

        void CreateRange(TEntity entity);

        void Update(TEntity entity);

        void UpdateRange(TEntity entity);

        void Delete(TEntity entity);

        void Delete(int id);

        IEnumerable<TEntity> GetAll();

        TEntity Find(int id);
    }
}
