using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HashFunctionAnalizer.HashFunctions
{
    public abstract class SHA2 : HashAlgorithm
    {
        protected SHA2() {
            base.HashSizeValue = 256;
        }

        protected SHA2(int hashBitLength) {
            if (hashBitLength != 224 && hashBitLength != 256 && hashBitLength != 384 && hashBitLength != 512)
                throw new ArgumentException("hashBitLength must be 224, 256, 384, or 512", "hashBitLength");
            Initialize();
            HashSizeValue = hashBitLength;
            switch (hashBitLength)
            {
                case 224:
                    Rounds = 64;
                    K_32 = new uint[]
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
                    RoundConstants_32 = new uint[]
                    {
                     0xc1059ed8, 0x367cd507,
                     0x3070dd17, 0xf70e5939,
                     0xffc00b31, 0x68581511,
                     0x64f98fa7, 0xbefa4fa4
                    };
                    break;
                case 256:
                    Rounds = 64;
                    K_32 = new uint[]
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
                    RoundConstants_32 = new uint[]
                    {
                     0x6a09e667, 0xbb67ae85,
                     0x3c6ef372, 0xa54ff53a,
                     0x510e527f, 0x9b05688c,
                     0x1f83d9ab, 0x5be0cd19
                    };
                    break;
                case 384:
                    Rounds = 80;
                    K_64 = new ulong[]
                    {
                    0x428a2f98d728ae22, 0x7137449123ef65cd, 0xb5c0fbcfec4d3b2f, 0xe9b5dba58189dbbc,
                    0x3956c25bf348b538, 0x59f111f1b605d019, 0x923f82a4af194f9b, 0xab1c5ed5da6d8118,
                    0xd807aa98a3030242, 0x12835b0145706fbe, 0x243185be4ee4b28c, 0x550c7dc3d5ffb4e2,
                    0x72be5d74f27b896f, 0x80deb1fe3b1696b1, 0x9bdc06a725c71235, 0xc19bf174cf692694,
                    0xe49b69c19ef14ad2, 0xefbe4786384f25e3, 0x0fc19dc68b8cd5b5, 0x240ca1cc77ac9c65,
                    0x2de92c6f592b0275, 0x4a7484aa6ea6e483, 0x5cb0a9dcbd41fbd4, 0x76f988da831153b5,
                    0x983e5152ee66dfab, 0xa831c66d2db43210, 0xb00327c898fb213f, 0xbf597fc7beef0ee4,
                    0xc6e00bf33da88fc2, 0xd5a79147930aa725, 0x06ca6351e003826f, 0x142929670a0e6e70,
                    0x27b70a8546d22ffc, 0x2e1b21385c26c926, 0x4d2c6dfc5ac42aed, 0x53380d139d95b3df,
                    0x650a73548baf63de, 0x766a0abb3c77b2a8, 0x81c2c92e47edaee6, 0x92722c851482353b,
                    0xa2bfe8a14cf10364, 0xa81a664bbc423001, 0xc24b8b70d0f89791, 0xc76c51a30654be30,
                    0xd192e819d6ef5218, 0xd69906245565a910, 0xf40e35855771202a, 0x106aa07032bbd1b8,
                    0x19a4c116b8d2d0c8, 0x1e376c085141ab53, 0x2748774cdf8eeb99, 0x34b0bcb5e19b48a8,
                    0x391c0cb3c5c95a63, 0x4ed8aa4ae3418acb, 0x5b9cca4f7763e373, 0x682e6ff3d6b2b8a3,
                    0x748f82ee5defb2fc, 0x78a5636f43172f60, 0x84c87814a1f0ab72, 0x8cc702081a6439ec,
                    0x90befffa23631e28, 0xa4506cebde82bde9, 0xbef9a3f7b2c67915, 0xc67178f2e372532b,
                    0xca273eceea26619c, 0xd186b8c721c0c207, 0xeada7dd6cde0eb1e, 0xf57d4f7fee6ed178,
                    0x06f067aa72176fba, 0x0a637dc5a2c898a6, 0x113f9804bef90dae, 0x1b710b35131c471b,
                    0x28db77f523047d84, 0x32caab7b40c72493, 0x3c9ebe0a15c9bebc, 0x431d67c49c100d4c,
                    0x4cc5d4becb3e42b6, 0x597f299cfc657e2a, 0x5fcb6fab3ad6faec, 0x6c44198c4a475817
                    };
                    RoundConstants_64 = new ulong[]
                    {
                    0xcbbb9d5dc1059ed8,
                    0x629a292a367cd507,
                    0x9159015a3070dd17,
                    0x152fecd8f70e5939,
                    0x67332667ffc00b31,
                    0x8eb44a8768581511,
                    0xdb0c2e0d64f98fa7,
                    0x47b5481dbefa4fa4
                    };
                    break;
                case 512:
                    Rounds = 80;
                    K_64 = new ulong[]
                    {
                    0x428a2f98d728ae22, 0x7137449123ef65cd, 0xb5c0fbcfec4d3b2f, 0xe9b5dba58189dbbc,
                    0x3956c25bf348b538, 0x59f111f1b605d019, 0x923f82a4af194f9b, 0xab1c5ed5da6d8118,
                    0xd807aa98a3030242, 0x12835b0145706fbe, 0x243185be4ee4b28c, 0x550c7dc3d5ffb4e2,
                    0x72be5d74f27b896f, 0x80deb1fe3b1696b1, 0x9bdc06a725c71235, 0xc19bf174cf692694,
                    0xe49b69c19ef14ad2, 0xefbe4786384f25e3, 0x0fc19dc68b8cd5b5, 0x240ca1cc77ac9c65,
                    0x2de92c6f592b0275, 0x4a7484aa6ea6e483, 0x5cb0a9dcbd41fbd4, 0x76f988da831153b5,
                    0x983e5152ee66dfab, 0xa831c66d2db43210, 0xb00327c898fb213f, 0xbf597fc7beef0ee4,
                    0xc6e00bf33da88fc2, 0xd5a79147930aa725, 0x06ca6351e003826f, 0x142929670a0e6e70,
                    0x27b70a8546d22ffc, 0x2e1b21385c26c926, 0x4d2c6dfc5ac42aed, 0x53380d139d95b3df,
                    0x650a73548baf63de, 0x766a0abb3c77b2a8, 0x81c2c92e47edaee6, 0x92722c851482353b,
                    0xa2bfe8a14cf10364, 0xa81a664bbc423001, 0xc24b8b70d0f89791, 0xc76c51a30654be30,
                    0xd192e819d6ef5218, 0xd69906245565a910, 0xf40e35855771202a, 0x106aa07032bbd1b8,
                    0x19a4c116b8d2d0c8, 0x1e376c085141ab53, 0x2748774cdf8eeb99, 0x34b0bcb5e19b48a8,
                    0x391c0cb3c5c95a63, 0x4ed8aa4ae3418acb, 0x5b9cca4f7763e373, 0x682e6ff3d6b2b8a3,
                    0x748f82ee5defb2fc, 0x78a5636f43172f60, 0x84c87814a1f0ab72, 0x8cc702081a6439ec,
                    0x90befffa23631e28, 0xa4506cebde82bde9, 0xbef9a3f7b2c67915, 0xc67178f2e372532b,
                    0xca273eceea26619c, 0xd186b8c721c0c207, 0xeada7dd6cde0eb1e, 0xf57d4f7fee6ed178,
                    0x06f067aa72176fba, 0x0a637dc5a2c898a6, 0x113f9804bef90dae, 0x1b710b35131c471b,
                    0x28db77f523047d84, 0x32caab7b40c72493, 0x3c9ebe0a15c9bebc, 0x431d67c49c100d4c,
                    0x4cc5d4becb3e42b6, 0x597f299cfc657e2a, 0x5fcb6fab3ad6faec, 0x6c44198c4a475817
                   };
                    RoundConstants_64 = new ulong[]
                    {
                    0x6a09e667f3bcc908,
                    0xbb67ae8584caa73b,
                    0x3c6ef372fe94f82b,
                    0xa54ff53a5f1d36f1,
                    0x510e527fade682d1,
                    0x9b05688c2b3e6c1f,
                    0x1f83d9abfb41bd6b,
                    0x5be0cd19137e2179,
                    };
                    break;
            }

        }

        /// <summary>Creates an instance of the default implementation of <see cref="T:System.Security.Cryptography.SHA2" />.</summary>
        /// <returns>A new instance of <see cref="T:System.Security.Cryptography.SHA2" />.</returns>
        /// <exception cref="T:System.Reflection.TargetInvocationException">The algorithm was used with Federal Information Processing Standards (FIPS) mode enabled, but is not FIPS compatible.</exception>
        /// <PermissionSet>
        /// <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode" />
        /// </PermissionSet>
        public static new SHA2 Create()
        {
            return Create("System.Security.Cryptography.SHA2");
        }

        /// <summary>Creates an instance of a specified implementation of <see cref="T:System.Security.Cryptography.SHA3" />.</summary>
        /// <returns>A new instance of <see cref="T:System.Security.Cryptography.SHA3" /> using the specified implementation.</returns>
        /// <param name="hashName">The name of the specific implementation of <see cref="T:System.Security.Cryptography.SHA3" /> to be used. </param>
        /// <exception cref="T:System.Reflection.TargetInvocationException">The algorithm described by the <paramref name="hashName" /> parameter was used with Federal Information Processing Standards (FIPS) mode enabled, but is not FIPS compatible.</exception>
        public static new SHA2 Create(string hashName)
        {
            return (SHA2)CryptoConfig.CreateFromName(hashName);
        }

        #region " Hash Algorithm Members "
        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="ibStart"></param>
        /// <param name="cbSize"></param>
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
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override byte[] HashFinal()
        {
            return this.Hash;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Initialize()
        {
            buffLength = 0;
            if (HashSizeValue == 224 || HashSizeValue == 256)
                state_32 = new uint[8];
            else state_64 = new ulong[8];
            HashValue = null;
        }
        #endregion

        #region Implementation
        internal readonly ulong[] RoundConstants_64;
        internal readonly uint[] RoundConstants_32;
        internal readonly ulong[] K_64;
        internal readonly uint[] K_32;
        internal ulong[] state_64;
        internal uint[] state_32;
        internal byte[] buffer;
        internal int buffLength;
        //protected new byte[] HashValue;
        //protected new int HashSizeValue;
        internal int rounds;

        internal int Rounds
        {
            get { return rounds;}
            set { rounds = value;}
        }

        /// <summary>
        /// 
        /// </summary>
        public int SizeInBytes
        {
            get
            {
                return rounds / 8;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int HashByteLength
        {
            get
            {
                return HashSizeValue / 8;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override bool CanReuseTransform
        {
            get
            {
                return true;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        protected void AddToBuffer(byte[] array, ref int offset, ref int count)
        {
            int amount = Math.Min(count, buffer.Length - buffLength);
            Buffer.BlockCopy(array, offset, buffer, buffLength, amount);
            offset += amount;
            buffLength += amount;
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

        /// <summary>
        /// 
        /// </summary>
        public override int HashSize
        {
            get
            {
                return HashSizeValue;
            }
        }
        #endregion
        protected byte GetByte64(ulong x, int n)
        {
            return (byte)((x >> 8 * n) & 0xFF);
        }

        protected byte GetByte32(uint x, int n)
        {
            return (byte)((x >> 8 * n) & 0xFF);
        }

        protected uint Shr32(int bit, uint x)
        {
            return x >> bit;
        }
         
        protected ulong Shr64(int bit, ulong x)
        {
            return x >> bit;
        }

        private static uint Rotr32(int bit, uint x)
        {
            return (x >> bit) | (x << (32 - bit));
        }

        private static uint Rotl32(int bit, uint x)
        {
            return (x << bit) | (x >> 32 - bit);
        }

        protected ulong Rotr64(int bit, ulong x)
        {
            return (x >> bit) | (x << (64 - bit));
        }

        protected ulong Rotl64(int bit, ulong x)
        {
            return (x << bit) | (x >> 64 - bit);
        }

        protected uint Ch32(uint x, uint y, uint z)
        {
            return (x & y) ^ ((x ^ 0xffffffff) & z);
        }

        protected ulong Ch64(ulong x, ulong y, ulong z)
        {
            return ((x & y) ^ ((x ^ 0xffffffffffffffff) & z)) % 0xffffffffffffffff;
        }

        protected uint Maj32(uint x, uint y, uint z)
        {
            return (x & y) ^ (x & z) ^ (y & z);
        }

        protected ulong Maj64(ulong x, ulong y, ulong z)
        {
            return (x & y) ^ (x & z) ^ (y & z);
        }

        protected uint Bsig032(uint x)
        {
            return Rotr32(2, x) ^ Rotr32(13, x) ^ Rotr32(22, x);
        }

        protected uint Bsig132(uint x)
        {
            return Rotr32(6, x) ^ Rotr32(11, x) ^ Rotr32(25, x);
        }

        protected uint Ssig032(uint x)
        {
            return Rotr32(7, x) ^ Rotr32(18, x) ^ Shr32(3, x);
        }

        protected uint Ssig132(uint x)
        {
            return Rotr32(17, x) ^ Rotr32(19, x) ^ Shr32(10, x);
        }

        protected ulong Bsig064(ulong x)
        {
            return Rotr64(28, x) ^ Rotr64(34, x) ^ Rotr64(39, x);
        }

        protected ulong Bsig164(ulong x)
        {
            return Rotr64(14, x) ^ Rotr64(18, x) ^ Rotr64(41, x);
        }

        protected ulong Ssig064(ulong x)
        {
            return Rotr64(1, x) ^ Rotr64(8, x) ^ Shr64(7, x);
        }

        protected ulong Ssig164(ulong x)
        {
            return Rotr64(19, x) ^ Rotr64(61, x) ^ Shr64(6, x);
        }

    }
}
