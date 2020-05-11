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
	/// Description rÃ©sumÃ©e de CRelationTypeEquipement_FournisseursServeur.
	/// </summary>
	public class CRelationTypeEquipement_FournisseursServeur : CObjetServeur
	{

		//-------------------------------------------------------------------
#if PDA
		public CRelationTypeEquipement_FournisseursServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationTypeEquipement_FournisseursServeur( int nIdSession )
			:base ( nIdSession )
		{
		}

		
		/// ////////////////////////////////////////////////////////////
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CRelationTypeEquipement_Fournisseurs relation = (CRelationTypeEquipement_Fournisseurs)objet;
				if ( relation.TypeEquipement == null )
					result.EmpileErreur(I.T( "The Equipment type cannot be null|109"));
				if ( relation.Fournisseur == null )
					result.EmpileErreur(I.T( "The Supplier cannot be null|110"));
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
			return CRelationTypeEquipement_Fournisseurs.c_nomTable;
		}


		/// ////////////////////////////////////////////////////////////
		public override Type GetTypeObjets()
		{
			return typeof(CRelationTypeEquipement_Fournisseurs);
		}

		

	}
}
