using System.Collections.Generic;
using sc2i.common;

namespace futurocom.snmp.Mib
{
    public sealed class NotificationType : IEntity
    {
        private string _module;
        private string _parent;
        private uint _value;
        private string _name;
        private string _description;
        private string[] _objects;

        public NotificationType()
        {
        }

        public NotificationType(string module, IList<Symbol> header, Lexer lexer)
        {
            _module = module;
            _name = header[0].ToString();
            lexer.ParseOidValue(out _parent, out _value);

            _description = header.GetSingleValueString(Symbol.Description, "");
            _objects = header.GetValuesStringAvecAccolades(Symbol.Objects);


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

        //------------------------------------------------------
        public string[] Objects
        {
            get
            {
                return _objects;
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

            serializer.TraiteString(ref _module);
            serializer.TraiteString(ref _parent);
            long nVal = (int)_value;
            serializer.TraiteLong(ref nVal);
            _value = (uint)nVal;
            serializer.TraiteString(ref _name);
            serializer.TraiteString(ref _description);

            int nNb = _objects == null ? 0 : _objects.Length;
            serializer.TraiteInt(ref nNb);
            switch (serializer.Mode)
            {
                case ModeSerialisation.Ecriture:
                    if (_objects != null)
                        foreach (string strObject in _objects)
                        {
                            string strTmp = strObject;
                            serializer.TraiteString(ref strTmp);
                        }
                    break;
                case ModeSerialisation.Lecture :
                    List<string> lst = new List<string>();
                    for (int i = 0; i < nNb; i++)
                    {
                        string strTmp = "";
                        serializer.TraiteString(ref strTmp);
                        lst.Add(strTmp);
                    }
                    _objects = lst.ToArray();
                    break;
            }
            return result;
        }
    }
}