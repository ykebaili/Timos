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
	public class CRelationBesoinQuantite_ElementServeur : CObjetServeur
	{
		/// //////////////////////////////////////////////////
#if PDA
		public CRelationBesoinQuantite_ElementServeur()
			:base ()
		{
			
		}
#endif
		/// //////////////////////////////////////////////////
		public CRelationBesoinQuantite_ElementServeur( int nIdSession )
			:base ( nIdSession )
		{
			
		}

		//////////////////////////////////////////////////////////////////////
		public override string GetNomTable()
		{
			return CRelationBesoinQuantite_Element.c_nomTable;
		}

		//////////////////////////////////////////////////////////////////////
		public override Type GetTypeObjets()
		{
			return typeof(CRelationBesoinQuantite_Element);
		}

		//////////////////////////////////////////////////////////////////////
        public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
        {
            CResultAErreur result = CResultAErreur.True;
            try
            {
                CRelationBesoinQuantite_Element rel = (CRelationBesoinQuantite_Element)objet;

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
