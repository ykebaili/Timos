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
	/// Description rÃ©sumÃ©e de CRelationTypeEquipement_StockServeur.
	/// </summary>
	public class CRemplacementEquipementServeur : CObjetServeur
	{

		//-------------------------------------------------------------------
#if PDA
		public CRelationTypeEquipement_StockServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRemplacementEquipementServeur( int nIdSession )
			:base ( nIdSession )
		{
		}

		
		/// ////////////////////////////////////////////////////////////
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CRemplacementEquipement remplacement = (CRemplacementEquipement)objet;
				if ( remplacement.EquipementRemplace == null )
					result.EmpileErreur(I.T( "The replaced equipment must be defined|253"));
				if (remplacement.EmplacementDestination == null)
					result.EmpileErreur(I.T("The site of the equipment must be defined|254"));
					
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
			return CRemplacementEquipement.c_nomTable;
		}


		/// ////////////////////////////////////////////////////////////
		public override Type GetTypeObjets()
		{
			return typeof(CRemplacementEquipement);
		}

		

		

	}
}
