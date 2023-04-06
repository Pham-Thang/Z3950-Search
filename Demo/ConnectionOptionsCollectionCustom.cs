using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoom.Net;

namespace Demo
{
    public class ConnectionOptionsCollectionCustom : IConnectionOptionsCollectionCustom, IDisposable
    {
        public IntPtr _zoomOptions;

        public string this[string key]
        {
            get
            {
                return YazCustom.ZOOM_options_get(_zoomOptions, key);
            }
            set
            {
                YazCustom.ZOOM_options_set(_zoomOptions, key, value);
            }
        }

        internal ConnectionOptionsCollectionCustom()
        {
            _zoomOptions = YazCustom.ZOOM_options_create();
        }

        public void Dispose()
        {
            YazCustom.ZOOM_options_destroy(_zoomOptions);
            _zoomOptions = IntPtr.Zero;
        }

        internal IntPtr CreateConnection()
        {
            return YazCustom.ZOOM_connection_create(_zoomOptions);
        }
    }
}
