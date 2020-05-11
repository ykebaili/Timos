using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;
using tiag.client;

namespace timos.data
{
	/// <summary>
	/// Type de contrat.<br/>
    /// Le type de contrat fournit au contrat :<br/>
    /// <ul>
    /// <li>Le formulaire personnalisé éventuellement associé</li>
    /// <li>Une indication sur la gestion des sites associés au contrat de ce type : manuelle ou par profil</li>
    /// <li>Un indicateur comme quoi les contrats de ce type s'appliquent à de la maintenance préventive</li>
    /// <li>Un indicateur comme quoi les contrats de ce type s'appliquent à de la maintenance corrective</li>
    /// </ul>
	/// </summary>
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iIntervention)]
    [DynamicClass("Contrat Type")]
    [Table(CTypeContrat.c_nomTable, CTypeContrat.c_champId, true)]
    [FullTableSync]
    [ObjetServeurURI("CTypeContratServeur")]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IngeProjet_ID,
        Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersPreventives_ID,
        Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersCorrectives_ID)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_TypeContrat_ID)]
    [TiagClass(CTypeContrat.c_nomTiag, "Id", true)]
    public class CTypeContrat : CObjetDonneeAIdNumeriqueAuto,
        IDefinisseurChampCustom
    {

        public const string c_nomTable = "CONTRACT_TYPE";
        public const string c_nomTiag = "Contract Type";

        public const string c_champId = "CONTTYP_ID";
        public const string c_champLibelle = "CONTTYP_LABEL";
        public const string c_champIdForm = "CONTTYP_FORM";
        public const string c_champGestionSitesManuel = "CONTTYP_MANUAL_SITES";
        public const string c_champGestionMaintenanceCorretive = "CONTTYP_CORR_MAINT";
        public const string c_champGestionMaintenancePreventive = "CONTTYP_PREV_MAINT";


        /// /////////////////////////////////////////////
        public CTypeContrat(CContexteDonnee contexte)
            : base(contexte)
        {
        }

        /// /////////////////////////////////////////////
        public CTypeContrat(DataRow row)
            : base(row)
        {
        }

        /// /////////////////////////////////////////////
        public override string DescriptionElement
        {
            get
            {
                return I.T( "Contract type|423");
            }
        }

        /// /////////////////////////////////////////////
        protected override void MyInitValeurDefaut()
        {
            GestionSitesManuel = false;
            GestionMaintenancePreventive = false;
            GestionMaintenanceCorrective = false;
        }

        /// /////////////////////////////////////////////
        public override string[] GetChampsTriParDefaut()
        {
            return new string[] { c_champLibelle };
        }

        //---------------------------------------------------
        /// <summary>
        /// Le libellé du type de contrat
        /// </summary>
        [TableFieldProperty(c_champLibelle, 255)]
        [DynamicField("Label")]
        [RechercheRapide]
        [DescriptionField]
        [TiagField("Label")]
        public string Libelle
        {
            get
            {
                return (string)Row[c_champLibelle];
            }
            set
            {
                Row[c_champLibelle] = value;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// Indicateur de gestion manuelle des sites (si VRAI),<br/>
        /// sinon, gestion par profil
        /// </summary>
        [TableFieldProperty(c_champGestionSitesManuel)]
        [DynamicField("Manual Site Management")]
        public bool GestionSitesManuel
        {
            get
            {
                return (bool)Row[c_champGestionSitesManuel];
            }
            set
            {
                Row[c_champGestionSitesManuel] = value;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// Indicateur de type pour maintenance corrective
        /// </summary>
        [TableFieldProperty(c_champGestionMaintenanceCorretive)]
        [DynamicField("Corrective Maintenance Management")]
        public bool GestionMaintenanceCorrective
        {
            get
            {
                return (bool)Row[c_champGestionMaintenanceCorretive];
            }
            set
            {
                Row[c_champGestionMaintenanceCorretive] = value;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// Indicateur de type pour maintenance préventive
        /// </summary>
        [TableFieldProperty(c_champGestionMaintenancePreventive)]
        [DynamicField("Preventive Maintenance Management")]
        public bool GestionMaintenancePreventive
        {
            get
            {
                return (bool)Row[c_champGestionMaintenancePreventive];
            }
            set
            {
                Row[c_champGestionMaintenancePreventive] = value;
            }
        }
        
        //-------------------------------------------------------------------
        /// <summary>
        /// Formulaire pour saisie du compte rendu d'opération
        /// </summary>
        [Relation(
            CFormulaire.c_nomTable,
            CFormulaire.c_champId,
            CTypeContrat.c_champIdForm,
            false,
            false,
            false)]
        [DynamicField("Contrat Report Form")]
        public CFormulaire Formulaire
        {
            get
            {
                return (CFormulaire)GetParent(CTypeContrat.c_champIdForm, typeof(CFormulaire));
            }
            set
            {
                SetParent(CTypeContrat.c_champIdForm, value);
            }
        }


        //---------------------------------------------------------
        public IRelationDefinisseurChamp_ChampCustom[] RelationsChampsCustomDefinis
        {
            get { return new IRelationDefinisseurChamp_ChampCustom[0]; }
        }

        //---------------------------------------------------------
        public IRelationDefinisseurChamp_Formulaire[] RelationsFormulaires
        {
            get
            {
                if (Formulaire != null)
                {
                    CRelationDefinisseurChamp_FormulaireStatic rel = new CRelationDefinisseurChamp_FormulaireStatic(this, Formulaire);
                    return new IRelationDefinisseurChamp_Formulaire[] { rel };
                }
                return new IRelationDefinisseurChamp_Formulaire[0];
            }
        }

        //---------------------------------------------------------
        public CChampCustom[] TousLesChampsAssocies
        {
            get
            {
                List<CChampCustom> lst = new List<CChampCustom>();
                if (Formulaire!= null)
                    foreach (CRelationFormulaireChampCustom rel in Formulaire.RelationsChamps)
                        lst.Add(rel.Champ);
                return lst.ToArray();
            }
        }



        //-----------------------------------------------------------------------
        public CRoleChampCustom RoleChampCustomDesElementsAChamp
        {
            get
            {
                return CRoleChampCustom.GetRole(CContrat.c_roleChampCustom);
            }
        }

    }
}
