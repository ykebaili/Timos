using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;

namespace futurocom.snmp.Mib
{
    /**
     * As this type is used for Counter32 and TimeTicks as well as Unsigned32
     * and Gauge32 it incorrectly allows range restrictions of Counter32 and
     * TimeTicks.  This is ok as currently we do not care about detecting
     * incorrect MIBs and this doesn't block the decoding of correct MIBs.
     */
    [Serializable]
    public class UnsignedType : AbstractTypeAssignment
    {
        private string _module;
        private string _name;
        private IList<ValueRange> _ranges;

        public UnsignedType()
        {
        }

        public override SnmpType SnmpType
        {
            get
            {
                return SnmpType.Integer32;
            }
        }

        public UnsignedType(string module, string name, Lexer lexer)
        {
            _module = module;
            _name = name;

            Symbol temp = lexer.NextNonEOLSymbol;
            if (temp == Symbol.OpenParentheses)
            {
                _ranges = DecodeRanges(lexer);
            }
            else
            {
                lexer.Restore(temp);
            }
        }

        public UnsignedType(string module, string name, IEnumerator<Symbol> enumerator, ref Symbol temp)
        {
            _module = module;
            _name = name;

            temp = enumerator.NextNonEOLSymbol();
            if (temp == Symbol.OpenParentheses)
            {
                _ranges = DecodeRanges(enumerator);
                temp = enumerator.NextNonEOLSymbol();
            }
        }

        public bool Contains(int value)
        {
            foreach (ValueRange range in _ranges)
            {
                if (range.Contains(value))
                {
                    return true;
                }
            }

            return false;
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

            int nCount = _ranges == null ? 0 : _ranges.Count;
            serializer.TraiteInt(ref nCount);
            switch (serializer.Mode)
            {
                case ModeSerialisation.Ecriture:
                    if (_ranges != null)
                    {
                        foreach (ValueRange valeur in _ranges)
                        {
                            ValueRange copie = valeur;
                            result = serializer.TraiteObject<ValueRange>(ref copie);
                            if (!result)
                                return result;
                        }
                    }
                    break;
                case ModeSerialisation.Lecture:
                    _ranges = new List<ValueRange>();
                    for (int n = 0; n < nCount; n++)
                    {
                        ValueRange v = null;
                        result = serializer.TraiteObject<ValueRange>(ref v);
                        if (!result)
                            return result;
                        _ranges.Add(v);
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
    }
}
