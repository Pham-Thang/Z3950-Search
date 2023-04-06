using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoom.Net;

namespace Demo
{
    public interface IResultSetCustom : IDisposable, IList, ICollection, IEnumerable
    {
        //
        // Summary:
        //     Getting the IResultSetOptionsCollection options
        IResultSetOptionsCollection Options { get; }

        //
        // Summary:
        //     Fetching a record
        IRecord this[uint index] { get; }

        //
        // Summary:
        //     Fetching a record
        new IRecord this[int index] { get; }

        //
        // Summary:
        //     Get size of Result Set in number of Records
        uint Size { get; }
    }
}
