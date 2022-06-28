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
    public enum OvrTouch : Int32
    {
        A               = OvrButton.A,
        B               = OvrButton.B,
        RThumb          = OvrButton.RThumb,
        RThumbRest      = 0x00000008,
        RIndexTrigger   = 0x00000010,

        X               = OvrButton.X,
        Y               = OvrButton.Y,
        LThumb          = OvrButton.LThumb,
        LThumbRest      = 0x00000800,
        LIndexTrigger   = 0x00001000,

        RIndexPointing  = 0x00000020,
        RThumbUp        = 0x00000040,
        LIndexPointing  = 0x00002000,
        LThumbUp        = 0x00004000,
    }
}
