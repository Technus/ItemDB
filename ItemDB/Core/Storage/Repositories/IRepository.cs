﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemDB.Core.Storage.Repositories
{
    public interface IRepository<TEntity> where TEntity : class, IIdentifiable
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        void AddOrUpdate(TEntity entity);
        void Remove(TEntity entity);
    }
}
