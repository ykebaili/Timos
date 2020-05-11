using System;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using sc2i.common;
using sc2i.common.planification;
using sc2i.process;
using sc2i.multitiers.client;
using sc2i.data;
using sc2i.data.dynamic;

using timos.securite;
using timos.acteurs;
using timos.data.version;
using sc2i.expression;
using timos.data.projet.gantt;
using timos.data.projet.Contraintes;
using Lys.Licence.Types;
using Lys.Applications.Timos.Smt;
using tiag.client;
using timos.data.projet;
using timos.data.securite;
using timos.data.projet.besoin;
using System.Reflection;
using sc2i.process.workflow;
using timos.data.process.workflow;

namespace timos.data
{
    /// <summary>
    /// L'outil 'projet' permet de planifier et d'assurer le suivi de cette planification grâce à la présentation d'un diagramme de Gantt. 
    /// </summary>
    /// <remarks>
    /// Un projet peut présenter une entité très complexe comme un contrat de déploiement de plusieurs sites
    /// ou la construction d'un site, ou une tâche élémentaire comme une opération de recette ou l'installation d'un équipement.
    /// Un projet peut contenir d'autres projets, sans limitation de niveau.
    /// Outre les relations de parenté entre projets, il peut exister des relations de précédence entre projets;
    /// par exemple, le projet B ne peut démarrer que lorsque le projet A est terminé.
    /// Le diagramme de Gantt d'un projet présente le déroulement dans le temps du projet et de ses sous-projets,
    /// toutes les relations entre ces projets (parenté, précédence), ainsi que l'état de progression de ces projets.
    /// </remarks>
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iEquipement)]
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iSite)]
    [DynamicClass("Projet")]

    [ObjetServeurURI("CProjetServeur")]
    [AutoExec("Autoexec")]
    [Table(CProjet.c_nomTable, CProjet.c_champId, true)]
    [LicenceCount(CConfigTypesTimos.c_appType_Projet_ID)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IngeProjet_ID)]
    [TypeId("PROJECT")]
    [TiagClass(CProjet.c_nomTiag, "Id", true)]
    public partial class CProjet :
        CObjetHierarchique,
        IObjetDonneeAChamps,
        IElementDeProjetPlanifiable,
        IElementATypeStructurant<CTypeProjet>,
        IElementAEvenementsDefinis,
        IElementAEO,
        IElementARestrictionsSpecifiques,
        ISatisfactionBesoinAvecSousBesoins,
        IResumeurDeCouts
    {
        #region Constantes
        public const string c_nomTiag = "Project";

        public const string c_nomTable = "PROJECT";
        public const string c_champId = "PRJ_ID";
        public const string c_champDescription = "PRJ_DESCRIPTION";
        public const string c_champLibelle = "PRJ_LABEL";
        public const string c_roleChampCustom = "PROJECT";

        public const string c_champDateDebutPlanifiee = "PRJ_PLAN_START";
        public const string c_champDateFinPlanifiee = "PRJ_PLAN_END";
        public const string c_champDebutAuto = "PRJ_PLAN_START_AUTO";
        public const string c_champStartedWithoutDate = "PRJ_START_NO_DATE";
        public const string c_champEndedWithoutDate = "PRJ_END_NO_DATE";
        public const string c_champDateDebutReel = "PRJ_START_DATE";
        public const string c_champDateFinReel = "PRJ_DATE_END";
        public const string c_champDateDebutPlanifieeCalculee = "PRJ_PLAN_START_CALC";
        public const string c_champDateFinPlanifieeCalculee = "PRJ_PLAN_END_CALC";
        public const string c_champAsynchronousUpdate = "PRJ_ASYNC_UPDATE";
        public const string c_champProjectTemplateKey = "PRJ_SRC_TPL_KEY";


        public const string c_champAnomaliesProjetsFils = "PRJ_ANO_CHILDREN_PRJS";
        public const string c_champFiltresAnomaliesCode = "PRJ_ANO_FILTER_CODE";

        //Hierarchie
        public const string c_champCodeSystemePartiel = "PRJ_PARTIAL_SYS_CODE";
        public const string c_champCodeSystemeComplet = "PRJ_FULL_SYS_CODE";
        public const string c_champNiveau = "PRJ_LEVEL";
        public const string c_champIdParent = "PRJ_PARENT_ID";
        public const string c_champIndexTri = "PRJ_INDEX_TRI";

        //Designer Projet
        public const string c_champPrjShowMiniature = "DESIGNER_PRJ_SHOW_THUMB";
        public const string c_champPrjIcoEtat = "DESIGNER_PRJ_ICO_ETAT";
        public const string c_champPrjIcoAno = "DESIGNER_PRJ_ICO_ANO";
        public const string c_champPrjX = "DESIGNER_PRJ_X";
        public const string c_champPrjY = "DESIGNER_PRJ_Y";
        public const string c_champPrjWidth = "DESIGNER_PRJ_WIDTH";
        public const string c_champPrjHeight = "DESIGNER_PRJ_HEIGHT";

        public const string c_champCoutPrevisionnel = "PRJ_ESTIMATED_COST";
        public const string c_champCoutReel = "PRJ_ACTUAL_COST";

        //Gestion de l'avancement
        public const string c_champPctAvancement = "PRJ_PROGRESS";
        public const string c_champPoids = "PRJ_WEIGHT";

        //Gantt
        public const string c_champGanttId = "PRJ_GANTT_ID";

        public const string c_champPoidsFils = "PRJ_SUM_CHLD_WGT";
        public const string c_champAvancementsFils = "PRJ_SUM_CHLD_AVT";
        public const string c_champTableDernieresDatesConnues = "PRJ_CACHE_DATES_CHILDS";

        //Ittérations
        public const string c_champIterationNumber = "PRJ_ITTRATION_NO";

        public const string c_champCalculateMode = "PRJ_AUTOCALCMOD";

        //Lien avec les étapes
        public const string c_champStepLinkBehavior = "PRJ_STEP_LINK_BEHAVE";
        #endregion

        [Serializable]
        public class CCacheDatesProjet
        {
            private int m_nIdProjet;
            private DateTime? m_dateDebutPlanifiee;
            private DateTime? m_dateFinPlanifiee;
            private DateTime? m_dateDebutReelle;
            private DateTime? m_dateFinRelle;

            //-------------------------------------------------
            public CCacheDatesProjet(CProjet projet)
            {
                m_nIdProjet = projet.Id;
            }

            //-------------------------------------------------
            public int IdProjet
            {
                get
                {
                    return m_nIdProjet;
                }
            }

            //-------------------------------------------------
            public override int GetHashCode()
            {
                return m_nIdProjet;
            }

            //-------------------------------------------------
            public DateTime? DateDebutPlanifiee
            {
                get
                {
                    return m_dateDebutPlanifiee;
                }
                set
                {
                    m_dateDebutPlanifiee = value;
                }
            }

            //-------------------------------------------------
            public DateTime? DateFinPlanifiee
            {
                get
                {
                    return m_dateFinPlanifiee;
                }
                set
                {
                    m_dateFinPlanifiee = value;
                }
            }

            //-------------------------------------------------
            public DateTime? DateDebutRelle
            {
                get
                {
                    return m_dateDebutReelle;
                }
                set
                {
                    m_dateDebutReelle = value;
                }
            }

            //-------------------------------------------------
            public DateTime? DateFinRelle
            {
                get
                {
                    return m_dateFinRelle;
                }
                set
                {
                    m_dateFinRelle = value;
                }
            }
        }


        //-------------------------------------------------------------------
        public CProjet(CContexteDonnee ctx)
            : base(ctx)
        {
        }

        //-------------------------------------------------------------------
        public CProjet(System.Data.DataRow row)
            : base(row)
        {
        }


        public static void Autoexec()
        {
            CRoleChampCustom.RegisterRole(c_roleChampCustom, "Project", typeof(CProjet), typeof(CTypeProjet));
        }

        //-------------------------------------------------------------------
        public CRoleChampCustom RoleChampCustomAssocie
        {
            get
            {
                return CRoleChampCustom.GetRole(c_roleChampCustom);
            }
        }


        //-------------------------------------------------------------------
        public override string ToString()
        {
            return Libelle;
        }

        //-------------------------------------------------------------------
        public object[] TiagKeys
        {
            get { return new object[] { Id }; }
        }

        public string TiagType
        {
            get { return c_nomTiag; }
        }


        /// /////////////////////////////////////////////
        public override string DescriptionElement
        {
            get { return I.T("Project @1|273", Libelle); }
        }

        /// /////////////////////////////////////////////
        protected override void MyInitValeurDefaut()
        {

            base.MyInitValeurDefaut();
            ModeUpdateAsynchrone = false;
            TypesAnomaliesFiltres = ETypeAnomalieProjet.Boucle | ETypeAnomalieProjet.NonRespectContrainteDate;
            IdUniversel = CUniqueIdentifier.GetNew();
            InclureAnomaliesProjetsFils = true;
            AfficherMiniature = false;
            AfficherIcoAno = false;
            AfficherIcoEtat = false;
            DateDebutAuto = true;
            NumeroIteration = 0;
            TypesCoutsParentsARecalculer = ETypeCout.Aucun;
            Row[c_champCoutReel] = 0;
            Row[c_champCoutPrevisionnel] = 0;
            ModeCalculDatesParentes = (int)EModeCalculDatesProjet.Automatic;
            OptionLienEtapeCode = (int)EOptionLienProjetEtape.Standard;

        }

        //-----------------------------------------------------------
        /// <summary>
        /// Id unique universel quelque soit la machine
        /// </summary>
        [TableFieldProperty(CObjetDonnee.c_champIdUniversel, 64)]
        [DynamicField("Universal id")]
        [IndexField]
        [NonCloneable]
        public string IdUniversel
        {
            get
            {
                return (string)Row[CObjetDonnee.c_champIdUniversel];
            }
            set
            {
                Row[CObjetDonnee.c_champIdUniversel] = value;
            }
        }

        //-----------------------------------------------------------
        public bool ReadIfExistsUniversalId(string strId)
        {
            CFiltreData filtre = new CFiltreData(CObjetDonnee.c_champIdUniversel + "=@1",
                strId);
            return ReadIfExists(filtre);
        }

        /// /////////////////////////////////////////////
        public override string[] GetChampsTriParDefaut()
        {
            return new string[] { c_champIndexTri, c_champDateDebutPlanifiee, c_champLibelle };
        }


        /// /////////////////////////////////////////////
        [TableFieldProperty(c_champTableDernieresDatesConnues, IsInDb = false)]
        public Dictionary<int, CCacheDatesProjet> CacheLastDatesConnues
        {
            get
            {
                return Row[c_champTableDernieresDatesConnues] as Dictionary<int, CCacheDatesProjet>;
            }
            set
            {
                Row[c_champTableDernieresDatesConnues] = value;
            }
        }

        /// /////////////////////////////////////////////
        private CCacheDatesProjet GetCacheDates(CProjet projet)
        {
            Dictionary<int, CCacheDatesProjet> dic = CacheLastDatesConnues;
            if (dic == null)
            {
                dic = new Dictionary<int, CCacheDatesProjet>();
                CacheLastDatesConnues = dic;
            }
            CCacheDatesProjet cache = null;
            if (!dic.TryGetValue(projet.Id, out cache))
            {
                cache = new CCacheDatesProjet(projet);
                dic[projet.Id] = cache;
            }
            return cache;
        }

        /// /////////////////////////////////////////////
        private void StockLastDateDebutPlanifieeConnue(CProjet projet)
        {
            CCacheDatesProjet cache = GetCacheDates(projet);
            cache.DateDebutPlanifiee = projet.DateDebutPlanifieePourParent;

        }

        /// /////////////////////////////////////////////
        private void StockLastDateFinPlanifieeConnue(CProjet projet)
        {
            CCacheDatesProjet cache = GetCacheDates(projet);
            cache.DateFinPlanifiee = projet.DateFinPlanifieePourParent;
        }

        /// /////////////////////////////////////////////
        private void StockLastDateDebutReelleConnue(CProjet projet)
        {
            CCacheDatesProjet cache = GetCacheDates(projet);
            cache.DateDebutRelle = projet.DateDebutReel;
        }

        /// /////////////////////////////////////////////
        private void StockLastDateFinReelleConnue(CProjet projet)
        {
            CCacheDatesProjet cache = GetCacheDates(projet);
            cache.DateFinRelle = projet.DateFinRelle;
        }

        private enum ETypeDateProjet
        {
            DateDebutPlanifiee,
            DateFinPlanifiee,
            DateDebutReelle,
            DateFinReelle
        }

        /// /////////////////////////////////////////////
        private DateTime? GetLastDateConnuePourProjet(
            CProjet projet,
            ETypeDateProjet typeDate
            )
        {
            DateTime? retour = null;
            Dictionary<int, CCacheDatesProjet> dic = CacheLastDatesConnues;
            CCacheDatesProjet cache = null;
            int nId = 0;
            DataRowVersion oldVer = projet.VersionToReturn;
            if (projet.Row.RowState == DataRowState.Deleted)
            {
                projet.VersionToReturn = DataRowVersion.Original;
                nId = projet.Id;
                projet.VersionToReturn = oldVer;
            }
            else
                nId = projet.Id;
            if (dic == null || !dic.TryGetValue(nId, out cache) || cache.DateDebutPlanifiee == null)
            {
                DataRowVersion oldVers = projet.VersionToReturn;
                if (projet.Row.HasVersion(DataRowVersion.Original))
                {
                    projet.VersionToReturn = DataRowVersion.Original;
                    DateTime? dt = null;
                    switch (typeDate)
                    {
                        case ETypeDateProjet.DateDebutPlanifiee:
                            retour = projet.DateDebutPlanifieePourParent;
                            break;
                        case ETypeDateProjet.DateFinPlanifiee:
                            retour = projet.DateFinPlanifieePourParent;
                            break;
                        case ETypeDateProjet.DateDebutReelle:
                            retour = projet.DateDebutReel;
                            break;
                        case ETypeDateProjet.DateFinReelle:
                            dt = projet.DateFinRelle;
                            break;
                        default:
                            break;
                    }
                    projet.VersionToReturn = oldVers;
                }
            }
            else
            {
                switch (typeDate)
                {
                    case ETypeDateProjet.DateDebutPlanifiee:
                        retour = cache.DateDebutPlanifiee;
                        break;
                    case ETypeDateProjet.DateFinPlanifiee:
                        retour = cache.DateFinPlanifiee;
                        break;
                    case ETypeDateProjet.DateDebutReelle:
                        retour = cache.DateDebutRelle;
                        break;
                    case ETypeDateProjet.DateFinReelle:
                        retour = cache.DateFinRelle;
                        break;
                    default:
                        break;
                }
            }
            return retour;
        }

        /// /////////////////////////////////////////////
        private DateTime GetLastDateDebutPlanifieeConnuePourProjet(CProjet projet)
        {
            DateTime? dt = GetLastDateConnuePourProjet(projet, ETypeDateProjet.DateDebutPlanifiee);
            if (dt != null)
                return dt.Value;
            return DateTime.Now;
        }

        /// /////////////////////////////////////////////
        private DateTime GetLastDateFinPlanifieeConnuePourProjet(CProjet projet)
        {
            DateTime? dt = GetLastDateConnuePourProjet(projet, ETypeDateProjet.DateFinPlanifiee);
            if (dt != null)
                return dt.Value;
            return DateTime.Now;
        }

        /// /////////////////////////////////////////////
        private DateTime? GetLastDateDebutReelleConnuePourProjet(CProjet projet)
        {
            return GetLastDateConnuePourProjet(projet, ETypeDateProjet.DateDebutReelle);
        }

        /// /////////////////////////////////////////////
        private DateTime? GetLastDateFinReelleConnuePourProjet(CProjet projet)
        {
            return GetLastDateConnuePourProjet(projet, ETypeDateProjet.DateFinReelle);
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// Libellé du projet
        /// </summary>
        [TableFieldProperty(c_champLibelle, 255)]
        [DynamicField("Label")]
        [DescriptionField]
        [TiagField("Label")]
        public override string Libelle
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

        //-----------------------------------------------------------------------------
        /// <summary>
        /// Lorsqu'un projet est créé à partir d'un besoin projet, cette valeur
        /// la clé projet définie au niveau du besoin.
        /// </summary>
        /// <remarks>
        /// Sans gestion de 'template key', lorsqu'on applique une spécification
        /// de besoin en tant que modèle de projet, le système crée tous les
        /// projets définis par les besoins.
        /// <BR></BR>
        /// Dans le cas où le besoin possède une clé, le projet ne sera pas
        /// recréé si on réapplique le modèle.
        /// </remarks>
        [TableFieldProperty(c_champProjectTemplateKey, 255)]
        [DynamicField("Source template key")]
        [TiagField("Source template key")]
        public string SourceTemplateKey
        {
            get
            {
                return (string)Row[c_champProjectTemplateKey];
            }
            set
            {
                Row[c_champProjectTemplateKey] = value;
            }
        }


        /// <summary>
        /// Description du projet
        /// </summary>
        [TableFieldProperty(c_champDescription, 2000)]
        [DynamicField("Description")]
        [TiagField("Description")]
        public string Description
        {
            get
            {
                return (string)Row[c_champDescription];
            }
            set
            {
                Row[c_champDescription] = value;
            }
        }

        //-------------------------------------------------------------------
        public void TiagSetProjectTypeKeys(object[] lstCles)
        {
            CTypeProjet typeProjet = new CTypeProjet(ContexteDonnee);
            if (typeProjet.ReadIfExists(lstCles))
                TypeProjet = typeProjet;
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// Obtient ou définit le <see cref="CTypeProjet">Type du Projet</see>
        /// </summary>
        [Relation(CTypeProjet.c_nomTable, CTypeProjet.c_champId, CTypeProjet.c_champId, true, false)]
        [DynamicField("Project type")]
        [TiagRelation(typeof(CTypeProjet), "TiagSetProjectTypeKeys")]
        public CTypeProjet TypeProjet
        {
            get
            {
                return (CTypeProjet)GetParent(CTypeProjet.c_champId, typeof(CTypeProjet));
            }
            set
            {
                SetParent(CTypeProjet.c_champId, value);
            }
        }


        #region Pour Designer Projet
        [TableFieldProperty(c_champPrjShowMiniature)]
        public bool AfficherMiniature
        {
            get
            {
                return (bool)Row[c_champPrjShowMiniature];
            }
            set
            {
                Row[c_champPrjShowMiniature] = value;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [TableFieldProperty(c_champPrjX)]
        public int DesignerProjetX
        {
            get
            {
                return (int)Row[c_champPrjX];
            }
            set
            {
                Row[c_champPrjX] = value;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [TableFieldProperty(c_champPrjY)]
        public int DesignerProjetY
        {
            get
            {
                return (int)Row[c_champPrjY];
            }
            set
            {
                Row[c_champPrjY] = value;
            }
        }


        //-----------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [TableFieldProperty(c_champPrjWidth)]
        public int DesignerProjetWidth
        {
            get
            {
                return (int)Row[c_champPrjWidth];
            }
            set
            {
                Row[c_champPrjWidth] = value;
            }
        }


        //-----------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [TableFieldProperty(c_champPrjHeight)]
        public int DesignerProjetHeight
        {
            get
            {
                return (int)Row[c_champPrjHeight];
            }
            set
            {
                Row[c_champPrjHeight] = value;
            }
        }

        [TableFieldProperty(c_champPrjIcoEtat)]
        public bool AfficherIcoEtat
        {
            get
            {
                return (bool)Row[c_champPrjIcoEtat];
            }
            set
            {
                Row[c_champPrjIcoEtat] = value;
            }
        }
        [TableFieldProperty(c_champPrjIcoAno)]
        public bool AfficherIcoAno
        {
            get
            {
                return (bool)Row[c_champPrjIcoAno];
            }
            set
            {
                Row[c_champPrjIcoAno] = value;
            }
        }

        #endregion


        //----------------------------------------------------------------------------
        public void TiagSetParentProjectKeys(object[] lstCles)
        {
            CProjet projetParent = new CProjet(ContexteDonnee);
            if (projetParent.ReadIfExists(lstCles))
                Projet = projetParent;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Obtient ou définit le projet parent du projet
        /// </summary>
        [Relation(
            c_nomTable,
            c_champId,
            c_champIdParent,
            false,
            false)]
        [DynamicField("Parent Project")]
        [TiagRelation(typeof(CProjet), "TiagSetParentProjectKeys")]
        public CProjet Projet
        {
            get
            {
                return (CProjet)ObjetParent;
            }
            set
            {
                ObjetParent = value;
                if (value != null)
                {
                    if (DateDebutPlanifiee == null)
                        DateDebutPlanifiee = value.DateDebutPlanifiee;
                }

            }
        }

        //----------------------------------------------------
        /// <summary>
        /// Index du projet tel qu'il ressort suite au tri de celui-ci parmi les autres projets.
        /// L'index de tri est sauvegardé afin que l'utilisateur retrouve les projets triés
        /// tels qu'il l'avait effectué d'une ouverture de projet à une autre.
        /// </summary>
        [TableFieldProperty(CProjet.c_champIndexTri)]
        [DynamicField("Sort index")]
        [TiagField("Sort index")]
        public int IndexTri
        {
            get
            {
                return (int)Row[c_champIndexTri];
            }
            set
            {
                Row[c_champIndexTri] = value;
            }
        }


        //----------------------------------------------------
        public ETypeAnomalieProjet TypesAnomaliesFiltres
        {
            get
            {
                return (ETypeAnomalieProjet)TypesAnomaliesFiltresCode;
            }
            set
            {
                TypesAnomaliesFiltresCode = (int)value;
            }
        }

        //----------------------------------------------------
        /// <summary>
        /// Réservé pour utilisation future
        /// </summary>
        [TableFieldProperty(c_champFiltresAnomaliesCode)]
        [DynamicField("Anomaly Filters code")]
        public int TypesAnomaliesFiltresCode
        {
            get
            {
                return (int)Row[c_champFiltresAnomaliesCode];
            }
            set
            {
                Row[c_champFiltresAnomaliesCode] = value;
            }
        }

        //----------------------------------------------------
        /// <summary>
        /// Booléen indiquant s'il faut tenir compte des anomalies concernant les projets inclus,
        /// au niveau du projet lui-même.<br/>
        /// Réservé pour utilisation future
        /// </summary>
        [TableFieldProperty(c_champAnomaliesProjetsFils)]
        [DynamicField("Include Projects Children Anomaly")]
        public bool InclureAnomaliesProjetsFils
        {
            get
            {
                return (bool)Row[c_champAnomaliesProjetsFils];
            }
            set
            {
                Row[c_champAnomaliesProjetsFils] = value;
            }
        }

        //----------------------------------------------------
        /// <summary>
        /// Donne la liste des <see cref="CAnomalieProjet">anomalies du projet</see><br/>
        /// Réservé pour utilisation future
        /// </summary>
        [DynamicChilds("Projects Anomaly", typeof(CAnomalieProjet))]
        [RelationFille(typeof(CAnomalieProjet), "Projet")]
        public CListeObjetsDonnees AnomaliesDuProjet
        {
            get
            {
                return GetDependancesListe(CAnomalieProjet.c_nomTable, c_champId);
            }
        }

        //----------------------------------------------------
        /// <summary>
        /// Donne la liste des <see cref="CLienDeProjet">liens</see> de ce projet avec d'autres projets
        /// </summary>
        [DynamicChilds("Project Link related", typeof(CLienDeProjet))]
        public CListeObjetsDonnees LiensDeProjetAttaches
        {
            get
            {
                CListeObjetsDonnees lst = LiensEnTantQueProjetA;
                lst = LiensEnTantQueProjetB;
                CFiltreData filtre = new CFiltreData(CLienDeProjet.c_champPrjA + "=@1 or " +
                    CLienDeProjet.c_champPrjB + "=@1", Id);
                lst = new CListeObjetsDonnees(ContexteDonnee, typeof(CLienDeProjet), filtre);
                lst.InterditLectureInDB = true;
                return lst;
            }
        }

        //----------------------------------------------------
        [DynamicMethod("Link this projet as successor of parameter", "Predecessor")]
        public CLienDeProjet AddPredecessor(CProjet predecesseur)
        {
            if (predecesseur == null)
                return null;
            CListeObjetsDonnees lst = LiensEnTantQueProjetB;
            lst.Filtre = new CFiltreData(CLienDeProjet.c_champPrjA + "=@1",
                predecesseur.Id);
            if (lst.Count > 0)
                return lst[0] as CLienDeProjet;
            CLienDeProjet lien = new CLienDeProjet(ContexteDonnee);
            lien.CreateNewInCurrentContexte();
            lien.ProjetA = predecesseur;
            lien.ProjetB = this;
            CResultAErreur result = lien.ControleCoherenceLien();
            if (!result)
            {
                lien.CancelCreate();
                return null;
            }
            if (DateDebutAuto && DateDebutGantt < predecesseur.DateFinGantt && DureeEnHeure != null)
                MoveProject(predecesseur.DateFinGantt, DureeEnHeure.Value, (int)EModeDeplacementProjet.MoveAutoOnly);
            return lien;
        }

        //----------------------------------------------------
        [DynamicMethod("Link this projet as predecessor of parameter", "Successor")]
        public CLienDeProjet AddSuccessor(CProjet successeur)
        {
            if (successeur == null)
                return null; ;
            successeur = successeur.GetObjetInContexte(ContexteDonnee) as CProjet;
            return successeur.AddPredecessor(this);
        }

        //----------------------------------------------------
        public CLienDeProjet GetLienToPredecesseur(CProjet projet)
        {
            if (projet == null)
                return null;
            CListeObjetsDonnees lst = LiensEnTantQueProjetB;
            lst.Filtre = new CFiltreData(CLienDeProjet.c_champPrjA + "=@1",
                projet.Id);
            if (lst.Count > 0)
                return lst[0] as CLienDeProjet;
            return null;
        }

        //----------------------------------------------------
        public CLienDeProjet GetLienToSuccesseur(CProjet projet)
        {
            if (projet == null)
                return null;
            CListeObjetsDonnees lst = LiensEnTantQueProjetA;
            lst.Filtre = new CFiltreData(CLienDeProjet.c_champPrjB + "=@1",
                projet.Id);
            if (lst.Count > 0)
                return lst[0] as CLienDeProjet;
            return null;
        }



        //----------------------------------------------------
        /// <summary>
        /// Donne la liste des <see cref="CLienDeProjet">liens</see> de ce projet avec d'autres projets,
        /// liens pour lesquels ce projet est la source
        /// </summary>
        [DynamicChilds("Links as project A", typeof(CLienDeProjet))]
        [RelationFille(typeof(CLienDeProjet), "ProjetA")]
        public CListeObjetsDonnees LiensEnTantQueProjetA
        {
            get
            {
                return GetDependancesListe(CLienDeProjet.c_nomTable, CLienDeProjet.c_champPrjA);
            }
        }

        //----------------------------------------------------
        /// <summary>
        /// Donne la liste des <see cref="CLienDeProjet">liens</see> de ce projet avec d'autres projets,
        /// liens pour lesquels ce projet est la destination
        /// </summary>
        [DynamicChilds("Links as project B", typeof(CLienDeProjet))]
        [RelationFille(typeof(CLienDeProjet), "ProjetB")]
        public CListeObjetsDonnees LiensEnTantQueProjetB
        {
            get
            {
                return GetDependancesListe(CLienDeProjet.c_nomTable, CLienDeProjet.c_champPrjB);
            }
        }

        //----------------------------------------------------
        public override int NbCarsParNiveau
        {
            get
            {
                return 4;
            }
        }

        //----------------------------------------------------
        public override string ChampCodeSystemePartiel
        {
            get
            {
                return c_champCodeSystemePartiel;
            }
        }

        //----------------------------------------------------
        public override string ChampCodeSystemeComplet
        {
            get
            {
                return c_champCodeSystemeComplet;
            }
        }

        //----------------------------------------------------
        public override string ChampNiveau
        {
            get
            {
                return c_champNiveau;
            }
        }

        //----------------------------------------------------
        public override string ChampLibelle
        {
            get
            {
                return c_champLibelle;
            }
        }

        //----------------------------------------------------
        public override string ChampIdParent
        {
            get
            {
                return c_champIdParent;
            }
        }


        //----------------------------------------------------
        /// <summary>
        /// Donne la liste des projets fils de ce projet
        /// </summary>
        [RelationFille(typeof(CProjet), "Projet")]
        [DynamicChilds("Child projects", typeof(CProjet))]
        public CListeObjetsDonnees ProjetsFils
        {
            get
            {
                return ObjetsFils;
            }
        }

        //----------------------------------------------------
        /// <summary>
        /// Retourne tous les projets fils (quelque soit leur niveau)
        /// </summary>
        [DynamicField("All children projects")]
        public CProjet[] TousLesProjetsFils
        {
            get
            {
                List<IElementDeProjetPlanifiable> lst = new List<IElementDeProjetPlanifiable>();
                RecurseAddSousElements(lst);
                return (from t in lst where t.GetType() == typeof(CProjet) select t as CProjet).ToArray();
            }
        }

        //----------------------------------------------------
        [DynamicField("Iterations array")]
        public CProjet[] ToutesLesIterations
        {
            get
            {
                List<CProjet> lst = new List<CProjet>();
                lst.Add(this);
                if (GanttId.Length > 0 && Projet != null)
                {
                    foreach (CProjet prj in Projet.ProjetsFils)
                        if (prj.GanttId == GanttId && prj.Id != Id)
                            lst.Add(prj);
                }
                lst.Sort((x, y) => x.NumeroIteration.CompareTo(y.NumeroIteration));
                return lst.ToArray();
            }
        }





        //----------------------------------------------------
        /// <summary>
        /// Indique le code système propre au projet.
        /// Ce code est unique dans son projet parent.
        /// Ce code est exprimé  sur 4 caractères alphanumériques.
        /// </summary>
        [TableFieldProperty(c_champCodeSystemePartiel, 4)]
        [DynamicField("Partial system code")]
        public override string CodeSystemePartiel
        {
            get
            {
                string strVal = "";
                if (Row[c_champCodeSystemePartiel] != DBNull.Value)
                    strVal = (string)Row[c_champCodeSystemePartiel];
                strVal = strVal.Trim().PadLeft(2, '0');
                return strVal;
            }
        }

        //----------------------------------------------------
        /// <summary>
        /// Indique le code système complet du projet.
        /// Ce code système complet est la concaténation du code système partiel du projet
        /// avec le code système partiel de tous ses parents en remontant la hiérarchie.
        /// Exemple : pour un code système complet tel que : 0012000A0034 :
        /// 0034 est le code partiel du projet courant
        /// 000A est le code partiel du projet père
        /// 0012 est le code partiel du projet grand père
        /// </summary>
        [TableFieldProperty(c_champCodeSystemeComplet, 400)]
        [DynamicField("Full system code")]
        public override string CodeSystemeComplet
        {
            get
            {
                return (string)Row[c_champCodeSystemeComplet];
            }
        }

        //----------------------------------------------------
        /// <summary>
        /// Indique le niveau hiérarchique( nombre de parents ) du projet<br/>
        /// Le niveau d'un projet sans parent est 0.<br/>
        /// Exemple : Projet contrat -> Projet site -> Projet Energie :<br/>
        /// 'Projet contrat' a pour niveau 0,<br/>
        /// 'Projet site' inclus dans 'Projet contrat' a pour niveau 1 (1 parent en remontant la hiérarchie)<br/>
        /// 'Projet énergie' dans 'Projet site' a pour niveau 2 (2 parents en rempontant la hiérachie)
        /// </summary>
        [TableFieldProperty(c_champNiveau)]
        [DynamicField("Level")]
        public override int Niveau
        {
            get
            {
                return (int)Row[c_champNiveau];
            }
        }

        /// <summary>
        /// Donne la liste des <see cref="CIntervention">interventions</see> associées au projet
        /// </summary>
        [RelationFille(typeof(CIntervention), "Projet")]
        [DynamicChilds("Associated Interventions", typeof(CIntervention))]
        public CListeObjetsDonnees Interventions
        {
            get
            {
                return GetDependancesListe(CIntervention.c_nomTable, c_champId);
            }
        }


        /// <summary>
        /// Etat du projet :
        /// <ul>
        /// <li>Terminé, lorsque la date de fin réelle du projet est définie</li>
        /// <li>En retard, lorsque les dates de début et fin planifiées du projet sont définies et que la date du jour est supérieure à la date de fin planifiée</li>
        /// <li>Planifié, lorsque les dates de début et fin planifiées du projet sont définies et que la date du jour est inférieure ou égale à la date de fin planifiée</li>
        /// <li>A planifier, dans les autres cas</li>
        /// </ul>
        /// </summary>
        [DynamicField("State")]
        public CEtatPlanification EtatPlanification
        {
            get
            {
                if (DateFinRelle != null)
                    return new CEtatPlanification(EEtatPlanification.Termine);
                else if (DateDebutPlanifiee != null && DateFinPlanifiee != null)
                    if (DateTime.Now > (DateTime)DateFinPlanifiee)
                        return new CEtatPlanification(EEtatPlanification.EnRetard);
                    else
                        return new CEtatPlanification(EEtatPlanification.Planifie);
                else
                    return new CEtatPlanification(EEtatPlanification.APrePlanifier);
            }
        }

        /// <summary>
        /// Date de début dans un diagramme de Gantt
        /// Si la date de début réelle est définie, c'est la date de début réelle
        /// sinon
        /// Si la date de début planifiée est définie, c'est la date de début planifiée
        /// sinon
        ///     S'il y a un projet parent, c'est la date de début Gantt du projet parent
        ///     sinon
        ///     date du jour.
        /// </summary>
        [DynamicField("Gantt start date")]
        public DateTime DateDebutGantt
        {
            get
            {
                /*if (DateDebutReel == null)
                {*/
                if (DateDebutPlanifiee == null)
                {
                    if (Projet != null)
                        return Projet.DateDebutGantt;
                    else
                    {
                        bool bAvecHeures = false;
                        if (TypeProjet != null)
                            bAvecHeures = TypeProjet.TravaillerAvecLesHeures;
                        if (bAvecHeures)
                            return DateTime.Now;
                        else
                            return DateTime.Now.Date;
                    }
                }
                return DateDebutPlanifiee.Value;
                /*}
                return DateDebutReel.Value;*/
            }
            set
            {
                /*if (DateDebutReel != null)
                    DateDebutReel = value;
                else*/
                DateDebutPlanifiee = value;


            }
        }

        /// <summary>
        /// Date de fin dans un diagramme de gantt
        /// Si la date de fin réelle est définie, c'est la date de fin réelle
        /// sinon
        ///     Si la date de début réelle est définie et que la durée previsionnelle est connue, c'est la date de début réelle plus la durée
        ///     sinon
        ///         si la date de fin planifiée est définie, c'est cette date de fin
        ///     sinon
        ///         c'est la date de début planifiée plus la durée par défaut
        /// </summary>
        [DynamicField("Gantt end date")]
        public DateTime DateFinGantt
        {
            get
            {
                /*if (DateFinRelle != null)
                    return DateFinRelle.Value;*/
                if (DateFinPlanifiee != null)
                    return DateFinPlanifiee.Value;
                TimeSpan sp = TypeProjet != null ?
                    TimeSpan.FromHours(TypeProjet.DureeDefautHeures) :
                    TimeSpan.FromHours(48);
                return DateDebutGantt.Add(sp);
            }
            set
            {
                /*if (DateFinRelle != null)
                    DateFinRelle = value;
                else*/
                DateFinPlanifiee = value;
            }
        }

        //-----------------------------------------------------------------------------
        /// <summary>
        /// Date de début planifiée calculée à partir des dates de début planifiées
        /// des fils (si le projet a des projets fils).
        /// <BR></BR>Dans le cas d'un projet feuille, il s'agit toujours de la
        /// date planifiée du projet
        /// </summary>
        [TableFieldProperty(c_champDateDebutPlanifieeCalculee, NullAutorise = true)]
        [DynamicField("Calculated planned start date")]
        public DateTime? DateDebutPlanifieeCalculee
        {
            get
            {
                if (Row[c_champDateDebutPlanifieeCalculee] == DBNull.Value)
                    return null;
                if (TypeProjet != null && TypeProjet.TravaillerAvecLesHeures)
                    return (DateTime)Row[c_champDateDebutPlanifieeCalculee];
                return ((DateTime)Row[c_champDateDebutPlanifieeCalculee]).Date;
            }
        }

        //-----------------------------------------------------------------------------
        /// <summary>
        /// Date de fin planifiée calculée à partir des dates de fin planifiées
        /// des fils (si le projet a des projets fils).
        /// <BR></BR>Dans le cas d'un projet feuille, il s'agit toujours de la
        /// date planifiée du projet
        /// </summary>
        [TableFieldProperty(c_champDateFinPlanifieeCalculee, NullAutorise = true)]
        [DynamicField("Calculated planned end date")]
        public DateTime? DateFinPlanifieeCalculee
        {
            get
            {
                if (Row[c_champDateFinPlanifieeCalculee] == DBNull.Value)
                    return null;
                if (TypeProjet != null && TypeProjet.TravaillerAvecLesHeures)
                    return (DateTime)Row[c_champDateFinPlanifieeCalculee];
                return ((DateTime)Row[c_champDateFinPlanifieeCalculee]).Date;
            }
        }

        /// <summary>
        /// Si true, les dates, la progression et le poids du projet sont recalculés de 
        /// manière astynchrone.
        /// </summary>
        /// <remarks>
        /// Cette option est utilisée pour les projets possédant de nombreux projets fils. <BR></BR>
        /// En effet, lors de la mise à jour d'un projet fils, les données du projet parent sont mises à jour. Si deux projets fils
        /// d'un projet sont mis à jour en même temps sur deux postes différents, le projet parent est modifié par les deux et un risque
        /// d'accès conccurentiel à la base de donnée est présent. Pour éviter ce problème, le mode asynchrone active le mode "Multi utilisateurs"
        /// sur le projet.
        /// </remarks>
        [TableFieldProperty(c_champAsynchronousUpdate)]
        [DynamicField("Asynchronous update")]
        public bool ModeUpdateAsynchrone
        {
            get { return Row.Get<bool>(c_champAsynchronousUpdate); }
            set
            {
                Row[c_champAsynchronousUpdate] = value;
            }
        }





        //-----------------------------------------------------------------------------
        /// <summary>
        /// Retourne la date de début planifiée à retenir pour 
        /// le projet parent de ce projet
        /// </summary>
        public DateTime? DateDebutPlanifieePourParent
        {
            get
            {
                if (DateDebutPlanifieeCalculee == null)
                    return DateDebutPlanifiee;
                if (DateDebutPlanifiee == null)
                    return DateDebutPlanifieeCalculee;
                if (DateDebutPlanifiee < DateDebutPlanifieeCalculee)
                    return DateDebutPlanifiee;
                else
                    return DateDebutPlanifieeCalculee;
            }
        }

        //-----------------------------------------------------------------------------
        /// <summary>
        /// Retourne la date de fin planifiée à retenir pour le parent
        /// de ce projet.
        /// </summary>
        public DateTime? DateFinPlanifieePourParent
        {
            get
            {
                if (DateFinPlanifieeCalculee == null)
                    return DateFinPlanifiee;
                if (DateFinPlanifiee == null)
                    return DateFinPlanifieeCalculee;
                if (DateFinPlanifiee > DateFinPlanifieeCalculee)
                    return DateFinPlanifiee;
                return DateFinPlanifieeCalculee;
            }
        }

        //-----------------------------------------------------------------------------


        //-----------------------------------------------------------------------------
        /// <summary>
        /// Obtient ou définit la date de début planifiée du projet
        /// </summary>
        [TableFieldProperty(c_champDateDebutPlanifiee, NullAutorise = true)]
        [DynamicField("Planned Start Date")]
        [TiagField("Planned Start Date")]
        public DateTime? DateDebutPlanifiee
        {
            get
            {
                if (Row[c_champDateDebutPlanifiee] == DBNull.Value)
                    return null;
                else
                {
                    if (TypeProjet != null && TypeProjet.TravaillerAvecLesHeures)
                        return (DateTime)Row[c_champDateDebutPlanifiee];
                    return ((DateTime)Row[c_champDateDebutPlanifiee]).Date;
                }
            }
            set
            {
                if (HasChilds())
                {
                    if (!DateDebutAuto)
                        Row[c_champDateDebutPlanifiee, true] = value;
                    UpdateDateDebutPlanifieeCalculeeFromChilds();

                    return;
                }
                SetDateDebutPlanifieeCalculeeMemeSiCestUnParent(value, true);
            }
        }

        //-----------------------------------------------------------------------------
        /// <summary>
        /// Obtient ou définit la date de fin planifiée du projet
        /// </summary>
        [TableFieldProperty(c_champDateFinPlanifiee, NullAutorise = true)]
        [DynamicField("Planned End Date")]
        [TiagField("Planned End Date")]
        public DateTime? DateFinPlanifiee
        {
            get
            {
                if (Row[c_champDateFinPlanifiee] == DBNull.Value)
                    return null;
                else
                {
                    if (TypeProjet != null && TypeProjet.TravaillerAvecLesHeures)
                        return (DateTime)Row[c_champDateFinPlanifiee];
                    return ((DateTime)Row[c_champDateFinPlanifiee]).Date;
                }
            }
            set
            {
                if (HasChilds())
                {
                    if (!DateDebutAuto)
                        Row[c_champDateFinPlanifiee, true] = value;
                    UpdateDateFinPlanifieeCalculeeFromChilds();

                    return;
                }
                SetDateFinPlanifieeCalculeeMemeSiCestUnParent(value, true);
            }
        }

        /// /////////////////////////////////////////////
        void SetDateDebutPlanifieeCalculeeMemeSiCestUnParent(DateTime? dt, bool bNotifierParent)
        {
            bNotifierParent &= (EModeCalculDatesProjet)ModeCalculDatesParentes == EModeCalculDatesProjet.Automatic;
            if (dt == null)
                Row[c_champDateDebutPlanifieeCalculee] = DBNull.Value;
            else
            {
                DateTime date = dt.Value;
                if (TypeProjet == null || !TypeProjet.TravaillerAvecLesHeures)
                    date = date.Date;
                Row[c_champDateDebutPlanifieeCalculee] = date;
            }
            if (!HasChilds() || DateDebutAuto)
                Row[c_champDateDebutPlanifiee] = Row[c_champDateDebutPlanifieeCalculee];
            if (bNotifierParent && Projet != null)
                Projet.UpdateDateDebutPlanifieeCalculeeFromChilds();
        }

        /// /////////////////////////////////////////////
        void SetDateFinPlanifieeCalculeeMemeSiCestUnParent(DateTime? dt, bool bNotifierParent)
        {
            bNotifierParent &= (EModeCalculDatesProjet)ModeCalculDatesParentes == EModeCalculDatesProjet.Automatic;
            if (dt == null)
                Row[c_champDateFinPlanifieeCalculee] = DBNull.Value;
            else
            {
                DateTime date = dt.Value;
                if (TypeProjet == null || !TypeProjet.TravaillerAvecLesHeures)
                    date = date.Date;
                Row[c_champDateFinPlanifieeCalculee] = date;
            }
            if (!HasChilds() || DateDebutAuto)
                Row[c_champDateFinPlanifiee] = Row[c_champDateFinPlanifieeCalculee];
            if (bNotifierParent && Projet != null)
                Projet.UpdateDateFinPlanifieeCalculeeFromChilds();
        }

        /// /////////////////////////////////////////////
        void SetDateDebutReelleMemeSiCestUnParent(DateTime? dt, bool bNotifierParent)
        {
            bNotifierParent &= (EModeCalculDatesProjet)ModeCalculDatesParentes == EModeCalculDatesProjet.Automatic;
            if (dt == null)
                Row[c_champDateDebutReel] = DBNull.Value;
            else
            {
                DateTime date = dt.Value;
                if (TypeProjet == null || !TypeProjet.TravaillerAvecLesHeures)
                    date = date.Date;
                Row[c_champDateDebutReel] = date;
                Row[c_champStartedWithoutDate] = false;
            }
            if (bNotifierParent && Projet != null)
                Projet.UpdateDateDebutReelleFromFils();
        }

        /// /////////////////////////////////////////////
        void SetDateFinReelleMemeSiCestUnParent(DateTime? dt, bool bNotifierParent)
        {
            bNotifierParent &= (EModeCalculDatesProjet)ModeCalculDatesParentes == EModeCalculDatesProjet.Automatic;
            if (dt == null)
                Row[c_champDateFinReel] = DBNull.Value;
            else
            {
                DateTime date = dt.Value;
                if (TypeProjet == null || !TypeProjet.TravaillerAvecLesHeures)
                    date = date.Date;
                Row[c_champDateFinReel] = date;
                Row[c_champEndedWithoutDate] = false;
            }
            if (bNotifierParent && Projet != null)
                Projet.UpdateDateFinReelleFromFils();
        }


        //-----------------------------------------------------------------------
        /// <summary>
        /// Obtient ou définit la date de début réelle du projet
        /// </summary>
        [TableFieldProperty(CProjet.c_champDateDebutReel, true)]
        [DynamicField("True start date")]
        [TiagField("True start date")]
        public DateTime? DateDebutReel
        {
            get
            {
                return (DateTime?)Row[c_champDateDebutReel, true];
            }
            set
            {
                if (!HasChilds())
                    SetDateDebutReelleMemeSiCestUnParent(value, true);
                else
                    UpdateDateDebutReelleFromFils();
            }
        }

        ////ATTENTION, GARDER LE NOM "DATEFINRELLE" car utilisé dans des formules, filtres
        ////et propriétés chez les clients
        /// <summary>
        /// Obtient ou définit la date de fin réelle du projet
        /// </summary>
        [TableFieldProperty(c_champDateFinReel, NullAutorise = true)]
        [DynamicField("True end date")]
        [TiagField("True end date")]
        public DateTime? DateFinRelle
        {
            get
            {
                if (Row[c_champDateFinReel] == DBNull.Value)
                    return null;
                else
                    return (DateTime)Row[c_champDateFinReel];
            }
            set
            {
                if (!HasChilds())
                    SetDateFinReelleMemeSiCestUnParent(value, true);
                else
                    UpdateDateFinReelleFromFils();
            }
        }


        //-------------------------------------------------------
        /// <summary>
        /// Booléen indiquant si le projet est ou non en 'Date de début automatique'.
        /// Si un projet est en 'Date de début automatique' et que ce projet est lié
        /// à un projet prédécesseur, le fait de repousser la date de fin planifiée du
        /// projet prédécesseur au-delà de la date de début planifiée du projet,
        /// repoussera d'autant la date de début du projet; ceci afin que la règle
        /// de précédence reste respectée.
        /// </summary>
        [TableFieldProperty(c_champDebutAuto)]
        [DynamicField("Is auto start date")]
        [TiagField("Is auto start date")]
        public bool DateDebutAuto
        {
            get
            {
                return (bool)Row[c_champDebutAuto];
            }
            set
            {
                bool bOld = true;
                if (Row[c_champDebutAuto] != DBNull.Value)
                    bOld = DateDebutAuto;
                Row[c_champDebutAuto] = value;
                if (value != bOld && value)
                {
                    UpdateDateDebutPlanifieeCalculeeFromChilds();
                    UpdateDateFinPlanifieeCalculeeFromChilds();
                }
            }
        }

        //-----------------------------------------------------------------------------------
        /// <summary>
        /// Indique si le Projet est démarré bien que la date de début réelle ne soit pas définie
        /// </summary>
        [TableFieldProperty(c_champStartedWithoutDate)]
        [DynamicField("Started without date")]
        public bool StartedWithoutDate
        {
            get
            {
                return (bool)Row[c_champStartedWithoutDate];
            }
            set
            {
                if (DateDebutReel == null)
                {
                    Row[c_champStartedWithoutDate] = value;
                    if (Projet != null)
                        Projet.UpdateDateDebutReelleFromFils();
                }
            }
        }

        //-----------------------------------------------------------------------------------
        [DynamicField("Is started")]
        public bool IsStarted
        {
            get
            {
                return (DateDebutReel != null || StartedWithoutDate);
            }
        }

        //-----------------------------------------------------------------------------------
        /// <summary>
        /// Indique si le Projet est démarré bien que la date de début réelle ne soit pas définie
        /// </summary>
        [TableFieldProperty(c_champEndedWithoutDate)]
        [DynamicField("Ended without date")]
        public bool EndedWithoutDate
        {
            get
            {
                return (bool)Row[c_champEndedWithoutDate];
            }
            set
            {
                if (DateFinRelle == null)
                {
                    Row[c_champEndedWithoutDate] = value;
                    if (Projet != null)
                        Projet.UpdateDateFinReelleFromFils();
                }
            }
        }

        //-----------------------------------------------------------------------------------
        [DynamicField("Is ended")]
        public bool IsEnded
        {
            get
            {
                return (DateFinRelle != null || EndedWithoutDate);
            }
        }

        /// <summary>
        /// Retourne true si aucun des projets "feuille" n'est en Autostartdate, false sinon
        /// </summary>
        [DynamicField("Has auto start leaf")]
        public bool HasFeuilleAutoStart
        {
            get
            {
                if (!HasChilds())
                    return DateDebutAuto;
                else foreach (CProjet child in ProjetsFils)
                    {
                        if (child.HasFeuilleAutoStart)
                            return true;
                    }
                return false;
            }
        }

        /// /////////////////////////////////////////////
        public bool DatesAuto
        {
            get
            {
                if (HasChilds())
                {
                    return DateDebutAuto;
                }
                return DateDebutReel == null && DateFinRelle == null && DateDebutAuto;
            }
        }


        /// <summary>
        /// Change le mode de calcul des dates parent/enfant
        /// </summary>
        /// <remarks>
        /// Cette valeur est volatile et n'est jamais stockée en base de données<BR></BR>
        /// Ce champ est utile pour définir le mode de calcul lors de process impliquant beaucoup de projets<BR></BR>
        /// Les valeurs possibles sont<BR></BR>
        /// <LI>0 : automatic (valeur par défaut)</LI>
        /// <LI>1 : suspendu : le calcul des répercutions des dates sur les projets parents et fils est suspendue et est automatiquement réactivé avant la sauvegarde du projet</LI>
        /// <LI>2 : Désactivé : Le calcul est suspendu et n'est pas réactivé avant la sauvegarde des données</LI>
        /// <BR></BR>
        /// <BR></BR>
        /// POur simplifier l'utilisation de ce champ, il est préférable d'utiliser les fonction SuspendAutomaticDatesCalculation, DisableAutomaticDatesCalculation
        ///  et EnableAutomaticDatesCalculation
        /// 
        /// </remarks>
        [TableFieldProperty(c_champCalculateMode, IsInDb = false)]
        [DynamicField("Calculate mode code")]
        public int ModeCalculDatesParentes
        {
            get
            {
                object val = Row[c_champCalculateMode];
                if (val == DBNull.Value)
                    return (int)EModeCalculDatesProjet.Automatic;
                return (int)val;
            }
            set
            {
                Row[c_champCalculateMode] = value;
            }
        }

        /// <summary>
        /// Indique le comportement de ce projet lorsqu'il est geré par une étape de workflow.
        /// </summary>
        /// <remarks>
        /// 0 : Fonctionnement standard<BR></BR>
        /// 1 : Pas d'itération automatique
        /// 2 : L'étape ne change pas les dates
        /// 3 : Le comportement repasse en standard lorsqu'une étape est terminée
        /// </remarks>
        [TableFieldProperty(c_champStepLinkBehavior)]
        [DynamicField("Link behavior code")]
        public int OptionLienEtapeCode
        {
            get
            {
                return (int)Row[c_champStepLinkBehavior];
            }
            set
            {
                Row[c_champStepLinkBehavior] = value;
            }
        }

        /// <summary>
        /// Indique le comportement de ce projet lorsqu'il est geré par une étape de workflow.
        /// </summary>
        [DynamicField("Link behavior")]
        public COptionLienProjetEtape OptionLienEtape
        {
            get
            {
                return new COptionLienProjetEtape((EOptionLienProjetEtape)OptionLienEtapeCode);
            }
            set
            {
                if (value != null)
                    OptionLienEtapeCode = value.CodeInt;
            }
        }

        public bool HasOptionLienEtape(EOptionLienProjetEtape option)
        {
            return (OptionLienEtape.Code & option) == option;
        }

        [DynamicMethod("Suspend automatic date calculation until save or switch to automatic", "Recursive mode or not")]
        public void SuspendAutomaticDatesCalculation(bool bRecursive)
        {
            ModeCalculDatesParentes = (int)EModeCalculDatesProjet.Suspended;
            if (bRecursive && HasChilds())
            {
                foreach (CProjet fils in ProjetsFils)
                    fils.SuspendAutomaticDatesCalculation(true);
            }

        }

        [DynamicMethod("Deactivate automatic date calculation until save or reload of object", "Recursive mode or not")]
        public void DisableAutomaticDatesCalculation(bool bRecursive)
        {
            ModeCalculDatesParentes = (int)EModeCalculDatesProjet.Inactive;
            if (bRecursive && HasChilds())
            {
                foreach (CProjet fils in ProjetsFils)
                    fils.DisableAutomaticDatesCalculation(true);
            }
        }

        [DynamicMethod("Activate automatic date calculations and recalculate date if previous state was 'Suspended(0)'", "Recursive mode or not")]
        public void ActivateAutomaticDatesCalculation(bool bRecursive)
        {
            EModeCalculDatesProjet oldMode = (EModeCalculDatesProjet)ModeCalculDatesParentes;

            ModeCalculDatesParentes = (int)EModeCalculDatesProjet.Automatic;
            if (oldMode == EModeCalculDatesProjet.Suspended)
                RecalculateDates(false);
            if (bRecursive && HasChilds())
            {
                foreach (CProjet fils in ProjetsFils)
                    fils.ActivateAutomaticDatesCalculation(true);
            }
        }

        /// <summary>
        /// Calcule la date de début planifiée à partir de ses enfants
        /// </summary>
        /// <returns></returns>
        public void UpdateDateDebutPlanifieeCalculeeFromChilds()
        {
            if ((EModeCalculDatesProjet)ModeCalculDatesParentes != EModeCalculDatesProjet.Automatic)
                return;
            if (!HasChilds())
                return;
            bool bSurModifiesUniquement = true;
            if (DateDebutPlanifieeCalculee == null)
                bSurModifiesUniquement = false;
            if (IsDependanceChargee(c_nomTable, c_champIdParent))
                bSurModifiesUniquement = false;
            DateTime? dateDebut = DateDebutPlanifieeCalculee;
            List<CProjet> lstFils = new List<CProjet>();
            if (bSurModifiesUniquement)
            {
                //Récupère tous les fils modifiés
                List<CProjet> lstFilsSansLecture = GetProjetsFilsSansChargementEnBase();
                bool bAllNew = true;
                foreach (CProjet prjFils in lstFilsSansLecture)
                {
                    if (
                        prjFils.Row.RowState == DataRowState.Modified ||
                        prjFils.Row.RowState == DataRowState.Deleted ||
                        prjFils.Row.RowState == DataRowState.Added)
                    {
                        if (prjFils.Row.RowState != DataRowState.Added)
                            bAllNew = false;


                        if (GetLastDateDebutPlanifieeConnuePourProjet(prjFils) == dateDebut)
                        //C'est lui qui déterminait la date de début
                        {
                            DataRow row = prjFils.Row.Row;
                            if (row.RowState == DataRowState.Deleted)
                            {
                                bSurModifiesUniquement = false;
                                break;
                            }
                            if (prjFils.DateDebutPlanifieePourParent > dateDebut)
                            {
                                //Damned, on ne connait plus la date de début min,
                                //il faut donc reprendre tous les fils !
                                lstFils.Clear();
                                bSurModifiesUniquement = false;
                                break;
                            }
                        }
                        lstFils.Add(prjFils);
                    }
                }
                if (bAllNew)
                {
                    //Si tous les fils sont nouveaux, ont fait un check complet
                    bSurModifiesUniquement = false;
                }
            }
            if (!bSurModifiesUniquement)
            {
                dateDebut = null;
                lstFils.Clear();
                foreach (CProjet projetFils in ProjetsFils)
                {
                    lstFils.Add(projetFils);
                }
            }

            foreach (CProjet projet in lstFils)
            {
                if (projet.IsValide())
                {
                    if (dateDebut == null || projet.DateDebutPlanifieePourParent < dateDebut.Value)
                        dateDebut = projet.DateDebutPlanifieePourParent;
                    StockLastDateDebutPlanifieeConnue(projet);
                }
            }

            SetDateDebutPlanifieeCalculeeMemeSiCestUnParent(dateDebut, true);
        }

        /// <summary>
        /// Calcule la date de fin à partir de la date de ses enfants
        /// </summary>
        /// <returns></returns>
        public void UpdateDateFinPlanifieeCalculeeFromChilds()
        {
            if ((EModeCalculDatesProjet)ModeCalculDatesParentes != EModeCalculDatesProjet.Automatic)
                return;
            if (!HasChilds())
                return;//rien à faire, c'est un truc sans projets fils
            bool bSurModifiesUniquement = true;
            if (DateFinPlanifiee == null)
                bSurModifiesUniquement = false;
            if (IsDependanceChargee(c_nomTable, c_champIdParent))
                bSurModifiesUniquement = false;
            DateTime? dateFin = DateFinPlanifieeCalculee;
            List<CProjet> lstFils = new List<CProjet>();
            if (bSurModifiesUniquement)
            {
                List<CProjet> lstProjetsFilsSansChargement = GetProjetsFilsSansChargementEnBase();
                foreach (CProjet prjFils in lstProjetsFilsSansChargement)
                {
                    if (prjFils.Row.RowState == DataRowState.Modified || prjFils.Row.RowState == DataRowState.Deleted)
                    {
                        //Attention, si l'ancienne date de fin était égale à la date
                        //de fin, et que la nouvelle date est inférieure à la date
                        //de fin, on ne connait plus le max !
                        if (GetLastDateFinPlanifieeConnuePourProjet(prjFils) == dateFin)
                        {
                            if (prjFils.Row.RowState == DataRowState.Deleted)
                            {
                                bSurModifiesUniquement = false;
                                break;
                            }
                            if (prjFils.DateFinPlanifieePourParent < dateFin)
                            {
                                //Damned, on ne connait plus la date de fin max,
                                //il faut donc reprendre tous les fils !
                                bSurModifiesUniquement = false;
                                break;
                            }
                        }
                        lstFils.Add(prjFils);
                    }
                }
            }
            if (!bSurModifiesUniquement)
            {
                dateFin = null;
                lstFils.Clear();
                foreach (CProjet projetFils in ProjetsFils)
                {
                    lstFils.Add(projetFils);
                }
            }

            foreach (CProjet projet in lstFils)
            {
                if (projet.IsValide())
                {
                    if (dateFin == null || projet.DateFinPlanifieePourParent > dateFin.Value)
                        dateFin = projet.DateFinPlanifieePourParent;
                    StockLastDateFinPlanifieeConnue(projet);
                }
            }
            SetDateFinPlanifieeCalculeeMemeSiCestUnParent(dateFin, true);
        }

        //------------------------------------------------------------------------------
        public void UpdateDateDebutReelleFromFils()
        {
            if ((EModeCalculDatesProjet)ModeCalculDatesParentes != EModeCalculDatesProjet.Automatic)
                return;
            if (!HasChilds())
                return;
            bool bSurModifiesUniquement = true;
            if (IsDependanceChargee(c_nomTable, c_champIdParent))
                bSurModifiesUniquement = false;
            DateTime? dateDebut = DateDebutReel;
            List<CProjet> lstFils = new List<CProjet>();
            bool bAllNull = true;
            if (bSurModifiesUniquement)
            {
                //Récupère tous les fils modifiés
                List<CProjet> lstFilsSansLecture = GetProjetsFilsSansChargementEnBase();
                bool bAllNew = true;
                foreach (CProjet prjFils in lstFilsSansLecture)
                {
                    if (prjFils.Row.RowState == DataRowState.Deleted)
                    {
                        bSurModifiesUniquement = false;
                        break;
                    }
                    if (
                        prjFils.Row.RowState == DataRowState.Modified ||
                        prjFils.Row.RowState == DataRowState.Added)
                    {
                        if (prjFils.Row.RowState != DataRowState.Added)
                            bAllNew = false;
                        if (prjFils.DateDebutReel != null)
                        {
                            bAllNull = false;
                            if (GetLastDateDebutReelleConnuePourProjet(prjFils) == dateDebut)
                            //C'est lui qui déterminait la date de début
                            {
                                DataRow row = prjFils.Row.Row;
                                if (row.RowState == DataRowState.Deleted)
                                {
                                    bSurModifiesUniquement = false;
                                    break;
                                }
                                if (prjFils.DateDebutReel > dateDebut)
                                {
                                    //Damned, on ne connait plus la date de début min,
                                    //il faut donc reprendre tous les fils !
                                    lstFils.Clear();
                                    bSurModifiesUniquement = false;
                                    break;
                                }
                            }
                        }
                        lstFils.Add(prjFils);
                    }
                }
                if (bAllNew)
                {
                    //Si tous les fils sont nouveaux, ont fait un check complet
                    bSurModifiesUniquement = false;
                }
                if (bAllNull && DateDebutReel != null)
                {
                    //Tous les fils modifiés sont nulls, mais on a une date de début,
                    //On ne sait donc pas quelle est cette date, il faut reprendre
                    //a partir de tous les fils y compris les non modifiés
                    bSurModifiesUniquement = false;
                }
            }
            if (!bSurModifiesUniquement)
            {
                dateDebut = null;
                lstFils.Clear();
                foreach (CProjet projetFils in ProjetsFils)
                {
                    lstFils.Add(projetFils);
                }
            }

            foreach (CProjet projet in lstFils)
            {
                if (projet.IsValide())
                {
                    if (dateDebut == null || projet.DateDebutReel < dateDebut.Value)
                        dateDebut = projet.DateDebutReel;
                    StockLastDateDebutReelleConnue(projet);
                }
            }

            SetDateDebutReelleMemeSiCestUnParent(dateDebut, true);

            // Règle 2 : Si aucun fils n'a de date de début
            if(dateDebut == null)
            {
                // On cherche si au moins un fils a le flag StartedWithoutDate = true
                bool bFlagEnded = false;
                foreach (CProjet projet in ProjetsFils)
                {
                    if (projet.IsValide())
                    {
                        if (projet.StartedWithoutDate)
                        {
                            // On a trouvé un fils qui est StartedWithourDate
                            bFlagEnded = true;
                            // c'est bon on peut s'arrêter de chercher maintenant
                            break;
                        }
                    }
                }
                StartedWithoutDate = bFlagEnded;
            }
        }

        //--------------------------------------------------------
        public void UpdateDateFinReelleFromFils()
        {
            if ((EModeCalculDatesProjet)ModeCalculDatesParentes != EModeCalculDatesProjet.Automatic)
                return;
            if (!HasChilds())
                return;
            bool bSurModifiesUniquement = true;
            if (IsDependanceChargee(c_nomTable, c_champIdParent))
                bSurModifiesUniquement = false;
            DateTime? dateFin = DateFinRelle;
            List<CProjet> lstFils = new List<CProjet>();
            bool bHasNull = false;
            if (bSurModifiesUniquement)
            {
                //Récupère tous les fils modifiés
                List<CProjet> lstFilsSansLecture = GetProjetsFilsSansChargementEnBase();
                bool bAllNew = true;
                foreach (CProjet prjFils in lstFilsSansLecture)
                {
                    if (prjFils.Row.RowState == DataRowState.Deleted)
                    {
                        bSurModifiesUniquement = false;
                        break;
                    }
                    if (
                        prjFils.Row.RowState == DataRowState.Modified ||
                        prjFils.Row.RowState == DataRowState.Added)
                    {
                        if (prjFils.Row.RowState != DataRowState.Added)
                            bAllNew = false;
                        if (prjFils.DateFinRelle == null && !prjFils.EndedWithoutDate)
                            bHasNull = true;
                        if (prjFils.DateFinRelle != null)
                        {
                            if (dateFin == null)
                            {
                                bSurModifiesUniquement = false;
                                break;
                            }
                            if (GetLastDateFinReelleConnuePourProjet(prjFils) == dateFin)
                            // C'est lui qui déterminait la date de fin
                            {
                                DataRow row = prjFils.Row.Row;
                                if (row.RowState == DataRowState.Deleted)
                                {
                                    bSurModifiesUniquement = false;
                                    break;
                                }
                                if (prjFils.DateFinRelle < dateFin)
                                {
                                    //Damned, on ne connait plus la date de fin max,
                                    //il faut donc reprendre tous les fils !
                                    lstFils.Clear();
                                    bSurModifiesUniquement = false;
                                    break;
                                }
                            }
                        }
                        lstFils.Add(prjFils);
                    }
                }
                if (bAllNew)
                {
                    //Si tous les fils sont nouveaux, ont fait un check complet
                    bSurModifiesUniquement = false;
                }
                if (bHasNull)
                {
                    SetDateFinReelleMemeSiCestUnParent(null, true);
                    return;
                }
            }
            if (!bHasNull)
            {
                if (!bSurModifiesUniquement)
                {
                    lstFils.Clear();
                    dateFin = null;
                    foreach (CProjet projetFils in ProjetsFils)
                    {
                        lstFils.Add(projetFils);
                    }
                }

                foreach (CProjet projet in lstFils)
                {
                    if (projet.IsValide())
                    {
                        if (projet.DateFinRelle == null)
                        {
                            // On a trouvé un fils qui n'a pas de date fin réelle
                            if (projet.EndedWithoutDate)
                                continue; // On doit regarder les autres projets fils

                            dateFin = null;
                            break;
                        }
                        if (dateFin == null || projet.DateFinRelle > dateFin.Value)
                            dateFin = projet.DateFinRelle;
                        StockLastDateFinReelleConnue(projet);
                    }
                }
            }

            SetDateFinReelleMemeSiCestUnParent(dateFin, true);

            // Règle 2 : Si aucun fils n'a de date de fin
            if (dateFin == null)
            {
                // On cherche si tous les fils ont le flag EndedWithoutDate = true
                bool bFlagEnded = true;
                foreach (CProjet projet in ProjetsFils)
                {
                    if (projet.IsValide())
                    {
                        if (!projet.IsEnded)
                        {
                            // On a trouvé un fils qui n'est pas EndedWithourDate
                            bFlagEnded = false;
                            // c'est bon on peut s'arrêter de chercher maintenant
                            break;
                        }
                    }
                }
                EndedWithoutDate = bFlagEnded;
            }
        }

        //------------------------------------------------------------------------------------------
        /// <summary>
        /// Retourne la liste des sous éléments du projet (interventions et projets)
        /// </summary>
        public List<IElementDeProjetPlanifiable> ElementsDuProjetAttachables
        {
            get
            {
                List<IElementDeProjetPlanifiable> eles = new List<IElementDeProjetPlanifiable>();
                CListeObjetsDonnees prjs = ProjetsFils;
                foreach (CProjet p in prjs)
                    eles.Add(p);
                CListeObjetsDonnees inters = Interventions;
                foreach (CIntervention i in inters)
                    eles.Add(i);
                return eles;
            }
        }


        public CTypeElementDeProjet TypeElementDeProjet
        {
            get
            {
                return new CTypeElementDeProjet(ETypeElementDeProjet.Projet);
            }
        }


        #region IObjetDonneeAChamps Membres

        public CRelationElementAChamp_ChampCustom GetNewRelationToChamp()
        {
            return new CRelationProjet_ChampCustom(ContexteDonnee);
        }

        public string GetNomTableRelationToChamps()
        {
            return CRelationProjet_ChampCustom.c_nomTable;
        }

        public CListeObjetsDonnees GetRelationsToChamps(int nIdChamp)
        {
            CListeObjetsDonnees liste = RelationsChampsCustom;
            liste.InterditLectureInDB = true;
            liste.Filtre = new CFiltreData(CChampCustom.c_champId + " = @1", nIdChamp);
            return liste;
        }

        #endregion

        public HashSet<CTypeProjet> TousLesTypesDuProjet
        {
            get
            {
                HashSet<CTypeProjet> setTypes = new HashSet<CTypeProjet>();
                if (TypeProjet != null)
                    setTypes.Add(TypeProjet);
                foreach (CProjet_SousType st in RelationsSousTypes)
                    setTypes.Add(st.SousType);
                return setTypes;
            }
        }

        #region IElementAChamps Membres

        public IDefinisseurChampCustom[] DefinisseursDeChamps
        {
            get
            {
                HashSet<CTypeProjet> setTypes = TousLesTypesDuProjet;
                List<IDefinisseurChampCustom> lst = new List<IDefinisseurChampCustom>();
                foreach (CTypeProjet type in setTypes)
                    lst.Add(type);
                return lst.ToArray();
            }
        }

        public CChampCustom[] GetChampsHorsFormulaire()
        {
            if (TypeProjet == null)
                return new CChampCustom[0];

            ArrayList lst = new ArrayList();
            foreach (CRelationTypeProjet_ChampCustom rel in TypeProjet.RelationsChampsCustomDefinis)
                lst.Add(rel.ChampCustom);

            foreach (CRelationTypeProjet_Formulaire rel1 in TypeProjet.RelationsFormulaires)
                foreach (CRelationFormulaireChampCustom rel2 in rel1.Formulaire.RelationsChamps)
                    lst.Remove(rel2.Champ);

            return (CChampCustom[])lst.ToArray(typeof(CChampCustom));
        }

        public CFormulaire[] GetFormulaires()
        {
            return CUtilElementAChamps.GetFormulaires(this);
        }

        //----------------------------------------------------
        /// <summary>
        /// Donne la liste des relations du projet avec des champs personnalisés
        /// </summary>
        [RelationFille(typeof(CRelationProjet_ChampCustom), "ElementAChamps")]
        [DynamicChilds("Custom fields relations", typeof(CRelationProjet_ChampCustom))]
        public CListeObjetsDonnees RelationsChampsCustom
        {
            get
            {
                return GetDependancesListe(CRelationProjet_ChampCustom.c_nomTable, c_champId);
            }
        }

        #endregion

        #region IElementAVariables Membres

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

        #endregion

        /// <summary>
        /// Pourcentage d'avancement du projet.
        /// Lorsqu'il s'agit d'un projet parent la formule de calcul est la suivante :
        /// (PS0 * P0 + PS1 * P1 + ... + PSn * Pn)/(P0 + P1 + ... + Pn)
        /// où PSn est le projet feuille d'indice n et Pn le poids attribué à ce même projet.
        /// Sont pris en considération, tous les projets feuilles enfants de ce projet,
        /// quelque soit leur niveau dans la hiérarchie des projets enfants.
        /// Lorqu'il s'agit d'un projet feuille, le mode de calcul est donné par la formule
        /// définie au niveau du type de projet correspondant.
        /// </summary>
        [TableFieldProperty(CProjet.c_champPctAvancement)]
        [DynamicField("Progress status")]
        [TiagField("Progress status")]
        public double PctAvancement
        {
            get
            {
                return (double)Row[c_champPctAvancement];
            }
            set
            {
                Row[c_champPctAvancement] = value;
            }
        }


        /// <summary>
        /// Poids du projet.
        /// Lorsqu'il s'agit d'un projet parent la formule de calcul est la suivante :
        /// P0 + P1 + ... + Pn
        /// où Pn est le poids attribué au projet feuille d'indice n.
        /// Sont pris en considération, tous les projets feuilles enfants de ce projet,
        /// quelque soit leur niveau dans la hiérarchie des projets enfants.
        /// Lorqu'il s'agit d'un projet feuille, le mode de calcul est donné par la formule
        /// définie au niveau du type de projet correspondant.
        /// </summary>
        [TableFieldProperty(CProjet.c_champPoids)]
        [DynamicField("Weight")]
        [TiagField("Weight")]
        public double Poids
        {
            get
            {
                return (double)Row[c_champPoids];
            }
            set
            {
                Row[c_champPoids] = value;
            }
        }


        //-----------------------------------------------------------
        /// <summary>
        /// Identifiant de la barre de Gantt contenant l'élément.<BR></BR>
        /// Lorsque plusieurs projets ont le même Id de barre Gantt,
        /// ils sont affichés sur la même ligne, sauf si cet identifiant est vide
        /// </summary>
        [TableFieldProperty(c_champGanttId, 255)]
        [DynamicField("Gantt Bar Id")]
        public string GanttId
        {
            get
            {
                return (string)Row[c_champGanttId];
            }
            set
            {
                Row[c_champGanttId] = value;
            }
        }


        //-----------------------------------------------------------
        /// <summary>
        /// Numéro d'itération (si ce projet est geré par un workflow).
        /// </summary>
        [TableFieldProperty(c_champIterationNumber)]
        [DynamicField("Iteration n0")]
        public int NumeroIteration
        {
            get
            {
                return (int)Row[c_champIterationNumber];
            }
            set
            {
                Row[c_champIterationNumber] = value;
            }
        }



        /// <summary>
        /// Durée du projet en heures.
        /// Si les dates de début et de fin réelles sont remplies, c'est la différence entre ces deux dates,
        /// ou si les dates de début et de fin planifiées sont remplies, c'est la différence entre ces deux dates,
        /// sinon, c'est 24.
        /// </summary>
        [DynamicField("Duration")]
        public double? DureeEnHeure
        {
            get
            {
                if (DateFinRelle != null && DateDebutReel != null)
                    return ((TimeSpan)(DateFinRelle.Value - DateDebutReel.Value)).TotalHours;
                if (DateFinPlanifiee != null && DateDebutPlanifiee != null)
                    return ((TimeSpan)(DateFinPlanifiee - DateDebutPlanifiee)).TotalHours;
                return 24;
            }
        }

        /// <summary>
        /// Retourne le poids calculé à partir de la formule
        /// de poids du type de projet;
        /// </summary>
        /// <returns></returns>
        public double CalcPoidsDepuisFormule()
        {
            double fPoids = 0;
            if (TypeProjet != null)
            {
                C2iExpression formule = TypeProjet.FormulePoids;
                CContexteEvaluationExpression ctx = new CContexteEvaluationExpression(this);
                CResultAErreur result = formule.Eval(ctx);
                if (result)
                    try
                    {
                        fPoids = Convert.ToDouble(result.Data);
                    }
                    catch
                    {
                    }
            }
            return fPoids;
        }

        /// <summary>
        /// Retourne true si l'élément a des projets fils
        /// </summary>
        /// <returns></returns>
        public bool HasChilds()
        {
            return HasDependances(CProjet.c_nomTable, new string[] { CProjet.c_champIdParent });
        }

        ///-------------------------------------------------------------------
        private List<CProjet> GetProjetsFilsSansChargementEnBase()
        {
            List<CProjet> lstRetour = new List<CProjet>();
            CListeObjetsDonnees lstFilsSansLecture = new CListeObjetsDonnees(ContexteDonnee, typeof(CProjet));
            lstFilsSansLecture.Filtre = new CFiltreData(CProjet.c_champIdParent + "=@1", Id);
            lstFilsSansLecture.InterditLectureInDB = true;
            lstFilsSansLecture.RowStateFilter = DataViewRowState.ModifiedCurrent | DataViewRowState.Added | DataViewRowState.Deleted;
            foreach (CProjet projet in lstFilsSansLecture)
                lstRetour.Add(projet);
            return lstRetour;
        }



        ///-------------------------------------------------------------------
        //Met à jour le poid. Attention,le poids des fils doit être à jour !
        public void UpdateWeight()
        {
            double fPoids = Poids;
            if (!HasChilds())
            {
                Poids = CalcPoidsDepuisFormule();
                return;
            }
            if (IsNew())
                CalcWeight(false);
            //C'est une mise à jour, on repart de l'ancien poids,
            //et on fait les modifs par rapport aux modifs des poids des enfants
            if (Row.HasVersion(DataRowVersion.Original))
                fPoids = (double)Row[c_champPoids, DataRowVersion.Original];
            //Charge les dépendances
            List<CProjet> lst = GetProjetsFilsSansChargementEnBase();
            foreach (CProjet prj in lst)
            {
                if (prj.Row.RowState != DataRowState.Unchanged)
                {
                    if (prj.Row.HasVersion(DataRowVersion.Original))
                        fPoids -= (double)prj.Row[c_champPoids, DataRowVersion.Original];
                    if (prj.Row.HasVersion(DataRowVersion.Current))
                        fPoids += (double)prj.Row[c_champPoids];
                }
            }
        }


        /// <summary>
        /// Recalcule le poids du projet récursivement ou non en fonction de la valeur passée en paramètre
        /// </summary>
        /// <param name="bRecursive">True pour calcul récursif, False sinon</param>
        /// <returns>Le poids calculé</returns>
        [DynamicMethod("Calculate weight for the project", "true for recursive calculation")]
        public double CalcWeight(bool bRecursive)
        {
            double fPoids = 1;
            if (!HasChilds())
            {
                fPoids = CalcPoidsDepuisFormule();

            }
            else
            {
                fPoids = 0;
                foreach (CProjet projetFils in ProjetsFils)
                {
                    if (bRecursive)
                        projetFils.CalcWeight(bRecursive);
                    fPoids += projetFils.Poids;
                }
            }
            if (Projet != null && fPoids != Poids)
            {
                Poids = fPoids;
                Projet.CalcWeight(false);
            }
            Poids = fPoids;
            return fPoids;
        }

        /// <summary>
        /// Calcule la progression du projet à partir de la formule
        /// du type de projet
        /// </summary>
        /// <returns></returns>
        public double CalcProgressDepuisFormule()
        {
            double fAvancement = 0;
            if (TypeProjet != null && TypeProjet.FormuleAvancement != null)
            {
                CContexteEvaluationExpression ctx = new CContexteEvaluationExpression(this);
                CResultAErreur result = TypeProjet.FormuleAvancement.Eval(ctx);
                if (result)
                {
                    try
                    {
                        fAvancement = Convert.ToDouble(result.Data);
                    }
                    catch
                    {
                    }
                }
            }
            return fAvancement;
        }

        //--------------------------------------------------
        [TableFieldProperty(c_champPoidsFils, true)]
        public double? SommePoidsDesFils
        {
            get
            {
                return (double?)Row[c_champPoidsFils, true];
            }
        }

        //--------------------------------------------------
        [TableFieldProperty(c_champAvancementsFils, true)]
        public double? SommeAvancementFils
        {
            get
            {
                return (double?)Row[c_champAvancementsFils, true];
            }
        }

        /// <summary>
        /// Met à jour la progression. Attention, dépend de la progression des fils
        /// qui doit donc être calculée
        /// </summary>
        public void UpdateProgress()
        {
            if (SommeAvancementFils == null || SommePoidsDesFils == null)
            {
                CalcProgress(false);
                return;
            }
            if (!HasChilds())
            {
                CalcProgress(false);
                return;
            }
            double fAvancement = SommeAvancementFils.Value;
            double fPoids = SommePoidsDesFils.Value;
            List<CProjet> lst = GetProjetsFilsSansChargementEnBase();
            foreach (CProjet prj in lst)
            {

                if (prj.Row.RowState != DataRowState.Unchanged)
                {
                    if (prj.Row.HasVersion(DataRowVersion.Original))
                    {
                        double fPds = (double)prj.Row[c_champPoids, DataRowVersion.Original];
                        double fAvt = (double)prj.Row[c_champAvancementsFils, DataRowVersion.Original];
                        fPoids -= fPds;
                        fAvancement -= fPds * fAvancement;
                    }
                    if (prj.Row.HasVersion(DataRowVersion.Current))
                    {
                        double fPds = (double)prj.Row[c_champPoids];
                        double fAvt = (double)prj.Row[c_champAvancementsFils];
                        fPoids += fPds;
                        fAvancement += fPds * fAvancement;
                    }
                }
            }
            Row[c_champAvancementsFils] = fAvancement;
            Row[c_champPoidsFils] = fPoids;
            if (fPoids != 0)
                PctAvancement = fAvancement / fPoids;
            else
                PctAvancement = 0;
        }

        /// <summary>
        /// recalcule la progression du projet, récursivement ou non en fonction de la valeur passée en paramètre
        /// </summary>
        /// <param name="bRecursive">True pour récursivité, False sinon</param>
        /// <returns>La progression calculée</returns>
        [DynamicMethod("Calc progress", "true for recursive calculation")]
        public double CalcProgress(bool bRecursive)
        {
            double fAvancement = 0;
            if (HasChilds())
            {
                double fPoids = 0;
                foreach (CProjet projetFils in ProjetsFils)
                {
                    if (bRecursive)
                        projetFils.CalcProgress(true);
                    fAvancement += projetFils.PctAvancement * projetFils.Poids;
                    fPoids += projetFils.Poids;
                }
                Row[c_champAvancementsFils] = fAvancement;
                Row[c_champPoids] = fPoids;
                if (fPoids != 0)
                    fAvancement /= fPoids;
            }
            else
                fAvancement = CalcProgressDepuisFormule();

            if (fAvancement != PctAvancement)
            {
                if (Projet != null)
                {
                    PctAvancement = fAvancement;
                    Projet.CalcProgress(false);
                }
                foreach (CRelationMetaProjet_Projet rel in RelationsMetaProjets)
                {
                    rel.MetaProjet.CalcProgress(false);
                }
            }

            PctAvancement = fAvancement;
            return fAvancement;
        }




        #region AnomaliesV2
        /// <summary>
        /// Réservé pour utilisation future
        /// </summary>
        [DynamicMethod("Audit the project")]
        public void AuditProject()
        {
            CalcAnomaliesInCurrentContext(null);
        }

        /// <summary>
        /// Ajoute récursivement les éléments de sous projet
        /// </summary>
        /// <param name="projet"></param>
        /// <param name="lstToFill"></param>
        private void RecurseAddSousElements(List<IElementDeProjetPlanifiable> lstToFill)
        {
            foreach (CProjet sousProjet in ProjetsFils)
            {
                lstToFill.Add(sousProjet);
                sousProjet.RecurseAddSousElements(lstToFill);
            }
            foreach (CIntervention intervention in Interventions)
            {
                lstToFill.Add(intervention);
            }
        }

        /// <summary>
        /// calcule les anomalies. Attention, ne travaille qu'avec les éléments
        /// sauvegardés (utilisation de filtres avancés)
        /// </summary>
        /// <param name="indicateurParametre"></param>
        /// <returns></returns>
        public CResultAErreur CalcAnomaliesInCurrentContext(IIndicateurProgression indicateurParametre)
        {
            CResultAErreur result = CResultAErreur.True;
            result = CObjetDonneeAIdNumerique.Delete(AnomaliesDuProjet, true);
            if (!result)
                return result;
            CConteneurIndicateurProgression indicateur = CConteneurIndicateurProgression.GetConteneur(indicateurParametre);
            indicateurParametre.SetBornesSegment(0, 100);

            List<IElementDeProjetPlanifiable> lstElementsDeProjet = new List<IElementDeProjetPlanifiable>();
            HashSet<CLienDeProjet> hashSetLiens = new HashSet<CLienDeProjet>();

            if (ContexteDonnee.IsEnEdition)
            {
                //Chargement des éléments sans utiliser de filtres avancés
                lstElementsDeProjet.Add(this);
                RecurseAddSousElements(lstElementsDeProjet);
                //Chargement des liens
                foreach (IElementDeProjetPlanifiable elt in lstElementsDeProjet)
                {
                    foreach (CLienDeProjet lien in elt.LiensDeProjetAttaches)
                        hashSetLiens.Add(lien);
                }
            }
            else
            {
                //Chargement des elements fils en utilisant des filtres avancés
                //Charge tous les éléments du projet et des sous projets
                CListeObjetDonneeGenerique<CProjet> lstProjets = new CListeObjetDonneeGenerique<CProjet>(ContexteDonnee);
                lstProjets.PreserveChanges = true;
                lstProjets.Filtre = new CFiltreData(CProjet.c_champCodeSystemeComplet + " like @1",
                    CodeSystemeComplet + "%");

                lstProjets.AssureLectureFaite();
                indicateur.SetValue(5);

                //Chargement des interventions
                CListeObjetsDonnees lstInterventions = lstProjets.GetDependances("Interventions");
                lstInterventions.PreserveChanges = true;
                lstInterventions.AssureLectureFaite();
                indicateur.SetValue(10);

                //Chargement des liens
                foreach (CLienDeProjet lien in lstProjets.GetDependances("LiensEnTantQueProjetA"))
                    hashSetLiens.Add(lien);
                foreach (CLienDeProjet lien in lstProjets.GetDependances("LiensEnTantQueProjetB"))
                    hashSetLiens.Add(lien);
                foreach (CLienDeProjet lien in lstInterventions.GetDependances("LiensEnTantQueInterventionA"))
                    hashSetLiens.Add(lien);
                foreach (CLienDeProjet lien in lstInterventions.GetDependances("LiensEnTantQueInterventionB"))
                    hashSetLiens.Add(lien);
                indicateur.SetValue(15);

                foreach (CProjet projet in lstProjets)
                    lstElementsDeProjet.Add(projet);
                foreach (CIntervention intervention in lstInterventions)
                    lstInterventions.Add(intervention);
            }
            List<CLienDeProjet> lstLiens = new List<CLienDeProjet>();
            foreach (CLienDeProjet lien in hashSetLiens)
                lstLiens.Add(lien);


            //Controle de la planification
            indicateur.PushSegment(15, 20);
            indicateur.SetBornesSegment(0, lstElementsDeProjet.Count());
            int nElt = 0;
            if ((this.TypesAnomaliesFiltres & ETypeAnomalieProjet.PlanificationIncomplete) == 0)
            {
                foreach (IElementDeProjetPlanifiable elt in lstElementsDeProjet)
                {
                    if (elt.DateDebutGantt == null || elt.DateDebutGantt == null)
                    {
                        result = CAnomalieProjet.CreerAnomalie(
                            ContexteDonnee,
                            this,
                            ETypeAnomalieProjet.PlanificationIncomplete,
                            I.T("'@1' is not completely planned|475", elt.Libelle),
                            elt);
                        if (!result)
                            return result;
                    }
                    nElt++;
                    indicateur.SetValue(nElt);
                }
            }
            indicateur.PopSegment();
            indicateur.SetValue(20);

            //controle des respect des contraintes de lien
            indicateur.PushSegment(20, 60);
            indicateur.SetBornesSegment(0, lstLiens.Count());
            nElt = 0;
            if ((this.TypesAnomaliesFiltres & ETypeAnomalieProjet.NonRespectContrainteDate) == 0)
            {
                foreach (CLienDeProjet lien in lstLiens)
                {
                    result = lien.CalcAnomaliesDates(this);
                    if (!result)
                        return result;
                    nElt++;
                    indicateur.SetValue(nElt);
                }
            }
            indicateur.PopSegment();
            indicateur.SetValue(60);

            return result;
        }
        #endregion

        #region IElementATypeStructurant<CTypeProjet> Membres

        public CTypeProjet ElementStructurant
        {
            get { throw new NotImplementedException(); }
        }

        #endregion

        public int IdTypeStructurant
        {
            get { return (int)Row[CTypeProjet.c_champId]; }
        }

        CTypeProjet IElementATypeStructurant<CTypeProjet>.ElementStructurant
        {
            get { return TypeProjet; }
        }


        /// <summary>
        /// Donne la liste des <see cref="CAnomalieProjet">anomalies</see> concernant le projet<br/>
        /// Réservé pour utilisation future
        /// </summary>
        [DynamicChilds("Concerning anomalies", typeof(CAnomalieProjet))]
        [RelationFille(typeof(CAnomalieProjet), "ProjetConcerne")]
        public CListeObjetsDonnees AnomaliesConcernant
        {
            get
            {
                return GetDependancesListe(CAnomalieProjet.c_nomTable, CAnomalieProjet.c_champIdProjetConcerne);
            }
        }

        //---------------------------------------------------------------------
        protected void MoveWithChilds(
            TimeSpan sp,
            TimeSpan? duree,
            EModeDeplacementProjet mode,
            bool bForcerSurCetElement)
        {
            if (sp.TotalHours == 0 && duree == null)
                return;
            if (!bForcerSurCetElement && ProjetsFils.Count == 0)
            {
                if ((DateFinRelle != null || DateDebutReel != null) &&
                    mode != EModeDeplacementProjet.MoveNonAutoEtTermines)
                    return;
                if (!DateDebutAuto &&
                    mode != EModeDeplacementProjet.MoveNonAuto &&
                    mode != EModeDeplacementProjet.MoveNonAutoEtTermines)
                    return;
            }
            bool bHasSuspend = (EModeCalculDatesProjet)ModeCalculDatesParentes == EModeCalculDatesProjet.Automatic;
            if (bHasSuspend)
                ModeCalculDatesParentes = (int)EModeCalculDatesProjet.Suspended;
            DateDebutGantt = DateDebutGantt.Add(sp);
            if (duree == null && (DateFinPlanifiee != null || DateFinRelle != null))
                DateFinGantt = DateFinGantt.Add(sp);
            else if (duree != null)
                DateFinGantt = DateDebutGantt.Add(duree.Value);
            foreach (CProjet prj in ProjetsFils.ToArrayList())
            {
                int nOldMode = prj.ModeCalculDatesParentes;
                prj.MoveWithChilds(sp, null, mode, false);
                prj.ModeCalculDatesParentes = nOldMode;
            }
            if (bHasSuspend)
                ActivateAutomaticDatesCalculation(false);
            if (ProjetsFils.Count > 0)
            {
                UpdateDateFinPlanifieeCalculeeFromChilds();
                UpdateDateDebutPlanifieeCalculeeFromChilds();
            }

        }


        //---------------------------------------------------------------------
        protected void RepercuteMoveSurContraintes(TimeSpan sp, TimeSpan? duree)
        {
            if (sp.TotalHours > 0 || duree != null)
            {
                HashSet<IElementDeProjetPlanifiable> set = new HashSet<IElementDeProjetPlanifiable>();
                FillDicSuccesseurs(set);
                foreach (IElementDeProjetPlanifiable elt in set)
                {
                    if (elt != null)
                    {
                        if (elt.DateDebutGantt < DateFinGantt && elt.DatesAuto)
                            elt.Move(DateFinGantt - elt.DateDebutGantt, null, EModeDeplacementProjet.MoveAutoOnly, false);
                    }
                }
            }
            else
                if (sp.TotalHours < 0)
                {
                    HashSet<IElementDeProjetPlanifiable> set = new HashSet<IElementDeProjetPlanifiable>();
                    FillDicPredecesseurs(set);
                    foreach (IElementDeProjetPlanifiable elt in set)
                        if (elt != null)
                        {
                            if (elt.DateFinGantt > DateDebutGantt)
                                elt.Move(DateDebutGantt - elt.DateFinGantt, null, EModeDeplacementProjet.MoveAutoOnly, false);
                        }
                }

            foreach (CProjet prj in ProjetsFils.ToArrayList())
                prj.RepercuteMoveSurContraintes(sp, duree);
        }


        /// <summary>
        /// Déplace le projet vers une nouvelle date de début planifiée et fixe une nouvelle durée
        /// </summary>
        /// <param name="newStartDate">Nouvelle date de début planifiée</param>
        /// <param name="durationHour">Nouvelle durée exprimée en heures</param>
        /// <param name="moveMode">Mode de déplacement</param>
        [DynamicMethod("Move the current Project to the new Planned Start Date",
            "New Planned Start Date",
            "New Duration in Hours",
            "Moving Mode (int) : 0-Move Auto only, 1-Move non Auto, 2-Move non Auto and Ended")]
        public void MoveProject(DateTime newStartDate, double durationHour, int moveMode)
        {
            if (DateDebutPlanifiee == null)
                DateDebutPlanifiee = DateTime.Now;

            TimeSpan sp = newStartDate - this.DateDebutPlanifiee.Value;
            TimeSpan duree = TimeSpan.FromHours(durationHour);
            EModeDeplacementProjet mode = (EModeDeplacementProjet)moveMode;

            Move(sp, duree, mode, true);

        }

        [DynamicMethod("Recalculate all dates according to childs dates", "Recursive")]
        public void RecalculateDates(bool bRecursive)
        {
            RecalculerLesDates(bRecursive, true);
        }

        public void RecalculerLesDates(bool bRecursive, bool bNotifierParent)
        {
            if (bRecursive)
            {
                foreach (CProjet projet in ProjetsFils)
                    projet.RecalculerLesDates(true, false);
            }
            DateTime? dateDebutReel = null;
            DateTime? dateFinReelle = null;
            bool bAllTermines = true;
            DateTime? dateDebutPlanifiee = null;
            DateTime? dateFinPlanifiee = null;
            if (ProjetsFils.Count == 0)
            {
                dateDebutReel = DateDebutReel;
                dateFinReelle = DateFinRelle;
                dateDebutPlanifiee = DateDebutPlanifiee;
                dateFinPlanifiee = DateFinPlanifiee;
            }
            else
            {
                foreach (CProjet projet in ProjetsFils)
                {
                    bAllTermines &= projet.DateFinRelle != null;

                    if (projet.DateDebutReel != null && (projet.DateDebutReel < dateDebutReel || dateDebutReel == null))
                        dateDebutReel = projet.DateDebutReel;
                    if (bAllTermines && (projet.DateFinRelle > dateFinReelle || dateFinReelle == null))
                        dateFinReelle = projet.DateFinRelle;

                    if (DateDebutAuto)
                    {
                        if (projet.DateDebutPlanifiee != null &&
                            projet.DateDebutPlanifiee < dateDebutPlanifiee || dateDebutPlanifiee == null)
                            dateDebutPlanifiee = projet.DateDebutPlanifiee;
                        if (projet.DateFinRelle != null &&
                            projet.DateFinRelle > dateFinPlanifiee || dateFinPlanifiee == null)
                            dateFinPlanifiee = projet.DateFinPlanifiee;
                    }
                }
            }
            SetDateDebutReelleMemeSiCestUnParent(dateDebutReel, bNotifierParent);
            if (bAllTermines)
                SetDateFinReelleMemeSiCestUnParent(dateFinReelle, bNotifierParent);
            if (DateDebutAuto)
            {
                SetDateDebutPlanifieeCalculeeMemeSiCestUnParent(dateDebutPlanifiee, bNotifierParent);
                SetDateFinPlanifieeCalculeeMemeSiCestUnParent(dateFinPlanifiee, bNotifierParent);
            }
        }




        //---------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sp"></param>
        /// <param name="duree"></param>
        /// <param name="mode"></param>
        /// <param name="bForceForThisElement">Indique que l'élément sur lequel on appelle
        /// la fonction est bougé quel que soit le mode de dépalcement</param>
        public void Move(TimeSpan sp, TimeSpan? duree, EModeDeplacementProjet mode, bool bForceForThisElement)
        {
            if (HasChilds() && !DateDebutAuto && bForceForThisElement)
            {
                if (DateDebutPlanifiee != null)
                {
                    DateDebutPlanifiee = DateDebutPlanifiee.Value.Add(sp);
                    if (duree == null)
                    {
                        if (DateFinPlanifiee != null)
                            DateFinPlanifiee = DateFinPlanifiee.Value.Add(sp);
                    }
                    else
                        DateFinPlanifiee = DateDebutPlanifiee.Value.Add(duree.Value);
                }
                return;
            }
            if (!DateDebutAuto && mode != EModeDeplacementProjet.MoveNonAuto && !bForceForThisElement)
                return;
            MoveWithChilds(sp, duree, mode, bForceForThisElement);
            RepercuteMoveSurContraintes(sp, duree);
            if (ProjetsFils.Count > 0)
            {
                UpdateDateFinPlanifieeCalculeeFromChilds();
                UpdateDateDebutPlanifieeCalculeeFromChilds();
            }
        }

        //---------------------------------------------------------------------
        public void FillDicSuccesseurs(HashSet<IElementDeProjetPlanifiable> dic)
        {
            if (Projet != null)
                Projet.FillDicSuccesseurs(dic);
            //Remplit la liste des successeurs
            foreach (CLienDeProjet lien in LiensEnTantQueProjetA)
            {
                if (!dic.Contains(lien.ElementB))
                {
                    dic.Add(lien.ElementB);
                    lien.ElementB.FillDicSuccesseurs(dic);
                }
            }
        }

        //---------------------------------------------------------------------
        /// <summary>
        /// retourne tous les projets prédécesseurs, récursivement
        /// </summary>
        [DynamicField("All predecessors")]
        public CProjet[] TousLesPredecesseurs
        {
            get
            {
                HashSet<IElementDeProjetPlanifiable> dicPredecesseurs = new HashSet<IElementDeProjetPlanifiable>();
                FillDicPredecesseurs(dicPredecesseurs);
                List<CProjet> lst = new List<CProjet>();
                foreach (IElementDeProjetPlanifiable elt in dicPredecesseurs)
                {
                    if (elt is CProjet)
                        lst.Add((CProjet)elt);
                }
                return lst.ToArray();
            }
        }

        //---------------------------------------------------------------------
        /// <summary>
        /// Retourne tous les projets feuille ( sans fils ) nécéssaire
        /// pour l'execution de ce projet.
        /// </summary>
        [DynamicField("All necessary leaf projects")]
        public CProjet[] ToutesLesFeuillesNecessaires
        {
            get
            {
                HashSet<CProjet> projets = new HashSet<CProjet>();
                HashSet<CProjet> projetsVus = new HashSet<CProjet>();
                projetsVus.Add(this);
                this.FillDicFeuillesNecessaires(projets, projetsVus);
                return projets.ToArray();
            }
        }

        //---------------------------------------------------------------------
        private void FillDicFeuillesNecessaires(HashSet<CProjet> projets, HashSet<CProjet> projetsVus)
        {
            if (HasChilds())
            {
                foreach (CProjet prj in ProjetsFils)
                {
                    if (!prj.HasChilds() && !projets.Contains(prj))
                        projets.Add(prj);
                    if (!projetsVus.Contains(prj))
                    {
                        projetsVus.Add(prj);
                        prj.FillDicFeuillesNecessaires(projets, projetsVus);
                    }
                }
            }
            foreach (CProjet prj in TousLesPredecesseurs)
            {
                if (!prj.HasChilds() && !projets.Contains(prj))
                    projets.Add(prj);
                if (!projetsVus.Contains(prj))
                {
                    projetsVus.Add(prj);
                    prj.FillDicFeuillesNecessaires(projets, projetsVus);
                }
            }
        }
        //---------------------------------------------------------------------
        public void FillDicPredecesseurs(HashSet<IElementDeProjetPlanifiable> dic)
        {
            if (Projet != null)
                Projet.FillDicPredecesseurs(dic);
            //Remplit la liste des prédecesseurs
            foreach (CLienDeProjet lien in LiensEnTantQueProjetB)
            {
                if (!dic.Contains(lien.ElementA))
                {
                    dic.Add(lien.ElementA);
                    lien.ElementA.FillDicPredecesseurs(dic);
                }
            }
        }

        //---------------------------------------------------------------------
        public IDefinisseurEvenements[] Definisseurs
        {
            get
            {
                HashSet<CTypeProjet> set = TousLesTypesDuProjet;
                List<IDefinisseurEvenements> lst = new List<IDefinisseurEvenements>();
                foreach (CTypeProjet type in set)
                    lst.Add(type);
                return lst.ToArray();
            }
        }

        //---------------------------------------------------------------------
        public bool IsDefiniPar(IDefinisseurEvenements definisseur)
        {
            if (definisseur is CTypeProjet)
                return TousLesTypesDuProjet.Contains((CTypeProjet)definisseur);
            return false;
        }


        //---------------------------------------------
        /// <summary>
        /// Donne la liste des contraintes propres au projet
        /// </summary>
        [RelationFille(typeof(CContrainteDeProjet), "Projet")]
        [DynamicChilds("Own Constraints", typeof(CContrainteDeProjet))]
        public CListeObjetsDonnees ContraintesPropres
        {
            get
            {
                return GetDependancesListe(CContrainteDeProjet.c_nomTable, c_champId);
            }
        }

        //--------------------------------------------------------------
        /// <summary>
        /// Retourne la liste de toutes les contraintes du projet,<br/>
        /// Contraintes propres et Contraintes induites par les Liens de Projet
        /// </summary>
        /// <returns></returns>
        [DynamicMethod("Get all the Project Constraints")]
        public IContrainteDeProjet[] GetAllConstraints()
        {
            List<IContrainteDeProjet> lstContraintes = new List<IContrainteDeProjet>();

            // Ajoute les contriantes propres
            foreach (IContrainteDeProjet contrainte in ContraintesPropres)
            {
                lstContraintes.Add(contrainte);
            }

            // Ajoute les contraintes induites par les Successeurs
            foreach (CLienDeProjet lien in LiensEnTantQueProjetA)
            {
                DateTime dateContrainte = lien.ProjetB.DateDebutGantt;
                if (lien.ProjetB.DateDebutReel != null)
                    dateContrainte = lien.ProjetB.DateDebutReel.Value;
                CModeContrainteDeGantt modeContrainte = new CModeContrainteDeGantt(EModeContrainteDeGantt.FinAuPlusTard);

                CContrainteDeProjetInduite contrainteInduite = new CContrainteDeProjetInduite(dateContrainte, modeContrainte);
                lstContraintes.Add(contrainteInduite);
            }

            // Ajoute les contraintes induites par les Predecesseurs
            foreach (CLienDeProjet lien in LiensEnTantQueProjetB)
            {
                DateTime dateContrainte = lien.ProjetA.DateFinGantt;
                if (lien.ProjetA.DateFinRelle != null)
                    dateContrainte = lien.ProjetA.DateFinRelle.Value;
                CModeContrainteDeGantt modeContrainte = new CModeContrainteDeGantt(EModeContrainteDeGantt.DebutAuPlusTot);

                CContrainteDeProjetInduite contrainteInduite = new CContrainteDeProjetInduite(dateContrainte, modeContrainte);
                lstContraintes.Add(contrainteInduite);
            }

            return lstContraintes.ToArray();
        }


        //----------------------------------------------------------------------
        /// <summary>
        /// Vérifie si le projet respecte ou non la contrainte passée en paramètre
        /// </summary>
        /// <param name="contrainte">La contrainte à vérifier</param>
        /// <returns>True si la contrainte est respectée, False dans le cas contraire</returns>
        [DynamicMethod("Check if the Project respect or not the specified constraint",
            "The Constraint to check")]
        public bool RespectConstraint(IContrainteDeProjet contrainte)
        {
            if (contrainte == null)
                return true;

            switch (contrainte.Mode.Code)
            {
                case EModeContrainteDeGantt.DebutAuPlusTot:
                    if (DateDebutGantt < contrainte.Date)
                        return false;
                    break;
                case EModeContrainteDeGantt.DebutAuPlusTard:
                    if (DateDebutGantt > contrainte.Date)
                        return false;
                    break;
                case EModeContrainteDeGantt.FinAuPlusTot:
                    if (DateFinGantt < contrainte.Date)
                        return false;
                    break;
                case EModeContrainteDeGantt.FinAuPlusTard:
                    if (DateFinGantt > contrainte.Date)
                        return false;
                    break;
                default:
                    break;
            }

            return true;
        }

        /// <summary>
        /// Déplace les projets fils par rapport à la date passée en paramètre,
        /// tout en respectant les contraintes entre ces projets
        /// </summary>
        /// <param name="minStartDate">Date</param>
        [DynamicMethod("Calculate the earliest date for project and sub project, respecting constraints",
            "Global start date")]
        public void OptimizeDates(DateTime minStartDate)
        {
            Stack<DateTime> stackMinDates = new Stack<DateTime>();
            if (!TypeProjet.TravaillerAvecLesHeures)
                minStartDate = minStartDate.Date;
            stackMinDates.Push(minStartDate);
            bool bHasMove;
            int nNbIterations = 100;
            do
            {
                bHasMove = false;
                OptimizeDates(stackMinDates, ref bHasMove);
                nNbIterations--;

            }
            while (bHasMove && nNbIterations > 0);
        }


        protected void OptimizeDates(Stack<DateTime> stackMinDates, ref bool bHasMove)
        {
            DateTime dateMin = stackMinDates.Peek();
            if (DateDebutAuto || HasChilds())
            {
                //Prend la date min parmi toutes les contraintes
                foreach (IContrainteDeProjet contrainte in GetAllConstraints())
                {
                    if (contrainte.Mode.Code == EModeContrainteDeGantt.DebutAuPlusTot &&
                        contrainte.Date > dateMin)
                        dateMin = contrainte.Date;
                }
            }
            else
                dateMin = DateDebutGantt;
            if (!HasChilds())
            {
                if (DateDebutReel == null && DateFinRelle == null)
                {
                    if (!TypeProjet.TravaillerAvecLesHeures)
                        dateMin = dateMin.Date;
                    if (dateMin != DateDebutGantt)
                    {
                        DateTime oldStart = DateDebutGantt;
                        MoveProject(dateMin, DureeEnHeure.Value, 0);
                        if (DateDebutGantt != oldStart)
                            bHasMove = true;
                    }
                }
            }
            else
            {
                if (!TypeProjet.TravaillerAvecLesHeures)
                    dateMin = dateMin.Date;
                stackMinDates.Push(dateMin);
                foreach (CProjet projetFils in ProjetsFils)
                {
                    projetFils.OptimizeDates(stackMinDates, ref bHasMove);
                }
                stackMinDates.Pop();
            }
        }

        /// <summary>
        /// Déplace les dépendances pour respecter les liens de projet
        /// </summary>
        [DynamicMethod("Move dependancies. Only automatic dependancies will be mode")]
        public void AutoMoveDependancies()
        {
            DateTime dtStart = DateDebutGantt;
            HashSet<IElementDeProjetPlanifiable> set = new HashSet<IElementDeProjetPlanifiable>();
            FillDicPredecesseurs(set);
            foreach (IElementDeProjetPlanifiable elt in set)
            {
                if (elt.DatesAuto)
                {
                    if (elt.DateFinGantt > dtStart)
                        elt.Move(dtStart - elt.DateFinGantt, null, EModeDeplacementProjet.MoveAutoOnly, true);
                }
            }

            DateTime dtFin = DateFinGantt;
            set.Clear();
            FillDicSuccesseurs(set);
            foreach (IElementDeProjetPlanifiable elt in set)
            {
                if (elt.DatesAuto)
                {
                    if (elt.DateDebutGantt < dtFin)
                        elt.Move(dtFin - elt.DateDebutGantt, null, EModeDeplacementProjet.MoveAutoOnly, true);
                }
            }
        }


        //-------------------------------------------------------------------
        /// <summary>
        /// Version des données directement associée au projet
        /// </summary>
        [Relation(
            CVersionDonnees.c_nomTable,
            CVersionDonnees.c_champId,
            CVersionDonnees.c_champId,
            false,
            true,
            false)]
        [DynamicField("Associated data version")]
        public CVersionDonnees VersionDonneesDirectementAssociee
        {
            get
            {
                return (CVersionDonnees)GetParent(CVersionDonnees.c_champId, typeof(CVersionDonnees));
            }
            set
            {
                SetParent(CVersionDonnees.c_champId, value);
            }
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// Version des données appliquée au projet.<br/>
        /// Supposons qu'un projet fils n'a pas de version directement associée<br/>
        /// et qu'un projet parent a une version directement associée;<br/>
        /// dans ce cas, la version appliquée pour ce projet fils est la<br/>
        /// version associée au projet parent.
        /// </summary>
        [DynamicField("Applied data version")]
        public CVersionDonnees VersionDonneesAppliquee
        {
            get
            {
                if (VersionDonneesDirectementAssociee != null)
                    return VersionDonneesDirectementAssociee;
                if (Projet != null)
                    return Projet.VersionDonneesAppliquee;
                return null;
            }
        }

        //-------------------------------------------------------------------
        private bool EstCeQueLesFilsOntDesVersions()
        {
            foreach (CProjet projet in ProjetsFils)
            {
                if (projet.VersionDonneesDirectementAssociee != null)
                    return true;
                if (projet.EstCeQueLesFilsOntDesVersions())
                    return true;
            }
            return false;
        }

        //-------------------------------------------------------------------
        public CResultAErreurType<CVersionDonnees> CreateDataVersionInCurrentContext()
        {
            //tente de créer une version de données.
            //Ce n'est possible que si les fils n'ont pas de version de données
            CResultAErreurType<CVersionDonnees> resultVersion = new CResultAErreurType<CVersionDonnees>();
            resultVersion.Result = true;
            if (VersionDonneesDirectementAssociee != null)
            {
                resultVersion.DataType = VersionDonneesDirectementAssociee;
                return resultVersion;
            }
            //vérifie que les fils n'ont pas de version de données
            if (EstCeQueLesFilsOntDesVersions())
            {
                resultVersion.EmpileErreur(I.T("You can not associate a data version to this project because some child projects have associated data version|20111"));
                return resultVersion;
            }
            CVersionDonnees versionParente = VersionDonneesAppliquee;
            if (TypeProjet.VersionSurReferentiel)
                versionParente = null;
            CVersionDonnees version = new CVersionDonnees(ContexteDonnee);
            version.CreateNewInCurrentContexte();
            version.Libelle = Libelle;
            version.CodeTypeVersion = (int)CTypeVersion.TypeVersion.Previsionnelle;
            version.VersionParente = versionParente;
            VersionDonneesDirectementAssociee = version;
            resultVersion.Data = version;
            return resultVersion;
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// Elément principal associé du référentiel, dans le cadre de la gestion de version<br/>
        /// couplée au projet; c'est à dire sur quel élément porte la gestion de version
        /// activée à partir du projet
        /// </summary>
        [DynamicField("Main associated element")]
        public object ElementAssociePrincipal
        {
            get
            {
                if (TypeProjet != null)
                {
                    C2iExpression formule = TypeProjet.FormuleElementAssocie;
                    CContexteEvaluationExpression ctx = new CContexteEvaluationExpression(this);
                    if (formule != null)
                    {
                        CResultAErreur result = formule.Eval(ctx);
                        if (result && result.Data != null)
                            return result.Data;
                    }
                }
                if (Projet != null)
                    return Projet.ElementAssociePrincipal;
                return null;
            }
        }


        //-------------------------------------------------------
        public CResultAErreurType<CFormulaire> FormulaireSpecifiquePourVersion
        {
            get
            {
                CResultAErreurType<CFormulaire> resFormulaire = new CResultAErreurType<CFormulaire>();
                if (TypeProjet != null)
                {
                    C2iExpression formule = TypeProjet.FormuleFormulaireVersion;
                    CContexteEvaluationExpression ctx = new CContexteEvaluationExpression(this);
                    if (formule != null)
                    {
                        CResultAErreur result = formule.Eval(ctx);
                        if (result && (result.Data is int || result.Data is CFormulaire))
                        {
                            CFormulaire formulaire = result.Data as CFormulaire;
                            if (formulaire == null && result.Data is int)
                            {
                                formulaire = new CFormulaire(ContexteDonnee);
                                if (!formulaire.ReadIfExists((int)result.Data))
                                    formulaire = null;
                            }
                            if (formulaire == null)
                                result.EmpileErreur(I.T("Projet type setup error on form formula. The formula result should be a form Id or a form|20183"));
                            resFormulaire.DataType = formulaire;
                        }
                        if (!result)
                            resFormulaire.EmpileErreur(result.Erreur);
                    }
                }
                return resFormulaire;
            }
        }


        //------------------------------------------------------------------------------
        /// <summary>
        /// Obtient, pour ce projet, la valeur du champ personnalisé associé,
        /// dont l'identifiant est passé en paramètre à la fonction
        /// </summary>
        /// <param name="nIdChamp">Identifiant (Id) du champ personnalisé</param>
        /// <returns>La valeur correspondante</returns>
        [DynamicMethod("Returns the Custom Field Value for the current Project",
            "Id of the Custom field")]
        public object GetValue(int nIdChamp)
        {
            // TESTDBKEYOK
            return GetValeurChamp(nIdChamp);
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// Définit, pour ce projet, la valeur du champ personnalisé associé,
        /// dont l'identifiant est passé en paramètre à la fonction
        /// </summary>
        /// <param name="nIdChamp">Identifiant (Id) du champ personnalisé</param>
        /// <param name="valeur">Valeur à définir</param>
        /// <returns>True si succès, False si échec</returns>
        [DynamicMethod("Defines the Custom Field Value for the current Project",
            "Id of the Custom field",
            "The Value to be stored")]
        public bool SetValue(int nIdChamp, object valeur)
        {
            // TESTDBKEYOK
            CResultAErreur result = SetValeurChamp(nIdChamp, valeur);

            return result.Result;
        }


        //-----------------------------------------------------------
        [DynamicMethod(
            "Asigne a new Organizational Entity to the Element",
            "The Organizational Entity Identifier")]
        public CResultAErreur AjouterEO(int nIdEO)
        {
            return CUtilElementAEO.AjouterEO(this, nIdEO);
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// Codes complets (Full_system_code) de toutes les <see cref="CEntiteOrganisationnelle">entités organisationnelles</see> auxquels est affecté l'équipement<br/>
        /// </summary>
        /// <remarks>
        /// Ces codes sont présentés sous la forme d'une chaîne de caractères<br/>
        /// Chaque code est encadré par deux caractères ~ (exemple : ~01051B~0201~061A0304~)
        /// </remarks>
        [TableFieldProperty(CUtilElementAEO.c_champEO, 500)]
        [DynamicField("Organisational entities codes")]
        public string CodesEntitesOrganisationnelles
        {
            get { return (string)Row[CUtilElementAEO.c_champEO]; }
            set { Row[CUtilElementAEO.c_champEO] = value; }
        }

        //-------------------------------------------------------------------
        public IElementAEO[] DonnateursEO
        {
            get
            {
                List<IElementAEO> lst = new List<IElementAEO>();
                if (TypeProjet != null)
                    lst.Add(TypeProjet);
                return lst.ToArray();
            }
        }

        //-------------------------------------------------------------------
        public CListeObjetsDonnees EntiteOrganisationnellesDirectementLiees
        {
            get { return CRelationElement_EO.GetEntitesOrganisationnellesDirectementLiees(this); }
        }

        //-------------------------------------------------------------------
        public IElementAEO[] HeritiersEO
        {
            get
            {
                return new IElementAEO[0];
            }
        }

        //-------------------------------------------------------------------
        [DynamicMethod(
            "Set all Organizational Entities to the Element",
            "An array of Organizational Entity IDs")]
        public CResultAErreur SetAllOrganizationalEntities(int[] nIdsOE)
        {
            return CUtilElementAEO.SetAllOrganizationalEntities(this, nIdsOE);
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// Remet à jour les codes des <see cref="CEntiteOrganisationnelle">entités organisationnelles</see> de cet équipement
        /// </summary>
        [DynamicMethod("Refresh Organizational entities codes for this element")]
        public void RefreshCodesEOS()
        {
            CUtilElementAEO.UpdateEOs(this);
        }

        //-------------------------------------------------------------------
        [DynamicMethod(
            "Remove an Organizational Entity from the Element",
            "The Organizational Entity Identifier")]
        public CResultAErreur SupprimerEO(int nIdEO)
        {
            return CUtilElementAEO.SupprimerEO(this, nIdEO);
        }

        //-------------------------------------------------------------------
        public void CompleteRestriction(CRestrictionUtilisateurSurType restriction)
        {
            CUtilElementAEO.CompleteRestriction(this, restriction);
            CUtilElementARestrictionsSpecifiques.CompleteRestriction(this, restriction);
        }


        //---------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [RelationFille(typeof(CRelationMetaProjet_Projet), "Projet")]
        [DynamicChilds("Meta project relations", typeof(CRelationMetaProjet_Projet))]
        public CListeObjetsDonnees RelationsMetaProjets
        {
            get
            {
                return GetDependancesListe(CRelationMetaProjet_Projet.c_nomTable, c_champId);
            }
        }



        #region IElementARestrictionsSpecifiques Membres
        //---------------------------------------------
        public List<CRelationElement_RestrictionSpecifique> ListeRestrictions
        {
            get { return CUtilElementARestrictionsSpecifiques.GetRelationsRestrictions(this); }
        }
        //---------------------------------------------
        public void AddRestrictionFor(CGroupeRestrictionSurType restriction, IElementDonnantDesRestrictions elementDonnantDesRestrictions)
        {
            CUtilElementARestrictionsSpecifiques.AddRestrictionForElementDonnantDesRestrictions(this, restriction, elementDonnantDesRestrictions);
        }


        //---------------------------------------------
        public void RemoveRestrictionFor(CGroupeRestrictionSurType restriction, IElementDonnantDesRestrictions elementDonnantDesRestrictions)
        {
            CUtilElementARestrictionsSpecifiques.RemoveRestrictionForElementDonnantDesRestrictions(this, restriction, elementDonnantDesRestrictions);
        }
        #endregion

        //---------------------------------------------
        /// <summary>
        /// Relations vers les sous types de ce projet
        /// </summary>
        [RelationFille(typeof(CProjet_SousType), "Projet")]
        [DynamicChilds("Sub types relations", typeof(CProjet_SousType))]
        public CListeObjetsDonnees RelationsSousTypes
        {
            get
            {
                return GetDependancesListe(CProjet_SousType.c_nomTable, c_champId);
            }
        }

        //---------------------------------------------
        [DynamicMethod("Add a sub type to the project", "Sub type")]
        public void AddSubType(CTypeProjet typeProjet)
        {
            if (typeProjet == null)
                return;
            CListeObjetsDonnees lst = RelationsSousTypes;
            lst.Filtre = new CFiltreData(CTypeProjet.c_champId + "=@1",
                typeProjet.Id);
            if (lst.Count == 0)
            {
                CProjet_SousType rel = new CProjet_SousType(ContexteDonnee);
                rel.CreateNewInCurrentContexte();
                rel.Projet = this;
                rel.SousType = typeProjet;
            }
        }

        //---------------------------------------------
        [DynamicMethod("Remove a sub type from a project", "Sub type")]
        public void RemoveSubType(CTypeProjet typeProjet)
        {
            if (typeProjet == null)
                return;
            CListeObjetsDonnees lst = RelationsSousTypes;
            lst.Filtre = new CFiltreData(CTypeProjet.c_champId + "=@1",
                typeProjet.Id);
            if (lst.Count > 0)
                CObjetDonneeAIdNumerique.Delete(lst, true);
        }

        //---------------------------------------------
        /// <summary>
        /// Liste des spécifications associées à ce projet
        /// </summary>
        [RelationFille(typeof(CPhaseSpecifications), "Projet")]
        [DynamicChilds("Specifications list", typeof(CPhaseSpecifications))]
        public CListeObjetsDonnees ListeSpecifications
        {
            get
            {
                return GetDependancesListe(CPhaseSpecifications.c_nomTable, c_champId);
            }
        }

        //---------------------------------------------
        [DynamicMethod("Create sub projects and needs from template",
            "specifcations template",
            "Default project type")]
        public void ApplySpecificationTemplate(
            CPhaseSpecifications phase,
            CTypeProjet defaultProjectType)
        {
            ApplyFilteredSpecificationTemplate(phase, defaultProjectType, null);
        }

        //---------------------------------------------
        [DynamicMethod("Create sub projects and needs from template",
            "specifcations template",
            "Default project type",
            "Needs id to implement")]
        public void ApplyFilteredSpecificationTemplate(
            CPhaseSpecifications phase,
            CTypeProjet defaultProjectType,
            IEnumerable besoinsAAppliquer)
        {

            List<int> lstIds = null;
            if (besoinsAAppliquer != null)
            {
                lstIds = new List<int>();
                CListeObjetsDonnees lstBesoins = phase.Besoins;
                foreach (object obj in besoinsAAppliquer)
                {
                    if (obj is int)
                    {
                        lstIds.Add((int)obj);
                    }
                    else if (obj is CBesoin)
                        lstIds.Add(((CBesoin)obj).Id);
                    else
                    {
                        if (obj != null)
                        {
                            string strCodeTemplate = obj.ToString();
                            //Trouve le besoins
                            lstBesoins.Filtre = new CFiltreData(CBesoin.c_champTemplateKey + " like @1",
                                strCodeTemplate.Trim());
                            if (lstBesoins.Count > 0)
                            {
                                HashSet<string> codesAjoutes = new HashSet<string>();
                                foreach (CBesoin b in lstBesoins)
                                {
                                    if (!codesAjoutes.Contains(b.SourceTemplateKey))
                                    {
                                        lstIds.Add(b.Id);
                                        codesAjoutes.Add(b.SourceTemplateKey);
                                    }
                                }
                            }
                            else
                                lstIds.Add(((CBesoin)lstBesoins[0]).Id);
                        }
                    }
                }
            }

            InternalApplyFilteredSpecificationTemplate(
                phase,
                defaultProjectType,
                lstIds != null ? lstIds.ToArray() : null);
        }


        //---------------------------------------------
        public void InternalApplyFilteredSpecificationTemplate(
            CPhaseSpecifications phase,
            CTypeProjet defaultProjectType,
            int[] nIdsBesoinsAAppliquer)
        {
            if (phase == null)
                return;

            CListeObjetsDonnees besoinsRacine = phase.Besoins;
            besoinsRacine.Filtre = new CFiltreData(CBesoin.c_champIdBesoinParent + " is null");
            Dictionary<CBesoin, CProjet> dicBesoinToProjet = new Dictionary<CBesoin, CProjet>();
            Dictionary<string, string> dicIdQuantitesOrgToNew = new Dictionary<string, string>();
            Dictionary<int, int> dicBesoinsOrgToNew = new Dictionary<int, int>();
            foreach (CBesoin besoin in besoinsRacine)
            {
                ApplyNeedTemplate(
                    DateDebutGantt,
                    besoin,
                    this,
                    null,
                    defaultProjectType,
                    dicBesoinToProjet,
                    dicIdQuantitesOrgToNew,
                    dicBesoinsOrgToNew,
                    nIdsBesoinsAAppliquer);
            }
            //Crée les dépendances entre les projets
            foreach (KeyValuePair<CBesoin, CProjet> kv in dicBesoinToProjet)
            {
                foreach (CBesoinDependance dep in kv.Key.LiensBesoinsDontJeDepend)
                {
                    if (dep.BesoinReference != null)
                    {
                        CProjet projetPred = null;
                        if (dicBesoinToProjet.TryGetValue(dep.BesoinReference, out projetPred))
                        {
                            if (projetPred != null)
                                kv.Value.AddPredecessor(projetPred);
                        }
                    }
                }
            }
            OptimizeDates(DateDebutGantt);
        }

        //---------------------------------------------
        private void ApplyNeedTemplate(
            DateTime startDate,
            CBesoin besoin,
            CProjet projetParent,
            CBesoin besoinParent,
            CTypeProjet defaultProjectType,
            Dictionary<CBesoin, CProjet> dicBesoinToProjet,
            Dictionary<string, string> dicIdQuantitesOrgToNew,
            Dictionary<int, int> dicBesoinsOrgToNew,
            int[] nIdsBesoinsAAppliquer)
        {
            CDonneeBesoinProjet donneeProjet = besoin.DonneeBesoin as CDonneeBesoinProjet;
            if (donneeProjet != null)
            {
                CProjet projet = new CProjet(ContexteDonnee);
                bool bExiste = false;
                if (donneeProjet.CleProjetTemplate.Trim().Length > 0 && projetParent != null)
                {
                    //Cherche s'il y a un projet fils avec cette clé
                    CListeObjetsDonnees projetsFils = projetParent.ProjetsFils;
                    projetsFils.Filtre = new CFiltreData(CProjet.c_champProjectTemplateKey + "=@1",
                        donneeProjet.CleProjetTemplate);
                    if (projetsFils.Count > 0)
                    {
                        projet = (CProjet)projetsFils[0];
                        bExiste = true;
                    }
                }
                if (!bExiste)
                {
                    if (nIdsBesoinsAAppliquer == null ||
                        nIdsBesoinsAAppliquer.Contains(besoin.Id))
                    {
                        projet.CreateNewInCurrentContexte();
                        projet.Libelle = besoin.Libelle;
                        projet.SourceTemplateKey = donneeProjet.CleProjetTemplate;
                        projet.Projet = projetParent;
                        projet.ModeCalculDatesParentes = ModeCalculDatesParentes;
                        projet.DateDebutPlanifiee = startDate;
                        projet.DateFinPlanifiee = startDate.AddDays(donneeProjet.DureeJours);
                        CTypeProjet typeProjet = donneeProjet.GetTypeProjet(ContexteDonnee);
                        projet.TypeProjet = typeProjet == null ? defaultProjectType : typeProjet;
                        if (donneeProjet.FormuleInitialisation != null)
                        {
                            CContexteEvaluationExpression ctx = new CContexteEvaluationExpression(projet);
                            donneeProjet.FormuleInitialisation.Eval(ctx);
                        }
                    }
                    else
                        projet = null;
                }
                projetParent = projet;
                besoinParent = null;
                if (projet != null)
                    dicBesoinToProjet[besoin] = projet;
            }
            else
            {
                if (projetParent.IsNew())
                {
                    if (nIdsBesoinsAAppliquer == null ||
                        nIdsBesoinsAAppliquer.Contains(besoin.Id))
                    {
                        CPhaseSpecifications spec = projetParent.GetOrCreateSpecifications();
                        CBesoin newBesoin = new CBesoin(ContexteDonnee);
                        newBesoin.PhaseSpecifications = spec;
                        newBesoin.BesoinParent = besoinParent;
                        newBesoin.CopyFromTemplate(besoin, dicIdQuantitesOrgToNew, dicBesoinsOrgToNew);
                        besoinParent = newBesoin;
                    }
                }
            }
            if (projetParent != null)
            {
                foreach (CBesoin child in besoin.BesoinsFils)
                    ApplyNeedTemplate(
                        startDate,
                        child,
                        projetParent,
                        besoinParent,
                        defaultProjectType,
                        dicBesoinToProjet,
                        dicIdQuantitesOrgToNew,
                        dicBesoinsOrgToNew,
                        nIdsBesoinsAAppliquer);
            }
        }



        //---------------------------------------------
        [DynamicField("Specifications")]
        public CPhaseSpecifications Specifications
        {
            get
            {
                CListeObjetsDonnees lst = ListeSpecifications;
                if (lst.Count > 0)
                    return lst[0] as CPhaseSpecifications;
                if (IsNewInThisContexte())
                {
                    CPhaseSpecifications phase = new CPhaseSpecifications(ContexteDonnee);
                    phase.CreateNewInCurrentContexte();
                    phase.Projet = this;
                    return phase;
                }
                return null;
            }
        }

        //---------------------------------------------
        [DynamicMethod("Get specifications and create it if it doesn't exists")]
        public CPhaseSpecifications GetOrCreateSpecifications()
        {
            CPhaseSpecifications phase = Specifications;
            if (phase == null)
            {
                phase = new CPhaseSpecifications(ContexteDonnee);
                phase.CreateNewInCurrentContexte();
                phase.Projet = this;
            }
            return phase;
        }

        #region ISatisfactionBesoin Membres
        /// <summary>
        /// Libellé du projet en tant que satisfaction de besoin
        /// </summary>
        [DynamicField("Satisfaction label")]
        public string LibelleSatisfactionComplet
        {
            get { return I.T("Project @1|20170", Libelle); }
        }

        /// <summary>
        /// Liste des besoins satisfaits par ce projet
        /// </summary>
        [DynamicChilds("Satisfied needs", typeof(CBesoin))]
        public CBesoin[] BesoinsSolutionnes
        {
            get { return CRelationBesoin_Satisfaction.GetBesoinsSatisfaits(this).ToList<CBesoin>().ToArray(); }
        }

        /// <summary>
        /// Relations aux besoins satisfaits par ce projet
        /// </summary>
        [DynamicChilds("Satisfied needs relations", typeof(CRelationBesoin_Satisfaction))]
        public CListeObjetsDonnees RelationsSatisfaits
        {
            get { return CRelationBesoin_Satisfaction.GetRelationsBesoinsSatisfaits(this); }
        }



        //-------------------------------------------------------------------------------------
        public bool CanSatisfaire(CBesoin besoin)
        {
            return true;
        }

        //-------------------------------------------------------------------------------------
        public CObjetDonneeAIdNumerique ObjetPourEditionElementACout
        {
            get { return this; }
        }

        //-------------------------------------------------------------------------------------
        [DynamicMethod("Returns true if satisfaction is a direct satisfaction to the need")]
        public bool IsDirectSatisfactionFor(CBesoin besoin)
        {
            return CUtilSatisfaction.IsDirectSatisfactionFor(this, besoin);
        }


        //-------------------------------------------------------------------------------------
        [DynamicMethod("Returns true if satisfaction is a direct or indirect satisfaction to the need")]
        public bool IsRecursiveSatisfactionFor(CBesoin besoin)
        {
            return CUtilSatisfaction.IsRecursiveSatisfactionFor(this, besoin);
        }

        #endregion

        #region ISatisfactionBesoinAvecSousBesoins Membres


        //---------------------------------------------
        public CBesoin[] GetSousBesoinsDeSatisfaction()
        {
            List<CBesoin> lstBesoins = new List<CBesoin>();
            FillListBesoinsAvecSousProjets(lstBesoins);
            return lstBesoins.ToArray();
        }

        //---------------------------------------------
        public CBesoin[] GetSousBesoinsDeSatisfactionDirects()
        {
            if (Specifications != null)
                return Specifications.GetSousBesoinsDeSatisfaction();
            return new CBesoin[0];
        }

        //---------------------------------------------
        public ISatisfactionBesoin[] GetSousSatisfactions()
        {
            List<ISatisfactionBesoin> lst = new List<ISatisfactionBesoin>();
            foreach (CProjet projet in ProjetsFils)
                lst.Add(projet);
            return lst.ToArray();
        }


        //---------------------------------------------
        public void FillListBesoinsAvecSousProjets(List<CBesoin> besoins)
        {
            if (Specifications != null)
            {
                foreach (CBesoin besoin in Specifications.GetSousBesoinsDeSatisfaction())
                    besoins.Add(besoin);
            }
            foreach (CProjet fils in ProjetsFils)
                fils.FillListBesoinsAvecSousProjets(besoins);
        }

        //---------------------------------------------
        public void FillSetBesoins(HashSet<CBesoin> setBesoins, HashSet<ISatisfactionBesoinAvecSousBesoins> setSousElementsFaits)
        {
            if (setSousElementsFaits.Contains(this))
                return;
            setSousElementsFaits.Add(this);
            foreach (CBesoin b in GetSousBesoinsDeSatisfaction())
            {
                b.FillSetBesoins(setBesoins, setSousElementsFaits);
            }

        }

        //---------------------------------------------
        /// <summary>
        /// Retourne toutes les satisfactions liées à cette satisfaction, y compris elle même
        /// </summary>
        /// <returns></returns>
        [DynamicMethod("Returns all satisfactions linked to this satisfaction, including itself")]
        public ISatisfactionBesoin[] GetFlattenSatisfactionsHierarchy()
        {
            return CUtilSatisfaction.GetFlattenSatisfactionsHierarchy(this);
        }


        //---------------------------------------------
        /// <summary>
        /// Cout estimé du projet.
        /// </summary>
        /// <remarks>
        /// <H1>Méthode de calcul du coût estimé d'un projet :</H1>
        /// Si les spécifications du projet ne satisfont aucun besoin, le cout du projet intègre le cout de la spécification.<BR></BR>
        /// Par ailleurs, un projet parent intègre le cout de chacun de ses projets fils qui ne satisfait pas de besoin
        /// </remarks>
        [TableFieldProperty(c_champCoutPrevisionnel)]
        [DynamicField("Estimated cost")]
        public double CoutPrevisionnel
        {
            get
            {
                return (double)Row[c_champCoutPrevisionnel];
            }
        }

        //---------------------------------------------
        /// <summary>
        /// Cout réel du projet.
        /// </summary>
        /// <remarks>
        /// <H1>Méthode de calcul du coût réel d'un projet :</H1>
        /// Si les spécifications du projet ne satisfont aucun besoin, le cout du projet intègre le cout de la spécification.<BR></BR>
        /// Par ailleurs, un projet parent intègre le cout de chacun de ses projets fils qui ne satisfait pas de besoin
        /// </remarks>
        [TableFieldProperty(c_champCoutReel)]
        [DynamicField("Actual cost")]
        public double CoutReel
        {
            get
            {
                return (double)Row[c_champCoutReel];
            }
        }

        //---------------------------------------------
        [TableFieldProperty(CUtilElementACout.c_champImputationsVersUtilisateurs, 1024)]
        public string ImputationsSurUtilisateursString
        {
            get
            {
                return (string)Row[CUtilElementACout.c_champImputationsVersUtilisateurs];
            }
            set
            {
                Row[CUtilElementACout.c_champImputationsVersUtilisateurs] = value;
            }
        }

        //---------------------------------------------
        [TableFieldProperty(CUtilElementACout.c_champImputationsParLesSources, 1024)]
        public string ImputationsDeSourcesString
        {
            get
            {
                return (string)Row[CUtilElementACout.c_champImputationsParLesSources];
            }
            set
            {
                Row[CUtilElementACout.c_champImputationsParLesSources] = value;
            }
        }

        //---------------------------------------------
        public double CalcImputationAFaireSur(IElementACout elementACout, bool bCoutReel)
        {
            if (elementACout == null || elementACout.Row.RowState == DataRowState.Deleted)
                return 0;
            CBesoin besoin = elementACout as CBesoin;
            if (besoin != null)
                return CUtilElementACout.CalcImputationAFaireSur(this, besoin, bCoutReel);
            return 0;
        }

        //---------------------------------------------
        public void SetCoutSansCalculDesParents(double fValeur, bool bCoutReel)
        {
            if (bCoutReel)
                Row[c_champCoutReel] = fValeur;
            else
                Row[c_champCoutPrevisionnel] = fValeur;
        }

        //---------------------------------------------
        public void SetCoutAvecCalculDesParents(double fValeur, bool bCoutReel)
        {
            SetCoutSansCalculDesParents(fValeur, bCoutReel);
            CUtilElementACout.OnChangeCout(this, bCoutReel, false);
        }

        //---------------------------------------------
        public bool IsCoutFromSources(bool bCoutReel)
        {
            return true;
        }

        //---------------------------------------------
        /// <summary>
        /// Indique les types de couts parents à recalculer
        /// </summary>
        [TableFieldProperty(CUtilElementACout.c_champCoutsParentsARecalculer, IsInDb = false)]
        public ETypeCout TypesCoutsParentsARecalculer
        {
            get
            {
                if (Row[CUtilElementACout.c_champCoutsParentsARecalculer] == DBNull.Value)
                    return ETypeCout.Aucun;
                return (ETypeCout)Row[CUtilElementACout.c_champCoutsParentsARecalculer];
            }
            set
            {
                Row[CUtilElementACout.c_champCoutsParentsARecalculer] = value;
            }
        }

        //---------------------------------------------
        public double CalculeTonCoutPuisqueTuNeCalculePasAPartirDesSourcesDeCout(bool bCoutReel)
        {
            //Sisi, on calcule à partir des sources de coût
            return 0;
        }

        //--------------------------------------------------------------
        public bool ShouldAjouterCoutPropreAuCoutDesSource(bool bCoutReel)
        {
            return false;
        }




        //---------------------------------------------
        public CImputationsCouts GetImputationsAFaireSurUtilisateursDeCout()
        {
            CImputationsCouts imputations = new CImputationsCouts(this);

            foreach (CRelationBesoin_Satisfaction rel in RelationsSatisfaits)
            {
                imputations.AddImputation(rel.Besoin, rel.RatioCoutReelApplique, rel);
            }
            if (Projet != null)
                imputations.AddImputation(Projet, imputations.PoidsTotal == 0 ? 1 : 0, null);
            return imputations;

        }

        //---------------------------------------------
        [DynamicMethod("Force system to calculate estimated cost for this element and its sub elements")]
        public double RecalcEstimatedCost()
        {
            return RecalcEstimatedCost(null);
        }

        //---------------------------------------------
        [DynamicMethod("Force system to calculate actual cost for this element and its sub elements")]
        public double RecalcActualCost()
        {
            return RecalcActualCost(null);
        }

        //---------------------------------------------
        public double RecalcEstimatedCost(IIndicateurProgression indicateur)
        {
            CUtilElementACout.RecalculeCoutDescendant(this, false, true, indicateur);
            return CoutPrevisionnel;
        }

        //---------------------------------------------
        public double RecalcActualCost(IIndicateurProgression indicateur)
        {
            CUtilElementACout.RecalculeCoutDescendant(this, true, true, indicateur);
            return CoutReel;
        }

        //---------------------------------------------
        public IElementACout[] GetSourcesDeCout(bool bCoutReel)
        {
            HashSet<IElementACout> set = new HashSet<IElementACout>();
            if (Specifications != null)
                set.Add(Specifications);
            foreach (CProjet fils in ProjetsFils)
                set.Add(fils);
            return set.ToArray();
        }

        #endregion


        #region IResumeurDeCouts Membres

        public double GetCoutResume(bool bCoutReel)
        {
            Dictionary<IElementACout, bool> setElementToAPrendreEnCompte = new Dictionary<IElementACout, bool>();
            FillHashetElementsPourResume(bCoutReel, setElementToAPrendreEnCompte);
            Dictionary<IElementACout, CImputationsCouts> cacheImputations = new Dictionary<IElementACout, CImputationsCouts>();
            //On a tous les besoins dans un hashet, maintenant, il faut sommer les couts
            double fCout = 0;
            foreach (KeyValuePair<IElementACout, bool> kv in setElementToAPrendreEnCompte)
            {
                IElementACout element = kv.Key;
                if (kv.Value)
                {

                    if (element is CBesoin)
                    {
                        bool bSourceInSet = false;
                        foreach (IElementACout elt in element.GetSourcesDeCout(bCoutReel))
                        {
                            if (setElementToAPrendreEnCompte.ContainsKey(elt))
                            {
                                bSourceInSet = true;
                                break;
                            }
                        }
                        if (!bSourceInSet)
                            fCout += bCoutReel ? element.CoutReel : element.CoutPrevisionnel;
                        else
                        {
                            foreach (IElementACout source in element.GetSourcesDeCout(bCoutReel))
                            {
                                if (!setElementToAPrendreEnCompte.ContainsKey(source))
                                //Si la source est dans le set, elle sera ajoutée, donc on ne la prend pas
                                {
                                    CImputationsCouts imputations = null;
                                    if (!cacheImputations.TryGetValue(source, out imputations))
                                    {
                                        imputations = source.GetImputationsAFaireSurUtilisateursDeCout();
                                        cacheImputations[source] = imputations;
                                    }

                                    fCout += imputations.GetCoutImputéeA(element, bCoutReel);
                                }
                            }
                        }
                    }
                }
            }
            return fCout;
        }

        private void FillHashetElementsPourResume(bool bCoutReel, Dictionary<IElementACout, bool> dicElementToAPrendreEnCompte)
        {
            if (Specifications != null)
            {
                Specifications.FillSetElementsACoutPourResumeCout(bCoutReel, dicElementToAPrendreEnCompte);
            }
            foreach (CProjet fils in ProjetsFils)
            {
                dicElementToAPrendreEnCompte[fils] = false;
                fils.FillHashetElementsPourResume(bCoutReel, dicElementToAPrendreEnCompte);
            }
        }

        #endregion

        [DynamicMethod("Links workflow to the projet and tries to adjust workflow state to project state",
            "Workflow to link",
            "Step type Key to link",
            "Start workflows if project is started and not ended")]
        public bool LinkToWorkflowStep(CWorkflow workflow, string strIdTypeEtape, bool bSynchronizeStarts)
        {
            if (workflow == null)
                return false;
            workflow = ContexteDonnee.GetObjetInThisContexte(workflow) as CWorkflow;
            CResultAErreur result = CGestionnaireProjetsDeWorkflow.LinkProjetToWorkflowStep(
                this, workflow, strIdTypeEtape, bSynchronizeStarts);
            return result.Result;
        }


        [DynamicMethod("Returns all children projects with specified template key",
            "Source template key")]
        public CProjet[] FindChildrenForTemplateKey ( string strTemplateKey, bool bRecursive )
        {
            List<CProjet> lst = new List<CProjet>();
            List<CProjet> lstFils = new List<CProjet>();
            if (bRecursive)
                lstFils.AddRange(TousLesProjetsFils);
            else
                lstFils.AddRange(ProjetsFils.ToArray<CProjet>());
            foreach ( CProjet projet in lstFils )
            {
                if (projet.SourceTemplateKey == strTemplateKey)
                    lst.Add(projet);
            }
            return lst.ToArray();
        }
    }
}
