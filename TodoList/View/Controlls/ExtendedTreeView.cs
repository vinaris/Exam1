using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace View.Controlls
{
    public class ExtendedTreeView : TreeView
    {
        //public static readonly DependencyProperty SelectedItemsProperty = DependencyProperty.Register("SelectedItem", typeof(Object), typeof(ExtendedTreeView), new PropertyMetadata(null));
        //public new object SelectedItem
        //{
        //    get { return (object)GetValue(SelectedItemProperty); }
        //    set
        //    {
        //        SetValue(SelectedItemsProperty, value);
        //        NotifyPropertyChanged("SelectedItem");
        //    }
        //}

        //public ExtendedTreeView()
        //{
        //    SelectedItemChanged += MyTreeView_SelectedItemChanged;
        //}

        //private void MyTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<Object> e)
        //{
        //    SelectedItem = base.SelectedItem;
        //}

        //public event PropertyChangedEventHandler PropertyChanged;
        //private void NotifyPropertyChanged(String aPropertyName)
        //{
        //    if (PropertyChanged != null)
        //        PropertyChanged(this, new PropertyChangedEventArgs(aPropertyName));
        //}



        public ExtendedTreeView() : base()
        {
            this.SelectedItemChanged += ___ICH;
        }

        void ___ICH(object sender, RoutedPropertyChangedEventArgs<object> e)
        {

            if (SelectedItem != null)
            {
                SetValue(SelectedItem_Property, SelectedItem);
            }

        }

        public object SelectedItem_
        {
            get { return (object)GetValue(SelectedItem_Property); }
            set { SetValue(SelectedItem_Property, value); }
        }
        public static readonly DependencyProperty SelectedItem_Property = DependencyProperty.Register("SelectedItem_", typeof(object), typeof(ExtendedTreeView), new UIPropertyMetadata(null));
    }
}
