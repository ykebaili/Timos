using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;

namespace sc2i.workflow
{
	/// <summary>
	/// Description résumée de CGrilleGeneriqueServeur.
	/// </summary>
	public class CGrilleGeneriqueServeur : CObjetServeurAvecBlob
	{
#if PDA
		public CGrilleGeneriqueServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CGrilleGeneriqueServeur( int nIdSession )
			:base(nIdSession)
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CGrilleGenerique.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CGrilleGenerique grille = (CGrilleGenerique)objet;

				if ( grille.Libelle.Trim() == "" )
					result.EmpileErreur(I.T("Grid label cannot be empty|317"));

				//Controler que le libellé est unique pour le type
				if ( !CObjetDonneeAIdNumerique.IsUnique ( grille, CGrilleGenerique.c_champLibelle, grille.Libelle ) )
					result.EmpileErreur(I.T("Another Grid has the same label|318"));

				if ( grille.Code.Trim() != "" )
				{
					if (!CObjetDonneeAIdNumerique.IsUnique(grille, CGrilleGenerique.c_champCode, grille.Code))
						result.EmpileErreur(I.T("Another Grid has the same code|319"));
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
			return typeof(CGrilleGenerique);
		}
	}
}
