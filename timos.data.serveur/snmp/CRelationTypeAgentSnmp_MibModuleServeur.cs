using System;
using System.Collections;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;

namespace timos.data.snmp.serveur
{
	/// <summary>
	/// Description rÃ©sumÃ©e de CRelationTypeAgentSnmp_MibModuleServeur.
	/// </summary>
	public class CRelationTypeAgentSnmp_MibModuleServeur : CObjetServeurAvecBlob
	{
		//-------------------------------------------------------------------
#if PDA
		public CRelationTypeAgentSnmp_MibModuleServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationTypeAgentSnmp_MibModuleServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CRelationTypeAgentSnmp_MibModule.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CRelationTypeAgentSnmp_MibModule relation = (CRelationTypeAgentSnmp_MibModule)objet;

				if ( relation.TypeAgent == null )
                    result.EmpileErreur(I.T("No specified agent type|20147"));
                if (relation.MibModule == null)
                    result.EmpileErreur(I.T("No specified mib module|20148"));

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
			return typeof(CRelationTypeAgentSnmp_MibModule);
		}
		//-------------------------------------------------------------------
	}
}
