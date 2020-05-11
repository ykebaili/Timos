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
	/// Description résumée de CAuditVersionServeur.
	/// </summary>
	public class CAuditVersionServeur : CObjetServeur
	{
		//-------------------------------------------------------------------
		public CAuditVersionServeur(int nIdSession)
			: base(nIdSession)
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable()
		{
			return CAuditVersion.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CAuditVersion audit = (CAuditVersion)objet;
				
				if (audit.Libelle == "")
					result.EmpileErreur(I.T("Audit label cannot be empty|414"));
				if (audit.TypeAudit == null)
                    result.EmpileErreur(I.T("Audit must have an Audit Type|413"));
				if (audit.NomVersionCible == audit.NomVersionSource)
					result.EmpileErreur(I.T("The Target version cannot be equal to the source version|415"));
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
			return typeof(CAuditVersion);
		}
	}
}

