using ItemDB.Core.Storage;
using ItemDB.Core.Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;

namespace ItemDB.Storage.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity: class,IIdentifiable
    {
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(DbSet<TEntity> dBSet)
        {
            _dbSet = dBSet;
        }

        public void AddOrUpdate(TEntity entity)
        {
            _dbSet.AddOrUpdate(e=>e.Id,entity);
        }

        public TEntity Get(int id)
        {
            return _dbSet.FirstOrDefault(i=>i.Id==id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
