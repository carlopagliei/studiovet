namespace Carlop.ClassLib.Encryption
{
    //using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.IO;
    using System.Security;
    using System.Security.Cryptography;
    using System.Security.Principal;
    using System.Text;

    /// <summary>
    /// Asymmetric encryption uses a pair of keys to encrypt and decrypt.
    /// There is a "public" key which is used to encrypt. Decrypting, on the other hand,
    /// requires both the "public" key and an additional "private" key. The advantage is
    /// that people can send you encrypted messages without being able to decrypt them.
    /// </summary>
    /// <remarks>
    /// The only provider supported is the <see cref="T:System.Security.Cryptography.RSACryptoServiceProvider" />
    /// </remarks>
    public class Asymmetric
    {
        /// <summary>
        /// Instantiates a new asymmetric encryption session using the default key size;
        /// this is usally 1024 bits
        /// </summary>
        public Asymmetric()
        {
            this._KeyContainerName = "Encryption.AsymmetricEncryption.DefaultContainerName";
            //this._UseMachineKeystore = true;
            this._KeySize = 0x400;
            this._rsa = this.GetRSAProvider();
        }

        public Asymmetric(int keySize)
        {
            this._KeyContainerName = "Encryption.AsymmetricEncryption.DefaultContainerName";
            //this._UseMachineKeystore = true;
            this._KeySize = 0x400;
            this._KeySize = keySize;
            this._rsa = this.GetRSAProvider();
        }

        /// <summary>
        /// Decrypts data using the default private key
        /// </summary>
        public Data Decrypt(Data encryptedData)
        {
            PrivateKey key1 = new PrivateKey();
            key1.LoadFromConfig();
            return this.Decrypt(encryptedData, key1);
        }

        /// <summary>
        /// Decrypts data using the provided private key as XML
        /// </summary>
        public Data Decrypt(Data encryptedData, string PrivateKeyXML)
        {
            this.LoadKeyXml(PrivateKeyXML, true);
            return this.DecryptPrivate(encryptedData);
        }

        public Data Decrypt(Data encryptedData, PrivateKey PrivateKey)
        {
            this._rsa.ImportParameters(PrivateKey.ToParameters());
            return this.DecryptPrivate(encryptedData);
        }

        private Data DecryptPrivate(Data encryptedData)
        {
            return new Data(this._rsa.Decrypt(encryptedData.Bytes, false));
        }

        public Data Encrypt(Data d)
        {
            PublicKey key1 = this.DefaultPublicKey;
            return this.Encrypt(d, key1);
        }

        public Data Encrypt(Data d, string publicKeyXML)
        {
            this.LoadKeyXml(publicKeyXML, false);
            return this.EncryptPrivate(d);
        }

        /// <summary>
        /// Encrypts data using the provided public key
        /// </summary>
        public Data Encrypt(Data d, PublicKey publicKey)
        {
            this._rsa.ImportParameters(publicKey.ToParameters());
            return this.EncryptPrivate(d);
        }

        private Data EncryptPrivate(Data d)
        {
            Data data1;
            try
            {
                data1 = new Data(this._rsa.Encrypt(d.Bytes, false));
            }
            catch (CryptographicException exception2)
            {
                if (exception2.Message.ToLower().IndexOf("bad length") > -1)
                {
                    throw new CryptographicException("Your data is too large; RSA encryption is designed to encrypt relatively small amounts of data. The exact byte limit depends on the key size. To encrypt more data, use symmetric encryption and then encrypt that symmetric key with asymmetric RSA encryption.", exception2);
                }
                throw;
            }
            return data1;
        }

        /// <summary>
        /// Generates a new public/private key pair as XML strings
        /// </summary>
        public void GenerateNewKeyset(ref string publicKeyXML, ref string privateKeyXML)
        {
            RSA rsa1 = RSA.Create();
            publicKeyXML = rsa1.ToXmlString(false);
            privateKeyXML = rsa1.ToXmlString(true);
        }

        public void GenerateNewKeyset(ref PublicKey publicKey, ref PrivateKey privateKey)
        {
            string text1 = null;
            string text2 = null;
            this.GenerateNewKeyset(ref text2, ref text1);
            publicKey = new PublicKey(text2);
            privateKey = new PrivateKey(text1);
        }

        private RSACryptoServiceProvider GetRSAProvider()
        {
            CspParameters parameters1 = null;
            RSACryptoServiceProvider provider1 = null;
            RSACryptoServiceProvider provider2 = null;
            try
            {
                parameters1 = new CspParameters();
                parameters1.KeyContainerName = this._KeyContainerName;
                provider2 = new RSACryptoServiceProvider(this._KeySize, parameters1);
                provider2.PersistKeyInCsp = false;
                RSACryptoServiceProvider.UseMachineKeyStore = true;
                provider1 = provider2;
            }
            catch (CryptographicException exception2)
            {
                if (exception2.Message.ToLower().IndexOf("csp for this implementation could not be acquired") > -1)
                {
                    throw new Exception(@"Unable to obtain Cryptographic Service Provider. Either the permissions are incorrect on the 'C:\Documents and Settings\All Users\Application Data\Microsoft\Crypto\RSA\MachineKeys' folder, or the current security context '" + WindowsIdentity.GetCurrent().Name + "' does not have access to this folder.", exception2);
                }
                throw;
            }
            finally
            {
                if (provider2 != null)
                {
                    provider2 = null;
                }
                if (parameters1 != null)
                {
                    parameters1 = null;
                }
            }
            return provider1;
        }

        private void LoadKeyXml(string keyXml, bool isPrivate)
        {
            try
            {
                this._rsa.FromXmlString(keyXml);
            }
            catch (XmlSyntaxException exception2)
            {
                string text1;
                if (isPrivate)
                {
                    text1 = "private";
                }
                else
                {
                    text1 = "public";
                }
                throw new XmlSyntaxException(string.Format("The provided {0} encryption key XML does not appear to be valid.", text1), exception2);
            }
        }


        /// <summary>
        /// Returns the default private key as stored in the *.config file
        /// </summary>
        public PrivateKey DefaultPrivateKey
        {
            get
            {
                PrivateKey key2 = new PrivateKey();
                key2.LoadFromConfig();
                return key2;
            }
        }

        public PublicKey DefaultPublicKey
        {
            get
            {
                PublicKey key2 = new PublicKey();
                key2.LoadFromConfig();
                return key2;
            }
        }

        /// <summary>
        /// Sets the name of the key container used to store this key on disk; this is an
        /// unavoidable side effect of the underlying Microsoft CryptoAPI.
        /// </summary>
        /// <remarks>
        /// http://support.microsoft.com/default.aspx?scid=http://support.microsoft.com:80/support/kb/articles/q322/3/71.asp&amp;NoWebContent=1
        /// </remarks>
        public string KeyContainerName
        {
            get
            {
                return this._KeyContainerName;
            }
            set
            {
                this._KeyContainerName = value;
            }
        }

        public int KeySizeBits
        {
            get
            {
                return this._rsa.KeySize;
            }
        }

        /// <summary>
        /// Returns the maximum supported key size, in bits
        /// </summary>
        public int KeySizeMaxBits
        {
            get
            {
                return this._rsa.LegalKeySizes[0].MaxSize;
            }
        }

        public int KeySizeMinBits
        {
            get
            {
                return this._rsa.LegalKeySizes[0].MinSize;
            }
        }

        /// <summary>
        /// Returns valid key step sizes, in bits
        /// </summary>
        public int KeySizeStepBits
        {
            get
            {
                return this._rsa.LegalKeySizes[0].SkipSize;
            }
        }


        private const string _ElementCoefficient = "InverseQ";
        private const string _ElementExponent = "Exponent";
        private const string _ElementModulus = "Modulus";
        private const string _ElementParent = "RSAKeyValue";
        private const string _ElementPrimeExponentP = "DP";
        private const string _ElementPrimeExponentQ = "DQ";
        private const string _ElementPrimeP = "P";
        private const string _ElementPrimeQ = "Q";
        private const string _ElementPrivateExponent = "D";
        private const string _KeyCoefficient = "PrivateKey.InverseQ";
        private string _KeyContainerName;
        private const string _KeyExponent = "PublicKey.Exponent";
        private const string _KeyModulus = "PublicKey.Modulus";
        private const string _KeyPrimeExponentP = "PrivateKey.DP";
        private const string _KeyPrimeExponentQ = "PrivateKey.DQ";
        private const string _KeyPrimeP = "PrivateKey.P";
        private const string _KeyPrimeQ = "PrivateKey.Q";
        private const string _KeyPrivateExponent = "PrivateKey.D";
        private int _KeySize;
        private RSACryptoServiceProvider _rsa;
        //private bool _UseMachineKeystore;


        public class PrivateKey
        {
            public PrivateKey()
            {
            }

            public PrivateKey(string keyXml)
            {
                this.LoadFromXml(keyXml);
            }

            public void ExportToConfigFile(string strFilePath)
            {
                StreamWriter writer1 = new StreamWriter(strFilePath, false);
                writer1.Write(this.ToConfigSection());
                writer1.Close();
            }

            /// <summary>
            /// Writes the Xml representation of this private key to a file
            /// </summary>
            public void ExportToXmlFile(string filePath)
            {
                StreamWriter writer1 = new StreamWriter(filePath, false);
                writer1.Write(this.ToXml());
                writer1.Close();
            }

            /// <summary>
            /// Load private key from App.config or Web.config file
            /// </summary>
            public void LoadFromConfig()
            {
                this.Modulus = Carlop.ClassLib.Encryption.Utils.GetConfigString("PublicKey.Modulus", true);
                this.Exponent = Carlop.ClassLib.Encryption.Utils.GetConfigString("PublicKey.Exponent", true);
                this.PrimeP = Carlop.ClassLib.Encryption.Utils.GetConfigString("PrivateKey.P", true);
                this.PrimeQ = Carlop.ClassLib.Encryption.Utils.GetConfigString("PrivateKey.Q", true);
                this.PrimeExponentP = Carlop.ClassLib.Encryption.Utils.GetConfigString("PrivateKey.DP", true);
                this.PrimeExponentQ = Carlop.ClassLib.Encryption.Utils.GetConfigString("PrivateKey.DQ", true);
                this.Coefficient = Carlop.ClassLib.Encryption.Utils.GetConfigString("PrivateKey.InverseQ", true);
                this.PrivateExponent = Carlop.ClassLib.Encryption.Utils.GetConfigString("PrivateKey.D", true);
            }

            /// <summary>
            /// Loads the private key from its XML string
            /// </summary>
            public void LoadFromXml(string keyXml)
            {
                this.Modulus = Carlop.ClassLib.Encryption.Utils.GetXmlElement(keyXml, "Modulus");
                this.Exponent = Carlop.ClassLib.Encryption.Utils.GetXmlElement(keyXml, "Exponent");
                this.PrimeP = Carlop.ClassLib.Encryption.Utils.GetXmlElement(keyXml, "P");
                this.PrimeQ = Carlop.ClassLib.Encryption.Utils.GetXmlElement(keyXml, "Q");
                this.PrimeExponentP = Carlop.ClassLib.Encryption.Utils.GetXmlElement(keyXml, "DP");
                this.PrimeExponentQ = Carlop.ClassLib.Encryption.Utils.GetXmlElement(keyXml, "DQ");
                this.Coefficient = Carlop.ClassLib.Encryption.Utils.GetXmlElement(keyXml, "InverseQ");
                this.PrivateExponent = Carlop.ClassLib.Encryption.Utils.GetXmlElement(keyXml, "D");
            }

            /// <summary>
            /// Returns *.config file XML section representing this private key
            /// </summary>
            public string ToConfigSection()
            {
                StringBuilder builder1 = new StringBuilder();
                StringBuilder builder2 = builder1;
                builder2.Append(Carlop.ClassLib.Encryption.Utils.WriteConfigKey("PublicKey.Modulus", this.Modulus));
                builder2.Append(Carlop.ClassLib.Encryption.Utils.WriteConfigKey("PublicKey.Exponent", this.Exponent));
                builder2.Append(Carlop.ClassLib.Encryption.Utils.WriteConfigKey("PrivateKey.P", this.PrimeP));
                builder2.Append(Carlop.ClassLib.Encryption.Utils.WriteConfigKey("PrivateKey.Q", this.PrimeQ));
                builder2.Append(Carlop.ClassLib.Encryption.Utils.WriteConfigKey("PrivateKey.DP", this.PrimeExponentP));
                builder2.Append(Carlop.ClassLib.Encryption.Utils.WriteConfigKey("PrivateKey.DQ", this.PrimeExponentQ));
                builder2.Append(Carlop.ClassLib.Encryption.Utils.WriteConfigKey("PrivateKey.InverseQ", this.Coefficient));
                builder2.Append(Carlop.ClassLib.Encryption.Utils.WriteConfigKey("PrivateKey.D", this.PrivateExponent));
                builder2 = null;
                return builder1.ToString();
            }

            public RSAParameters ToParameters()
            {
                RSAParameters parameters1 = new RSAParameters();
                parameters1.Modulus = Convert.FromBase64String(this.Modulus);
                parameters1.Exponent = Convert.FromBase64String(this.Exponent);
                parameters1.P = Convert.FromBase64String(this.PrimeP);
                parameters1.Q = Convert.FromBase64String(this.PrimeQ);
                parameters1.DP = Convert.FromBase64String(this.PrimeExponentP);
                parameters1.DQ = Convert.FromBase64String(this.PrimeExponentQ);
                parameters1.InverseQ = Convert.FromBase64String(this.Coefficient);
                parameters1.D = Convert.FromBase64String(this.PrivateExponent);
                return parameters1;
            }

            public string ToXml()
            {
                StringBuilder builder1 = new StringBuilder();
                StringBuilder builder2 = builder1;
                builder2.Append(Carlop.ClassLib.Encryption.Utils.WriteXmlNode("RSAKeyValue", false));
                builder2.Append(Carlop.ClassLib.Encryption.Utils.WriteXmlElement("Modulus", this.Modulus));
                builder2.Append(Carlop.ClassLib.Encryption.Utils.WriteXmlElement("Exponent", this.Exponent));
                builder2.Append(Carlop.ClassLib.Encryption.Utils.WriteXmlElement("P", this.PrimeP));
                builder2.Append(Carlop.ClassLib.Encryption.Utils.WriteXmlElement("Q", this.PrimeQ));
                builder2.Append(Carlop.ClassLib.Encryption.Utils.WriteXmlElement("DP", this.PrimeExponentP));
                builder2.Append(Carlop.ClassLib.Encryption.Utils.WriteXmlElement("DQ", this.PrimeExponentQ));
                builder2.Append(Carlop.ClassLib.Encryption.Utils.WriteXmlElement("InverseQ", this.Coefficient));
                builder2.Append(Carlop.ClassLib.Encryption.Utils.WriteXmlElement("D", this.PrivateExponent));
                builder2.Append(Carlop.ClassLib.Encryption.Utils.WriteXmlNode("RSAKeyValue", true));
                builder2 = null;
                return builder1.ToString();
            }


            public string Coefficient;
            public string Exponent;
            public string Modulus;
            public string PrimeExponentP;
            public string PrimeExponentQ;
            public string PrimeP;
            public string PrimeQ;
            public string PrivateExponent;
        }

        public class PublicKey
        {
            public PublicKey()
            {
            }

            public PublicKey(string KeyXml)
            {
                this.LoadFromXml(KeyXml);
            }

            /// <summary>
            /// Writes the *.config file representation of this public key to a file
            /// </summary>
            public void ExportToConfigFile(string filePath)
            {
                StreamWriter writer1 = new StreamWriter(filePath, false);
                writer1.Write(this.ToConfigSection());
                writer1.Close();
            }

            /// <summary>
            /// Writes the Xml representation of this public key to a file
            /// </summary>
            public void ExportToXmlFile(string filePath)
            {
                StreamWriter writer1 = new StreamWriter(filePath, false);
                writer1.Write(this.ToXml());
                writer1.Close();
            }

            /// <summary>
            /// Load public key from App.config or Web.config file
            /// </summary>
            public void LoadFromConfig()
            {
                this.Modulus = Carlop.ClassLib.Encryption.Utils.GetConfigString("PublicKey.Modulus", true);
                this.Exponent = Carlop.ClassLib.Encryption.Utils.GetConfigString("PublicKey.Exponent", true);
            }

            public void LoadFromXml(string keyXml)
            {
                this.Modulus = Carlop.ClassLib.Encryption.Utils.GetXmlElement(keyXml, "Modulus");
                this.Exponent = Carlop.ClassLib.Encryption.Utils.GetXmlElement(keyXml, "Exponent");
            }

            public string ToConfigSection()
            {
                StringBuilder builder1 = new StringBuilder();
                StringBuilder builder2 = builder1;
                builder2.Append(Carlop.ClassLib.Encryption.Utils.WriteConfigKey("PublicKey.Modulus", this.Modulus));
                builder2.Append(Carlop.ClassLib.Encryption.Utils.WriteConfigKey("PublicKey.Exponent", this.Exponent));
                builder2 = null;
                return builder1.ToString();
            }

            /// <summary>
            /// Converts this public key to an RSAParameters object
            /// </summary>
            public RSAParameters ToParameters()
            {
                RSAParameters parameters1 = new RSAParameters();
                parameters1.Modulus = Convert.FromBase64String(this.Modulus);
                parameters1.Exponent = Convert.FromBase64String(this.Exponent);
                return parameters1;
            }

            public string ToXml()
            {
                StringBuilder builder1 = new StringBuilder();
                StringBuilder builder2 = builder1;
                builder2.Append(Carlop.ClassLib.Encryption.Utils.WriteXmlNode("RSAKeyValue", false));
                builder2.Append(Carlop.ClassLib.Encryption.Utils.WriteXmlElement("Modulus", this.Modulus));
                builder2.Append(Carlop.ClassLib.Encryption.Utils.WriteXmlElement("Exponent", this.Exponent));
                builder2.Append(Carlop.ClassLib.Encryption.Utils.WriteXmlNode("RSAKeyValue", true));
                builder2 = null;
                return builder1.ToString();
            }


            public string Exponent;
            public string Modulus;
        }
    }
}

