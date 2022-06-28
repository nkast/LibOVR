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

namespace nkast.LibOVR
{
    [Flags]
    public enum OvrButton : Int32
    {
        A           = 0x00000001,
        B           = 0x00000002,
        RThumb      = 0x00000004,
        RShoulder   = 0x00000008,
        X           = 0x00000100,
        Y           = 0x00000200,
        LThumb      = 0x00000400,
        LShoulder   = 0x00000800,
        Up          = 0x00010000,
        Down        = 0x00020000,
        Left        = 0x00040000,
        Right       = 0x00080000,
        Enter       = 0x00100000,
        Back        = 0x00200000,
        VolUp       = 0x00400000,
        VolDown     = 0x00800000,
        Home        = 0x01000000,
    }
}
