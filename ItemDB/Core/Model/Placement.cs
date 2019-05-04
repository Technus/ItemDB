using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ItemDB.Core.Model
{
    public class Placement :DependencyObject
    {
        public Placement()
        {

        }

        public int Id
        {
            get { return (int)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register(nameof(Id), typeof(int), typeof(Placement));

        public Item PlacedItem
        {
            get { return (Item)GetValue(PlacedItemProperty); }
            set { SetValue(PlacedItemProperty, value); }
        }
        public static readonly DependencyProperty PlacedItemProperty =
            DependencyProperty.Register(nameof(PlacedItem), typeof(Item), typeof(Placement));

        public Location Location
        {
            get { return (Location)GetValue(LocationProperty); }
            set { SetValue(LocationProperty, value); }
        }
        public static readonly DependencyProperty LocationProperty =
            DependencyProperty.Register(nameof(Location), typeof(Location), typeof(Placement));

        public decimal Count
        {
            get { return (decimal)GetValue(CountProperty); }
            set { SetValue(CountProperty, value); }
        }
        public static readonly DependencyProperty CountProperty =
            DependencyProperty.Register(nameof(Count), typeof(decimal), typeof(Placement));

    }
}
