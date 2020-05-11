using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;

using timos.acteurs;
using sc2i.workflow;




namespace timos.acteurs.serveur
{
	/// <summary>
	/// Description rÃ©sumÃ©e de CRestrictionChampCustomServeur.
	/// </summary>
	public class CRestrictionChampCustomServeur : CObjetServeur
	{
		public const int c_nRestrictionPDA = 7;


		//-------------------------------------------------------------------
		/// <summary>
		/// CrÃ©Ã©e les restrictions par dÃ©faut
		/// </summary>
		/// <param name="nIdSession"></param>
		public static void CreateDefaultRestrictions( int nIdSession )
		{
			using ( CContexteDonnee contexte = new CContexteDonnee ( nIdSession, true, false ) )
			{
				CRestrictionChampCustom rest = new CRestrictionChampCustom ( contexte );
				if ( !rest.ReadIfExists ( new CFiltreData (CRestrictionChampCustom.c_champValeurFlag+"=7" ) ) )
				{
					rest.CreateNew ();
					rest.ValeurFlag = c_nRestrictionPDA;
					rest.Libelle = "PDA";
					rest.CommitEdit();
				}
			}
		}


		//-------------------------------------------------------------------
		public CRestrictionChampCustomServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CRestrictionChampCustom.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CRestrictionChampCustom flag = (CRestrictionChampCustom)objet;

				if ( flag.Libelle == "" )
					result.EmpileErreur(I.T("Flag label cannot be empty|280"));
				if (!CObjetDonneeAIdNumerique.IsUnique(flag, CRestrictionChampCustom.c_champValeurFlag, flag.ValeurFlag.ToString()))
				{
					result.EmpileErreur(I.T("A flag already exist with this value|281"));
				}
				if ( flag.ValeurFlag > 31 || flag.ValeurFlag <1 )
					result.EmpileErreur(I.T("Flag value must be ranking between 1 and 31|282"));
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
			return typeof(CRestrictionChampCustom);
		}
		//-------------------------------------------------------------------
		public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
		{
			CResultAErreur result = base.TraitementAvantSauvegarde (contexte);
			if ( !result )
				return result;
			DataTable table = contexte.Tables[GetNomTable()];
			if ( table == null )
				return result;
			ArrayList lst = new ArrayList ( table.Rows );
			foreach ( DataRow row in lst )
			{
				if ( row.RowState == DataRowState.Modified || row.RowState == DataRowState.Deleted )
				{
					CRestrictionChampCustom rest = new CRestrictionChampCustom ( row );
					rest.VersionToReturn = DataRowVersion.Original;
					int nOldFlag = rest.ValeurFlag;
					rest.VersionToReturn = DataRowVersion.Default;
					if ( nOldFlag == c_nRestrictionPDA )
					{
						if ( row.RowState == DataRowState.Deleted )
						{
							result.EmpileErreur(I.T("Cannot delete restriction related to PDA|283"));
							return result;
						}
						rest.ValeurFlag = c_nRestrictionPDA;
					}
				}
			}
			return result;
		}

	}
}
