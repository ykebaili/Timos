﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;

namespace futurocom.snmp.Mib
{
    [Serializable]
    public abstract class AbstractTypeAssignment : ITypeAssignment , I2iSerializable
    {
        protected Symbol Next(object o)
        {
            Lexer lexer = o as Lexer;
            IEnumerator<Symbol> enumerator = o as IEnumerator<Symbol>;

            if (lexer != null)
            {
                return lexer.NextNonEOLSymbol;
            }
            else if (enumerator != null)
            {
                return enumerator.NextNonEOLSymbol();
            }
            else
            {
                return null;
            }
        }

        public abstract SnmpType SnmpType{get;}

        protected IList<ValueRange> DecodeRanges(object enumerator)
        {
            Symbol temp = null;
            List<ValueRange> _ranges = new List<ValueRange>();

            bool size = false;

            while (temp != Symbol.CloseParentheses)
            {
                Symbol value1 = Next(enumerator);
                Symbol value2 = null;

                if (value1 == Symbol.Size)
                {
                    size = true;
                    Next(enumerator).Expect(Symbol.OpenParentheses);
                    continue;
                }

                temp = Next(enumerator);
                if (temp == Symbol.DoubleDot)
                {
                    value2 = Next(enumerator);
                    temp = Next(enumerator);
                }

                ValueRange range = new ValueRange(value1, value2);

                if (size)
                {
                    value1.Validate(range.Start < 0, "invalid sub-typing; size must be greater than 0");
                }

                value1.Validate(this.Contains(range.Start, _ranges), "invalid sub-typing");
                if (value2 != null)
                {
                    value2.Validate(this.Contains((int)range.End, _ranges), "invalid sub-typing");
                }

                foreach (ValueRange other in _ranges)
                {
                    value1.Validate(range.Contains(other.Start), "invalid sub-typing");
                    if (other.End != null)
                    {
                        value1.Validate(range.Contains((int)other.End), "invalid sub-typing");
                    }
                }

                _ranges.Add(range);
            }

            if (size)
            {
                Next(enumerator).Expect(Symbol.CloseParentheses);
            }
            return _ranges;
        }

        protected IDictionary<int, string> DecodeEnumerations(object enumerator)
        {
            Dictionary<int, string> _map = new Dictionary<int, string>();

            int signedNumber;
            do
            {
                string identifier = Next(enumerator).ToString();

                Next(enumerator).Expect(Symbol.OpenParentheses);

                Symbol value = Next(enumerator);

                if (int.TryParse(value.ToString(), out signedNumber))
                {
                    try
                    {
                        // Have to include the number as it seems repeated identifiers are allowed ??
                        _map.Add(signedNumber, String.Format("{0}({1})", identifier, signedNumber));
                    }
                    catch (ArgumentException ex)
                    {
                        value.Validate(true, ex.Message);
                    }
                }
                else
                {
                    // Need to get "DefinedValue".
                }

                Next(enumerator).Expect(Symbol.CloseParentheses);
            } while (Next(enumerator) != Symbol.CloseBracket);

            return _map;
        }

        private bool Contains(Int64 value, IList<ValueRange> ranges)
        {
            foreach (ValueRange range in ranges)
            {
                if (range.Contains(value))
                {
                    return true;
                }
            }

            return false;
        }

        public abstract string Name { get; }

        public abstract CResultAErreur Serialize(C2iSerializer serializer);

        public abstract Type GetTypeDotNet();

        //public abstract ISnmpData FromString(string strValeur);

        public static ISnmpData GetSnmpFromDotNet(AbstractTypeAssignment typeSnmp, object valeur)
        {
            ISnmpData data = null;
            if (typeSnmp is BitsType)
            {
                
            }
            else if (typeSnmp is IntegerType)
            {
                try
                {
                    data= new Integer32(Convert.ToInt32(valeur));
                }
                catch { }
            }
            else if (typeSnmp is OctetStringType)
            {
                try
                {
                    data =  new OctetString(valeur.ToString());
                }
                catch
                {
                }
            }
            else if (typeSnmp is UnsignedType)
            {

            }
            return data;
        }

        public static ISnmpData GetSnmpFromDotNet(object valeur)
        {
            ISnmpData data = null;
            if (valeur != null)
            {
                if (valeur is int )
                {
                    data = new Integer32((int)valeur);
                }
                else
                    data = new OctetString(valeur.ToString());
            }
            return data;
        }

    }
}
