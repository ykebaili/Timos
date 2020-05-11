using System.Collections.Generic;
using sc2i.common;

namespace futurocom.snmp.Mib
{
    internal sealed class ModuleIdentity : IEntity
    {
        private  string _module;
        private string _parent;
        private  uint _value;
        private  string _name;
        private string _description;

        public ModuleIdentity()
        {
        }

        public ModuleIdentity(string module, IList<Symbol> header, Lexer lexer)
        {
            _module = module;
            _name = header[0].ToString();
            lexer.ParseOidValue(out _parent, out _value);
            _description = header.GetSingleValueString(Symbol.Description, "");
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
            // TODO: implement this.
            get { return _description; }
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
            long nVal = (long)_value;
            serializer.TraiteLong(ref nVal);
            _value = (uint)nVal;
            serializer.TraiteString(ref _name);
            serializer.TraiteString(ref _description);
            return result;
        }
    }
}