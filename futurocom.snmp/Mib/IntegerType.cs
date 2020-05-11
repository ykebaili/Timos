/*
 * Created by SharpDevelop.
 * User: lextm
 * Date: 2008/7/25
 * Time: 20:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Collections.Generic;
using sc2i.common;
using System;

namespace futurocom.snmp.Mib
{
    /// <summary>
    /// The INTEGER type represents a list of alternatives, or a range of numbers..
    /// Includes Integer32 as it's indistinguishable from INTEGER.
    /// </summary>
    /**
     * As this type is used for Integer32 as well as INTEGER it incorrectly
     * allows enumeration sub-typing of Integer32.  This is ok as currently we
     * do not care about detecting incorrect MIBs and this doesn't block the
     * decoding of correct MIBs.
     */
    [Serializable]
    public sealed class IntegerType : AbstractTypeAssignment
    {
        private bool _isEnumeration;
        private IDictionary<int, string> _map;
        private IList<ValueRange> _ranges;
        private string _name;

        public IntegerType()
        {
        }

        public override SnmpType SnmpType
        {
            get
            {
                return SnmpType.Integer32;
            }
        }

        /// <summary>
        /// Creates an <see cref="IntegerType"/> instance.
        /// </summary>
        /// <param name="module"></param>
        /// <param name="name"></param>
        /// <param name="lexer"></param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "module")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "name")]
        public IntegerType(string module, string name, Lexer lexer)
        {
            _name = name;

            Symbol temp = lexer.NextNonEOLSymbol;
            if (temp == Symbol.OpenBracket)
            {
                _isEnumeration = true;
                _map = DecodeEnumerations(lexer);
            }
            else if (temp == Symbol.OpenParentheses)
            {
                _isEnumeration = false;
                _ranges = DecodeRanges(lexer);
            }
            else
            {
                lexer.Restore(temp);
            }
        }

        /// <summary>
        /// Creates an <see cref="IntegerType"/> instance.
        /// </summary>
        /// <param name="module"></param>
        /// <param name="name"></param>
        /// <param name="enumerator"></param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "module")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "name")]
        public IntegerType(string module, string name, IEnumerator<Symbol> enumerator, ref Symbol temp)
        {
            _name = name;
            temp = enumerator.NextNonEOLSymbol();
            if (temp == Symbol.OpenBracket)
            {
                _isEnumeration = true;
                _map = DecodeEnumerations(enumerator);
                temp = enumerator.NextNonEOLSymbol();
            }
            else if (temp == Symbol.OpenParentheses)
            {
                _isEnumeration = false;
                _ranges = DecodeRanges(enumerator);
                temp = enumerator.NextNonEOLSymbol();
            }
        }

        public override string Name
        {
            get { return _name; }
        }

        public bool IsEnumeration
        {
            get
            {
                return _isEnumeration;
            }
        }

        public string this[int identifier]
        {
            get
            {
                return _isEnumeration ? _map[identifier] : null;
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
            serializer.TraiteBool(ref _isEnumeration);
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

            nCount = _map == null ? 0 : _map.Count;
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
    }
}