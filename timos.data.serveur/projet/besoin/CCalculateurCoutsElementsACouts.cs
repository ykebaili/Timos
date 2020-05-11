using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using sc2i.data;
using System.Collections;
using timos.data.projet.besoin;
using sc2i.data.serveur;

namespace timos.data.serveur.projet.besoin
{
    [AutoExec("Autoexec")]
    public class CCalculateurCoutsElementsACouts
    {
        public static void Autoexec()
        {
            //Insertion au début pour que les évenements se déclenchent bien
            CContexteDonneeServeur.InsertTraitementAvantSauvegarde(new TraitementSauvegardeExterne(CalculeCoutEnTraitementAvantSauvegarde));
        }

        public static CResultAErreur CalculeCoutEnTraitementAvantSauvegarde(CContexteDonnee ctxDonnee, Hashtable tableDatas)
        {
            return CUtilElementACout.RecalculeCoutsARecalculer(ctxDonnee);
        }
    }
}
