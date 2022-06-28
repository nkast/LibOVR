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
    public struct OvrRecti
    {
        public int X;
        public int Y;
        public int W;
        public int H;

        public OvrRecti(int x, int y, int w, int h) : this()
        {
            this.X = x;
            this.Y = y;
            this.W = w;
            this.H = h;
        }

        public override string ToString()
        {
            return String.Format("{{X: {0}, Y: {1}, W: {2}, H: {3} }}",
                   X, Y, W, H);
        }
    }

}
