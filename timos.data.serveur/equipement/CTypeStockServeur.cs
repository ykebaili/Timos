using System;
using System.Collections;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;



namespace timos.data
{
	/// <summary>
	/// Description résumée de CTypeStockServeur.
	/// </summary>
	public class CTypeStockServeur : CObjetServeur
	{
		//-------------------------------------------------------------------
#if PDA
		public CTypeStockServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CTypeStockServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CTypeStock.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CTypeStock TypeStock = (CTypeStock)objet;

				if ( TypeStock.Libelle == "")
					result.EmpileErreur(I.T("The stock type label can not be empty|114"));
				if (!CObjetDonneeAIdNumerique.IsUnique(TypeStock, CTypeStock.c_champLibelle, TypeStock.Libelle))
					result.EmpileErreur(I.T( "Another Stock Type with the same name already exists|115"));
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
			return typeof(CTypeStock);
		}
		//-------------------------------------------------------------------
	}
}
