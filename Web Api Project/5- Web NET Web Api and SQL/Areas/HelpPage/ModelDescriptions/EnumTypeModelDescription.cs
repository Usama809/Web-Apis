using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace _5__Web_NET_Web_Api_and_SQL.Areas.HelpPage.ModelDescriptions
{
    public class EnumTypeModelDescription : ModelDescription
    {
        public EnumTypeModelDescription()
        {
            Values = new Collection<EnumValueDescription>();
        }

        public Collection<EnumValueDescription> Values { get; private set; }
    }
}