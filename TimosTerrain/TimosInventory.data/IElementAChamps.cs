using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common.memorydb;

namespace TimosInventory.data
{
    /// <summary>
    /// Description résumée de IElementAChamps.
    /// </summary>
    public interface IElementAChamps : IEntiteDeMemoryDb
    {
        //Retourne des objets de type CRelationElementAChamp_ChampCustom
        CListeEntitesDeMemoryDbBase RelationsChampsCustom { get; }

        object GetValeurChamp(string strIdChamp);
        void SetValeurChamp(string strIdChamp, object valeur);

        CRelationElementAChamp_ChampCustom GetNewRelationToChamp();

    }


    public static class CUtilElementAChamps
    {
        //----------------------------------------------------------------------------------------------
        public static CRelationElementAChamp_ChampCustom GetRelationToChamp(IElementAChamps eltAChamps, string strIdChamp)
        {
            CListeEntitesDeMemoryDbBase lst = eltAChamps.RelationsChampsCustom;
            lst.Filtre = new CFiltreMemoryDb(CChampCustom.c_champId + "=@1", strIdChamp);
            foreach (CRelationElementAChamp_ChampCustom rel in lst)
                return rel;
            return null;
        }

        //----------------------------------------------------------------------------------------------
        public static object GetValeurChamp(IElementAChamps eltAChamps, string strIdChamp)
        {
            CRelationElementAChamp_ChampCustom rel = GetRelationToChamp(eltAChamps, strIdChamp);
            if (rel != null)
                return rel.GetValeur();
            return null;
        }

        //----------------------------------------------------------------------------------------------
        public static void SetValeurChamp(IElementAChamps eltAChamps, string strIdChamp, object valeur)
        {
            CRelationElementAChamp_ChampCustom rel = GetRelationToChamp(eltAChamps, strIdChamp);
            if (rel == null)
            {
                rel = eltAChamps.GetNewRelationToChamp();
                rel.CreateNew();
                rel.Row[CChampCustom.c_champId] = strIdChamp;
                rel.ElementAChamps = eltAChamps;
            }
            rel.Valeur = valeur;
        }
    }


}
