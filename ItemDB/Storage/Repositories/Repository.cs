using ItemDB.Core.Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemDB.Storage.Repositories
{
    class Repository<TEntity> : IRepository<TEntity> where TEntity:class
    {
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(DbSet<TEntity> dBSet)
        {
            _dbSet = dBSet;
        }

        public TEntity get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> getAll()
        {
            throw new NotImplementedException();
        }
    }
}
