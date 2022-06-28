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
using System.Collections;
using System.Collections.Generic;

namespace nkast.LibOVR
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct OvrFixedArray2<T>
    {
        public T Item0;
        public T Item1;

        public T this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return Item0;
                    case 1:
                        return Item1;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        Item0 = value;
                        break;
                    case 1:
                        Item1 = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
        }

        public int Count { get { return 2; } }


        public unsafe override string ToString()
        {
            return string.Format("[{0},{1}]", Item0, Item1);
        }

    }
}
