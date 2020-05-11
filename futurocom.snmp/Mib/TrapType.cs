/*
 * Created by SharpDevelop.
 * User: lextm
 * Date: 2008/5/31
 * Time: 12:20
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Collections.Generic;
using sc2i.common;

namespace futurocom.snmp.Mib
{
    public sealed class TrapType : IEntity
    {
        private string _module;
        private int _value;
        private string _name;
        private string _description;
        private string _entreprise;
        private string[] _variables;

        public TrapType()
        {
        }


        public TrapType(string module, IList<Symbol> header, Lexer lexer)
        {
            _module = module;
            _name = header[0].ToString();
            Symbol temp;
            while ((temp = lexer.NextSymbol) == Symbol.EOL)
            {
            }
            _description = header.GetSingleValueString(Symbol.Description, "");
            _entreprise = header.GetSingleValueString(Symbol.Entreprise, "");
            _variables = header.GetValuesStringAvecAccolades(Symbol.Variables);
            
            bool succeeded = int.TryParse(temp.ToString(), out _value);
            temp.Validate(!succeeded, "not a decimal");
        }

        public string Module
        {
            get { return _module; }
        }

        public string ModuleName
        {
            get
            {
                return _module;
            }
        }

        public string Parent
        {
            get
            {
                return _entreprise;
            }
            set
            {
            }
        }

        public uint Value
        {
            get { return (uint)_value; }
        }

        public string Name
        {
            get { return _name; }
        }

        //---------------------------------------------------
        public string Description
        {
            get
            {
                return _description;
            }
        }

        //---------------------------------------------------
        public string Entreprise
        {
            get
            {
                return _entreprise;
            }
        }

        //---------------------------------------------------
        public string[] Variables
        {
            get
            {
                return _variables;
            }
        }



        //---------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //---------------------------------------------------
        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            serializer.TraiteString(ref _module);
            serializer.TraiteString(ref _name);
            serializer.TraiteInt(ref _value);
            serializer.TraiteString(ref _description);
            serializer.TraiteString(ref _entreprise);

            int nNb = _variables == null ? 0 : _variables.Length;
            serializer.TraiteInt(ref nNb);
            switch (serializer.Mode)
            {
                case ModeSerialisation.Ecriture:
                    if (_variables != null)
                        foreach (string strObject in _variables)
                        {
                            string strTmp = strObject;
                            serializer.TraiteString(ref strTmp);
                        }
                    break;
                case ModeSerialisation.Lecture:
                    List<string> lst = new List<string>();
                    for (int i = 0; i < nNb; i++)
                    {
                        string strTmp = "";
                        serializer.TraiteString(ref strTmp);
                        lst.Add(strTmp);
                    }
                    _variables = lst.ToArray();
                    break;
            }

            return result;
        }
    }
}