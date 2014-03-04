﻿//******************************************************************************************************
//  Encoding7Bit.cs - Gbtc
//
//  Copyright © 2013, Grid Protection Alliance.  All Rights Reserved.
//
//  Licensed to the Grid Protection Alliance (GPA) under one or more contributor license agreements. See
//  the NOTICE file distributed with this work for additional information regarding copyright ownership.
//  The GPA licenses this file to you under the Eclipse Public License -v 1.0 (the "License"); you may
//  not use this file except in compliance with the License. You may obtain a copy of the License at:
//
//      http://www.opensource.org/licenses/eclipse-1.0.php
//
//  Unless agreed to in writing, the subject software distributed under the License is distributed on an
//  "AS-IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. Refer to the
//  License for the specific language governing permissions and limitations.
//
//  Code Modification History:
//  ----------------------------------------------------------------------------------------------------
//  3/16/2012 - Steven E. Chisholm
//       Generated original version of source code. 
//       
//
//******************************************************************************************************

using System;

namespace GSF
{
    /// <summary>
    /// Contains 7 bit encoding functions
    /// </summary>
    public static class Encoding7Bit
    {
        public static int GetSize(uint value1)
        {
            if (value1 < 128)
                return 1;
            if (value1 < 128 * 128)
                return 2;
            if (value1 < 128 * 128 * 128)
                return 3;
            if (value1 < 128 * 128 * 128 * 128)
                return 4;
            return 5;
        }

        public static int GetSize(ulong value1)
        {
            if (value1 < 128)
                return 1;
            if (value1 < 128 * 128)
                return 2;
            if (value1 < 128 * 128 * 128)
                return 3;
            if (value1 < 128 * 128 * 128 * 128)
                return 4;
            if (value1 < 128L * 128 * 128 * 128 * 128)
                return 5;
            if (value1 < 128L * 128 * 128 * 128 * 128 * 128)
                return 6;
            if (value1 < 128L * 128 * 128 * 128 * 128 * 128 * 128)
                return 7;
            if (value1 < 128L * 128 * 128 * 128 * 128 * 128 * 128 * 128)
                return 8;
            return 9;
        }

        public static unsafe void Write(byte* stream, ref int position, uint value1)
        {
            if (value1 < 128)
            {
                stream[position] = (byte)value1;
                position += 1;
                return;
            }
            stream[position] = (byte)(value1 | 128);
            if (value1 < 128 * 128)
            {
                stream[position + 1] = (byte)(value1 >> 7);
                position += 2;
                return;
            }
            stream[position + 1] = (byte)((value1 >> 7) | 128);
            if (value1 < 128 * 128 * 128)
            {
                stream[position + 2] = (byte)(value1 >> 14);
                position += 3;
                return;
            }
            stream[position + 2] = (byte)((value1 >> 14) | 128);
            if (value1 < 128 * 128 * 128 * 128)
            {
                stream[position + 3] = (byte)(value1 >> 21);
                position += 4;
                return;
            }
            stream[position + 3] = (byte)((value1 >> 21) | 128);
            stream[position + 4] = (byte)(value1 >> 28);
            position += 5;
            return;
        }

        public static void Write(byte[] stream, ref int position, uint value1)
        {
            if (value1 < 128)
            {
                stream[position] = (byte)value1;
                position += 1;
                return;
            }
            stream[position] = (byte)(value1 | 128);
            if (value1 < 128 * 128)
            {
                stream[position + 1] = (byte)(value1 >> 7);
                position += 2;
                return;
            }
            stream[position + 1] = (byte)((value1 >> 7) | 128);
            if (value1 < 128 * 128 * 128)
            {
                stream[position + 2] = (byte)(value1 >> 14);
                position += 3;
                return;
            }
            stream[position + 2] = (byte)((value1 >> 14) | 128);
            if (value1 < 128 * 128 * 128 * 128)
            {
                stream[position + 3] = (byte)(value1 >> 21);
                position += 4;
                return;
            }
            stream[position + 3] = (byte)((value1 >> 21) | 128);
            stream[position + 4] = (byte)(value1 >> 28);
            position += 5;
            return;
        }

        public static void Write(Action<byte> stream, uint value1)
        {
            if (value1 < 128)
            {
                stream((byte)value1);
                return;
            }
            stream((byte)(value1 | 128));
            if (value1 < 128 * 128)
            {
                stream((byte)(value1 >> 7));
                return;
            }
            stream((byte)((value1 >> 7) | 128));
            if (value1 < 128 * 128 * 128)
            {
                stream((byte)(value1 >> 14));
                return;
            }
            stream((byte)((value1 >> 14) | 128));
            if (value1 < 128 * 128 * 128 * 128)
            {
                stream((byte)(value1 >> 21));
                return;
            }
            stream((byte)((value1 >> 21) | 128));
            stream((byte)(value1 >> 28));
        }

        public static void ReadUInt32(byte[] stream, ref int position, out uint value1)
        {
            int pos = position;
            uint value11;
            value11 = stream[pos];
            if (value11 < 128)
            {
                position = pos + 1;
                value1 = value11;
                return;
            }
            value11 ^= ((uint)stream[pos + 1] << 7);
            if (value11 < 128 * 128)
            {
                position = pos + 2;
                value1 = value11 ^ 0x80;
                return;
            }
            value11 ^= ((uint)stream[pos + 2] << 14);
            if (value11 < 128 * 128 * 128)
            {
                position = pos + 3;
                value1 = value11 ^ 0x4080;
                return;
            }
            value11 ^= ((uint)stream[pos + 3] << 21);
            if (value11 < 128 * 128 * 128 * 128)
            {
                position = pos + 4;
                value1 = value11 ^ 0x204080;
                return;
            }
            value11 ^= ((uint)stream[pos + 4] << 28) ^ 0x10204080;
            position = pos + 5;
            value1 = value11;
            return;
        }

        public static uint ReadUInt32(Func<byte> stream)
        {
            uint value11;
            value11 = stream();
            if (value11 < 128)
            {
                return value11;
            }
            value11 ^= ((uint)stream() << 7);
            if (value11 < 128 * 128)
            {
                return value11 ^ 0x80;
            }
            value11 ^= ((uint)stream() << 14);
            if (value11 < 128 * 128 * 128)
            {
                return value11 ^ 0x4080;
            }
            value11 ^= ((uint)stream() << 21);
            if (value11 < 128 * 128 * 128 * 128)
            {
                return value11 ^ 0x204080;
            }
            value11 ^= ((uint)stream() << 28) ^ 0x10204080;
            return value11;
        }

        public static ulong ReadUInt64(Func<byte> stream)
        {
            ulong value11;
            value11 = stream();
            if (value11 < 128)
            {
                return value11;
            }
            value11 ^= ((ulong)stream() << (7));
            if (value11 < 128 * 128)
            {
                return value11 ^ 0x80;
            }
            value11 ^= ((ulong)stream() << (7 + 7));
            if (value11 < 128 * 128 * 128)
            {
                return value11 ^ 0x4080;
            }
            value11 ^= ((ulong)stream() << (7 + 7 + 7));
            if (value11 < 128 * 128 * 128 * 128)
            {
                return value11 ^ 0x204080;
            }
            value11 ^= ((ulong)stream() << (7 + 7 + 7 + 7));
            if (value11 < 128L * 128 * 128 * 128 * 128)
            {
                return value11 ^ 0x10204080L;
            }
            value11 ^= ((ulong)stream() << (7 + 7 + 7 + 7 + 7));
            if (value11 < 128L * 128 * 128 * 128 * 128 * 128)
            {
                return value11 ^ 0x810204080L;
            }
            value11 ^= ((ulong)stream() << (7 + 7 + 7 + 7 + 7 + 7));
            if (value11 < 128L * 128 * 128 * 128 * 128 * 128 * 128)
            {
                return value11 ^ 0x40810204080L;
            }
            value11 ^= ((ulong)stream() << (7 + 7 + 7 + 7 + 7 + 7 + 7));
            if (value11 < 128L * 128 * 128 * 128 * 128 * 128 * 128 * 128)
            {
                return value11 ^ 0x2040810204080L;
            }
            value11 ^= ((ulong)stream() << (7 + 7 + 7 + 7 + 7 + 7 + 7 + 7));
            return value11 ^ 0x102040810204080L;
        }

        public static void ReadUInt64(byte[] stream, ref int position, out ulong value1)
        {
            int pos = position;
            ulong value11;
            value11 = stream[pos];
            if (value11 < 128)
            {
                position += 1;
                value1 = value11;
                return;
            }
            value11 ^= ((ulong)stream[pos + 1] << (7));
            if (value11 < 128 * 128)
            {
                position += 2;
                value1 = value11 ^ 0x80;
                return;
            }
            value11 ^= ((ulong)stream[pos + 2] << (7 + 7));
            if (value11 < 128 * 128 * 128)
            {
                position += 3;
                value1 = value11 ^ 0x4080;
                return;
            }
            value11 ^= ((ulong)stream[pos + 3] << (7 + 7 + 7));
            if (value11 < 128 * 128 * 128 * 128)
            {
                position += 4;
                value1 = value11 ^ 0x204080;
                return;
            }
            value11 ^= ((ulong)stream[pos + 4] << (7 + 7 + 7 + 7));
            if (value11 < 128L * 128 * 128 * 128 * 128)
            {
                position += 5;
                value1 = value11 ^ 0x10204080L;
                return;
            }
            value11 ^= ((ulong)stream[pos + 5] << (7 + 7 + 7 + 7 + 7));
            if (value11 < 128L * 128 * 128 * 128 * 128 * 128)
            {
                position += 6;
                value1 = value11 ^ 0x810204080L;
                return;
            }
            value11 ^= ((ulong)stream[pos + 6] << (7 + 7 + 7 + 7 + 7 + 7));
            if (value11 < 128L * 128 * 128 * 128 * 128 * 128 * 128)
            {
                position += 7;
                value1 = value11 ^ 0x40810204080L;
                return;
            }
            value11 ^= ((ulong)stream[pos + 7] << (7 + 7 + 7 + 7 + 7 + 7 + 7));
            if (value11 < 128L * 128 * 128 * 128 * 128 * 128 * 128 * 128)
            {
                position += 8;
                value1 = value11 ^ 0x2040810204080L;
                return;
            }
            value11 ^= ((ulong)stream[pos + 8] << (7 + 7 + 7 + 7 + 7 + 7 + 7 + 7));
            position += 9;
            value1 = value11 ^ 0x102040810204080L;
            return;
        }

        public unsafe static int MeasureUInt64(byte* stream, int position)
        {
            stream += position;
            if (stream[0] < 128)
                return 1;
            if (stream[1] < 128)
                return 2;
            if (stream[2] < 128)
                return 3;
            if (stream[3] < 128)
                return 4;
            if (stream[4] < 128)
                return 5;
            if (stream[5] < 128)
                return 6;
            if (stream[6] < 128)
                return 7;
            if (stream[7] < 128)
                return 8;
            return 9;
        }

        public unsafe static ulong ReadUInt64(byte* stream, ref int position)
        {
            ulong value;
            ReadUInt64(stream, ref position, out value);
            return value;
        }

        public unsafe static void ReadUInt64(byte* stream, ref int position, out ulong value1)
        {
            int pos = position;
            ulong value11;
            value11 = stream[pos];
            if (value11 < 128)
            {
                position += 1;
                value1 = value11;
                return;
            }
            value11 ^= ((ulong)stream[pos + 1] << (7));
            if (value11 < 128 * 128)
            {
                position += 2;
                value1 = value11 ^ 0x80;
                return;
            }
            value11 ^= ((ulong)stream[pos + 2] << (7 + 7));
            if (value11 < 128 * 128 * 128)
            {
                position += 3;
                value1 = value11 ^ 0x4080;
                return;
            }
            value11 ^= ((ulong)stream[pos + 3] << (7 + 7 + 7));
            if (value11 < 128 * 128 * 128 * 128)
            {
                position += 4;
                value1 = value11 ^ 0x204080;
                return;
            }
            value11 ^= ((ulong)stream[pos + 4] << (7 + 7 + 7 + 7));
            if (value11 < 128L * 128 * 128 * 128 * 128)
            {
                position += 5;
                value1 = value11 ^ 0x10204080L;
                return;
            }
            value11 ^= ((ulong)stream[pos + 5] << (7 + 7 + 7 + 7 + 7));
            if (value11 < 128L * 128 * 128 * 128 * 128 * 128)
            {
                position += 6;
                value1 = value11 ^ 0x810204080L;
                return;
            }
            value11 ^= ((ulong)stream[pos + 6] << (7 + 7 + 7 + 7 + 7 + 7));
            if (value11 < 128L * 128 * 128 * 128 * 128 * 128 * 128)
            {
                position += 7;
                value1 = value11 ^ 0x40810204080L;
                return;
            }
            value11 ^= ((ulong)stream[pos + 7] << (7 + 7 + 7 + 7 + 7 + 7 + 7));
            if (value11 < 128L * 128 * 128 * 128 * 128 * 128 * 128 * 128)
            {
                position += 8;
                value1 = value11 ^ 0x2040810204080L;
                return;
            }
            value11 ^= ((ulong)stream[pos + 8] << (7 + 7 + 7 + 7 + 7 + 7 + 7 + 7));
            position += 9;
            value1 = value11 ^ 0x102040810204080L;
            return;
        }


        unsafe public static void Write(byte* stream, ref int position, ulong value1)
        {
            if (value1 < 128)
            {
                stream[position] = (byte)value1;
                position += 1;
                return;
            }
            stream[position] = (byte)(value1 | 128);
            if (value1 < 128 * 128)
            {
                stream[position + 1] = (byte)(value1 >> 7);
                position += 2;
                return;
            }
            stream[position + 1] = (byte)((value1 >> 7) | 128);
            if (value1 < 128 * 128 * 128)
            {
                stream[position + 2] = (byte)(value1 >> (7 + 7));
                position += 3;
                return;
            }
            stream[position + 2] = (byte)((value1 >> (7 + 7)) | 128);
            if (value1 < 128 * 128 * 128 * 128)
            {
                stream[position + 3] = (byte)(value1 >> (7 + 7 + 7));
                position += 4;
                return;
            }
            stream[position + 3] = (byte)((value1 >> (7 + 7 + 7)) | 128);
            if (value1 < 128L * 128 * 128 * 128 * 128)
            {
                stream[position + 4] = (byte)(value1 >> (7 + 7 + 7 + 7));
                position += 5;
                return;
            }
            stream[position + 4] = (byte)((value1 >> (7 + 7 + 7 + 7)) | 128);
            if (value1 < 128L * 128 * 128 * 128 * 128 * 128)
            {
                stream[position + 5] = (byte)(value1 >> (7 + 7 + 7 + 7 + 7));
                position += 6;
                return;
            }
            stream[position + 5] = (byte)((value1 >> (7 + 7 + 7 + 7 + 7)) | 128);
            if (value1 < 128L * 128 * 128 * 128 * 128 * 128 * 128)
            {
                stream[position + 6] = (byte)(value1 >> (7 + 7 + 7 + 7 + 7 + 7));
                position += 7;
                return;
            }
            stream[position + 6] = (byte)((value1 >> (7 + 7 + 7 + 7 + 7 + 7)) | 128);
            if (value1 < 128L * 128 * 128 * 128 * 128 * 128 * 128 * 128)
            {
                stream[position + 7] = (byte)(value1 >> (7 + 7 + 7 + 7 + 7 + 7 + 7));
                position += 8;
                return;
            }
            stream[position + 7] = (byte)(value1 >> (7 + 7 + 7 + 7 + 7 + 7 + 7) | 128);
            stream[position + 8] = (byte)(value1 >> (7 + 7 + 7 + 7 + 7 + 7 + 7 + 7));
            position += 9;
            return;
        }

        public static void Write(byte[] stream, ref int position, ulong value1)
        {
            if (value1 < 128)
            {
                stream[position] = (byte)value1;
                position += 1;
                return;
            }
            stream[position] = (byte)(value1 | 128);
            if (value1 < 128 * 128)
            {
                stream[position + 1] = (byte)(value1 >> 7);
                position += 2;
                return;
            }
            stream[position + 1] = (byte)((value1 >> 7) | 128);
            if (value1 < 128 * 128 * 128)
            {
                stream[position + 2] = (byte)(value1 >> (7 + 7));
                position += 3;
                return;
            }
            stream[position + 2] = (byte)((value1 >> (7 + 7)) | 128);
            if (value1 < 128 * 128 * 128 * 128)
            {
                stream[position + 3] = (byte)(value1 >> (7 + 7 + 7));
                position += 4;
                return;
            }
            stream[position + 3] = (byte)((value1 >> (7 + 7 + 7)) | 128);
            if (value1 < 128L * 128 * 128 * 128 * 128)
            {
                stream[position + 4] = (byte)(value1 >> (7 + 7 + 7 + 7));
                position += 5;
                return;
            }
            stream[position + 4] = (byte)((value1 >> (7 + 7 + 7 + 7)) | 128);
            if (value1 < 128L * 128 * 128 * 128 * 128 * 128)
            {
                stream[position + 5] = (byte)(value1 >> (7 + 7 + 7 + 7 + 7));
                position += 6;
                return;
            }
            stream[position + 5] = (byte)((value1 >> (7 + 7 + 7 + 7 + 7)) | 128);
            if (value1 < 128L * 128 * 128 * 128 * 128 * 128 * 128)
            {
                stream[position + 6] = (byte)(value1 >> (7 + 7 + 7 + 7 + 7 + 7));
                position += 7;
                return;
            }
            stream[position + 6] = (byte)((value1 >> (7 + 7 + 7 + 7 + 7 + 7)) | 128);
            if (value1 < 128L * 128 * 128 * 128 * 128 * 128 * 128 * 128)
            {
                stream[position + 7] = (byte)(value1 >> (7 + 7 + 7 + 7 + 7 + 7 + 7));
                position += 8;
                return;
            }
            stream[position + 7] = (byte)(value1 >> (7 + 7 + 7 + 7 + 7 + 7 + 7) | 128);
            stream[position + 8] = (byte)(value1 >> (7 + 7 + 7 + 7 + 7 + 7 + 7 + 7));
            position += 9;
            return;
        }

        public static void Write(Action<byte> stream, ulong value1)
        {
            if (value1 < 128)
            {
                stream((byte)value1);
                return;
            }
            stream((byte)(value1 | 128));
            if (value1 < 128 * 128)
            {
                stream((byte)(value1 >> 7));
                return;
            }
            stream((byte)((value1 >> 7) | 128));
            if (value1 < 128 * 128 * 128)
            {
                stream((byte)(value1 >> (7 + 7)));
                return;
            }
            stream((byte)((value1 >> (7 + 7)) | 128));
            if (value1 < 128 * 128 * 128 * 128)
            {
                stream((byte)(value1 >> (7 + 7 + 7)));
                return;
            }
            stream((byte)((value1 >> (7 + 7 + 7)) | 128));
            if (value1 < 128L * 128 * 128 * 128 * 128)
            {
                stream((byte)(value1 >> (7 + 7 + 7 + 7)));
                return;
            }
            stream((byte)((value1 >> (7 + 7 + 7 + 7)) | 128));
            if (value1 < 128L * 128 * 128 * 128 * 128 * 128)
            {
                stream((byte)(value1 >> (7 + 7 + 7 + 7 + 7)));
                return;
            }
            stream((byte)((value1 >> (7 + 7 + 7 + 7 + 7)) | 128));
            if (value1 < 128L * 128 * 128 * 128 * 128 * 128 * 128)
            {
                stream((byte)(value1 >> (7 + 7 + 7 + 7 + 7 + 7)));
                return;
            }
            stream((byte)((value1 >> (7 + 7 + 7 + 7 + 7 + 7)) | 128));
            if (value1 < 128L * 128 * 128 * 128 * 128 * 128 * 128 * 128)
            {
                stream((byte)(value1 >> (7 + 7 + 7 + 7 + 7 + 7 + 7)));
                return;
            }
            stream((byte)(value1 >> (7 + 7 + 7 + 7 + 7 + 7 + 7) | 128));
            stream((byte)(value1 >> (7 + 7 + 7 + 7 + 7 + 7 + 7 + 7)));
            return;
        }
        
    }
}