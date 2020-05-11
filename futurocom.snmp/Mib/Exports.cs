/*
 * Created by SharpDevelop.
 * User: lextm
 * Date: 2008/6/7
 * Time: 17:34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Collections.Generic;
using sc2i.common;

namespace futurocom.snmp.Mib
{
    /// <summary>
    /// Description of Exports.
    /// </summary>
    public sealed class Exports : I2iSerializable
    {
        private readonly IList<string> _types = new List<string>();

        public Exports()
        {
        }
        
        public Exports(Lexer lexer)
        {
            Symbol previous = null;
            Symbol temp;
            while ((temp = lexer.NextSymbol) != Symbol.Semicolon) 
            {
                if (temp == Symbol.EOL) 
                {
                    continue;
                }
                
                if (temp == Symbol.Comma && previous != null) 
                {
                    previous.ValidateIdentifier();
                    _types.Add(previous.ToString());
                }
                
                previous = temp;
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
            int nNb = _types == null?0:_types.Count;
            serializer.TraiteInt(ref nNb);
            switch (serializer.Mode)
            {
                case ModeSerialisation.Ecriture:
                    if ( _types != null )
                        foreach (string strVal in _types)
                        {
                            string strTmp = strVal;
                            serializer.TraiteString(ref strTmp);
                        }
                    break;
                case ModeSerialisation.Lecture:
                    _types.Clear();
                    for (int i = 0; i < nNb; i++)
                    {
                        string strTmp = "";
                        serializer.TraiteString(ref strTmp);
                        _types.Add(strTmp);
                    }
                    break;
            }
            return result;
        }
    }
}