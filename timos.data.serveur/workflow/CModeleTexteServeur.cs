using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;

namespace sc2i.workflow
{
	/// <summary>
	/// Description résumée de CModeleTexteServeur.
	/// </summary>
	public class CModeleTexteServeur : CObjetServeurAvecBlob
	{
#if PDA
		public CModeleTexteServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CModeleTexteServeur( int nIdSession )
			:base(nIdSession)
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CModeleTexte.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CModeleTexte modele = (CModeleTexte)objet;

				if (modele.Libelle.Trim() == "")
					result.EmpileErreur(I.T("Text Model label cannot be empty|321"));

				//Controler que le libellé est unique pour le type
				if (!CObjetDonneeAIdNumerique.IsUnique(modele, CModeleTexte.c_champLibelle, modele.Libelle))
					result.EmpileErreur(I.T("Another model has the same label|322"));
					
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
			return typeof(CModeleTexte);
		}
	}
}
