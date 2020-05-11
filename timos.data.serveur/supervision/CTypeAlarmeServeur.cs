using System;
using System.Collections;
using System.Text;
using System.Data;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;

using timos.data;
using timos.securite;
using timos.data.supervision;
using System.Collections.Generic;
using timos.data.snmp.Proxy;
using futurocom.snmp;
using timos.data.serveur.supervision;
using sc2i.common.synchronisation;

namespace timos.data.serveur
{
    /// <summary>
    /// Description rÃ©sumÃ©e 
    /// </summary>
    public class CTypeAlarmeServeur : CObjetServeurAvecBlob
    {
        //-------------------------------------------------------------------
        public CTypeAlarmeServeur(int nIdSession)
			:base ( nIdSession )
		{
		}

		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CTypeAlarme.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			
            try
			{
                CTypeAlarme typeAlarme = (CTypeAlarme)objet;

                // Verifie le champ "Libelle"
                if (typeAlarme.Libelle == "")
					result.EmpileErreur(I.T("Alarm Type label cannot be empty|20151"));

                
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
            return typeof(CTypeAlarme);
		}

		//-------------------------------------------------------------------
        public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
        {
            CResultAErreur result = base.TraitementAvantSauvegarde(contexte);
            if (result)
                result = SObjetHierarchiqueServeur.TraitementAvantSauvegarde(contexte, GetNomTable());
            return result;
        }
       
    }
}
