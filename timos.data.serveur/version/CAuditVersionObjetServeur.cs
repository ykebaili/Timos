using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using sc2i.data;
using sc2i.data.dynamic;
using sc2i.data.serveur;
using sc2i.common;

namespace timos.data.version
{
	/// <summary>
	/// Description résumée de CAuditVersionObjetServeur.
	/// </summary>
	public class CAuditVersionObjetServeur : CObjetServeur
	{
		//-------------------------------------------------------------------
		public CAuditVersionObjetServeur(int nIdSession)
			: base(nIdSession)
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable()
		{
			return CAuditVersionObjet.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CAuditVersionObjet tb = (CAuditVersionObjet)objet;
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
			return typeof(CAuditVersionObjet);
		}
	}
}

