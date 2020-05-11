using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.expression;
using sc2i.common;
using sc2i.data;
using sc2i.data.dynamic;
using sc2i.common.memorydb;
using futurocom.supervision;

namespace timos.data.supervision
{
    public class CFournisseurProprietesAlarmeLocale : IFournisseurProprietesDynamiques
    {

        public CDefinitionProprieteDynamique[] GetDefinitionsChamps(CObjetPourSousProprietes objet, CDefinitionProprieteDynamique defParente)
        {
            List<CDefinitionProprieteDynamique> listeProps = new List<CDefinitionProprieteDynamique>();
            listeProps.AddRange(new CFournisseurGeneriqueProprietesDynamiques().GetDefinitionsChamps(objet, defParente));

            if (objet.TypeAnalyse == typeof(CLocalAlarme))
            {
                CListeObjetsDonnees lstChamps = new CListeObjetsDonnees(CContexteDonneeSysteme.GetInstance(), typeof(CChampCustom));
                lstChamps.Filtre = CChampCustom.GetFiltreChampsForRole(CAlarme.c_roleChampCustom);

                CMemoryDb db = new CMemoryDb();

                foreach (CChampCustom champ in lstChamps)
                {
                    CLocalChampTypeAlarme localChamp = CTypeAlarme.GetChampTypeAlarme(db, champ);
                    listeProps.Add(new CDefinitionProprieteDynamiqueChampAlarme(localChamp));
                }
            }

            return listeProps.ToArray();
        }

        public CDefinitionProprieteDynamique[] GetDefinitionsChamps(CObjetPourSousProprietes objet)
        {
            return GetDefinitionsChamps(objet, null);
        }

        public CDefinitionProprieteDynamique[] GetDefinitionsChamps(Type typeInterroge, int nNbNiveaux, CDefinitionProprieteDynamique defParente)
        {
            return GetDefinitionsChamps(new CObjetPourSousProprietes(typeInterroge), defParente);
        }

        public CDefinitionProprieteDynamique[] GetDefinitionsChamps(Type typeInterroge, int nNbNiveaux)
        {
            return GetDefinitionsChamps(new CObjetPourSousProprietes(typeInterroge));
        }

     
    }

    [AutoExec("Autoexec")]
    public class CFournisseurSpecifiqueChampsAlarmeLocale : IFournisseurProprieteDynamiquesSimplifie
    {
        public static void Autoexec()
        {
            CFournisseurGeneriqueProprietesDynamiques.RegisterTypeFournisseur(new CFournisseurSpecifiqueChampsAlarmeLocale());
        }

        public CDefinitionProprieteDynamique[] GetDefinitionsChamps(CObjetPourSousProprietes objet, CDefinitionProprieteDynamique defParente)
        {
            List<CDefinitionProprieteDynamique> listeProps = new List<CDefinitionProprieteDynamique>();
            if (objet.TypeAnalyse != null && objet.TypeAnalyse == typeof(CLocalAlarme))
            {
                CListeObjetsDonnees lstChamps = new CListeObjetsDonnees(CContexteDonneeSysteme.GetInstance(), typeof(CChampCustom));
                lstChamps.Filtre = CChampCustom.GetFiltreChampsForRole(CAlarme.c_roleChampCustom);

                using (CMemoryDb db = new CMemoryDb())
                {

                    foreach (CChampCustom champ in lstChamps)
                    {
                        CLocalChampTypeAlarme localChamp = CTypeAlarme.GetChampTypeAlarme(db, champ);
                        listeProps.Add(new CDefinitionProprieteDynamiqueChampAlarme(localChamp));
                    }
                }
            }
            return listeProps.ToArray();
        }
    }

}
