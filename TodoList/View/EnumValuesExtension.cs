using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Windows.Markup;
using Model;

namespace View
{
    public class EnumValuesExtension : MarkupExtension
    {
        public List<EnumValueDescription> EnumValues { get; set; } = new List<EnumValueDescription>();

        public static string GetDisplayName(Enum value)
        {
            DisplayAttribute[] displayAttributes = (DisplayAttribute[])(value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DisplayAttribute), false));
            return displayAttributes.Length > 0 ? displayAttributes[0].Name : value.ToString();
        }

        public EnumValuesExtension(Type type)
        {          
            var values  = type.GetEnumNames();
            foreach (var val in values)
            {
                Enum status = (Enum) Enum.Parse(type, val);
                var des = new EnumValueDescription(status, GetDisplayName(status));
                EnumValues.Add(des);
            }
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return EnumValues;
        }
    }
}