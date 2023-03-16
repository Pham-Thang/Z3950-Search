using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Z3950.Api.Attrs
{
    public class FieldNameAttribute : Attribute
    {
        private string _name;

        public string Name => _name;

        public FieldNameAttribute(string name)
        {
            _name = name;
        }
    }
}
