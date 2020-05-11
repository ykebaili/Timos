using System;
using System.Data;
using System.Collections;

using sc2i.data;
using sc2i.common;
using sc2i.data.serveur;
using spv.data;
using timos.data;

namespace spv.data.serveur
{
    [AutoExec("Autoexec")]
    public class CSpvTypeqServeur : CObjetServeur
    {

        public static void Autoexec()
        {
            CGestionnaireHookTraitementAvantSauvegarde.RegisterHook(typeof(CTypeEquipement), PropagerCTypeEquipement);
        }

        ///////////////////////////////////////////////////////////////
        public CSpvTypeqServeur(int nIdSession)
            : base(nIdSession)
        {
        }

        ///////////////////////////////////////////////////////////////
        public override string GetNomTable()
        {
            return CSpvTypeq.c_nomTable;
        }

        ///////////////////////////////////////////////////////////////
        public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
        {
            CResultAErreur result = CResultAErreur.True;
            try
            {
                CSpvTypeq typeq = (CSpvTypeq)objet;
                if (typeq.ChercheOIDParMIB)
                {
                    if (typeq.NomIdentifiantSnmp == null || typeq.NomIdentifiantSnmp.Length == 0)
                        result.EmpileErreur(I.T("When <Automatic MIB> is checked (SNMP identification), <Secondary (name)> should be filled|50006"));

                    else if (typeq.TypeqModulesMIB.Count <= 0)
                        result.EmpileErreur(I.T("When <Automatic MIB> is checked (SNMP identification), MIBs should be associated with the equipement type|50007"));

                }
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
            return typeof(CSpvTypeq);
        }


        private static CSpvTypeq GetSpvTypeq(DataRow row)
        {
            CSpvTypeq spvTypeq;
            CTypeEquipement typeEquipement = new CTypeEquipement(row);
            spvTypeq = CSpvTypeq.GetSpvTypeqFromTypeEquipement(typeEquipement) as CSpvTypeq;
            if (spvTypeq == null)
            {
                spvTypeq = CSpvTypeq.GetSpvTypeqFromTypeEquipementAvecCreation(typeEquipement);
            }
            spvTypeq.CopyFromTypeEquipement(typeEquipement);
            return spvTypeq;
        }


        ////////////////////////////////////////////////////////////////////
        public static void PropagerCTypeEquipement(CContexteDonnee contexte, Hashtable tableData, ref CResultAErreur result)
        {
            CResultAErreur resultat = CResultAErreur.True;

            DataTable dt = contexte.Tables[CTypeEquipement.c_nomTable];
            if (dt != null)
            {
                ArrayList rows = new ArrayList(dt.Rows);
                CSpvTypeq spvTypeq;

                foreach (DataRow row in rows)
                {
                    if (row.RowState != DataRowState.Unchanged)
                    {
                        
                        switch (row.RowState)
                        {
                            case DataRowState.Added:
                            case DataRowState.Modified:
                                spvTypeq = CSpvTypeqServeur.GetSpvTypeq(row);
                                if (spvTypeq.ChercheOIDParMIB && 
                                    spvTypeq.NomIdentifiantSnmp != null && 
                                    spvTypeq.NomIdentifiantSnmp.Length > 0 && 
                                    spvTypeq.TypeqModulesMIB.Count > 0)
                                    resultat = spvTypeq.MibAuto();

                                break;

                            default:
                                break;
                        }
                    }
                    else
                    {
                        if (CSpvTypeq.IsModified((Int32)row[CTypeEquipement.c_champId], contexte))
                        {
                            spvTypeq = CSpvTypeqServeur.GetSpvTypeq(row);
                            if (spvTypeq.ChercheOIDParMIB && 
                                spvTypeq.NomIdentifiantSnmp != null && 
                                spvTypeq.NomIdentifiantSnmp.Length > 0 && 
                                spvTypeq.TypeqModulesMIB.Count > 0)
                                resultat = spvTypeq.MibAuto();
                        }
                    }

                }//foreach (DataRow row in rows)

            }// if (dt != null)

            if (!resultat)
                throw new CExceptionErreur(result.Erreur);

        }


        public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
        {
            CResultAErreur result = base.TraitementAvantSauvegarde(contexte);

            if (!result)
                return result;

            DataTable table = contexte.Tables[GetNomTable()];
            if (table == null)
                return result;

            ArrayList lstRows = new System.Collections.ArrayList(table.Rows);
            foreach (DataRow row in lstRows)
            {
                if (row.RowState == DataRowState.Modified)
                {
                    CSpvTypeq spvTypeq = new CSpvTypeq(row);
                    if ((string)row[CSpvTypeq.c_champTYPEQ_NOM, DataRowVersion.Original] !=
                        spvTypeq.Libelle)
                    {
                        foreach (CSpvEquip spvEquip in spvTypeq.Equipements)
                            spvEquip.LibelleTypeEquipement = spvTypeq.Libelle;
                    }

                    if ((bool)row[CSpvTypeq.c_champTYPEQ_TOSURV, DataRowVersion.Original] !=
                        spvTypeq.ASurveiller)
                    {
                        CSpvMessem spvMessem = new CSpvMessem(contexte);
                        spvMessem.CreateNewInCurrentContexte();
                        spvMessem.FormatMessModTypeq(spvTypeq.Id, spvTypeq.ASurveiller);
                    }
                }
                else if (row.RowState == DataRowState.Deleted)
                {
                    Int32 nId = (Int32)row[CSpvTypeq.c_champTYPEQ_ID, DataRowVersion.Original];
                    if (nId == CSpvTypeq.c_TypeEquipMediationId)
                        result.EmpileErreur(I.T("EQUIP MEDIATION is a system equipment type, we cannot erase it|50018"));
                    else
                    {
                        CSpvMessem spvMessem = new CSpvMessem(contexte);
                        spvMessem.CreateNewInCurrentContexte();
                        spvMessem.FormatMessDelTypeq(nId);
                    }
                }
            }
            return result;
        }
    }
}
