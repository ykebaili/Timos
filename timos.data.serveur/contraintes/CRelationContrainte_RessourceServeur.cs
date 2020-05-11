using System;
using System.Collections;
using System.Text;
using System.Diagnostics;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;

using timos.data;

namespace timos.data.serveur
{
    /// <summary>
    /// Description résumée.
    /// </summary>
    public class CRelationContrainte_RessourceServeur : CObjetDonneeServeurAvecCache
    {
        //-------------------------------------------------------------------
        public CRelationContrainte_RessourceServeur(int nIdSession)
			:base ( nIdSession )
		{
		}

		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CRelationContrainte_Ressource.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			
            try
			{
                int conteur = 0;
                CRelationContrainte_Ressource rel = (CRelationContrainte_Ressource) objet;

                // Vérifie si le Type de Contrainte correspond au Type de la Ressource associée
                if (rel.Ressource.TypeRessource != null && rel.Contrainte.TypeContrainte != null)
                {
                    CTypeRessource[] typeResListe = rel.Contrainte.TypeContrainte.GetTousLesTypesRessources();

                    foreach (CTypeRessource tp in typeResListe)
                    {
                        Debug.Print("Type Ressource = " + tp.Libelle);
                        if(tp == rel.Ressource.TypeRessource)
                            conteur++;
                    }
                    if (conteur == 0)
                        result.EmpileErreur(I.T( "The Resource Type doesn't match the Constraint Type|127"));

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
            return typeof(CRelationContrainte_Ressource);
		}
		//-------------------------------------------------------------------
    }
}
