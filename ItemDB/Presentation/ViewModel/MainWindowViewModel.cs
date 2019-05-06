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
        public MainWindowViewModel()
        {

            ShowAllContacts = new SimplerCommand
            {
                Action = () =>
                {
                    new ContactsView(new ContactsViewModel(new WorkUnit())).Show();
                }
            };
        }
        public SimplerCommand ShowAllContacts { get; private set; }
    }
}
