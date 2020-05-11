using System.Collections.Generic;
using sc2i.common;

namespace futurocom.snmp.Mib
{
    /// <summary>
    /// Object identifier node.
    /// </summary>
    internal sealed class ObjectIdentity : IEntity
    {
        private string _module;
        private string _name;
        private string _parent;
        private uint _value;
        private string _description;

        public ObjectIdentity()
        {
        }
        
        /// <summary>
        /// Creates a <see cref="ObjectIdentity"/>.
        /// </summary>
        /// <param name="module">Module name</param>
        /// <param name="header">Header</param>
        /// <param name="lexer">Lexer</param>
        public ObjectIdentity(string module, IList<Symbol> header, Lexer lexer)
        {
            _module = module;
            _name = header[0].ToString();
            lexer.ParseOidValue(out _parent, out _value);
            if (_parent == "0")
            {
                _parent = "ccitt";
            }
            _description = header.GetSingleValueString(Symbol.Description, "");
        }

        /// <summary>
        /// Module name.
        /// </summary>
        public string ModuleName
        {
            get
            {
                return _module;
            }
        }
        
        /// <summary>
        /// Name.
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
        }
        
        /// <summary>
        /// Parent name.
        /// </summary>
        public string Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }
        
        /// <summary>
        /// Value.
        /// </summary>
        public uint Value
        {
            get
            {
                return _value;
            }
        }
        
        public string Description
        {
            get { return _description; }
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
            serializer.TraiteString(ref _parent);

            long nLong = (long)_value;
            serializer.TraiteLong(ref nLong);
            _value = (uint)nLong;
            
            serializer.TraiteString(ref _description);

            return result;
        }

        

    }
}