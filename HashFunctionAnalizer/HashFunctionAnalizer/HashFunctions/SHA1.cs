using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashFunctionAnalizer.HashFunctions
{
    internal class SHA1
    {
        #region Const
        protected const uint k0 = 0x5a827999;
        protected const uint k1 = 0x6ed9eba1;
        protected const uint k2 = 0x8f1bbcdc;
        protected const uint k3 = 0xca62c1d6;
        #endregion

        protected uint[] H;

        public SHA1()
        {
            Initialize();
        }

        public virtual void Initialize()
        {
            H[0] = 0x67452301;
            H[1] = 0xefcdab89;
            H[2] = 0x98badcfe;
            H[3] = 0x10325476;
            H[4] = 0xc3d2e1f0;
        }

        protected virtual void Expand(uint[] data)
        {
            for (int i = 16; i < 80; i++)
            {
                uint T = data[i - 3] ^ data[i - 8] ^ data[i - 14] ^ data[i - 16];
                data[i] = ((T << 1) | (T >> 31));
            }
        }

        protected uint[] PadInput(byte[] input)
        {
            uint bytesToPad = Convert.ToUInt32((64 - (input.Length % 64)) % 64);
            byte[] paddedInput = new byte[input.Length + bytesToPad];
            if(bytesToPad == 0)
            {
                Array.Copy(input, paddedInput, paddedInput.Length);
            }
            else
            {
                for(int i=0; i< input.Length; i++)
                {
                    paddedInput[i] = input[i];
                }
                paddedInput[input.Length] = 0x80;

                for (int i = 1; i < bytesToPad -2; i++)
                {
                    paddedInput[input.Length + i] = 0;
                }
                paddedInput[paddedInput.Length - 2] = GetByte((64 - bytesToPad) * 8, 1);
                paddedInput[paddedInput.Length - 1] = GetByte((64 - bytesToPad) * 8, 0);
            }

            //Input is padded to 512bit size blocks
            
            uint[] result = new uint[paddedInput.Length / 4];
            for(int i = 0; i<paddedInput.Length; i+=4)
            {
                uint temp = 0;
                temp += paddedInput[i];
                temp = temp << 8;

                temp += paddedInput[i + 1];
                temp = temp << 8;

                temp += paddedInput[i + 2];
                temp = temp << 8;

                temp += paddedInput[i + 3];
                result[i / 4] = temp;
            }
            return result;
        }

        public static byte GetByte(uint x, int n)
        {
            return (byte)((x >> 8 * n) & 0xFF);
        }

        public static uint Shift(int bits, uint word)
        {
            return (word << bits | word >> (32 - bits));
        }

        protected virtual void TransformBlock(byte[] a_data)
        {
            uint[] data = PadInput(a_data);
            uint[] resultHash = new uint[80];

            uint A = H[0];
            uint B = H[1];
            uint C = H[2];
            uint D = H[3];
            uint E = H[4];

            uint temp = 0;
            int t = 0;

            for(t = 0; t < 16; t++)
            {
                resultHash[t] = data[t];
            }

        }
    }
}
