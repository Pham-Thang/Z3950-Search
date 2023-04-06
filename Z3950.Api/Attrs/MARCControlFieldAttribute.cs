using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Z3950.Api.Attrs
{
    public class MARCDataFieldAttribute : Attribute
    {
        private static Regex SyntaxRegex = new Regex(@"[0-9]{3} ( |#|[0-9]){2}\$([a-z]|[0-9])");
        private string _tag;
        private char _indicator1;
        private char _indicator2;
        private char _code;

        public string Tag => _tag;
        public char Code => _code;

        public MARCDataFieldAttribute(string tag, char code)
        {
            _tag = tag;
            _code = code;
        }
        public MARCDataFieldAttribute(string field)
        {
            if (!ValidateField(field))
            {
                throw new ArgumentException($"{nameof(field)} {field} invalid syntax");
            }
            var parts = field.Split(' ');
            _tag = parts[0];
            var chars = parts[1].ToCharArray();
            _indicator1 = chars[0];
            _indicator2 = chars[1];
            _code = chars[3];
        }

        private bool ValidateField(string field)
        {
            return SyntaxRegex.IsMatch(field);
        }
    }
}
