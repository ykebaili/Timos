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

namespace timos.securite
{
	/// <summary>
	/// Description résumée de Class1.
	/// </summary>
	public class CRelationElement_RestrictionSpecifique_ApplicationServeur : CObjetServeur
	{
		/// //////////////////////////////////////////////////
#if PDA
		public CRelationElement_RestrictionSpecifique_ApplicationServeur()
			:base ()
		{
			
		}
#endif
		/// //////////////////////////////////////////////////
		public CRelationElement_RestrictionSpecifique_ApplicationServeur( int nIdSession )
			:base ( nIdSession )
		{
			
		}

		//////////////////////////////////////////////////////////////////////
		public override string GetNomTable()
		{
			return CRelationElement_RestrictionSpecifique_Application.c_nomTable;
		}

		//////////////////////////////////////////////////////////////////////
		public override Type GetTypeObjets()
		{
			return typeof(CRelationElement_RestrictionSpecifique_Application);
		}

		//////////////////////////////////////////////////////////////////////
        public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
        {
            CResultAErreur result = CResultAErreur.True;
            try
            {
                CRelationElement_RestrictionSpecifique_Application rel = (CRelationElement_RestrictionSpecifique_Application)objet;

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
