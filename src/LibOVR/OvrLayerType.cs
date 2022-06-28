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
    public enum OvrLayerType : Int32
    {
        Disabled        =  0,
        EyeFov          =  1,
        EyeFovDepth     =  2,
        Quad            =  3,
        //QuadHeadLocked  =  4, // use ovrLayerType_Quad with ovrLayerFlag_HeadLocked.
        EyeMatrix       =  5,
        EyeFovMultires  =  7,
        Cylinder        =  8,
        Cube            = 10,
    }
}
