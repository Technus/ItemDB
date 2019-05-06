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
        public IWorkUnit WorkUnit { get; private set; }
        public readonly IContactRepository _contacts;

        public ContactsViewModel()//Model First!
        {
            //STUB
        }
        public ContactsViewModel(IWorkUnit workUnit)//Model First!
        {
            LoadAllContacts = new SimplerCommand
            {
                Action = () =>
                {
                    LoadedContacts = new ObservableCollection<Contact>(_contacts.GetAll());
                    SaveAllContacts.RaiseCanExecuteChanged();
                }
            };
            SaveAllContacts = new SimplerCommand<IWorkUnit>
            {
                Action = ()=> {
                    workUnit.Save();
                    SaveAllContacts.RaiseCanExecuteChanged();
                },
                CanExecutePredicate = wu => {
                    return wu?.IsChanged() ?? false;
                }
            };
            WorkUnit = workUnit;
            _contacts = workUnit.Contacts;
        }

        public SimplerCommand LoadAllContacts { get; private set; }
        public SimplerCommand<IWorkUnit> SaveAllContacts { get; private set; }

        public void OnEdit()
        {
            SaveAllContacts.RaiseCanExecuteChanged();
        }

        public ObservableCollection<Contact> LoadedContacts
        {
            get { return (ObservableCollection<Contact>)GetValue(LoadedContactsProperty); }
            set { SetValue(LoadedContactsProperty, value); }
        }
        public static readonly DependencyProperty LoadedContactsProperty =
            DependencyProperty.Register(nameof(LoadedContacts), typeof(ObservableCollection<Contact>), typeof(ContactsViewModel));
    }
}
