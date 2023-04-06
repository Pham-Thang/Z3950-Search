using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Z3950.Api.Attrs
{
    public class MARCControlFieldAttribute : Attribute
    {
        private string _tag;

        public string Tag => _tag;

        public MARCControlFieldAttribute(string tag)
        {
            _tag = tag;
        }
    }
}
