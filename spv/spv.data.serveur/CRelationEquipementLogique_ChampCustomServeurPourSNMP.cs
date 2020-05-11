using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using timos.data;
using sc2i.data.serveur;
using sc2i.data;
using System.Data;
using System.Collections;
using sc2i.data.dynamic;
using sc2i.multitiers.client;
using sc2i.expression;
using spv.data.SNMP;

namespace spv.data.serveur
{
    [AutoExec("Autoexec")]
    public class CRelationEquipementLogique_ChampCustomServeurPourSNMP
    {
        public static void Autoexec()
        {
            CGestionnaireHookTraitementAvantSauvegarde.RegisterHook(typeof(CRelationEquipementLogique_ChampCustom), new TraitementSauvegardeExterne(ModificationsSNMP));
        }

        //////////////////////////////////////////////////////////////////
        public static void ModificationsSNMP(
            CContexteDonnee contexte,
            Hashtable tableData,
            ref CResultAErreur result)
        {
            if (!result)
                return;
            DataTable table = contexte.Tables[CRelationEquipementLogique_ChampCustom.c_nomTable];
            if (table == null)
                return;
            ArrayList lst = new ArrayList(table.Rows);
            IRequeteSNMPServeur requeteurServeur = null;
            foreach (DataRow row in lst)
            {
                if (row.RowState == DataRowState.Modified || row.RowState == DataRowState.Added)
                {
                    if (row[CObjetDonnee.c_champContexteModification] == DBNull.Value ||
                        (string)row[CObjetDonnee.c_champContexteModification] != CSpvChampCustomSNMP.c_contexteModificationRefreshFromSNMP)
                    {
                        CRelationEquipementLogique_ChampCustom relChamp = new CRelationEquipementLogique_ChampCustom(row);
                        CSpvChampCustomSNMP champSNMP = new CSpvChampCustomSNMP(contexte);
                        if (champSNMP.ReadIfExists(new CFiltreData(CSpvChampCustomSNMP.c_champIdChampCustomTimos + "=@1",
                            (int)row[CChampCustom.c_champId])))
                        {
                            if (!champSNMP.GetOnly)
                            {
                                CSpvEquip eqptSpv = new CSpvEquip(contexte);
                                if (eqptSpv.ReadIfExists(new CFiltreData(CSpvEquip.c_champSmtEquipementLogique_Id + "=@1",
                                    row[CEquipementLogique.c_champId])))
                                {
                                    string strIP = eqptSpv.AdresseIP;
                                    string strCommunaute = eqptSpv.CommunauteSnmp;
                                    if (requeteurServeur == null)
                                        requeteurServeur = C2iFactory.GetNewObjetForSession("CRequeteSNMPServeur", typeof(IRequeteSNMPServeur), eqptSpv.ContexteDonnee.IdSession) as IRequeteSNMPServeur;
                                    if (champSNMP != null && champSNMP.OID != null && champSNMP.OID.Length > 0 &&
                                            champSNMP.FormuleIndex != null)
                                    {
                                        CContexteEvaluationExpression ctxFormule = new CContexteEvaluationExpression(relChamp.ElementAChamps);
                                        CResultAErreur resTmp = champSNMP.FormuleIndex.Eval(ctxFormule);
                                        if (resTmp)
                                        {
                                            try
                                            {
                                                int nIndex = Convert.ToInt32(result.Data);
                                                string strOid = champSNMP.OID + "." + nIndex.ToString();
                                                CRequeteSnmpOID requete = new CRequeteSnmpOID(strIP, strCommunaute, strOid);
                                                
                                                requeteurServeur.SetValue(requete, relChamp.Valeur);
                                            }
                                            catch { }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
