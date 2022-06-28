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
    public enum OvrInitFlags : Int32
    {
        Debug = 0x00000001,
        RequestVersion = 0x00000004,
        Invisible = 0x00000010,
        MixedRendering = 0x00000020,
        FocusAware = 0x00000040,
    }
}
