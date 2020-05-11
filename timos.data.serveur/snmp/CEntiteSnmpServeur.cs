using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;

using timos.data;
using timos.securite;
using timos.data.snmp;
using timos.data.snmp.serveur;

namespace timos.data.serveur
{
    /// <summary>
    /// Description résumée de CEntiteSnmpServeur.
    /// </summary>
    public class CEntiteSnmpServeur : CObjetHierarchiqueServeur
    {
        //-------------------------------------------------------------------
        public CEntiteSnmpServeur(int nIdSession)
			:base ( nIdSession )
		{
		}

		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CEntiteSnmp.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			
           
			return result;
		}

        
		

		//-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
            return typeof(CEntiteSnmp);
		}
		
       
    }
}
