using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;

namespace ItemDB.Core.Model
{
    public class Item :DependencyObject
    {
        public Item()
        {
            Manufacturers = new ObservableCollection<Contact>();
            Placements = new ObservableCollection<Placement>();
            Sources = new ObservableCollection<Source>();
        }

        public int Id
        {
            get { return (int)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register(nameof(Id), typeof(int), typeof(Item));

        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }
        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register(nameof(Name), typeof(string), typeof(Item));

        public ObservableCollection<Contact> Manufacturers
        {
            get { return (ObservableCollection<Contact>)GetValue(ManufacturersProperty); }
            set { SetValue(ManufacturersProperty, value); }
        }
        public static readonly DependencyProperty ManufacturersProperty =
            DependencyProperty.Register(nameof(Manufacturers), typeof(ObservableCollection<Contact>), typeof(Item));

        public ObservableCollection<Placement> Placements
        {
            get { return (ObservableCollection<Placement>)GetValue(PlacementsProperty); }
            set { SetValue(PlacementsProperty, value); }
        }
        public static readonly DependencyProperty PlacementsProperty =
            DependencyProperty.Register(nameof(Placements), typeof(ObservableCollection<Placement>), typeof(Item));

        public ObservableCollection<Source> Sources
        {
            get { return (ObservableCollection<Source>)GetValue(SourcesProperty); }
            set { SetValue(SourcesProperty, value); }
        }
        public static readonly DependencyProperty SourcesProperty =
            DependencyProperty.Register(nameof(Sources), typeof(ObservableCollection<Source>), typeof(Item));
    }
}
