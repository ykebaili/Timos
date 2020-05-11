using System;
using System.Collections;

using System.Drawing;
using sc2i.common;
using sc2i.multitiers.client;
using sc2i.expression;
using sc2i.data;
using sc2i.process;
using timos.data;

namespace spv.data
{
    /// <summary>
    /// Description résumée de CActionCreateEquipementsDecouverts.
    /// </summary>
    [AutoExec("Autoexec")]
    public class CActionCreateEquipementsDecouverts : CActionLienSortantSimple
    {
        private int m_nIdFamilleEquipement = -1;
        /// /////////////////////////////////////////////////////////
        public CActionCreateEquipementsDecouverts(CProcess process)
            : base(process)
        {
            Libelle = I.T("Transfer discovered|20010");
        }

        /// /////////////////////////////////////////////////////////
        public int IdFamilleEquipement
        {
            get
            {
                return m_nIdFamilleEquipement;
            }
            set
            {
                m_nIdFamilleEquipement = value;
            }

        }

        /// /////////////////////////////////////////////////////////
        public static void Autoexec()
        {
            CGestionnaireActionsDisponibles.RegisterTypeAction(
                I.T("Transfer discovered equipments|20011"),
                I.T("Transfer discovered equipments|20011"),
                typeof(CActionCreateEquipementsDecouverts),
                CGestionnaireActionsDisponibles.c_categorieMetier);
        }


        /// /////////////////////////////////////////////////////////
        public override bool PeutEtreExecuteSurLePosteClient
        {
            get { return false; }
        }


        /// ////////////////////////////////////////////////////////
        public override CResultAErreur VerifieDonnees()
        {
            CResultAErreur result = CResultAErreur.True;
            if ( m_nIdFamilleEquipement < 0 )
            {
                result.EmpileErreur(I.T("Select a family for discovered types|20026"));
                return result;
            }
           return result;
        }


        /// /////////////////////////////////////////
        public override void AddIdVariablesNecessairesInHashtable(Hashtable table)
        {
        }


        /// /////////////////////////////////////////
        private int GetNumVersion()
        {
            return 1;
            //1 : ajout de la famille d'équipement
        }

        /// ////////////////////////////////////////////////////////
        protected override CResultAErreur MySerialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            
           result = base.MySerialize(serializer);
               
           if (nVersion >= 1)
                serializer.TraiteInt(ref m_nIdFamilleEquipement);
            return result;
        }


        /// ////////////////////////////////////////////////////////
        protected override CResultAErreur MyExecute(CContexteExecutionAction contexte)
        {
            CResultAErreur result = CResultAErreur.True;
            CFamilleEquipement famille = new CFamilleEquipement(contexte.ContexteDonnee);
            if ( !famille.ReadIfExists ( m_nIdFamilleEquipement ) )
            {
                result.EmpileErreur(I.T("Equipment type family @1 doesn't exists|20027", m_nIdFamilleEquipement.ToString()));
                return result;
            }

            CListeObjetsDonnees lstTypes = new CListeObjetsDonnees(contexte.ContexteDonnee, typeof(CSpvTypeq));
            lstTypes.Filtre = new CFiltreData(CSpvTypeq.c_champSmtTypeEquipement_Id + " is null");
            foreach (CSpvTypeq typeEq in lstTypes.ToArrayList())
            {
                CTypeEquipement type = new CTypeEquipement(contexte.ContexteDonnee);
                type.CreateNewInCurrentContexte();
                type.Libelle = typeEq.Libelle;
                type.Famille = famille;
                typeEq.TypeEquipementSmt = type;
            }

            CListeObjetsDonnees lstObjets = new CListeObjetsDonnees(contexte.ContexteDonnee, typeof(CSpvEquip));
            lstObjets.Filtre = new CFiltreDataAvance(CSpvEquip.c_nomTable, 
                "HasNo("+CSpvEquip.c_champSmtEquipementLogique_Id + ") and " +
                "Has(TypeEquipement." + CSpvTypeq.c_champSmtTypeEquipement_Id + ") and " +
                "has("+CSpvSite.c_nomTable + "." + CSpvSite.c_champSmtSite_Id + ")");
            int nNbEquips = lstObjets.Count;
            int nEquip = 0;
            if ( contexte.IndicateurProgression != null )
            {
                contexte.IndicateurProgression.PushSegment ( 9, nNbEquips );
                contexte.SetInfoProgression(I.T("Transfering discovered equipments|20221"));
            }
            ArrayList lstEquips = lstObjets.ToArrayList();
            foreach (CSpvEquip equipSpv in lstEquips)
            {
 
                nEquip++;
                if (nEquip % 20 == 0 && contexte.IndicateurProgression != null)
                {
                    contexte.IndicateurProgression.SetValue(nEquip/2);
                    contexte.SetInfoProgression((int)(nEquip/2) + "/" + nNbEquips);
                }
                CSpvSite siteSpv = equipSpv.SpvSite;
                CSpvTypeq typeEqSpv = equipSpv.TypeEquipement;
                if (siteSpv != null && typeEqSpv != null)
                {
                    CTypeEquipement typeTimos = typeEqSpv.TypeEquipementSmt;
                    CSite siteTimos = siteSpv.ObjetTimosAssocie;
                    if (typeTimos != null && siteTimos != null)
                    {
                        CEquipementLogique equipementTimos = new CEquipementLogique(contexte.ContexteDonnee);
                        equipementTimos.TypeEquipement = typeTimos;
                        equipementTimos.Site = siteTimos;
                        equipementTimos.Libelle = equipSpv.CommentairePourSituer;
                        equipSpv.ObjetTimosAssocie = equipementTimos;
                    }
                }
            }
            foreach (CSpvEquip equipSpv in lstEquips)
            {
                nEquip++;
                if (nEquip % 20 == 0 && contexte.IndicateurProgression != null)
                {
                    contexte.IndicateurProgression.SetValue(nEquip / 2);
                    contexte.SetInfoProgression((int)(nEquip / 2) + "/" + nNbEquips);
                }
                CEquipementLogique equip = equipSpv.ObjetTimosAssocie;
                if (equipSpv.EquipementEnglobant != null)
                {
                    CEquipementLogique englobant = equipSpv.EquipementEnglobant.ObjetTimosAssocie;
                    if (englobant == null)
                    {
                        result = equipSpv.Delete(true);
                        if (!result)
                            return result;
                    }
                    else
                        equip.EquipementLogiqueContenant = englobant;
                }
            }
            if (contexte.IndicateurProgression != null)
                contexte.IndicateurProgression.PopSegment();
            return result;
        }
    }
}
