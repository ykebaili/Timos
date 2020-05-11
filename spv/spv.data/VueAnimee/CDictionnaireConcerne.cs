using System;
using System.Collections.Generic;
using System.Text;
using timos.data.reseau.arbre_operationnel;

namespace spv.data.VueAnimee
{
    internal class CDictionnaireConcerne : Dictionary<int, List<CInfoElementDeSchemaSupervise>>
    {
        public CDictionnaireConcerne()
        {
        }

        public void Add(int nIdElementSpv, CInfoElementDeSchemaSupervise info)
        {
            List<CInfoElementDeSchemaSupervise> lst = null;
            if (!TryGetValue(nIdElementSpv, out lst))
            {
                lst = new List<CInfoElementDeSchemaSupervise>();
                this[nIdElementSpv] = lst;
            }
            if (!lst.Contains(info))
                lst.Add(info);
        }


    }

    /////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// 
    /// </summary>
    public class CDictionnaireElementToNoeudArbre : Dictionary<int, List<CElementDeArbreOperationnel>>
    {
        public CDictionnaireElementToNoeudArbre()
        {
        }

        public void Add(int nIdElement, CElementDeArbreOperationnel info)
        {
            List<CElementDeArbreOperationnel> lst = null;
            if (!TryGetValue(nIdElement, out lst))
            {
                lst = new List<CElementDeArbreOperationnel>();
                this[nIdElement] = lst;
            }
            if (!lst.Contains(info))
                lst.Add(info);
        }
         

    }
}
