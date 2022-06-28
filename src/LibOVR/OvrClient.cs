#region License
//   Copyright 2022 Kastellanos Nikolaos
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
#endregion

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace nkast.LibOVR
{
    public class OvrClient : IDisposable
    {
        static readonly WeakReference _current = new WeakReference(null);

        bool _isDisposed;

        public OvrClient()
        {

        }

        public static OvrDetectResult Detect(int timeoutMilliseconds)
        {
            return Native.ovr_Detect(timeoutMilliseconds);
        }

        public static int TryInitialize(out OvrClient ovrClient)
        {
            if (OvrClient._current.IsAlive)
                throw new InvalidOperationException("Allready initialized");

            var ovrResult = Native.ovr_Initialize(IntPtr.Zero);
            if (ovrResult >= 0)
            {
                ovrClient = new OvrClient();
                OvrClient._current.Target = ovrClient;
                return ovrResult;
            }
            ovrClient = null;
            return ovrResult;
        }

        public static unsafe int TryInitialize(OvrInitParams initParams, out OvrClient ovrClient)
        {
            if (OvrClient._current.IsAlive)
                throw new InvalidOperationException("Allready initialized");

            var ovrResult = Native.ovr_Initialize(new IntPtr(&initParams));
            if (ovrResult >= 0)
            {
                ovrClient = new OvrClient();
                OvrClient._current.Target = ovrClient;
                return ovrResult;
            }
            ovrClient = null;
            return ovrResult;
        }

        public int TryCreateSession(out OvrSession ovrSession)
        {
            if (_isDisposed)
                throw new ObjectDisposedException("OvrClient");


            IntPtr sessionPtr;
            OvrGraphicsLuid luid;
            var ovrResult = Native.ovr_Create(out sessionPtr, out luid);
            if (ovrResult >= 0)
            {
                ovrSession = new OvrSession(this, sessionPtr, luid);
                return ovrResult;
            }

            ovrSession = null;
            return ovrResult;
        }

        #region IDisposable
        ~OvrClient()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
           
            Native.ovr_Shutdown();
            _isDisposed = true;
            OvrClient._current.Target = null;
        }

        #endregion
    }

}

