/*
 * Created by SharpDevelop.
 * User: lextm
 * Date: 2008/5/31
 * Time: 12:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Collections.Generic;
using sc2i.common;

namespace futurocom.snmp.Mib
{
    /// <summary>
    /// The IMPORTS construct is used to specify items used in the current MIB module which are defined in another MIB module or ASN.1 module.
    /// </summary>
    public sealed class Imports : IConstruct
    {
        private readonly List<string> _dependents = new List<string>();

        public Imports()
        {
        }

        public Imports(IEnumerable<string> dependents)
        {
            _dependents.AddRange(dependents);
        }
        
        /// <summary>
        /// Creates an <see cref="Imports"/> instance.
        /// </summary>
        /// <param name="lexer"></param>
        public Imports(Lexer lexer)
        {
            Symbol temp;
            while ((temp = lexer.NextSymbol) != Symbol.Semicolon)
            {
                if (temp == Symbol.EOL)
                {
                    continue;
                }
                
                _dependents.Add(new ImportsFrom(temp, lexer).Module);
            }
        }
        
        internal IList<string> Dependents
        {
            get
            {
                return _dependents;
            }
        }

        //-----------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //-----------------------------------------------------
        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            int nNb = _dependents == null?0:_dependents.Count;
            serializer.TraiteInt(ref nNb);
            switch (serializer.Mode)
            {
                case ModeSerialisation.Ecriture:
                    if ( _dependents != null )
                        foreach (string strVal in _dependents)
                        {
                            string strTmp = strVal;
                            serializer.TraiteString(ref strTmp);
                        }
                    break;
                case ModeSerialisation.Lecture:
                    _dependents.Clear();
                    for (int i = 0; i < nNb; i++)
                    {
                        string strTmp = "";
                        serializer.TraiteString(ref strTmp);
                        _dependents.Add(strTmp);
                    }
                    break;
            }
            return result;
        }
    }
}