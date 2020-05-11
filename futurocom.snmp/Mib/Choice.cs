/*
 * Created by SharpDevelop.
 * User: lextm
 * Date: 2008/5/31
 * Time: 11:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using sc2i.common;
namespace futurocom.snmp.Mib
{
    /// <summary>
    /// The CHOICE type represents a list of alternatives..
    /// </summary>
    internal sealed class Choice : ITypeAssignment
    {
        private string _name;

        public Choice()
        {
        }

        public SnmpType SnmpType
        {
            get
            {
                return SnmpType.Unknown;
            }
        }

        /// <summary>
        /// Creates a <see cref="Choice"/> instance.
        /// </summary>
        /// <param name="module"></param>
        /// <param name="name"></param>
        /// <param name="lexer"></param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "module")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1804:RemoveUnusedLocals", MessageId = "temp")]
        public Choice(string module, string name, Lexer lexer)
        {
            _name = name;

            Symbol temp;
            while ((temp = lexer.NextSymbol) != Symbol.OpenBracket)
            {
            }
            
            while ((temp = lexer.NextSymbol) != Symbol.CloseBracket)
            {
            }
        }

        public string Name
        {
            get { return _name; }
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
            serializer.TraiteString(ref _name);
            return result;
        }
    }
}