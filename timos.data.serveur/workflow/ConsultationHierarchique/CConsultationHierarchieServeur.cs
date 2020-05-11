using System;
using System.Collections;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;
using timos.data.workflow.ConsultationHierarchique;

namespace timos.workflow.ConsultatHierarchique
{
	/// <summary>
	/// Description résumée de CConsultationHierarchiqueServeur.
	/// </summary>
	public class CConsultationHierarchiqueServeur : CObjetServeurAvecBlob
	{
		//-------------------------------------------------------------------
#if PDA
		public CConsultationHierarchiqueServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CConsultationHierarchiqueServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CConsultationHierarchique.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CConsultationHierarchique ConsultationHierarchique = (CConsultationHierarchique)objet;

                if (ConsultationHierarchique.Libelle == string.Empty)
                    result.EmpileErreur(I.T("The Label can not be empty|126"));
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
			return typeof(CConsultationHierarchique);
		}
		//-------------------------------------------------------------------
	}
}
