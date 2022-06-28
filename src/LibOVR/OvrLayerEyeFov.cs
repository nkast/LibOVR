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
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public unsafe struct OvrLayerEyeFov
    {
        public OvrLayerHeader Header;
        public OvrFixedArray2<IntPtr> ColorTexture; // OvrTextureSwapChain
        public OvrFixedArray2<OvrRecti> Viewport;
        public OvrFixedArray2<OvrFovPort> Fov;
        public OvrFixedArray2<OvrPosef> RenderPose;
        public double SensorSampleTime;


        public override string ToString()
        {
            return String.Format("{{Header: {0}, SensorSampleTime: {1} }}",
                   Header, SensorSampleTime);
        }
    }
}
