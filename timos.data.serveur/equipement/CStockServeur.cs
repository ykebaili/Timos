using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;

using timos.securite;

namespace timos.data
{
	/// <summary>
	/// Description résumée de CStockServeur.
	/// </summary>
	public class CStockServeur : CObjetServeur
	{
		//-------------------------------------------------------------------
#if PDA
		public CStockServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CStockServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CStock.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CStock stock = (CStock)objet;

				if ( stock.Libelle == "")
					result.EmpileErreur(I.T("Stock label cannot be empty|111"));
				if (!CObjetDonneeAIdNumerique.IsUnique(stock, CStock.c_champLibelle, stock.Libelle))
					result.EmpileErreur(I.T( "Another Stock with the same label already exists|112"));
				if ( stock.TypeStock == null )
					result.EmpileErreur(I.T("Stock Type cannot be empty|116"));
				if (stock.Site == null)
					result.EmpileErreur(I.T( "The Stock related Site cannot be empty|117"));

				if (result)
					result = SObjetAFilsACoordonneeServeur.VerifieDonnees(stock);

				if (result)
					result = stock.VerifieCoordonnee();


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
			return typeof(CStock);
		}
		//-------------------------------------------------------------------
		public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
		{
			CResultAErreur result = base.TraitementAvantSauvegarde(contexte);
			if (!result)
				return result;

			DataTable dt = contexte.Tables[CStock.c_nomTable];
			ArrayList rows = new ArrayList(dt.Rows);
			foreach (DataRow dr in rows)
			{
				if (dr.RowState == DataRowState.Modified || dr.RowState == DataRowState.Added)
				{
					CStock stock = new CStock(dr);
					result =SObjetAFilsACoordonneeServeur.TraitementAvantSauvegarde(stock);
					if (!result)
						return result;
				}
			}



			return result;
		}
	}
}
