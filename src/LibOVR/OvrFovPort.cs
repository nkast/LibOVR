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
    public struct OvrFovPort
    {
        public float UpTan;    // The tangent of the angle between the viewing vector and the top edge of the field of view.
        public float DownTan;  // The tangent of the angle between the viewing vector and the bottom edge of the field of view.
        public float LeftTan;  // The tangent of the angle between the viewing vector and the left edge of the field of view.
        public float RightTan; // The tangent of the angle between the viewing vector and the right edge of the field of view.

        public override string ToString()
        {
            return String.Format("{{UpTan: {0}, DownTan: {1}, LeftTan: {2}, RightTan: {3} }}",
                   UpTan, DownTan, LeftTan, RightTan);
        }
    }
}
