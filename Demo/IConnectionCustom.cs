using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoom.Net;

namespace Demo
{
    public interface IConnectionCustom : IDisposable
    {
        //
        // Summary:
        //     Setting and getting the databaseName option
        string DatabaseName { get; set; }

        //
        // Summary:
        //     Setting and getting the username option
        string Username { get; set; }

        //
        // Summary:
        //     Setting and getting the password option
        string Password { get; set; }

        //
        // Summary:
        //     Setting and getting recordSyntax option
        RecordSyntax Syntax { get; set; }

        //
        // Summary:
        //     Other standard options described at http://zoom.z3950.org/api/zoom-1.4.html#3.8
        //     are implemented using the Zoom::Net::IConnectionOptions interface.
        //
        // Remarks:
        //     See the following info for all possible values: http://www.indexdata.dk/yaz/doc/zoom.tkl#zoom.connections
        IConnectionOptionsCollectionCustom Options { get; }

        //
        // Summary:
        //     Submitting a Query to a Connection. The resultset is held on the server.
        //
        // Parameters:
        //   query:
        //     The query is either a PQF or a CQL query.
        IResultSet Search(IQuery query);

        //
        // Summary:
        //     Submitting a Scan to a Connection. The scanset is held on the server.
        //
        // Parameters:
        //   query:
        //     The scan query is a subset of PQF, namely the Attributes+Term part.
        IScanSet Scan(IPrefixQuery query);
    }
}
