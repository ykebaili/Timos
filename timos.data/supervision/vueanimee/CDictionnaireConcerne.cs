using System;
using System.Collections.Generic;
using System.Text;
using timos.data.reseau.arbre_operationnel;
using sc2i.common;

namespace timos.data.supervision.vueanimee
{
    internal class CDictionnaireConcerne : Dictionary<CDbKey, List<CInfoElementDeSchemaSupervise>>
    {
        public CDictionnaireConcerne()
        {
        }

        public void Add(CDbKey nIdElement, CInfoElementDeSchemaSupervise info)
        {
            List<CInfoElementDeSchemaSupervise> lst = null;
            if (!TryGetValue(nIdElement, out lst))
            {
                lst = new List<CInfoElementDeSchemaSupervise>();
                this[nIdElement] = lst;
            }
            if (!lst.Contains(info))
                lst.Add(info);
        }


    }

    /////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// 
    /// </summary>
    public class CDictionnaireElementToNoeudArbre : Dictionary<CDbKey, List<CElementDeArbreOperationnel>>
    {
        public CDictionnaireElementToNoeudArbre()
        {
        }

        public void Add(CDbKey nIdElement, CElementDeArbreOperationnel info)
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
