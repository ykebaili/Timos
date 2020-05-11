using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using timos.data.snmp;
using sc2i.win32.common;
using System.Collections;
using sc2i.data;
using sc2i.win32.data.dynamic;
using sc2i.common;
using sc2i.formulaire.win32.editor;

namespace timos.snmp
{
    public partial class CPanelEditeEntitesSnmp : UserControl, IControlALockEdition
    {
        private IConteneurEntitesSnmp m_conteneur = null;
        private CTypeEntiteSnmp m_typeEntites = null;

        public CPanelEditeEntitesSnmp()
        {
            InitializeComponent();
        }

        //---------------------------------------------------------------
        public void InitChamps(IConteneurEntitesSnmp conteneur,
            CTypeEntiteSnmp typeEntites)
        {
            m_panelEntites.SuspendDrawing();
            m_conteneur = conteneur;
            m_typeEntites = typeEntites;
            HashSet<string> indexsOuverts = new HashSet<string>();
            foreach (Control ctlr in new ArrayList(m_panelEntites.Controls))
            {
                CPanelEditeEntiteSnmp panel = ctlr as CPanelEditeEntiteSnmp;
                if (panel != null && !panel.IsCollapse && panel.ElementEdite.IsValide())
                    indexsOuverts.Add(panel.ElementEdite.Index);
                ctlr.Visible = false;
                m_extModeEdition.SetModeEdition ( ctlr, TypeModeEdition.Autonome );
                m_panelEntites.Controls.Remove(ctlr);
                try
                {
                    ctlr.Dispose();
                }
                catch { }
            }

            FillEntities(indexsOuverts);

            m_panelEntites.ResumeDrawing();
        }

        //---------------------------------------------------------------
        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            foreach (Control ctrl in m_panelEntites.Controls)
            {
                CPanelChampsCustom panelChamps = ctrl as CPanelChampsCustom;
                if (panelChamps != null)
                {
                    result = panelChamps.MAJ_Champs();
                    if (!result)
                    {
                        result.EmpileErreur(I.T("Erreur on entity @1|20312", panelChamps.ElementEdite.DescriptionElement));
                        return result;
                    }
                }
                CPanelEditeEntiteSnmp panelSlide = ctrl as CPanelEditeEntiteSnmp;
                if (panelSlide != null)
                {
                    result = panelSlide.MajChamps();
                    if (!result)
                    {
                        result.EmpileErreur(I.T("Erreur on entity @1|20312", panelSlide.ElementEdite.DescriptionElement));
                        return result;
                    }
                }
                CPanelFormulaireSurElement panelFormulaire = ctrl as CPanelFormulaireSurElement;
                if (panelFormulaire != null)
                {
                    result = panelFormulaire.AffecteValeursToElement();
                    if (!result)
                    {
                        result.EmpileErreur(I.T("Erreur on entity @1|20312", panelSlide.ElementEdite.DescriptionElement));
                        return result;
                    }
                }
            }
            return result;
        }



        //---------------------------------------------------------------
        private void FillEntities(HashSet<string> indexsOuverts)
        {
            
            if (m_typeEntites != null && m_typeEntites.ModeFormulaire.Code == EModeFormulairePourTypeEntite.FormulaireSurAgent)
            {
                if (m_typeEntites.FormulaireUnique != null)
                {
                    CPanelFormulaireSurElement panel = new CPanelFormulaireSurElement();
                    panel.InitPanel(m_typeEntites.FormulaireUnique.Formulaire, m_conteneur);
                    m_panelEntites.Controls.Add(panel);
                    panel.Dock = DockStyle.Fill;
                    panel.LockEdition = !m_extModeEdition.ModeEdition;
                    m_extModeEdition.SetModeEdition(panel, TypeModeEdition.EnableSurEdition);
                }
                return;
            }
            CListeObjetsDonnees lst = m_conteneur.EntitesRacines;
            lst.Filtre = new CFiltreData(CTypeEntiteSnmp.c_champId + "=@1",
                m_typeEntites.Id);
            lst.Tri = CEntiteSnmp.c_champIndex;
            /*if (lst.Count == 1)
            {
                CEntiteSnmp entite = lst[0] as CEntiteSnmp;
                CPanelChampsCustom panel = new CPanelChampsCustom();
                m_panelEntites.Controls.Add(panel);
                panel.Dock = DockStyle.Fill;
                panel.LockEdition = !m_extModeEdition.ModeEdition;
                m_extModeEdition.SetModeEdition(panel, TypeModeEdition.EnableSurEdition);
                panel.ElementEdite = entite;
            }
            else*/
            {
                foreach (CEntiteSnmp entite in lst)
                {
                    CPanelEditeEntiteSnmp panel = new CPanelEditeEntiteSnmp();
                    m_panelEntites.Controls.Add(panel);
                    panel.Dock = DockStyle.Top;
                    panel.Init(entite);
                    panel.BringToFront();
                    panel.LockEdition = !m_extModeEdition.ModeEdition;
                    m_extModeEdition.SetModeEdition(panel, TypeModeEdition.EnableSurEdition);
                    if (indexsOuverts != null && indexsOuverts.Contains(entite.Index))
                        panel.Extend();
                    if (lst.Count == 1)
                    {
                        panel.Extend();
                        panel.TitleHeight = 0;
                    }
                }
            }
        }




        #region IControlALockEdition Membres

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

        #endregion

    }
}
