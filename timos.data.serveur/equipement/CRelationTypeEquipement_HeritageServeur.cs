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
	/// Description résumée de CTypeEquipementHeritageServeur.
	/// </summary>
	public class CRelationTypeEquipement_HeritageServeur : CObjetServeur
	{

		//-------------------------------------------------------------------
#if PDA
		public CTypeEquipementHeritageServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationTypeEquipement_HeritageServeur( int nIdSession )
			:base ( nIdSession )
		{
		}

		
		/// ////////////////////////////////////////////////////////////
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CRelationTypeEquipement_Heritage relation = (CRelationTypeEquipement_Heritage)objet;
				if ( relation.TypeParent == null )
					result.EmpileErreur(I.T("The parent type must be defined|249"));
				if ( relation.TypeFils == null )
					result.EmpileErreur(I.T("The child type must be defined|250"));
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
			return CRelationTypeEquipement_Heritage.c_nomTable;
		}


		/// ////////////////////////////////////////////////////////////
		public override Type GetTypeObjets()
		{
			return typeof(CRelationTypeEquipement_Heritage);
		}

		

	}
}
