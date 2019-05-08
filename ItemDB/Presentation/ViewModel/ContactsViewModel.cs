using ItemDB.Core.Model;
using ItemDB.Core.Storage;
using ItemDB.Core.Storage.Repositories;
using ItemDB.Commands;
using ItemDB.Presentation.View;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Collections;

namespace ItemDB.Presentation.ViewModel
{
    public class ContactsViewModel : DependencyObject
    {
        public IWorkUnitProvider WorkUnitProvider { get; private set; }
        public IWorkUnit WorkUnit { get; private set; }
        
        public ContactsViewModel()
        {
            //STUB
        }

        public ContactsViewModel(IWorkUnitProvider workUnitProvider)
        {
            WorkUnitProvider = workUnitProvider;

            LoadAllContacts = new SimplerCommand
            {
                Action = () =>
                {
                    WorkUnit = WorkUnitProvider.ProvideWorkUnit();
                    LoadedContacts = new ObservableCollection<Contact>(WorkUnit.Contacts.GetAll());
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
            OnEditEnding = new SimplerCommand
            {
                Action = SaveAllContacts.RaiseCanExecuteChanged
            };
            DeleteSelected = new SimpleCommand
            {
                Action = () =>
                {
                    SelectedContacts.ToList().ForEach(c => LoadedContacts.Remove(c));
                },
                CanExecuteFunc = ()=>{
                    return SelectedContacts?.Count > 0;
                }
            };
            OnSelectionChange = new SimplerCommand<IList>
            {
                Action = o =>
                {
                    SelectedContacts = new ObservableCollection<Contact>(o.OfType<Contact>());
                }
            };
        }

        public void NotifyLoaded()
        {
            NotifyChangesMade();
            NotifySelectionChanged();
        }

        public void NotifySelectionChanged()
        {
            DeleteSelected.RaiseCanExecuteChanged();
        }

        public void NotifyChangesMade()
        {
            SaveAllContacts.RaiseCanExecuteChanged();
        }

        public SimplerCommand<IList> OnSelectionChange { get;private set; }

        public SimplerCommand LoadAllContacts { get; private set; }

        public SimpleCommand SaveAllContacts { get; private set; }

        public SimplerCommand OnEditEnding { get; private set; }

        public SimpleCommand DeleteSelected { get; private set; }

        public ObservableCollection<Contact> LoadedContacts
        {
            get { return (ObservableCollection<Contact>)GetValue(LoadedContactsProperty); }
            set
            {
                if (LoadedContacts != null) LoadedContacts.CollectionChanged -= LoadedContacts_CollectionChanged;
                if (value != null) value.CollectionChanged += LoadedContacts_CollectionChanged;
                SetValue(LoadedContactsProperty, value);
                NotifyChangesMade();
            }
        }
        public static readonly DependencyProperty LoadedContactsProperty =
            DependencyProperty.Register(nameof(LoadedContacts), typeof(ObservableCollection<Contact>), typeof(ContactsViewModel));

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
                foreach (Contact c in e.OldItems)
                {
                    WorkUnit.Contacts.Remove(c);
                }
            }
            NotifyChangesMade();
        }

        public ObservableCollection<Contact> SelectedContacts
        {
            get { return (ObservableCollection<Contact>)GetValue(SelectedContactsProperty); }
            set
            {
                if (SelectedContacts != null) SelectedContacts.CollectionChanged -= SelectedContacts_CollectionChanged;
                if (value != null) value.CollectionChanged += SelectedContacts_CollectionChanged;
                SetValue(SelectedContactsProperty, value);
                NotifySelectionChanged();
            }
        }
        public static readonly DependencyProperty SelectedContactsProperty =
            DependencyProperty.Register(nameof(SelectedContacts), typeof(ObservableCollection<Contact>), typeof(ContactsViewModel));

        private void SelectedContacts_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            NotifySelectionChanged();
        }
    }
}
