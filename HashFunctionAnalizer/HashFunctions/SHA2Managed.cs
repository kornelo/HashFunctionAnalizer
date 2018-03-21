using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashFunctionAnalizer.HashFunctions
{
    class SHA2Managed: SHA2
    {
        /// <summary>
        /// 
        /// </summary>
        public SHA2Managed()
			: base(256) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hashBitLength"></param>
        public SHA2Managed(int hashBitLength)
			: base(hashBitLength) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="ibStart"></param>
        /// <param name="cbSize"></param>
        protected override void HashCore(byte[] array, int ibStart, int cbSize)
        {
            base.HashCore(array, ibStart, cbSize);
            if (cbSize == 0)
                return;
            int sizeInBytes = array.Length;
            if (buffer == null)
                buffer = new byte[sizeInBytes];
            int stride = sizeInBytes;
            ulong[] utemps = new ulong[stride];
            if (buffLength == sizeInBytes)
                throw new Exception("Unexpected error, the internal buffer is full");
            AddToBuffer(array, ref ibStart, ref cbSize);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override byte[] HashFinal()
        {
            int sizeInBytes = SizeInBytes;
            byte[] outb = new byte[HashByteLength];

            int stride = sizeInBytes;
            if (HashSizeValue == 224 || HashSizeValue == 256)
            {
                uint[] utemps = new uint[stride];
                utemps = PadInput_32(buffer);
                TransformBlock32(utemps, Rounds);
                Buffer.BlockCopy(state_32, 0, outb, 0, HashByteLength);
            }
            else
            {
                ulong[] utemps = new ulong[stride];
                utemps = PadInput_64(buffer);
                TransformBlock64(utemps, Rounds);
                Buffer.BlockCopy(state_64, 0, outb, 0, HashByteLength);
            }

                return outb;
        }

        private uint[] PadInput_32(byte[] input)
        {
            uint bytesToPad;

                bytesToPad = Convert.ToUInt32((64 - (input.Length % 64)) % 64);
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

                    paddedInput[paddedInput.Length - 2] = GetByte32((64 - bytesToPad) * 8, 1);
                    paddedInput[paddedInput.Length - 1] = GetByte32((64 - bytesToPad) * 8, 0);
            }

            uint[] result;

            //Input is padded to 512bit size blocks
                result = new uint[paddedInput.Length / 4];
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

                    result[i / 4] = temp;
                }
           
            return result;
        }

        private ulong[] PadInput_64(byte[] input)
        {
            uint bytesToPad;

            if (HashSizeValue == 224 || HashSizeValue == 256)
            {
                bytesToPad = Convert.ToUInt32((64 - (input.Length % 64)) % 64);
                if (input.Length == 0) bytesToPad = 64;

            }
            else
            {
                bytesToPad = Convert.ToUInt32((128 - (input.Length % 128)) % 128);
                if (input.Length == 0) bytesToPad = 128;
            }

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

                if (HashSizeValue == 224 || HashSizeValue == 256)
                {
                    paddedInput[paddedInput.Length - 2] = GetByte32((64 - bytesToPad) * 8, 1);
                    paddedInput[paddedInput.Length - 1] = GetByte32((64 - bytesToPad) * 8, 0);
                }
                else
                {
                    paddedInput[paddedInput.Length - 2] = GetByte64((128 - bytesToPad) * 8, 1);
                    paddedInput[paddedInput.Length - 1] = GetByte64((128 - bytesToPad) * 8, 0);
                }
            }

            ulong[] result;

            //Input is padded to 512bit size blocks
            if (HashSizeValue == 224 || HashSizeValue == 256)
            {
                result = new ulong[paddedInput.Length / 4];
                for (var i = 0; i < paddedInput.Length; i += 4)
                {
                    ulong temp = 0;
                    temp += paddedInput[i];
                    temp = temp << 8;

                    temp += paddedInput[i + 1];
                    temp = temp << 8;

                    temp += paddedInput[i + 2];
                    temp = temp << 8;

                    temp += paddedInput[i + 3];

                    result[i / 4] = temp;
                }
            }
            else
            {
                //Input is padded to 1024bit size blocks

                result = new ulong[paddedInput.Length / 8];
                for (var i = 0; i < paddedInput.Length; i += 8)
                {
                    ulong temp = 0;
                    temp += paddedInput[i];
                    temp = temp << 8;

                    temp += paddedInput[i + 1];
                    temp = temp << 8;

                    temp += paddedInput[i + 2];
                    temp = temp << 8;

                    temp += paddedInput[i + 3];
                    temp = temp << 8;

                    temp += paddedInput[i + 4];
                    temp = temp << 8;

                    temp += paddedInput[i + 5];
                    temp = temp << 8;

                    temp += paddedInput[i + 6];
                    temp = temp << 8;

                    temp += paddedInput[i + 7];
                    result[i / 8] = temp;
                }
            }
            return result;
        }


        private void TransformBlock64(ulong[] inb, int rounds)
        {
             state_64 = RoundConstants_64;
            
            var resultHash = new ulong[rounds];

            int t;

            for (t = 0; t < 16; t++)
            {
                resultHash[t] = inb[t];
            }

            for (t = 16; t < rounds; t++)
            {

                    resultHash[t] = (Ssig164(resultHash[t - 2]) + resultHash[t - 7] + Ssig064(resultHash[t - 15]) +
                                    resultHash[t - 16]) % 0xffffffffffffffff;
            }

            var a = state_64[0];
            var b = state_64[1];
            var c = state_64[2];
            var d = state_64[3];
            var e = state_64[4];
            var f = state_64[5];
            var g = state_64[6];
            var h = state_64[7];

            ulong tmp1, tmp2;

            for (t = 0; t < rounds; t++)
            {
               
                    tmp1 = h + Bsig164(e) + Ch64(e, f, g) + K_64[t] + resultHash[t];
                    tmp2 = Bsig064(a) + Maj64(a, b, c);
              
                h = g;
                g = f;
                f = e;
                e = d + tmp1;
                d = c;
                c = b;
                b = a;
                a = tmp1 + tmp2;
            }

            state_64[0] = a + state_64[0];
            state_64[1] = b + state_64[1];
            state_64[2] = c + state_64[2];
            state_64[3] = d + state_64[3];
            state_64[4] = e + state_64[4];
            state_64[5] = f + state_64[5];
            state_64[6] = g + state_64[6];
            state_64[7] = h + state_64[7];

        }

        private void TransformBlock32(uint[] inb, int rounds)
        {
            state_32 = RoundConstants_32;

            var resultHash = new uint[rounds];

            int t;

            for (t = 0; t < 16; t++)
            {
                resultHash[t] = inb[t];
            }

            for (t = 16; t < rounds; t++)
            {

                resultHash[t] = (Ssig132(resultHash[t - 2]) + resultHash[t - 7] + Ssig032(resultHash[t - 15]) +
                                resultHash[t - 16]);
            }

            var a = state_32[0];
            var b = state_32[1];
            var c = state_32[2];
            var d = state_32[3];
            var e = state_32[4];
            var f = state_32[5];
            var g = state_32[6];
            var h = state_32[7];

            uint tmp1, tmp2;

            for (t = 0; t < rounds; t++)
            {

                tmp1 = h + Bsig132(e) + Ch32(e, f, g) + K_32[t] + resultHash[t];
                tmp2 = Bsig032(a) + Maj32(a, b, c);

                h = g;
                g = f;
                f = e;
                e = d + tmp1;
                d = c;
                c = b;
                b = a;
                a = tmp1 + tmp2;
            }

            state_32[0] = a + state_32[0];
            state_32[1] = b + state_32[1];
            state_32[2] = c + state_32[2];
            state_32[3] = d + state_32[3];
            state_32[4] = e + state_32[4];
            state_32[5] = f + state_32[5];
            state_32[6] = g + state_32[6];
            state_32[7] = h + state_32[7];

        }
    }
}
