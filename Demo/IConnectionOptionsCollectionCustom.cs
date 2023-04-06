using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public interface IConnectionOptionsCollectionCustom
    {
        /// <summary>
        ///  http://www.indexdata.dk/yaz/doc/zoom.tkl#zoom.connections
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string this[string key] { get; set; }
    }
}
