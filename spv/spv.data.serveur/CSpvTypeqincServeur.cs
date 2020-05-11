using System;
using System.Data;
using sc2i.data;
using sc2i.common;
using sc2i.data.serveur;
using spv.data;

namespace spv.data.serveur
{
	public class CSpvTypeqincServeur : CObjetServeur
	{
		
		///////////////////////////////////////////////////////////////
		public CSpvTypeqincServeur ( int nIdSession )
			:base(nIdSession)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public override string GetNomTable()
		{
			return CSpvTypeqinc.c_nomTable;
		}
		
		///////////////////////////////////////////////////////////////
		public override CResultAErreur VerifieDonnees ( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				//TODO : Insérer la logique de vérification de donnée
                CSpvTypeqinc snmpTable = objet as CSpvTypeqinc;

                if (snmpTable.Libelle == null || snmpTable.Libelle == "")
                    result.EmpileErreur(I.T("Snmp table should have a label|3"));

                if ((snmpTable.OIDAutre == null || snmpTable.OIDAutre == "") &&
                    (snmpTable.OIDNom == null || snmpTable.OIDNom == "") &&
                    (snmpTable.OIDSignature == null || snmpTable.OIDSignature == ""))
                    result.EmpileErreur (I.T("Keybord at least one of the OID|50000"));
			}
			catch ( Exception e )
			{
				result.EmpileErreur( new CErreurException ( e ) );
			}
			return result;
		}
		
		///////////////////////////////////////////////////////////////
		public override Type GetTypeObjets()
		{
			return typeof(CSpvTypeqinc);
		}
	}
}
