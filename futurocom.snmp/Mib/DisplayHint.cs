using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using sc2i.common;

namespace futurocom.snmp.Mib
{
    class DisplayHint : I2iSerializable
    {
        private enum NumType {
            dec=0,
            hex,
            oct,
            bin,
            str
        }

        private string _str;
        private NumType _type;
        private int _decimalPoints = 0;

        public DisplayHint()
        {
        }

        public DisplayHint(string str)
        {
            _str = str;
            if (str.StartsWith("d"))
            {
                _type = NumType.dec;
                if (str.StartsWith("d-"))
                {
                    _decimalPoints = Convert.ToInt32(str.Substring(2));
                }
            }
            else if (str.StartsWith("o"))
            {
                _type = NumType.oct;
            }
            else if (str.StartsWith("h"))
            {
                _type = NumType.hex;
            }
            else if (str.StartsWith("b"))
            {
                _type = NumType.bin;
            }
            else
            {
                _type = NumType.str;
                foreach (char c in str)
                {

                }
            }

        }

        public override string ToString()
        {
            return _str;
        }

        internal object Decode(int i)
        {
            switch (_type)
            {
                case NumType.dec:
                    if (_decimalPoints == 0)
                    {
                        return i;
                    }
                    else
                    {
                        return i / Math.Pow(10.0, _decimalPoints);
                    }
                case NumType.hex:
                    return System.Convert.ToString(i, 16);
                case NumType.oct:
                    return System.Convert.ToString(i, 8);
                case NumType.bin:
                    return System.Convert.ToString(i, 2);
                default:
                    return null;
            }
        }

        //----------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //----------------------------------------------------
        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            serializer.TraiteString(ref _str);
            
            int nTmp = (int)_type;
            serializer.TraiteInt(ref nTmp);
            _type = (NumType)nTmp;
            
            if (!result)
                return result;
            serializer.TraiteInt(ref _decimalPoints);
            return result;
        }


    }
}
