using ItemDB.Core.Model;
using ItemDB.Core.Storage;
using ItemDB.Core.Storage.Repositories;
using ItemDB.Presentation.Commands;
using ItemDB.Presentation.View;
using System.Collections.ObjectModel;
using System.Windows;

namespace ItemDB.Presentation.ViewModel
{
    public class ContactsViewModel : DependencyObject
    {
        private readonly IWorkUnit _workUnit;
        private readonly IContactRepository _contacts;

        public ContactsViewModel()
        {
            //STUB
        }
        public ContactsViewModel(IWorkUnit workUnit)
        {
            LoadAllContacts = new SimplerCommand
            {
                Action = () =>
                {
                    LoadedContacts = new ObservableCollection<Contact>(_contacts.GetAll());
                }
            };
            _workUnit = workUnit;
            _contacts = workUnit.Contacts;
        }

        public SimplerCommand LoadAllContacts { get; private set; }

        public ObservableCollection<Contact> LoadedContacts
        {
            get { return (ObservableCollection<Contact>)GetValue(LoadedContactsProperty); }
            set { SetValue(LoadedContactsProperty, value); }
        }
        public static readonly DependencyProperty LoadedContactsProperty =
            DependencyProperty.Register(nameof(LoadedContacts), typeof(ObservableCollection<Contact>), typeof(ContactsViewModel));
    }
}
