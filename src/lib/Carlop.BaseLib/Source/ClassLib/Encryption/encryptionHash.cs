namespace Carlop.ClassLib.Encryption
{
    using System;
    using System.IO;
    using System.Security.Cryptography;

    public class Hash
    {
        private Hash()
        {
            this._HashValue = new Data();
        }

        public Hash(Carlop.ClassLib.Encryption.Hash.Provider p)
        {
            this._HashValue = new Data();
            switch (((int) p))
            {
                case 0:
                {
                    this._Hash = new CRC32();
                    return;
                }
                case 1:
                {
                    this._Hash = new SHA1Managed();
                    return;
                }
                case 2:
                {
                    this._Hash = new SHA256Managed();
                    return;
                }
                case 3:
                {
                    this._Hash = new SHA384Managed();
                    return;
                }
                case 4:
                {
                    this._Hash = new SHA512Managed();
                    return;
                }
                case 5:
                {
                    this._Hash = new MD5CryptoServiceProvider();
                    return;
                }
            }
        }

        public Data Calculate(ref Stream s)
        {
            this._HashValue.Bytes = this._Hash.ComputeHash(s);
            return this._HashValue;
        }

        /// <summary>
        /// Calculates hash for fixed length <see cref="T:vbTests.Encryption.Data" />
        /// </summary>
        public Data Calculate(Data d)
        {
            return this.CalculatePrivate(d.Bytes);
        }

        public Data Calculate(Data d, Data salt)
        {
            byte[] buffer1 = new byte[((d.Bytes.Length + salt.Bytes.Length) - 1) + 1];
            salt.Bytes.CopyTo(buffer1, 0);
            d.Bytes.CopyTo(buffer1, salt.Bytes.Length);
            return this.CalculatePrivate(buffer1);
        }

        /// <summary>
        /// Calculates hash for an array of bytes
        /// </summary>
        private Data CalculatePrivate(byte[] b)
        {
            this._HashValue.Bytes = this._Hash.ComputeHash(b);
            return this._HashValue;
        }


        /// <summary>
        /// Returns the previously calculated hash
        /// </summary>
        public Data Value
        {
            get
            {
                return this._HashValue;
            }
        }


        private HashAlgorithm _Hash;
        private Data _HashValue;


        private class CRC32 : HashAlgorithm
        {
            public CRC32()
            {
                this.result = -1;
                this.crcLookup = new int[] { 
                    0, 0x77073096, -301047508, -1727442502, 0x76dc419, 0x706af48f, -379345611, -1637575261, 0xedb8832, 0x79dcb8a4, -522852066, -1747789432, 0x9b64c2b, 0x7eb17cbd, -407360249, -1866523247, 
                    0x1db71064, 0x6ab020f2, -205950648, -2067906082, 0x1adad47d, 0x6ddde4eb, -187386543, -2083289657, 0x136c9856, 0x646ba8c0, -43845254, -1973040660, 0x14015c4f, 0x63066cd9, -99664541, -1928851979, 
                    0x3b6e20c8, 0x4c69105e, -715111964, -1570279054, 0x3c03e4d1, 0x4b04d447, -770865667, -1526024853, 0x35b5a8fa, 0x42b2986c, -608450090, -1396901568, 0x32d86ce3, 0x45df5c75, -589951537, -1412350631, 
                    0x26d930ac, 0x51de003a, -925412992, -1076862698, 0x21b4f4b5, 0x56b3c423, -809855591, -1195530993, 0x2802b89e, 0x5f058808, -972236366, -1324619484, 0x2f6f7c87, 0x58684c11, -1050600021, -1234817731, 
                    0x76dc4190, 0x1db7106, -1731059524, -271249366, 0x71b18589, 0x6b6b51f, -1614814043, -390540237, 0x7807c9a2, 0xf00f934, -1777751922, -519137256, 0x7f6a0dbb, 0x86d3d2d, -1855689577, -429695999, 
                    0x6b6b51f4, 0x1c6c6162, -2056965928, -228458418, 0x6c0695ed, 0x1b01a57b, -2113342271, -183516073, 0x65b0d9c6, 0x12b7e950, -1950435094, -54949764, 0x62dd1ddf, 0x15da2d49, -1932296973, -69972891, 
                    0x4db26158, 0x3ab551ce, -1547960204, -725929758, 0x4adfa541, 0x3dd895d7, -1529756563, -740887301, 0x4369e96a, 0x346ed9fc, -1385723834, -631195440, 0x44042d73, 0x33031de5, -1442165665, -586318647, 
                    0x5005713c, 0x270241aa, -1106571248, -921952122, 0x5768b525, 0x206f85b3, -1184443383, -832445281, 0x5edef90e, 0x29d9c998, -1328506846, -942167884, 0x59b33d17, 0x2eb40d81, -1212326853, -1061524307, 
                    -306674912, -1698712650, 0x3b6e20c, 0x74b1d29a, -355121351, -1647151185, 0x4db2615, 0x73dc1683, -480048366, -1805370492, 0xd6d6a3e, 0x7a6a5aa8, -468791541, -1828061283, 0xa00ae27, 0x7d079eb1, 
                    -267414716, -2029476910, 0x1e01f268, 0x6906c2fe, -144550051, -2140837941, 0x196c3671, 0x6e6b06e7, -19653770, -1982649376, 0x10da7a5a, 0x67dd4acc, -105259153, -1900089351, 0x17b7be43, 0x60b08ed5, 
                    -690576408, -1580100738, 0x38d8c2c4, 0x4fdff252, -776247311, -1497606297, 0x3fb506dd, 0x48b2364b, -670225446, -1358292148, 0x36034af6, 0x41047a60, -547295293, -1469587627, 0x316e8eef, 0x4669be79, 
                    -882789492, -1134132454, 0x256fd2a0, 0x5268e236, -871598187, -1156888829, 0x220216b9, 0x5505262f, -977650754, -1296233688, 0x2bb45a92, 0x5cb36a04, -1026031705, -1244606671, 0x2cd99e8b, 0x5bdeae1d, 
                    -1687895376, -328994266, 0x756aa39c, 0x26d930a, -1677130071, -351390145, 0x72076785, 0x5005713, -1782625662, -491226604, 0x7bb12bae, 0xcb61b38, -1831694693, -438977011, 0x7cdcefb7, 0xbdbdf21, 
                    -2032938284, -237706686, 0x68ddb3f8, 0x1fda836e, -2118248755, -155638181, 0x6fb077e1, 0x18b74777, -2012718362, -15766928, 0x66063bca, 0x11010b5c, -1889165569, -127750551, 0x616bffd3, 0x166ccf45, 
                    -1609899400, -686959890, 0x4e048354, 0x3903b3c2, -1486412191, -799009033, 0x4969474d, 0x3e6e77db, -1362007478, -640263460, 0x40df0b66, 0x37d83bf0, -1447252397, -558129467, 0x47b2cf7f, 0x30b5ffe9, 
                    -1111625188, -893730166, 0x53b39330, 0x24b4a3a6, -1160759803, -841546093, 0x54de5729, 0x23d967bf, -1285129682, -1000256840, 0x5d681b02, 0x2a6f2b94, -1274298825, -1022587231, 0x5a05df1b, 0x2d02ef8d
                 };
            }

            protected override void HashCore(byte[] array, int ibStart, int cbSize)
            {
                int num3 = cbSize - 1;
                for (int num2 = ibStart; num2 <= num3; num2++)
                {
                    int num1 = (this.result & 0xff) ^ array[num2];
                    this.result = ((this.result & -256) / 0x100) & 0xffffff;
                    this.result ^= this.crcLookup[num1];
                }
            }

            protected override byte[] HashFinal()
            {
                byte[] buffer1 = BitConverter.GetBytes(~this.result);
                Array.Reverse(buffer1);
                return buffer1;
            }

            public override void Initialize()
            {
                this.result = -1;
            }


            public override byte[] Hash
            {
                get
                {
                    byte[] buffer1 = BitConverter.GetBytes(~this.result);
                    Array.Reverse(buffer1);
                    return buffer1;
                }
            }


            private int[] crcLookup;
            private int result;
        }

        /// <summary>
        /// Type of hash; some are security oriented, others are fast and simple
        /// </summary>
        public enum Provider
        {
            CRC32,
            SHA1,
            SHA256,
            SHA384,
            SHA512,
            MD5
        }
    }
}

