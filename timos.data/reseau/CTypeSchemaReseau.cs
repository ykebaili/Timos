using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;
using timos.securite;
using tiag.client;
using sc2i.doccode;

namespace timos.data
{


    /// <summary>
    /// Type de schéma réseau.
    /// Définit le comportement pour tous les <see cref="CSchemaReseau">schémas réseau</see> de ce type,
    /// par exemple, c'est au niveau du type de schéma réseau que se fait
    /// l'association avec les formulaires personnalisés à afficher au niveau des schémas réseau de ce type.
    /// </summary>
    [DynamicClass("Network diagram type")]
    [Table(CTypeSchemaReseau.c_nomTable, CTypeSchemaReseau.c_champId, true)]
    [ObjetServeurURI("CTypeSchemaReseauServeur")]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_Liaisons_ID)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_Liaisons_ID)]
    [Unique(false, "The label of this diagram type is already used", CTypeSchemaReseau.c_champLibelle)]
    [TiagClass("Network diagram type", "Id", true)]
    public class CTypeSchemaReseau : CObjetDonneeAIdNumeriqueAuto,
        IDefinisseurChampCustomRelationObjetDonnee,
        IDefinisseurSymbole,
        IObjetALectureTableComplete
    {
        public const string c_nomTable = "NTW_DIAG_TYPE";
        public const string c_champId = "NTW_DIAG_TYPE_ID";
        public const string c_champLibelle = "NTW_DIAG_TYPE_LABEL";
      

        /// /////////////////////////////////////////////
        public CTypeSchemaReseau(CContexteDonnee contexte)
            : base(contexte)
        {
        }

        /// /////////////////////////////////////////////
        public CTypeSchemaReseau(DataRow row)
            : base(row)
        {
        }

        /// /////////////////////////////////////////////
        // Decription du Type de schéma réseau
        public override string DescriptionElement
        {
            get { return I.T("Network Diagram Type: @1|30082", Libelle); }
        }


        /// /////////////////////////////////////////////
        protected override void MyInitValeurDefaut()
        {
        }

        /// /////////////////////////////////////////////
        public override string[] GetChampsTriParDefaut()
        {
            return new string[] { c_champLibelle };
        }

        /////////////////////////////////////////////
        /// <summary>
        /// Indique libellé pour ce Type de schéma réseau. Ce champ texte de 255 caractères est obligatoire et unique.
        /// </summary>
        [TableFieldProperty(c_champLibelle, 255)]
        [DynamicField("Label")]
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



        #region IDefinisseurChampCustomRelationObjetDonnee Membres

        /// <summary>
        /// Donne la liste des relations entre le <see cref="CRelationTypeSchemaReseau_ChampCustom">type de schéma réseau et les champs personnalisés</see>
        /// </summary>
        [RelationFille(typeof(CRelationTypeSchemaReseau_ChampCustom), "Definisseur")]
        [DynamicChilds("Custom fields relations", typeof(CRelationTypeSchemaReseau_ChampCustom))]
        public CListeObjetsDonnees RelationsChampsCustomListe
        {
            get { return GetDependancesListe(CRelationTypeSchemaReseau_ChampCustom.c_nomTable, c_champId); }
        }


        /// <summary>
        /// Donne la liste des relations entre le <see cref="CRelationTypeSchemaReseau_Formulaire">type de schéma réseau et les formulaires personnalisés</see>
        /// </summary>
        [RelationFille(typeof(CRelationTypeSchemaReseau_Formulaire), "Definisseur")]
        [DynamicChilds("Form relations", typeof(CRelationTypeSchemaReseau_Formulaire))]
        public CListeObjetsDonnees RelationsFormulairesListe
        {
            get { return GetDependancesListe(CRelationTypeSchemaReseau_Formulaire.c_nomTable, c_champId); }
        }


        #endregion








        #region IDefinisseurChampCustom Membres

        /// /////////////////////////////////////////////
        public IRelationDefinisseurChamp_ChampCustom[] RelationsChampsCustomDefinis
        {
            get
            {
                return (IRelationDefinisseurChamp_ChampCustom[])RelationsChampsCustomListe.ToArray(typeof(IRelationDefinisseurChamp_ChampCustom));
            }
        }

        /// /////////////////////////////////////////////
        public IRelationDefinisseurChamp_Formulaire[] RelationsFormulaires
        {
            get
            {
                return (IRelationDefinisseurChamp_Formulaire[])RelationsFormulairesListe.ToArray(typeof(IRelationDefinisseurChamp_Formulaire));
            }
        }

        /// /////////////////////////////////////////////
        public CRoleChampCustom RoleChampCustomDesElementsAChamp
        {
            get
            {
                return CRoleChampCustom.GetRole(CSchemaReseau.c_roleChampCustom);
            }
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




        #region IDefinisseurSymbole Membres

        public CSymbole Symbole
        {
            get
            {
                if (SymbolePropre != null)
                    return SymbolePropre;
                if (SymboleDeBibliotheque != null)
                    return SymboleDeBibliotheque.Symbole;
                return null;
            }
        }


        /// <summary>
        /// Obtient ou définit le <see cref="CSymboleDeBibliotheque">symbole graphique de bibliothèque</see> associé au type de schéma réseau, lorsqu'il existe
        /// </summary>
        [Relation(
            CSymboleDeBibliotheque.c_nomTable,
           CSymboleDeBibliotheque.c_champId,
          CSymboleDeBibliotheque.c_champId,
            false,
            false,
            false)]
        [DynamicField("Library Symbol")]
        public CSymboleDeBibliotheque SymboleDeBibliotheque
        {
            get
            {
                return (CSymboleDeBibliotheque)GetParent(CSymboleDeBibliotheque.c_champId, typeof(CSymboleDeBibliotheque));
            }
            set
            {
                if (SymbolePropre != null)
                {

                    SymbolePropre = null;
                }
                SetParent(CSymboleDeBibliotheque.c_champId, value);

            }

        }

        [RelationFille(typeof(CSymbole), "TypeSite")]
        public CSymbole SymbolePropre
        {

            get
            {
                CListeObjetsDonneesContenus liste = GetDependancesListe(CSymbole.c_nomTable, CTypeSchemaReseau.c_champId);
                if (liste.Count > 0)
                    return (CSymbole)liste[0];
                else
                    return null;
            }

            set
            {


                Row[CSymboleDeBibliotheque.c_champId] = null;
                if (value == null)
                {
                    if (SymbolePropre != null)
                        SymbolePropre.Delete();
                }
                else
                {
                    value.TypeSchemaReseau = this;
                }



            }

        }

        public Type GetTypePourLequelOnSelectionneUnSymbole()
        {
            return typeof(CSchemaReseau);
        }

        #endregion

       

        public C2iSymbole SymboleDefiniADessiner
        {
            get
            {
                C2iSymbole symbole = null;
                if (Symbole != null)
                    symbole = Symbole.Symbole;
                if (symbole == null)
                    symbole = CSymbole.GetSymboleParDefaut(typeof(CSchemaReseau), ContexteDonnee);
                return symbole;
            }
        }


        /// <summary>
        /// Donne la liste des <see cref="CSchemaReseau">schémas réseau</see> de ce type de schéma
        /// </summary>
        [RelationFille(typeof(CSchemaReseau), "TypeSchemaReseau")]
        [DynamicChilds("Network diagrams", typeof(CSchemaReseau))]
        public CListeObjetsDonnees Schemas
        {
            get
            {
                return GetDependancesListe(CSchemaReseau.c_nomTable, c_champId);
            }
        }

    }
}
