using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Models
{
    public class MARCFieldAttribute : Attribute
    {
        private string _tag;
        private char _char;

        public string Tag => _tag;
        public char Char => _char;

        public MARCFieldAttribute(string tag, char @char)
        {
            _tag = tag;
            _char = @char;
        }
    }
}
