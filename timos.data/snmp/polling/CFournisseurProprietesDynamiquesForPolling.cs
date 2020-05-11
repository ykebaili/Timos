using sc2i.data.dynamic;
using sc2i.expression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timos.data.snmp.polling
{
    public class CFournisseurProprietesDynamiquesForPolling : IFournisseurProprietesDynamiques
    {
        private CTypeEntiteSnmp m_typeEntite = null;

        //-------------------------------------------------------------------------------
        public CFournisseurProprietesDynamiquesForPolling ( CTypeEntiteSnmp typeEntite )
        {
            m_typeEntite = typeEntite;
        }

        //-------------------------------------------------------------------------------
        public CDefinitionProprieteDynamique[] GetDefinitionsChamps(CObjetPourSousProprietes objet, CDefinitionProprieteDynamique defParente)
        {
            return GetDefinitionsChamps(objet);
        }

        //-------------------------------------------------------------------------------
        public CDefinitionProprieteDynamique[] GetDefinitionsChamps(CObjetPourSousProprietes objet)
        {
            return GetDefinitionsChamps(typeof(CEntiteSnmp), 0);
        }

        //-------------------------------------------------------------------------------
        public CDefinitionProprieteDynamique[] GetDefinitionsChamps(Type typeInterroge, int nNbNiveaux, CDefinitionProprieteDynamique defParente)
        {
            return GetDefinitionsChamps(typeof(CEntiteSnmp), 0);
        }

        //-------------------------------------------------------------------------------
        public CDefinitionProprieteDynamique[] GetDefinitionsChamps(Type typeInterroge, int nNbNiveaux)
        {
            List<CDefinitionProprieteDynamique> lst = new List<CDefinitionProprieteDynamique>();

            foreach (CChampEntiteFromQueryToChampCustom champ in m_typeEntite.ChampsFromQueryList)
            {
                champ.ContexteDonneePourChamp = m_typeEntite.ContexteDonnee;
                CChampCustom chCust = champ.ChampCustom;
                if (chCust != null)
                    lst.Add(new CDefinitionProprieteDynamiqueChampCustom(chCust));
            }
            return lst.ToArray();
        }

    }
}
