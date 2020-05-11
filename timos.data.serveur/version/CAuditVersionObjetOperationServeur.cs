using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;


using sc2i.data;
using sc2i.data.dynamic;
using sc2i.data.serveur;
using sc2i.common;

namespace timos.data.version
{
	/// <summary>
	/// Description résumée de CAuditVersionObjetOperationServeur.
	/// </summary>
	public class CAuditVersionObjetOperationServeur : CObjetServeurAvecBlob
	{
		//-------------------------------------------------------------------
		public CAuditVersionObjetOperationServeur(int nIdSession)
			: base(nIdSession)
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable()
		{
			return CAuditVersionObjetOperation.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CAuditVersionObjetOperation audit = (CAuditVersionObjetOperation)objet;
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
			return typeof(CAuditVersionObjetOperation);
		}
	}
}

