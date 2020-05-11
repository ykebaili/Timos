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
    /// Description résumée de CParametrageAffichageListeAlarmes.
    /// </summary>
    public class CParametrageAffichageListeAlarmesServeur : CObjetServeurAvecBlob
    {
        //-------------------------------------------------------------------
#if PDA
		public CParametrageAffichageListeAlarmes()
			:base()
		{
		}
#endif
        //-------------------------------------------------------------------
        public CParametrageAffichageListeAlarmesServeur(int nIdSession)
            : base(nIdSession)
        {
        }

        //-------------------------------------------------------------------
        public override string GetNomTable()
        {
            return CParametrageAffichageListeAlarmes.c_nomTable;
        }

        //-------------------------------------------------------------------
        public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
        {
            CResultAErreur result = CResultAErreur.True;
            try
            {
                CParametrageAffichageListeAlarmes parametre = (CParametrageAffichageListeAlarmes)objet;
                if (parametre.Libelle == string.Empty)
                    result.EmpileErreur(I.T("Alarm Display Setting Label cannot be empty|10024"));

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
            return typeof(CParametrageAffichageListeAlarmes);
        }

        
    }
}
