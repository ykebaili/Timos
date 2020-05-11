using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;
using sc2i.process;

using timos.acteurs;
using tiag.client;
using timos.data.interventions;

namespace timos.data
{
    /// <summary>
    /// Type pour les <see cref="CIntervention">interventions</see>.<br/>
    /// Un type d'intervention définit pour les interventions de ce type :<br/>
    /// <ul>
    /// <li>une durée habituelle, exprimée en heures qui peut cependant être modifiée sur l'intervention</li>
    /// <li>le nombre d'intervenants possible, avec pour chacun d'eux le profil permettant de le sélectionner sur l'intervention</li>
    /// <li>la liste des types d'opérations directement associées</li>
    /// <li>la liste des contraintes à satisfaire</li>
    /// <li>les formulaires associés</li>
    /// <li>les contacts possibles</li>
    /// <li>le profil pour sélection de l'acteur pré-planificateur</li>
    /// <li>le profil pour sélection de l'acteur planificateur</li>
    /// <li>le type d'activité associé</li>
    /// </ul>
    /// </summary>
    [DynamicClass("Intervention type")]
    [Table(CTypeIntervention.c_nomTable, CTypeIntervention.c_champId, true)]
    [FullTableSync]
    [ObjetServeurURI("CTypeInterventionServeur")]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IngeProjet_ID,
        Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersPreventives_ID,
        Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersCorrectives_ID)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_TypeInterEtOps_ID)]
    [TiagClass(CTypeIntervention.c_nomTiag, "Id", true)]
    [AutoExec("Autoexec")]
    public class CTypeIntervention :
        CElementAChamp,
        IObjetALectureTableComplete,
        IDefinisseurChampCustomRelationObjetDonnee,
        IPossesseurContrainte,
        ITypeElementAContacts,
        IDefinisseurEvenements,
        IFournisseurListeTypeOperation
    {
        public const string c_nomTable = "INTER_TYPE";
        public const string c_nomTiag = "Intervention Type";

        public const string c_champId = "INTERTP_ID";
        public const string c_champLibelle = "INTERTP_LABEL";
        public const string c_champCode = "INTERTP_CODE";
        public const string c_champMnemomnique = "INTERTP_MEMOMNIC";
        public const string c_champDureeStandard = "INTERTP_DURATION_HOURS";
        public const string c_champDescriptif = "INTERTP_DESC";

        public const string c_champIdProfilRessource = "TYPEINTER_IDRESPR";
        public const string c_champIdProfilPreplanifieur = "TYPEINTER_PREPLA_PROF_ID";
        public const string c_champIdProfilPlanifieur = "TYPEINTER_PLAN_PROF_ID";

        public const string c_champDataRemplissage = "INTERTP_DATA_FILL";
        public const string c_champFiltreIntervenants = "INTERTP_OPERATOR_FILTER";

        public const string c_roleChampCustom = "INTERVENTION_TYPE";

        /// /////////////////////////////////////////////
        public CTypeIntervention(CContexteDonnee contexte)
            : base(contexte)
        {
        }

        /// /////////////////////////////////////////////
        public CTypeIntervention(DataRow row)
            : base(row)
        {
        }

        //-------------------------------------------------------------------
        public static void Autoexec()
        {
            CRoleChampCustom.RegisterRole(c_roleChampCustom, "Intervention type", typeof(CTypeIntervention), typeof(CDefinisseurChampsPourTypeSansDefinisseur));
        }

        /// /////////////////////////////////////////////
        public override string DescriptionElement
        {
            get
            {
                return I.T("Intervention type|123") + " " + Libelle;
            }
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

        //----------------------------------------------
        /// <summary>
        /// Libellé du type d'intervention
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

        ////////////////////////////////////////////////
        /// <summary>
        /// code de ce type de Intervention
        /// </summary>
        [TableFieldProperty(CTypeIntervention.c_champCode, 64)]
        [DynamicField("Code")]
        [RechercheRapide]
        [TiagField("Code")]
        public string Code
        {
            get
            {
                return (string)Row[c_champCode];
            }
            set
            {
                Row[c_champCode] = value;
            }
        }



        //-----------------------------------------------------------
        /// <summary>
        /// Mnemonique du type d'intervention
        /// </summary>
        [TableFieldProperty(c_champMnemomnique, 64)]
        [RechercheRapide]
        [DynamicField("Mnemonic")]
        [TiagField("Mnemonic")]
        public string Mnemomnique
        {
            get
            {
                return (string)Row[c_champMnemomnique];
            }
            set
            {
                Row[c_champMnemomnique] = value;
            }
        }


        //-----------------------------------------------------------
        /// <summary>
        /// Durée habituelle pour une intervention de ce type
        /// </summary>
        [TableFieldProperty(c_champDureeStandard)]
        [DynamicField("Standard duration")]
        [TiagField("Standard duration")]
        public double DureeStandardHeures
        {
            get
            {
                return (double)Row[c_champDureeStandard];
            }
            set
            {
                Row[c_champDureeStandard] = value;
            }
        }


        //-----------------------------------------------------------
        /// <summary>
        /// Description
        /// </summary>
        [TableFieldProperty(c_champDescriptif, 1024)]
        [DynamicField("Description")]
        [TiagField("Description")]
        public string Descriptif
        {
            get
            {
                return (string)Row[c_champDescriptif];
            }
            set
            {
                Row[c_champDescriptif] = value;
            }
        }

        /// /////////////////////////////////////////////////////////
        [TableFieldProperty(CTypeIntervention.c_champDataRemplissage, NullAutorise = true)]
        public CDonneeBinaireInRow DataRemplissage
        {
            get
            {
                if (Row[c_champDataRemplissage] == DBNull.Value)
                {
                    CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession, Row, c_champDataRemplissage);
                    CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champDataRemplissage, donnee);
                }
                object obj = Row[c_champDataRemplissage];
                return ((CDonneeBinaireInRow)obj).GetSafeForRow(Row.Row);
            }
            set
            {
                Row[c_champDataRemplissage] = value;
            }
        }


        /// /////////////////////////////////////////////////////////
        [BlobDecoder]
        public CParametreRemplissageActiviteParIntervention ParametreRemplissageActivite
        {
            get
            {
                CDonneeBinaireInRow data = DataRemplissage;
                if (data != null && data.Donnees != null)
                {
                    try
                    {
                        MemoryStream stream = new MemoryStream(data.Donnees);
                        BinaryReader reader = new BinaryReader(stream);
                        CSerializerReadBinaire serializer = new CSerializerReadBinaire(reader);
                        CParametreRemplissageActiviteParIntervention parametre = new CParametreRemplissageActiviteParIntervention();
                        CResultAErreur result = parametre.Serialize(serializer);
                        reader.Close();
                        stream.Close();
                        if (result)
                            return parametre;
                    }
                    catch
                    {
                    }
                }
                return null;
            }
            set
            {
                if (value == null)
                {
                    CDonneeBinaireInRow data = DataRemplissage;
                    data.Donnees = null;
                    DataRemplissage = data;
                }
                else
                {
                    MemoryStream stream = new MemoryStream();
                    try
                    {
                        BinaryWriter writer = new BinaryWriter(stream);
                        CSerializerSaveBinaire serializer = new CSerializerSaveBinaire(writer);
                        CResultAErreur result = value.Serialize(serializer);
                        if (result)
                        {
                            CDonneeBinaireInRow data = DataRemplissage;
                            data.Donnees = stream.GetBuffer();
                            DataRemplissage = data;
                        }
                        writer.Close();
                    }
                    catch
                    {
                        CDonneeBinaireInRow data = DataRemplissage;
                        data.Donnees = null;
                        DataRemplissage = data;
                    }
                    stream.Close();
                }
            }
        }



        //-----------------------------------------------------------------------
        public CListeObjetsDonnees RelationsChampsCustomListe
        {
            get
            {
                return GetDependancesListe(CRelationTypeIntervention_ChampCustom.c_nomTable, c_champId);
            }
        }

        //-----------------------------------------------------------------------
        public CListeObjetsDonnees RelationsFormulairesListe
        {
            get
            {
                return GetDependancesListe(CRelationTypeIntervention_Formulaire.c_nomTable, c_champId);
            }
        }

        //-----------------------------------------------------------------------
        public IRelationDefinisseurChamp_ChampCustom[] RelationsChampsCustomDefinis
        {
            get
            {
                return (IRelationDefinisseurChamp_ChampCustom[])RelationsChampsCustomListe.ToArray(typeof(IRelationDefinisseurChamp_ChampCustom));
            }
        }

        //-----------------------------------------------------------------------
        public IRelationDefinisseurChamp_Formulaire[] RelationsFormulaires
        {
            get
            {
                return (IRelationDefinisseurChamp_Formulaire[])RelationsFormulairesListe.ToArray(typeof(IRelationDefinisseurChamp_Formulaire));
            }
        }

        //-----------------------------------------------------------------------
        public CRoleChampCustom RoleChampCustomDesElementsAChamp
        {
            get
            {
                return CRoleChampCustom.GetRole(CIntervention.c_roleChampCustom);
            }
        }

        //-----------------------------------------------------------------------
        public CChampCustom[] TousLesChampsAssocies
        {
            get
            {
                return CRecuperateurTousChampsAssociesADefinisseur.GetTousLesChampsAssociesA(this);
            }
        }



        //---------------------------------------------
        /// <summary>
        /// Retourne la liste des relations entre le type d'intervention et les types d'opérations associées
        /// </summary>
        [RelationFille(typeof(CTypeIntervention_TypeOperation), "TypeIntervention")]
        [DynamicChilds("Operation type relations", typeof(CTypeIntervention_TypeOperation))]
        public CListeObjetsDonnees RelationsTypesOperations
        {
            get
            {
                return GetDependancesListe(CTypeIntervention_TypeOperation.c_nomTable, c_champId);
            }
        }

        //---------------------------------------------------------------------------
        /// <summary>
        /// Retourne la liste des contraintes à satisfaire pour les interventions de ce type
        /// </summary>
        [RelationFille(typeof(CContrainte), "TypeIntervention")]
        [DynamicChilds("Constraints", typeof(CContrainte))]
        public CListeObjetsDonnees Contraintes
        {
            get
            {
                return GetDependancesListe(CContrainte.c_nomTable, c_champId);
            }
        }

        //---------------------------------------------------------------------------
        public List<CContrainte> ToutesLesContraintes
        {
            get
            {
                List<CContrainte> lst = new List<CContrainte>();
                foreach (CContrainte contrainte in Contraintes)
                    lst.Add(contrainte);
                return lst;
            }
        }

        //---------------------------------------------------------------------------
        /// <summary>
        /// Retourne la liste des relations entre le type d'intervention<br/>
        /// et les profils d'intervenants, afin de pouvoir fournir<br/>
        /// sur les interventions de ce type, des listes d'acteurs,<br/>
        /// filtrés suivant ces profils. Permet par exemple de filtrer<br/>
        /// les acteurs en fonction de compétences particulières.
        /// </summary>
        [RelationFille(typeof(CTypeIntervention_ProfilIntervenant), "TypeIntervention")]
        [DynamicChilds("Relations profils intervenants", typeof(CTypeIntervention_ProfilIntervenant))]
        public CListeObjetsDonnees RelationsProfilsIntervenants
        {
            get
            {
                return GetDependancesListe(CTypeIntervention_ProfilIntervenant.c_nomTable, c_champId);
            }
        }

        public void TiagSetTypeActiviteActeurKeys(object[] lstCles)
        {
            CTypeActiviteActeur tp = new CTypeActiviteActeur(ContexteDonnee);
            if (tp.ReadIfExists(lstCles))
                TypeActiviteActeur = tp;
        }
        //---------------------------------------------------------------------------
        /// <summary>
        /// Cette relation est utilisée pour la création d'un objet Activite Acteur
        /// à partir d'une Intervention
        /// </summary>
        [Relation(
            CTypeActiviteActeur.c_nomTable,
            CTypeActiviteActeur.c_champId,
            CTypeActiviteActeur.c_champId,
            false,
            false,
            false)]
        [DynamicField("Member activity type")]
        [TiagRelation(typeof(CTypeActiviteActeur), "TiagSetTypeActiviteActeurKeys")]
        public CTypeActiviteActeur TypeActiviteActeur
        {
            get
            {
                return (CTypeActiviteActeur)GetParent(CTypeActiviteActeur.c_champId, typeof(CTypeActiviteActeur));
            }
            set
            {
                SetParent(CTypeActiviteActeur.c_champId, value);
            }
        }


        //-------------------------------------------------------------------
        /// <summary>
        /// Donne ou définit le profil de ressource pour lever les contraintes
        /// </summary>
        [Relation(
            CProfilElement.c_nomTable,
            CProfilElement.c_champId,
            CTypeIntervention.c_champIdProfilRessource,
            false,
            false,
            false)]
        [DynamicField("Defaut resource profile")]
        public CProfilElement ProfilRessourceDefaut
        {
            get
            {
                return (CProfilElement)GetParent(CTypeIntervention.c_champIdProfilRessource, typeof(CProfilElement));
            }
            set
            {
                SetParent(CTypeIntervention.c_champIdProfilRessource, value);
            }
        }


        //-------------------------------------------------------------------
        /// <summary>
        /// Donne ou définit le profil de l'acteur planificateur
        /// </summary>
        [Relation(
            CProfilElement.c_nomTable,
            CProfilElement.c_champId,
            CTypeIntervention.c_champIdProfilPlanifieur,
            false,
            false,
            false)]
        [DynamicField("Planner profile")]
        public CProfilElement ProfilPlanifieur
        {
            get
            {
                return (CProfilElement)GetParent(CTypeIntervention.c_champIdProfilPlanifieur, typeof(CProfilElement));
            }
            set
            {
                SetParent(CTypeIntervention.c_champIdProfilPlanifieur, value);
            }
        }



        //-------------------------------------------------------------------
        /// <summary>
        /// Donne ou définit le profil de l'acteur pré-planificateur
        /// </summary>
        [Relation(
            CProfilElement.c_nomTable,
            CProfilElement.c_champId,
            CTypeIntervention.c_champIdProfilPreplanifieur,
            false,
            false,
            false)]
        [DynamicField("PrePlanner profile")]
        public CProfilElement ProfilPreplanifieur
        {
            get
            {
                return (CProfilElement)GetParent(CTypeIntervention.c_champIdProfilPreplanifieur, typeof(CProfilElement));
            }
            set
            {
                SetParent(CTypeIntervention.c_champIdProfilPreplanifieur, value);
            }
        }


        /// /////////////////////////////////////////////////////////
        [TableFieldProperty(c_champFiltreIntervenants, NullAutorise = true)]
        public CDonneeBinaireInRow DonneeFiltreIntervenants
        {
            get
            {
                if (Row[c_champFiltreIntervenants] == DBNull.Value)
                {
                    CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession, Row, c_champFiltreIntervenants);
                    CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champFiltreIntervenants, donnee);
                }
                object obj = Row[c_champFiltreIntervenants];
                return ((CDonneeBinaireInRow)obj).GetSafeForRow(Row.Row);
            }
            set
            {
                Row[c_champFiltreIntervenants] = value;
            }
        }

        /// /////////////////////////////////////////////////////////////
        /// <summary>
        /// Filtre les Type d'éléments "Data" (ou cellule du tableau)
        /// </summary>
        [BlobDecoder]
        public CFiltreDynamique FiltreDynamiqueIntervenants
        {
            get
            {
                CFiltreDynamique filtre = null;
                if (DonneeFiltreIntervenants.Donnees != null)
                {
                    filtre = new CFiltreDynamique(ContexteDonnee);
                    MemoryStream stream = new MemoryStream(DonneeFiltreIntervenants.Donnees);
                    BinaryReader reader = new BinaryReader(stream);
                    CSerializerReadBinaire serializer = new CSerializerReadBinaire(reader);
                    CResultAErreur result = filtre.Serialize(serializer);
                    if (!result)
                    {
                        filtre = null;
                    }
                    reader.Close();
                    stream.Close();
                }

                return filtre;
            }
            set
            {
                if (value == null)
                {
                    CDonneeBinaireInRow data = DonneeFiltreIntervenants;
                    data.Donnees = null;
                    DonneeFiltreIntervenants = data;
                }
                else
                {
                    MemoryStream stream = new MemoryStream();
                    BinaryWriter writer = new BinaryWriter(stream);
                    CSerializerSaveBinaire serializer = new CSerializerSaveBinaire(writer);
                    CResultAErreur result = value.Serialize(serializer);
                    if (result)
                    {
                        CDonneeBinaireInRow data = DonneeFiltreIntervenants;
                        data.Donnees = stream.GetBuffer();
                        DonneeFiltreIntervenants = data;
                    }
                    writer.Close();
                    stream.Close();
                }
            }
        }





        #region ITypeElementAContacts
        //-------------------------------------------------------------------
        /// <summary>
        /// Retourne la liste des Objets liant les profils aux acteurs<br/>
        /// correspondant au type d'intervention
        /// </summary>
        [RelationFille(typeof(CActeursSelonProfil), "TypeIntervention")]
        [DynamicChilds("Contacts", typeof(CActeursSelonProfil))]
        public List<CActeursSelonProfil> ProfilsContacts
        {
            get
            {
                List<CActeursSelonProfil> lstret = new List<CActeursSelonProfil>();
                CListeObjetsDonnees lst = GetDependancesListe(CActeursSelonProfil.c_nomTable, c_champId);
                foreach (CObjetDonnee obj in lst)
                    lstret.Add((CActeursSelonProfil)obj);

                return lstret;
            }
        }

        //--------------------------------------------------------------------
        /// <summary>
        /// Modèle de texte employé pour la présentation de la liste des contacts possibles
        /// </summary>
        [RelationAttribute(
            CModeleTexte.c_nomTable,
            CModeleTexte.c_champId,
            CModeleTexte.c_champId,
            false,
            false,
            false)]
        [DynamicField("Text model of possible actors")]
        public CModeleTexte ModeleTexteContacts
        {
            get
            {
                return (CModeleTexte)GetParent(CModeleTexte.c_champId, typeof(CModeleTexte));
            }
            set
            {
                SetParent(CModeleTexte.c_champId, value);
            }
        }

        public Type TypeDesElementsAContacts
        {
            get
            {
                return typeof(CIntervention);
            }
        }

        #endregion

        #region IDefinisseurEvenements Membres

        //---------------------------------------------------------
        public CComportementGenerique[] ComportementsInduits
        {
            get
            {
                return CUtilDefinisseurEvenement.GetComportementsInduits(this);
            }
        }

        //---------------------------------------------------------
        public CListeObjetsDonnees Evenements
        {
            get
            {
                return CUtilDefinisseurEvenement.GetEvenementsFor(this);
            }
        }

        //---------------------------------------------------------
        public Type[] TypesCibleEvenement
        {
            get
            {
                return new Type[] { typeof(CIntervention) };
            }
        }

        #endregion

        #region IFournisseurListeTypeOperation Membres

        public CListeObjetsDonnees GetListeTypesOperations(CContexteDonnee contexte)
        {
            CListeObjetsDonnees liste = new CListeObjetsDonnees(
                contexte, typeof(CTypeOperation));

            liste.Filtre = new CFiltreDataAvance(
                CTypeOperation.c_nomTable,
                CTypeIntervention_TypeOperation.c_nomTable + "." +
                CTypeIntervention.c_champId + "=@1",
                this.Id);

            return liste;
        }

        #endregion

        public override IDefinisseurChampCustom[] DefinisseursDeChamps
        {
            get
            {
                return new IDefinisseurChampCustom[]{
                    new CDefinisseurChampsPourTypeSansDefinisseur(
                        ContexteDonnee, 
                        CRoleChampCustom.GetRole(CTypeIntervention.c_roleChampCustom) )};
            }
        }

        public override CRelationElementAChamp_ChampCustom GetNewRelationToChamp()
        {
            return new CRelationTypeIntervention_ChampCustomValeur(ContexteDonnee);
        }

        [RelationFille(typeof(CRelationTypeIntervention_ChampCustomValeur), "ElementAChamps")]
        public override CListeObjetsDonnees RelationsChampsCustom
        {
            get
            {
                return GetDependancesListe(CRelationTypeIntervention_ChampCustomValeur.c_nomTable, c_champId);
            }
        }

        public override CRoleChampCustom RoleChampCustomAssocie
        {
            get
            {
                return CRoleChampCustom.GetRole(CTypeIntervention.c_roleChampCustom);
            }
        }

        //---------------------------------------------
        /// <summary>
        /// Toutes les interventions de ce type
        /// </summary>
        [RelationFille(typeof(CIntervention), "TypeIntervention")]
        [DynamicChilds("Interventions", typeof(CIntervention))]
        public CListeObjetsDonnees Interventions
        {
            get
            {
                return GetDependancesListe(CIntervention.c_nomTable, c_champId);
            }
        }
    }

}
