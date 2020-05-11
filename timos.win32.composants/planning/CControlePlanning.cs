using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

using sc2i.common;
using sc2i.data;
using sc2i.workflow;
using sc2i.win32.common;

using timos.acteurs;
using timos.data;
using sc2i.drawing;
using timos.win32.composants.Properties;
using System.Drawing.Imaging;
using timos.win32.composants.planning;
using sc2i.win32.data;
using sc2i.data.dynamic;
using timos.win32.composants.gantt;
using sc2i.win32.navigation;
using sc2i.win32.data.dynamic;
using sc2i.win32.data.navigation;
using sc2i.expression;
using sc2i.formulaire.win32.editor;

namespace timos.win32.composants
{
	public partial class CControlePlanning : UserControl, IControlALockEdition
	{
		//Minimum de pixels pour une graduation de l'échelle
		private const double c_tailleMinGraduation = 25.0f;
		private const int c_margeGaucheEchelle = 13;

		private DateTime m_dateDebut = DateTime.Now.Date;
		private DateTime m_dateFin = DateTime.Now.Date.AddDays(1);

        private C2iTextBoxSelectionneForMenu m_menuSelectItemDeLigne = null;
		
		private int m_nHauteurLigne = 26;

		private IBasePlanning m_baseAffichee = null;

		private int m_nLigneMax = 0;

		//Indique le type de ressource que l'on est en train d'affecter
		private Type m_typeRessourcesAffectees = typeof(CActeur);

		private Color m_couleurFondElementAIntervention = Color.FromArgb(210, 210, 255);
		private Color m_couleurFondElementAInterventionSelectionne = Color.FromArgb(0, 0, 190);

		private bool m_bEnableAffichageDatesEnBas = true;

		private bool m_bAutoTooltip = true;

		private IElementAIntervention m_elementAInterventionSelectionne = null;

        private CToolStripDateTimePicker m_menuDatesIntervention = null;
        private CToolStripDateTimePicker m_menuDatesEchelle = null;

		/// <summary>
		/// Tâche à mettre en évidence
		/// </summary>
		private CIntervention m_tacheToHighlight = null;

		/// <summary>
		/// Information sur chaque tranche affichée
		/// </summary>
		public class CInfoTrancheAffichee : IObjetAToolTipModeleSpecial
		{
            private bool m_bHasConflit = false;

			public readonly ITranchePlanning Tranche;
			public readonly int Ligne;
			private Rectangle m_rect;
			public readonly ITypeRelationEntreePlanning_Ressource TypeRelation = null;
			public readonly Color CouleurIntervention;
            

            private IRessourceEntreePlanning m_ressource = null;


			public CInfoTrancheAffichee ( 
				ITranchePlanning tranche,
				ITypeRelationEntreePlanning_Ressource typeRelation,
                IRessourceEntreePlanning ressource,
				Rectangle rect,
				Color couleurIntervention,
				int nLigne)
			{
                m_ressource = ressource;
				Tranche = tranche;
				m_rect = rect;
				Ligne = nLigne;
				TypeRelation = typeRelation;
				CouleurIntervention = couleurIntervention;

			}

            //---------------------------------------------------------
            public Rectangle Rect
            {
                get
                {
                    return m_rect;
                }
                set
                {
                    m_rect = value;
                }
            }


			//---------------------------------------------------------
			public override bool Equals(object obj)
			{
				if (!(obj is CInfoTrancheAffichee))
					return false;
				CInfoTrancheAffichee autre = (CInfoTrancheAffichee)obj;
				if (autre.Tranche.Equals(Tranche))
				{
					if (autre.TypeRelation != null && autre.TypeRelation.Equals(TypeRelation) ||
						 autre.TypeRelation == null && TypeRelation == null)
                        if ( autre.Ressource == Ressource )
						    return true;    
				}
				return false;
			}

			//---------------------------------------------------------
			public override int GetHashCode()
			{
				if (TypeRelation == null)
					return Tranche.GetHashCode() * TypeRelation.GetHashCode();
				return Tranche.GetHashCode();
			}

            //---------------------------------------------------------
            public bool HasConflit
            {
                get
                {
                    return m_bHasConflit;
                }
                set
                {
                    m_bHasConflit = value;
                }
            }

			//---------------------------------------------------------
			public IRessourceEntreePlanning Ressource
			{
				get
				{
                    return m_ressource;
				}
				set
				{
					if ( TypeRelation != null )
					{
                        if (value == null)
                        {
                            if (m_ressource != null)
                                Tranche.EntreePlanning.DissocieRessource(TypeRelation, m_ressource);
                        }
                        else
                        {
                            if (m_ressource != null && m_ressource != value)
                            {
                                Tranche.EntreePlanning.DissocieRessource(TypeRelation, m_ressource);
                            }
                            if (value != null && TypeRelation.GetTypeRessource().IsAssignableFrom(value.GetType()))
                                Tranche.EntreePlanning.AssocieRessource(TypeRelation, value);

                        }
                        m_ressource = value;
					}
				}
			}

			//---------------------------------------------------------
			public object ObjetPourToolTip
			{
				get
				{
					if (Tranche is CFractionIntervention && Ressource is CActeur)
						return new CDonneeAffectationInterventionActeur(this);
					if (Tranche is CFractionIntervention && Ressource is CRessourceMaterielle)
						return new CDonneeAffectationInterventionRessource(this);
					if (TypeRelation != null)
						return TypeRelation;
					return Tranche;
				}
			}

			

		}


#region classes utilisées pour les infos bulle
		public class CDonneeInterventionPourBulle
		{
			private CInfoTrancheAffichee m_tranche;

			internal CDonneeInterventionPourBulle ( CInfoTrancheAffichee info )
			{
				m_tranche = info;
			}

			internal CInfoTrancheAffichee InfoTranche
			{
				get
				{
					return m_tranche;
				}
			}

			[DynamicField("Intervention part")]
			public CFractionIntervention FractionIntervention
			{
				get
				{
					return ( CFractionIntervention )InfoTranche.Tranche;
				}
			}

            public override bool Equals(object obj)
            {
                if (!(obj is CDonneeInterventionPourBulle))
                    return false;
                return ((CDonneeInterventionPourBulle)obj).InfoTranche.Equals(InfoTranche);
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
					
		}

		[DynamicClass("Planning : Assignment task/Member")]
		public class CDonneeAffectationInterventionActeur : CDonneeInterventionPourBulle
		{

			internal CDonneeAffectationInterventionActeur(CInfoTrancheAffichee info)
				: base(info)
			{
			}

			[DynamicField("Operator")]
			public CActeur Acteur
			{
				get
				{
					return (CActeur)InfoTranche.Ressource;
				}
			}
		}

		[DynamicClass("Planning : Planning : Assignment task/Resource")]
		public class CDonneeAffectationInterventionRessource : CDonneeInterventionPourBulle
		{

			internal CDonneeAffectationInterventionRessource(CInfoTrancheAffichee info)
				: base(info)
			{
			}

			[DynamicField("Resource")]
			public CRessourceMaterielle Ressource
			{
				get
				{
					return (CRessourceMaterielle)InfoTranche.Ressource;
				}
			}
		}
		#endregion

		/// <summary>
		/// Information sur chaque ligne
		/// </summary>
		public class CInfoLigne : IObjetAToolTipModeleSpecial
		{
			public readonly IRessourceEntreePlanning Ressource;
			public readonly IElementAIntervention ElementAIntervention;
            public readonly ITypeRelationEntreePlanning_Ressource RelationTypeRessource;
			
			public CInfoLigne(
                IRessourceEntreePlanning res, 
                IElementAIntervention elt,
                ITypeRelationEntreePlanning_Ressource relationTypeRessource)
			{
				Ressource = res;
				ElementAIntervention = elt;
                RelationTypeRessource = relationTypeRessource;
			}

			public bool IsOkForTranche(CInfoTrancheAffichee tranche)
			{
				return false;
				/*if (tranche == null)
					return false;
				if (tranche.TypeRelation == null)
					return false;
				if (  m_trancheTestOk== null || !tranche.Tranche.Equals ( m_trancheTestOk.Tranche ) ||
					!tranche.TypeRelation.Equals ( m_trancheTestOk.TypeRelation ) )
				{
					m_trancheTestOk = tranche;
					if (Ressource != null && Ressource.CanBeUseFor(tranche.TypeRelation, tranche.Tranche.EntreePlanning))
						m_bOkForTrancheSel = true;
					else
						m_bOkForTrancheSel = false;
				}
				return m_bOkForTrancheSel;*/
			}

			public object ObjetPourToolTip
			{
				get
				{
					if (Ressource != null)
						return Ressource;
					if (ElementAIntervention != null)
						return ElementAIntervention;
					return null;
				}
			}

		}


		private class CTrancheDragDrop : ITranchePlanning
		{
			private CIntervention m_intervention = null;
			private CInfoTrancheAffichee m_infoTranche;
			private IRessourceEntreePlanning m_ressource = null;
			private DateTime m_dateDebut;
			private DateTime m_dateFin;

			public CTrancheDragDrop(CInfoTrancheAffichee tranche)
			{
				m_infoTranche = tranche;
				m_dateDebut = tranche.Tranche.DateDebut;
				m_dateFin = tranche.Tranche.DateFin;
			}

			public CTrancheDragDrop ( CIntervention intervention )
			{
				m_intervention = intervention;
				m_dateDebut = DateDebut;
				m_dateFin = m_dateDebut.AddHours ( Math.Max(intervention.DureePrevisionnelle,1));
			}

			//-----------------------------------------
			public DateTime DateDebut
			{
				get
				{
					return m_dateDebut;
				}
				set
				{
					m_dateDebut = value;
				}
			}

			//-----------------------------------------
			public DateTime DateFin
			{
				get
				{
					return m_dateFin;
				}
				set
				{
					m_dateFin = value;
				}
			}

			//-----------------------------------------
			public CIntervention Intervention
			{
				get
				{
					return m_intervention;
				}
			}

			//-----------------------------------------
			public Type TypeRessourceAttendu
			{
				get
				{
					if ( m_infoTranche.TypeRelation != null )
						return m_infoTranche.TypeRelation.GetTypeRessource();
					return null;
				}
			}

			//-----------------------------------------
			public IRessourceEntreePlanning Ressource
			{
				get
				{
					return m_ressource;
				}
				set
				{
					m_ressource = value;
				}
			}		
					

			//-----------------------------------------
			public IEntreePlanning EntreePlanning
			{
				get
				{
					if ( m_infoTranche != null )
						return m_infoTranche.Tranche.EntreePlanning;
					if ( m_intervention != null )
						return m_intervention;
					return null;
				}
			}

			#region IEntreeAgenda Membres

			public string Libelle
			{
				get { return ""; }
			}

			public bool SansHoraire
			{
				get { return true; }
			}

			public CEtatEntreeAgenda Etat
			{
				get { return new CEtatEntreeAgenda(EtatEntreeAgenda.AFaire); }
			}

			public string Commentaires
			{
				get { return ""; }
			}

			public string IdAppliExterne
			{
				get { return ""; }
			}

			public string IdExterne
			{
				get { return ""; }
			}

			#endregion
		}


		private CInfoTrancheAffichee m_infoTrancheSelectionnee = null;

		/// <summary>
		/// Tranche->List de cinfoTrancheAffichee
		/// </summary>
		private Dictionary<ITranchePlanning, List<CInfoTrancheAffichee>> m_tranchesToInfosAffichage = new Dictionary<ITranchePlanning, List<CInfoTrancheAffichee>>();
		
		/// <summary>
		/// Liste des info tranche affichées (un par pavé)
		/// </summary>
		private List<CInfoTrancheAffichee> m_listeTranchesAffichees = new List<CInfoTrancheAffichee>();
		
		/// <summary>
		/// Informations sur les lignes
		/// </summary>
		private Dictionary<int, CInfoLigne> m_infoLignes = new Dictionary<int, CInfoLigne>();


		/// <summary>
		/// Cache des tranches des ressources pour la période affichée
		/// </summary>
		private Dictionary<IRessourceEntreePlanning, CTrancheHoraire[]> m_cacheTranchesRessources = new Dictionary<IRessourceEntreePlanning,CTrancheHoraire[]>();

		private enum EUniteDuree
		{
			Minutes=0,
			Heures,
			Jour
		}

		private long[] m_nConversionUniteToMinute = new long[]
			{
			1,
			60,
			60*24};

		//Nombre d'heures par pixel
		private double m_fEchelle = 1;
		private TimeSpan m_ecartGraduations = new TimeSpan(1, 0, 0);
		private DateTime m_dateStartGraduations = DateTime.Now;

		private Dictionary<int, Image> m_cacheImages = new Dictionary<int, Image>();
		
		public CControlePlanning()
		{
			InitializeComponent();
			m_panelDessin.AllowDrop = true;
            m_panelLignes.AllowDrop = true;
            m_couleurFondElementAIntervention = Color.FromArgb(210, 255, 210);

            try
            {
                if (!DesignMode)
                {
                    PrepareMenuLigne(m_menuGestionSites, typeof(CSite), "Libelle");
                    PrepareMenuLigne(m_menuGestionActeurs, typeof(CActeur), "IdentiteComplete");
                    PrepareMenuLigne(m_menuGestionResources, typeof(CRessourceMaterielle), "Libelle");

                    PrepareMenuIntervention();

                    PrepareMenuEchelle();
                }
            }
            catch { }
		}

        //-------------------------------------------------------------------------
        //Crée les menus pour ajouter des sites, des acteurs ou des ressources
        private void PrepareMenuLigne(ToolStripMenuItem itemParent,
            Type typeElements,
            string strProprieteLibelle)
        {
            itemParent.DropDownItems.Clear();



            C2iTextBoxSelectionneForMenu txtSelect = new C2iTextBoxSelectionneForMenu();
            itemParent.DropDownItems.Add(txtSelect);
            txtSelect.TextBoxSelection.InitForSelect(typeElements, strProprieteLibelle, false);
            txtSelect.OnSelectObject += new ObjetDonneeEventHandler(menuLignes_OnSelectObject);

            CListeObjetsDonnees lstObjets = new CListeObjetsDonnees(CSc2iWin32DataClient.ContexteCourant, typeof(CListeEntites));
            lstObjets.Filtre = new CFiltreData(CListeEntites.c_champTypeElements + "=@1" ,
                typeElements.ToString());
            if (lstObjets.Count > 0)
            {
                ToolStripSeparator sep = new ToolStripSeparator();
                itemParent.DropDownItems.Add(sep);
                foreach (CListeEntites lst in lstObjets)
                {
                    ToolStripMenuItem itemListe = new ToolStripMenuItem(lst.Libelle);
                    itemListe.Tag = lst;
                    itemListe.Click += new EventHandler(itemListe_Click);
                    itemParent.DropDownItems.Add(itemListe);
                }
            }

            CListeObjetsDonnees lstFiltre = new CListeObjetsDonnees(CSc2iWin32DataClient.ContexteCourant, typeof(CFiltreDynamiqueInDb));
            lstFiltre.Filtre = new CFiltreData(CFiltreDynamiqueInDb.c_champTypeElements + "=@1",
                typeElements.ToString());
            if (lstFiltre.Count > 0)
            {
                ToolStripMenuItem menuAddByFiltre = new ToolStripMenuItem(I.T("Add by filter|20026"));
                ToolStripMenuItem menuRemoveByFiltre = new ToolStripMenuItem(I.T("Remove by filter|20027"));
                itemParent.DropDownItems.Add(new ToolStripSeparator());
                itemParent.DropDownItems.Add(menuAddByFiltre);
                itemParent.DropDownItems.Add(menuRemoveByFiltre);
                foreach (CFiltreDynamiqueInDb filtre in lstFiltre)
                {
                    ToolStripMenuItem itemAddByFiltre = new ToolStripMenuItem(filtre.Libelle);
                    itemAddByFiltre.Tag = filtre;
                    itemAddByFiltre.Click += new EventHandler(itemAddByFiltre_Click);
                    menuAddByFiltre.DropDownItems.Add(itemAddByFiltre);

                    ToolStripMenuItem itemRemoveByFiltre = new ToolStripMenuItem(filtre.Libelle);
                    itemRemoveByFiltre.Tag = filtre;
                    itemRemoveByFiltre.Click += new EventHandler(itemRemoveByFiltre_Click);
                    menuRemoveByFiltre.DropDownItems.Add(itemRemoveByFiltre);
                }
            }

            itemParent.DropDownItems.Add(new ToolStripSeparator());

            ToolStripMenuItem itemHideAll = new ToolStripMenuItem(I.T("Hide all|20016"));
            itemHideAll.Tag = typeElements;
            itemHideAll.Click += new EventHandler(itemHideAll_Click);
            itemParent.DropDownItems.Add(itemHideAll);

            

        }

       
        //-------------------------------------------------------------------------
        private void PrepareMenuIntervention()
        {
            if (m_menuRClickCalendrier.Items.Contains(m_menuARemplacerParDatesInter))
            {
                m_menuDatesIntervention = new CToolStripDateTimePicker();
                m_menuRClickCalendrier.Items.Insert(
                    m_menuRClickCalendrier.Items.IndexOf(m_menuARemplacerParDatesInter),
                    m_menuDatesIntervention);
                m_menuDatesIntervention.OnValideDates += new EventHandler(menuDates_OnValideDates);
                m_menuRClickCalendrier.Items.Remove(m_menuARemplacerParDatesInter);
            }
        }


        //-------------------------------------------------------------------------
        private void PrepareMenuEchelle()
        {
            if (m_menuRClickEchelle.Items.Contains(m_menuARemplacerParDatesEchelle))
            {
                m_menuDatesEchelle = new CToolStripDateTimePicker();
                m_menuRClickEchelle.Items.Insert(
                    m_menuRClickEchelle.Items.IndexOf(m_menuARemplacerParDatesEchelle),
                    m_menuDatesEchelle);
                m_menuDatesEchelle.OnValideDates += new EventHandler(m_menuDatesEchelle_OnValideDates);
                m_menuRClickEchelle.Items.Remove(m_menuARemplacerParDatesEchelle);
            }
        }

        void m_menuDatesEchelle_OnValideDates(object sender, EventArgs e)
        {
            DateDebut = m_menuDatesEchelle.StartDate;
            DateFin = m_menuDatesEchelle.EndDate;
            Refresh();
            m_menuRClickEchelle.Hide();
        }

        

        

		/// <summary>
		/// Dernier point utilisé lors d'une opération de drag and drop
		/// </summary>
		private Point m_lastPointDragDrop = new Point ( 0, 0 );

			
		#region Gestion de l'échelle
		public event EventHandler OnChangeBornesDates = null;
		//-----------------------------------------------
		private void CalculeEchelle( DateTime dateDebut, DateTime dateFin )
		{
			//Calcule l'échelle
			TimeSpan sp = dateFin-dateDebut;
			double fNbHeures = sp.TotalHours;
			if ( fNbHeures < 0 )
				fNbHeures = 1;
			m_fEchelle = fNbHeures / (double)(m_panelDessin.ClientSize.Width-c_margeGaucheEchelle*2);

			//Incréments possibles : Heures, 1/2j, j, sem, mois
			TimeSpan[] increments = new TimeSpan[]
			{
				new TimeSpan ( 1, 0, 0 ),
				new TimeSpan ( 2, 0, 0 ),
				new TimeSpan ( 4, 0, 0 ),
				new TimeSpan ( 12, 0, 0 ),
				new TimeSpan ( 1, 0, 0, 0 ),
				new TimeSpan ( 7, 0, 0, 0 )
			};
			TimeSpan spIncrement = increments[0];

			int nIndexIncrement = 0;
			while (
				spIncrement.TotalHours / m_fEchelle < c_tailleMinGraduation && nIndexIncrement < increments.Length-1)
			{
				nIndexIncrement++;
				spIncrement = increments[nIndexIncrement];
			}
			m_ecartGraduations = spIncrement;
			m_dateStartGraduations = GetDateStartGraduation(DateDebut);

		}

		//-----------------------------------------------
		private DateTime GetDateStartGraduation(DateTime dateDebut)
		{
			dateDebut = new DateTime(
				dateDebut.Year,
				dateDebut.Month,
				dateDebut.Day,
				dateDebut.Hour,
				0, 0);
			DateTime dtRetour = dateDebut;
			if (m_ecartGraduations.TotalHours <= 24)
			{
				int nNbHeures = (int)m_ecartGraduations.TotalHours;
				//Travaille sur les heures
				int nHour = dtRetour.Hour;
				if (nHour % nNbHeures != 0)
				{
					nHour = (int)(((int)(nHour / m_ecartGraduations.TotalHours + 1)) * m_ecartGraduations.TotalHours);
				}
				nHour = nHour % 24;
				dtRetour = new DateTime(
					dtRetour.Year,
					dtRetour.Month,
					dtRetour.Day,
					nHour,
					0, 0);
				if (nHour < dateDebut.Hour)
					dtRetour = dtRetour.AddDays(1);
			}
			else
			{
				//Travaille sur les jours
				dtRetour = dtRetour.Date;
				if (m_ecartGraduations.TotalDays > 6)
					//Travaille en semaine, donc commence au lundi
					while (dtRetour.DayOfWeek != DayOfWeek.Monday)
						dtRetour = dtRetour.AddDays(1);
			}
			return dtRetour;
		}

		//----------------------------------------------
		private DateTime GetDateTime ( int nX )
		{
			nX -= c_margeGaucheEchelle;
			double fHeures = (double)nX * m_fEchelle;
			return DateDebut.AddHours ( fHeures );
		}

		//-----------------------------------------------
		private void StockTrancheAffichee(CInfoTrancheAffichee info)
		{
			if (!m_tranchesToInfosAffichage.ContainsKey(info.Tranche))
				m_tranchesToInfosAffichage[info.Tranche] = new List<CInfoTrancheAffichee>();
			List<CInfoTrancheAffichee> lst = m_tranchesToInfosAffichage[info.Tranche];
			if (lst.Contains(info))
				lst.Remove(info);
			lst.Add(info);
			if (m_listeTranchesAffichees.Contains(info))
				m_listeTranchesAffichees.Remove(info);
			m_listeTranchesAffichees.Add(info);
		}

        //-----------------------------------------------
        private Point GetLogicalPoint ( Point pt )
        {
            return new Point ( pt.X, pt.Y + m_scroll.Value);
        }

		//-----------------------------------------------
		private void CalculeDessin()
		{
            using (CWaitCursor waiter = new CWaitCursor())
            {
                int nHeight = m_panelDessin.Height;
                //Calcule l'échelle affichée utilisée
                CalculeEchelle(DateDebut, DateFin);

                DateTime dateStartGrad = GetDateStartGraduation(DateDebut);
                DateTime date = dateStartGrad;

                if (m_baseAffichee != null)
                {
                    m_nLigneMax = 0;

                    //Affiche les entrées des éléments de planning
                    List<ITranchePlanning> lstElts = m_baseAffichee.GetTranchesForElementsAInterventionBetween(DateDebut, DateFin);
                    lstElts.Sort(new CSorterTranchesPlanning());

                    m_listeTranchesAffichees.Clear();
                    m_infoLignes.Clear();
                    m_tranchesToInfosAffichage.Clear();

                    int nLigne = -1;
                    m_nLigneMax = -1;
                    foreach (IElementAIntervention eltAIntervention in m_baseAffichee.ElementsAIntervention)
                    {
                        bool bHasLignes = false;
                        int nLigneBase = m_nLigneMax + 1;
                        List<CInfoTrancheAffichee> lstTranchesElt = new List<CInfoTrancheAffichee>();
                        foreach (ITranchePlanning tranche in lstElts)
                        {
                            if (tranche.EntreePlanning.ElementLiePrincipal.Equals(eltAIntervention))
                            {
                                bHasLignes = true;
                                ArrayList lstRelTypesRessources = new ArrayList();
                                lstRelTypesRessources.Add(null);//Entrée globale

                                //Affichage des resources à affecter
                                foreach (ITypeRelationEntreePlanning_Ressource rel in tranche.EntreePlanning.GetRelationsRessourceAAffecter(m_typeRessourcesAffectees))
                                {
                                    if (rel.AfficherManquantDansPlanning)
                                    {
                                        IRessourceEntreePlanning[] ressources = tranche.EntreePlanning.GetRessourcesAssociees(rel);
                                        if (ressources == null || ressources.Length == 0)
                                            lstRelTypesRessources.Add(rel);
                                    }
                                }

                                foreach (ITypeRelationEntreePlanning_Ressource rt in lstRelTypesRessources)
                                {
                                    nLigne = nLigneBase;
                                    foreach (CInfoTrancheAffichee infoBr in lstTranchesElt)
                                    {
                                        if (CUtilEntreePlanning.Intersect(infoBr.Tranche, tranche.DateDebut, tranche.DateFin))
                                            nLigne++;
                                    }
                                    Rectangle rcTranche = CalcRectTranche(tranche, nLigne);
                                    CInfoTrancheAffichee info = new CInfoTrancheAffichee(
                                        tranche,
                                        rt,
                                        null,
                                        rcTranche,
                                        tranche.EntreePlanning.Couleur,
                                        nLigne);
                                    lstTranchesElt.Add(info);
                                    StockTrancheAffichee(info);
                                    m_nLigneMax = Math.Max(nLigne, m_nLigneMax);
                                    if (!m_infoLignes.ContainsKey(nLigne))
                                        m_infoLignes[nLigne] = new CInfoLigne(null, eltAIntervention, rt);
                                }
                            }
                        }
                        if (!bHasLignes)
                        {
                            nLigne = nLigneBase;
                            if (!m_infoLignes.ContainsKey(nLigne))
                                m_infoLignes[nLigne] = new CInfoLigne(null, eltAIntervention, null);

                            m_nLigneMax = Math.Max(nLigne, m_nLigneMax);

                        }

                        //Pas de lignes de données pour cet élément, 
                        //Ajoute une ligne vide
                    }

                    //Affiche les entrées des ressources
                    lstElts = m_baseAffichee.GetOccupationsForRessourcesBetween(DateDebut, DateFin);
                    lstElts.Sort(new CSorterTranchesPlanning());
                    nLigne = m_nLigneMax + 1;
                    int nMargeHautRessource = m_panelEchelle.Height;
                    foreach (IRessourceEntreePlanning ressource in m_baseAffichee.Ressources)
                    {
                        string strRes = ressource.Libelle;
                        int nLigneBase = nLigne;
                        m_nLigneMax = nLigne;
                        List<CInfoTrancheAffichee> tranchesRessources = new List<CInfoTrancheAffichee>();
                        foreach (ITranchePlanning tranche in new ArrayList(lstElts))
                        {
                            nLigne = nLigneBase;
                            ITypeRelationEntreePlanning_Ressource[] typesRelations = null;
                            typesRelations = tranche.EntreePlanning.GetTypesRelationsAssociees(ressource);
                            bool bAdd = typesRelations != null && typesRelations.Length > 0;
                            if (!bAdd)
                            {
                                bAdd = tranche.EntreePlanning.Occupe(ressource);
                            }
                            if (bAdd)
                            {
                                foreach (CInfoTrancheAffichee infoBr in tranchesRessources)
                                {
                                    string strR1, strR2;
                                    strR1 = "";// infoBr.Ressource.Libelle;
                                    strR2 = ressource.Libelle;
                                    /*if (!infoBr.Tranche.Equals ( tranche ) &&  infoBr.Ressource.Equals(ressource) && CUtilEntreePlanning.Intersect(infoBr.Tranche, tranche.DateDebut, tranche.DateFin))
                                        nLigne++;*/
                                }
                                ITypeRelationEntreePlanning_Ressource typeRelation = null;
                                int nIndexRelation = 0;
                                if (typesRelations.Length > 0)
                                    typeRelation = typesRelations[0];
                                do
                                {
                                    CInfoTrancheAffichee info = new CInfoTrancheAffichee(
                                        tranche,
                                        typeRelation,
                                        ressource,
                                        CalcRectTranche(tranche, nLigne),
                                        tranche.EntreePlanning.Couleur,
                                        nLigne);
                                    StockTrancheAffichee(info);
                                    tranchesRessources.Add(info);
                                    if (!m_infoLignes.ContainsKey(nLigne))
                                        m_infoLignes[nLigne] = new CInfoLigne(ressource, null, null);
                                    m_nLigneMax = Math.Max(nLigne, m_nLigneMax);
                                    nIndexRelation++;
                                    typeRelation = null;
                                    if (nIndexRelation < typesRelations.Length)
                                        typeRelation = typesRelations[nIndexRelation];
                                    //lstElts.Remove(tranche);
                                }
                                while (typeRelation != null);
                            }
                        }
                        m_nLigneMax = Math.Max(nLigne, m_nLigneMax);
                        if (!m_infoLignes.ContainsKey(nLigne))
                            m_infoLignes[nLigne] = new CInfoLigne(ressource, null, null);
                        nLigne = m_nLigneMax + 1;
                    }
                }
                if (m_infoTrancheSelectionnee != null)
                {
                    int nIndex = m_listeTranchesAffichees.IndexOf(m_infoTrancheSelectionnee);
                    if (nIndex >= 0)
                    {
                        m_infoTrancheSelectionnee = null;
                        SelectTranche(m_listeTranchesAffichees[nIndex]);
                    }
                }

                CalculeConflits();


                int nTotalHeight = (m_infoLignes.Count + 1) * m_nHauteurLigne;
                m_scroll.Visible = nTotalHeight > m_panelDessin.Height;
                m_scroll.Minimum = 0;
                m_scroll.Maximum = Math.Max(0, nTotalHeight - m_panelDessin.Height);
            }
		}

        //----------------------------------------------
        private void CalculeConflits()
        {
            Dictionary<IRessourceEntreePlanning, List<CInfoTrancheAffichee>> dicResToTranche = new Dictionary<IRessourceEntreePlanning, List<CInfoTrancheAffichee>>();
            foreach (KeyValuePair<ITranchePlanning, List<CInfoTrancheAffichee>> kv in m_tranchesToInfosAffichage)
            {
                foreach (CInfoTrancheAffichee tranche in kv.Value)
                    if (tranche.Ressource != null)
                    {
                        List<CInfoTrancheAffichee> lstTranches = null;
                        if (!dicResToTranche.TryGetValue(tranche.Ressource, out lstTranches))
                        {
                            lstTranches = new List<CInfoTrancheAffichee>();
                            dicResToTranche[tranche.Ressource] = lstTranches;
                        }
                        lstTranches.Add(tranche);
                    }
            }
            foreach (KeyValuePair<IRessourceEntreePlanning, List<CInfoTrancheAffichee>> kv in dicResToTranche)
            {
                List<CInfoTrancheAffichee> lstTranchesConflictuables = kv.Value;
                for (int nTranche1 = 0; nTranche1 < lstTranchesConflictuables.Count; nTranche1++)
                {
                    for (int nTranche2 = nTranche1 + 1; nTranche2 < lstTranchesConflictuables.Count; nTranche2++)
                    {
                        Rectangle rct1 = lstTranchesConflictuables[nTranche1].Rect;
                        Rectangle rct2 = lstTranchesConflictuables[nTranche2].Rect;
                        if (rct1.IntersectsWith(rct2))
                        {
                            lstTranchesConflictuables[nTranche1].HasConflit = true;
                            lstTranchesConflictuables[nTranche2].HasConflit = true;
                        }
                    }
                }
            }
        }

        //----------------------------------------------
        public int HauteurLigne
        {
            get
            {
                return m_nHauteurLigne;
            }
            set
            {
                m_nHauteurLigne = Math.Max(value, 10);
                Refresh();
            }
        }

		//----------------------------------------------
		/// <summary>
		/// Retourne la position x d'une date
		/// </summary>
		/// <param name="dt"></param>
		/// <param name="dateDebut"></param>
		/// <returns></returns>
		private int GetX(DateTime dt, DateTime dateDebut, DateTime dateDebutGraduation)
		{
			TimeSpan sp = dt - dateDebutGraduation;
			TimeSpan ecartDebut = dateDebutGraduation - dateDebut;
			return ( int )(sp.TotalHours / m_fEchelle + m_nHauteurLigne + ecartDebut.TotalHours / m_fEchelle);
		}

		//----------------------------------------------
		private DateTime GetArrondi(DateTime dt)
		{
			long tickEcart = m_ecartGraduations.Ticks/4;
			if (tickEcart > new TimeSpan(1, 0, 0, 0).Ticks)
				tickEcart = new TimeSpan(1, 0, 0, 0).Ticks;
			return new DateTime(((long)dt.Ticks / tickEcart) * tickEcart);
		}
		
		//-----------------------------------------------
		private void DrawEchelle ( 
			Graphics g,
			DateTime dateDebut,
			DateTime dateFin)
		{
			int nYBas = m_panelEchelle.ClientRectangle.Height;
			int nHeight = nYBas / 3;

			CalculeEchelle( dateDebut, dateFin );

			Brush br = new SolidBrush(m_panelEchelle.BackColor);
			Rectangle rc = m_panelEchelle.ClientRectangle;
			rc.Offset(-rc.Left, -rc.Top);
			g.FillRectangle(br, rc);
			br.Dispose();

			DateTime dateStartGrad = GetDateStartGraduation(dateDebut);
			DateTime date = dateStartGrad;
			Font ft = new Font("Arial", 7);
			while ( date < dateFin )
			{
				int nPos = GetX ( date, dateDebut, dateStartGrad );
				int nHeightLigne = nHeight;
				if (date.Hour != 0)
					nHeightLigne /= 2;
				g.DrawLine(Pens.Black, new Point(nPos, nYBas - nHeightLigne), new Point(nPos, nYBas));
				
				string strText = "";
				if (date.Hour == 0)
					strText = date.ToString("dd/MM");
				else
					strText = date.ToString("HH")+"h";
				SizeF sizeText = g.MeasureString (strText, ft);
				Point pt = new Point(nPos - (int)sizeText.Width / 2, nYBas - nHeightLigne - (int)sizeText.Height);
				g.DrawString(strText, ft, Brushes.Black, pt);

				//Dessine la ligne dans le calendrier
				Pen crayonTrait = new Pen ( Color.LightGray );
				crayonTrait.DashStyle = DashStyle.DashDot;


				date = date.Add(m_ecartGraduations);
			}
			ft.Dispose();
		}

		private bool m_bDragEchelleEnCours = false;
		private Point m_ptStartDragEchelle = new Point(-1, -1);
		private double m_fPointStartDragEchelle = 1;
		private void m_panelEchelle_MouseDown(object sender, MouseEventArgs e)
		{
			if ( e.Button == MouseButtons.Right )
			{
				m_ptStartDragEchelle = new Point( e.X, e.Y );
				Rectangle rc = m_panelEchelle.ClientRectangle;
				m_fPointStartDragEchelle = (double)(e.X - rc.Left)/(double)rc.Width;
			}
		}

		private void m_panelEchelle_MouseMove(object sender, MouseEventArgs e)
		{
			if (!m_bDragEchelleEnCours && e.Button == MouseButtons.Right)
			{
				if ( Math.Abs ( e.X - m_ptStartDragEchelle.X ) > 3 )
				{
					m_bDragEchelleEnCours = true;
					m_panelEchelle.Capture = true;
				}
			}
            DateTime dtToolTip = GetArrondi(GetDateTime ( e.X ));

            m_tooltip.SetToolTip(m_panelEchelle, dtToolTip.ToShortDateString() + 
                (dtToolTip.Date != dtToolTip?" " +dtToolTip.ToShortTimeString():""));

			if (m_bDragEchelleEnCours)
			{
				Rectangle rc = m_panelEchelle.ClientRectangle;
				double fPointDragEchelle = (double)(e.X - rc.Left) / (double)rc.Width;
				if (fPointDragEchelle <= 0)
					return;
				double fMult = fPointDragEchelle / m_fPointStartDragEchelle;
				//Calcule la nouvelle date de fin
				TimeSpan sp = DateFin - DateDebut;
				DateTime dtFin = DateDebut.AddHours(sp.TotalHours / fMult);
				Graphics g = m_panelEchelle.CreateGraphics();
				DrawEchelle(g, DateDebut, dtFin);
				g.Dispose();
			}
		}


		private void m_panelEchelle_MouseUp(object sender, MouseEventArgs e)
		{
			if (m_bDragEchelleEnCours)
			{
				m_bDragEchelleEnCours = false;
				m_panelEchelle.Capture = false;
				Rectangle rc = m_panelEchelle.ClientRectangle;

				double fPointDragEchelle = (double)(e.X - rc.Left) / (double)rc.Width;
				if (fPointDragEchelle <= 0)
					return;
				double fMult = fPointDragEchelle / m_fPointStartDragEchelle;
				//Calcule la nouvelle date de fin
				TimeSpan sp = DateFin - DateDebut;
				DateFin = DateDebut.AddHours(sp.TotalHours / fMult);
				m_timerSendEventChangeDate.Stop();
				m_timerSendEventChangeDate.Start();
				Refresh();
			}
			else
			{
				DateTime dt = GetDateTime(e.X);
				m_menuZoomOn.Text = I.T( "Zoom on @1|117", dt.ToShortDateString());
				m_menuZoomOn.Tag = dt;
				m_menuPopupInfoLigne.DropDownItems.Clear();
				CWin32Traducteur.Translate(m_menuRClickEchelle);
                m_menuDatesEchelle.StartDate = DateDebut;
                m_menuDatesEchelle.EndDate = DateFin;
				m_menuRClickEchelle.Show(m_panelEchelle, new Point(e.X, e.Y));
			}
			
		}
		#endregion

		private void m_wndEchelle_Paint(object sender, PaintEventArgs e)
		{
			//if ( !DesignMode )
			DrawEchelle(e.Graphics, DateDebut, DateFin);
		}


		#region dessin du calendrier
		//----------------------------------------------------
		private DateTime m_lastDateTimeDrawDebut = DateTime.Now;
		private DateTime m_lastDateTimeDrawEnd = DateTime.Now;
		private void DrawCalendrier(
			Graphics gCalendrier)
		{
			if (DesignMode)
				return;
            m_bIsDrawingCalendrier = true;
			int nHeight = m_panelDessin.Height;
			
			Rectangle rc = m_panelDessin.ClientRectangle;
			rc.Offset ( -rc.Left, - rc.Top );
			gCalendrier.FillRectangle ( Brushes.White, rc );

			if (m_lastDateTimeDrawDebut != DateDebut ||
				m_lastDateTimeDrawEnd != DateFin)
				m_cacheTranchesRessources.Clear();

			m_lastDateTimeDrawDebut = DateDebut;
			m_lastDateTimeDrawEnd = DateFin;

            Matrix oldM = gCalendrier.Transform;
            gCalendrier.TranslateTransform(0, -m_scroll.Value);

			
			
			//Dessine les lignes de séparation;
			object lastObj = null;
			Pen penLigne = new Pen ( Brushes.LightGray );
			penLigne.DashStyle = DashStyle.Dot;
			 bool bFirstRessource = true;
            int nStart = Math.Max ( m_scroll.Value / m_nHauteurLigne, 0 );
            int nEnd = Math.Min ( m_nLigneMax, nStart + m_panelDessin.Height/m_nHauteurLigne+1);
			for (int nLigne = nStart; nLigne <= nEnd; nLigne++)
			{
				if (m_infoLignes.ContainsKey(nLigne))
				{
					int nY = nLigne * m_nHauteurLigne;
					CInfoLigne info = m_infoLignes[nLigne];
					Color couleur = m_couleurFondElementAIntervention;
					if (info.Ressource != null)
						couleur = CUtilEntreePlanning.GetCouleurTypeRessource(info.Ressource.GetType());
                    if (nLigne % 2 != 0)
                        couleur = CUtilCouleur.GetCouleurAlternative(couleur);
					Brush br = new SolidBrush(couleur);
					gCalendrier.FillRectangle(br, 0, nY, m_panelDessin.Width, m_nHauteurLigne);
					br.Dispose();
					Pen penTmp = penLigne;
					if (info.Ressource != null && lastObj != null &&!typeof(IRessourceEntreePlanning).IsAssignableFrom(lastObj.GetType()))
					{
						penTmp = new Pen(Color.Black, 2);
					}
					if ( (info.Ressource != null && !info.Ressource.Equals(lastObj)) ||
						 (info.ElementAIntervention != null && !info.ElementAIntervention.Equals(lastObj)) )
					{
						
						gCalendrier.DrawLine(penTmp, 0, nY, m_panelDessin.Width, nY);
					}
					if (info.Ressource != null && bFirstRessource)
					{
						bFirstRessource = false;
					}
					if ( penTmp != penLigne )
						penTmp.Dispose();
					lastObj = info.Ressource == null ? (object)info.ElementAIntervention : (object)info.Ressource;
					if (info.Ressource != null && m_ecartGraduations.TotalHours < 8)
					{
						CTrancheHoraire[] tranches = null;
						if (m_cacheTranchesRessources.ContainsKey(info.Ressource))
							tranches = m_cacheTranchesRessources[info.Ressource];
						else
						{
							tranches = info.Ressource.GetHoraires(DateDebut, DateFin);
							m_cacheTranchesRessources[info.Ressource] = tranches;
						}
						foreach (CTrancheHoraire tranche in tranches)
						{
							if (tranche.TypeOccupationHoraire != null)
							{
                                //int nXStart = GetX(tranche.DateHeureDebut, m_dateDebut, m_dateFin);
                                int nXStart = GetX(tranche.DateHeureDebut, DateDebut, m_dateStartGraduations);
								int nXFin = GetX(tranche.DateHeureFin, DateDebut, m_dateStartGraduations);
								Brush brCal = new SolidBrush(Color.FromArgb(32, Color.FromArgb(tranche.TypeOccupationHoraire.Couleur)));
								gCalendrier.FillRectangle(brCal, nXStart, nY, nXFin - nXStart, m_nHauteurLigne);
								brCal.Dispose();
							}
						}
					}
				}
			}
			penLigne.Dispose();

			DateTime date = m_dateStartGraduations;
			Font ft = new Font("Arial", 7);
			Pen penHeure = new Pen(Color.LightGray);
			penHeure.DashStyle = DashStyle.Dot;
			Pen penJour = new Pen(Color.Black);
			penJour.DashStyle = DashStyle.Dot;
			while (date < DateFin)
			{
				int nPos = GetX(date, DateDebut, m_dateStartGraduations);
				Pen pen = date.Hour == 0 ? penJour : penHeure;
				gCalendrier.DrawLine(pen, new Point(nPos, m_scroll.Value), new Point(nPos, m_scroll.Value+m_panelDessin.Height));
				date = date.Add(m_ecartGraduations);
			}
			ft.Dispose();
			penJour.Dispose();
			penHeure.Dispose();

			try
			{
				foreach (CInfoTrancheAffichee info in m_listeTranchesAffichees)
				{
					DrawTranche(gCalendrier, info);
				}
			}
			catch
			{ }

            gCalendrier.Transform = oldM;
            m_bIsDrawingCalendrier = false;
		}

		private void DrawEntetesLignes ( Graphics g )
		{
            Matrix oldM = g.Transform;
            g.TranslateTransform(0, -m_scroll.Value);
			//Dessine les lignes de séparation;
			object lastObj = null;
			Pen penLigne = new Pen ( Brushes.LightGray );
			penLigne.DashStyle = DashStyle.Dot;
			Font ft = new Font ("Arial", 7);
			bool bHasSelectionElementATache = false;
			Color couleurTexte = Color.Black;
			for (int nLigne = 0; nLigne <= m_nLigneMax; nLigne++)
			{
				if (m_infoLignes.ContainsKey(nLigne))
				{
					CInfoLigne info = m_infoLignes[nLigne];
                    Image img = null;
					string strLib = "";
					Color couleur = m_couleurFondElementAIntervention;
                    couleurTexte = GetCouleurVisibleSur(couleur);
					if (info.Ressource != null )
					{
						if (!info.Ressource.Equals(lastObj))
						{
							lastObj = info.Ressource;
							strLib = info.Ressource.Libelle;
							if (info.Ressource is CRessourceMaterielle)
								strLib += "\r\n   " + ((CRessourceMaterielle)info.Ressource).Emplacement.Libelle;
							
						}
						couleur = CUtilEntreePlanning.GetCouleurTypeRessource(info.Ressource.GetType());
						couleurTexte = GetCouleurVisibleSur(couleur);
                        if (info.Ressource is CActeur)
                            img = Resources.Intervenant;
					}
					else if (info.ElementAIntervention != null )
                    {
                        if (!info.ElementAIntervention.Equals(lastObj))//Nouveau site
                        {
                            img = DynamicClassAttribute.GetImage(info.ElementAIntervention.GetType());
                            lastObj = info.ElementAIntervention;
                            strLib = info.ElementAIntervention.DescriptionElement;
                            if (info.ElementAIntervention.Equals(m_elementAInterventionSelectionne))
                            {
                                couleur = m_couleurFondElementAInterventionSelectionne;
                                couleurTexte = GetCouleurVisibleSur(couleur);
                                bHasSelectionElementATache = true;
                            }
                        }
                        else
                        {
                            //Nouveau truc à affecter
                            if (info.RelationTypeRessource != null)
                            {
                                Type tp = info.RelationTypeRessource.GetTypeRessource();
                                /*if (tp != null)
                                    img = DynamicClassAttribute.GetImage(tp);
                                if (tp == typeof(CActeur)) 
                                    img = Resources.Intervenant;*/
                                couleur = CUtilEntreePlanning.GetCouleurTypeRessource(tp);
                                couleurTexte = GetCouleurVisibleSur(couleur);
                               // strLib = info.RelationTypeRessource.Libelle;
                            }
                            
                        }

					}
					int nY = nLigne * m_nHauteurLigne + m_panelEchelle.Height;
                    if (nLigne % 2 != 0)
                        couleur = CUtilCouleur.GetCouleurAlternative(couleur);
					Brush br = new SolidBrush(couleur);
					Rectangle rc = new Rectangle(0, nY , m_panelLignes.Width , m_nHauteurLigne);
					g.FillRectangle(br, rc);
					br.Dispose();
					Brush brTexte = new SolidBrush(couleurTexte);
                    if (img != null)
                    {
                        g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        Size sz = CUtilImage.GetSizeAvecRatio(img, new Size(rc.Height, rc.Height));
                        Rectangle rcImage = new Rectangle(
                            rc.Left, rc.Top, sz.Width, sz.Height);
                        g.DrawImage(img, rcImage);
                        rc = new Rectangle(rc.Left + rcImage.Width, rc.Top, rc.Width - rcImage.Width, rc.Height);
                    }
            
					if ( strLib != "" )
					{
						g.DrawLine(penLigne, 0, nY, m_panelLignes.Width, nY);
                        StringFormat sf = new StringFormat();
                        sf.Alignment = StringAlignment.Near;
                        sf.LineAlignment = StringAlignment.Far;
						g.DrawString(strLib, ft, brTexte, rc, sf);
                        sf.Dispose();
						
						if (info.IsOkForTranche(m_infoTrancheSelectionnee))
						{
							Image bmp = m_imageRessourceOk.Image;
							g.DrawImage(bmp, new Point(rc.Right - bmp.Width - 1, rc.Top + 1));
						}

					}
					brTexte.Dispose();
				}
			}
			penLigne.Dispose();
			ft.Dispose();
			if (!bHasSelectionElementATache)
				m_elementAInterventionSelectionne = null;

            g.Transform = oldM;
		}


		//---------------------------------------------------------------
		private Rectangle CalcRectTranche(ITranchePlanning tranche, int nLigne)
		{
			int nX1 = GetX(tranche.DateDebut, DateDebut, m_dateStartGraduations);
			int nY1 = nLigne * m_nHauteurLigne;
			int nX2 = GetX(tranche.DateFin, DateDebut, m_dateStartGraduations);
			if (nX2 - nX1 < 8)
				nX2 = nX1 + 8;
			Rectangle rc = new Rectangle(nX1, nY1, nX2 - nX1, m_nHauteurLigne);
			return rc;
		}

		//--------------------------------------------------------------
		private Color GetCouleurVisibleSur(Color c)
		{
			int nMoy = (c.R + c.B + c.G) / 3;
			if (nMoy < 128)
				return Color.White;
			else
				return Color.Black;
		}

		//---------------------------------------------------------------
		private void DrawTranche(Graphics g, CInfoTrancheAffichee tranche)
		{
			Rectangle rc = tranche.Rect;
			rc.Inflate(0, -2);
			if ( rc.Width < 8 )
				rc = new Rectangle ( rc.Left, rc.Top, 8, rc.Height );
			rc.Offset(0, 1);
			if (g != null)
			{
				Brush br = new SolidBrush(tranche.CouleurIntervention);
				Color couleurText = GetCouleurVisibleSur(tranche.CouleurIntervention);
				if (tranche.TypeRelation == null)
				{
                    g.FillRectangle(br, rc);
                    g.DrawRectangle(Pens.Black, rc);
					/*Rectangle rcEllipseGauche = new Rectangle ( rc.Left, rc.Top, 8, rc.Height );
					Rectangle rcEllipseDroite = new Rectangle ( rc.Right-8, rc.Top, 8, rc.Height );
					g.FillEllipse(br, rcEllipseGauche);
					g.FillEllipse(br, rcEllipseDroite);
					g.FillRectangle(br, new Rectangle(rc.Left + 4, rc.Top, rc.Width - 8, rc.Height));*/
				}
				else
				{
                    if (tranche.Ressource != null)
                    {
                        g.FillRectangle(br, rc);
                        Pen pen;
                        if (tranche.Tranche.EntreePlanning.Equals(m_tacheToHighlight))
                            pen = new Pen(Color.Black, 3);
                        else
                            pen = new Pen(Color.Black);
                        g.DrawRectangle(pen, rc);
                        pen.Dispose();
                    }
				}
				Image bmp = null;
				string strLib = "";
				if (!m_baseAffichee.ElementsAIntervention.Contains(tranche.Tranche.EntreePlanning.ElementLiePrincipal))
				{
					IElementAIntervention elt = tranche.Tranche.EntreePlanning.ElementLiePrincipal;
					strLib = elt.Libelle;
				}
				else
				{
					if (tranche.TypeRelation is CContrainte)
					{
						CContrainte contrainte = (CContrainte)tranche.TypeRelation;
						if (m_cacheImages.ContainsKey(contrainte.TypeContrainte.Id))
							bmp = m_cacheImages[contrainte.TypeContrainte.Id];
						else
						{
							bmp = contrainte.TypeContrainte.ImageApplique;
							if (bmp == null)
								bmp = Resources.outils;
							m_cacheImages[contrainte.TypeContrainte.Id] = bmp;
						}
						strLib = ((CContrainte)tranche.TypeRelation).Libelle;
					}
					else if (tranche.TypeRelation is CTypeIntervention_ProfilIntervenant)
					{
						bmp = Resources.Intervenant;
						strLib = ((CTypeIntervention_ProfilIntervenant)tranche.TypeRelation).Libelle;
					}
					else
						strLib = tranche.Tranche.EntreePlanning.Libelle;
				}
				if (bmp != null && tranche.Ressource == null)
				{
                    rc = tranche.Rect;
                    Size sz = CUtilImage.GetSizeAvecRatio ( bmp, new Size(200, m_nHauteurLigne));
                    ColorMatrix cm = new ColorMatrix();
                    cm.Matrix00 = 1.0f;
                    cm.Matrix11 = 0.0f;
                    cm.Matrix22 = 0.0f;
                    //cm.Matrix33 = 0.75f;
                    ImageAttributes ia = new ImageAttributes();
                    ia.SetColorMatrix(cm);
                    g.DrawImage(bmp, new Rectangle(rc.Left, rc.Top+rc.Height/2-sz.Height/2, sz.Width, sz.Height), 
                        0, 0, bmp.Width, bmp.Height,
                        GraphicsUnit.Pixel, ia);
                    ia.Dispose();
                    rc.Width = sz.Width;

                    tranche.Rect = rc;
				}
                if (tranche.HasConflit)
                {
                    Size sz = CUtilImage.GetSizeAvecRatio(Resources.warning, new Size(rc.Height - 2, rc.Height - 2));
                    g.DrawImage(Resources.warning, rc.Left + 1, rc.Top + 1, sz.Width, sz.Height);
                }
				br.Dispose();
				Font ft = new Font("Arial", 7);
				StringFormat sf = new StringFormat(StringFormat.GenericDefault);
				sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Far;
				br = new SolidBrush(Color.Black);//GetCouleurVisibleSur(tranche.CouleurIntervention));
				g.DrawString(strLib, ft, br, new Rectangle(rc.Right, rc.Top, 4000, rc.Height), sf);
				br.Dispose();
				ft.Dispose();
                sf.Dispose();
			}
		}

		/*//---------------------------------------------------------------
		private Rectangle DrawTranche ( Graphics g, ITranchePlanning tranche, int nLigne )
		{
			return DrawTranche ( g, tranche, nLigne, DateDebut, GetDateStartGraduation ( DateDebut ) );
		}

		//---------------------------------------------------------------
		private Rectangle DrawTranche(Graphics g, ITranchePlanning tranche, int nLigne, DateTime dateDebut, DateTime dateStartGraduation)
		{
			int nX1 = GetX(tranche.DateDebut, dateDebut, dateStartGraduation);
			int nY1 = nLigne * c_nHauteurLigne;
			int nX2 = GetX(tranche.DateFin, dateDebut, dateStartGraduation);
			if (nX2 - nX1 < 4)
				nX2 = nX1 + 4;
			Rectangle rc = new Rectangle(nX1, nY1, nX2 - nX1, c_nHauteurLigne);
			if (g != null)
			{
				g.FillRectangle(Brushes.Blue, rc);
				g.DrawRectangle(Pens.Black, rc);
				Font ft = new Font("Arial", 7);
				StringFormat sf = new StringFormat(StringFormat.GenericDefault);
				sf.Alignment = StringAlignment.Center;
				g.DrawString(tranche.EntreePlanning.Libelle, ft, Brushes.White, rc, sf);
				ft.Dispose();
			}
			return rc;
		}*/
		#endregion

		//----------------------------------------------------
		public DateTime DateDebut
		{
			get
			{
				return m_dateDebut;
			}
			set
			{
				bool bChange = value != m_dateDebut;
				m_dateDebut = value;
                if ((m_dateFin - m_dateDebut).Days > 60)
                    m_dateFin = m_dateFin.AddDays(60);
                if ((m_dateFin - m_dateDebut).TotalHours < 4)
                    m_dateFin = m_dateDebut.AddHours(4);
				if (bChange)
				{
					m_timerSendEventChangeDate.Stop();
					m_timerSendEventChangeDate.Start();
				}

			}
		}

		//----------------------------------------------------
		public DateTime DateFin
		{
			get
			{
				return m_dateFin;
			}
			set
			{
				bool bChange = value != m_dateFin;
				m_dateFin = value;
                if ((m_dateFin - m_dateDebut).Days > 60)
                    m_dateFin = m_dateDebut.AddDays(60);
                if ((m_dateFin - m_dateDebut).TotalHours < 4)
                    m_dateFin = m_dateDebut.AddHours(4);
				if (bChange)
				{
					m_timerSendEventChangeDate.Stop();
					m_timerSendEventChangeDate.Start();
				}
			}
		}

		//----------------------------------------------------
		private void m_panelDessin_Paint(object sender, PaintEventArgs e)
		{
			DrawCalendrier(e.Graphics);
		}

		//----------------------------------------------------
		public CInfoTrancheAffichee GetTrancheAt(Point pt)
		{
			return GetTrancheAtAvecExclusion(pt);
		}

		//----------------------------------------------------
		private CInfoTrancheAffichee GetTrancheAtAvecExclusion ( Point pt, params CInfoTrancheAffichee[] tranchesAExclure )
		{
            pt = GetLogicalPoint(pt);
			foreach ( CInfoTrancheAffichee info in m_listeTranchesAffichees )
			{
				bool bTest = true;
				foreach (CInfoTrancheAffichee info2 in tranchesAExclure)
					if (info2.Equals(info))
					{
						bTest = false;
						break;
					}
				if ( bTest && info.Rect.Contains ( pt ) )
					return info;
			}
			return null;
		}

		#region Gestion de la souris
		private Point m_ptStartDrag = new Point(-1, -1);
		private bool m_bDragEnCours = false;
		//----------------------------------------------------
		private void m_panelDessin_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
                m_bDragEnCours = false;
                m_panelDessin.Capture = true;
                Cursor = Cursors.Hand;
				m_ptStartDrag = new Point(e.X, e.Y);
			}
			if (e.Button == MouseButtons.Left)
			{
				CInfoTrancheAffichee info = GetTrancheAt(new Point (e.X, e.Y));
				if (info != null)
				{
					SelectTranche(info);
					m_ptStartDrag = new Point(e.X, e.Y);
				}
				else
					SelectTranche(null);
			}
		}

		//----------------------------------------------------
		private void SelectTranche ( CInfoTrancheAffichee tranche )
		{
			Graphics g = m_panelDessin.CreateGraphics();
			HideSelection(g);
			g.Dispose();
			m_infoTrancheSelectionnee = null;
			if ( tranche != null )
			{
				m_infoTrancheSelectionnee = tranche ;
				ShowSelection();
			}
			if (m_infoTrancheSelectionnee != null)
			{
				ShowInfos(m_infoTrancheSelectionnee.Tranche);
				m_panelLignes.Refresh();
			}
			else
				ShowInfos(null);
		}

		//----------------------------------------------------
		private bool m_bModificationDateParProgramme = false;
		private ITranchePlanning m_lastTrancheSel = null;
		private void ShowInfos ( ITranchePlanning tranche )
		{
			m_lastTrancheSel = tranche;
		}
		

		//----------------------------------------------------
		private bool m_bDragDropInterne = false;
		private void m_panelDessin_MouseMove(object sender, MouseEventArgs e)
		{
			if (!m_bDragEnCours && (e.Button == MouseButtons.Right || e.Button == MouseButtons.Left) )
			{
				if (Math.Abs(e.X - m_ptStartDrag.X) > 3 || 
					Math.Abs (e.Y - m_ptStartDrag.Y) > 3 )
				{
					if (m_infoTrancheSelectionnee != null && e.Button == MouseButtons.Left && m_gestionnaireModeEdition.ModeEdition )
					{
						CTrancheDragDrop trMove = new CTrancheDragDrop ( m_infoTrancheSelectionnee );
						//Il faut que tous les intervenants soient visible pour pouvoir déplacer la tâche
						m_bDragDropInterne = true;
						DragDropEffects eff = DoDragDrop(trMove, DragDropEffects.Move | DragDropEffects.Link);
						if (eff == DragDropEffects.Move || eff == DragDropEffects.Link)
						{
							Point pt = m_panelDessin.PointToClient(m_lastPointDragDrop);
							CInfoTrancheAffichee infoAutre = GetTrancheAtAvecExclusion(pt, m_infoTrancheSelectionnee);
							bool bMove = true;
							if ( infoAutre != null && infoAutre.Tranche is  CFractionIntervention  &&
								m_infoTrancheSelectionnee.Tranche is CFractionIntervention &&
								((CFractionIntervention)infoAutre.Tranche).Intervention.Equals ( ((CFractionIntervention)m_infoTrancheSelectionnee.Tranche).Intervention ) &&
								m_infoTrancheSelectionnee.TypeRelation != null && 
								m_infoTrancheSelectionnee.TypeRelation.Equals ( infoAutre.TypeRelation ) )
							{
								if (CFormAlerte.Afficher("Fusionner les deux parties de tâche ? ",
									EFormAlerteType.Question) == DialogResult.Yes)
								{
									TimeSpan sp = infoAutre.Tranche.DateFin - infoAutre.Tranche.DateDebut;
									sp += m_infoTrancheSelectionnee.Tranche.DateFin - m_infoTrancheSelectionnee.Tranche.DateDebut;
									if (trMove.DateDebut > infoAutre.Tranche.DateDebut)
										m_infoTrancheSelectionnee.Tranche.DateDebut = infoAutre.Tranche.DateDebut;
									else
										m_infoTrancheSelectionnee.Tranche.DateDebut = trMove.DateDebut;
									m_infoTrancheSelectionnee.Tranche.DateFin = m_infoTrancheSelectionnee.Tranche.DateDebut.AddMinutes(sp.TotalMinutes);
									((CFractionIntervention)infoAutre.Tranche).Delete();
									bMove = false;
								}
							}
							if (bMove)
							{
								m_infoTrancheSelectionnee.Tranche.DateDebut = trMove.DateDebut;
								m_infoTrancheSelectionnee.Tranche.DateFin = trMove.DateFin;

                                if (trMove.Ressource == null)//Désassignation ?
                                {
                                    if (m_infoTrancheSelectionnee.Ressource != null &&
                                        m_baseAffichee.Ressources.Contains(m_infoTrancheSelectionnee.Ressource))
                                        m_infoTrancheSelectionnee.Ressource = null;
                                    //Ne fait rien
                                }
                                else
                                {
                                    if (trMove.Ressource != null && m_infoTrancheSelectionnee.Tranche != null && m_infoTrancheSelectionnee.Ressource == null && eff == DragDropEffects.Link)
                                    {
                                        //Trouve tous les éléments attendus
                                        ITypeRelationEntreePlanning_Ressource[] rels = m_infoTrancheSelectionnee.Tranche.EntreePlanning.GetRelationsRessourceAAffecter(trMove.Ressource.GetType());
                                        
                                        if (rels.Length > 1)
                                        {
                                            CMenuModal menu = new CMenuModal();
                                            
                                            foreach (ITypeRelationEntreePlanning_Ressource rel in rels)
                                            {
                                                ToolStripMenuItem item = new ToolStripMenuItem(rel.Libelle);
                                                item.Tag = rel;
                                                menu.Items.Add(item);
                                            }
                                            ToolStripItem selectedItem = menu.ShowMenu(Cursor.Position);
                                            if (selectedItem != null)
                                            {
                                                ITypeRelationEntreePlanning_Ressource rel = selectedItem.Tag as ITypeRelationEntreePlanning_Ressource;
                                                if (rel != null)
                                                {
                                                    CResultAErreur result = m_infoTrancheSelectionnee.Tranche.EntreePlanning.AssocieRessource(rel, trMove.Ressource);
                                                    if ( !result )
                                                    {
                                                        CFormAlerte.Afficher ( result.Erreur ) ;
                                                    }
                                                }
                                            }
                                            menu.Dispose();
                                        }
                                        else if (rels.Length == 1)
                                            m_infoTrancheSelectionnee.Tranche.EntreePlanning.AssocieRessource(rels[0], trMove.Ressource);
                                    }
                                    else
                                        m_infoTrancheSelectionnee.Ressource = trMove.Ressource;
                                }
							}

							Refresh();
							ShowInfos(m_infoTrancheSelectionnee.Tranche);
						}
						m_bDragDropInterne = false;
					}
					if (e.Button == MouseButtons.Right)
					{
						m_bDragEnCours = true;
						m_panelDessin.Capture = true;
					}
				}
			}
			if (m_bDragEnCours)
			{
				Cursor = Cursors.Hand;
				int nEcart = e.X - m_ptStartDrag.X;
				DateTime dateDebut = DateDebut.AddHours(-(double)nEcart * m_fEchelle);
				DateTime dateFin = DateFin.AddHours(-(double)nEcart * m_fEchelle);
                m_scroll.Value = Math.Max(0, Math.Min(m_scroll.Value + m_ptStartDrag.Y - e.Y, m_scroll.Maximum));
				Graphics g = m_panelEchelle.CreateGraphics();
				DrawEchelle(g, dateDebut, dateFin);
                
                m_ptStartDrag.Y = e.Y;
				g.Dispose();
			}
			else if (e.Button == MouseButtons.None)
			{
				Cursor = Cursors.Default;
			}
		}

		private void m_panelDessin_MouseUp(object sender, MouseEventArgs e)
		{
            m_panelDessin.Capture = false;
			if (m_bDragEnCours)
			{
				m_panelDessin.Capture = false;
				m_bDragEnCours = false;
				int nEcart = e.X - m_ptStartDrag.X;
				DateDebut = DateDebut.AddHours(-(double)nEcart * m_fEchelle);
				DateFin = DateFin.AddHours(-(double)nEcart * m_fEchelle);
				m_timerSendEventChangeDate.Stop();
				m_timerSendEventChangeDate.Start();
				Refresh();
			}
			else
			{
				if (e.Button == MouseButtons.Right)
				{
					CInfoTrancheAffichee info = GetTrancheAt(new Point(e.X, e.Y));
					if (info != null)
					{
						SelectTranche(info);
						ShowMenuIntervention();
					}
				}
			}

		}

		private class CMenuItemARessource : ToolStripMenuItem
		{
			public CMenuItemARessource ( string strLibelle )
				:base ( strLibelle )
			{
			}
		}

		private void ShowMenuIntervention()
		{
			if ( m_infoTrancheSelectionnee == null )
				return;
			ArrayList lst = new ArrayList ( m_menuRClickCalendrier.Items );
			foreach ( ToolStripItem item in lst )
			{
				if ( item is CMenuItemARessource )
					m_menuRClickCalendrier.Items.Remove ( item );
			}

            if (m_menuDatesIntervention != null)
            {
                ITranchePlanning tranche = m_infoTrancheSelectionnee.Tranche;
                if (tranche == null)
                {
                    m_menuDatesIntervention.Visible = false;
                }
                else
                {
                    m_menuDatesIntervention.StartDate = tranche.DateDebut;
                    m_menuDatesIntervention.EndDate = tranche.DateFin;
                }
                m_menuDatesIntervention.Tag = tranche;
                m_menuDatesIntervention.DateTimePicker.LockEdition = !m_gestionnaireModeEdition.ModeEdition;
            }


			IElementAIntervention elementLie = m_infoTrancheSelectionnee.Tranche.EntreePlanning.ElementLiePrincipal;
			if (elementLie != null)
			{
				m_menuElementAIntervention.Visible = true;
				m_menuElementAIntervention.Text = elementLie.DescriptionElement;
				m_menuElementAIntervention.Tag = elementLie;
				if (m_baseAffichee.ElementsAIntervention.Contains(elementLie))
					m_menuElementAIntervention.Checked = true;
				else
					m_menuElementAIntervention.Checked = false;
                checkListToolStripMenuItem.Visible = elementLie is CIntervention &&
                    ((CIntervention)elementLie).ToutesLesContraintesCheckList.Length > 0;
			}
			else
				m_menuElementAIntervention.Visible = false;
			foreach ( Type tp in m_infoTrancheSelectionnee.Tranche.EntreePlanning.GetTypesRessourceAAffecter() )
			{
				CMenuItemARessource itemType = new CMenuItemARessource(CUtilEntreePlanning.GetLibelleTypeRessource(tp));
				foreach ( ITypeRelationEntreePlanning_Ressource rel in m_infoTrancheSelectionnee.Tranche.EntreePlanning.GetRelationsRessourceAAffecter ( tp ) )
				{
					if (m_gestionnaireModeEdition.ModeEdition)
					{
						ToolStripMenuItem itemCherche = new ToolStripMenuItem(I.T("Search @1|20020", rel.Libelle));
						itemCherche.Tag = rel;
						itemCherche.Click += new EventHandler(itemCherche_Click);
						itemType.DropDownItems.Add(itemCherche);
					}
                    foreach (IRessourceEntreePlanning res in m_infoTrancheSelectionnee.Tranche.EntreePlanning.GetRessourcesAssociees(rel))
                    {
                        if (res != null)
                        {
                            ToolStripMenuItem itemRes = new ToolStripMenuItem(rel.Libelle + " : " + res.Libelle);
                            itemRes.Tag = res;
                            itemRes.Image = DynamicClassAttribute.GetImage(res.GetType());
                            if (m_baseAffichee.Ressources.Contains(res))
                                itemRes.Checked = true;
                            itemRes.Click += new EventHandler(itemRes_Click);
                            itemType.DropDownItems.Add(itemRes);
                        }
                        else
                        {
                            if (m_gestionnaireModeEdition.ModeEdition)
                            {
                                ToolStripMenuItem itemRes = new ToolStripMenuItem(rel.Libelle + " : " + I.T("<Click to affect>|115"));
                                itemRes.Tag = rel;
                                itemRes.Click += new EventHandler(itemAffectRes_Click);
                                itemType.DropDownItems.Add(itemRes);
                            }
                        }
                    }

				}
				if (itemType.DropDownItems.Count > 0)
				{
					ToolStripMenuItem item = new ToolStripMenuItem(I.T( "Show all|114"));
					item.Tag = tp;
					item.Click += new EventHandler(ShowAllRessources_Click);
					itemType.DropDownItems.Insert(0, item);
					m_menuRClickCalendrier.Items.Add(itemType);
				}
			}

			m_menuDiviserIntervention.Visible = m_gestionnaireModeEdition.ModeEdition;
			m_menuEditerIntervention.Visible = OnEditerIntervention != null;

			//Infos bulle
			object donnee = m_infoTrancheSelectionnee.ObjetPourToolTip;
			m_menuPopupInfo.DropDownItems.Clear();
			if (donnee != null && m_bAutoTooltip)
				CMenuModeleTexte.AddToMenuParent(m_menuPopupInfo, m_tooltipDessin.TooltipContext, donnee);
	
			if (m_menuPopupInfo.DropDownItems.Count == 0)
				m_menuPopupInfo.Visible = false;
			else
				m_menuPopupInfo.Visible = true;
	


			Point pt = m_infoTrancheSelectionnee.Rect.Location;
			pt.Offset ( 0, m_infoTrancheSelectionnee.Rect.Height-m_scroll.Value );
			m_menuRClickCalendrier.Show ( m_panelDessin, pt );
		}

			
		void  itemCherche_Click(object sender, EventArgs e)
		{
			if (sender is ToolStripMenuItem)
			{
				ToolStripMenuItem item = (ToolStripMenuItem)sender;
				if (item.Tag is ITypeRelationEntreePlanning_Ressource)
				{
					ITypeRelationEntreePlanning_Ressource rel = (ITypeRelationEntreePlanning_Ressource)item.Tag;
					if (rel.TypeElementsProfiles == typeof(CRessourceMaterielle))
					{
						CFormChercheRessource.FindRessource((CIntervention)m_infoTrancheSelectionnee.Tranche.EntreePlanning,
							(CContrainte)rel,
							new SetRessourceEventHandler(AfficheRessourceFromSearch));
					}
					else
					{
                        CFormChercheIntervenant.SelectIntervenants(
                            (CIntervention)m_infoTrancheSelectionnee.Tranche.EntreePlanning,
                            (CTypeIntervention_ProfilIntervenant)rel,
                            new EventHandler(OnSelectIntervenants),
                            new SetIntervenantEventHandler(SelectIntervenantFromRecherche));
					}
				}
			}

		}

        //----------------------------------------------------
        private void OnSelectIntervenants(object sender, EventArgs args)
        {
            CFormChercheIntervenant frm = sender as CFormChercheIntervenant;
            if (frm != null)
            {
                List<CActeur> lst = new List<CActeur>(frm.ActeursSelectionnes);
                lst.Sort((x, y) => x.Libelle.CompareTo(y.Libelle));
                foreach (CActeur acteur in lst)
                {
                    m_baseAffichee.AddRessource(acteur);
                }
                Refresh();
            }
        }

		//----------------------------------------------------
		public void AfficheRessourceFromSearch(object obj, CRessourceMaterielle ressource)
		{
            m_baseAffichee.AddRessource(ressource);
            Refresh();
		}

		//----------------------------------------------------
		public void SelectIntervenantFromRecherche(object obj, CActeur acteur)
		{
            m_baseAffichee.AddRessource(acteur);
            Refresh();
		}

		

		//----------------------------------------------------
		public void  ShowAllRessources_Click(object sender, EventArgs e)
		{
			if ( sender is ToolStripMenuItem && m_infoTrancheSelectionnee != null)
			{
				bool bAdd = false;
				Type tp = (Type)((ToolStripMenuItem)sender).Tag;
                
				foreach ( ITypeRelationEntreePlanning_Ressource rel in m_infoTrancheSelectionnee.Tranche.EntreePlanning.GetRelationsRessourceAAffecter ( tp ) )
				{
                    foreach (IRessourceEntreePlanning res in m_infoTrancheSelectionnee.Tranche.EntreePlanning.GetRessourcesAssociees(rel))
                    {
                        if (res != null && !m_baseAffichee.Ressources.Contains(res))
                        {
                            m_baseAffichee.AddRessource(res);
                            bAdd = true;
                        }
                    }
				}
				if ( bAdd )
					Refresh();
			}
		}

		//----------------------------------------------------
		public void  itemElementAIntervention_Click(object sender, EventArgs e)
		{
			if (sender is CMenuItemARessource && ((CMenuItemARessource)sender).Tag is IElementAIntervention)
			{
				IElementAIntervention obj = (IElementAIntervention)((CMenuItemARessource)sender).Tag;
				if (!m_baseAffichee.ElementsAIntervention.Contains(obj))
				{
					m_baseAffichee.AddElementAIntervention(obj);
					Refresh();
				}
			}
		}

		//----------------------------------------------------
		void  itemRes_Click(object sender, EventArgs e)
		{
			if (sender is ToolStripMenuItem)
			{
				object tag = ((ToolStripMenuItem)sender).Tag;
				if (tag is IRessourceEntreePlanning && !m_baseAffichee.Ressources.Contains((IRessourceEntreePlanning)tag))
				{
					m_baseAffichee.AddRessource((IRessourceEntreePlanning)tag);
					Refresh();
				}
					
			}
		}

		//----------------------------------------------------
		void itemAffectRes_Click(object sender, EventArgs e)
		{
			if (sender is ToolStripMenuItem)
			{
				object tag = ((ToolStripMenuItem)sender).Tag;
				if (tag is ITypeRelationEntreePlanning_Ressource)
				{
					IRessourceEntreePlanning[] res = m_infoTrancheSelectionnee.Tranche.EntreePlanning.GetRessourcesPossibles(
						(ITypeRelationEntreePlanning_Ressource)tag,
						null);
					foreach (IRessourceEntreePlanning ressource in res)
					{
						if (!m_baseAffichee.Ressources.Contains(ressource))
							m_baseAffichee.AddRessource(ressource);
					}
					Refresh();
				}

			}
		}

			




		#endregion

		public IBasePlanning BaseAffichee
		{
			get
			{
				return m_baseAffichee;
			}
			set
			{
				bool bChange = m_baseAffichee != value;
				m_baseAffichee = value;
				if (bChange)
				{
					if ( m_elementAInterventionSelectionne != null && m_baseAffichee.ElementsAIntervention.Count() > 0 )
					{
						IElementAIntervention elt = (IElementAIntervention)Activator.CreateInstance ( m_elementAInterventionSelectionne.GetType(), m_baseAffichee.ContexteDonnee );
						if ( ((CObjetDonnee)elt).ReadIfExists ( ((CObjetDonnee)m_elementAInterventionSelectionne).GetValeursCles() ) )
							m_elementAInterventionSelectionne = elt;
						else
							m_elementAInterventionSelectionne = null;
					}
					else
						m_elementAInterventionSelectionne = null;
				}
				Refresh();
			}
		}

		#region Drag and drop d'éléments
		private CTrancheDragDrop m_trancheDragDrop = null;
		private Bitmap m_bmpDragDrop = null;
		private TimeSpan m_ecartDragDropTranche = new TimeSpan(1,0,0);
        private bool m_bIsDragDropFromIntervention = false;
		private void m_panelDessin_DragEnter(object sender, DragEventArgs e)
		{
			if (!m_gestionnaireModeEdition.ModeEdition)
			{
				e.Effect = DragDropEffects.None;
				return;
			}
			CTrancheDragDrop trancheDragDrop = null;
			if ( e.Data.GetData ( typeof(CTrancheDragDrop ) ) != null )
				trancheDragDrop = (CTrancheDragDrop)e.Data.GetData ( typeof(CTrancheDragDrop) );

			Point pt = new Point(e.X, e.Y);
			pt = m_panelDessin.PointToClient(pt);
            m_bIsDragDropFromIntervention = false;

            CIntervention intervention = e.Data.GetData(typeof(CIntervention)) as CIntervention;
            if (intervention == null)
            {
                CReferenceObjetDonnee refObj = e.Data.GetData(typeof(CReferenceObjetDonnee)) as CReferenceObjetDonnee;
                if (refObj != null && refObj.TypeObjet == typeof(CIntervention))
                {
                    intervention = refObj.GetObjet(m_baseAffichee.ContexteDonnee) as CIntervention;
                }
            }

			if (intervention != null)
			{
                intervention = intervention.GetObjetInContexte(m_baseAffichee.ContexteDonnee) as CIntervention;
				trancheDragDrop = new CTrancheDragDrop(intervention);
				double fDuree = Math.Max(intervention.DureePrevisionnelle, 0.25);
                m_bIsDragDropFromIntervention = intervention.Fractions.Count == 0;

			}
		

			if ( trancheDragDrop != null ) 
			{
                if (m_bDragDropInterne)
                    pt = m_ptStartDrag;
                else
                {
                    TimeSpan sp = trancheDragDrop.DateFin - trancheDragDrop.DateDebut;
                    trancheDragDrop.DateDebut = GetDateTime(pt.X).AddHours(-sp.TotalHours / 2);
                    trancheDragDrop.DateFin = trancheDragDrop.DateDebut + sp;
                }
				m_trancheDragDrop = trancheDragDrop;
				if ( m_bmpDragDrop != null )
				{
					m_bmpDragDrop.Dispose();
					m_bmpDragDrop = null;
				}
				m_bmpDragDrop = new Bitmap ( m_panelDessin.Width, m_panelDessin.Height );
				Graphics g = Graphics.FromImage ( m_bmpDragDrop );
				DrawCalendrier ( g );
				g.Dispose();
				m_ecartDragDropTranche = m_trancheDragDrop.DateDebut-GetDateTime(pt.X);
			}
		}

		//------------------------------------------------------------
		private Rectangle m_lastZoneDessinOver = new Rectangle(0, 0, 0, 0);
        private DateTime? m_lastAutoscrollDate = null;
		private void m_panelDessin_DragOver(object sender, DragEventArgs e)
		{
			if (!m_gestionnaireModeEdition.ModeEdition)
			{
				e.Effect = DragDropEffects.None;
				return;
			}
			if (m_trancheDragDrop != null && e.X != m_lastPointDragDrop.X || e.Y != m_lastPointDragDrop.Y )
			{
				Point ptLogique = new Point(e.X, e.Y);
				m_lastPointDragDrop = ptLogique;
				ptLogique = m_panelDessin.PointToClient(ptLogique);
                ptLogique = GetLogicalPoint(ptLogique);
				Graphics g = m_panelDessin.CreateGraphics();
				try
				{
					m_lastZoneDessinOver.Inflate(2, 2);
					g.DrawImage(m_bmpDragDrop, m_lastZoneDessinOver, m_lastZoneDessinOver, GraphicsUnit.Pixel);
				}
				catch { }
				DateTime dt = GetDateTime(ptLogique.X);
				dt = dt.Add(m_ecartDragDropTranche);
				TimeSpan sp = m_trancheDragDrop.DateFin - m_trancheDragDrop.DateDebut;
				//Si affichage en jours, ne change pas l'heure
                if ( (e.KeyState & 32 )== 32 || m_bIsDragDropFromIntervention )
                {
                    dt = GetArrondi(dt);
                    if (m_ecartGraduations >= new TimeSpan(1, 0, 0, 0))
                        dt = new DateTime(
                            dt.Year,
                            dt.Month,
                            dt.Day, m_trancheDragDrop.DateDebut.Hour, m_trancheDragDrop.DateDebut.Minute, 0);
                    m_trancheDragDrop.DateDebut = dt;
                    m_trancheDragDrop.DateFin = m_trancheDragDrop.DateDebut + sp;
                }

				int nLigne = ptLogique.Y / m_nHauteurLigne;
				if (nLigne < 0)
					nLigne = 0;
				IRessourceEntreePlanning res = null;
				if (m_infoLignes.ContainsKey(nLigne))
					res = m_infoLignes[nLigne].Ressource;
				e.Effect = DragDropEffects.Move;
				if (res != null)
				{
					Type tpRes = m_trancheDragDrop.TypeRessourceAttendu;
                    if (tpRes != null && !tpRes.IsAssignableFrom(res.GetType()))
                    {
                        e.Effect = DragDropEffects.None;
                    }
                    else if (tpRes == null)
                    {
                        e.Effect = DragDropEffects.Link;
                        m_trancheDragDrop.Ressource = res;
                    }
                    else
                        m_trancheDragDrop.Ressource = res;
				}
				else
					m_trancheDragDrop.Ressource = res;

				m_lastZoneDessinOver =  CalcRectTranche(m_trancheDragDrop, nLigne );
                m_lastZoneDessinOver.Offset(0, -m_scroll.Value);
				Pen leCrayon = new Pen(Brushes.Black);
				leCrayon.DashStyle = DashStyle.Dot;
				g.DrawRectangle(leCrayon, m_lastZoneDessinOver);
				g.Dispose();
				//g.Dispose();
				ShowInfos(m_trancheDragDrop);
            }
            if ( m_trancheDragDrop != null )
            {
                bool bHasAutoScroll = false;
                Point pt = m_panelDessin.PointToClient(new Point(e.X, e.Y));
                if (pt.Y > m_panelDessin.Height - m_nHauteurLigne &&
                    m_scroll.Value < m_scroll.Maximum && 
                    ( m_lastAutoscrollDate == null ||
                    ((TimeSpan)(DateTime.Now - m_lastAutoscrollDate)).TotalMilliseconds > 10 ))
                {
                    m_scroll.Value = Math.Min(m_scroll.Value + m_nHauteurLigne , m_scroll.Maximum);
                    m_lastAutoscrollDate = DateTime.Now;
                    bHasAutoScroll = true;
                }
                if (pt.Y < m_nHauteurLigne && 
                    m_scroll.Value > 0  && 
                    (m_lastAutoscrollDate == null ||
                    ((TimeSpan)(DateTime.Now - m_lastAutoscrollDate)).TotalMilliseconds > 10))
                {
                    m_scroll.Value = Math.Max(m_scroll.Value - m_nHauteurLigne, 0);
                    m_lastAutoscrollDate = DateTime.Now;
                    bHasAutoScroll = true;
                }
                if (bHasAutoScroll)
                {
                    if (m_bmpDragDrop != null)
                    {
                        m_bmpDragDrop.Dispose();
                        m_bmpDragDrop = null;
                    }
                    m_bmpDragDrop = new Bitmap(m_panelDessin.Width, m_panelDessin.Height);
                    Graphics g = Graphics.FromImage(m_bmpDragDrop);
                    DrawCalendrier(g);
                    g.Dispose();
                }

				
			}
		}

		//------------------------------------------------------------
		private void m_panelDessin_DragLeave(object sender, EventArgs e)
		{
			if (!m_gestionnaireModeEdition.ModeEdition)
			{
				return;
			}
			m_trancheDragDrop = null;
			if (m_bmpDragDrop != null)
			{
				m_bDragDropInterne = false;
				m_bmpDragDrop.Dispose();
				m_bmpDragDrop = null;
			}
		}

		//------------------------------------------------------------
		
		private void m_panelDessin_DragDrop(object sender, DragEventArgs e)
		{
			if (!m_gestionnaireModeEdition.ModeEdition)
			{
				e.Effect = DragDropEffects.None;
				return;
			}
			if (m_trancheDragDrop.Intervention != null && m_trancheDragDrop.Intervention.Fractions.Count == 0)
			{
				//Création d'une fraction pour cette intervention
				CFractionIntervention fraction = new CFractionIntervention(m_trancheDragDrop.Intervention.ContexteDonnee);
				fraction.CreateNewInCurrentContexte();
				fraction.Intervention = m_trancheDragDrop.Intervention;
				fraction.DateDebutPlanifie = m_trancheDragDrop.DateDebut;
				fraction.DateFinPlanifiee = m_trancheDragDrop.DateFin;
				fraction.EtatInt = (int)EtatFractionIntervention.AFaire;
			}
            if (m_trancheDragDrop.Intervention != null && m_trancheDragDrop.Intervention.Site != null &&
                !m_baseAffichee.ElementsAIntervention.Contains(m_trancheDragDrop.Intervention.Site))
            {
                m_baseAffichee.AddElementAIntervention(m_trancheDragDrop.Intervention.Site);
            }
			m_trancheDragDrop = null;
			if (m_bmpDragDrop != null)
			{
				m_bmpDragDrop.Dispose();
				m_bmpDragDrop = null;
			}
		}
		#endregion

		#region Dessin et gestion de la sélection

		private int m_nPhaseSelection = 0;
        private bool m_bIsDrawingCalendrier = false;
		private void m_timerShowSelection_Tick(object sender, EventArgs e)
		{
            if (m_bIsDrawingCalendrier)
                return;
			Graphics g = m_panelDessin.CreateGraphics();
			DrawSelection ( g, m_nPhaseSelection++ );
			g.Dispose();
			if ( m_nPhaseSelection > 10 )
				m_nPhaseSelection = 0;
		}

		//------------------------------------
		/// <summary>
		/// Affiche la selection
		/// </summary>
		private void ShowSelection ( )
		{
			if (m_infoTrancheSelectionnee != null)
			{
				m_timerShowSelection.Enabled = true;
				Graphics g = m_panelDessin.CreateGraphics();
				DrawSelection(g, m_nPhaseSelection);
			}
			else
				m_timerShowSelection.Enabled = false;
		}

		//------------------------------------
		/// <summary>
		/// Masque la sélection
		/// </summary>
		/// <param name="g"></param>
		private void HideSelection( Graphics g )
		{
			m_timerShowSelection.Enabled = false;
			if ( m_infoTrancheSelectionnee != null )
			{
				try
				{
					Rectangle rc = m_infoTrancheSelectionnee.Rect;
					rc.Inflate ( 2, 2 );
					m_panelDessin.Invalidate(rc);
					//DrawTranche(g, m_infoTrancheSelectionnee);
				}
				catch { }
			}
		}

		//Dessine la sélection. La phase sert à faire clignoter la sélection
		private void DrawSelection ( Graphics g, int nPhase )
		{
			if (m_infoTrancheSelectionnee != null)
			{
				try
				{
                    Matrix oldM = g.Transform;
                    g.TranslateTransform(0, -m_scroll.Value);
					g.DrawRectangle(Pens.White, m_infoTrancheSelectionnee.Rect);
					Pen pen = new Pen(Color.Black);
					pen.DashStyle = DashStyle.Dash;
					if (nPhase % 2 == 0)
						pen.DashOffset = 2;
					g.DrawRectangle(pen, m_infoTrancheSelectionnee.Rect);
                    g.Transform = oldM;
				}
				catch
				{ }
			}
		}

		#endregion



		//----------------------------------------------------------------
		private void RefreshDiffere()
		{
			m_timerRefreshDessin.Enabled = false;
			m_timerRefreshDessin.Enabled = true;
		}

		//----------------------------------------------------------------
		private void m_timerRefreshDessin_Tick(object sender, EventArgs e)
		{
			m_timerRefreshDessin.Enabled = false;
			Refresh();
            if (m_infoTrancheSelectionnee != null)
                ShowInfos(m_infoTrancheSelectionnee.Tranche);
            else
                ShowInfos(null);
		}


		private void m_panelLignes_Paint(object sender, PaintEventArgs e)
		{
			DrawEntetesLignes(e.Graphics);
		}

		public override void Refresh()
		{
			CalculeEchelle(DateDebut, DateFin);
			CalculeDessin();
			base.Refresh();
		}

		private void m_panelDessin_Click(object sender, EventArgs e)
		{

		}

		//--------------------------------------------------
		private void showAssignedActors114ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (m_infoTrancheSelectionnee != null && m_infoTrancheSelectionnee.Tranche.EntreePlanning is CIntervention)
			{
				Hashtable tableIntervenants = new Hashtable();
				CIntervention tache = (CIntervention)m_infoTrancheSelectionnee.Tranche.EntreePlanning;
				foreach (CIntervention_Intervenant tc in tache.RelationsIntervenants)
					tableIntervenants[tc.Intervenant] = true;
				m_baseAffichee.ClearRessources();
				foreach (CActeur acteur in tableIntervenants.Keys)
					m_baseAffichee.AddRessource(acteur);
				Refresh();
			}
		}

		//--------------------------------------------------
		public Type TypeRessourcesAAffecter
		{
			get
			{
				return m_typeRessourcesAffectees;
			}
			set
			{
				m_typeRessourcesAffectees = value;
				Refresh();
			}
		}

		private void m_menuRClickIntervention_Opening(object sender, CancelEventArgs e)
		{
            
		}

		//--------------------------------------------------------------------
		public event EventHandler OnChangeSelectionElementAIntervention;
		public IElementAIntervention ElementAInterventionSelectionne
		{
			get
			{
				return m_elementAInterventionSelectionne;
			}
			set
			{
				bool bHasChange = value != m_elementAInterventionSelectionne;
				m_elementAInterventionSelectionne = value;
				m_panelLignes.Refresh();
				if (bHasChange && OnChangeSelectionElementAIntervention != null)
					OnChangeSelectionElementAIntervention(this, new EventArgs());
			}
		}

		//--------------------------------------------------------------------
		private int m_nNumLigneMenuLigne = -1;
		private void m_panelLignes_MouseUp(object sender, MouseEventArgs e)
		{
			int nLigne = (e.Y - m_panelEchelle.Height) / m_nHauteurLigne;
            if (nLigne >= 0 && m_infoLignes.ContainsKey(nLigne))
            {
                CInfoLigne info = m_infoLignes[nLigne];
                string strText = "";
                if (info.Ressource != null)
                    strText = info.Ressource.Libelle;
                else if (info.ElementAIntervention != null)
                {
                    strText = info.ElementAIntervention.DescriptionElement;
                    ElementAInterventionSelectionne = info.ElementAIntervention;
                }
                if (e.Button == MouseButtons.Right)
                {
                    m_menuMasquerLigne.Text = I.T("Hide @1|116", strText);
                    m_menuMasquerLigne.Visible = true;
                    m_nNumLigneMenuLigne = nLigne;

                    object donnee = info.ObjetPourToolTip;
                    m_menuPopupInfoLigne.DropDownItems.Clear();
                    if (donnee != null && m_bAutoTooltip)
                        CMenuModeleTexte.AddToMenuParent(m_menuPopupInfoLigne, m_tooltipLignes.TooltipContext, donnee);

                    if (m_menuPopupInfoLigne.DropDownItems.Count == 0)
                        m_menuPopupInfoLigne.Visible = false;
                    else
                        m_menuPopupInfoLigne.Visible = true;

                    ShowMenuLigne(nLigne, new Point ( e.X, e.Y ));
                }
            }
            else if ( e.Button == MouseButtons.Right )
            {
                ShowMenuLigne(null,new Point ( e.X, e.Y ));

            }
		}

        //--------------------------------------------------------------------
        private void ShowMenuLigne( int? nLigne, Point pt)
        {
            foreach (ToolStripItem item in new ArrayList(m_menuRClickLigne.Items))
            {
                if (item != m_menuGestionActeurs &&
                    item != m_menuGestionSites &&
                    item != m_menuGestionResources)
                    item.Visible = nLigne != null;
            }
            m_menuRClickLigne.Show(m_panelLignes, pt);
        }


		//--------------------------------------------------------------------
		private void m_menuMasquerLigne_Click(object sender, EventArgs e)
		{
			if (m_infoLignes.ContainsKey(m_nNumLigneMenuLigne))
			{
				CInfoLigne info = m_infoLignes[m_nNumLigneMenuLigne];
				if (info.Ressource != null)
					m_baseAffichee.RemoveRessource(info.Ressource);
				else if (info.ElementAIntervention != null)
					m_baseAffichee.RemoveElementAIntervention(info.ElementAIntervention);
				Refresh();
			}
		}

		//--------------------------------------------------------------------
		private void m_menuZoomOn_Click(object sender, EventArgs e)
		{
			if (sender is ToolStripMenuItem)
			{
				ToolStripMenuItem item = (ToolStripMenuItem)sender;
				if (item.Tag is DateTime)
				{
					DateDebut = ((DateTime)item.Tag).Date;
					DateFin = DateDebut.AddDays(1);
					Refresh();
				}
			}
		}

		//---------------------------------------------------
		private void m_menu2Jours_Click(object sender, EventArgs e)
		{
			DateFin = DateDebut.AddDays(2);
			Refresh();
		}

		//---------------------------------------------------
		private void m_menu3Jours_Click(object sender, EventArgs e)
		{
			DateFin = DateDebut.AddDays(3);
			Refresh();
		}

		//---------------------------------------------------
		private void m_menu5jours_Click(object sender, EventArgs e)
		{
			DateFin = DateDebut.AddDays(5);
			Refresh();
		}

		
		//---------------------------------------------------
		private void m_menuSemaine_Click(object sender, EventArgs e)
		{
			DateFin = DateDebut.AddDays(7);
			Refresh();
		}

		//---------------------------------------------------
		private void m_menu2Semaines_Click(object sender, EventArgs e)
		{
			DateFin = DateDebut.AddDays(14);
			Refresh();
		}

		//---------------------------------------------------
		public CInfoLigne GetLigneAt(Point pt)
		{
			int nLigne = (pt.Y - m_panelEchelle.Height) / m_nHauteurLigne;
			if (nLigne >= 0 && m_infoLignes.ContainsKey(nLigne))
				return m_infoLignes[nLigne];
			return null;
		}

		//-------------------------------------------------------------------
		public bool MasquerEntetesLignes
		{
			get
			{
				return !m_panelLignes.Visible;
			}
			set
			{
				m_panelLignes.Visible = !value;
			}
		}


		//-------------------------------------------------------------------
		public bool EnableAffichageDatesEnBas
		{
			get
			{
				return m_bEnableAffichageDatesEnBas;
			}
			set
			{
				m_bEnableAffichageDatesEnBas = value;
			}
		}

		//---------------------------------------------------------------------
		public bool AutoTooltip
		{
			get
			{
				return m_bAutoTooltip;
			}
			set
			{
				m_bAutoTooltip = value;
				m_tooltipDessin.Enable = value;
			}
		}
		
		//-------------------------------------------------------------------
		private void m_menuDiviserIntervention_Click(object sender, EventArgs e)
		{
			if (m_infoTrancheSelectionnee != null && m_infoTrancheSelectionnee.Tranche is CFractionIntervention)
			{
				Point pt = m_infoTrancheSelectionnee.Rect.Location;
				pt.Offset(0, m_infoTrancheSelectionnee.Rect.Height);
				pt = m_panelDessin.PointToScreen(pt);
				DateTime? dtSplit = CFormDiviserIntervention.GetDateDivision(pt, (CFractionIntervention)m_infoTrancheSelectionnee.Tranche);
				if (dtSplit != null)
				{
					CFractionIntervention fractionInit = (CFractionIntervention)m_infoTrancheSelectionnee.Tranche;
					CFractionIntervention fractionSuite = (CFractionIntervention)fractionInit.Clone(false);
					DateTime dt = (DateTime)dtSplit;
					DateTime dtFinInit = fractionInit.DateFinPlanifiee;
					fractionInit.DateFinPlanifiee = dt;
					if (fractionInit.DateDebutPlanifie > fractionInit.DateFinPlanifiee)
						fractionInit.DateDebutPlanifie = fractionInit.DateFinPlanifiee.AddMinutes(-30);
					TimeSpan sp = (TimeSpan)(fractionInit.DateFinPlanifiee - fractionInit.DateDebutPlanifie);
					if (sp.TotalMinutes < 30)
						fractionInit.DateDebutPlanifie = fractionInit.DateFinPlanifiee.AddMinutes(-30);

					fractionSuite.DateDebutPlanifie = dt;
					fractionSuite.DateFinPlanifiee = dtFinInit;
					if (fractionSuite.DateFinPlanifiee < fractionSuite.DateDebutPlanifie)
						fractionSuite.DateFinPlanifiee = fractionSuite.DateDebutPlanifie.AddMinutes(30);
					sp = (TimeSpan)(fractionSuite.DateFinPlanifiee - fractionSuite.DateDebutPlanifie);
					if ( sp.TotalMinutes < 30 )
						fractionSuite.DateFinPlanifiee = fractionSuite.DateDebutPlanifie.AddMinutes(30);
					Refresh();
				}
			}
		}

		//---------------------------------------------------------------------
		private void AssureInterventionVisible ( CIntervention tache )
		{
			if ( tache.DateDebutPlanifiee == null ||
				tache.DateFinPlanifiee == null )
				return;
			if ( DateDebut > (DateTime)tache.DateDebutPlanifiee ||
				 DateFin < (DateTime)tache.DateFinPlanifiee )
			{
				TimeSpan sp = (DateTime)tache.DateFinPlanifiee - (DateTime)tache.DateDebutPlanifiee;
				DateDebut = ((DateTime)tache.DateDebutPlanifiee).AddMinutes ( -sp.TotalMinutes/2 );
				DateFin = ((DateTime)tache.DateFinPlanifiee).AddMinutes ( sp.TotalMinutes/2);
                sp = DateFin - DateDebut;
                double dureePrevue = tache.DureePrevisionnelle;
                if (dureePrevue <= 0)
                    dureePrevue = 4;
                if (sp.TotalHours < dureePrevue)
                    DateFin = DateFin.AddHours(dureePrevue);
			}
		}

		//-------------------------------------------------------------------
		public void AfficheForRessource(IRessourceEntreePlanning ressource, CIntervention tache)
		{
			if (m_baseAffichee == null)
				m_baseAffichee = new CFournisseurEntreesPlanning(ressource.ContexteDonnee);
			MasquerEntetesLignes = true;
			EnableAffichageDatesEnBas = false;
			m_baseAffichee.ClearElementsAIntervention();
			m_baseAffichee.ClearRessources();
			m_baseAffichee.AddRessource(ressource);
			if (tache != m_tacheToHighlight)
				AssureInterventionVisible(tache);
			m_tacheToHighlight = tache;
			Refresh();
		}
		//-------------------------------------------------------------------
		public void AfficheForRessource(IRessourceEntreePlanning ressource, DateTime dateDebut, DateTime dateFin)
		{
			if (m_baseAffichee == null)
				m_baseAffichee = new CFournisseurEntreesPlanning(ressource.ContexteDonnee);
			MasquerEntetesLignes = true;
			EnableAffichageDatesEnBas = false;
			m_baseAffichee.ClearElementsAIntervention();
			m_baseAffichee.ClearRessources();
			m_baseAffichee.AddRessource(ressource);
			
			DateDebut = dateDebut.AddHours(-4);
			DateFin = dateFin.AddHours(4);
			CalculeEchelle(DateDebut, DateFin);
			Refresh();
		}



		#region IControlALockEdition Membres

		public bool LockEdition
		{
			get
			{
				return !m_gestionnaireModeEdition.ModeEdition;
			}
			set
			{
				m_gestionnaireModeEdition.ModeEdition = !value;
				if (OnChangeLockEdition != null)
					OnChangeLockEdition(this, new EventArgs());
			}
		}

		public event EventHandler OnChangeLockEdition;

		#endregion

		private void m_timerSendEventChangeDate_Tick(object sender, EventArgs e)
		{
			if (OnChangeBornesDates != null)
				OnChangeBornesDates(this, new EventArgs());
			m_timerSendEventChangeDate.Stop();
		}

		private void CControlePlanning_SizeChanged(object sender, EventArgs e)
		{
			CAppeleurFonctionAvecDelai.CallFonctionAvecDelai(this, "Refresh", 1000);
		}


		public event EventHandler OnEditerIntervention;
		private void m_menuEditerIntervention_Click(object sender, EventArgs e)
		{
			if (OnEditerIntervention != null)
			{
				OnEditerIntervention(this, new EventArgs());
			}
		}

		public IEntreePlanning EntreePlanningSelectionnee
		{
			get
			{
				if (m_infoTrancheSelectionnee != null && m_infoTrancheSelectionnee.Tranche != null)
				{
					return m_infoTrancheSelectionnee.Tranche.EntreePlanning;
				}
				return null;
			}
		}

		//------------------------------------------------------------------------
		private void checkListToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Point pt = Cursor.Position;
			if ( m_infoTrancheSelectionnee != null && m_infoTrancheSelectionnee.Tranche.EntreePlanning is CIntervention )
				CFormCheckListPopup.Popup ( pt, (CIntervention)m_infoTrancheSelectionnee.Tranche.EntreePlanning, !LockEdition );
		}

        //------------------------------------------------------------------------
        private void m_menuElementAIntervention_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            IElementAIntervention elt = item != null ? item.Tag as IElementAIntervention : null;
            if (elt != null)
            {
                //Ajoute l'élément s'il n'exite pas
                if (!m_baseAffichee.ElementsAIntervention.Contains(elt))
                {
                    m_baseAffichee.AddElementAIntervention(elt);
                    Refresh();
                }
            }
                
        }

        private bool m_bAllowDropInEntetesLignes = false;
        private void m_panelLignes_DragEnter(object sender, DragEventArgs e)
        {
            CReferenceObjetDonnee[] refs = e.Data.GetData(typeof(CReferenceObjetDonnee[])) as CReferenceObjetDonnee[];
            if (refs == null)
            {
                CReferenceObjetDonnee refObj = e.Data.GetData(typeof(CReferenceObjetDonnee)) as CReferenceObjetDonnee;
                if (refObj != null)
                    refs = new CReferenceObjetDonnee[] { refObj };
            }
            if (refs != null && refs.Length > 0)
            {
                Type tp = refs[0].TypeObjet;
                m_bAllowDropInEntetesLignes = typeof(IRessourceEntreePlanning).IsAssignableFrom(tp) ||
                    typeof(IElementAIntervention).IsAssignableFrom(tp) ||
                    typeof(IEntreePlanning).IsAssignableFrom(tp);
            }
            if (m_bAllowDropInEntetesLignes)
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }

        private void m_panelLignes_DragDrop(object sender, DragEventArgs e)
        {
            CReferenceObjetDonnee[] refs = e.Data.GetData(typeof(CReferenceObjetDonnee[])) as CReferenceObjetDonnee[];
            if (refs == null)
            {
                CReferenceObjetDonnee refObj = e.Data.GetData(typeof(CReferenceObjetDonnee)) as CReferenceObjetDonnee;
                if (refObj != null)
                    refs = new CReferenceObjetDonnee[] { refObj };
            }
            if ( refs != null )
            {
                foreach ( CReferenceObjetDonnee reference in refs )
                {
                    CObjetDonnee obj = reference.GetObjet ( m_baseAffichee.ContexteDonnee );
                    IElementAIntervention eltInter = obj as IElementAIntervention;
                    if ( eltInter != null )
                    {
                        if ( !m_baseAffichee.ElementsAIntervention.Contains ( eltInter ) )
                            m_baseAffichee.AddElementAIntervention ( eltInter );
                    }
                    else
                    {
                        IRessourceEntreePlanning res = obj as IRessourceEntreePlanning;
                        if (res != null && !m_baseAffichee.Ressources.Contains(res))
                            m_baseAffichee.AddRessource(res);
                        else
                        {
                            IEntreePlanning entree = obj as IEntreePlanning;
                            if (entree != null && entree.ElementLiePrincipal != null &&
                            !m_baseAffichee.ElementsAIntervention.Contains(entree.ElementLiePrincipal))
                                m_baseAffichee.AddElementAIntervention(entree.ElementLiePrincipal);
                        }
                    }
                }
                Refresh();
            }
        }

        private void m_panelLignes_DragLeave(object sender, EventArgs e)
        {
            m_bAllowDropInEntetesLignes = false;
        }

        private void m_scroll_ValueChanged(object sender, EventArgs e)
        {
            if (!m_bDragEnCours)
            {
                this.SuspendDrawing();
                m_panelDessin.Invalidate();
                m_panelLignes.Invalidate();
                this.ResumeDrawing();
            }
            else
                m_panelLignes.Invalidate();
        }

        private void m_menuAddMember_DropDownOpening(object sender, EventArgs e)
        {
            CInfoLigne info = null;
            if (m_infoLignes.TryGetValue(m_nNumLigneMenuLigne, out info))
            {
            }
        }

        private void OnSelectLigneInMenu(object sender, CObjetDonneeEventArgs args)
        {
            CActeur acteur = m_menuSelectItemDeLigne.TextBoxSelection.ElementSelectionne as CActeur;
            if (acteur != null && !m_baseAffichee.Ressources.Contains(acteur))
            {
                m_baseAffichee.AddRessource(acteur);
                Refresh();
            }
        }

        //--------------------------------------------------------------------------
        void menuLignes_OnSelectObject(object sender, CObjetDonneeEventArgs args)
        {
            C2iTextBoxSelectionneForMenu select = sender as C2iTextBoxSelectionneForMenu;
            if (select != null)
            {
                CObjetDonnee obj = select.TextBoxSelection.ElementSelectionne;
                if (obj != null)
                {
                    IElementAIntervention elt = obj as IElementAIntervention;
                    if (elt != null && !m_baseAffichee.ElementsAIntervention.Contains(elt))
                    {
                        m_baseAffichee.AddElementAIntervention(elt);
                        select.TextBoxSelection.ElementSelectionne = null;
                        Refresh();
                    }
                    IRessourceEntreePlanning res = obj as IRessourceEntreePlanning;
                    if (res != null && !m_baseAffichee.Ressources.Contains(res))
                    {
                        m_baseAffichee.AddRessource(res);
                        select.TextBoxSelection.ElementSelectionne = null;
                        Refresh();
                    }
                }
            }
        }

        //--------------------------------------------------------------------------
        private void itemListe_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            CListeEntites lst = item != null ? item.Tag as CListeEntites : null;
            if (lst != null)
            {
                CObjetDonnee[] objets = lst.ElementsLies;
                bool bIsRessource = objets.Length > 0 && typeof(IRessourceEntreePlanning).IsAssignableFrom(objets[0].GetType());
                foreach (CObjetDonnee objet in objets)
                {
                    if (!bIsRessource)
                    {
                        IElementAIntervention elt = objet as IElementAIntervention;
                        if (elt != null && !m_baseAffichee.ElementsAIntervention.Contains(elt))
                            m_baseAffichee.AddElementAIntervention(elt);
                    }
                    else
                    {
                        IRessourceEntreePlanning res = objet as IRessourceEntreePlanning;
                        if (res != null && !m_baseAffichee.Ressources.Contains(res))
                            m_baseAffichee.AddRessource(res);
                    }
                }
                Refresh();
                m_menuRClickLigne.Hide();
            }
        }

        //---------------------------------------------------------------
        CFiltreDynamique m_lastFiltreDynamique = null;
        private CFiltreData GetFiltre ( CFiltreDynamique filtre )
        {
            if ( filtre == null )
                return null;
            if (m_lastFiltreDynamique != null)
            {
                foreach (IVariableDynamique variable in m_lastFiltreDynamique.ListeVariables)
                {
                    object val = m_lastFiltreDynamique.GetValeurChamp(variable.IdVariable);
                    IVariableDynamique var2 = filtre.GetVariable(variable.IdVariable);
                    if (var2 != null && var2.Nom == variable.Nom)
                        filtre.SetValeurChamp(var2, val);
                }
            }
            m_lastFiltreDynamique = filtre;

            if (filtre.FormulaireEdition.Childs.Count() > 0)
            {
                if (!CFormFormulairePopup.EditeElement(
                    filtre.FormulaireEdition, filtre, "Filter|20175"))
                {
                    return null;
                }
            }
            CResultAErreur result = filtre.GetFiltreData();
            if ( result && result.Data is CFiltreData )
                return result.Data as CFiltreData;
            return null;
        }

        //--------------------------------------------------------------------------
        void itemRemoveByFiltre_Click(object sender, EventArgs e)
        {
            TraiteMenuFiltre(sender as ToolStripMenuItem, true);
        }

        private void TraiteMenuFiltre ( ToolStripMenuItem item, bool bSuppression )
        {
            CFiltreDynamiqueInDb filtreIndb = item != null ? item.Tag as CFiltreDynamiqueInDb : null;
            if (filtreIndb != null)
            {
                
                CFiltreData filtre = GetFiltre(filtreIndb.Filtre);
                if (filtre != null)
                {
                    CListeObjetsDonnees lst = new CListeObjetsDonnees(m_baseAffichee.ContexteDonnee, filtreIndb.TypeElements);
                    lst.Filtre = filtre;
                    foreach (CObjetDonnee obj in lst)
                    {
                        IElementAIntervention elt = obj as IElementAIntervention;
                        if (elt != null)
                        {
                            if (bSuppression)
                                m_baseAffichee.RemoveElementAIntervention(elt);
                            else
                            {
                                if (!m_baseAffichee.ElementsAIntervention.Contains(elt))
                                    m_baseAffichee.AddElementAIntervention(elt);
                            }
                        }
                        IRessourceEntreePlanning ressource = obj as IRessourceEntreePlanning;
                        if (ressource != null)
                        {
                            if (bSuppression)
                                m_baseAffichee.RemoveRessource(ressource);
                            else
                            {
                                if (!m_baseAffichee.Ressources.Contains(ressource))
                                    m_baseAffichee.AddRessource(ressource);
                            }
                        }
                    }
                    Refresh();
                }
            }

        }

        void itemAddByFiltre_Click(object sender, EventArgs e)
        {
            TraiteMenuFiltre(sender as ToolStripMenuItem, false);
        }


        //--------------------------------------------------------------------------
        void itemHideAll_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            Type tp = item != null ? item.Tag as Type : null;
            if (tp != null)
            {
                if (typeof(IElementAIntervention).IsAssignableFrom(tp))
                {
                    m_baseAffichee.ClearElementsAIntervention();
                }
                if (typeof(IRessourceEntreePlanning).IsAssignableFrom(tp))
                {
                    foreach (IRessourceEntreePlanning res in m_baseAffichee.Ressources.ToArray())
                        m_baseAffichee.RemoveRessource(res);
                }
                Refresh();
            }
        }

        //--------------------------------------------------------------------------
        void menuDates_OnValideDates(object sender, EventArgs e)
        {
            CToolStripDateTimePicker dtPicker = sender as CToolStripDateTimePicker;
            ITranchePlanning tranche = dtPicker != null ? dtPicker.Tag as ITranchePlanning : null;
            if (tranche!= null)
            {
                tranche.DateDebut = dtPicker.StartDate;
                tranche.DateFin = dtPicker.EndDate;
                Refresh();
            }
            m_menuRClickCalendrier.Hide();

        }

        //-------------------------------------------------------------------------
        private void m_menuEditerElementDeLigne_Click(object sender, EventArgs e)
        {
            if (m_infoLignes.ContainsKey(m_nNumLigneMenuLigne))
            {
                CInfoLigne info = m_infoLignes[m_nNumLigneMenuLigne];
                object objetAEditer = null;
                if (info.Ressource != null)
                    objetAEditer = info.Ressource;
                else if (info.ElementAIntervention != null)
                    objetAEditer = info.ElementAIntervention;
                if (objetAEditer != null)
                {
                    IFormNavigable frmNav = FindForm() as IFormNavigable;
                    if (frmNav != null)
                    {
                        frmNav.Navigateur.EditeElement(objetAEditer, false, "");
                    }
                }
            }
        }

	}
}
