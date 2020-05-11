using System;
using System.Collections;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;

namespace timos.snmp.polling
{
	/// <summary>
	/// Description rÃ©sumÃ©e de CSnmpPollingFieldServeur.
	/// </summary>
	public class CSnmpPollingFieldServeur : CObjetDonneeServeurAvecCache
	{
		//-------------------------------------------------------------------
#if PDA
		public CSnmpPollingFieldServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CSnmpPollingFieldServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CSnmpPollingField.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CSnmpPollingField SnmpPollingField = (CSnmpPollingField)objet;

				if ( SnmpPollingField.Nom == "")
					result.EmpileErreur(I.T("Snmp field name cannot be empty|20192"));
				if (!CObjetDonneeAIdNumerique.IsUnique(SnmpPollingField, CSnmpPollingField.c_champNom, SnmpPollingField.Nom))
					result.EmpileErreur(I.T( "Snmp field @1 already exists|20193",SnmpPollingField.Nom));
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
			return typeof(CSnmpPollingField);
		}
		//-------------------------------------------------------------------
	}
}
