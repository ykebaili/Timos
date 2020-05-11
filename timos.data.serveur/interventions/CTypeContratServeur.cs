using System;
using System.Collections;
using System.Text;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;

using timos.data;

namespace timos.data.serveur
{
    /// <summary>
    /// Description résumée 
    /// </summary>
    public class CTypeContratServeur : CObjetDonneeServeurAvecCache
    {
        //-------------------------------------------------------------------
        public CTypeContratServeur(int nIdSession)
			:base ( nIdSession )
		{
		}

		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CTypeContrat.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			
            try
			{
                CTypeContrat type_Contrat = (CTypeContrat)objet;

				if (type_Contrat.Libelle == "")
					result.EmpileErreur(I.T( "Contract type label can not be empty|353"));
				if (!CObjetDonneeAIdNumerique.IsUnique(type_Contrat, CTypeContrat.c_champLibelle, type_Contrat.Libelle))
                    result.EmpileErreur(I.T( "This contract type Label already exists|354"));

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
            return typeof(CTypeContrat);
		}
		//-------------------------------------------------------------------
    }
}
