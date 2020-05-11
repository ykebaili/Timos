using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using sc2i.win32.common;
using timos.data;
using timos.data.projet.gantt;
using timos.data.projet;
using timos.securite;
using sc2i.win32.data;

namespace timos.win32.gantt
{
    public partial class CGanttDiagram : UserControl, IControlALockEdition
    {
        IBaseGantt m_base = null;
        CParametresAffichageGantt m_parametreAffichage = new CParametresAffichageGantt();

        public CGanttDiagram()
        {
            InitializeComponent();
        }
        
        public CParametresAffichageGantt Parametre
        {
            get
            {
                return m_parametreAffichage;
            }
            set
            {
                m_parametreAffichage = value;
                m_arbre.ItemHeight = m_parametreAffichage.LineHeight;
            }
        }

        public CParametreDessinLigneGantt ParametreDessinLigne
        {
            get
            {
                if (m_zoneBarres != null)
                    return m_zoneBarres.ParametreDessinLigne;
                return null;
            }
            set
            {
                if (value != null)
                {
                    m_arbre.ParametreDessinLigne = value;
                    m_zoneBarres.ParametreDessinLigne = value;
                }
            }
        }

        public void RefreshElement(IElementDeGantt elt)
        {
            m_arbre.RefreshNode(elt);
            m_zoneBarres.Refresh();

        }

        //Retourne l'élément qui définit l'unité par défaut
        private IElementAUniteGanttParDefaut GetElementUniteDefault()
        {
            if ( m_base != null )
            {
                return m_base.GetElements().FirstOrDefault(e => typeof(IElementAUniteGanttParDefaut).IsAssignableFrom(e.GetType()) && e.ElementParent == null) as IElementAUniteGanttParDefaut;
            }
            return null;
            
        }

        public void Init ( IBaseGantt baseGantt )
        {
            IElementDeGantt eltSel = SelectedElement;
            m_base = baseGantt;
            IElementAUniteGanttParDefaut eltAUniteDefaut = GetElementUniteDefault();
            if (eltAUniteDefaut != null)
            {
                Parametre.Unit = eltAUniteDefaut.UniteParDefaut;
                Parametre.PrecisionUnit = eltAUniteDefaut.PrecisionParDefault;
            }


            m_zoneTemps.AllowChangeDefaultUnit =
                eltAUniteDefaut != null &&
                !m_extModeEdition.ModeEdition &&
                CUtilUtilisateur.UtilisateurConnecteIsAdministrateur(CSc2iWin32DataClient.ContexteCourant);
                
                

            m_arbre.Init(m_base, Parametre.DateDebut, Parametre.CalcDateFin(m_panelTimeEtBarres.ClientSize.Width));
            m_zoneTemps.ParametreAffichage = Parametre;
            m_zoneBarres.Init ( Parametre, m_base, m_zoneTemps, m_arbre );
            SelectedElement = eltSel;
            
            
            
        }

        private void m_arbre_OnChangePosition(object sender, EventArgs e)
        {
            m_zoneBarres.Invalidate();
        }

        private void m_arbre_SelectionChanged(object sender, EventArgs e)
        {
            m_zoneBarres.SelectedElement = m_arbre.SelectedElement;
        }

        private void m_zoneBarres_SelectionChanged(object sender, EventArgs e)
        {
            m_arbre.SelectedElement = m_zoneBarres.SelectedElement;
        }
            
        public IElementDeGantt SelectedElement
        {
            get
            {
                return m_arbre.SelectedElement;
            }
            set
            {
                m_arbre.SelectedElement = value;
            }
        }

        public event GanttElementEventHandler ElementGanttArbreDoubleClick;
        public event GanttElementEventHandler ElementGanttArbreMouseDown;

        private void m_arbre_ElementGanttDoubleClick(object sender, CGanttElementEventArgs args)
        {
            if (ElementGanttArbreDoubleClick != null)
                ElementGanttArbreDoubleClick(this, args);
        }

        private void m_arbre_ElementGanttMouseDown(object sender, CGanttElementEventArgs args)
        {
            if (ElementGanttArbreMouseDown != null)
                ElementGanttArbreMouseDown(this, args);
        }







        public void OnChangeFilsProjet(sc2i.data.IObjetHierarchiqueACodeHierarchique iObjetHierarchiqueACodeHierarchique)
        {
            throw new NotImplementedException();
        }

        private bool m_bNoChangeOnScroll = false;
        private void m_scrollDate_Scroll(object sender, ScrollEventArgs e)
        {
            if (!m_panelInfoScroll.Visible)
                m_panelInfoScroll.Visible = true;
            m_lblDateScroll.Text = Parametre.AddCells(Parametre.DateDebut, m_scrollDate.Value).ToShortDateString();
        }

        private void m_timerHideInfoScroll_Tick(object sender, EventArgs e)
        {
            m_panelInfoScroll.Visible = false;
            m_timerHideInfoScroll.Stop();
            if (!m_scrollDate.Capture )
            {
                Parametre.DateDebut = Parametre.AddCells(Parametre.DateDebut, m_scrollDate.Value);
                m_bNoChangeOnScroll = true;
                m_scrollDate.Value = 0;
                m_bNoChangeOnScroll = false;
            }
        }

        private void m_scrollDate_ValueChanged(object sender, EventArgs e)
        {
            if (!m_bNoChangeOnScroll)
            {
                m_timerHideInfoScroll.Stop();
                m_timerHideInfoScroll.Start();
            }
        }

        private void m_scrollDate_Resize(object sender, EventArgs e)
        {
            if (m_scrollDate.Width > 10)
            {
                m_bNoChangeOnScroll = true;
                m_scrollDate.Maximum = m_scrollDate.Width / 2;
                m_scrollDate.Minimum = -m_scrollDate.Width / 2;
                m_scrollDate.Value = 0;
                m_scrollDate.LargeChange = (int)(ClientSize.Width / Parametre.CellWidth) - 1;
                m_bNoChangeOnScroll = false;
            }
        }


        public bool LockEdition
        {
            get
            {
                return !m_extModeEdition.ModeEdition;
            }
            set
            {
                m_extModeEdition.ModeEdition = !value;
                if (OnChangeLockEdition != null)
                    OnChangeLockEdition(this, new EventArgs());
            }
        }

        public event EventHandler OnChangeLockEdition;

        public event GanttElementEventHandler GanttContextMenuOpenning;
        private void m_zoneBarres_BarContextMenuOpenning(object sender, CGanttElementEventArgs args)
        {
            // Remonte simplement l'évenement d'ouverture du menu da la zone GanttBar
            if (GanttContextMenuOpenning != null)
                GanttContextMenuOpenning(sender, args);
        }


        public event OnMoveGanttElement OnMoveElementDeGantt;
        // Remonte l'événement du CGanttBar
        private void m_zoneBarres_OnMoveElementDeGantt(IElementDeGantt element)
        {
            if (OnMoveElementDeGantt != null)
                OnMoveElementDeGantt(element);
        }

        public ContextMenuStrip MenuRClickArbre
        {
            get
            {
                return m_arbre.MenuRClick;
            }
        }

        private void m_zoneTemps_OnApplyAsDefaultScale(EGanttTimeUnit unit, int nPrecision)
        {
            IElementAUniteGanttParDefaut elt = GetElementUniteDefault();
            if ( elt != null )
            {
                elt.UniteParDefaut = unit;
                elt.PrecisionParDefault = nPrecision;
            }
        }

    }
}
