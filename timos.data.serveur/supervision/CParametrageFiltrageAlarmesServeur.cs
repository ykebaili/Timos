using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;

using timos.acteurs;
using timos.securite;
using timos.data.supervision;

namespace timos.data.serveur.supervision
{
    /// <summary>
    /// Description résumée de CParametrageFiltrageAlarmes.
    /// </summary>
    public class CParametrageFiltrageAlarmesServeur : CObjetServeurAvecBlob
    {
        //-------------------------------------------------------------------
#if PDA
		public CParametrageFiltrageAlarmes()
			:base()
		{
		}
#endif
        //-------------------------------------------------------------------
        public CParametrageFiltrageAlarmesServeur(int nIdSession)
            : base(nIdSession)
        {
        }

        //-------------------------------------------------------------------
        public override string GetNomTable()
        {
            return CParametrageFiltrageAlarmes.c_nomTable;
        }

        //-------------------------------------------------------------------
        public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
        {
            CResultAErreur result = CResultAErreur.True;
            try
            {
                CParametrageFiltrageAlarmes parametre = (CParametrageFiltrageAlarmes)objet;
                if (parametre.Libelle == string.Empty)
                    result.EmpileErreur(I.T("The Label can not be empty|181"));

                if (parametre.CategorieMasquage == null)
                    result.EmpileErreur(I.T("The Masking Category can not be null|10025"));

            }
            catch (Exception e)
            {
                result.EmpileErreur(new CErreurException(e));
            }
            return result;
        }

        //-------------------------------------------------------------------
        public override Type GetTypeObjets()
        {
            return typeof(CParametrageFiltrageAlarmes);
        }

        public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
        {
            return base.TraitementAvantSauvegarde(contexte);

        }

        public override CResultAErreur TraitementApresSauvegarde(CContexteDonnee contexte, bool bOperationReussie)
        {
            return base.TraitementApresSauvegarde(contexte, bOperationReussie);
        }

        
        
    }
}
