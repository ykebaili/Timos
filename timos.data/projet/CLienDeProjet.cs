using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using sc2i.data;
using sc2i.common;
using sc2i.process;
using sc2i.multitiers.client;

using sc2i.data.dynamic;
using sc2i.common.planification;
using sc2i.expression;

using timos.securite;
using timos.acteurs;
using tiag.client;


namespace timos.data
{
    /// <summary>
    /// Les liens entre éléments de projets définissent les liens chronologiques et les relations de précédence entre
    /// éléments de projets contenus dans un même projet. Un lien relie deux éléments de projets.
    /// Les éléments de projet sont soit des sous-projets, soit des interventions.
    /// </summary>
    /// <remarks>
    /// les liens sont orientés de l'élément de projet prédécesseur vers l'élément de projet successeur.
    /// Plusieurs liens différents peuvent partir d'un même élément de projet ou y arriver.
    /// Dans le diagramme de Gantt, un lien est en trait bleu lorsque la date de début de planification
    /// de l'élément de projet successeur est supérieure ou égale à la date de fin de planification de l'élément de projet prédécesseur;
    /// le lien est en traits pointillés rouges  lorsque ce n'est pas le cas.
    /// </remarks>
    [DynamicClass("Project link")]
	[ObjetServeurURI("CLienDeProjetServeur")]
	[Table(CLienDeProjet.c_nomTable, CLienDeProjet.c_champId, true)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IngeProjet_ID)]
    [RefillAfterClone]
    [TiagClass(CLienDeProjet.c_nomTiag, "Id", true)]
    public partial class CLienDeProjet : 
        CObjetDonneeAIdNumeriqueAuto, 
        IElementAAnomalieProjet
	{
		#region Déclaration des constantes
        public const string c_nomTiag = "Project Link";

        public const string c_nomTable = "PROJECT_LNK";
		public const string c_champId = "PRJ_LNK_ID";

		//Liaisons
		public const string c_champInterA = "PRJ_LNK_INTER_A";
		public const string c_champInterB = "PRJ_LNK_INTER_B";
		public const string c_champPrjA = "PRJ_LNK_PRJ_A";
		public const string c_champPrjB = "PRJ_LNK_PRJ_B";

		#endregion

		//-------------------------------------------------------------------
		public CLienDeProjet(CContexteDonnee ctx)
			: base(ctx)
		{
		}

		//-------------------------------------------------------------------
		public CLienDeProjet(System.Data.DataRow row)
			: base(row)
		{
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

        //-------------------------------------------------------------------
        public override string DescriptionElement
        {
			get 
			{
                return I.T("Dependancy from @1 to @2|531",
                    ElementA != null ? ElementA.DescriptionElement : "?",
                    ElementB != null ? ElementB.DescriptionElement : "?");
			}
        }

        /// /////////////////////////////////////////////
        protected override void MyInitValeurDefaut()
        {
        }

        /// /////////////////////////////////////////////
        public override string[] GetChampsTriParDefaut()
        {
            return new string[] { c_champId };
        }
                
        //-------------------------------------------------------------------
        /// <summary>
        /// Obtient ou définit l'élément source du lien
        /// </summary>
        [DynamicField("Element A")]
		public IElementDeProjetPlanifiable ElementA
		{
			get
			{
				if (ProjetA != null)
					return ProjetA;
				else
					return InterventionA;
			}
			set
			{
				if (value is CProjet)
				{
					ProjetA = (CProjet)value;
					InterventionA = null;
				}
				else if (value is CIntervention)
				{
					ProjetA = null;
					InterventionA = (CIntervention)value;
				}
				else
				{
					ProjetA = null;
					InterventionA = null;
				}
			}
		}

        //-------------------------------------------------------------------
        /// <summary>
        /// Obtient ou définit l'élément terminal du lien
        /// </summary>
        [DynamicField("Element B")]
        public IElementDeProjetPlanifiable ElementB
		{
			get
			{
				if (ProjetB != null)
					return ProjetB;
				else
					return InterventionB;
			}
			set
			{
				if (value is CProjet)
				{
					ProjetB = (CProjet)value;
					InterventionB = null;
				}
				else if (value is CIntervention)
				{
					ProjetB = null;
					InterventionB = (CIntervention) value;
				}
				else 
				{
					ProjetB = null;
					InterventionB = null;
				}
			}
		}

        //-------------------------------------------------------------------
        public void TiagSetProjectAKeys(object[] lstCles)
        {
            CProjet projetA = new CProjet(ContexteDonnee);
            if (projetA.ReadIfExists(lstCles))
                ProjetA = projetA;
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// Obtient ou définit le <see cref="CProjet">projet</see> source du lien, lorsqu'il s'agit d'un projet
        /// </summary>
		[Relation(
			CProjet.c_nomTable,
			CProjet.c_champId,
		    c_champPrjA,
			false,
			true,
			false)]
        [DynamicField("Project A")]
        [RefillAfterClone]
        [TiagRelation(typeof(CProjet), "TiagSetProjectAKeys")]
        public CProjet ProjetA
		{
			get
			{
				return (CProjet)GetParent(c_champPrjA, typeof(CProjet));
			}
			set
			{
				SetParent(c_champPrjA, value);
			}
		}

        //-------------------------------------------------------------------
        public void TiagSetProjectBKeys(object[] lstCles)
        {
            CProjet projetB = new CProjet(ContexteDonnee);
            if (projetB.ReadIfExists(lstCles))
                ProjetB = projetB;
        }
        
        //-------------------------------------------------------------------
        /// <summary>
        /// Obtient ou définit le <see cref="CProjet">projet</see> terminal du lien, lorsqu'il s'agit d'un projet
        /// </summary>
		[Relation(
			CProjet.c_nomTable,
			CProjet.c_champId,
		    c_champPrjB,
			false,
		   true,
			false)]
        [DynamicField("Project B")]
        [RefillAfterClone]
        [TiagRelation(typeof(CProjet), "TiagSetProjectBKeys")]
        public CProjet ProjetB
		{
			get
			{
				return (CProjet)GetParent(c_champPrjB, typeof(CProjet));
			}
			set
			{
				SetParent(c_champPrjB, value);
			}
		}


        //-------------------------------------------------------------------
        /// <summary>
        /// Obtient ou définit l'<see cref="CIntervention">intervention</see> source du lien, lorsqu'il s'agit d'une intervention
        /// </summary>
		[Relation(
			CIntervention.c_nomTable,
		   CIntervention.c_champId,
		   c_champInterA,
			false,
			true,
			false)]
        [RefillAfterClone]
        [DynamicField("Intervention A")]
        public CIntervention InterventionA
		{
			get
			{
				return (CIntervention)GetParent(c_champInterA, typeof(CIntervention));
			}
			set
			{
				SetParent(c_champInterA, value);
			}
		}

        //-------------------------------------------------------------------
        /// <summary>
        /// Obtient ou définit l'<see cref="CIntervention">intervention</see> terminale du lien, lorsqu'il s'agit d'une intervention
        /// </summary>
		[Relation(
            CIntervention.c_nomTable,
            CIntervention.c_champId,
            c_champInterB,
			false,
			true,
			false)]
        [RefillAfterClone]
        [DynamicField("Intervention B")]
        public CIntervention InterventionB
		{
			get
			{
				return (CIntervention)GetParent(c_champInterB, typeof(CIntervention));
			}
			set
			{
				SetParent(c_champInterB, value);
			}
		}

		public int NbCalculAnomalie
		{
			get
			{
				int nb = 0;
				//nb = (Projet != null && !((Projet.TypesAnomaliesFiltres & ETypeAnomalieProjet.NonRespectContrainteDate) == ETypeAnomalieProjet.NonRespectContrainteDate)) ? nb++ : nb;
				return nb;
			}
		}


        //----------------------------------------------------------------
		public CResultAErreur CalcAnomaliesDates( CProjet projet )
		{
            CResultAErreur result = CResultAErreur.True;
			if (projet == null)
				return result;
            if (((projet.TypesAnomaliesFiltres & ETypeAnomalieProjet.NonRespectContrainteDate) == 0))
            {
                if (ElementA == null && ElementB == null)
                    CAnomalieProjet.CreerAnomalie(ContexteDonnee, projet, ETypeAnomalieProjet.Autre,
                        I.T("Invalid project link : no link end|484"), null);
                else if (ElementA == null)
                    CAnomalieProjet.CreerAnomalie(ContexteDonnee, projet, ETypeAnomalieProjet.Autre,
                        I.T("No link end for link to @1|485", ElementB.DescriptionElement),
                        null);
                else if (ElementB == null)
                    CAnomalieProjet.CreerAnomalie(ContexteDonnee, projet, ETypeAnomalieProjet.Autre,
                        I.T("No link end for link to @1|485", ElementA.DescriptionElement),
                        null);
                else
                {
                    DateTime? date1 = ElementA.DateDebutGantt;
                    DateTime? date2 = ElementB.DateDebutGantt;
                    if (date1 != null && date2 != null)
                    {
                        TimeSpan sp = date1.Value - date2.Value;
                        double fTolerance = 0;
                        if (sp.TotalDays > fTolerance)
                        {
                            result = CAnomalieProjet.CreerAnomalie(ContexteDonnee,
                                projet,
                                ETypeAnomalieProjet.NonRespectContrainteDate,
                                I.T("Constraint error for elements @1 and @2|486",
                                ElementA.DescriptionElement,
                                ElementB.DescriptionElement),
                                this);
                        }
                    }
                }
            }

			return result;
		}


        /// <summary>
        /// Donne la liste des <see cref="CAnomalieProjet">anomalies</see> concernant ce lien
        /// </summary>
        [RelationFille(typeof(CAnomalieProjet), "LienConcerne")]
        [DynamicChilds("Concerning anomalies", typeof(CAnomalieProjet))]
        public CListeObjetsDonnees AnomaliesConcernant
        {
            get
            {
                return GetDependancesListe(CAnomalieProjet.c_nomTable, c_champId);
            }
        }


        /// <summary>
        /// Vérifie que le lien est cohérent
        /// </summary>
        /// <returns></returns>
        public CResultAErreur ControleCoherenceLien()
        {
            CResultAErreur result = CResultAErreur.True;
            if (ProjetA != null && ProjetB != null)
            {
                if (ProjetA.IsChildOf(ProjetB))
                    result.EmpileErreur(I.T("Link between @1 and @2 is invalide, because @1 is parent of @2|20072",
                        ProjetB.Libelle, ProjetA.Libelle));
                if (result && ProjetB.IsChildOf(ProjetA))
                    result.EmpileErreur(I.T("Link between @1 and @2 is invalide, because @1 is parent of @2|20072",
                        ProjetA.Libelle, ProjetB.Libelle));
            }
            if (ElementA != null && ElementB != null && result)
            {
                HashSet<IElementDeProjetPlanifiable> set = new HashSet<IElementDeProjetPlanifiable>();
                ElementA.FillDicPredecesseurs(set);
                if (set.Contains(ElementB))
                {
                    result.EmpileErreur(I.T("Link between @1 and @2 provokes a cyclic dependence|20073",
                        ElementA.DescriptionElement, ElementB.DescriptionElement));
                }
                if (result)
                {
                    set.Clear();
                    ElementB.FillDicSuccesseurs(set);
                    if (set.Contains(ElementA))
                    {
                        result.EmpileErreur(I.T("Link between @1 and @2 provokes a cyclic dependence|20073",
                            ElementA.DescriptionElement, ElementB.DescriptionElement));
                    }
                }
            }
            return result;
        }


       
    }
}
