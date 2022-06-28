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
using System.Text;

namespace nkast.LibOVR
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public unsafe struct OvrHmdDesc
    {
        public OvrHmdType Type;
        fixed byte pad0[4];
        public fixed byte ProductName[64];
        public fixed byte Manufacturer[64];
        public short VendorId;
        public short ProductId;
        public fixed byte SerialNumber[24];
        public short FirmwareMajor;
        public short FirmwareMinor;
        public OvrHmdCaps AvailableHmdCaps;
        public OvrHmdCaps DefaultHmdCaps;
        public OvrTrackingCaps AvailableTrackingCaps;
        public OvrTrackingCaps DefaultTrackingCaps;
        public OvrFixedArray2<OvrFovPort> DefaultEyeFov;
        public OvrFixedArray2<OvrFovPort> MaxEyeFov;
        public OvrSizei Resolution;
        public float DisplayRefreshRate;
        fixed byte pad1[4];


        public unsafe override string ToString()
        {
            fixed (byte* pProductName = ProductName)
            fixed (byte* pManufacturer = Manufacturer)
            fixed (byte* pSerialNumber = SerialNumber)
            {
                string productName = Utf8PtrToString(pProductName, 64);
                string manufacturer = Utf8PtrToString(pManufacturer, 64);
                string serialNumber = Utf8PtrToString(pSerialNumber, 24);

                string defaultEyeFov = string.Format("[{0},{1}]", DefaultEyeFov[0], DefaultEyeFov[1]);
                string maxEyeFov = string.Format("[{0},{1}]", MaxEyeFov[0], MaxEyeFov[1]);

                return String.Format("{{Type: {0}, ProductName: {1}, Manufacturer: {2}, VendorId: {3}, ProductId: {4}, SerialNumber: {5}, FirmwareMajor: {6}, FirmwareMinor: {7}, AvailableHmdCaps: {8}, DefaultHmdCaps: {9}, AvailableTrackingCaps: {10}, DefaultTrackingCaps: {11}, DefaultEyeFov: {12}, MaxEyeFov: {13}, Resolution: {14}, DisplayRefreshRate: {15} }}",
                       Type, productName, manufacturer, VendorId, ProductId, serialNumber, FirmwareMajor, FirmwareMinor, AvailableHmdCaps, DefaultHmdCaps,
                       AvailableTrackingCaps, DefaultTrackingCaps, defaultEyeFov, maxEyeFov, Resolution, DisplayRefreshRate);
            }
        }

        private string Utf8PtrToString(byte* pBytes, int byteCount)
        {
            var bytes = new byte[byteCount];
            for(int i =0; i< byteCount; i++)
                bytes[i] = pBytes[i];

            return Encoding.ASCII.GetString(bytes).Trim('\0');
        }
    }
}