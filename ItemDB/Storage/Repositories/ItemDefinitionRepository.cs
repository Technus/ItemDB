using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItemDB.Core.Model;
using ItemDB.Core.Storage.Repositories;

namespace ItemDB.Storage.Repositories
{
    class ItemDefinitionRepository:Repository<ItemDefinition>,IItemRepository
    {
        public ItemDefinitionRepository(DbSet<ItemDefinition> itemDefinitions) : base(itemDefinitions) { }
    }
}
