using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using timos.data.commandes;
using System.Collections;
using sc2i.common;
using sc2i.win32.common;
using timos.data;

namespace timos.commandes
{
    public partial class CControleEditeLignesDeCommande : UserControl, IControlALockEdition
    {
        private CCommande m_commande = null;
        private Stack<CControleEditeLigneCommande> m_controlesReserve = new Stack<CControleEditeLigneCommande>();
        private CDonneesActeurFournisseur m_fournisseurPourFiltre = null;

        public CControleEditeLignesDeCommande()
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------
        public CDonneesActeurFournisseur FournisseurPourFiltre
        {
            get
            {
                return m_fournisseurPourFiltre;
            }
            set
            {
                m_fournisseurPourFiltre = value;
                foreach (CControleEditeLigneCommande ctrl in ControlesCommande)
                    ctrl.FournisseurPourFiltre = value;
            }
        }

        //------------------------------------------------------------------
        private IEnumerable<CControleEditeLigneCommande> ControlesCommande
        {
            get
            {
                List<CControleEditeLigneCommande> lst = new List<CControleEditeLigneCommande>();
                foreach (Control ctrl in m_panelLignes.Controls)
                {
                    CControleEditeLigneCommande c = ctrl as CControleEditeLigneCommande;
                    if (c != null)
                        lst.Add(c);
                }
                return lst.AsReadOnly();
            }
        }

        //------------------------------------------------------------------
        public void Init(CCommande commande)
        {
            m_commande = commande;
            m_panelLignes.Visible = false;
            m_panelLignes.SuspendDrawing();
            foreach (CControleEditeLigneCommande ctrl in ControlesCommande)
            {
                ctrl.Visible = false;
                m_controlesReserve.Push(ctrl);
            }

            bool bIsFirst = true;
            foreach (CLigneCommande ligne in m_commande.Lignes)
            {
                CControleEditeLigneCommande ctrl = AddControleLigne ( ligne );
                ctrl.IsFirst = bIsFirst;
                bIsFirst = false;

            }
            m_panelLignes.ResumeDrawing();
            m_panelLignes.Visible = true;
        }

        //------------------------------------------------------------
        private CControleEditeLigneCommande AddControleLigne ( CLigneCommande ligne )
        {
            CControleEditeLigneCommande ctrl = null;
            if (m_controlesReserve.Count() != 0)
                ctrl = m_controlesReserve.Pop();
            else
            {
                ctrl = new CControleEditeLigneCommande();
                m_panelLignes.Controls.Add(ctrl);
                m_extModeEdition.SetModeEdition(ctrl, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
                ctrl.OnAddLine += new EventHandler(ctrl_OnAddLine);
                ctrl.OnDelete += new EventHandler(ctrl_OnDelete);
                ctrl.OnGoDown += new EventHandler(ctrl_OnGoDown);
                ctrl.OnGoUp += new EventHandler(ctrl_OnGoUp);
            }
            ctrl.BringToFront();
            ctrl.Dock = DockStyle.Top;
            ctrl.LockEdition = !m_extModeEdition.ModeEdition;
            ctrl.FournisseurPourFiltre = m_fournisseurPourFiltre;
            ctrl.Init(ligne, ligne.Numero == 0);
            ctrl.Visible = true;
            return ctrl;
        }

        //------------------------------------------------------------
        void ctrl_OnGoUp(object sender, EventArgs e)
        {
            CControleEditeLigneCommande ctrl = sender as CControleEditeLigneCommande;
            if (ctrl == null)
                return;
            CLigneCommande ligne = ctrl.Ligne;
            if (ligne.Numero > 0)
            {
                RenumerotteLignes(ligne.Numero - 1, ligne.Numero - 1, 1);
                ligne.Numero--;
            }
            SortControls();
        }

        //------------------------------------------------------------
        void ctrl_OnGoDown(object sender, EventArgs e)
        {
            CControleEditeLigneCommande ctrl = sender as CControleEditeLigneCommande;
            if (ctrl == null)
                return;
            CLigneCommande ligne = ctrl.Ligne;
            if (ligne.Numero < m_commande.Lignes.Count - 1)
            {
                RenumerotteLignes(ligne.Numero + 1, ligne.Numero + 1, -1);
                ligne.Numero++;
            }
            SortControls();
        }

        //------------------------------------------------------------
        void ctrl_OnDelete(object sender, EventArgs e)
        {
            CControleEditeLigneCommande ctrl = sender as CControleEditeLigneCommande;
            if (ctrl == null)
                return;
            CLigneCommande ligne = ctrl.Ligne;
            int nNumero = ligne.Numero;
            RenumerotteLignes(nNumero, m_commande.Lignes.Count - 1, -1);
            CResultAErreur result = ligne.Delete(true);
            if (!result)
            {
                CFormAlerte.Afficher(result.Erreur);
                return;
            }
            ctrl.Visible = false;
            m_controlesReserve.Push(ctrl);
        }

        //------------------------------------------------------------
        void ctrl_OnAddLine(object sender, EventArgs e)
        {
            CControleEditeLigneCommande ctrl = sender as CControleEditeLigneCommande;
            if (ctrl == null)
                return;
            CLigneCommande ligneRef = ctrl.Ligne;
            RenumerotteLignes ( ligneRef.Numero+1, m_commande.Lignes.Count-1, 1);
            CLigneCommande ligne = new CLigneCommande(m_commande.ContexteDonnee);
            ligne.Commande = m_commande;
            ligne.Numero = ligneRef.Numero+1;
            AddControleLigne(ligne);
            SortControls();

        }

        //------------------------------------------------------------
        private void RenumerotteLignes(int nFrom, int nTo, int nInc)
        {
            foreach (CLigneCommande ligne in m_commande.Lignes)
            {
                if (ligne.Numero >= nFrom && ligne.Numero <= nTo)
                    ligne.Numero += nInc;
            }
        }

        //------------------------------------------------------------
        private void SortControls()
        {
            List<CControleEditeLigneCommande> lst = new List<CControleEditeLigneCommande>(ControlesCommande);
            lst.Sort((c1, c2) => c1.Ligne.Numero.CompareTo(c2.Ligne.Numero));
            m_panelLignes.SuspendDrawing();
            bool bFirst = true;
            foreach (CControleEditeLigneCommande ctrl in lst)
            {
                ctrl.BringToFront();
                ctrl.IsFirst = bFirst;
                bFirst = false;
            }
            m_panelLignes.ResumeDrawing();
        }




        private void m_lnkAddLine_LinkClicked(object sender, EventArgs e)
        {
            if (m_extModeEdition.ModeEdition)
            {
                CLigneCommande ligne = new CLigneCommande(m_commande.ContexteDonnee);
                ligne.Numero = m_commande.Lignes.Count;
                ligne.Commande = m_commande;
                AddControleLigne(ligne);
            }
        }

        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            foreach (CControleEditeLigneCommande ctrl in ControlesCommande)
            {
                result = ctrl.MajChamps();
                if (!result)
                    return result;
            }
            return result;
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
                    OnChangeLockEdition(this, null);
            }
        }

        public event EventHandler OnChangeLockEdition;

        #endregion
    }
}
