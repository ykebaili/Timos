using System;
using System.Collections;
using System.Data;
using System.IO;

using sc2i.data;
using sc2i.data.dynamic;
using sc2i.common;
using System.Collections.Generic;
using timos.securite;
using sc2i.expression;

namespace timos.data.projet
{
    /// <summary>
    /// Un méta projet est un regroupement semi-dynamique de projet. 
    /// <BR>
    /// </BR>
    /// Chaque Meta projet contient une liste de projets qui le composent et
    /// permet de travailler directement via un diagramme de Gantt dans ces
    /// projets liés.
    /// </summary>
    /// <remarks>
    /// Les projets sont associés aux méta projet de deux manières
    /// <LI>Manuellement : l'utilisateur ajoute manuellement un ou
    /// plusieurs projets au meta projet</LI>
    /// <LI>Semi-automatiquement : sur le méta projet, l'utilisateur indique
    /// un filtre, qui permet d'ajouter dynamiquement des projets dans le
    /// meta projet. </LI>
    /// Dans le cas de l'ajout semi-automatique, il est nécéssaire de 'rafraichir' la
    /// liste des projets contenus lorsqu'il y a des changements
    /// dans les projets.
    /// </remarks>
    [AutoExec("Autoexec")]
    [DynamicClass("Meta project")]
    [ObjetServeurURI("CMetaProjetServeur")]
    [Table(CMetaProjet.c_nomTable, CMetaProjet.c_champId, true, IsGrandVolume = true)]
    [FullTableSync]
    public class CMetaProjet : CObjetHierarchique, IElementAEO,
        IObjetDonneeAChamps
    {
        public const string c_roleChampCustom = "METAPROJECT";

        #region Déclaration des constantes
        public const string c_nomTable = "META_PROJECT";
        public const string c_champId = "MEPRJ_ID";
        public const string c_champLibelle = "MEPRJ_LABEL";
        public const string c_champCommentaires = "MEPRJ_COMMENT";
        public const string c_champDataFiltre = "MEPRJ_FILTER";
        public const string c_champMetaParentId = "MEPRJ_PARENT_ID";
        public const string c_champCodeSystemeComplet = "MEPRJ_FULL_SYSTEM_CODE";
        public const string c_champCodeSystemePartiel = "MEPRJ_SYSTEM_CODE";
        public const string c_champNiveau = "MEPRJ_LEVEL";

        public const string c_champDateDebutPlanifiee = "MEPRJ_START";
        public const string c_champDateFinPlanifiee = "MEPRJ_PLAN_END";
        public const string c_champDateDebutReelle = "MEPRJ_TRUE_START";
        public const string c_champDateFinReelle = "MEPRJ_TRUE_END";
        public const string c_champAsynchronousUpdate = "MEPRJ_ASYNC_UPDATE";
        public const string c_champHideChildProjects = "MEPRJ_HIDE_CHILD_PROJECTS";

        public const string c_champPctAvancement = "MEPRJ_PROGRESS";
        public const string c_champPoidsFils = "MEPRJ__SUM_CHLD_WGT";
        public const string c_champAvancementsFils = "MEPRJ__SUM_CHLD_AVT";

        public const string c_champTableDernieresDatesConnues = "MEPRJ_CACHE_DATES_CHILDS";
        #endregion



        //-------------------------------------------------------------------
#if PDA
		public CMetaProjet()
			:base()
		{
		}
#endif
        //-------------------------------------------------------------------
        public CMetaProjet(CContexteDonnee ctx)
            : base(ctx)
        {
        }
        //-------------------------------------------------------------------
        public CMetaProjet(System.Data.DataRow row)
            : base(row)
        {
        }

        //-------------------------------------------------------------------
        public static void Autoexec()
        {
            CRoleChampCustom.RegisterRole(c_roleChampCustom, I.T("Meta project|20137"),
                typeof(CMetaProjet),
                typeof(CTypeMetaProjet));
        }

        //-------------------------------------------------------------------
        protected override void MyInitValeurDefaut()
        {
            base.MyInitValeurDefaut();
            DateDebutPlanifiee = DateTime.Now;
            DateFinPlanifiee = DateTime.Now;
            ModeUpdateAsynchrone = false;
        }
        //-------------------------------------------------------------------
        public override string[] GetChampsTriParDefaut()
        {
            return new string[] { c_champLibelle };
        }
        //-------------------------------------------------------------------
        public override string DescriptionElement
        {
            get
            {
                return I.T("Meta project @1|20134", Libelle);
            }
        }
        //-------------------------------------------------------------------
        /// <summary>
        /// Libellé du méta projet
        /// </summary>
        [
        TableFieldProperty(c_champLibelle, 255),
        DynamicField("Label")
        ]
        [DescriptionField]
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

        //-------------------------------------------------------------------
        [TableFieldProperty(c_champDateDebutPlanifiee)]
        [DynamicField("Planned Start date")]
        public DateTime DateDebutPlanifiee
        {
            get
            {
                return Row.Get<DateTime>(c_champDateDebutPlanifiee);
            }
            set
            {
                Row[c_champDateDebutPlanifiee] = value;
            }
        }

        //-------------------------------------------------------------------
        [TableFieldProperty(c_champHideChildProjects)]
        [DynamicField("Hide childs projects")]
        public bool HideChildProjects
        {
            get
            {
                return Row.Get<bool>(c_champHideChildProjects);
            }
            set
            {
                Row[c_champHideChildProjects] = value;
            }
        }

        //-------------------------------------------------------------------
        [TableFieldProperty(c_champDateFinPlanifiee)]
        [DynamicField("Planned End date")]
        public DateTime DateFinPlanifiee
        {
            get
            {
                return Row.Get<DateTime>(c_champDateFinPlanifiee);
            }
            set
            {
                Row[c_champDateFinPlanifiee] = value;
            }
        }

        //-------------------------------------------------------------------
        [TableFieldProperty(c_champDateDebutReelle, true)]
        [DynamicField("True Start date")]
        public DateTime? DateDebutReelle
        {
            get
            {
                return Row.Get<DateTime?>(c_champDateDebutReelle);
            }
            set
            {
                Row[c_champDateDebutReelle, true] = value;
            }
        }

        //-------------------------------------------------------------------
        [TableFieldProperty(c_champDateFinReelle, true)]
        [DynamicField("True End date")]
        public DateTime? DateFinReelle
        {
            get
            {
                return Row.Get<DateTime?>(c_champDateFinReelle);
            }
            set
            {
                Row[c_champDateFinReelle, true] = value;
            }
        }

        /// <summary>
        /// Si true, les dates, la progression et le poids du méta-projet sont recalculés de 
        /// manière astynchrone.
        /// </summary>
        /// <remarks>
        /// Cette option est utilisée pour les méta-projets possédant de nombreux projets fils. <BR></BR>
        /// En effet, lors de la mise à jour d'un projet fils, les données du méta-projet parent sont mises à jour. Si deux projets fils
        /// d'un méta-projet sont mis à jour en même temps sur deux postes différents, le méta-projet parent est modifié par les deux et un risque
        /// d'accès conccurentiel à la base de donnée est présent. Pour éviter ce problème, le mode asynchrone active le mode "Multi utilisateurs"
        /// sur le méta-projet.
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

        //-------------------------------------------------------------------
        /// <summary>
        /// Commentaires ou descriptif de ce meta projet
        /// </summary>
        [
        TableFieldProperty(c_champCommentaires, 1024),
        DynamicField("Commentaires")
        ]
        public string Commentaires
        {
            get
            {
                return (string)Row[c_champCommentaires];
            }
            set
            {
                Row[c_champCommentaires] = value;
            }
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [Relation(
            CTypeMetaProjet.c_nomTable,
            CTypeMetaProjet.c_champId,
            CTypeMetaProjet.c_champId,
            false,
            false,
            false)]
        [DynamicField("Meta project type")]
        public CTypeMetaProjet TypeMetaProjet
        {
            get
            {
                return (CTypeMetaProjet)GetParent(CTypeMetaProjet.c_champId, typeof(CTypeMetaProjet));
            }
            set
            {
                SetParent(CTypeMetaProjet.c_champId, value);
            }
        }






        //-------------------------------------------------------------------
        /// <summary>
        /// Relations vers les projets liés (qu'ils soient liés
        /// automatiquement ou manuellement)
        /// </summary>
        [RelationFille(typeof(CRelationMetaProjet_Projet), "MetaProjet")]
        [DynamicChilds("Projects links", typeof(CRelationMetaProjet_Projet))]
        public CListeObjetsDonnees RelationsProjets
        {
            get
            {
                return GetDependancesListe(CRelationMetaProjet_Projet.c_nomTable, c_champId);
            }
        }

        /// <summary>
        /// Pourcentage d'avancement du meta projet.
        /// La formule de calcul est la suivante :
        /// (PS0 * P0 + PS1 * P1 + ... + PSn * Pn)/(P0 + P1 + ... + Pn)
        /// où PSn est le projet feuille d'indice n et Pn le poids attribué à ce même projet.
        /// Sont pris en considération, tous les projets feuilles liés à ce projet,
        /// quelque soit leur niveau dans la hiérarchie des projets liés.
        /// </summary>
        [TableFieldProperty(c_champPctAvancement)]
        [DynamicField("Progress status")]
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
        /// recalcule la progression du projet, récursivement ou non en fonction de la valeur passée en paramètre
        /// </summary>
        /// <param name="bRecursive">True pour récursivité, False sinon</param>
        /// <returns>La progression calculée</returns>
        [DynamicMethod("Calc progress", "true for recursive calculation")]
        public double CalcProgress(bool bRecursive)
        {
            double fAvancement = 0;
            if (RelationsProjets.Count != 0)
            {
                double fPoids = 0;
                RelationsProjets.ReadDependances("Projet");
                foreach (CRelationMetaProjet_Projet rel in RelationsProjets)
                {
                    CProjet projetFils = rel.Projet;
                    if (projetFils != null)
                    {
                        if (bRecursive)
                            projetFils.CalcProgress(true);
                        fAvancement += projetFils.PctAvancement * projetFils.Poids;
                        fPoids += projetFils.Poids;
                    }
                }
                Row[c_champAvancementsFils] = fAvancement;
                Row[c_champPoidsFils] = fPoids;
                if (fPoids != 0)
                    fAvancement /= fPoids;
            }

            PctAvancement = fAvancement;
            return fAvancement;
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

            double fAvancement = SommeAvancementFils.Value;
            double fPoids = SommePoidsDesFils.Value;
            List<CRelationMetaProjet_Projet> lst = RelationsProjets.ToList<CRelationMetaProjet_Projet>();
            foreach (CRelationMetaProjet_Projet rel in lst)
            {
                CProjet prj = rel.Projet;
                if (prj.Row.RowState != DataRowState.Unchanged)
                {
                    if (prj.Row.HasVersion(DataRowVersion.Original))
                    {
                        double fPds = (double)prj.Row[CProjet.c_champPoids, DataRowVersion.Original];
                        double fAvt = (double)prj.Row[CProjet.c_champAvancementsFils, DataRowVersion.Original];
                        fPoids -= fPds;
                        fAvancement -= fPds * fAvancement;
                    }
                    if (prj.Row.HasVersion(DataRowVersion.Current))
                    {
                        double fPds = (double)prj.Row[CProjet.c_champPoids];
                        double fAvt = (double)prj.Row[CProjet.c_champAvancementsFils];
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

        //-------------------------------------------------------------------------
        public IElementAVariablesDynamiques GetElementAVariableSourceFromType()
        {
            CElementAVariablesDynamiques elt = CElementAVariablesDynamiques.GetElementAUneVariableType(typeof(CProjet), DynamicClassAttribute.GetNomConvivial(typeof(CProjet)));
            return elt;
        }



        /// /////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champDataFiltre, NullAutorise = true)]
        public CDonneeBinaireInRow DataFiltre
        {
            get
            {
                if (Row[c_champDataFiltre] == DBNull.Value)
                {
                    CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession, Row, c_champDataFiltre);
                    CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champDataFiltre, donnee);
                }
                return ((CDonneeBinaireInRow)Row[c_champDataFiltre]).GetSafeForRow(Row.Row);
            }
            set
            {
                Row[c_champDataFiltre] = value;
            }
        }

        /// /////////////////////////////////////////////////////////////
        [BlobDecoder]
        public CFiltreDynamique FiltreDynamique
        {
            get
            {
                CFiltreDynamique retour = null;
                if (DataFiltre.Donnees != null)
                {
                    MemoryStream stream = new MemoryStream(DataFiltre.Donnees);
                    BinaryReader reader = new BinaryReader(stream);
                    CSerializerReadBinaire serializer = new CSerializerReadBinaire(reader);
                    I2iSerializable objet = null;
                    CResultAErreur result = serializer.TraiteObject(ref objet);
                    if (result)
                    {
                        retour = (CFiltreDynamique)objet;
                    }

                    reader.Close();
                    stream.Close();
                }

                return retour;
            }
            set
            {
                if (value == null)
                {
                    CDonneeBinaireInRow data = DataFiltre;
                    data.Donnees = null;
                    DataFiltre = data;
                }
                else
                {

                    MemoryStream stream = new MemoryStream();
                    BinaryWriter writer = new BinaryWriter(stream);
                    CSerializerSaveBinaire serializer = new CSerializerSaveBinaire(writer);
                    I2iSerializable objet = value;
                    CResultAErreur result = serializer.TraiteObject(ref objet);
                    if (result)
                    {
                        CDonneeBinaireInRow data = DataFiltre;
                        data.Donnees = stream.GetBuffer();
                        DataFiltre = data;
                    }

                    writer.Close();
                    stream.Close();
                }
            }
        }

        [DynamicMethod("Refresh project list from filter")]
        public void RefreshProjectsList()
        {
            //Calcule le filtre
            try
            {
                CFiltreDynamique filtreDyn = FiltreDynamique;
                if (filtreDyn != null)
                {
                    CResultAErreur result = filtreDyn.GetFiltreData();
                    if (result)
                    {
                        //Supprime les éléments automatiques
                        CListeObjetsDonnees lstToDelete = RelationsProjets;
                        lstToDelete.Filtre = new CFiltreData(CRelationMetaProjet_Projet.c_champIsAutoAdded + "=@1",
                            true);
                        CObjetDonneeAIdNumerique.Delete(lstToDelete, true);

                        if (result.Data is CFiltreData)
                        {
                            CListeObjetsDonnees liste = new CListeObjetsDonnees(ContexteDonnee, typeof(CProjet));
                            liste.Filtre = (CFiltreData)result.Data;

                            foreach (CProjet prj in liste.ToArrayList())
                            {
                                AssocieProjet(prj, true);
                            }
                        }
                        UpdateDateDebutPlanifieeFromChilds(false);
                        UpdateDateFinPlanifieeFromChilds(false);
                        UpdateProgress();
                    }
                }
            }
            catch { }
        }

        //-------------------------------------------------------------------
        public void AssocieProjet(CProjet projet, bool bAutoAdded)
        {
            CListeObjetsDonnees rels = RelationsProjets;
            rels.Filtre = new CFiltreData(CProjet.c_champId + "=@1",
                projet.Id);
            if (rels.Count == 0)
            {
                CRelationMetaProjet_Projet rel = new CRelationMetaProjet_Projet(ContexteDonnee);
                rel.CreateNewInCurrentContexte();
                rel.Projet = projet;
                rel.MetaProjet = this;
                rel.IsAutoAdded = bAutoAdded;
            }
        }

        [DynamicMethod("Add a project to the meta project")]
        public void AddProject(CProjet projet)
        {
            AssocieProjet(projet, false);
        }

        /// <summary>
        /// Déplace le metaprojet vers une nouvelle date de début planifiée et fixe une nouvelle durée
        /// </summary>
        /// <param name="newStartDate">Nouvelle date de début</param>
        /// <param name="durationHour">Nouvelle durée exprimée en heures</param>
        /// <param name="moveMode">Mode de déplacement</param>
        [DynamicMethod("Move the current metaproject to the new Start Date",
            "New Start Date",
            "New  in Hours",
            "Moving Mode (int) : 0-Move Auto only, 1-Move non Auto, 2-Move non Auto and Ended")]
        public void MoveProject(DateTime newStartDate, double durationHour, int moveMode)
        {
            TimeSpan sp = newStartDate - this.DateFinPlanifiee;
            TimeSpan duree = TimeSpan.FromHours(durationHour);
            EModeDeplacementProjet mode = (EModeDeplacementProjet)moveMode;

            Move(sp, duree, mode, true);

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
            MoveWithChilds(sp, duree, mode, bForceForThisElement);
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

            DateDebutPlanifiee = DateDebutPlanifiee.Add(sp);
            if (duree == null)
                DateFinPlanifiee = DateFinPlanifiee.Add(sp);
            else if (duree != null)
                DateFinPlanifiee = DateFinPlanifiee.Add(duree.Value);
            foreach (CRelationMetaProjet_Projet rel in RelationsProjets.ToArrayList())
            {
                rel.Projet.Move(sp, null, mode, false);
            }
            UpdateDateFinPlanifieeFromChilds(false);
            UpdateDateDebutPlanifieeFromChilds(false);
        }

        /// /////////////////////////////////////////////
        [TableFieldProperty(c_champTableDernieresDatesConnues, IsInDb = false)]
        public Dictionary<int, CProjet.CCacheDatesProjet> CacheLastDatesConnues
        {
            get
            {
                return Row[c_champTableDernieresDatesConnues] as Dictionary<int, CProjet.CCacheDatesProjet>;
            }
            set
            {
                Row[c_champTableDernieresDatesConnues] = value;
            }
        }

        /// /////////////////////////////////////////////
        private void StockLastDateDebutPlanifieeConnue(CProjet projet)
        {
            Dictionary<int, CProjet.CCacheDatesProjet> dic = CacheLastDatesConnues;
            if (dic == null)
            {
                dic = new Dictionary<int, CProjet.CCacheDatesProjet>();
                CacheLastDatesConnues = dic;
            }
            CProjet.CCacheDatesProjet cache = null;
            if (!dic.TryGetValue(projet.Id, out cache))
            {
                cache = new CProjet.CCacheDatesProjet(projet);
                dic[projet.Id] = cache;
            }
            cache.DateDebutPlanifiee = projet.DateDebutPlanifiee;
        }

        /// /////////////////////////////////////////////
        private void StockLastDateFinPlanifieeConnue(CProjet projet)
        {
            Dictionary<int, CProjet.CCacheDatesProjet> dic = CacheLastDatesConnues;
            if (dic == null)
            {
                dic = new Dictionary<int, CProjet.CCacheDatesProjet>();
                CacheLastDatesConnues = dic;
            }
            CProjet.CCacheDatesProjet cache = null;
            if (!dic.TryGetValue(projet.Id, out cache))
            {
                cache = new CProjet.CCacheDatesProjet(projet);
                dic[projet.Id] = cache;
            }
            cache.DateFinPlanifiee = projet.DateFinPlanifiee;
        }

        /// /////////////////////////////////////////////
        private void StockLastDateDebutReelleConnue(CProjet projet)
        {
            Dictionary<int, CProjet.CCacheDatesProjet> dic = CacheLastDatesConnues;
            if (dic == null)
            {
                dic = new Dictionary<int, CProjet.CCacheDatesProjet>();
                CacheLastDatesConnues = dic;
            }
            CProjet.CCacheDatesProjet cache = null;
            if (!dic.TryGetValue(projet.Id, out cache))
            {
                cache = new CProjet.CCacheDatesProjet(projet);
                dic[projet.Id] = cache;
            }
            cache.DateDebutRelle = projet.DateDebutReel;
        }

        /// /////////////////////////////////////////////
        private void StockLastDateFinReelleConnue(CProjet projet)
        {
            Dictionary<int, CProjet.CCacheDatesProjet> dic = CacheLastDatesConnues;
            if (dic == null)
            {
                dic = new Dictionary<int, CProjet.CCacheDatesProjet>();
                CacheLastDatesConnues = dic;
            }
            CProjet.CCacheDatesProjet cache = null;
            if (!dic.TryGetValue(projet.Id, out cache))
            {
                cache = new CProjet.CCacheDatesProjet(projet);
                dic[projet.Id] = cache;
            }
            cache.DateFinRelle = projet.DateFinRelle;
        }

        /// /////////////////////////////////////////////
        private DateTime? GetLastDateDebutPlanifieeConnuePourProjet(CProjet projet)
        {
            DateTime? retour = null;
            Dictionary<int, CProjet.CCacheDatesProjet> dic = CacheLastDatesConnues;
            CProjet.CCacheDatesProjet cache = null;
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
                    retour = projet.DateDebutPlanifiee;
                    projet.VersionToReturn = oldVers;
                }
            }
            else
            {
                retour = cache.DateDebutPlanifiee.Value;
            }
            return retour;
        }

        /// /////////////////////////////////////////////
        private DateTime? GetLastDateFinPlanifieeConnuePourProjet(CProjet projet)
        {
            DateTime? retour = null;
            Dictionary<int, CProjet.CCacheDatesProjet> dic = CacheLastDatesConnues;
            CProjet.CCacheDatesProjet cache = null;
            if (dic == null || !dic.TryGetValue(projet.Id, out cache) || cache.DateFinPlanifiee == null)
            {
                DataRowVersion oldVers = projet.VersionToReturn;
                if (projet.Row.HasVersion(DataRowVersion.Original))
                {
                    projet.VersionToReturn = DataRowVersion.Original;
                    retour = projet.DateFinPlanifiee;
                    projet.VersionToReturn = oldVers;
                }
            }
            else
            {
                retour = cache.DateFinPlanifiee.Value;
            }
            return retour;
        }

        /// /////////////////////////////////////////////
        private DateTime? GetLastDateDebutReelleConnuePourProjet(CProjet projet)
        {
            DateTime? retour = null;
            Dictionary<int, CProjet.CCacheDatesProjet> dic = CacheLastDatesConnues;
            CProjet.CCacheDatesProjet cache = null;
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
                    retour = projet.DateDebutReel;
                    projet.VersionToReturn = oldVers;
                }
            }
            else
            {
                retour = cache.DateDebutRelle.Value;
            }
            return retour;
        }

        /// /////////////////////////////////////////////
        private DateTime? GetLastDateFinReelleConnuePourProjet(CProjet projet)
        {
            DateTime? retour = null;
            Dictionary<int, CProjet.CCacheDatesProjet> dic = CacheLastDatesConnues;
            CProjet.CCacheDatesProjet cache = null;
            if (dic == null || !dic.TryGetValue(projet.Id, out cache) || cache.DateFinPlanifiee == null)
            {
                DataRowVersion oldVers = projet.VersionToReturn;
                if (projet.Row.HasVersion(DataRowVersion.Original))
                {
                    projet.VersionToReturn = DataRowVersion.Original;
                    retour = projet.DateFinRelle;
                    projet.VersionToReturn = oldVers;
                }
            }
            else
            {
                retour = cache.DateFinRelle.Value;
            }
            return retour;
        }



        /// <summary>
        /// Retourne la date de début à partir de la date de ses enfants
        /// </summary>
        /// <returns></returns>
        public void UpdateDateDebutPlanifieeFromChilds(bool bSurModifiesUniquement)
        {
            DateTime? dateDebut = DateDebutPlanifiee;
            List<CProjet> lstFils = new List<CProjet>();
            if (bSurModifiesUniquement)
            {
                //Récupère tous les fils modifiés
                List<CProjet> lstFilsSansLecture = new List<CProjet>();
                List<CMetaProjet> lstMetaFilsSansLecture = new List<CMetaProjet>();
                foreach (CRelationMetaProjet_Projet rel in RelationsProjets)
                {
                    if (rel.Projet.Row.RowState != DataRowState.Unchanged)
                        lstFils.Add(rel.Projet);
                }
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
                        {
                            DataRow row = prjFils.Row.Row;
                            if (row.RowState == DataRowState.Deleted)
                            {
                                bSurModifiesUniquement = false;
                                break;
                            }
                            if (prjFils.DateDebutPlanifiee > dateDebut)
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
                RelationsProjets.ReadDependances("Projet");
                foreach (CRelationMetaProjet_Projet rel in RelationsProjets)
                {
                    lstFils.Add(rel.Projet);
                }
            }

            foreach (CProjet projet in lstFils)
            {
                if (projet.IsValide())
                {
                    DateTime? dt = projet.DateDebutPlanifiee;
                    if (dateDebut == null || dt < dateDebut.Value)
                        dateDebut = dt;
                    StockLastDateDebutPlanifieeConnue(projet);
                }
            }
            if (dateDebut != null)
            {
                DateDebutPlanifiee = dateDebut.Value;
            }
        }

        /// <summary>
        /// Retourne la date de fin à partir de la date de ses enfants
        /// </summary>
        /// <returns></returns>
        public void UpdateDateFinPlanifieeFromChilds(bool bSurModifiesUniquement)
        {
            DateTime? dateFin = DateFinPlanifiee;
            List<CProjet> lstFils = new List<CProjet>();
            if (bSurModifiesUniquement)
            {
                //Récupère tous les fils modifiés
                List<CProjet> lstFilsSansLecture = new List<CProjet>();
                foreach (CRelationMetaProjet_Projet rel in RelationsProjets)
                {
                    if (rel.Projet.Row.RowState != DataRowState.Unchanged)
                        lstFils.Add(rel.Projet);
                }
                foreach (CProjet prjFils in lstFilsSansLecture)
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
                            if (prjFils.DateFinPlanifiee < dateFin)
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
                RelationsProjets.ReadDependances("Projet");
                dateFin = null;
                lstFils.Clear();
                foreach (CRelationMetaProjet_Projet rel in RelationsProjets)
                {
                    lstFils.Add(rel.Projet);
                }
            }

            foreach (CProjet projet in lstFils)
            {
                if (projet.IsValide())
                {
                    if (dateFin == null || projet.DateFinPlanifiee > dateFin.Value)
                        dateFin = projet.DateFinPlanifiee;
                    StockLastDateFinPlanifieeConnue(projet);
                }
            }
            if (dateFin != null)
                DateFinPlanifiee = dateFin.Value;
        }


        /// <summary>
        /// Retourne la date de début à partir de la date de ses enfants
        /// </summary>
        /// <returns></returns>
        public void UpdateDateDebutReelleFromChilds(bool bSurModifiesUniquement)
        {
            DateTime? dateDebut = DateDebutReelle;

            List<CProjet> lstFils = new List<CProjet>();
            if (bSurModifiesUniquement)
            {
                //Récupère tous les fils modifiés
                List<CProjet> lstFilsSansLecture = new List<CProjet>();
                foreach (CRelationMetaProjet_Projet rel in RelationsProjets)
                {
                    if (rel.Projet.Row.RowState != DataRowState.Unchanged)
                        lstFils.Add(rel.Projet);
                }
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
                RelationsProjets.ReadDependances("Projet");
                foreach (CRelationMetaProjet_Projet rel in RelationsProjets)
                {
                    lstFils.Add(rel.Projet);
                }
            }

            bool bAllNull = true;
            foreach (CProjet projet in lstFils)
            {
                if (projet.IsValide())
                {
                    DateTime? dt = projet.DateDebutReel;
                    if (dateDebut == null || dt < dateDebut.Value)
                        dateDebut = dt;
                    bAllNull &= dt == null;
                    StockLastDateDebutReelleConnue(projet);
                }
            }
            DateDebutReelle = bAllNull ? null : (DateTime?)dateDebut.Value;
        }

        /// <summary>
        /// Retourne la date de fin à partir de la date de ses enfants
        /// </summary>
        /// <returns></returns>
        public void UpdateDateFinReelleFromChilds(bool bSurModifiesUniquement)
        {
            DateTime? dateFin = DateFinReelle;
            List<CProjet> lstFils = new List<CProjet>();
            if (bSurModifiesUniquement)
            {
                //Récupère tous les fils modifiés
                List<CProjet> lstFilsSansLecture = new List<CProjet>();
                foreach (CRelationMetaProjet_Projet rel in RelationsProjets)
                {
                    if (rel.Projet.Row.RowState != DataRowState.Unchanged)
                        lstFils.Add(rel.Projet);
                }
                foreach (CProjet prjFils in lstFilsSansLecture)
                {
                    if (prjFils.Row.RowState == DataRowState.Modified || prjFils.Row.RowState == DataRowState.Deleted)
                    {
                        //Attention, si l'ancienne date de fin était égale à la date
                        //de fin, et que la nouvelle date est inférieure à la date
                        //de fin, on ne connait plus le max !
                        if (GetLastDateFinReelleConnuePourProjet(prjFils) == dateFin)
                        {
                            if (prjFils.Row.RowState == DataRowState.Deleted)
                            {
                                bSurModifiesUniquement = false;
                                break;
                            }
                            if (prjFils.DateFinRelle < dateFin)
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
                RelationsProjets.ReadDependances("Projet");
                dateFin = null;
                lstFils.Clear();
                foreach (CRelationMetaProjet_Projet rel in RelationsProjets)
                {
                    lstFils.Add(rel.Projet);
                }
            }

            bool bAllNull = true;
            foreach (CProjet projet in lstFils)
            {
                if (projet.IsValide())
                {
                    if (dateFin == null || projet.DateFinRelle > dateFin.Value)
                        dateFin = projet.DateFinRelle;
                    bAllNull &= projet.DateFinRelle == null;
                    StockLastDateFinReelleConnue(projet);
                }
            }
            DateFinReelle = bAllNull ? null : (DateTime?)dateFin.Value;
        }


        //-----------------------------------------------------------
        [DynamicMethod(
            "Asigne a new Organisationnal Entity to the Element",
            "The Organisationnal Entity Identifier")]
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
                if (TypeMetaProjet == null)
                    return new IElementAEO[0];
                else
                    return new IElementAEO[] { TypeMetaProjet };

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
            get { return new IElementAEO[0]; }
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
            "Remove an Organisationnal Entity from the Element",
            "The Organisationnal Entity Identifier")]
        public CResultAErreur SupprimerEO(int nIdEO)
        {
            return CUtilElementAEO.SupprimerEO(this, nIdEO);
        }

        //-------------------------------------------------------------------
        public void CompleteRestriction(CRestrictionUtilisateurSurType restriction)
        {
            CUtilElementAEO.CompleteRestriction(this, restriction);
        }



        #region IObjetDonneeAChamps Membres
        //-------------------------------------------------------------------
        public CRelationElementAChamp_ChampCustom GetNewRelationToChamp()
        {
            return new CRelationMetaProjet_ChampCustom(ContexteDonnee);
        }

        //-------------------------------------------------------------------
        public string GetNomTableRelationToChamps()
        {
            return CRelationMetaProjet_ChampCustom.c_nomTable;
        }

        //-------------------------------------------------------------------
        public CListeObjetsDonnees GetRelationsToChamps(int nIdChamp)
        {
            CListeObjetsDonnees liste = RelationsChampsCustom;
            liste.InterditLectureInDB = true;
            liste.Filtre = new CFiltreData(CChampCustom.c_champId + " = @1", nIdChamp);
            return liste;
        }

        #endregion

        #region IElementAChamps Membres

        //-------------------------------------------------------------------
        public IDefinisseurChampCustom[] DefinisseursDeChamps
        {
            get
            {
                if (TypeMetaProjet != null)
                    return new IDefinisseurChampCustom[] { TypeMetaProjet };
                return new IDefinisseurChampCustom[0];
            }
        }

        //-------------------------------------------------------------------
        public CChampCustom[] GetChampsHorsFormulaire()
        {
            if (TypeMetaProjet == null)
                return new CChampCustom[0];

            ArrayList lst = new ArrayList();
            foreach (CRelationTypeProjet_ChampCustom rel in TypeMetaProjet.RelationsChampsCustomDefinis)
                lst.Add(rel.ChampCustom);

            foreach (CRelationTypeProjet_Formulaire rel1 in TypeMetaProjet.RelationsFormulaires)
                foreach (CRelationFormulaireChampCustom rel2 in rel1.Formulaire.RelationsChamps)
                    lst.Remove(rel2.Champ);

            return (CChampCustom[])lst.ToArray(typeof(CChampCustom));
        }

        //-------------------------------------------------------------------
        public CFormulaire[] GetFormulaires()
        {
            return CUtilElementAChamps.GetFormulaires(this);
        }


        //-------------------------------------------------------------------
        [RelationFille(typeof(CRelationMetaProjet_ChampCustom), "ElementAChamps")]
        [DynamicChilds("Custom fields relations", typeof(CRelationMetaProjet_ChampCustom))]
        public CListeObjetsDonnees RelationsChampsCustom
        {
            get
            {
                return GetDependancesListe(CRelationMetaProjet_ChampCustom.c_nomTable, c_champId);
            }
        }

        //-------------------------------------------------------------------
        public CRoleChampCustom RoleChampCustomAssocie
        {
            get { return CRoleChampCustom.GetRole(c_roleChampCustom); }
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

        //-------------------------------------------------------------------
        public override string ChampCodeSystemeComplet
        {
            get { return c_champCodeSystemeComplet; }
        }

        //-------------------------------------------------------------------
        public override string ChampCodeSystemePartiel
        {
            get { return c_champCodeSystemePartiel; }
        }

        //-------------------------------------------------------------------
        public override string ChampIdParent
        {
            get { return c_champMetaParentId; }
        }

        //-------------------------------------------------------------------
        public override string ChampLibelle
        {
            get { return c_champLibelle; }
        }

        //-------------------------------------------------------------------
        public override string ChampNiveau
        {
            get { return c_champNiveau; }
        }

        
        //----------------------------------------------------
        /// <summary>
        /// Indique le code système complet du metaprojet.
        /// Ce code système complet est la concaténation du code système partiel du metaprojet
        /// avec le code système partiel de tous ses parents en remontant la hiérarchie.
        /// Exemple : pour un code système complet tel que : 0012000A0034 :
        /// 0034 est le code partiel du metaprojet courant
        /// 000A est le code partiel du metaprojet père
        /// 0012 est le code partiel du metaprojet grand père
        /// </summary>
        [TableFieldProperty(c_champCodeSystemeComplet, 400)]
        [DynamicField("Full system code")]
        public override string CodeSystemeComplet
        {
            get { return (string)Row[c_champCodeSystemeComplet]; }
        }

        //----------------------------------------------------
        /// <summary>
        /// Indique le code système propre au metaprojet.
        /// Ce code est unique dans son metaprojet parent.
        /// Ce code est exprimé  sur 4 caractères alphanumériques.
        /// </summary>
        [TableFieldProperty(c_champCodeSystemePartiel, 4)]
        [DynamicField("Partial system code")]
        public override string CodeSystemePartiel
        {
            get { return (string)Row[c_champCodeSystemePartiel]; }
        }

        //-------------------------------------------------------------------
        public override int NbCarsParNiveau
        {
            get { return 4; }
        }

        //----------------------------------------------------
        /// <summary>
        /// Indique le niveau hiérarchique( nombre de parents ) du metaprojet<br/>
        /// Le niveau d'un metaprojet sans parent est 0.<br/>
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

        //----------------------------------------------------------------------------
        /// <summary>
        /// Obtient ou définit le metaprojet parent du metaprojet
        /// </summary>
        [Relation(
            c_nomTable,
            c_champId,
            c_champMetaParentId,
            false,
            false)]
        [DynamicField("Parent Project")]
        public CMetaProjet MetaProjet
        {
            get
            {
                return (CMetaProjet)ObjetParent;
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

        //----------------------------------------------------------------------------
        [RelationFille(typeof(CMetaProjet), "MetaProjet")]
        [DynamicChilds("Children meta projects", typeof(CMetaProjet))]
        public CListeObjetsDonnees MetaProjetsFils
        {
            get{
                return GetDependancesListe ( CMetaProjet.c_nomTable, c_champMetaParentId);
            }
        }


    }
}