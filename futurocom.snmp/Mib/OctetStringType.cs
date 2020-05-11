using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;

namespace futurocom.snmp.Mib
{
    [Serializable]
    public class OctetStringType : AbstractTypeAssignment
    {
        private string _module;
        private string _name;
        private IList<ValueRange> _size;

        public OctetStringType()
        {
        }

        public override SnmpType SnmpType
        {
            get
            {
                return SnmpType.OctetString;
            }
        }

        public OctetStringType(string module, string name, Lexer lexer)
        {
            _module = module;
            _name = name;
            _size = new List<ValueRange>();

            Symbol temp = lexer.NextSymbol;
            if (temp == Symbol.OpenParentheses)
            {
                _size = DecodeRanges(lexer);
            }

        }

        public OctetStringType(string module, string name, IEnumerator<Symbol> enumerator, ref Symbol temp)
        {
            _module = module;
            _name = name;
            _size = new List<ValueRange>();

            temp = enumerator.NextSymbol();
            if (temp == Symbol.OpenParentheses)
            {
                _size = DecodeRanges(enumerator);
                temp = enumerator.NextNonEOLSymbol();
            }
        }

        public override string Name
        {
            get { return _name; }
        }

        public bool Contains(int p)
        {
            foreach (ValueRange range in _size)
            {
                if (range.Contains(p))
                {
                    return true;
                }
            }

            return false;
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

            int nCount = _size == null ? 0 : _size.Count;
            serializer.TraiteInt(ref nCount);
            switch (serializer.Mode)
            {
                case ModeSerialisation.Ecriture:
                    if (_size != null)
                    {
                        foreach (ValueRange valeur in _size)
                        {
                            ValueRange copie = valeur;
                            result = serializer.TraiteObject<ValueRange>(ref copie);
                            if (!result)
                                return result;
                        }
                    }
                    break;
                case ModeSerialisation.Lecture:
                    _size = new List<ValueRange>();
                    for (int n = 0; n < nCount; n++)
                    {
                        ValueRange v = null;
                        result = serializer.TraiteObject<ValueRange>(ref v);
                        if (!result)
                            return result;
                        _size.Add(v);
                    }
                    break;
            }
            return result;
        }

        //----------------------------------
        public override Type GetTypeDotNet()
        {
            return typeof(string);
        }
    }
}
