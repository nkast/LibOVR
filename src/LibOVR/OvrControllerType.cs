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
    public enum OvrControllerType : UInt32
    {
        None    = 0x0000,
        LTouch  = 0x0001,
        RTouch  = 0x0002,
        Touch   = (LTouch | RTouch),
        Remote  = 0x0004,

        XBox    = 0x0010,

        Object0 = 0x0100,
        Object1 = 0x0200,
        Object2 = 0x0400,
        Object3 = 0x0800,

        Active = 0xffffffff,
    }
}
