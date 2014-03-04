﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vtortola.WebSockets
{
    public sealed class WebSocketConnectionExtensionCollection : IReadOnlyCollection<IWebSocketConnectionExtension>
    {
        readonly List<IWebSocketConnectionExtension> _extensions;
        readonly WebSocketListener _listener;

        public WebSocketConnectionExtensionCollection(WebSocketListener webSocketListener)
        {
            _listener = webSocketListener;
            _extensions = new List<IWebSocketConnectionExtension>();
        }

        public void RegisterExtension(IWebSocketConnectionExtension extension)
        {
            if (_listener.IsStarted)
                throw new WebSocketException("Extensions cannot be added after the service is started");

            _extensions.Add(extension);
        }

        public int Count
        {
            get { return _extensions.Count; }
        }

        public IEnumerator<IWebSocketConnectionExtension> GetEnumerator()
        {
            return _extensions.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _extensions.GetEnumerator();
        }
    }

}
