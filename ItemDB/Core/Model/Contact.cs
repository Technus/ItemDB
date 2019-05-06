using ItemDB.Core.Storage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ItemDB.Core.Model
{
    public class Contact : DependencyObject, IIdentifiable
    {
        public Contact(){
            ItemsManufactured = new ObservableCollection<ItemDefinition>();
            ItemSources = new ObservableCollection<Source>();

        }

        public int Id
        {
            get { return (int)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register(nameof(Id), typeof(int), typeof(Contact));

        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }
        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register(nameof(Name), typeof(string), typeof(Contact));

        public ObservableCollection<ItemDefinition> ItemsManufactured
        {
            get { return (ObservableCollection<ItemDefinition>)GetValue(ItemsManufacturedProperty); }
            set { SetValue(ItemsManufacturedProperty, value); }
        }
        public static readonly DependencyProperty ItemsManufacturedProperty =
            DependencyProperty.Register(nameof(ItemsManufactured), typeof(ObservableCollection<ItemDefinition>), typeof(Contact));

        public ObservableCollection<Source> ItemSources
        {
            get { return (ObservableCollection<Source>)GetValue(ItemSourcesProperty); }
            set { SetValue(ItemSourcesProperty, value); }
        }
        public static readonly DependencyProperty ItemSourcesProperty =
            DependencyProperty.Register(nameof(ItemSources), typeof(ObservableCollection<Source>), typeof(Contact));
    }
}
