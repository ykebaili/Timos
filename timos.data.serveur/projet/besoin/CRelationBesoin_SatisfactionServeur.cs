using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;

using sc2i.common;
using sc2i.data;
using sc2i.data.serveur;
using sc2i.data.dynamic;
using timos.acteurs;
using sc2i.multitiers.client;
using timos.securite;
using timos.data.securite;

namespace timos.data.projet.besoin
{
	/// <summary>
	/// Description résumée de Class1.
	/// </summary>
	public class CRelationBesoin_SatisfactionServeur : CObjetServeur
	{
		/// //////////////////////////////////////////////////
#if PDA
		public CRelationBesoin_SatisfactionServeur()
			:base ()
		{
			
		}
#endif
		/// //////////////////////////////////////////////////
		public CRelationBesoin_SatisfactionServeur( int nIdSession )
			:base ( nIdSession )
		{
			
		}

		//////////////////////////////////////////////////////////////////////
		public override string GetNomTable()
		{
			return CRelationBesoin_Satisfaction.c_nomTable;
		}

		//////////////////////////////////////////////////////////////////////
		public override Type GetTypeObjets()
		{
			return typeof(CRelationBesoin_Satisfaction);
		}

		//////////////////////////////////////////////////////////////////////
        public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
        {
            CResultAErreur result = CResultAErreur.True;
            try
            {
                CRelationBesoin_Satisfaction rel = (CRelationBesoin_Satisfaction)objet;

                return result;
            }
            catch (Exception e)
            {
                result.EmpileErreur(new CErreurException(e));
            }
            return result;

        }

	}
}
