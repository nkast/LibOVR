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
    public struct OvrMatrix4f
    {
        public float M11;
        public float M12;
        public float M13;
        public float M14;
        public float M21;
        public float M22;
        public float M23;
        public float M24;
        public float M31;
        public float M32;
        public float M33;
        public float M34;
        public float M41;
        public float M42;
        public float M43;
        public float M44;

        public OvrMatrix4f(OvrPosef pose)
        {
            float ww = pose.Orientation.W * pose.Orientation.W;
            float xx = pose.Orientation.X * pose.Orientation.X;
            float yy = pose.Orientation.Y * pose.Orientation.Y;
            float zz = pose.Orientation.Z * pose.Orientation.Z;

            M11 = ww + xx - yy - zz;
            M12 = 2 * (pose.Orientation.X * pose.Orientation.Y - pose.Orientation.W * pose.Orientation.Z);
            M13 = 2 * (pose.Orientation.X * pose.Orientation.Z + pose.Orientation.W * pose.Orientation.Y);
            M14 = pose.Position.X;
            M21 = 2 * (pose.Orientation.X * pose.Orientation.Y + pose.Orientation.W * pose.Orientation.Z);
            M22 = ww - xx + yy - zz;
            M23 = 2 * (pose.Orientation.Y * pose.Orientation.Z - pose.Orientation.W * pose.Orientation.X);
            M24 = pose.Position.Y;
            M31 = 2 * (pose.Orientation.X * pose.Orientation.Z - pose.Orientation.W * pose.Orientation.Y);
            M32 = 2 * (pose.Orientation.Y * pose.Orientation.Z + pose.Orientation.W * pose.Orientation.X);
            M33 = ww - xx - yy + zz;
            M34 = pose.Position.Z;
            M41 = 0;
            M42 = 0;
            M43 = 0;
            M44 = 1;
        }

        public static OvrMatrix4f CreateProjection(OvrFovPort fov, float znear, float zfar, OvrProjectionModifier projectionModFlags)
        {
            return Native.ovrMatrix4f_Projection(fov, znear, zfar, projectionModFlags);
        }

        public override string ToString()
        {
            return String.Format("{{M11: {0}, M12: {1}, M13: {2}, M14: {3}, M21: {4}, M22: {5}, M23: {6}, M24: {7}, M31: {8}, M32: {9}, M33: {10}, M34: {11}, M41: {12}, M42: {13}, M43: {14}, M44: {15} }}",
                   M11, M12, M13, M14, M21, M22, M23, M24, M31, M32, M33, M34, M41, M42, M43, M44);
        }

    }
}
