using System;
using System.Data;
using sc2i.data;
using sc2i.common;
using sc2i.data.serveur;
using spv.data;
using timos.data;
using System.Collections.Generic;
using System.Collections;

namespace spv.data.serveur
{
    [AutoExec("Autoexec")]
    public class CSpvLiai_LiaicServeur : CObjetServeur
    {

        ///////////////////////////////////////////////////////////////
        public CSpvLiai_LiaicServeur(int nIdSession)
            : base(nIdSession)
        {
        }

        //////////////////////////////////////////////////////////////////
        public static void Autoexec()
        {
            CGestionnaireHookTraitementAvantSauvegarde.RegisterHook(typeof(CElementDeSchemaReseau), PropagerDependanceLien);
        }

        ///////////////////////////////////////////////////////////////
        public override string GetNomTable()
        {
            return CSpvLiai_Liaic.c_nomTable;
        }

        ///////////////////////////////////////////////////////////////
        public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
        {
            CResultAErreur result = CResultAErreur.True;
            try
            {
                //TODO : Insérer la logique de vérification de donnée
            }
            catch (Exception e)
            {
                result.EmpileErreur(new CErreurException(e));
            }
            return result;
        }

        ///////////////////////////////////////////////////////////////
        public override Type GetTypeObjets()
        {
            return typeof(CSpvLiai_Liaic);
        }

        private static void MajSpvLiaiLiaiC(CElementDeSchemaReseau element)
        {
            if (element == null)
                return;
            if (element.LienReseau != null && element.SchemaReseau != null &&
                element.SchemaReseau.LienReseau != null)
            {
                //C'est une dépendance de lien à lien
                //Cherche si la dépendance existe déjà
                CSpvLiai_Liaic dep = new CSpvLiai_Liaic(element.ContexteDonnee);
                CSpvLiai liaiSupportée = null;
                if (CSpvLiai.CanSupervise(element.SchemaReseau.LienReseau))
                    liaiSupportée = CSpvLiai.GetObjetSpvFromObjetTimosAvecCreation(element.SchemaReseau.LienReseau);

                CSpvLiai liaiSupportant = null;
                if (CSpvLiai.CanSupervise(element.LienReseau))
                    liaiSupportant = CSpvLiai.GetObjetSpvFromObjetTimosAvecCreation(element.LienReseau);
                if (liaiSupportée != null && liaiSupportant != null)
                {
                    if (!dep.ReadIfExists(new CFiltreData(CSpvLiai_Liaic.c_champIdLiaisonSupportée + "=@1 and " +
                        CSpvLiai_Liaic.c_champIdLiaisonSupportant + "=@2",
                        liaiSupportée.Id,
                        liaiSupportant.Id)))
                    {
                        dep.CreateNewInCurrentContexte(new object[] { liaiSupportée.Id, liaiSupportant.Id });
                    }
                }
            }
        }


        public static void PropagerDependanceLien(CContexteDonnee contexte, Hashtable tableData, ref CResultAErreur result)
        {
            DataTable dt = contexte.Tables[CElementDeSchemaReseau.c_nomTable];
            if (dt != null)
            {
                ArrayList rows = new ArrayList(dt.Rows);
                foreach (DataRow row in rows)
                {
                    if (row.RowState != DataRowState.Unchanged)
                    {
                        CElementDeSchemaReseau element = new CElementDeSchemaReseau(row);

                        switch (row.RowState)
                        {
                            case DataRowState.Added:
                            case DataRowState.Modified:
                                if (element != null && element.LienReseau != null &&
                                    element.SchemaReseau != null && element.SchemaReseau.LienReseau != null)
                                    //Il s'agit bien d'une liaison dans une liaisons
                                    MajSpvLiaiLiaiC(element);
                                break;
                            case DataRowState.Deleted:
                                element.VersionToReturn = DataRowVersion.Original;
                                CLienReseau lienSupportant = element.LienReseau;
                                if (lienSupportant != null && lienSupportant.IsValide())
                                {
                                    CSchemaReseau schema = element.SchemaReseau;
                                    if (schema.Row.RowState == DataRowState.Deleted)
                                        schema.VersionToReturn = DataRowVersion.Original;
                                    CLienReseau lienSupporte = schema.LienReseau;
                                    if (lienSupporte != null && lienSupporte.IsValide())//Il s'agit bien d'un élément support/supportant
                                    {
                                        CSpvLiai liaiSupportant = CSpvLiai.GetSpvLiaiFromLienReseau(lienSupportant) as CSpvLiai;
                                        if (liaiSupportant != null)
                                            liaiSupportant.UpdateSupportés();
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
    }
}
