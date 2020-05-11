using System;
using System.Collections;
using System.Text;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;

using timos.data;

namespace timos.data.serveur
{
	/// <summary>
	/// Description résumée de
	/// </summary>
	public class CRelationEquipement_TableParametrableServeur : CObjetDonneeServeurAvecCache
	{
		//-------------------------------------------------------------------
		public CRelationEquipement_TableParametrableServeur(int nIdSession)
			: base(nIdSession)
		{
		}

		//-------------------------------------------------------------------
		public override string GetNomTable()
		{
			return CRelationEquipement_TableParametrable.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
		{
			CResultAErreur result = CResultAErreur.True;

			try
			{
				CRelationEquipement_TableParametrable relation = (CRelationEquipement_TableParametrable)objet;

				if (relation.Equipement == null)
					result.EmpileErreur(I.T( "The equipement cannot be empty|382"));

				if (relation.TableParametrable == null)
					result.EmpileErreur(I.T( "The custom table cannot be empty|381"));

			}
			catch (Exception e)
			{
				result.EmpileErreur(new CErreurException(e));
			}
			return result;
		}

		//-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
			return typeof(CRelationEquipement_TableParametrable);
		}
		//-------------------------------------------------------------------
	}
}
