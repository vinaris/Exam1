using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    public class EnumValueDescription
    {
        public EnumValueDescription(object enumValue, string displayString)
        {
            EnumValue = enumValue;
            DisplayString = displayString;
        }

        public object EnumValue { get; }
        public string DisplayString { get; }
    }
}
