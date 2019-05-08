using ItemDB.Core.Model;
using ItemDB.Core.Storage;
using ItemDB.Core.Storage.Repositories;
using ItemDB.Presentation.Commands;
using ItemDB.Presentation.View;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ItemDB.Presentation.ViewModel
{
    public class ContactsViewModel : DependencyObject
    {
        public IWorkUnitProvider WorkUnitProvider { get; private set; }
        public IWorkUnit WorkUnit { get; private set; }

        public ContactsViewModel()//Model First!
        {
            //STUB
        }

        public ContactsViewModel(IWorkUnitProvider workUnitProvider)//Model First!
        {
            WorkUnitProvider = workUnitProvider;
            LoadedContacts = new ObservableCollection<Contact>();
            LoadedContacts.CollectionChanged += LoadedContacts_CollectionChanged;

            LoadAllContacts = new SimplerCommand
            {
                Action = () =>
                {
                    PrepareForWork();
                    WorkUnit.Contacts.GetAll().ToList().ForEach(contact => LoadedContacts.Add(contact));
                    NotifyChangesMade();
                }
            };
            SaveAllContacts = new SimpleCommand
            {
                Action = ()=> {
                    WorkUnit.Save();
                    LoadedContacts.ToList().ForEach(c => WorkUnit.Reload(c));
                    NotifyChangesMade();
                },
                CanExecuteFunc = () => WorkUnit?.IsChanged() ?? false
            };
            EditEnding = new SimplerCommand
            {
                Action = SaveAllContacts.RaiseCanExecuteChanged
            };
        }

        private void LoadedContacts_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                foreach (Contact c in e.NewItems)
                {
                    WorkUnit.Contacts.AddOrUpdate(c);
                }
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                foreach(Contact c in e.OldItems)
                {
                    WorkUnit.Contacts.Remove(c);
                }
            }
            NotifyChangesMade();
        }

        public void PrepareForWork()
        {
            WorkUnit = WorkUnitProvider.ProvideWorkUnit();
            LoadedContacts.Clear();
        }

        public void NotifyChangesMade()
        {
            SaveAllContacts.RaiseCanExecuteChanged();
        }

        public SimplerCommand LoadAllContacts { get; private set; }

        public SimpleCommand SaveAllContacts { get; private set; }

        public SimplerCommand EditEnding { get; private set; }

        public ObservableCollection<Contact> LoadedContacts
        {
            get { return (ObservableCollection<Contact>)GetValue(LoadedContactsProperty); }
            set { SetValue(LoadedContactsProperty, value); }
        }
        public static readonly DependencyProperty LoadedContactsProperty =
            DependencyProperty.Register(nameof(LoadedContacts), typeof(ObservableCollection<Contact>), typeof(ContactsViewModel));
    }
}
