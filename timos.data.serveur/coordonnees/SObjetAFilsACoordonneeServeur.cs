using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using sc2i.data;
using sc2i.common;
using timos.data;

namespace timos.data
{
	public static class SObjetAFilsACoordonneeServeur
	{

		//----------------------------------------------------------------------------
		public static CResultAErreur VerifieDonnees( IObjetAFilsACoordonnees objet )
		{
			CParametrageSystemeCoordonnees parametrage = objet.ParametrageCoordonneesApplique;
			if (parametrage != null )
				return parametrage.IsModifValide();
			return CResultAErreur.True;
		}

		//----------------------------------------------------------------------------
		public static CResultAErreur TraitementAvantSauvegarde(IObjetAFilsACoordonnees objet)
		{

			CResultAErreur result = CResultAErreur.True;
			if (((CObjetDonnee)objet).Row.RowState == DataRowState.Deleted)
				return result;
			CObjetDonnee objDonnee = (CObjetDonnee)objet;
			DataRow row = objDonnee.Row;
			if (row.RowState == DataRowState.Added)
			{
				if (objet.ParametrageCoordonneesPropre == null)
				{
					CParametrageSystemeCoordonnees parametrage = objet.ParametrageCoordonneesApplique;
					if (parametrage != null)
					{
						parametrage = (CParametrageSystemeCoordonnees)parametrage.Clone(false);
						parametrage.ObjetASystemeDeCoordonnees = objet;
					}
				}
				if (objet.OptionsControleCoordonneesPropre == null)
					objet.OptionsControleCoordonneesPropre = objet.OptionsControleCoordonneesApplique;
			}
			if (row.RowState == DataRowState.Modified)
			{

				DataRowVersion oldVers = objDonnee.VersionToReturn;
				objDonnee.VersionToReturn = DataRowVersion.Original;
				EOptionControleCoordonnees? oldOpt = objet.OptionsControleCoordonneesApplique;
				objDonnee.VersionToReturn = oldVers;
				EOptionControleCoordonnees? newOpt = objet.OptionsControleCoordonneesApplique;
				if (newOpt != oldOpt)
				{
					result = objet.VerifieCoordonneesFils();
					if (!result)
						return result;
				}
			}
			return result;
		}
	}
}
