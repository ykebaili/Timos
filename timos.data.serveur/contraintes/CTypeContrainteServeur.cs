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
    /// Description rÃ©sumÃ©e de CTypeContrainteServeur.
    /// </summary>
    public class CTypeContrainteServeur : CObjetServeurAvecBlob
    {
        //-------------------------------------------------------------------
        public CTypeContrainteServeur(int nIdSession)
			:base ( nIdSession )
		{
		}

		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CTypeContrainte.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			
            try
			{
                CTypeContrainte type_cont = (CTypeContrainte)objet;

                // Verifie le champ "Libelle"
                if (type_cont.Libelle == "")
					result.EmpileErreur(I.T( "Constraint Type label cannot be empty|10003"));

                // Le champ "Libelle" doit Ãªtre unique dans son parent seulement.
                if (type_cont.TypeContrainteParent != null)
                {
                    // Liste des sites frÃ¨res lst
                    CListeObjetsDonnees lst = type_cont.TypeContrainteParent.TypesContraintesFils;

                    lst.Filtre = new CFiltreData(CTypeContrainte.c_champLibelle + " = @1 AND " + CTypeContrainte.c_champId + " <> @2", type_cont.Libelle, type_cont.Id);
                    if (lst.Count != 0)
                        result.EmpileErreur(I.T("The Constraint type '@1' already exists|239",type_cont.Libelle));
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
            return typeof(CTypeContrainte);
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
