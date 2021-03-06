﻿using System;
using sc2i.common;

namespace futurocom.snmp.Mib
{
    internal sealed class TextualConvention : ITypeAssignment
    {
        private string _name;
        private DisplayHint _displayHint;
        private Status _status;
        private string _description;
        private string _reference;
        private ITypeAssignment _syntax;

        public TextualConvention()
        {
        }

        public SnmpType SnmpType
        {
            get
            {
                return SnmpType.OctetString;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "module")]
        public TextualConvention(string module, string name, Lexer lexer)
        {
            _name = name;

            Symbol temp = lexer.NextNonEOLSymbol;

            if (temp == Symbol.DisplayHint)
            {
                // TODO: this needs decoding to a useful format.
                _displayHint = new DisplayHint(lexer.NextNonEOLSymbol.ToString().Trim(new char[] { '"' }));
                temp = lexer.NextNonEOLSymbol;
            }

            temp.Expect(Symbol.Status);
            try
            {
                _status = (Status)Enum.Parse(typeof(Status), lexer.NextNonEOLSymbol.ToString());
                temp = lexer.NextNonEOLSymbol;
            }
            catch (ArgumentException)
            {
                temp.Validate(true, "Invalid status");
            }

            temp.Expect(Symbol.Description);
            _description = lexer.NextNonEOLSymbol.ToString().Trim(new char[] { '"' });
            temp = lexer.NextNonEOLSymbol;

            if (temp == Symbol.Reference)
            {
                _reference = lexer.NextNonEOLSymbol.ToString();
                temp = lexer.NextNonEOLSymbol;
            }

            temp.Expect(Symbol.Syntax);

            /* 
             * RFC2579 definition:
             *       Syntax ::=   -- Must be one of the following:
             *                    -- a base type (or its refinement), or
             *                    -- a BITS pseudo-type
             *               type
             *             | "BITS" "{" NamedBits "}"
             *
             * From section 3.5:
             *      The data structure must be one of the alternatives defined
             *      in the ObjectSyntax CHOICE or the BITS construct.  Note
             *      that this means that the SYNTAX clause of a Textual
             *      Convention can not refer to a previously defined Textual
             *      Convention.
             *      
             *      The SYNTAX clause of a TEXTUAL CONVENTION macro may be
             *      sub-typed in the same way as the SYNTAX clause of an
             *      OBJECT-TYPE macro.
             * 
             * Therefore the possible values are (grouped by underlying type):
             *      INTEGER, Integer32
             *      OCTET STRING, Opaque
             *      OBJECT IDENTIFIER
             *      IpAddress
             *      Counter64
             *      Unsigned32, Counter32, Gauge32, TimeTicks
             *      BITS
             * With appropriate sub-typing.
             */

            temp = lexer.NextNonEOLSymbol;
            if (temp == Symbol.Bits)
            {
                _syntax = new BitsType(module, string.Empty, lexer);
            }
            else if (temp == Symbol.Integer || temp == Symbol.Integer32)
            {
                _syntax = new IntegerType(module, string.Empty, lexer);
            }
            else if (temp == Symbol.Octet)
            {
                temp = lexer.NextSymbol;
                temp.Expect(Symbol.String);
                _syntax = new OctetStringType(module, string.Empty, lexer);
            }
            else if (temp == Symbol.Opaque)
            {
                _syntax = new OctetStringType(module, string.Empty, lexer);
            }
            else if (temp == Symbol.IpAddress)
            {
                _syntax = new IpAddressType(module, string.Empty, lexer);
            }
            else if (temp == Symbol.Counter64)
            {
                _syntax = new Counter64Type(module, string.Empty, lexer);
            }
            else if (temp == Symbol.Unsigned32 || temp == Symbol.Counter32 || temp == Symbol.Gauge32 || temp == Symbol.TimeTicks)
            {
                _syntax = new UnsignedType(module, string.Empty, lexer);
            }
            else if (temp == Symbol.Object)
            {
                temp = lexer.NextSymbol;
                temp.Expect(Symbol.Identifier);
                _syntax = new ObjectIdentifierType(module, string.Empty, lexer);
            }
            else
            {
                _syntax = new TypeAssignment(string.Empty, string.Empty, temp, lexer);
                //temp.Validate(true, "illegal syntax for textual convention");
            }
        }

        public string Name
        {
            get { return _name; }
        }

        public string DisplayHint
        {
            get { return _displayHint == null ? null : _displayHint.ToString(); }
        }

        public Status Status
        {
            get { return _status; }
        }

        public string Description
        {
            get { return _description; }
        }

        public string Reference
        {
            get { return _reference; }
        }

        public ITypeAssignment Syntax
        {
            get { return _syntax; }
        }

        internal object Decode(Variable v)
        {
            if (_syntax is IntegerType)
            {
                Integer32 i = v.Data as Integer32;
                if (i == null || (_syntax as IntegerType).IsEnumeration)
                {
                    return null;
                }
                else if (_displayHint != null)
                {
                    return _displayHint.Decode(i.ToInt32());
                }
                else
                {
                    return i.ToInt32();
                }
            }
            else if (_syntax is UnsignedType)
            {
                Integer32 i = v.Data as Integer32;
                if (i == null)
                {
                    return null;
                }
                else if (_displayHint != null)
                {
                    return _displayHint.Decode(i.ToInt32());
                }
                else
                {
                    return i.ToInt32();
                }
            }
            else if (_syntax is OctetStringType)
            {
                OctetString o = v.Data as OctetString;
                if (o == null)
                {
                    return null;
                }
                else
                {
                    // TODO: Follow the format specifier for octet strings.
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        //------------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //------------------------------------------------------
        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;

            serializer.TraiteString(ref _name);
            result = serializer.TraiteObject<DisplayHint>(ref _displayHint);

            int nVal = (int)_status;
            serializer.TraiteInt(ref nVal);
            _status = (Status)nVal;

            serializer.TraiteString(ref _description);
            serializer.TraiteString(ref _reference);
            result = serializer.TraiteObject<ITypeAssignment>(ref _syntax);
            if (!result)
                return result;

            return result;
        }


    }
}