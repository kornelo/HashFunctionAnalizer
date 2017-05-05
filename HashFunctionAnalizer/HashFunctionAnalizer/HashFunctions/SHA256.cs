using System;

namespace HashFunctionAnalizer.HashFunctions
{
    internal class Sha256 : IDisposable
    {
        private static readonly uint[] K =
        {
            0x428a2f98, 0x71374491, 0xb5c0fbcf, 0xe9b5dba5, 0x3956c25b, 0x59f111f1, 0x923f82a4, 0xab1c5ed5,
            0xd807aa98, 0x12835b01, 0x243185be, 0x550c7dc3, 0x72be5d74, 0x80deb1fe, 0x9bdc06a7, 0xc19bf174,
            0xe49b69c1, 0xefbe4786, 0x0fc19dc6, 0x240ca1cc, 0x2de92c6f, 0x4a7484aa, 0x5cb0a9dc, 0x76f988da,
            0x983e5152, 0xa831c66d, 0xb00327c8, 0xbf597fc7, 0xc6e00bf3, 0xd5a79147, 0x06ca6351, 0x14292967,
            0x27b70a85, 0x2e1b2138, 0x4d2c6dfc, 0x53380d13, 0x650a7354, 0x766a0abb, 0x81c2c92e, 0x92722c85,
            0xa2bfe8a1, 0xa81a664b, 0xc24b8b70, 0xc76c51a3, 0xd192e819, 0xd6990624, 0xf40e3585, 0x106aa070,
            0x19a4c116, 0x1e376c08, 0x2748774c, 0x34b0bcb5, 0x391c0cb3, 0x4ed8aa4a, 0x5b9cca4f, 0x682e6ff3,
            0x748f82ee, 0x78a5636f, 0x84c87814, 0x8cc70208, 0x90befffa, 0xa4506ceb, 0xbef9a3f7, 0xc67178f2
        };

        private readonly uint[] _h = new uint[8];

        public Sha256()
        {
            Initialize();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public virtual uint[] Hash(byte[] data)
        {
            Initialize();
            return TransformBlock(data);
        }

        protected virtual void Initialize()
        {
            _h[0] = 0x6a09e667;
            _h[1] = 0xbb67ae85;
            _h[2] = 0x3c6ef372;
            _h[3] = 0xa54ff53a;
            _h[4] = 0x510e527f;
            _h[5] = 0x9b05688c;
            _h[6] = 0x1f83d9ab;
            _h[7] = 0x5be0cd19;
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

        private static uint Shr(int bit, uint x)
        {
            return x >> bit;
        }

        private static uint Rotr(int bit, uint x)
        {
            return (x >> bit) | (x << (32 - bit));
        }

        private static uint Rotl(int bit, uint x)
        {
            return (x << bit) | (x >> 32 - bit);
        }

        private static uint Ch(uint x, uint y, uint z)
        {
            return (x & y) ^ ((x ^ 0xffffffff) & z);
        }

        private static uint Maj(uint x, uint y, uint z)
        {
            return (x & y) ^ (x & z) ^ (y & z);
        }

        private static uint Bsig0(uint x)
        {
            return Rotr(2, x) ^ Rotr(13, x) ^ Rotr(22, x);
        }

        private static uint Bsig1(uint x)
        {
            return Rotr(6, x) ^ Rotr(11, x) ^ Rotr(25, x);
        }

        private static uint Ssig0(uint x)
        {
            return Rotr(7, x) ^ Rotr(18, x) ^ Shr(3, x);
        }

        private static uint Ssig1(uint x)
        {
            return Rotr(17, x) ^ Rotr(19, x) ^ Shr(10, x);
        }

        protected virtual uint[] TransformBlock(byte[] aData)
        {
            var data = PadInput(aData);
            var resultHash = new uint[64];

            int t;

            for (t = 0; t < 16; t++)
            {
                resultHash[t] = data[t];
            }

            for (t = 16; t < 64; t++)
            {
                resultHash[t] = Ssig1(resultHash[t - 2]) + resultHash[t - 7] + Ssig0(resultHash[t - 15]) +
                                resultHash[t - 16];
            }

            var a = _h[0];
            var b = _h[1];
            var c = _h[2];
            var d = _h[3];
            var e = _h[4];
            var f = _h[5];
            var g = _h[6];
            var h = _h[7];

            for (t = 0; t < 64; t++)
            {
                var tmp1 = h + Bsig1(e) + Ch(e, f, g) + K[t] + resultHash[t];
                var tmp2 = Bsig0(a) + Maj(a, b, c);
                h = g;
                g = f;
                f = e;
                e = d + tmp1;
                d = c;
                c = b;
                b = a;
                a = tmp1 + tmp2;
            }

            _h[0] = a + _h[0];
            _h[1] = b + _h[1];
            _h[2] = c + _h[2];
            _h[3] = d + _h[3];
            _h[4] = e + _h[4];
            _h[5] = f + _h[5];
            _h[6] = g + _h[6];
            _h[7] = h + _h[7];

            return _h;
        }
    }
}