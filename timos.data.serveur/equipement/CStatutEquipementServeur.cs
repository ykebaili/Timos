using System;
using System.Collections;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;

using timos.securite;

namespace timos.data
{
	/// <summary>
	/// Description rÃ©sumÃ©e de CStatutEquipementServeur.
	/// </summary>
	public class CStatutEquipementServeur : CObjetServeur
	{
		//-------------------------------------------------------------------
#if PDA
		public CStatutEquipementServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CStatutEquipementServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CStatutEquipement.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CStatutEquipement statutEquipement = (CStatutEquipement)objet;

				if ( statutEquipement.Libelle == "")
					result.EmpileErreur(I.T("The Equipment Status label cannot be empty|118"));
				if (statutEquipement.Code == "")
					result.EmpileErreur(I.T( "The Equipment Status code can not be empty|119"));
				if (!CObjetDonneeAIdNumerique.IsUnique(statutEquipement, CStatutEquipement.c_champLibelle, statutEquipement.Libelle))
					result.EmpileErreur(I.T( "Another equipment status with the same name already exists|120"));
				if (!CObjetDonneeAIdNumerique.IsUnique(statutEquipement, CStatutEquipement.c_champCode, statutEquipement.Code))
					result.EmpileErreur(I.T( "Another equipment status with the same code already exists|121"));
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
			return typeof(CStatutEquipement);
		}
		//-------------------------------------------------------------------
	}
}
