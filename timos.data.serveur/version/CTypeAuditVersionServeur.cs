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
	/// Description résumée de CTypeAuditVersionServeur.
	/// </summary>
	public class CTypeAuditVersionServeur : CObjetServeurAvecBlob
	{
		//-------------------------------------------------------------------
		public CTypeAuditVersionServeur(int nIdSession)
			: base(nIdSession)
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable()
		{
			return CTypeAuditVersion.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CTypeAuditVersion tb = (CTypeAuditVersion)objet;
				if (tb.Libelle == "")
					result.EmpileErreur(I.T( "Audit type label could not be empty|409"));
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
			return typeof(CTypeAuditVersion);
		}
	}
}

