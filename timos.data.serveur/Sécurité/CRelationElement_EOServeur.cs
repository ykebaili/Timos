using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;

using sc2i.common;
using sc2i.data;
using sc2i.data.serveur;
using sc2i.data.dynamic;
using timos.acteurs;
using sc2i.multitiers.client;
using timos.securite;

namespace timos.securite
{
	/// <summary>
	/// Description résumée de Class1.
	/// </summary>
	public class CRelationElement_EOServeur : CObjetServeur
	{
		/// //////////////////////////////////////////////////
#if PDA
		public CRelationElement_EOServeur()
			:base ()
		{
			
		}
#endif
		/// //////////////////////////////////////////////////
		public CRelationElement_EOServeur( int nIdSession )
			:base ( nIdSession )
		{
			
		}

		//////////////////////////////////////////////////////////////////////
		public override string GetNomTable()
		{
			return CRelationElement_EO.c_nomTable;
		}

		//////////////////////////////////////////////////////////////////////
		public override Type GetTypeObjets()
		{
			return typeof(CRelationElement_EO);
		}

		//////////////////////////////////////////////////////////////////////
		public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{	
				CRelationElement_EO rel = (CRelationElement_EO)objet;

				return result;
			}
			catch ( Exception e )
			{
				result.EmpileErreur(new CErreurException(e));
			}
			return result;
				
		}

		//////////////////////////////////////////////////////////////////////
		public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
		{
			CResultAErreur  result =  base.TraitementAvantSauvegarde(contexte);
			if (!result)
				return result;

			DataTable table = contexte.Tables[GetNomTable()];
			if (table == null)
				return result;

			ArrayList lst = new ArrayList(table.Rows);
			Dictionary<IElementAEO,bool> tableElementsToUpdate = new Dictionary<IElementAEO,bool>();
			foreach (DataRow row in lst)
			{
				if (
					row.RowState == DataRowState.Modified ||
					row.RowState == DataRowState.Added )
				{
					CRelationElement_EO rel = new CRelationElement_EO(row);
					CObjetDonneeAIdNumerique objet = rel.ElementLie;
					if (objet != null )
					{
                        if (objet is IElementAEO)
                        {
                            tableElementsToUpdate[(IElementAEO)objet] = true;

                            // Vérifie les Exception de Type pour le Type d'EO
                            if (rel.EntiteOrganisationnelle != null &&
                                rel.EntiteOrganisationnelle.TypeEntite != null &&
                                rel.EntiteOrganisationnelle.TypeEntite.HasExceptionForType(objet.GetType()))
                            {
                                result.EmpileErreur(I.T("@1 cannot be affected to Organizational Entity @2. There is an Exception on this Type|10011",
                                    ((IElementAEO)objet).DescriptionElement, rel.EntiteOrganisationnelle.Libelle));
                                return result;
                            }
                        }
					}
				}
				else if (row.RowState == DataRowState.Deleted)
				{
					CRelationElement_EO rel = new CRelationElement_EO(row);
					rel.VersionToReturn = DataRowVersion.Original;
					CObjetDonneeAIdNumerique objet = rel.ElementLie;
					if (objet != null && objet.IsValide() && objet is IElementAEO && (!(rel.Row[CSc2iDataConst.c_champIsDeleted] is bool) || (bool)rel.Row[CSc2iDataConst.c_champIsDeleted]!=true))
					{
						tableElementsToUpdate[(IElementAEO)objet] = true;
					}
				}
			}

			//Met à jour les eos des éléments qui ont bougé
			foreach (IElementAEO element in tableElementsToUpdate.Keys)
			{
				result = CUtilElementAEO.UpdateEOSInCurrentContext(element);
				if (!result)
					return result;
			}
			return result;

		}

	}
}
