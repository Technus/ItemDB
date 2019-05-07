using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemDB.Core.Storage
{
    public interface IWorkUnitProvider
    {
        IWorkUnit ProvideWorkUnit();
    }
}
