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

namespace timos.securite
{
	/// <summary>
	/// Description résumée de Class1.
	/// </summary>
    public class CExceptionTypePourTypeEOServeur : CObjetServeur
	{

		/// //////////////////////////////////////////////////
		public CExceptionTypePourTypeEOServeur( int nIdSession )
			:base ( nIdSession )
		{
			
		}

		//////////////////////////////////////////////////////////////////////
		public override string GetNomTable()
		{
			return CExceptionTypePourTypeEO.c_nomTable;
		}

		//////////////////////////////////////////////////////////////////////
		public override Type GetTypeObjets()
		{
			return typeof(CExceptionTypePourTypeEO);
		}

		//////////////////////////////////////////////////////////////////////
		public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{	
				CExceptionTypePourTypeEO exception = (CExceptionTypePourTypeEO)objet;

                if (exception.TypeEntiteOrganisationnelle == null)
                    result.EmpileErreur(I.T("Exception must be linked to an Organizational Entity Type|10010"));

                if (exception.TypeEntiteOrganisationnelle != null && exception.TypeElement == null)
                    result.EmpileErreur(I.T("Exception for OE Type @1 must be related to an Element Type|10009", exception.TypeEntiteOrganisationnelle.Libelle));

				return result;
			}
			catch ( Exception e )
			{
				result.EmpileErreur(new CErreurException(e));
			}
			return result;
				
		}

	}
}
