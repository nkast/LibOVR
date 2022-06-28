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
    public struct OvrTextureSwapChainDesc
    {
        public OvrTextureType Type;
        public OvrTextureFormat Format;
        public int ArraySize;
        public int Width;
        public int Height;
        public int MipLevels;
        public int SampleCount;
        public OvrBool StaticImage;
        public OvrTextureMiscFlags MiscFlags;
        public OvrTextureBindFlags BindFlags;


        public override string ToString()
        {
            return String.Format("{{Type: {0}, Format: {1}, ArraySize: {2}, Width: {3}, Height: {4}, MipLevels: {5}, SampleCount: {6}, StaticImage: {7}, MiscFlags: {8}, BindFlags: {9} }}",
                   Type, Format, ArraySize, Width, Height, MipLevels, SampleCount, StaticImage, MiscFlags, BindFlags);
        }
    }
}
