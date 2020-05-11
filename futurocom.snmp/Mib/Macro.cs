using System.Collections.Generic;
using sc2i.common;

namespace futurocom.snmp.Mib
{

    internal sealed class Macro : ITypeAssignment
    {
        private string _name;

        public Macro()
        { 
        }

        public SnmpType SnmpType
        {
            get
            {
                return SnmpType.Unknown;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1804:RemoveUnusedLocals", MessageId = "temp")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "module")]
        public Macro(string module, IList<Symbol> header, Lexer lexer)
        {
            _name = header[0].ToString();
            Symbol temp;
            while ((temp = lexer.NextSymbol) != Symbol.Begin)
            {                
            }
            
            while ((temp = lexer.NextSymbol) != Symbol.End)
            {
            }
        }

        public string Name
        {
            get { return _name; }
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
           
            return result;
        }
    }
}