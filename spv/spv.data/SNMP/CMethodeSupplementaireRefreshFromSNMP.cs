using System;
using System.Collections.Generic;
using System.Text;
using sc2i.common;
using timos.data;
using sc2i.data;
using sc2i.data.dynamic;
using sc2i.expression;
using sc2i.multitiers.client;

namespace spv.data.SNMP
{
    /// <summary>
    /// Ajoute au CEquipementLogique la capacité de remplir ses champs custom
    /// via SNMP
    /// </summary>
    [AutoExec("Autoexec")]
    public class CMethodeSupplementaireRefreshFromSNMP : CMethodeSupplementaire
    {
        public CMethodeSupplementaireRefreshFromSNMP()
            :base ( typeof(CEquipementLogique))
        {
        }

        public static void Autoexec()
        {
            CGestionnaireMethodesSupplementaires.RegisterMethode(new CMethodeSupplementaireRefreshFromSNMP());
        }

        public override string Description
        {
            get { return I.T("Update SNMP field values from SNMP|20020"); }
        }

        public override CInfoParametreMethodeDynamique[] InfosParametres
        {
            get { return new CInfoParametreMethodeDynamique[0]; }
        }

        public override object Invoke(object objetAppelle, params object[] parametres)
        {
            return RefreshFromSNMP(objetAppelle);
        }

        public override string Name
        {
            get { return "RefreshFromSNMP"; }
        }

        public override bool ReturnArrayOfReturnType
        {
            get { return false; }
        }

        public override Type ReturnType
        {
            get { return typeof(bool); }
        }

        public static bool RefreshFromSNMP ( object obj )
        {
            CEquipementLogique eqpt = obj as CEquipementLogique;
            if(  eqpt == null )
                return false;
            CSpvEquip eqptSpv = CSpvEquip.GetObjetSpvFromObjetTimos ( eqpt );
            if ( eqptSpv == null )
                return false;
            string strIP = eqptSpv.AdresseIP;
            string strCommunaute = eqptSpv.CommunauteSnmp;
            CChampCustom[] lstChamps = eqpt.TousLesChamps;
            string strOldContexteModif = eqpt.ContexteDonnee.IdModificationContextuelle;;
            eqpt.ContexteDonnee.IdModificationContextuelle = CSpvChampCustomSNMP.c_contexteModificationRefreshFromSNMP;
            IRequeteSNMPServeur requeteurServeur = C2iFactory.GetNewObjetForSession("CRequeteSNMPServeur", typeof(IRequeteSNMPServeur), eqpt.ContexteDonnee.IdSession) as IRequeteSNMPServeur;
            foreach ( CChampCustom champ in lstChamps )
            {
                CSpvChampCustomSNMP champSNMP = CSpvChampCustomSNMP.GetObjetSpvFromObjetTimos ( champ );
                if ( champSNMP!= null && champSNMP.OID != null && champSNMP.OID.Length > 0 && 
                    champSNMP.FormuleIndex != null )
                {
                    CContexteEvaluationExpression ctxFormule = new CContexteEvaluationExpression ( eqpt );
                    CResultAErreur result = champSNMP.FormuleIndex.Eval ( ctxFormule );
                    if ( result )
                    {
                        try
                        {
                            int nIndex = Convert.ToInt32 ( result.Data );
                            string strOid = champSNMP.OID+"."+nIndex.ToString();
                            CRequeteSnmpOID requete = new CRequeteSnmpOID ( strIP, strCommunaute, strOid );
                            result = requeteurServeur.GetValue ( requete );
                            if ( result )
                                eqpt.SetValeurChamp ( champ, result.Data );
                        }
                        catch{}
                    }
                }
            }
            eqpt.ContexteDonnee.IdModificationContextuelle = strOldContexteModif;
            return true;
        }            
    }
}
