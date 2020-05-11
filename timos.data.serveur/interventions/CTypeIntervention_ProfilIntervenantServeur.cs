using System;
using System.Collections;
using System.Text;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;

using timos.data;
using timos.acteurs;


namespace timos.data.serveur
{
    /// <summary>
    /// Description résumée 
    /// </summary>
    public class CTypeIntervention_ProfilIntervenantServeur : CObjetDonneeServeurAvecCache
    {
        //-------------------------------------------------------------------
        public CTypeIntervention_ProfilIntervenantServeur(int nIdSession)
			:base ( nIdSession )
		{
		}

		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CTypeIntervention_ProfilIntervenant.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			
            try
			{
                CTypeIntervention_ProfilIntervenant relation = (CTypeIntervention_ProfilIntervenant)objet;
				if (relation.ProfilIntervenant != null)
				{
					if (typeof(CActeur) != relation.ProfilIntervenant.TypeElements ||
						typeof(CIntervention) != relation.ProfilIntervenant.TypeSource)
					{
						result.EmpileErreur(I.T("Incorrect profile : Member/Site expected|221"));
					}
				}
						
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
            return typeof(CTypeIntervention_ProfilIntervenant);
		}
		
		//-------------------------------------------------------------------
    }
}
