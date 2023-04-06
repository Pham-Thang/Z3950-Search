using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoom.Net.YazSharp;
using Zoom.Net;

namespace Demo
{
    public class ResultSetCustom : IResultSetCustom, IDisposable, IList, ICollection, IEnumerable
    {
        private ConnectionCustom _connection;

        private IntPtr _resultSet;

        private uint _size;

        private Record[] _records;

        private bool _disposed = false;

        IResultSetOptionsCollection IResultSet.Options => new ResultSetOptionsCollection(_resultSet);

        IRecord IResultSet.this[uint index]
        {
            get
            {
                if (_records[index] == null)
                {
                    IntPtr record = Yaz.ZOOM_resultset_record(_resultSet, index);
                    _records[index] = new Record(record, this);
                }

                return _records[index];
            }
        }

        IRecord IResultSet.this[int index] => ((IResultSet)this)[(uint)index];

        uint IResultSet.Size => _size;

        public bool IsReadOnly => true;

        object IList.this[int index]
        {
            get
            {
                return ((IResultSet)this)[(uint)index];
            }
            set
            {
                throw new NotImplementedException("Underlying ResultSet is readonly");
            }
        }

        public bool IsFixedSize => true;

        public bool IsSynchronized => false;

        public int Count => (int)((IResultSet)this).Size;

        public object SyncRoot
        {
            get
            {
                throw new NotImplementedException("Underlying ResultSet is not synchronised");
            }
        }

        internal ResultSet(IntPtr resultSet, Connection connection)
        {
            _connection = connection;
            _resultSet = resultSet;
            _size = Yaz.ZOOM_resultset_size(_resultSet);
            _records = new Record[_size];
            Yaz.yaz_log(Yaz.LogLevel.LOG, "ResultSet Created");
        }

        ~ResultSet()
        {
            Yaz.yaz_log(Yaz.LogLevel.LOG, "ResultSet Destroyed");
            ((IDisposable)this).Dispose();
        }

        void IDisposable.Dispose()
        {
            if (!_disposed)
            {
                Record[] records = _records;
                for (int i = 0; i < records.Length; i++)
                {
                    records[i]?.Dispose();
                }

                Yaz.ZOOM_resultset_destroy(_resultSet);
                Yaz.yaz_log(Yaz.LogLevel.LOG, "ResultSet Disposed");
                _connection = null;
                _resultSet = IntPtr.Zero;
                _disposed = true;
            }
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException("Underlying ResultSet is readonly");
        }

        public void Insert(int index, object value)
        {
            throw new NotImplementedException("Underlying ResultSet is readonly");
        }

        public void Remove(object value)
        {
            throw new NotImplementedException("Underlying ResultSet is readonly");
        }

        public bool Contains(object value)
        {
            throw new NotImplementedException("Underlying ResultSet is not searchable");
        }

        public void Clear()
        {
            throw new NotImplementedException("Underlying ResultSet is readonly");
        }

        public int IndexOf(object value)
        {
            throw new NotImplementedException("Underlying ResultSet is not searchable");
        }

        public int Add(object value)
        {
            throw new NotImplementedException("Underlying ResultSet is readonly");
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException("Underlying ResultSet is not copyable");
        }

        public IEnumerator GetEnumerator()
        {
            return new ResultSetEnumerator(this);
        }
    }
}
