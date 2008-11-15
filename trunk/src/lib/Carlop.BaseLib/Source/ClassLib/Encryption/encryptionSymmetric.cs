namespace Carlop.ClassLib.Encryption
{
    //using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Security.Cryptography;

    public class Symmetric
    {
        private Symmetric()
        {
        }

        /// <summary>
        /// Instantiates a new symmetric encryption object using the specified provider.
        /// </summary>
        public Symmetric(Carlop.ClassLib.Encryption.Symmetric.Provider provider, [Optional] bool useDefaultInitializationVector /* = true */)
        {
            switch (((int) provider))
            {
                case 0:
                {
                    this._crypto = new DESCryptoServiceProvider();
                    break;
                }
                case 1:
                {
                    this._crypto = new RC2CryptoServiceProvider();
                    break;
                }
                case 2:
                {
                    this._crypto = new RijndaelManaged();
                    break;
                }
                case 3:
                {
                    this._crypto = new TripleDESCryptoServiceProvider();
                    break;
                }
            }
            this.Key = this.RandomKey();
            if (useDefaultInitializationVector)
            {
                this.IntializationVector = new Data("%1Az=-@qT");
            }
            else
            {
                this.IntializationVector = this.RandomInitializationVector();
            }
        }

        public Data Decrypt(Stream encryptedStream)
        {
            MemoryStream stream2 = new MemoryStream();
            byte[] buffer1 = new byte[0x801];
            this.ValidateKeyAndIv(false);
            CryptoStream stream1 = new CryptoStream(encryptedStream, this._crypto.CreateDecryptor(), CryptoStreamMode.Read);
            for (int num1 = stream1.Read(buffer1, 0, 0x800); num1 > 0; num1 = stream1.Read(buffer1, 0, 0x800))
            {
                stream2.Write(buffer1, 0, num1);
            }
            stream1.Close();
            stream2.Close();
            return new Data(stream2.ToArray());
        }

        /// <summary>
        /// Decrypts the specified data using preset key and preset initialization vector
        /// </summary>
        public Data Decrypt(Data encryptedData)
        {
            MemoryStream stream2 = new MemoryStream(encryptedData.Bytes, 0, encryptedData.Bytes.Length);
            byte[] buffer1 = new byte[(encryptedData.Bytes.Length - 1) + 1];
            this.ValidateKeyAndIv(false);
            CryptoStream stream1 = new CryptoStream(stream2, this._crypto.CreateDecryptor(), CryptoStreamMode.Read);
            try
            {
                stream1.Read(buffer1, 0, encryptedData.Bytes.Length - 1);
            }
            catch (CryptographicException exception2)
            {
                throw new CryptographicException("Unable to decrypt data. The provided key may be invalid.", exception2);
            }
            finally
            {
                stream1.Close();
            }
            return new Data(buffer1);
        }

        /// <summary>
        /// Decrypts the specified stream using provided key and preset initialization vector
        /// </summary>
        public Data Decrypt(Stream encryptedStream, Data key)
        {
            this.Key = key;
            return this.Decrypt(encryptedStream);
        }

        public Data Decrypt(Data encryptedData, Data key)
        {
            this.Key = key;
            return this.Decrypt(encryptedData);
        }

        /// <summary>
        /// Encrypts the specified stream to memory using preset key and preset initialization vector
        /// </summary>
        public Data Encrypt(Stream s)
        {
            MemoryStream stream2 = new MemoryStream();
            byte[] buffer1 = new byte[0x801];
            this.ValidateKeyAndIv(true);
            CryptoStream stream1 = new CryptoStream(stream2, this._crypto.CreateEncryptor(), CryptoStreamMode.Write);
            for (int num1 = s.Read(buffer1, 0, 0x800); num1 > 0; num1 = s.Read(buffer1, 0, 0x800))
            {
                stream1.Write(buffer1, 0, num1);
            }
            stream1.Close();
            stream2.Close();
            return new Data(stream2.ToArray());
        }

        public Data Encrypt(Data d)
        {
            MemoryStream stream2 = new MemoryStream();
            this.ValidateKeyAndIv(true);
            CryptoStream stream1 = new CryptoStream(stream2, this._crypto.CreateEncryptor(), CryptoStreamMode.Write);
            stream1.Write(d.Bytes, 0, d.Bytes.Length);
            stream1.Close();
            stream2.Close();
            return new Data(stream2.ToArray());
        }

        public Data Encrypt(Stream s, Data key)
        {
            this.Key = key;
            return this.Encrypt(s);
        }

        /// <summary>
        /// Encrypts the specified Data using provided key
        /// </summary>
        public Data Encrypt(Data d, Data key)
        {
            this.Key = key;
            return this.Encrypt(d);
        }

        /// <summary>
        /// Encrypts the stream to memory using provided key and provided initialization vector
        /// </summary>
        public Data Encrypt(Stream s, Data key, Data iv)
        {
            this.IntializationVector = iv;
            this.Key = key;
            return this.Encrypt(s);
        }

        public Data RandomInitializationVector()
        {
            this._crypto.GenerateIV();
            return new Data(this._crypto.IV);
        }

        /// <summary>
        /// generates a random Key, if one was not provided
        /// </summary>
        public Data RandomKey()
        {
            this._crypto.GenerateKey();
            return new Data(this._crypto.Key);
        }

        private void ValidateKeyAndIv(bool isEncrypting)
        {
            if (this._key.IsEmpty)
            {
                if (!isEncrypting)
                {
                    throw new CryptographicException("No key was provided for the decryption operation!");
                }
                this._key = this.RandomKey();
            }
            if (this._iv.IsEmpty)
            {
                if (!isEncrypting)
                {
                    throw new CryptographicException("No initialization vector was provided for the decryption operation!");
                }
                this._iv = this.RandomInitializationVector();
            }
            this._crypto.Key = this._key.Bytes;
            this._crypto.IV = this._iv.Bytes;
        }


        /// <summary>
        /// Using the default Cipher Block Chaining (CBC) mode, all data blocks are processed using
        /// the value derived from the previous block; the first data block has no previous data block
        /// to use, so it needs an InitializationVector to feed the first block
        /// </summary>
        public Data IntializationVector
        {
            get
            {
                return this._iv;
            }
            set
            {
                this._iv = value;
                this._iv.MaxBytes = this._crypto.BlockSize / 8;
                this._iv.MinBytes = this._crypto.BlockSize / 8;
            }
        }

        public Data Key
        {
            get
            {
                return this._key;
            }
            set
            {
                this._key = value;
                this._key.MaxBytes = this._crypto.LegalKeySizes[0].MaxSize / 8;
                this._key.MinBytes = this._crypto.LegalKeySizes[0].MinSize / 8;
                this._key.StepBytes = this._crypto.LegalKeySizes[0].SkipSize / 8;
            }
        }

        /// <summary>
        /// Key size in bits. We use the default key size for any given provider; if you
        /// want to force a specific key size, set this property
        /// </summary>
        public int KeySizeBits
        {
            get
            {
                return this._crypto.KeySize;
            }
            set
            {
                this._crypto.KeySize = value;
                this._key.MaxBits = value;
            }
        }

        public int KeySizeBytes
        {
            get
            {
                return (this._crypto.KeySize / 8);
            }
            set
            {
                this._crypto.KeySize = value * 8;
                this._key.MaxBytes = value;
            }
        }


        private const int _BufferSize = 0x800;
        private SymmetricAlgorithm _crypto;
        //private Data _data;
        private const string _DefaultIntializationVector = "%1Az=-@qT";
        //private byte[] _EncryptedBytes;
        private Data _iv;
        private Data _key;
        //private bool _UseDefaultInitializationVector;


        public enum Provider
        {
            DES,
            RC2,
            Rijndael,
            TripleDES
        }
    }
}

