using Z3950.Api.Models;
using Zoom.Net;
using Zoom.Net.YazSharp;
using System.Xml;
using System.Text;
using MARC;

namespace Z3950.Api.Services
{
    public class Z3950Service : IZ3950Service
    {
        private readonly ConnectionConfig _connectionConfig;

        public Z3950Service(IConfiguration configuration) {
            _connectionConfig = configuration.GetSection("Connection").Get<ConnectionConfig>();
        }

        public List<object> Search(SearchParam searchParam)
        {
            IResultSet queryResults;
            var result = new List<object>();
            string query = BuildQuery(searchParam);
            using (var cnn = GetConnection())
            {
                CQLQuery q = new CQLQuery(query);
                //perform search
                queryResults = (ResultSet)cnn.Search(q);

                if (queryResults == null)
                {
                    return result;
                }

                for (uint i = 0; i < queryResults.Size; i++)
                {
                    string content = Encoding.UTF8.GetString(queryResults[i].Content);
                    FileMARCXml marcRecords = new FileMARCXml(content);
                    //if (string.IsNullOrWhiteSpace(content))
                    //{
                    //    continue;
                    //}
                    //This string is having the xml in string format. Convert it into the xml via XmlDocument
                    //XmlDocument doc = new XmlDocument();
                    //doc.LoadXml(content);
                    //_ = marcRecords[0];
                    //foreach (Record record in marcRecords)
                    //{
                    //    Field authorField = record["100"];
                    //    if (authorfield.IsDataField())
                    //    {
                    //        DataField authorDataField = (Datafield)authorField;
                    //        Subfield authorName = authorDataField['a'];
                    //        Console.WriteLine(authorName.Data);
                    //    }
                    //    else if (authorField.IsControlField())
                    //    {
                    //        //unreachable
                    //        Console.WriteLine("Something awful has happened. The author field should never be a control field!");
                    //    }
                    //}
                    result.Add(content);
                }
            }

            return result;
        }

        private string BuildQuery(SearchParam searchParam)
        {
            var query = new StringBuilder();
            var props = typeof(SearchParam).GetProperties();

            foreach (var prop in props)
            {
                if (query.Length != 0)
                {
                    query.Append(" OR ");
                }
                var value = prop.GetValue(searchParam);
                if (!string.IsNullOrEmpty(value?.ToString()))
                {
                    query.Append($"{prop.Name}=\"{value}\"");
                }
            }

            return query.ToString();
        }

        private Connection GetOpenConnection()
        {
            var cnn = this.GetConnection();
            cnn.Connect();
            return cnn;
        }

        private void CloseConnection(Connection cnn)
        {
            if (cnn != null)
            {
                return;
            }
            cnn.Dispose();
        }

        private Connection GetConnection()
        {
            //create a connection and provide the server details. Here I have used the LOC server
            Connection cnn = new Connection(_connectionConfig.Host, _connectionConfig.Port);
            //provide the name of the database on the server
            cnn.DatabaseName = _connectionConfig.DatabaseName;
            //define the syntax type that will be required. Here i am defining XML viz MarcXml
            cnn.Syntax = RecordSyntax.XML;

            return cnn;
        }
    }
}
