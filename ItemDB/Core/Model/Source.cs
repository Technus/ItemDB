using ItemDB.Core.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ItemDB.Core.Model
{
    public class Source : DependencyObject, IIdentifiable
    {
        public Source()
        {

        }

        public int Id
        {
            get { return (int)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register(nameof(Id), typeof(int), typeof(Source));

        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }
        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register(nameof(Name), typeof(string), typeof(Source));

        public Contact Contact
        {
            get { return (Contact)GetValue(ContactProperty); }
            set { SetValue(ContactProperty, value); }
        }
        public static readonly DependencyProperty ContactProperty =
            DependencyProperty.Register(nameof(Contact), typeof(Contact), typeof(Source));
        public int ContactId { get; set; }

        public ItemDefinition SourcedItem
        {
            get { return (ItemDefinition)GetValue(SourcedItemProperty); }
            set { SetValue(SourcedItemProperty, value); }
        }
        public static readonly DependencyProperty SourcedItemProperty =
            DependencyProperty.Register(nameof(SourcedItem), typeof(ItemDefinition), typeof(Source));
        public int SourcedItemId { get; set; }
    }
}
