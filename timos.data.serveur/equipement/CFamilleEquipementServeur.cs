using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;


namespace timos.data
{
	/// <summary>
	/// Description résumée de CUtilisateurServeur.
	/// </summary>
	public class CFamilleEquipementServeur : CObjetHierarchiqueServeur
	{
		//-------------------------------------------------------------------

		//-------------------------------------------------------------------
		public CFamilleEquipementServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CFamilleEquipement.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CFamilleEquipement famille = (CFamilleEquipement)objet;

				if ( famille.Libelle == "")
					result.EmpileErreur(I.T("The Equipment Family label must be defined|247"));

				CFamilleEquipement familleParente = famille.FamilleParente;
				while ( familleParente != null )
				{
					if ( familleParente == famille )
					{
						result.EmpileErreur(I.T("Error in the family hierarchy, the family is its own parent family|248"));
						return result;
					}
					familleParente = familleParente.FamilleParente;
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
			return typeof(CFamilleEquipement);
		}
		
		//-------------------------------------------------------------------
		public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
		{
			CResultAErreur result = base.TraitementAvantSauvegarde (contexte);
			if ( !result )
				return result;
			return result;
		}

		

	}
}
