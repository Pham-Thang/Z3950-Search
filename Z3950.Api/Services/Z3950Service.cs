using Z3950.Api.Models;
using Zoom.Net;
using Zoom.Net.YazSharp;
using System.Xml;
using System.Text;
using MARC;
using System.Text.Encodings.Web;
using Microsoft.Extensions.Logging.Abstractions;

namespace Z3950.Api.Services
{
    // https://software.indexdata.com/yaz/doc/
    public class Z3950Service : IZ3950Service
    {
        private readonly ConnectionConfig _connectionConfig;
        private readonly IMARCXmlReader _mxmlReader;
        private readonly IPrintService _printService;

        public Z3950Service(IConfiguration configuration, IMARCXmlReader mxmlReader, IPrintService printService)
        {
            _connectionConfig = configuration.GetSection("Connection").Get<ConnectionConfig>();
            _mxmlReader = mxmlReader;
            _printService = printService;
        }

        public List<string> Search(SearchParam searchParam)
        {
            IResultSet queryResults;
            var result = new List<string>();
            string query = BuildQuery(searchParam);
            using (var cnn = GetConnection())
            {
                CQLQuery q = new CQLQuery(query);
                //perform search

                queryResults = (ResultSet)cnn.Search(q);

                if (queryResults == null)
                {
                    return null;
                }

                for (uint i = 0; i < queryResults.Size; i++)
                {
                    string content = Encoding.UTF8.GetString(queryResults[i].Content);
                    if (!string.IsNullOrEmpty(content))
                    {
                        result.Add(content);
                    }
                }
            }

            return result;
        }

        public (List<string>, int) Paging(SearchParam searchParam, int skip, int limit)
        {
            IResultSet queryResults;
            var result = new List<string>();
            string query = BuildQuery(searchParam);
            using (var cnn = GetConnection())
            {
                CQLQuery q = new CQLQuery(query);
                //perform search

                queryResults = (ResultSet)cnn.Search(q);

                if (queryResults == null)
                {
                    return (null, 0);
                }

                var take = skip + limit;
                for (uint i = (uint)skip; i < queryResults.Size; i++)
                {
                    string content = Encoding.UTF8.GetString(queryResults[i].Content);
                    if (!string.IsNullOrEmpty(content))
                    {
                        result.Add(content);
                    }
                    if (i >= take)
                        break;
                }
            }

            return (result, (int)queryResults.Size);
        }

        public int SearchAndPrint(SearchParam searchParam)
        {
            IResultSet queryResults;
            var count = 0;
            string query = BuildQuery(searchParam);
            using (var cnn = GetConnection())
            {
                CQLQuery q = new CQLQuery(query);
                //perform search

                queryResults = (ResultSet)cnn.Search(q);

                if (queryResults == null)
                {
                    return count;
                }
                Encoding encoding = Encoding.UTF8; //Or any other Encoding
                var fields = _printService.GetFields(typeof(DocumentEntity));
                var rowFormat = new List<string>();

                var titles = new List<string>();
                for (var i = 0; i < fields.Count; ++i)
                {
                    rowFormat.Add("{" + $"{i}" + "}");
                    titles.Add(fields.ElementAt(i).Value.Name);
                }
                var rowFormatStr = string.Join(',', rowFormat);
                var titleLine = string.Format(rowFormatStr, titles.ToArray());

                using (FileStream fs = new FileStream(@"D:\large-data.csv", FileMode.OpenOrCreate))
                {
                    using (StreamWriter writer = new StreamWriter(fs, encoding))
                    {
                        writer.WriteLine(titleLine);
                        for (uint i = 0; i < queryResults.Size; i++)
                        {
                            string content = Encoding.UTF8.GetString(queryResults[i].Content);
                            if (!string.IsNullOrEmpty(content))
                            {
                                var model = _mxmlReader.ReadMARCXmlStrings<DocumentEntity>(new List<string> { content }).FirstOrDefault();

                                if (model == null)
                                {
                                    continue;
                                }

                                var values = new List<string>();
                                foreach (var field in fields)
                                {
                                    var prop = field.Key;
                                    var attr = field.Value.Name;
                                    var value = prop.GetValue(model) + "";
                                    values.Add(value.Replace(",", "-"));
                                }
                                //Suggestion made by KyleMit
                                var newLine = string.Format(rowFormatStr, values.ToArray());
                                writer.WriteLine(newLine);
                                ++count;
                            }
                        }
                    }
                }
            }

            return count;
        }

        private string BuildQuery(SearchParam searchParam)
        {
            var query = new StringBuilder();
            var props = typeof(SearchParam).GetProperties();

            foreach (var prop in props)
            {
                var value = prop.GetValue(searchParam);
                if (!string.IsNullOrEmpty(value?.ToString()))
                {
                    if (query.Length != 0)
                    {
                        query.Append(" OR ");
                    }
                    // TODO encode uri
                    query.Append($"{prop.Name}=\"{value}\"");
                }
            }

            // doc: https://software.indexdata.com/yaz/doc/yaz-client.html#sortspec
            query.Append(" SORTBY Title < lslb 0 ssub 10 mspn 5");

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
