using System;
using System.Collections;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.securite;

namespace timos.securite.serveur
{
	/// <summary>
	/// Description résumée de CRelationTypeEO_FormulaireParTypeServeur.
	/// </summary>
	public class CRelationTypeEO_FormulaireParTypeServeur : CObjetServeur
	{
		//-------------------------------------------------------------------
		//-------------------------------------------------------------------
		public CRelationTypeEO_FormulaireParTypeServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CRelationTypeEO_FormulaireParType.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CRelationTypeEO_FormulaireParType rel = (CRelationTypeEO_FormulaireParType)objet;


				if (rel.TypeEntiteOrganisationnelle == null )
					result.EmpileErreur(I.T("The Organisational Entity Type cannot be null|298"));
				if (rel.Formulaire== null)
					result.EmpileErreur(I.T("The form cannot be null|299"));
			}
			catch ( Exception e )
			{
				result.EmpileErreur( new CErreurException ( e ) );
			}
			return result;
		}
		//-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
			return typeof(CRelationTypeEO_FormulaireParType);
		}
		//-------------------------------------------------------------------
	}
}
