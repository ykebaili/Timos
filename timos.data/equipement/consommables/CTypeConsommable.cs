using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.data;
using System.Data;
using sc2i.common;
using sc2i.common.unites;
using sc2i.data.dynamic;
using System.Collections;
using timos.data.commandes;
using sc2i.expression;

namespace timos.data.equipement.consommables
{
    [DynamicClass("Consumable Type")]
    [ObjetServeurURI("CTypeConsommableServeur")]
    [Table(CTypeConsommable.c_nomTable, CTypeConsommable.c_champId, true)]
    [AutoExec("RegisterRole")]
    [DynamicIcon(typeof(CLotConsommable), ETypeIconeDynamique.EType)]
    public class CTypeConsommable : CObjetDonneeAIdNumeriqueAuto,
        IObjetDonneeAChamps,
        IDefinisseurChampCustomRelationObjetDonnee,
        IElementCommandable
    {
        public const string c_roleChampCustom = "CONSUMABLE_TYPE";
        public const string c_nomTable = "CONSUMABLE_TYPE";
        public const string c_champId = "CONSUMABLETYPE_ID";
        public const string c_champLibelle = "CONSUMABLETYPE_LABEL";
        public const string c_champGestionParLot = "CONSUMTYPE_LOTMNGMT";
        public const string c_champSortieStockDefinitive = "CONSUMTYPE_FINALOUT";
        public const string c_champUniteString = "CONSUMTYPE_UNIT";
        public const string c_champClasseUniteString = "CONSUMTYPE_UNIT_CLASS";


        public CTypeConsommable(CContexteDonnee context)
            : base(context)
        {
        }

        public CTypeConsommable(DataRow row)
            : base(row)
        {
        }



        public static void RegisterRole()
        {
            CRoleChampCustom.RegisterRole(CTypeConsommable.c_roleChampCustom, I.T("Consumable Type|10033"), typeof(CTypeConsommable), typeof(CFamilleEquipement));
        }

        public override string DescriptionElement
        {
            get 
            {
                return I.T("Consumable Type @1|10030", Libelle);
            }
        }

        public override string[] GetChampsTriParDefaut()
        {
            return new string[] { c_champLibelle };
        }

        protected override void MyInitValeurDefaut()
        {
            
        }

		//-----------------------------------------------------------
		/// <summary>
		/// Libellé du type de consommable
		/// </summary>
		[TableFieldProperty ( c_champLibelle, 500 )]
		[DynamicField("Label")]
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

        //------------------------------------------------------------------
        /// <summary>
        /// Indique si les consommables de ce type peuvent être gerés par lot identifié
        /// </summary>
        [TableFieldProperty(c_champGestionParLot)]
        [DynamicField("Lot Management")]
        public bool GestionParLot
        {
            get
            {
                return (bool)Row[c_champGestionParLot];
            }
            set
            {
                Row[c_champGestionParLot] = value;
            }
        }

        //------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [TableFieldProperty(c_champSortieStockDefinitive)]
        [DynamicField("Final Stock Output")]
        public bool SortieDefinitive
        {
            get
            {
                return (bool)Row[c_champSortieStockDefinitive];
            }
            set
            {
                Row[c_champSortieStockDefinitive] = value;
            }
        }
        //------------------------------------------------------------------
        /// <summary>
        /// Code de l'nité de base pour ce type de consommables
        /// </summary>
        [TableFieldProperty(c_champUniteString, 200)]
        [DynamicField("Unit string")]
        public string UniteString
        {
            get
            {
                return (string)Row[c_champUniteString];
            }
            set
            {
                Row[c_champUniteString] = value;
            }
        }

        //------------------------------------------------------------------
        /// <summary>
        /// Code de la classe de l'unité de base
        /// </summary>
        [TableFieldProperty(c_champClasseUniteString, 200)]
        [DynamicField("Unit class string")]
        public string UniteClassString
        {
            get
            {
                return (string)Row[c_champClasseUniteString];
            }
            set
            {
                Row[c_champClasseUniteString] = value;
            }
        }

        //------------------------------------------------------------------
        public IClasseUnite ClasseUnite
        {
            get
            {
                IClasseUnite classe = CGestionnaireUnites.GetClasse(UniteClassString);
                return classe;
            }
            set
            {
                if (value != null)
                    UniteClassString = value.GlobalId;
                else
                    UniteClassString = "";
            }
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// Obtient ou définit l'Unité avec laquelle ce Type de Consommable est dénombré
        /// </summary>
        [DynamicField("Unit")]
        public IUnite Unite
        {
            get
            {
                if ( UniteString.Length > 0 )
                    return CGestionnaireUnites.GetUnite(UniteString);
                if (ClasseUnite != null)
                    return CGestionnaireUnites.GetUnite(ClasseUnite.UniteBase);
                return null;
            }
            set
            {
                if (value != null)
                {
                    UniteString = value.GlobalId;
                    ClasseUnite = value.Classe;
                }
                else
                    UniteString = "";
            } 
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// Obtient ou définit la Famille d'équipement à laquelle appartient ce Type de Consommable
        /// </summary>
        [Relation(
            CFamilleEquipement.c_nomTable,
            CFamilleEquipement.c_champId,
            CFamilleEquipement.c_champId,
            true,
            false,
            false)]
        [DynamicField("Family")]
        public CFamilleEquipement Famille
        {
            get
            {
                return (CFamilleEquipement)GetParent(CFamilleEquipement.c_champId, typeof(CFamilleEquipement));
            }
            set
            {
                SetParent(CFamilleEquipement.c_champId, value);
            }
        }


        //-------------------------------------------------------------------------------
        /// <summary>
        /// Retorune la liste des <see cref="CLotConsommable"> Lots de Consommable </see>de ce Type de Consommable
        /// </summary>
        [RelationFille(typeof(CLotConsommable), "TypeConsommable")]
        [DynamicChilds("Consumable Lots", typeof(CLotConsommable))]
        public CListeObjetsDonnees LotsConsommable
        {
            get
            {
                return GetDependancesListe(CLotConsommable.c_nomTable, c_champId);
            }
        }

        //---------------------------------------------
        /// <summary>
        /// Retorune la liste des <see cref="CConditionnementConsommable"> Conditionnement </see>associés à ce Type de Consommable
        /// </summary>
        [RelationFille(typeof(CConditionnementConsommable), "TypeConsommable")]
        [DynamicChilds("Packagings", typeof(CConditionnementConsommable))]
        public CListeObjetsDonnees Conditionnements
        {
            get
            {
                return GetDependancesListe(CConditionnementConsommable.c_nomTable, c_champId);
            }
        }



        #region IObjetDonneeAChamps Membres
        //---------------------------------------------
        public CRelationElementAChamp_ChampCustom GetNewRelationToChamp()
        {
            return new CRelationTypeConsommable_ChampCustomValeur(ContexteDonnee);
        }

        //---------------------------------------------
        public string GetNomTableRelationToChamps()
        {
            return CRelationTypeConsommable_ChampCustomValeur.c_nomTable;
        }

        //---------------------------------------------
        public CListeObjetsDonnees GetRelationsToChamps(int nIdChamp)
        {
            CListeObjetsDonnees liste = RelationsChampsCustom;
            liste.InterditLectureInDB = true;
            liste.Filtre = new CFiltreData(CChampCustom.c_champId + " = @1", nIdChamp);
            return liste;
        }

        //---------------------------------------------------------
        /// <summary>
        /// Liste des relations du type d'équipement avec des champs personnalisés
        /// </summary>
        [RelationFille(typeof(CRelationTypeConsommable_ChampCustomValeur), "ElementAChamps")]
        [DynamicChilds("Custom fields relations", typeof(CRelationTypeConsommable_ChampCustomValeur))]
        public CListeObjetsDonnees RelationsChampsCustom
        {
            get
            {
                return GetDependancesListe(CRelationTypeConsommable_ChampCustomValeur.c_nomTable, c_champId);
            }
        }


        #endregion

        #region IElementAChamps Membres
        //---------------------------------------------
        public IDefinisseurChampCustom[] DefinisseursDeChamps
        {
            get
            {
                if (Famille != null)
                    return new IDefinisseurChampCustom[] { Famille.GetDefinisseurPourTypeConsommable() };
                return new IDefinisseurChampCustom[0];
            }
        }

        //---------------------------------------------
        public CChampCustom[] GetChampsHorsFormulaire()
        {
            Hashtable tableChampsFormulaire = new Hashtable();
            Hashtable tableChampsHorsFormulaire = new Hashtable();
            foreach (IDefinisseurChampCustom def in DefinisseursDeChamps)
            {
                foreach (CRelationFamilleEquipement_ChampCustom rel in def.RelationsChampsCustomDefinis)
                    tableChampsHorsFormulaire[rel.ChampCustom] = true;
                foreach (CRelationFamilleEquipement_Formulaire rel in def.RelationsFormulaires)
                    foreach (CRelationFormulaireChampCustom relF in rel.Formulaire.RelationsChamps)
                        tableChampsFormulaire[relF.Champ] = true;
            }
            foreach (CChampCustom champ in tableChampsFormulaire.Keys)
                tableChampsHorsFormulaire[champ] = false;
            ArrayList lst = new ArrayList();
            foreach (DictionaryEntry entry in tableChampsHorsFormulaire)
            {
                if ((bool)entry.Value)
                    lst.Add(entry.Key);
            }
            return (CChampCustom[])lst.ToArray(typeof(CChampCustom));
        }

        //---------------------------------------------
        public CFormulaire[] GetFormulaires()
        {
            return CUtilElementAChamps.GetFormulaires(this);
        }

        //----------------------------------------------------------------------------
        public object GetValeurChamp(int nIdChamp)
        {
            return CUtilElementAChamps.GetValeurChamp(this, nIdChamp);

        }

        //-----------------------------------------------------------------------------
        public object GetValeurChamp(int nIdChamp, DataRowVersion version)
        {
            return CUtilElementAChamps.GetValeurChamp(this, nIdChamp, version);
        }

        public object GetValeurChamp(string strIdVariable)
        {
            return CUtilElementAChamps.GetValeurChamp(this, strIdVariable);
        }

        //-----------------------------------------------------------------------------
        public object GetValeurChamp(IVariableDynamique variable)
        {
            if (variable == null)
                return null;
            return GetValeurChamp(variable.IdVariable);
        }

        //---------------------------------------------
        public CResultAErreur SetValeurChamp(string strIdVariable, object valeur)
        {
            return CUtilElementAChamps.SetValeurChamp(this, strIdVariable, valeur);
        }

        //---------------------------------------------
        public CResultAErreur SetValeurChamp(IVariableDynamique variable, object valeur)
        {
            if (variable == null)
                return CResultAErreur.True;
            return SetValeurChamp(variable.IdVariable, valeur);
        }

        //-------------------------------------------------------------------
        public CResultAErreur SetValeurChamp(int nIdChamp, object valeur)
        {
            return CUtilElementAChamps.SetValeurChamp(this, nIdChamp, valeur);
        }

        //---------------------------------------------
        public CRoleChampCustom RoleChampCustomAssocie
        {
            get { return CRoleChampCustom.GetRole( c_roleChampCustom ); }
        }
        
        #endregion


        #region IDefinisseurChampCustomRelationObjetDonnee Membres

        /// <summary>
        /// Relations vers les champs custom définis pour les lots de ce type
        /// </summary>
        [RelationFille ( typeof(CRelationTypeConsommable_ChampCustom), "Definisseur")]
        public CListeObjetsDonnees RelationsChampsCustomListe
        {
            get { return GetDependancesListe(CRelationTypeConsommable_ChampCustom.c_nomTable, c_champId); }
        }

        [RelationFille(typeof(CRelationTypeConsommable_Formulaire), "Definisseur")]
        public CListeObjetsDonnees RelationsFormulairesListe
        {
            get { return GetDependancesListe(CRelationTypeConsommable_Formulaire.c_nomTable, c_champId); }
        }

        #endregion

        #region IDefinisseurChampCustom Membres


        public IRelationDefinisseurChamp_ChampCustom[] RelationsChampsCustomDefinis
        {
            get { return (IRelationDefinisseurChamp_ChampCustom[])RelationsChampsCustomListe.ToArray(typeof(IRelationDefinisseurChamp_ChampCustom)); }
        }

        public IRelationDefinisseurChamp_Formulaire[] RelationsFormulaires
        {
            get { return (IRelationDefinisseurChamp_Formulaire[])RelationsFormulairesListe.ToArray(typeof(IRelationDefinisseurChamp_Formulaire)); }
        }

        public CRoleChampCustom RoleChampCustomDesElementsAChamp
        {
            get { return CRoleChampCustom.GetRole ( CLotConsommable.c_roleChampCustom); }
        }

        /// /////////////////////////////////////////////
        public CChampCustom[] TousLesChampsAssocies
        {
            get
            {
                Hashtable tableChamps = new Hashtable();
                FillHashtableChamps(tableChamps);
                CChampCustom[] liste = new CChampCustom[tableChamps.Count];
                int nChamp = 0;
                foreach (CChampCustom champ in tableChamps.Values)
                    liste[nChamp++] = champ;
                return liste;
            }
        }


        //---------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [RelationFille(typeof(CValorisationElement), "TypeConsommable")]
        [DynamicChilds("Valorisations", typeof(CValorisationElement))]
        public CListeObjetsDonnees Valorisations
        {
            get
            {
                return GetDependancesListe(CValorisationElement.c_nomTable, c_champId);
            }
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// Remplit une hashtable IdChamp->Champ
        /// avec tous les champs liés.(hiérarchique)
        /// </summary>
        /// <param name="tableChamps">HAshtable à remplir</param>
        private void FillHashtableChamps(Hashtable tableChamps)
        {
            foreach (IRelationDefinisseurChamp_ChampCustom relation in RelationsChampsCustomDefinis)
                tableChamps[relation.ChampCustom.Id] = relation.ChampCustom;
            foreach (IRelationDefinisseurChamp_Formulaire relation in RelationsFormulaires)
            {
                foreach (CRelationFormulaireChampCustom relFor in relation.Formulaire.RelationsChamps)
                    tableChamps[relFor.Champ.Id] = relFor.Champ;
            }
        }
        #endregion

        #region IElementCommandable Membres
        //-------------------------------------------------------------
        public IElementCommandable[] ReferencesCommandables
        {
            get
            {
                return Conditionnements.ToArray<IElementCommandable>();
            }
        }



        //---------------------------------------------
        /// <summary>
        /// Retourne la valeur d'un consommable de ce type pour une date donnée
        /// </summary>
        /// <remarks>
        /// La valeur retournée correspond à la valorisation dont la date
        /// est maximale et inférieure à la date demandée. <BR></BR>
        /// S'il n'existe pas de valorisation correspondante, <BR></BR>
        /// Si la date demandée est inférieure à la première valorisation
        /// connue, la valeur retournée est la première valorisation connue<BR></BR>
        /// Sinon, ce sera la date de la valorisation la plus récente<BR></BR>
        /// S'il n'existe pas de valorisation pour ce type d'équipement, la
        /// valeur retournée sera 0
        /// </remarks>
        /// <param name="dt"></param>
        /// <returns></returns>
        [DynamicMethod("Return valuation for a specific date", "Date")]
        public double GetValuationForDate(DateTime dt)
        {
            return GetValuationForDate(dt, new CValeurUnite(1, ""));
        }

        //------------------------------------------------------------------------
        public double GetValuationForDate(DateTime dt, CValeurUnite quantite)
        {
            CListeObjetsDonnees lstValEqpt = Valorisations;
            CListeObjetsDonnees lstLot = lstValEqpt.GetDependances("LotValorisation");
            double fQuantite = 1;
            if (quantite != null && Unite != null)
            {
                if (quantite.IUnite == null)
                    fQuantite = quantite.Valeur;
                else
                    fQuantite = quantite.ConvertTo(Unite.GlobalId).Valeur;
            }
            if (lstValEqpt.Count == 0)
                return 0;
            lstLot.Tri = CLotValorisation.c_champDateLot;
            CLotValorisation lot = lstLot[0] as CLotValorisation;
            if (lot != null && lot.DateLot.Date.AddMinutes(-1) > dt)//Premier plus récent->premier
            {
                CValorisationElement val = lot.GetValorisation(this);
                if (val != null)
                    return val.Valeur*fQuantite;
                return 0;
            }
            lstLot.InterditLectureInDB = true;
            lstLot.Filtre = new CFiltreData(CLotValorisation.c_champDateLot + "<@1",
                dt.Date.AddDays(1));
            lstLot.Tri = CLotValorisation.c_champDateLot;
            if (lstLot.Count > 0)
            {
                lot = lstLot[lstLot.Count - 1] as CLotValorisation;
                if (lot != null)
                {
                    CValorisationElement val = lot.GetValorisation(this);
                    if (val != null)
                    {
                        CValeurUnite v = val.QuantiteEtUnite;
                        IUnite monUnite = Unite;
                        if (v != null && monUnite != null)
                        {
                            v = v.ConvertTo(monUnite.GlobalId);
                            if (v.Valeur != 0)
                                return val.Valeur / v.Valeur*fQuantite;
                        }
                        return val.Valeur*fQuantite;
                    }
                }
            }
            return 0;
        }

        #endregion
    }
}
