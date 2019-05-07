using ItemDB.Core.Storage;
using ItemDB.Presentation.Commands;
using ItemDB.Presentation.View;
using ItemDB.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemDB.Presentation.ViewModel
{
    class MainWindowViewModel
    {
        private static readonly IWorkUnitProvider WorkUnitProvider=new WorkUnitProvider();

        public MainWindowViewModel()//View First!
        {

            ShowAllContacts = new SimplerCommand
            {
                Action = () =>
                {
                    new ContactsView(new ContactsViewModel(WorkUnitProvider)).Show();
                }
            };
        }
        public SimplerCommand ShowAllContacts { get; private set; }
    }
}
