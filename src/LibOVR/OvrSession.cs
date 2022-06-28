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
using System.Text;
using System.Threading.Tasks;

namespace nkast.LibOVR
{
    public class OvrSession : IDisposable
    {
        private OvrClient _ovrClient;
        private IntPtr _nativePtr;
        private OvrGraphicsLuid _graphicsLuid;

        public IntPtr NativePtr { get { return _nativePtr; } }

        public OvrGraphicsLuid GraphicsLuid { get { return _graphicsLuid; } }

        internal OvrSession(OvrClient ovrClient, IntPtr nativePtr, OvrGraphicsLuid graphicsLuid)
        {
            this._ovrClient = ovrClient;
            this._nativePtr = nativePtr;
            this._graphicsLuid = graphicsLuid;
        }

        public OvrHmdDesc GetHmdDesc()
        {
            return Native.ovr_GetHmdDesc(_nativePtr);
        }

        public OvrSizei GetFovTextureSize(OvrEyeType eye, OvrFovPort fov, float pixelsPerDisplayPixel)
        {
            return Native.ovr_GetFovTextureSize(_nativePtr, eye, fov, pixelsPerDisplayPixel);
        }

        public int CreateTextureSwapChainDX(IntPtr dxDevice, OvrTextureSwapChainDesc desc, out OvrTextureSwapChain textureSwapChain)
        {
            IntPtr textureSwapChainPtr;
            var ovrResult = Native.ovr_CreateTextureSwapChainDX(_nativePtr, dxDevice, ref desc, out textureSwapChainPtr);
            if (ovrResult >= 0)
            {
                textureSwapChain = new OvrTextureSwapChain(this, textureSwapChainPtr);
                return ovrResult;
            }
            throw new OvrException(ovrResult);
        }

        public OvrEyeRenderDesc GetRenderDesc(OvrEyeType eye, OvrFovPort fov)
        {
            var ovrResult = Native.ovr_GetRenderDesc(_nativePtr, eye, fov);
            return ovrResult;
        }

        public int GetSessionStatus(out OvrSessionStatus sessionStatus)
        {
            var ovrResult = Native.ovr_GetSessionStatus(_nativePtr, out sessionStatus);
            if (ovrResult >= 0)
                return ovrResult;
            throw new OvrException(ovrResult);
        }

        public double GetPredictedDisplayTime(long frameIndex)
        {
            return Native.ovr_GetPredictedDisplayTime(_nativePtr, frameIndex);
        }

        public OvrTrackingState GetTrackingState(double absTime, OvrBool latencyMarker)
        {
            return Native.ovr_GetTrackingState(_nativePtr, absTime, latencyMarker);
        }

        public unsafe void ovr_GetEyePoses(long frameIndex, OvrBool latencyMarker, OvrPosef[] hmdToEyePoses, OvrPosef[] outEyePoses, out double sensorSampleTime)
        {
            fixed (OvrPosef* phmdToEyePose = hmdToEyePoses)
            fixed (OvrPosef* poutEyePoses = outEyePoses)
            {
                Native.ovr_GetEyePoses2(_nativePtr, frameIndex, latencyMarker, phmdToEyePose, poutEyePoses, out sensorSampleTime);
            }
        }

        public unsafe void ovr_GetEyePoses(long frameIndex, OvrBool latencyMarker, OvrPosef* hmdToEyePoses, OvrPosef* outEyePoses, out double sensorSampleTime)
        {
            Native.ovr_GetEyePoses2(_nativePtr, frameIndex, latencyMarker, hmdToEyePoses, outEyePoses, out sensorSampleTime);
        }

        public OvrControllerType GetConnectedControllerTypes()
        {
            return Native.ovr_GetConnectedControllerTypes(_nativePtr);
        }

        public int GetInputState(OvrControllerType controllerType, out OvrInputState inputState)
        {
            var ovrResult = Native.ovr_GetInputState(_nativePtr, controllerType, out inputState);
            return ovrResult;
        }

        public int SetControllerVibration(OvrControllerType controllerType, float frequency, float amplitude)
        {
            var ovrResult = Native.ovr_SetControllerVibration(_nativePtr, controllerType, frequency, amplitude);
            return ovrResult;
        }

        public unsafe int WaitToBeginFrame(long frameIndex)
        {
            var ovrResult = Native.ovr_WaitToBeginFrame(_nativePtr, frameIndex);
            if (ovrResult >= 0)
                return ovrResult;
            throw new OvrException(ovrResult);
        }

        public unsafe int BeginFrame(long frameIndex)
        {
            var ovrResult = Native.ovr_BeginFrame(_nativePtr, frameIndex);
            if (ovrResult >= 0)
                return ovrResult;
            throw new OvrException(ovrResult);
        }

        public unsafe int EndFrame(long frameIndex, IntPtr viewScaleDesc, OvrLayerHeader** layerPtrList, uint layerCount)
        {
            var ovrResult = Native.ovr_EndFrame(_nativePtr, frameIndex, viewScaleDesc, layerPtrList, layerCount);
            if (ovrResult >= 0)
                return ovrResult;
            throw new OvrException(ovrResult);
        }

        [Obsolete("Use ovr_WaitToBeginFrame/ovr_BeginFrame/ovr_EndFrame")]
        public unsafe int SubmitFrame(long frameIndex, IntPtr viewScaleDesc, OvrLayerHeader** layerPtrList, uint layerCount)
        {
            var ovrResult = Native.ovr_SubmitFrame(_nativePtr, frameIndex, viewScaleDesc, layerPtrList, layerCount);
            if (ovrResult >= 0)
                return ovrResult;
            throw new OvrException(ovrResult);
        }

        public override string ToString()
        {
            return String.Format("{{_nativePtr: 0x{0}, GraphicsLuid: {1} }}",
                   _nativePtr.ToString("X"), _graphicsLuid.ToString());
        }

        #region IDisposable
        ~OvrSession()
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

            Native.ovr_Destroy(_nativePtr);
            _nativePtr = IntPtr.Zero;
            _graphicsLuid = default(OvrGraphicsLuid);

            _ovrClient = null;
        }
        #endregion
    }
}
