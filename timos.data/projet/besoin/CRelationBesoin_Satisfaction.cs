using System;
using System.Data;
using System.Collections.Generic;


using sc2i.common;
using sc2i.data;
using sc2i.data.dynamic;
using tiag.client;
using timos.data.tiag;
using timos.acteurs;
using timos.securite;
using System.Text;
using sc2i.multitiers.client;
using timos.data.commandes;

namespace timos.data.projet.besoin
{
	#region RelationBesoin_Satisfaction
	[AttributeUsage(AttributeTargets.Class)]
	[Serializable]
	public class RelationBesoin_SatisfactionAttribute : RelationTypeIdAttribute
	{
		public override string TableFille
		{
			get
			{
                return CRelationBesoin_Satisfaction.c_nomTable;
			}
		}

		//////////////////////////////////////
		public override int Priorite
		{
			get
			{
				return 800;
			}
		}

		protected override string MyIdRelation
		{
			get
			{
                return "NEED_SATISFACTION";
			}
		}


		public override string ChampId
		{
			get
			{
                return CRelationBesoin_Satisfaction.c_champIdElement;
			}
		}

		public override string ChampType
		{
			get
			{
                return CRelationBesoin_Satisfaction.c_champTypeElement;
			}
		}

		public override bool Composition
		{
			get
			{
				return true;
			}
		}
		public override bool CanDeleteToujours
		{
			get
			{
				return true;
			}
		}


		public override string NomConvivialPourParent
		{
			get
			{
				return I.T("Satisifed needs|20164");
			}
		}

		protected override bool MyIsAppliqueToType(Type tp)
		{
			return typeof(ISatisfactionBesoin).IsAssignableFrom(tp);
		}
	}

	#endregion

    

	/// <summary>
	/// Relation entre un <see cref="CBesoin">Besoin</see> et un élément
	/// satisfaisant ce besoin
	/// </summary>
    /// NOTE POUR LES DEVELOPPEURS : Toujours passer par la fonction AddSatisfaction et RemoveSatisfaction
    /// pour que les couts soient bien recalculés
    [Table(CRelationBesoin_Satisfaction.c_nomTable,
         CRelationBesoin_Satisfaction.c_champId,
		 true)]
    [ObjetServeurURI("CRelationBesoin_SatisfactionServeur")]
	[DynamicClass("Need / Satisfaction")]
	[RelationBesoin_Satisfaction]
    public class CRelationBesoin_Satisfaction : CObjetDonneeAIdNumeriqueAuto
	{
        private class CCacheRelations
        {
            private class CCacheRelationsParContexte
            {
                public DateTime DateLastAcces = DateTime.Now;

                private const int c_nNbMaxInCache = 500;

                private class CCacheRelation
                {
                    public DateTime DateLastAcces = DateTime.Now;
                    private List<int> m_lstIdsRelations = new List<int>();
                    private string m_strIds = null;
                    public CCacheRelation()
                    {

                    }

                    public void AddRelation(CRelationBesoin_Satisfaction relation)
                    {
                        m_strIds = null;
                        m_lstIdsRelations.Add(relation.Id);
                        DateLastAcces = DateTime.Now;
                    }

                    public List<int> Ids
                    {
                        get
                        {
                            DateLastAcces = DateTime.Now;
                            return m_lstIdsRelations;
                        }
                    }

                    public string IdsPourFiltre
                    {
                        get
                        {
                            DateLastAcces = DateTime.Now;
                            if (m_strIds == null)
                            {
                                StringBuilder bl = new StringBuilder();
                                foreach (int nId in m_lstIdsRelations)
                                {
                                    bl.Append(nId);
                                    bl.Append(',');
                                }
                                if (bl.Length > 0)
                                    bl.Remove(bl.Length - 1, 1);
                                m_strIds = bl.ToString();
                            }
                            return m_strIds;
                        }
                    }

                }

                private Dictionary<string, CCacheRelation> m_dicCaches = new Dictionary<string, CCacheRelation>();

                public void Reset()
                {
                    m_dicCaches = new Dictionary<string, CCacheRelation>();
                }

                private string GetKey(ISatisfactionBesoin satisfaction)
                {
                    return satisfaction.GetType() + "/" + satisfaction.Id;
                }

                //-------------------------------------------------------------------
                public void Reset(ISatisfactionBesoin satisfaction)
                {
                    DateLastAcces = DateTime.Now;
                    CCacheRelation cache = null;
                    if (m_dicCaches.TryGetValue(GetKey(satisfaction), out cache))
                        m_dicCaches.Remove(GetKey(satisfaction));
                }

                //-------------------------------------------------------------------
                public bool IsLoaded(ISatisfactionBesoin satisfaction)
                {
                    return m_dicCaches.ContainsKey(GetKey(satisfaction));
                }

                //-------------------------------------------------------------------
                private void NettoieCache()
                {
                    while (m_dicCaches.Count > c_nNbMaxInCache)
                    {
                        DateTime? dtMax = null;
                        string strKeyToDelete = null;
                        foreach (KeyValuePair<string, CCacheRelation> kv in m_dicCaches)
                        {
                            if (dtMax == null || dtMax.Value > kv.Value.DateLastAcces)
                            {
                                dtMax = kv.Value.DateLastAcces;
                                strKeyToDelete = kv.Key;
                            }
                        }
                        if (strKeyToDelete != null)
                            m_dicCaches.Remove(strKeyToDelete);
                    }
                }

                public void SetRelations(ISatisfactionBesoin satisfaction, CListeObjetsDonnees relations)
                {
                    CCacheRelation cache = new CCacheRelation();
                    foreach (CRelationBesoin_Satisfaction rel in relations)
                        cache.AddRelation(rel);
                    m_dicCaches[GetKey(satisfaction)] = cache;
                }

                public CListeObjetsDonnees GetRelations(ISatisfactionBesoin satisfaction)
                {
                    DateLastAcces = DateTime.Now;
                    CCacheRelation cache = null;
                    CFiltreData filtre;
                    if (!m_dicCaches.TryGetValue(GetKey(satisfaction), out cache))
                    {
                        filtre = new CFiltreData(
                        CRelationBesoin_Satisfaction.c_champTypeElement + "=@1 and " +
                        CRelationBesoin_Satisfaction.c_champIdElement + "=@2",
                        satisfaction.GetType().ToString(),
                        satisfaction.Id);
                        CListeObjetsDonnees liste = new CListeObjetsDonnees(satisfaction.ContexteDonnee, typeof(CRelationBesoin_Satisfaction), filtre);
                        liste.PreserveChanges = true;
                        SetRelations(satisfaction, liste);
                        return liste;
                    }
                    filtre = new CFiltreDataImpossible();
                    if (cache.Ids.Count > 0)
                        filtre = new CFiltreData(CRelationBesoin_Satisfaction.c_champId + " in (" + cache.IdsPourFiltre + ")");
                    else
                        filtre = new CFiltreDataImpossible();
                    CListeObjetsDonnees lstOptim = new CListeObjetsDonnees(satisfaction.ContexteDonnee, typeof(CRelationBesoin_Satisfaction), filtre);
                    lstOptim.PreserveChanges = true;
                    lstOptim.InterditLectureInDB = true;
                    return lstOptim;
                }
            }

            private Dictionary<int, CCacheRelationsParContexte> m_dicContexteToCache = new Dictionary<int, CCacheRelationsParContexte>();

            private const int m_nNbCachesMax = 5;

            //-------------------------------------------------------------------
            public bool IsLoaded(ISatisfactionBesoin satisfaction)
            {
                CCacheRelationsParContexte cache = null;
                if (!m_dicContexteToCache.TryGetValue(satisfaction.ContexteDonnee.IdContexteDonnee, out cache))
                    return false;
                return cache.IsLoaded(satisfaction);
            }


            //-------------------------------------------------------------------
            public void SetRelations ( ISatisfactionBesoin satisfaction, CListeObjetsDonnees lstRelations )
            {
                CCacheRelationsParContexte cache = null;
                if (!m_dicContexteToCache.TryGetValue(satisfaction.ContexteDonnee.IdContexteDonnee, out cache))
                {
                    NettoieCache();
                    cache = new CCacheRelationsParContexte();
                    m_dicContexteToCache[satisfaction.ContexteDonnee.IdContexteDonnee] = cache;
                }
                cache.SetRelations ( satisfaction, lstRelations );
            }

            //-------------------------------------------------------------------
            public CListeObjetsDonnees GetRelations(ISatisfactionBesoin satisfaction)
            {
                CCacheRelationsParContexte cache = null;
                if (!m_dicContexteToCache.TryGetValue(satisfaction.ContexteDonnee.IdContexteDonnee, out cache))
                {
                    NettoieCache();
                    cache = new CCacheRelationsParContexte();
                    m_dicContexteToCache[satisfaction.ContexteDonnee.IdContexteDonnee] = cache;
                }
                return cache.GetRelations ( satisfaction );
            }

            //-------------------------------------------------------------------
            private void NettoieCache()
            {
                while (m_dicContexteToCache.Count > m_nNbCachesMax)
                {
                    DateTime? dtMax = null;
                    int? nIdContexteToDelete = null;
                    foreach (KeyValuePair<int, CCacheRelationsParContexte> kv in m_dicContexteToCache)
                    {
                        if (dtMax == null || dtMax.Value > kv.Value.DateLastAcces)
                        {
                            dtMax = kv.Value.DateLastAcces;
                            nIdContexteToDelete = kv.Key;
                        }
                    }
                    if (nIdContexteToDelete != null)
                        m_dicContexteToCache.Remove(nIdContexteToDelete.Value);
                }
            }

            //-------------------------------------------------------------------
            public void  Reset()
            {
                m_dicContexteToCache.Clear();
            }

            //-------------------------------------------------------------------
            public void Reset(ISatisfactionBesoin satisfaction)
            {
                foreach (CCacheRelationsParContexte cache in m_dicContexteToCache.Values)
                    cache.Reset(satisfaction);
            }
        }

        private static CCacheRelations m_cacheRelations = null;

        public static void InitCachePourUnClientJamaisCotéServeur()
        {
            m_cacheRelations = new CCacheRelations();
        }

		public const string c_nomTable = "NEED_SATISFACTION";

		public const string c_champId = "NEEDSAT_ID";
		public const string c_champTypeElement = "NEEDSAT_ELEMENT_TYPE";
		public const string c_champIdElement = "NEEDSAT_ELEMENT_ID";
        public const string c_champRatioCoutReel = "NEEDSAT_COST_RATIO";

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ctx"></param>
		public CRelationBesoin_Satisfaction(CContexteDonnee ctx)
			: base(ctx)
		{
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="row"></param>
		public CRelationBesoin_Satisfaction(DataRow row)
			: base(row)
		{
		}


		
		/// <summary>
		/// 
		/// </summary>
		public override string DescriptionElement
		{
			get
			{
				string strInfo = I.T( "Relation between need '@1' and '@2'|20157",
                    (Besoin != null?Besoin.Libelle:"?"),
                    (Satisfaction != null?Satisfaction.DescriptionElement:"?"));
				return strInfo;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] { c_champId };
		}

		/// <summary>
		/// 
		/// </summary>
		protected override void MyInitValeurDefaut()
		{
		}

		
		/// <summary>
		/// Besoin satisfait par l'élément<br/>
		/// (obligatoire)
		/// </summary>
		[Relation(
			CBesoin.c_nomTable,
           CBesoin.c_champId,
           CBesoin.c_champId,
			true,
			true,
			true)]
		[DynamicField("Need")]
		public CBesoin Besoin
		{
			get
			{
				return (CBesoin)GetParent(CBesoin.c_champId, typeof(CBesoin));
			}
			set
			{
				SetParent(CBesoin.c_champId, value);
                if (value != null)
                    value.ResetHasSatisfactions();
			}
		}

        //----------------------------------------------------------------------------------
        protected override CResultAErreur MyCanDelete()
        {
            //Profite du fait qu'on risque de supprimer cet élément pour prévenir
            //le besoin qu'il doit invalider le cache HasSatisfactions
            if (Besoin != null)
                Besoin.ResetHasSatisfactions();
            return base.MyCanDelete();
        }

		/// <summary>
		/// 
		/// </summary>
		public Type TypeElement
		{
			get
			{
				return CActivatorSurChaine.GetType(StringTypeElement);
			}
			set
			{
				StringTypeElement = value.ToString();
			}
		}

		/// <summary>
		/// Type système de l'élément TIMOS, objet de la relation
		/// </summary>
		[TableFieldProperty(c_champTypeElement, 1024)]
		[IndexField]
        [DynamicField("Element Type")]
		public string StringTypeElement
		{
			get
			{
				return (string)Row[c_champTypeElement];
			}
			set
			{
				Row[c_champTypeElement] = value;
			}
		}

		/// <summary>
		/// Identifiant (Id) de l'élément TIMOS, objet de la relation
		/// </summary>
		[TableFieldPropertyAttribute(c_champIdElement)]
		[IndexField]
        [DynamicField("Element Id")]
		public int IdElement
		{
			get
			{
				return (int)Row[c_champIdElement];
			}
			set
			{
				Row[c_champIdElement] = value;
			}
		}

		/// <summary>
		/// Element satisfaitsant le besoin<br/>
		/// </summary>
		[DynamicFieldAttribute("Satisfaction")]
		public ISatisfactionBesoin Satisfaction
		{
			get
			{
				Type tp = TypeElement;
				if (tp == null)
					return null;
#if PDA
				IElementAAgenda obj = (IElementAAgenda)Activator.CreateInstance(tp);
				obj.ContexteDonnee = ContexteDonnee;
#else
				CObjetDonneeAIdNumerique obj = (CObjetDonneeAIdNumerique)Activator.CreateInstance(tp, new object[] { ContexteDonnee });
#endif
				if (obj.ReadIfExists(IdElement))
					return obj as ISatisfactionBesoin;
				return null;
			}
			set
			{
				if (value == null)
				{
					TypeElement = null;
					IdElement = -1;
				}
				else
				{
					TypeElement = value.GetType();
					IdElement = value.Id;
				}
			}
		}

        //------------------------------------------------------------------
        public static void PreloadBesoinsSatisfaits(CListeObjetsDonnees lstSatisfactions)
        {
            if (m_cacheRelations == null)
                return;
            if (lstSatisfactions == null || lstSatisfactions.Count == 0)
                return;
            Type tp = lstSatisfactions.TypeObjets;
            if (!typeof(ISatisfactionBesoin).IsAssignableFrom(tp))
                return;
            string strType = tp.ToString();
            StringBuilder bl = new StringBuilder();
            foreach (CObjetDonneeAIdNumerique sat in lstSatisfactions)
            {
                if (sat.IsValide() && !m_cacheRelations.IsLoaded((ISatisfactionBesoin)sat))
                {
                    bl.Append(sat.Id);
                    bl.Append(',');
                }
            }
            if (bl.Length == 0)
                return;
            bl.Remove(bl.Length - 1, 1);
            CListeObjetsDonnees lst = new CListeObjetsDonnees(
                lstSatisfactions.ContexteDonnee,
                typeof(CRelationBesoin_Satisfaction),
                new CFiltreData(CRelationBesoin_Satisfaction.c_champTypeElement + "=@1 and " +
                CRelationBesoin_Satisfaction.c_champIdElement + " in (" + bl.ToString() + ")", strType));
            lst.AssureLectureFaite();
            lst.InterditLectureInDB = true;
            foreach (ISatisfactionBesoin satisfaction in lstSatisfactions)
            {
                lst.Filtre = new CFiltreData(CRelationBesoin_Satisfaction.c_champTypeElement + "=@1 and " +
                    CRelationBesoin_Satisfaction.c_champIdElement + "=@2",
                    strType,
                    satisfaction.Id);
                m_cacheRelations.SetRelations(satisfaction, lst);
            }
        }



        //------------------------------------------------------------------
        /// <summary>
        /// Retourne les liens aux besoins satisfaits
        /// </summary>
        /// <param name="objet"></param>
        /// <returns></returns>
        public static CListeObjetsDonnees GetRelationsBesoinsSatisfaits(ISatisfactionBesoin satisfaction)
        {
            if ( m_cacheRelations != null )
                return m_cacheRelations.GetRelations(satisfaction);
            CFiltreData filtre = new CFiltreData(
                    CRelationBesoin_Satisfaction.c_champTypeElement + "=@1 and " +
                    CRelationBesoin_Satisfaction.c_champIdElement + "=@2",
                    satisfaction.GetType().ToString(),
                    satisfaction.Id);
            CListeObjetsDonnees liste = new CListeObjetsDonnees(satisfaction.ContexteDonnee, typeof(CRelationBesoin_Satisfaction), filtre);
            liste.PreserveChanges = true;
            return liste;
        }

        //------------------------------------------------------------------
        public static void ResetCache()
        {
            if ( m_cacheRelations != null )
                m_cacheRelations.Reset();
        }

        //------------------------------------------------------------------
        public static void ResetCache(ISatisfactionBesoin satisfaction)
        {
            if (m_cacheRelations != null)
                m_cacheRelations.Reset();
        }

        //------------------------------------------------------------------
        public static CListeObjetsDonnees GetBesoinsSatisfaits ( ISatisfactionBesoin satisfaction )
        {
            CListeObjetsDonnees lst = GetRelationsBesoinsSatisfaits(satisfaction);
            return lst.GetDependances("Besoin");
        }

        //------------------------------------------------------------------
        public CRelationBesoin_Satisfaction GetRelationToBesoin(ISatisfactionBesoin satisfaction, CBesoin besoin)
        {
            CListeObjetsDonnees lst = GetRelationsBesoinsSatisfaits(satisfaction);
            lst.Filtre = new CFiltreData(CBesoin.c_champId + "=@1", besoin.Id);
            if (lst.Count > 0)
                return lst[0] as CRelationBesoin_Satisfaction;
            return null;
        }

        //-----------------------------------------------------------
        /// <summary>
        /// Indique la part du cout de la satisfaction à affecter
        /// au besoin. 
        /// </summary>
        /// <remarks>
        /// Lorsqu' une satisfaction de besoin s'applique à plusieurs
        /// besoin, son coût est réparti entre les différents besoins
        /// qu'il satisfait. <BR></BR>
        /// Si le ratio est null, une valeur de 1 est appliqué. sinon,
        /// la valeur est utilisé en pondération avec les valeurs des ratios des
        /// autres besoins satisfaits
        /// </remarks>
        [TableFieldProperty(c_champRatioCoutReel, NullAutorise=true)]
        [DynamicField("Cost ratio")]
        public double? RatioCoutReel
        {
            get
            {
                return (double?)Row[c_champRatioCoutReel, true];
            }
            set
            {
                if (value != (double?)Row[c_champRatioCoutReel, true] && Satisfaction != null)
                {
                    CUtilElementACout.OnChangeCout(Satisfaction, true, false);
                    CUtilElementACout.OnChangeCout(Satisfaction, false, false);
                }

                Row[c_champRatioCoutReel, true] = value;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// Permet de s'affranchir des valeurs nulles
        /// </summary>
        public double RatioCoutReelApplique
        {
            get
            {
                if (RatioCoutReel == null)
                    return 1;
                return RatioCoutReel.Value;
            }
        }


        #region fonctions pour simplifier le paramétrage
        //-------------------------------------------------------------
        /// <summary>
        /// Retourne le projet satisfaction si s'en est un
        /// </summary>
        [DynamicField("Satisfaction as Project")]
        public CProjet SatisfactionAsProjet
        {
            get
            {
                return Satisfaction as CProjet;
            }
        }

        //-------------------------------------------------------------
        /// <summary>
        /// Retourne la phase satisfaction si s'en est une
        /// </summary>
        [DynamicField("Satisfaction as Specification")]
        public CPhaseSpecifications SatisfactionAsSpecification
        {
            get
            {
                return Satisfaction as CPhaseSpecifications;
            }
        }
        
        //-------------------------------------------------------------
        /// <summary>
        /// Retourne le besoin satisfaction si s'en est un
        /// </summary>
        [DynamicField("Satisfaction as need")]
        public CBesoin SatisfactionAsBesoin
        {
            get
            {
                return Satisfaction as CBesoin;
            }
        }

        //-------------------------------------------------------------
        /// <summary>
        /// Retourne le besoin satisfaction si s'en est un
        /// </summary>
        [DynamicField("Satisfaction as Command line")]
        public CLigneCommande SatisfactionAsLigneCommande
        {
            get
            {
                return Satisfaction as CLigneCommande;
            }
        }

        //-------------------------------------------------------------
        /// <summary>
        /// Retourne le besoin satisfaction si s'en est un
        /// </summary>
        [DynamicField("Satisfaction as intervention")]
        public CIntervention SatisfactionAsIntervention
        {
            get
            {
                return Satisfaction as CIntervention;
            }
        }
        #endregion

    }
}
