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
using System.Runtime.InteropServices;

namespace nkast.LibOVR
{
    internal static class Native
    {       
        [DllImport("nkast.LibOVR.Native.dll")]
        internal static extern OvrMatrix4f ovrMatrix4f_Projection(OvrFovPort fov, float znear, float zfar, OvrProjectionModifier projectionModFlags);

        [DllImport("nkast.LibOVR.Native.dll")]
        internal static extern OvrEyeRenderDesc ovr_GetRenderDesc(IntPtr ovrSession, OvrEyeType eye, OvrFovPort fov);

        [DllImport("nkast.LibOVR.Native.dll")]
        internal static extern OvrSizei ovr_GetFovTextureSize(IntPtr ovrSession, OvrEyeType eye, OvrFovPort fov, float pixelsPerDisplayPixel);

        [DllImport("nkast.LibOVR.Native.dll")]
        internal static extern int ovr_CreateTextureSwapChainDX(IntPtr session, IntPtr d3dDevice, ref OvrTextureSwapChainDesc desc, out IntPtr textureSwapChain);

        [DllImport("nkast.LibOVR.Native.dll")]
        internal static extern int ovr_GetTextureSwapChainLength(IntPtr ovrSession, IntPtr textureSwapChain, out int out_Length);

        [DllImport("nkast.LibOVR.Native.dll")]
        internal static unsafe extern int ovr_GetTextureSwapChainBufferDX(IntPtr ovrSession, IntPtr textureSwapChain, int index, Guid iid, out IntPtr out_Buffer);

        [DllImport("nkast.LibOVR.Native.dll")]
        internal static extern int ovr_GetTextureSwapChainCurrentIndex(IntPtr ovrSession, IntPtr textureSwapChain, out int out_Index);

        [DllImport("nkast.LibOVR.Native.dll")]
        internal static extern int ovr_CommitTextureSwapChain(IntPtr ovrSession, IntPtr textureSwapChain);

        [DllImport("nkast.LibOVR.Native.dll")]
        internal static unsafe extern int ovr_WaitToBeginFrame(IntPtr ovrSession, long frameIndex);

        [DllImport("nkast.LibOVR.Native.dll")]
        internal static unsafe extern int ovr_BeginFrame(IntPtr ovrSession, long frameIndex);

        [DllImport("nkast.LibOVR.Native.dll")]
        internal static unsafe extern int ovr_EndFrame(IntPtr ovrSession, long frameIndex, IntPtr viewScaleDesc, OvrLayerHeader** layerPtrList, uint layerCount);

        //[Obsolete("Use ovr_WaitToBeginFrame/ovr_BeginFrame/ovr_EndFrame")]
        [DllImport("nkast.LibOVR.Native.dll")]
        internal static unsafe extern int ovr_SubmitFrame(IntPtr ovrSession, long frameIndex, IntPtr viewScaleDesc, OvrLayerHeader** layerPtrList, uint layerCount);

        [DllImport("nkast.LibOVR.Native.dll")]
        internal static extern double ovr_GetPredictedDisplayTime(IntPtr ovrSession, long frameIndex);

        [DllImport("nkast.LibOVR.Native.dll")]
        internal static extern int ovr_SetTrackingOriginType(IntPtr ovrSession, OvrTrackingOrigin origin);

        [DllImport("nkast.LibOVR.Native.dll")]
        internal static extern OvrTrackingOrigin ovr_GetTrackingOriginType(IntPtr ovrSession);

        [DllImport("nkast.LibOVR.Native.dll")]
        internal static extern int ovr_RecenterTrackingOrigin(IntPtr ovrSession);

        [DllImport("nkast.LibOVR.Native.dll")]
        internal static extern OvrTrackingState ovr_GetTrackingState(IntPtr ovrSession, double absTime, OvrBool latencyMarker);

        [DllImport("nkast.LibOVR.Native.dll")]
        internal static unsafe extern void ovr_GetEyePoses2(IntPtr ovrSession, long frameIndex, OvrBool latencyMarker, OvrPosef* HmdToEyePoses, OvrPosef* outEyePoses, out double sensorSampleTime);

        [DllImport("nkast.LibOVR.Native.dll")]
        internal static extern OvrControllerType ovr_GetConnectedControllerTypes(IntPtr ovrSession);

        [DllImport("nkast.LibOVR.Native.dll")]
        internal static extern int ovr_GetInputState(IntPtr ovrSession, OvrControllerType controllerType, out OvrInputState inputState);

        [DllImport("nkast.LibOVR.Native.dll")]
        internal static extern int ovr_SetControllerVibration(IntPtr ovrSession, OvrControllerType controllerType, float frequency, float amplitude);

        [DllImport("nkast.LibOVR.Native.dll")]
        internal static extern OvrDetectResult ovr_Detect(int timeoutMilliseconds);

        [DllImport("nkast.LibOVR.Native.dll")]
        internal static extern int ovr_Initialize(IntPtr ovrInitParams);

        [DllImport("nkast.LibOVR.Native.dll")]
        internal static extern int ovr_Create(out IntPtr ovrSession, out OvrGraphicsLuid pLuid);

        [DllImport("nkast.LibOVR.Native.dll")]
        internal static extern int ovr_GetSessionStatus(IntPtr ovrSession, out OvrSessionStatus sessionStatus);

        [DllImport("nkast.LibOVR.Native.dll")]
        internal static extern OvrHmdDesc ovr_GetHmdDesc(IntPtr ovrSession);

        [DllImport("nkast.LibOVR.Native.dll")]
        internal static extern void ovr_DestroyTextureSwapChain(IntPtr session, IntPtr textureSwapChain);

        [DllImport("nkast.LibOVR.Native.dll")]
        internal static extern void ovr_Destroy(IntPtr ovrSession);

        [DllImport("nkast.LibOVR.Native.dll")]
        internal static extern void ovr_Shutdown();

    }
}
