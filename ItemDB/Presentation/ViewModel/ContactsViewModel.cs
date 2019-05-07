using ItemDB.Core.Model;
using ItemDB.Core.Storage;
using ItemDB.Core.Storage.Repositories;
using ItemDB.Presentation.Commands;
using ItemDB.Presentation.View;
using System;
using System.Collections.ObjectModel;
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
            WorkUnit = WorkUnitProvider.ProvideWorkUnit();

            LoadAllContacts = new SimplerCommand
            {
                Action = () =>
                {
                    Clear();
                    LoadedContacts = new ObservableCollection<Contact>(WorkUnit.Contacts.GetAll());
                    SaveAllContacts.RaiseCanExecuteChanged();
                }
            };
            SaveAllContacts = new SimpleCommand
            {
                Action = ()=> {
                    WorkUnit.Save();
                    SaveAllContacts.RaiseCanExecuteChanged();
                },
                CanExecutePredicate = () => WorkUnit?.IsChanged() ?? false
            };
            EditEnding = new SimplerCommand
            {
                Action = SaveAllContacts.RaiseCanExecuteChanged
            };
        }

        public void Clear()
        {
            WorkUnit.Dispose();
            WorkUnit = WorkUnitProvider.ProvideWorkUnit();
            LoadedContacts?.Clear();
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
