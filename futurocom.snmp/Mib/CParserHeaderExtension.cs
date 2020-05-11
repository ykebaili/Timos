using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace futurocom.snmp.Mib
{
    public static class CParserHeaderExtension
    {
        //-------------------------------------------------------------------------------------
        public static int? GetSymbolIndex ( this IList<Symbol> liste, Symbol symboleCherche )
        {
            int nPos = liste.IndexOf(symboleCherche);
            if ( nPos >= 0 )
                return nPos;
            return null;
        }

        //-------------------------------------------------------------------------------------
        public static Symbol[] GetValuesAvecAccolades (this IList<Symbol> liste, Symbol symboleCherche )
        {
            List<Symbol> lst = new List<Symbol>();
            int? nPos = liste.GetSymbolIndex ( symboleCherche );
            if (nPos != null)
            {
                //Vérifie que la valeur suivante est bien une accolade ouvrante
                if (liste.Count <= nPos.Value + 1)
                    return lst.ToArray();
                Symbol s = liste[nPos.Value + 1];
                s.Expect(Symbol.OpenBracket);
                int n = nPos.Value + 2;
                while (n < liste.Count && liste[n] != Symbol.CloseBracket)
                {
                    s = liste[n++];
                    if (s != Symbol.Comma)
                        lst.Add(s);
                }
            }
            return lst.ToArray();
        }

        //-------------------------------------------------------------------------------------
        public static string[] GetValuesStringAvecAccolades(this IList<Symbol> liste, Symbol symboleCherche)
        {
            List<string> lst = new List<string>();
            foreach ( Symbol s in liste.GetValuesAvecAccolades ( symboleCherche ) )
                lst.Add ( s.ToString() );
            return lst.ToArray();
        }

        //-------------------------------------------------------------------------------------
        public static Symbol GetSingleValue(this IList<Symbol> liste, Symbol symboleCherche)
        {
            Symbol value = null;
            int? nPos = liste.GetSymbolIndex(symboleCherche);
            if (nPos != null)
            {
                if (liste.Count > nPos.Value + 1)
                    value = liste[nPos.Value + 1];
            }
            return value;
        }

        //-------------------------------------------------------------------------------------
        public static string GetSingleValueString(this IList<Symbol> liste, Symbol symboleCherche, string strDefault)
        {
            Symbol value = liste.GetSingleValue(symboleCherche);
            if (value != null)
            {
                string strVal = value.ToString();
                if (strVal.StartsWith("\"") && strVal.EndsWith("\""))
                    strVal = strVal.Substring(1).Substring(0, strVal.Length - 2);
                return strVal;
            }
            return strDefault;
        }

    }
}
