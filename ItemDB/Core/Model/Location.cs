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
    public class Location : DependencyObject, IIdentifiable
    {
        public Location()
        {
            ChildLocations = new ObservableCollection<Location>();
            ItemPlacements = new ObservableCollection<Placement>();
        }

        public int Id
        {
            get { return (int)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register(nameof(Id), typeof(int), typeof(Location));

        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }
        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register(nameof(Name), typeof(string), typeof(Location));

        public Location ParentLocation
        {
            get { return (Location)GetValue(ParentLocationProperty); }
            set { SetValue(ParentLocationProperty, value); }
        }
        public static readonly DependencyProperty ParentLocationProperty =
            DependencyProperty.Register(nameof(ParentLocation), typeof(Location), typeof(Location));
        public int? ParentLocationId { get; set; }

        public ObservableCollection<Location> ChildLocations
        {
            get { return (ObservableCollection<Location>)GetValue(ChildLocationsProperty); }
            set { SetValue(ChildLocationsProperty, value); }
        }
        public static readonly DependencyProperty ChildLocationsProperty =
            DependencyProperty.Register(nameof(ChildLocations), typeof(ObservableCollection<Location>), typeof(Location));

        public ObservableCollection<Placement> ItemPlacements
        {
            get { return (ObservableCollection<Placement>)GetValue(ItemPlacmentsProperty); }
            set { SetValue(ItemPlacmentsProperty, value); }
        }

        public static readonly DependencyProperty ItemPlacmentsProperty =
            DependencyProperty.Register(nameof(ItemPlacements), typeof(ObservableCollection<Placement>), typeof(Location));
    }
}
