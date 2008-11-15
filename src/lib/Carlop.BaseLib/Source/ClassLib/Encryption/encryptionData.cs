namespace Carlop.ClassLib.Encryption
{
    using System;
    using System.Text;

    public class Data
    {
        static Data()
        {
            Data.DefaultEncoding = System.Text.Encoding.GetEncoding("Windows-1252");
        }

        public Data()
        {
            this._MaxBytes = 0;
            this._MinBytes = 0;
            this._StepBytes = 0;
            this.Encoding = Data.DefaultEncoding;
        }

        /// <summary>
        /// Creates new encryption data with the specified byte array
        /// </summary>
        public Data(byte[] b)
        {
            this._MaxBytes = 0;
            this._MinBytes = 0;
            this._StepBytes = 0;
            this.Encoding = Data.DefaultEncoding;
            this._b = b;
        }

        public Data(string s)
        {
            this._MaxBytes = 0;
            this._MinBytes = 0;
            this._StepBytes = 0;
            this.Encoding = Data.DefaultEncoding;
            this.Text = s;
        }

        /// <summary>
        /// Creates new encryption data using the specified string and the
        /// specified encoding to convert the string to a byte array.
        /// </summary>
        public Data(string s, System.Text.Encoding encoding)
        {
            this._MaxBytes = 0;
            this._MinBytes = 0;
            this._StepBytes = 0;
            this.Encoding = Data.DefaultEncoding;
            this.Encoding = encoding;
            this.Text = s;
        }

        public string ToBase64()
        {
            return this.Base64;
        }

        /// <summary>
        /// returns Hex string representation of this data
        /// </summary>
        public string ToHex()
        {
            return this.Hex; 
        }

        /// <summary>
        /// Returns text representation of bytes using the default text encoding
        /// </summary>
        public new string ToString()
        {
            return this.Text;
        }


        public string Base64
        {
            get
            {
                return Utils.ToBase64(this._b);
            }
            set
            {
                this._b = Utils.FromBase64(value);
            }
        }

        /// <summary>
        /// Returns the byte representation of the data;
        /// This will be padded to MinBytes and trimmed to MaxBytes as necessary!
        /// </summary>
        public byte[] Bytes
        {
            get
            {
                if ((this._MaxBytes > 0) && (this._b.Length > this._MaxBytes))
                {
                    byte[] buffer2 = new byte[(this._MaxBytes - 1) + 1];
                    Array.Copy(this._b, buffer2, buffer2.Length);
                    this._b = buffer2;
                }
                if ((this._MinBytes > 0) && (this._b.Length < this._MinBytes))
                {
                    byte[] buffer3 = new byte[(this._MinBytes - 1) + 1];
                    Array.Copy(this._b, buffer3, this._b.Length);
                    this._b = buffer3;
                }
                return this._b;
            }
            set
            {
                this._b = value;
            }
        }

        /// <summary>
        /// Sets or returns Hex string representation of this data
        /// </summary>
        public string Hex
        {
            get
            {
                return Utils.ToHex(this._b);
            }
            set
            {
                this._b = Utils.FromHex(value);
            }
        }

        public bool IsEmpty
        {
            get
            {
                if (this._b == null)
                {
                    return true;
                }
                if (this._b.Length == 0)
                {
                    return true;
                }
                return false;
            }
        }

        public int MaxBits
        {
            get
            {
                return (this._MaxBytes * 8);
            }
            set
            {
                this._MaxBytes = value / 8;
            }
        }

        /// <summary>
        /// maximum number of bytes allowed for this data; if 0, no limit
        /// </summary>
        public int MaxBytes
        {
            get
            {
                return this._MaxBytes;
            }
            set
            {
                this._MaxBytes = value;
            }
        }

        public int MinBits
        {
            get
            {
                return (this._MinBytes * 8);
            }
            set
            {
                this._MinBytes = value / 8;
            }
        }

        /// <summary>
        /// minimum number of bytes allowed for this data; if 0, no limit
        /// </summary>
        public int MinBytes
        {
            get
            {
                return this._MinBytes;
            }
            set
            {
                this._MinBytes = value;
            }
        }

        public int StepBits
        {
            get
            {
                return (this._StepBytes * 8);
            }
            set
            {
                this._StepBytes = value / 8;
            }
        }

        /// <summary>
        /// allowed step interval, in bytes, for this data; if 0, no limit
        /// </summary>
        public int StepBytes
        {
            get
            {
                return this._StepBytes;
            }
            set
            {
                this._StepBytes = value;
            }
        }

        public string Text
        {
            get
            {
                if (this._b == null)
                {
                    return "";
                }
                int num1 = Array.IndexOf<byte>(this._b, 0);
                if (num1 >= 0)
                {
                    return this.Encoding.GetString(this._b, 0, num1);
                }
                return this.Encoding.GetString(this._b);
            }
            set
            {
                this._b = this.Encoding.GetBytes(value);
            }
        }


        private byte[] _b;
        private int _MaxBytes;
        private int _MinBytes;
        private int _StepBytes;
        public static System.Text.Encoding DefaultEncoding;
        /// <summary>
        /// Determines the default text encoding for this Data instance
        /// </summary>
        public System.Text.Encoding Encoding;
    }
}

