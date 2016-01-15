using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace View.Converters
{
    class GroupByGroupConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            CollectionViewGroup group = value as CollectionViewGroup;
            if (group == null)
                return Binding.DoNothing;
            CollectionViewSource sortByGroup = new CollectionViewSource();
            sortByGroup.Source = group.Items;
            sortByGroup.GroupDescriptions.Add(new PropertyGroupDescription("Name"));
            return sortByGroup.View.Groups;


            //ICollectionView collection = value as ICollectionView;
            //if (collection == null)
            //{
            //    return Binding.DoNothing;
            //}
            //CollectionViewSource sortByGroup = new CollectionViewSource();
            //sortByGroup.GroupDescriptions.Add(new PropertyGroupDescription("Group"));
            //return sortByGroup.View.Groups;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
