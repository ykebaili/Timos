using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;

using sc2i.data;
using sc2i.data.dynamic;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;
using timos.securite;

namespace timos.data
{
	/// <summary>
	/// Description résumée de CFormatNumerotationServeur.
	/// </summary>
	public class CFormatNumerotationServeur : CObjetDonneeServeurAvecCache
	{
		//-------------------------------------------------------------------
		public CFormatNumerotationServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CFormatNumerotation.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CFormatNumerotation formatNumerotation = (CFormatNumerotation)objet;
				
				if ( formatNumerotation.Libelle == "")
					result.EmpileErreur(I.T("The numbering format label cannot be empty|192"));
				if (!CObjetDonneeAIdNumerique.IsUnique(formatNumerotation, CFormatNumerotation.c_champLibelle, formatNumerotation.Libelle))
					result.EmpileErreur(I.T("The numbering format '@1' already exists|193", formatNumerotation.Libelle));



				//lstcrscfn.Filtre = new CFiltreData(CFormatNumerotation.c_champId + " = @1", CFormatNumerotation.c_champId);

				if (IsUsed(new int[] { formatNumerotation.Id }))
				{
					result.EmpileErreur(I.T( "The numbering format is used by one or more coordinate systems : it cannot be modified|194"));
					return result;
				}

				if (!formatNumerotation.Romain)
				{
					//Longueur Sequence
					if (formatNumerotation.Sequence.Trim().Length < 1)
						result.EmpileErreur(I.T( "The sequence must contain at least two characters|195"));

					//Verifie une redondance de séquence
					foreach (char c in formatNumerotation.Sequence.Trim().ToUpper().ToCharArray())
					{
						if (c == CSystemeCoordonnees.c_separateurNumerotations)
						{
							result.EmpileErreur(I.T( "Bad separator character '@1' |240", CSystemeCoordonnees.c_separateurNumerotations.ToString()));
							break;
						}
						else if (formatNumerotation.Sequence.Trim().ToUpper().IndexOf(c) != formatNumerotation.Sequence.Trim().ToUpper().LastIndexOf(c))
						{
							result.EmpileErreur(I.T( "Invalid sequence due to redundancy|136"));
							break;
						}
					}
				}

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
			return typeof(CFormatNumerotation);
		}

		//-------------------------------------------------------------------
		public bool IsUsed(int[] nIdsFormats)
		{
			if (nIdsFormats.Length == 0)
				return false;
			string strIds = "";
			foreach (int nId in nIdsFormats)
				strIds += nId + ",";
			strIds = strIds.Substring(0, strIds.Length - 1);


			C2iRequeteAvancee requete = new C2iRequeteAvancee(-1);
			requete.TableInterrogee = CSystemeCoordonnees.c_nomTable;
			requete.FiltreAAppliquer = new CFiltreDataAvance(

			CSystemeCoordonnees.c_nomTable,
			CRelationSystemeCoordonnees_FormatNumerotation.c_nomTable + "." +
			CFormatNumerotation.c_champId + " in (" + strIds + ")");

			requete.ListeChamps.Add(new C2iChampDeRequete("ID", new CSourceDeChampDeRequete(CSystemeCoordonnees.c_champId), typeof(int), OperationsAgregation.None, true));
			CResultAErreur result = requete.ExecuteRequete(IdSession);
			if (!result)
				return true;

			DataTable table = (DataTable)result.Data;
			if (table.Rows.Count == 0)
				return false;
			List<int> idsSystemes = new List<int>();
			foreach (DataRow row in table.Rows)
				idsSystemes.Add((int)row[0]);
			CSystemeCoordonneesServeur serveur = new CSystemeCoordonneesServeur(IdSession);
			return serveur.IsUsed(idsSystemes.ToArray());
		}



		//-------------------------------------------------------------------
		public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
		{
			CResultAErreur result = base.TraitementAvantSauvegarde(contexte);
			if (!result)
				return result;
			DataTable table = contexte.Tables[GetNomTable()];
			if (table == null)
				return result;
			ArrayList lst = new ArrayList(table.Rows);
			foreach ( DataRow row in table.Rows )
			{
				if ( row.RowState == DataRowState.Modified )
				{
					if ( IsUsed ( new int[]{(int)row[CFormatNumerotation.c_champId]} ))
					{
						result.EmpileErreur(I.T("The numbering format cannot be modified because it is used|241"));
						return result;
					}
				}
			}
			return result;

		}

	}
}
