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
    public class CTypeOperationServeur : CObjetHierarchiqueServeur
    {
        //-------------------------------------------------------------------
        public CTypeOperationServeur(int nIdSession)
			:base ( nIdSession )
		{
		}

		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CTypeOperation.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			
            try
			{
                CTypeOperation type_Operation = (CTypeOperation)objet;

				if (type_Operation.Libelle == "")
					result.EmpileErreur(I.T( "Operation type label cannot be empty|146"));
                CListeObjetsDonnees lst = new CListeObjetsDonnees(objet.ContexteDonnee, typeof(CTypeOperation));
                lst.Filtre = new CFiltreData(CTypeOperation.c_champId + "<>@1 and " +
                    CTypeOperation.c_champLibelle + "=@2", type_Operation.Id, type_Operation.Libelle);
                if (type_Operation.TypeOperationParente == null)
                    lst.Filtre = CFiltreData.GetAndFiltre(lst.Filtre, 
                        new CFiltreData(CTypeOperation.c_champIdOperationParente + " is null"));
                else
                    lst.Filtre = CFiltreData.GetAndFiltre ( lst.Filtre,
                        new CFiltreData ( CTypeOperation.c_champIdOperationParente+"=@1",
                            type_Operation.TypeOperationParente.Id ));
                if ( lst.Count  != 0 )
                    result.EmpileErreur(I.T( "Operation type @1 already exists|147"), type_Operation.Libelle);

                if (type_Operation.Code != "")
                {
                    lst.Filtre = new CFiltreData(CTypeOperation.c_champId + "<>@1 and " +
                        CTypeOperation.c_champCode + "=@2", type_Operation.Id, type_Operation.Code);
                    if (type_Operation.TypeOperationParente == null)
                        lst.Filtre = CFiltreData.GetAndFiltre(lst.Filtre,
                            new CFiltreData(CTypeOperation.c_champIdOperationParente + " is null"));
                    else
                        lst.Filtre = CFiltreData.GetAndFiltre(lst.Filtre,
                            new CFiltreData(CTypeOperation.c_champIdOperationParente + "=@1",
                                type_Operation.TypeOperationParente.Id));
                    if (lst.Count != 0)
                    {
                        if (!CObjetDonneeAIdNumerique.IsUnique(type_Operation, CTypeOperation.c_champCode, type_Operation.Code))
                            result.EmpileErreur(I.T("Another operation type with the code @1 already exists|148"), type_Operation.Code);
                    }
                }
                if ( type_Operation.SaisieDureeParDateFin==true && 
                    (!type_Operation.SaisieDureeAppliquee ||
                    !type_Operation.SaisieHeureAppliquee ) )
                {
                    result.EmpileErreur(I.T("Option 'Enter end date' needs option 'Input duration' and 'Input start date'|20139"));
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
            return typeof(CTypeOperation);
		}
		//-------------------------------------------------------------------
    }
}
