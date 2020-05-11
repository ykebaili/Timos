using System.Collections.Generic;
using System.Text;
using System;
using sc2i.common;

namespace futurocom.snmp.Mib
{
    public sealed class ObjectType : IEntity
    {
        private string _module="";
        private string _parent="";
        private uint _value=0;
        private string _name="";
        private ITypeAssignment _syntax=null;
        private string _units="";
        private MaxAccess _access = MaxAccess.readWrite;
        private Status _status = Status.current;
        private string _description="";
        private string _reference="";
        private List<string> _indices = new List<string>();
        private string _augment="";
        private Symbol _defVal;

        public ObjectType()
        {
        }

        public ObjectType(string module, IList<Symbol> header, Lexer lexer)
        {
            _module = module;
            _name = header[0].ToString();
            ParseProperties(header);
            lexer.ParseOidValue(out _parent, out _value);
        }

        private void ParseProperties(IEnumerable<Symbol> header)
        {
            IEnumerator<Symbol> enumerator = header.GetEnumerator();
            Symbol temp = enumerator.NextNonEOLSymbol();

            // Skip name
            temp = enumerator.NextNonEOLSymbol();

            temp.Expect(Symbol.ObjectType);
            temp = enumerator.NextNonEOLSymbol();

            _syntax         = ParseSyntax       (enumerator, ref temp);
            _units          = ParseUnits        (enumerator, ref temp);
            _access         = ParseAccess       (enumerator, ref temp);
            _status         = ParseStatus       (enumerator, ref temp);
            _description    = ParseDescription  (enumerator, ref temp);
            _reference      = ParseReference    (enumerator, ref temp);
            _indices        = ParseIndices      (enumerator, ref temp);
            _augment        = ParseAugments     (enumerator, ref temp);
            _defVal         = ParseDefVal       (enumerator, ref temp);
        }

        private static string ParseAugments(IEnumerator<Symbol> enumerator, ref Symbol temp)
        {
            string augment = null;
            if (temp == Symbol.Augments)
            {
                temp = enumerator.NextNonEOLSymbol();

                temp.Expect(Symbol.OpenBracket);
                temp = enumerator.NextNonEOLSymbol();

                augment = temp.ToString();
                temp = enumerator.NextNonEOLSymbol();

                temp.Expect(Symbol.CloseBracket);
                temp = enumerator.NextNonEOLSymbol();
            }
            return augment;
        }

        private static Symbol ParseDefVal(IEnumerator<Symbol> enumerator, ref Symbol temp)
        {
            Symbol defVal = null;
            if (temp == Symbol.DefVal)
            {
                temp = enumerator.NextNonEOLSymbol();

                temp.Expect(Symbol.OpenBracket);
                temp = enumerator.NextNonEOLSymbol();

                if (temp == Symbol.OpenBracket)
                {
                    var depth = 1;
                    // TODO: decode this.
                    while (depth > 0)
                    {
                        temp = enumerator.NextNonEOLSymbol();
                        if (temp == Symbol.OpenBracket)
                        {
                            depth++;
                        }
                        else if (temp == Symbol.CloseBracket)
                        {
                            depth--;
                        }

                    }
                }
                else
                {
                    defVal = temp;
                    temp = enumerator.NextNonEOLSymbol();
                }
            }
            return defVal;
        }

        private static List<string> ParseIndices(IEnumerator<Symbol> enumerator, ref Symbol temp)
        {
            List<string> indices = null;
            if (temp == Symbol.Index)
            {
                temp = enumerator.NextNonEOLSymbol();

                indices = new List<string>();

                while (temp != Symbol.CloseBracket )
                {
                    if (temp != Symbol.Comma && temp != Symbol.OpenBracket)
                    {
                        indices.Add(temp.ToString());
                    }
                    temp = enumerator.NextNonEOLSymbol();
                }

                temp = enumerator.NextNonEOLSymbol();
            }
            return indices;
        }

        private static string ParseReference(IEnumerator<Symbol> enumerator, ref Symbol temp)
        {
            string reference = null;
            if (temp == Symbol.Reference)
            {
                temp = enumerator.NextNonEOLSymbol();

                reference = temp.ToString();
                temp = enumerator.NextNonEOLSymbol();
            }
            return reference;
        }

        private static string ParseDescription(IEnumerator<Symbol> enumerator, ref Symbol temp)
        {
            string description = null;
            if (temp == Symbol.Description)
            {
                temp = enumerator.NextNonEOLSymbol();

                description = temp.ToString().Trim(new char[] { '"' });
                temp = enumerator.NextNonEOLSymbol();
            }
            return description;
        }

        private static Status ParseStatus(IEnumerator<Symbol> enumerator, ref Symbol temp)
        {
            Status status = Status.obsolete;

            temp.Expect(Symbol.Status);
            temp = enumerator.NextNonEOLSymbol();

            try
            {
                status = (Status)Enum.Parse(typeof(Status), temp.ToString());
                temp = enumerator.NextNonEOLSymbol();
            }
            catch (ArgumentException)
            {
                temp.Validate(true, "Invalid status");
            }
            return status;
        }

        private static MaxAccess ParseAccess(IEnumerator<Symbol> enumerator, ref Symbol temp)
        {
            MaxAccess access = MaxAccess.notAccessible;

            if (temp == Symbol.MaxAccess || temp == Symbol.Access)
            {
                temp = enumerator.NextNonEOLSymbol();

                switch (temp.ToString())
                {
                    case "not-accessible":
                        access = MaxAccess.notAccessible;
                        break;
                    case "accessible-for-notify":
                        access = MaxAccess.accessibleForNotify;
                        break;
                    case "read-only":
                        access = MaxAccess.readOnly;
                        break;
                    case "read-write":
                        access = MaxAccess.readWrite;
                        break;
                    case "read-create":
                        access = MaxAccess.readCreate;
                        break;
                    case "write-only":
                        access = MaxAccess.readWrite;
                        break;
                    default:
                        temp.Validate(true, "Invalid access");
                        break;
                }
            }
            else
            {
                temp.Validate(true, "missing access");
            }

            temp = enumerator.NextNonEOLSymbol();
            return access;
        }

        private static string ParseUnits(IEnumerator<Symbol> enumerator, ref Symbol temp)
        {
            string units = null;

            if (temp == Symbol.Units)
            {
                temp = enumerator.NextNonEOLSymbol();

                units = temp.ToString();
                temp = enumerator.NextNonEOLSymbol();
            }

            return units;
        }

        private static ITypeAssignment ParseSyntax(IEnumerator<Symbol> enumerator, ref Symbol temp)
        {
            ITypeAssignment syntax;

            temp.Expect(Symbol.Syntax);
            temp = enumerator.NextNonEOLSymbol();

            if (temp == Symbol.Bits)
            {
                syntax = new BitsType(string.Empty, string.Empty, enumerator);
                temp = enumerator.NextNonEOLSymbol();
            }
            else if (temp == Symbol.Integer || temp == Symbol.Integer32)
            {
                syntax = new IntegerType(string.Empty, string.Empty, enumerator, ref temp);
            }
            else if (temp == Symbol.Octet)
            {
                temp = enumerator.NextNonEOLSymbol();

                temp.Expect(Symbol.String);
                syntax = new OctetStringType(string.Empty, string.Empty, enumerator, ref temp);
            }
            else if (temp == Symbol.Opaque)
            {
                syntax = new OctetStringType(string.Empty, string.Empty, enumerator, ref temp);
            }
            else if (temp == Symbol.IpAddress)
            {
                syntax = new IpAddressType(string.Empty, string.Empty, enumerator);
                temp = enumerator.NextNonEOLSymbol();
            }
            else if (temp == Symbol.Counter64)
            {
                syntax = new Counter64Type(string.Empty, string.Empty, enumerator);
                temp = enumerator.NextNonEOLSymbol();
            }
            else if (temp == Symbol.Unsigned32 || temp == Symbol.Counter32 || temp == Symbol.Gauge32 || temp == Symbol.TimeTicks)
            {
                syntax = new UnsignedType(string.Empty, string.Empty, enumerator, ref temp);
            }
            else if (temp == Symbol.Object)
            {
                temp = enumerator.NextNonEOLSymbol();

                temp.Expect(Symbol.Identifier);
                syntax = new ObjectIdentifierType(string.Empty, string.Empty, enumerator);
                temp = enumerator.NextNonEOLSymbol();
            }
            else if (temp == Symbol.Sequence)
            {
                temp = enumerator.NextNonEOLSymbol();

                if (temp == Symbol.Of)
                {
                    temp = enumerator.NextNonEOLSymbol();
                    syntax = new TypeAssignment(string.Empty, string.Empty, enumerator, ref temp);
                }
                else
                {
                    syntax = new Sequence(string.Empty, string.Empty, enumerator);
                    temp = enumerator.NextNonEOLSymbol();
                }
            }
            else
            {
                syntax = new TypeAssignment(string.Empty, string.Empty, enumerator, ref temp);
            }

            return syntax;
        }

        private static bool IsProperty(Symbol sym)
        {
            string s = sym.ToString();
            return s == "SYNTAX" || s == "MAX-ACCESS" || s == "STATUS" || s == "DESCRIPTION";
        }

        public string ModuleName
        {
            get { return _module; }
        }

        public string Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        public uint Value
        {
            get { return _value; }
        }

        public string Name
        {
            get { return _name; }
        }

        public string Description
        {
            get { return _description; }
        }

        public ITypeAssignment Syntax
        {
            get { return _syntax; }
            internal set { _syntax = value; }
        }

        //--------------------------------------------
        public MaxAccess Access
        {
            get
            {
                return _access;
            }
        }

        //--------------------------------------------
        public string Units
        {
            get
            {
                return _units;
            }
        }

        //--------------------------------------------
        public Symbol DefaultValue
        {
            get
            {
                return _defVal;
            }
        }

        //--------------------------------------------
        public string Reference
        {
            get
            {
                return _reference;
            }
        }

        //--------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //--------------------------------------------
        public string[] Indices
        {
            get
            {
                if (_indices == null)
                    return new string[0];
                return _indices.ToArray();
            }
        }

        //--------------------------------------------
        public string Augment
        {
            get
            {
                return _augment;
            }
        }



        //--------------------------------------------
        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);

            serializer.TraiteString(ref _module);
            serializer.TraiteString(ref _parent);

            long nLong = (long)_value;
            serializer.TraiteLong(ref nLong);
            _value = (uint)nLong;

            serializer.TraiteString(ref _name);

            result = serializer.TraiteObject<ITypeAssignment>(ref _syntax);
            if (!result)
                return result;

            serializer.TraiteString(ref _units);

            int nInt = (int)_access;
            serializer.TraiteInt(ref nInt);
            _access = (MaxAccess)nInt;

            nInt = (int)_status;
            serializer.TraiteInt(ref nInt);
            _status = (Status)nInt;

            serializer.TraiteString(ref _description);
            serializer.TraiteString(ref _reference);

            int nNb = _indices != null?_indices.Count:0;
            serializer.TraiteInt(ref nNb);
            switch (serializer.Mode)
            {
                case ModeSerialisation.Ecriture:
                    if (_indices != null)
                    {
                        foreach (string strVal in _indices)
                        {
                            string strTmp = strVal;
                            serializer.TraiteString(ref strTmp);
                        }
                    }
                    break;
                case ModeSerialisation.Lecture:
                    _indices = new List<string>();
                    for (int i = 0; i < nNb; i++)
                    {
                        string strTmp = "";
                        serializer.TraiteString(ref strTmp);
                        _indices.Add(strTmp);
                    }
                    break;
            }
            serializer.TraiteString(ref _augment);
            result = serializer.TraiteObject<Symbol>(ref _defVal);
            if (!result)
                return result;
            return result;
        }



    }
}