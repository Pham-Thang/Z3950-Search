using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoom.Net;
using Zoom.Net.YazSharp;

namespace Demo
{
    public class ConnectionCustom : IConnectionCustom, IDisposable
    {
        private string _host;

        private int _port;

        private ConnectionOptionsCollectionCustom _options;

        protected IntPtr _zoomConnection;

        private bool _disposed = false;

        private bool _connected = false;

        public IConnectionOptionsCollectionCustom Options => _options;

        public RecordSyntax Syntax
        {
            get
            {
                return (RecordSyntax)Enum.Parse(typeof(RecordSyntax), Options["preferredRecordSyntax"]);
            }
            set
            {
                Options["preferredRecordSyntax"] = Enum.GetName(typeof(RecordSyntax), value);
            }
        }

        public string DatabaseName
        {
            get
            {
                return Options["databaseName"];
            }
            set
            {
                Options["databaseName"] = value;
            }
        }

        public string Username
        {
            get
            {
                return Options["user"];
            }
            set
            {
                Options["user"] = value;
            }
        }

        public string Password
        {
            get
            {
                return Options["password"];
            }
            set
            {
                Options["password"] = value;
            }
        }

        static ConnectionCustom()
        {
            Log.Init(1, "Zoom.Net.YazSharp", "YazCustom.log");
        }

        public ConnectionCustom(string host, int port)
        {
            _host = host;
            _port = port;
            _options = new ConnectionOptionsCollectionCustom();
            _zoomConnection = YazCustom.ZOOM_connection_create(_options._zoomOptions);
            int errorCode = YazCustom.ZOOM_connection_error(_zoomConnection, "", "");
            CheckErrorCodeAndThrow(errorCode);
            YazCustom.yaz_log(YazCustom.LogLevel.LOG, "Connection Created");
        }

        ~ConnectionCustom()
        {
            YazCustom.yaz_log(YazCustom.LogLevel.LOG, "Connection Destroyed");
            Dispose();
        }

        private void CheckErrorCodeAndThrow(int errorCode)
        {
            switch (errorCode)
            {
                case 0:
                    break;
                case 10000:
                    {
                        string text = $"Connection could not be made to {_host}:{_port}";
                        throw new ConnectionUnavailableException(text);
                    }
                case 10010:
                    {
                        string text = $"The query requested is not valid or not supported";
                        throw new InvalidQueryException(text);
                    }
                case 10005:
                    {
                        string text = $"Server {_host}:{_port} rejected our init request";
                        throw new InitRejectedException(text);
                    }
                case 10007:
                    {
                        string text = $"Server {_host}:{_port} timed out handling our request";
                        throw new ConnectionTimeoutException(text);
                    }
                case 10001:
                case 10002:
                case 10003:
                case 10004:
                case 10006:
                case 10008:
                case 10009:
                    {
                        string text = YazCustom.ZOOM_connection_errmsg(_zoomConnection);
                        throw new ZoomImplementationException("A fatal error occurred in Yaz: " + errorCode + " - " + text);
                    }
                default:
                    throw new Bib1Exception((Bib1Diagnostic)errorCode, Enum.GetName(typeof(Bib1Diagnostic), (Bib1Diagnostic)errorCode));
            }
        }

        public IResultSet Search(IQuery query)
        {
            EnsureConnected();
            IntPtr intPtr = YazCustom.ZOOM_query_create();
            ResultSet result = null;
            try
            {
                if (query is ICQLQuery)
                {
                    YazCustom.ZOOM_query_cql(intPtr, query.QueryString);
                }
                else
                {
                    if (!(query is IPrefixQuery))
                    {
                        throw new NotImplementedException();
                    }

                    YazCustom.ZOOM_query_prefix(intPtr, query.QueryString);
                }

                IntPtr intPtr2 = YazCustom.ZOOM_connection_search(_zoomConnection, intPtr);
                int num = YazCustom.ZOOM_connection_errcode(_zoomConnection);
                if (num != 0)
                {
                    YazCustom.ZOOM_resultset_destroy(intPtr2);
                }

                CheckErrorCodeAndThrow(num);
                result = new ResultSet(intPtr2, this);
            }
            finally
            {
                YazCustom.ZOOM_query_destroy(intPtr);
                intPtr = IntPtr.Zero;
            }

            return result;
        }

        public IScanSet Scan(IPrefixQuery query)
        {
            EnsureConnected();
            IntPtr intPtr = YazCustom.ZOOM_connection_scan(_zoomConnection, query.QueryString);
            int num = YazCustom.ZOOM_connection_errcode(_zoomConnection);
            if (num != 0)
            {
                YazCustom.ZOOM_scanset_destroy(intPtr);
            }

            CheckErrorCodeAndThrow(num);
            return new ScanSet(intPtr, this);
        }

        protected void EnsureConnected()
        {
            if (!_connected)
            {
                Connect();
            }
        }

        public void Connect()
        {
            YazCustom.ZOOM_connection_connect(_zoomConnection, _host, _port);
            int errorCode = YazCustom.ZOOM_connection_errcode(_zoomConnection);
            CheckErrorCodeAndThrow(errorCode);
            _connected = true;
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                YazCustom.ZOOM_connection_destroy(_zoomConnection);
                YazCustom.yaz_log(YazCustom.LogLevel.LOG, "Connection Disposed");
                _zoomConnection = IntPtr.Zero;
                _disposed = true;
            }
        }
    }
}
