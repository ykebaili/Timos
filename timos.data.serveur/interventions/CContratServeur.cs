using System;
using System.Collections;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;

using timos.data;

namespace timos.data.serveur
{
	/// <summary>
	/// Description résumée de CContratServeur.
	/// </summary>
	public class CContratServeur : CObjetDonneeServeurAvecCache
	{
		//-------------------------------------------------------------------
#if PDA
		public CContratServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CContratServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CContrat.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CContrat contrat = (CContrat)objet;

                if (contrat.Libelle == "")
					result.EmpileErreur(I.T("The label of the Contract cannot be empty|206"));

                if(contrat.Client == null)
                    result.EmpileErreur(I.T("The Contract must have an associated Customer|207"));

                if(contrat.TypeContrat == null)
                    result.EmpileErreur(I.T( "The Contract must have a Contract Type|355"));

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
			return typeof(CContrat);
		}

		//-------------------------------------------------------------------
	}
}
