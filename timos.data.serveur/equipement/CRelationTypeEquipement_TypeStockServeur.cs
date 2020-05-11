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
	/// Description résumée de CRelationTypeEquipement_StockServeur.
	/// </summary>
	public class CRelationTypeEquipement_TypeStockServeur : CObjetServeur
	{

		//-------------------------------------------------------------------
#if PDA
		public CRelationTypeEquipement_StockServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationTypeEquipement_TypeStockServeur( int nIdSession )
			:base ( nIdSession )
		{
		}

		
		/// ////////////////////////////////////////////////////////////
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CRelationTypeEquipement_TypeStock relation = (CRelationTypeEquipement_TypeStock)objet;
				if ( relation.TypeEquipement == null )
					result.EmpileErreur(I.T( "The Equipment type cannot be null|109"));
				if ( relation.TypeStock == null )
					result.EmpileErreur(I.T( "The Stock type cannot be null|113"));
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
			return CRelationTypeEquipement_TypeStock.c_nomTable;
		}


		/// ////////////////////////////////////////////////////////////
		public override Type GetTypeObjets()
		{
			return typeof(CRelationTypeEquipement_TypeStock);
		}

		

	}
}
