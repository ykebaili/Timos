using System;
using System.Collections;
using System.Text;
using System.Data;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;

using timos.data;
using timos.securite;

namespace timos.data.serveur
{
    /// <summary>
    /// Description résumée
    /// </summary>
    public class CRessourceServeur : CObjetDonneeServeurAvecCache
    {
        //-------------------------------------------------------------------
        public CRessourceServeur(int nIdSession)
			:base ( nIdSession )
		{
		}

		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CRessourceMaterielle.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			
            try
			{
                CRessourceMaterielle res = (CRessourceMaterielle)objet;

                // Verifie le champ "Libelle"
                if (res.Libelle == "")
					result.EmpileErreur("The Label cannot be empty|126");

                // Vérifie le Type de ressource
                if(res.TypeRessource == null)
                    result.EmpileErreur("The Resource Type must be defined|129");

                // Vérifie que la ressource est localisée
                if(res.Emplacement == null)
                    result.EmpileErreur("The Resource Location must be defined|130");
                
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
            return typeof(CRessourceMaterielle);
		}
 
        //-------------------------------------------------------------------
        //public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
        //{
        //    CResultAErreur result = CResultAErreur.True;

        //    result = base.TraitementAvantSauvegarde(contexte);
        //    if (!result) return result;

        //    // Interdit le mouvement d'une ressource fille (La ressource possède un parent)
        //    DataTable table = contexte.Tables[GetNomTable()];
        //    ArrayList lst = new ArrayList(table.Rows);
        //    foreach (DataRow row in lst)
        //    {
        //        if (row.RowState == DataRowState.Modified)
        //        {

        //            CRessource res = new CRessource(row);
        //            // Sauvegarde de la version du DataRow
        //            DataRowVersion oldVer = res.VersionToReturn;
        //            // Emplacement après modif
        //            IPossesseurRessource modifEmplacement = res.Emplacement;

        //            // Changement de version
        //            res.VersionToReturn = DataRowVersion.Original;
        //            // Type de contrainte avant modif
        //            IPossesseurRessource originEmplacement = res.Emplacement;
        //            // Retour à la version du DataRow
        //            res.VersionToReturn = oldVer;

        //            // Si emplacement modifié et si la ressource possède un perent
        //            if (modifEmplacement != originEmplacement && res.RessourceParente != null)
        //            {
        //                result.EmpileErreur(I.T(
        //                    "The child Resource can not be moved without its parent Resource|159"));
        //            }
        //        }
        //    }
        //    return result;
        //}

    }
}
