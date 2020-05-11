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
	public class CRelationSite_TableParametrableServeur : CObjetDonneeServeurAvecCache
	{
		//-------------------------------------------------------------------
		public CRelationSite_TableParametrableServeur(int nIdSession)
			: base(nIdSession)
		{
		}

		//-------------------------------------------------------------------
		public override string GetNomTable()
		{
			return CRelationSite_TableParametrable.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
		{
			CResultAErreur result = CResultAErreur.True;

			try
			{
				CRelationSite_TableParametrable relation = (CRelationSite_TableParametrable)objet;

				if (relation.Site == null)
					result.EmpileErreur(I.T( "The Site cannot be empty|380"));

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
			return typeof(CRelationSite_TableParametrable);
		}
		//-------------------------------------------------------------------
	}
}
