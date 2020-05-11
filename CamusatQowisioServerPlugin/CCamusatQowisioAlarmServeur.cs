using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.data.serveur;
using CamusatQowisioClientPlugin;
using sc2i.common;
using sc2i.data;

namespace CamusatQowisioServerPlugin
{
    public class CCamusatQowisioAlarmServeur : CObjetServeur
    {
        public CCamusatQowisioAlarmServeur(int nIdSession)
            :base(nIdSession)
        {
        }

        public override string GetNomTable()
        {
            return CCamusatQowisioAlarm.c_nomTable;
        }

        public override Type GetTypeObjets()
        {
            return typeof(CCamusatQowisioAlarm);
        }

        public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
        {
            CResultAErreur result = CResultAErreur.True;

            return result;
        }

        public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
        {
            return base.TraitementAvantSauvegarde(contexte);
        }

    }
}
