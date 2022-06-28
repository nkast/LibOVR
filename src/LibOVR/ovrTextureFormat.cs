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
    public enum OvrTextureFormat : Int32
    {
        UNKNOWN             =  0,
        B5G6R5_UNORM        =  1, ///< Not currently supported on PC. Requires a DirectX 11.1 device.
        B5G5R5A1_UNORM      =  2, ///< Not currently supported on PC. Requires a DirectX 11.1 device.
        B4G4R4A4_UNORM      =  3, ///< Not currently supported on PC. Requires a DirectX 11.1 device.
        R8G8B8A8_UNORM      =  4,
        R8G8B8A8_UNORM_SRGB =  5,
        B8G8R8A8_UNORM      =  6,
        B8G8R8A8_UNORM_SRGB =  7, ///< Not supported for OpenGL applications
        B8G8R8X8_UNORM      =  8, ///< Not supported for OpenGL applications
        B8G8R8X8_UNORM_SRGB =  9, ///< Not supported for OpenGL applications
        R16G16B16A16_FLOAT  = 10,
        R11G11B10_FLOAT     = 25, ///< Not supported for D3D12 applications. Introduced in v1.10
        B8G8R8_UNORM        = 27, ///< Not currently supported.

        // Depth formats
        D16_UNORM           = 11,
        D24_UNORM_S8_UINT   = 12,
        D32_FLOAT           = 13,
        D32_FLOAT_S8X24_UINT= 14,

        // Added in 1.5 compressed formats can be used for static layers
        BC1_UNORM           = 15,
        BC1_UNORM_SRGB      = 16,
        BC2_UNORM           = 17,
        BC2_UNORM_SRGB      = 18,
        BC3_UNORM           = 19,
        BC3_UNORM_SRGB      = 20,
        BC6H_UF16           = 21,
        BC6H_SF16           = 22,
        BC7_UNORM           = 23,
        BC7_UNORM_SRGB      = 24,
    }
}
