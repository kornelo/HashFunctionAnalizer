using System;
using System.Security.Cryptography;

namespace HashFunctionAnalizer.HashFunctions
{
    internal class SHA1: HashAlgorithm
    {
        internal readonly uint[] _h = new uint[5];
        internal byte[] Buffer1 { get; set; }
        internal int BuffLength { get; set; }

        public SHA1()
        {
            _h[0] = 0x67452301;
            _h[1] = 0xefcdab89;
            _h[2] = 0x98badcfe;
            _h[3] = 0x10325476;
            _h[4] = 0xc3d2e1f0;
        }

        public override void Initialize()
        {
            Buffer1 = null;
            BuffLength = 0;
            HashValue = null;

            _h[0] = 0x67452301;
            _h[1] = 0xefcdab89;
            _h[2] = 0x98badcfe;
            _h[3] = 0x10325476;
            _h[4] = 0xc3d2e1f0;
        }


        private uint[] PadInput(byte[] input)
        {
            var bytesToPad = Convert.ToUInt32((64 - (input.Length%64))%64);
            if (input.Length == 0) bytesToPad = 64;
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

            var a = _h[0];
            var b = _h[1];
            var c = _h[2];
            var d = _h[3];
            var e = _h[4];

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

            _h[0] += a;
            _h[1] += b;
            _h[2] += c;
            _h[3] += d;
            _h[4] += e;

            return _h;
        }


        protected override void HashCore(byte[] array, int ibStart, int cbSize)
        {
            if (array == null)
                throw new ArgumentNullException("array");
            if (ibStart < 0)
                throw new ArgumentOutOfRangeException("ibStart");
            if (cbSize > array.Length)
                throw new ArgumentOutOfRangeException("cbSize");
            if (ibStart + cbSize > array.Length)
                throw new ArgumentOutOfRangeException("ibStart or cbSize");
            if (Buffer1 == null)
                Buffer1 = new byte[array.Length];
            AddToBuffer(array, ref ibStart, ref cbSize);
        }

        protected override byte[] HashFinal()
        {
            byte[] outb = new byte[20];
            uint[] utemps = TransformBlock(Buffer1);

            System.Buffer.BlockCopy(utemps, 0, outb, 0, utemps.Length*4);
            outb = PrepareOutput(outb);
            return outb;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        protected void AddToBuffer(byte[] array, ref int offset, ref int count)
        {
            int amount = Math.Min(count, Buffer1.Length - BuffLength);
            System.Buffer.BlockCopy(array, offset, Buffer1, BuffLength, amount);
            offset += amount;
            BuffLength += amount;
            count -= amount;
        }

        /// <summary>
        /// 
        /// </summary>
        public override byte[] Hash
        {
            get
            {
                return HashValue;
            }
        }

        public byte[] PrepareOutput(byte[] state)
        {
            int length = state.Length > 32 ? 8 : 4;
            var tmp = new byte[state.Length];
            int i = 0;

            for (var x = 0; x < state.Length; x += length)
            {
                for (var y = length - 1; y >= 0; y--)
                {
                    tmp[i] = state[x + y];
                    i++;
                }
            }
            return tmp;
        }

        #region Const

        private const uint K0 = 0x5a827999;
        private const uint K1 = 0x6ed9eba1;
        private const uint K2 = 0x8f1bbcdc;
        private const uint K3 = 0xca62c1d6;

        #endregion
    }
}