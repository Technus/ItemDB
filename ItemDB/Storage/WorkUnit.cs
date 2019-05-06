using ItemDB.Core.Storage;
using ItemDB.Core.Storage.Repositories;
using ItemDB.Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemDB.Storage
{
    class WorkUnit : IWorkUnit
    {
        private readonly ItemDbStorage _context;

        public WorkUnit()
        {
            _context = new ItemDbStorage();
        }

        public IContactRepository Contacts => new ContactRepository(_context.Contacts);

        public IItemDefinitionRepository Items => new ItemDefinitionRepository(_context.Items);

        public ILocationRepository Locations => new LocationRepository(_context.Locations);

        public IPlacementRepository Placements => new PlacementRepository(_context.Placements);

        public ISourceRepository Sources => new SourcesRepository(_context.Sources);

        public void Dispose()
        {
            _context.Dispose();
        }

        public bool IsChanged()
        {
            return _context.ChangeTracker.HasChanges();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
