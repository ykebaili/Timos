/*
 * Created by SharpDevelop.
 * User: lextm
 * Date: 2008/5/31
 * Time: 13:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Collections.Generic;
using sc2i.common;

namespace futurocom.snmp.Mib
{
    /// <summary>
    /// The AGENT-CAPABILITIES construct is used to specify implementation characteristics of an SNMP agent sub-system with respect to object types and events.
    /// </summary>
    internal sealed class AgentCapabilities : IEntity
    {
        private string _module;
        private string _name;
        private string _parent;
        private uint _value;
        private string _description;

        public AgentCapabilities()
        {
        }
        
        /// <summary>
        /// Creates an <see cref="AgentCapabilities"/> instance.
        /// </summary>
        /// <param name="module"></param>
        /// <param name="header"></param>
        /// <param name="lexer"></param>
        public AgentCapabilities(string module, IList<Symbol> header, Lexer lexer)
        {
            _module = module;
            _name = header[0].ToString();
            lexer.ParseOidValue(out _parent, out _value);
            _description = header.GetSingleValueString(Symbol.Description, "");
        }
        
        /// <summary>
        /// Module name.
        /// </summary>
        public string ModuleName
        {
            get { return _module; }
        }
      
        /// <summary>
        /// Name.
        /// </summary>
        public string Name
        {
            get { return _name; }
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
            get { return _value; }
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
            serializer.TraiteString(ref _parent);

            long nTmp = (long)_value;
            serializer.TraiteLong(ref nTmp);
            _value = (uint)nTmp;

            serializer.TraiteString(ref _name);
            serializer.TraiteString(ref _description);

            return result;
        }
    }
}