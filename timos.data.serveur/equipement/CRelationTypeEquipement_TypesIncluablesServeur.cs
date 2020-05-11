using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;

using sc2i.workflow.serveur;

namespace timos.data
{
	/// <summary>
	/// Description résumée de CRelationTypeEquipement_TypesIncluablesServeur.
	/// </summary>
	public class CRelationTypeEquipement_TypesIncluablesServeur : CObjetServeur
	{

		//-------------------------------------------------------------------
#if PDA
		public CRelationTypeEquipement_TypesIncluablesServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationTypeEquipement_TypesIncluablesServeur( int nIdSession )
			:base ( nIdSession )
		{
		}

		
		/// ////////////////////////////////////////////////////////////
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CRelationTypeEquipement_TypesIncluables relation = (CRelationTypeEquipement_TypesIncluables)objet;
				if ( relation.TypeIncluant == null )
					result.EmpileErreur(I.T("The including type must be defined|251"));
				if ( relation.TypeInclu == null )
					result.EmpileErreur(I.T("The included type must be defined|252"));
			}
			catch ( Exception e )
			{
				result.EmpileErreur( new CErreurException(e));
			}
			return result;
		}

		/// ////////////////////////////////////////////////////////////
		public override string GetNomTable()
		{
			return CRelationTypeEquipement_TypesIncluables.c_nomTable;
		}


		/// ////////////////////////////////////////////////////////////
		public override Type GetTypeObjets()
		{
			return typeof(CRelationTypeEquipement_TypesIncluables);
		}

		

	}
}
