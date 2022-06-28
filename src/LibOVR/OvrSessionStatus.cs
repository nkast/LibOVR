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
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public unsafe struct OvrSessionStatus
    {
        OvrBool IsVisible;

        OvrBool HmdPresent;

        OvrBool HmdMounted;

        OvrBool DisplayLost;

        OvrBool ShouldQuit;

        OvrBool ShouldRecenter;

        OvrBool HasInputFocus;

        OvrBool OverlayPresent;

        OvrBool DepthRequested;

        public override string ToString()
        {
            return String.Format("{{IsVisible: {0}, HmdPresent: {1}, HmdMounted: {2}, DisplayLost: {3}, ShouldQuit: {4}, ShouldRecenter: {5}, HasInputFocus: {6}, OverlayPresent: {7}, DepthRequested: {8} }}",
                   IsVisible, HmdPresent, HmdMounted, DisplayLost, ShouldQuit, ShouldRecenter, HasInputFocus, OverlayPresent, DepthRequested);
        }
    }
}
