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
    [StructLayout(LayoutKind.Explicit, Pack = 8)]
    public struct OvrTrackingState
    {
        [FieldOffset(0)]
        public OvrPoseStatef HeadPose;
        [FieldOffset(88)]
        public OvrStatusBits StatusFlags;
        [FieldOffset(96)]
        public OvrFixedArray2<OvrPoseStatef> HandPoses;
        [FieldOffset(272)]
        public OvrFixedArray2<OvrStatusBits> HandStatusFlags;
        [FieldOffset(280)]
        public OvrPosef CalibratedOrigin;

        public override string ToString()
        {
            return String.Format("{{HeadPose: {0}, StatusFlags: {1}, CalibratedOrigin: {2} }}",
                   HeadPose, StatusFlags,
                   CalibratedOrigin
                   );
        }
    }
}
