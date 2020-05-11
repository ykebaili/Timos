using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;

using timos.securite;
using System.Collections.Generic;

namespace timos.data.projet.besoin
{
    /// <summary>
    /// Description résumée de CPhaseSpecificationsServeur.
    /// </summary>
    public class CPhaseSpecificationsServeur : CObjetServeur
    {
        //-------------------------------------------------------------------
#if PDA
		public CPhaseSpecificationsServeur()
			:base()
		{
		}
#endif
        //-------------------------------------------------------------------
        public CPhaseSpecificationsServeur(int nIdSession)
            : base(nIdSession)
        {
        }
        //-------------------------------------------------------------------
        public override string GetNomTable()
        {
            return CPhaseSpecifications.c_nomTable;
        }
        //-------------------------------------------------------------------
        public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
        {
            CResultAErreur result = CResultAErreur.True;
            try
            {
                CPhaseSpecifications PhaseSpecifications = (CPhaseSpecifications)objet;

                if(PhaseSpecifications.Libelle == null || PhaseSpecifications.Libelle == "")
                    result.EmpileErreur(I.T( "Needs specification label should not be empty|20189"));
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
            return typeof(CPhaseSpecifications);
        }

        
    }
}
