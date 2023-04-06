using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class YazCustom
    {
        public enum LogLevel
        {
            FATAL = 1,
            DEBUG = 2,
            WARN = 4,
            LOG = 8
        }

        private const string YAZ_LIBRARY = "yaz";

        public const int ZOOM_ERROR_NONE = 0;

        public const int ZOOM_ERROR_CONNECT = 10000;

        public const int ZOOM_ERROR_MEMORY = 10001;

        public const int ZOOM_ERROR_ENCODE = 10002;

        public const int ZOOM_ERROR_DECODE = 10003;

        public const int ZOOM_ERROR_CONNECTION_LOST = 10004;

        public const int ZOOM_ERROR_INIT = 10005;

        public const int ZOOM_ERROR_INTERNAL = 10006;

        public const int ZOOM_ERROR_TIMEOUT = 10007;

        public const int ZOOM_ERROR_UNSUPPORTED_PROTOCOL = 10008;

        public const int ZOOM_ERROR_UNSUPPORTED_QUERY = 10009;

        public const int ZOOM_ERROR_INVALID_QUERY = 10010;

        public const int ZOOM_EVENT_NONE = 0;

        public const int ZOOM_EVENT_CONNECT = 1;

        public const int ZOOM_EVENT_SEND_DATA = 2;

        public const int ZOOM_EVENT_RECV_DATA = 3;

        public const int ZOOM_EVENT_TIMEOUT = 4;

        public const int ZOOM_EVENT_UNKNOWN = 5;

        public const int ZOOM_EVENT_SEND_APDU = 6;

        public const int ZOOM_EVENT_RECV_APDU = 7;

        public const int ZOOM_EVENT_RECV_RECORD = 8;

        public const int ZOOM_EVENT_RECV_SEARCH = 9;

        [DllImport("yaz", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern IntPtr ZOOM_connection_new(string host, int portnum);

        [DllImport("yaz", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern IntPtr ZOOM_connection_create(IntPtr options);

        [DllImport("yaz", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern void ZOOM_connection_connect(IntPtr c, string host, int port);

        [DllImport("yaz", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern void ZOOM_connection_destroy(IntPtr c);

        [DllImport("yaz", CharSet = CharSet.Unicode, EntryPoint = "ZOOM_connection_option_get", SetLastError = true)]
        private static extern IntPtr ZOOM_connection_option_get_IntPtr(IntPtr c, string key);

        public static string ZOOM_connection_option_get(IntPtr c, string key)
        {
            return Marshal.PtrToStringAnsi(ZOOM_connection_option_get_IntPtr(c, key));
        }

        [DllImport("yaz", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern void ZOOM_connection_option_set(IntPtr c, string key, string value);

        [DllImport("yaz", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern void ZOOM_connection_option_setl(IntPtr c, string key, string value, int length);

        [DllImport("yaz", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int ZOOM_connection_error(IntPtr c, string cp, string additionalInfo);

        [DllImport("yaz", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int ZOOM_connection_error_x(IntPtr c, string cp, string additionalInfo, string diagSet);

        [DllImport("yaz", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int ZOOM_connection_errcode(IntPtr c);

        [DllImport("yaz", CharSet = CharSet.Unicode, EntryPoint = "ZOOM_connection_errmsg", SetLastError = true)]
        private static extern IntPtr ZOOM_connection_errmsg_IntPtr(IntPtr c);

        public static string ZOOM_connection_errmsg(IntPtr c)
        {
            return Marshal.PtrToStringAnsi(ZOOM_connection_errmsg_IntPtr(c));
        }

        [DllImport("yaz", CharSet = CharSet.Unicode, EntryPoint = "ZOOM_connection_addinfo", SetLastError = true)]
        private static extern IntPtr ZOOM_connection_addinfo_IntPtr(IntPtr c);

        public static string ZOOM_connection_addinfo(IntPtr c)
        {
            return Marshal.PtrToStringAnsi(ZOOM_connection_addinfo_IntPtr(c));
        }

        [DllImport("yaz", CharSet = CharSet.Unicode, EntryPoint = "ZOOM_diag_str", SetLastError = true)]
        private static extern IntPtr ZOOM_diag_str_IntPtr(int error);

        public static string ZOOM_diag_str(int error)
        {
            return Marshal.PtrToStringAnsi(ZOOM_diag_str_IntPtr(error));
        }

        [DllImport("yaz", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int ZOOM_connection_last_event(IntPtr c);

        [DllImport("yaz", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern IntPtr ZOOM_connection_search(IntPtr c, IntPtr q);

        [DllImport("yaz", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern IntPtr ZOOM_connection_search_pqf(IntPtr c, string q);

        [DllImport("yaz", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern IntPtr ZOOM_resultset_destroy(IntPtr r);

        [DllImport("yaz", CharSet = CharSet.Unicode, EntryPoint = "ZOOM_resultset_option_get", SetLastError = true)]
        private static extern IntPtr ZOOM_resultset_option_get_IntPtr(IntPtr r, string key);

        public static string ZOOM_resultset_option_get(IntPtr r, string key)
        {
            return Marshal.PtrToStringAnsi(ZOOM_resultset_option_get_IntPtr(r, key));
        }

        [DllImport("yaz", CharSet = CharSet.Unicode, EntryPoint = "ZOOM_resultset_option_set", SetLastError = true)]
        private static extern IntPtr ZOOM_resultset_option_set_IntPtr(IntPtr r, string key, string value);

        public static string ZOOM_resultset_option_set(IntPtr r, string key, string value)
        {
            return Marshal.PtrToStringAnsi(ZOOM_resultset_option_set_IntPtr(r, key, value));
        }

        [DllImport("yaz", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern uint ZOOM_resultset_size(IntPtr r);

        [DllImport("yaz", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern void ZOOM_resultset_records(IntPtr r, IntPtr recs, uint start, uint count);

        [DllImport("yaz", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern IntPtr ZOOM_resultset_record(IntPtr r, uint position);

        [DllImport("yaz", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern IntPtr ZOOM_resultset_record_immediate(IntPtr r, uint position);

        [DllImport("yaz", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern void ZOOM_resultset_cache_reset(IntPtr r);

        [DllImport("yaz", CharSet = CharSet.Unicode, EntryPoint = "ZOOM_record_get_string", SetLastError = true)]
        private static extern IntPtr ZOOM_record_get_string_IntPtr(IntPtr record, string type, ref int length);

        [DllImport("yaz", CharSet = CharSet.Unicode, EntryPoint = "ZOOM_record_get", SetLastError = true)]
        private static extern IntPtr ZOOM_record_get_IntPtr(IntPtr record, string type, ref int length);

        //public unsafe static byte[] ZOOM_record_get_bytes(IntPtr record, string type, ref int length)
        //{
        //    byte* ptr = (byte*)ZOOM_record_get_IntPtr(record, type, ref length).ToPointer();
        //    byte[] array = new byte[length];
        //    for (int i = 0; i < length; i++)
        //    {
        //        array[i] = *ptr;
        //        ptr++;
        //    }

        //    return array;
        //}

        public static string ZOOM_record_get_string(IntPtr record, string type, ref int length)
        {
            return Marshal.PtrToStringAnsi(ZOOM_record_get_IntPtr(record, type, ref length));
        }

        [DllImport("yaz", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern void ZOOM_record_destroy_IntPtr(IntPtr record);

        [DllImport("yaz", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern IntPtr ZOOM_record_clone(IntPtr sourceRecord);

        [DllImport("yaz", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern IntPtr ZOOM_query_create();

        [DllImport("yaz", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern void ZOOM_query_destroy(IntPtr s);

        [DllImport("yaz", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int ZOOM_query_cql(IntPtr s, string query);

        [DllImport("yaz", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int ZOOM_query_prefix(IntPtr s, string query);

        [DllImport("yaz", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int ZOOM_query_sortby(IntPtr s, string criteria);

        [DllImport("yaz", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern IntPtr ZOOM_connection_scan(IntPtr connection, string startterm);

        [DllImport("yaz", CharSet = CharSet.Unicode, EntryPoint = "ZOOM_scanset_term", SetLastError = true)]
        private static extern IntPtr ZOOM_scanset_term_IntPtr(IntPtr scan, uint position, out int occ, out int length);

        public static string ZOOM_scanset_term(IntPtr scan, uint position, out int occ, out int length)
        {
            return Marshal.PtrToStringAnsi(ZOOM_scanset_term_IntPtr(scan, position, out occ, out length));
        }

        [DllImport("yaz", CharSet = CharSet.Unicode, EntryPoint = "ZOOM_scanset_display_term", SetLastError = true)]
        private static extern IntPtr ZOOM_scanset_display_term_IntPtr(IntPtr scan, uint position, int occ, int length);

        public static string ZOOM_scanset_display_term(IntPtr scan, uint position, int occ, int length)
        {
            return Marshal.PtrToStringAnsi(ZOOM_scanset_display_term_IntPtr(scan, position, occ, length));
        }

        [DllImport("yaz", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern uint ZOOM_scanset_size(IntPtr scan);

        [DllImport("yaz", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern uint ZOOM_scanset_destroy(IntPtr scan);

        [DllImport("yaz", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern uint ZOOM_scanset_option_get(IntPtr scan, string key);

        [DllImport("yaz", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern uint ZOOM_scanset_option_set(IntPtr scan, string key, string value);

        [DllImport("yaz", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern IntPtr ZOOM_connection_package(IntPtr connection, IntPtr options);

        [DllImport("yaz", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern void ZOOM_package_destroy(IntPtr package);

        [DllImport("yaz", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern void ZOOM_package_send(IntPtr package, string type);

        [DllImport("yaz", CharSet = CharSet.Unicode, EntryPoint = "ZOOM_package_option_get", SetLastError = true)]
        private static extern IntPtr ZOOM_package_option_get_IntPtr(IntPtr package, string key);

        public static string ZOOM_package_option_get(IntPtr package, string key)
        {
            return Marshal.PtrToStringAnsi(ZOOM_package_option_get_IntPtr(package, key));
        }

        [DllImport("yaz", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern void ZOOM_package_option_set(IntPtr package, string key, string value);

        [DllImport("yaz", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern void ZOOM_resultset_sort(IntPtr resultSet, string sortType, string sortSpec);

        [DllImport("yaz", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern IntPtr ZOOM_options_create();

        [DllImport("yaz", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern IntPtr ZOOM_options_create_with_parent(IntPtr parentOptions);

        [DllImport("yaz", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern IntPtr ZOOM_options_create_with_parent2(IntPtr parentOptions1, IntPtr parentOptions2);

        [DllImport("yaz", CharSet = CharSet.Unicode, EntryPoint = "ZOOM_options_get", SetLastError = true)]
        private static extern IntPtr ZOOM_options_get_IntPtr(IntPtr options, string key);

        public static string ZOOM_options_get(IntPtr options, string key)
        {
            return Marshal.PtrToStringAnsi(ZOOM_options_get_IntPtr(options, key));
        }

        [DllImport("yaz", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern void ZOOM_options_set(IntPtr options, string key, string value);

        [DllImport("yaz", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern void ZOOM_options_setl(IntPtr options, string key, string value, int length);

        [DllImport("yaz", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern void ZOOM_options_destroy(IntPtr options);

        [DllImport("yaz", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int ZOOM_options_get_bool(IntPtr options, string name, int defa);

        [DllImport("yaz", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int ZOOM_options_get_int(IntPtr options, string name, int defa);

        [DllImport("yaz", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern void ZOOM_options_set_int(IntPtr options, string name, int defa);

        [DllImport("yaz", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int ZOOM_event(int no, IntPtr connection);

        [DllImport("yaz", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern void yaz_log_init(int level, string prefix, string name);

        [DllImport("yaz", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern void yaz_log(LogLevel level, string message);
    }

}
