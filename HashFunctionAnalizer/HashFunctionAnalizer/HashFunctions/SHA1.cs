using System;

namespace HashFunctionAnalizer.HashFunctions
{
    internal class SHA1
    {
        private readonly uint[] H = new uint[5];

        public SHA1()
        {
            Initialize();
        }

        protected virtual void Initialize()
        {
            H[0] = 0x67452301;
            H[1] = 0xefcdab89;
            H[2] = 0x98badcfe;
            H[3] = 0x10325476;
            H[4] = 0xc3d2e1f0;
        }

        public virtual uint[] Hash(byte[] data)
        {
            Initialize();
            return TransformBlock(data);
        }

        private uint[] PadInput(byte[] input)
        {
            var bytesToPad = Convert.ToUInt32((64 - (input.Length%64))%64);
            var paddedInput = new byte[input.Length + bytesToPad];
            if (bytesToPad == 0)
            {
                Array.Copy(input, paddedInput, paddedInput.Length);
            }
            else
            {
                for (var i = 0; i < input.Length; i++)
                {
                    paddedInput[i] = input[i];
                }
                paddedInput[input.Length] = 0x80;

                for (var i = 1; i < bytesToPad - 2; i++)
                {
                    paddedInput[input.Length + i] = 0;
                }
                paddedInput[paddedInput.Length - 2] = GetByte((64 - bytesToPad)*8, 1);
                paddedInput[paddedInput.Length - 1] = GetByte((64 - bytesToPad)*8, 0);
            }

            //Input is padded to 512bit size blocks

            var result = new uint[paddedInput.Length/4];
            for (var i = 0; i < paddedInput.Length; i += 4)
            {
                uint temp = 0;
                temp += paddedInput[i];
                temp = temp << 8;

                temp += paddedInput[i + 1];
                temp = temp << 8;

                temp += paddedInput[i + 2];
                temp = temp << 8;

                temp += paddedInput[i + 3];
                result[i/4] = temp;
            }
            return result;
        }

        private static byte GetByte(uint x, int n)
        {
            return (byte) ((x >> 8*n) & 0xFF);
        }

        private static uint Shift(int bits, uint word)
        {
            return (word << bits | word >> (32 - bits));
        }

        protected virtual uint[] TransformBlock(byte[] aData)
        {
            var data = PadInput(aData);
            var resultHash = new uint[80];

            var a = H[0];
            var b = H[1];
            var c = H[2];
            var d = H[3];
            var e = H[4];

            uint temp;
            int t;

            for (t = 0; t < 16; t++)
            {
                resultHash[t] = data[t];
            }

            for (t = 16; t < 80; t++)
            {
                resultHash[t] = Shift(1,
                    (resultHash[t - 3] ^ resultHash[t - 8] ^ resultHash[t - 14] ^ resultHash[t - 16]));
            }

            for (t = 0; t < 20; t++)
            {
                temp = Shift(5, a) + ((b & c) | ((~b) & d)) + e + resultHash[t] + K0;
                e = d;
                d = c;
                c = Shift(30, b);
                b = a;
                a = temp;
            }

            for (t = 20; t < 40; t++)
            {
                temp = Shift(5, a) + (b ^ c ^ d) + e + resultHash[t] + K1;
                e = d;
                d = c;
                c = Shift(30, b);
                b = a;
                a = temp;
            }

            for (t = 40; t < 60; t++)
            {
                temp = Shift(5, a) + ((b & c) | (b & d) | (c & d)) + e + resultHash[t] + K2;
                e = d;
                d = c;
                c = Shift(30, b);
                b = a;
                a = temp;
            }

            for (t = 60; t < 80; t++)
            {
                temp = Shift(5, a) + (b ^ c ^ d) + e + resultHash[t] + K3;
                e = d;
                d = c;
                c = Shift(30, b);
                b = a;
                a = temp;
            }

            H[0] += a;
            H[1] += b;
            H[2] += c;
            H[3] += d;
            H[4] += e;

            return H;
        }

        #region Const

        private const uint K0 = 0x5a827999;
        private const uint K1 = 0x6ed9eba1;
        private const uint K2 = 0x8f1bbcdc;
        private const uint K3 = 0xca62c1d6;

        #endregion
    }
}