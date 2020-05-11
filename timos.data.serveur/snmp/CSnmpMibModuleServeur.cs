using System;
using System.Collections;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;

namespace timos.data.snmp.serveur
{
	/// <summary>
	/// Description rÃ©sumÃ©e de CSnmpMibModuleServeur.
	/// </summary>
	public class CSnmpMibModuleServeur : CObjetServeurAvecBlob
	{
		//-------------------------------------------------------------------
#if PDA
		public CSnmpMibModuleServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CSnmpMibModuleServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CSnmpMibModule.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CSnmpMibModule SnmpMibModule = (CSnmpMibModule)objet;

				if ( SnmpMibModule.Libelle == "")
					result.EmpileErreur(I.T("Mib module label can not be empty|20143"));
				if (!CObjetDonneeAIdNumerique.IsUnique(SnmpMibModule, CSnmpMibModule.c_champModuleId, SnmpMibModule.ModuleId))
					result.EmpileErreur(I.T( "Mib module '@1' already exist|20144",SnmpMibModule.ModuleId));
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
			return typeof(CSnmpMibModule);
		}
		//-------------------------------------------------------------------
	}
}
