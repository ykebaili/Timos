using System;
using System.Data;
using sc2i.data;
using sc2i.common;
using sc2i.data.serveur;
using spv.data;

namespace spv.data.serveur
{
    public class CSpvFamilleMibmoduleServeur : CSpvFamilleServeur
    {

        ///////////////////////////////////////////////////////////////
        public CSpvFamilleMibmoduleServeur(int nIdSession)
            : base(nIdSession)
        {
        }

        ///////////////////////////////////////////////////////////////
        public override string GetNomTable()
        {
            return CSpvFamilleMibmodule.c_nomTable;
        }

        ///////////////////////////////////////////////////////////////
        public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
        {
            CResultAErreur result = CResultAErreur.True;
            try
            {
                //TODO : Insérer la logique de vérification de donnée
                CSpvFamilleMibmodule familleSPV = (CSpvFamilleMibmodule)objet;

                // Vérifier que le libellé est renseigné
                if (familleSPV.ChampLibelle == "")
                    result.EmpileErreur(I.T("The family label must be specified|50008"));

                // Vérifier que la famille n'est pas son propre parent
                CSpvFamilleMibmodule familleMere = familleSPV.FamilleParente;
                while (familleMere != null)
                {
                    if (familleMere == familleSPV)
                    {
                        result.EmpileErreur(I.T("Error in the family hierarchy, the family is its own parent family|50009"));
                        return result;
                    }
                    familleMere = familleMere.FamilleParente;
                }

                // Vérifier que la famille est unique dans la branche
                result = VerifieUnicite (familleSPV);

            }
            catch (Exception e)
            {
                result.EmpileErreur(new CErreurException(e));
            }
            return result;
        }

        private CResultAErreur VerifieUnicite(CSpvFamilleMibmodule familleSPV)
        {
            //throw new Exception("The method or operation is not implemented.");
            CResultAErreur result = CResultAErreur.True;
            CFiltreData filtre;

            if (familleSPV.FamilleParente == null)
                filtre = new CFiltreData(CSpvFamilleMibmodule.c_champFAMILLE_NOM + "=@1 AND " +
                   CSpvFamilleMibmodule.c_champFAMILLE_BINDINGID + " IS NULL AND " +
                   CSpvFamilleMibmodule.c_champFAMILLE_ID + "<>@2", familleSPV.Libelle, familleSPV.Id);
            else
                filtre = new CFiltreData(CSpvFamilleMibmodule.c_champFAMILLE_NOM + "=@1 AND " +
                    CSpvFamilleMibmodule.c_champFAMILLE_BINDINGID + "=@2 AND " +
                    CSpvFamilleMibmodule.c_champFAMILLE_ID + "<>@3",
                    familleSPV.Libelle, familleSPV.FamilleParente.Id, familleSPV.Id);
            
            CSpvFamilleMibmodule famille = new CSpvFamilleMibmodule(familleSPV.ContexteDonnee);
            if (famille.ReadIfExists(filtre))
                result.EmpileErreur(I.T("The family should be unique in its branch|50010"));

            return result;
        }


        ///////////////////////////////////////////////////////////////
        public override Type GetTypeObjets()
        {
            return typeof(CSpvFamilleMibmodule);
        }


        ////-------------------------------------------------------------------
        protected override CFiltreData GetMyFiltreSysteme()
        {
            return new CFiltreData(CSpvFamilleMibmodule.c_champFAMILLE_CLASSID + "=@1",
                CSpvFamilleMibmodule.c_classID);
        }
    }
}
