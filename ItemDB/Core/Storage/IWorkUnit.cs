using ItemDB.Core.Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemDB.Core.Storage
{
    public interface IWorkUnit:IDisposable
    {
        IContactRepository Contacts { get; }
        IItemDefinitionRepository Items { get; }
        ILocationRepository Locations { get; }
        IPlacementRepository Placements { get; }
        ISourceRepository Sources { get; }

        void Save();
        bool IsChanged();
        void Reload(IIdentifiable entity);
    }
}
