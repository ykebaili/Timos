using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;

namespace futurocom.snmp.Mib
{
    [Serializable]
    public class BitsType : AbstractTypeAssignment
    {
        private string _module;
        private string _name;
        private IDictionary<int, string> _map;

        public BitsType()
        {
        }

        public override SnmpType SnmpType
        {
            get { return SnmpType.Opaque; }
        }

        public BitsType(string module, string name, Lexer lexer)
        {
            _module = module;
            _name = name;
            lexer.NextNonEOLSymbol.Expect(Symbol.OpenBracket);
            _map = DecodeEnumerations(lexer);
        }

        public BitsType(string module, string name, IEnumerator<Symbol> enumerator)
        {
            _module = module;
            _name = name;
            enumerator.NextNonEOLSymbol().Expect(Symbol.OpenBracket);
            _map = DecodeEnumerations(enumerator);
        }

        public string this[int identifier]
        {
            get
            {
                return (string)_map[identifier];
            }
        }

        public override string Name
        {
            get { return _name; }
        }

        //----------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //----------------------------------------------------
        public override CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            serializer.TraiteString(ref _module);
            serializer.TraiteString(ref _name);

            int nCount = _map == null ? 0 : _map.Count;
            serializer.TraiteInt(ref nCount);

            switch (serializer.Mode)
            {
                case ModeSerialisation.Ecriture:
                    if (_map != null)
                    {
                        foreach (KeyValuePair<int, string> kv in _map)
                        {
                            int nVal = kv.Key;
                            string strVal = kv.Value;
                            serializer.TraiteInt(ref nVal);
                            serializer.TraiteString(ref strVal);
                        }
                    }
                    break;
                case ModeSerialisation.Lecture:
                    _map = new Dictionary<int, string>();
                    for (int i = 0; i < nCount; i++)
                    {
                        int nVal = 0;
                        string strTmp = "";
                        serializer.TraiteInt(ref nVal);
                        serializer.TraiteString(ref strTmp);
                        _map[nVal] = strTmp;
                    }
                    break;
            }
            return result;
        }

        //----------------------------------
        public override Type GetTypeDotNet()
        {
            return typeof(int);
        }

        /*//----------------------------------
        public overrde ISnmpData FromString ( string strValeur )
        {*/

        
        

        



    }
}
