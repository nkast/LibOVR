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

namespace nkast.LibOVR
{
    public class OvrTextureSwapChain : IDisposable
    {
        private OvrSession _ovrSession;
        private IntPtr _nativePtr;

        public IntPtr NativePtr { get { return _nativePtr; } }


        internal OvrTextureSwapChain(OvrSession ovrSession, IntPtr nativePtr)
        {
            this._ovrSession = ovrSession;
            this._nativePtr = nativePtr;
        }

        public int GetTextureSwapChainLength(out int count)
        {
            var ovrResult = Native.ovr_GetTextureSwapChainLength(_ovrSession.NativePtr, _nativePtr, out count);
            if (ovrResult >= 0)
                return ovrResult;
            throw new OvrException(ovrResult);
        }

        public int GetTextureSwapChainBufferDX(int index, Guid iid, out IntPtr out_Buffer)
        {
            var ovrResult = Native.ovr_GetTextureSwapChainBufferDX(_ovrSession.NativePtr, _nativePtr, index, iid, out out_Buffer);
            if (ovrResult >= 0)
                return ovrResult;
            throw new OvrException(ovrResult);
        }

        public int GetCurrentIndex(out int index)
        {
            var ovrResult = Native.ovr_GetTextureSwapChainCurrentIndex(_ovrSession.NativePtr, _nativePtr, out index);
            if (ovrResult >= 0)
                return ovrResult;
            throw new OvrException(ovrResult);
        }

        public int Commit()
        {
            var ovrResult = Native.ovr_CommitTextureSwapChain(_ovrSession.NativePtr, _nativePtr);
            if (ovrResult >= 0)
                return ovrResult;
            throw new OvrException(ovrResult);
        }

        public override string ToString()
        {
            return String.Format("{{_nativePtr: 0x{0} }}",
                   _nativePtr.ToString("X"));
        }

        #region IDisposable
        ~OvrTextureSwapChain()
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

            Native.ovr_DestroyTextureSwapChain(_ovrSession.NativePtr, _nativePtr);
            _nativePtr = IntPtr.Zero;

            _ovrSession = null;
        }
        #endregion
    }
}
