using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using sc2i.win32.common;
using sc2i.formulaire;
using sc2i.common;
using sc2i.expression;
using timos.data;
using timos.acteurs;
using sc2i.common.Restrictions;


namespace sc2i.formulaire.win32.controles2iWnd
{
    [AutoExec("Autoexec")]
    public class CWndForC2iWndContacts : CControlWndFor2iWnd, IControleWndFor2iWnd
    {
		public class CLinkLabelToujoursActive : LinkLabel, IControlALockEdition
		{
			public bool LockEdition
			{
				get
				{
					return false;
				}
				set
				{
					if (OnChangeLockEdition != null)
						OnChangeLockEdition(this, new EventArgs());
				}
			}
			public event EventHandler OnChangeLockEdition;
		}

		private CLinkLabelToujoursActive m_linkLabel = new CLinkLabelToujoursActive();
        

        public static void Autoexec()
        {
            CCreateur2iFormulaireV2.RegisterEditeur(typeof(C2iWndContacts), typeof(CWndForC2iWndContacts));
        }


		//-----------------------------------------------------------
		protected override void  MyCreateControle(
            CCreateur2iFormulaireV2 createur,
            C2iWnd wnd,
            Control parent,
            IFournisseurProprietesDynamiques fournisseurProprietes)
        {
            if (WndContactAssocie == null)
                return;
            CCreateur2iFormulaireV2.AffecteProprietesCommunes(WndContactAssocie, m_linkLabel);
            m_linkLabel.Text = WndContactAssocie.Text;
            m_linkLabel.TextAlign = WndContactAssocie.TextAlign;
            switch (WndContactAssocie.BorderStyle)
            {
                case C2iWndLabel.LabelBorderStyle._3D:
                    m_linkLabel.BorderStyle = BorderStyle.Fixed3D;
                    break;
                case C2iWndLabel.LabelBorderStyle.Aucun:
                    m_linkLabel.BorderStyle = BorderStyle.None;
                    break;
                case C2iWndLabel.LabelBorderStyle.Plein:
                    m_linkLabel.BorderStyle = BorderStyle.FixedSingle;
                    break;
            }
            // Evenement clic
            m_linkLabel.LinkClicked += new LinkLabelLinkClickedEventHandler(CWndFor2iLink_LinkClicked);
            parent.Controls.Add(m_linkLabel);
        }

        //------------------------------------------------------------------------------
        void CWndFor2iLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
			if ( ElementAContacts != null )
				CFormFloatContacts.AfficherContacts(ElementAContacts);
        }

		//------------------------------------------------------------------------------
        public override Control Control
        {
            get
            {
                return m_linkLabel;
            }
        }

		//------------------------------------------------------------------------------
		private C2iWndContacts WndContactAssocie
		{
			get
			{
				return WndAssociee as C2iWndContacts;
			}
		}

		//------------------------------------------------------------------------------
		private IElementAContacts ElementAContacts
		{
			get
			{
				return EditedElement as IElementAContacts;
			}
		}

		//------------------------------------------------------------------------------
		protected override void OnChangeElementEdite(object element)
        {
        }

		//------------------------------------------------------------------------------
		protected override CResultAErreur MyMajChamps(bool bControlerLesValeursAvantValidation)
		{
            return CResultAErreur.True;
        }

		//------------------------------------------------------------------------------
		protected override void MyUpdateValeursCalculees()
		{
        }



        //---------------------------------------------
        protected override void MyAppliqueRestriction(
            CRestrictionUtilisateurSurType restrictionSurObjetEdite,
            CListeRestrictionsUtilisateurSurType restrictions,
            IGestionnaireReadOnlySysteme gestionnaireReadOnly)
		{
        }

        public override bool LockEdition
        {
            get
            {
                return false;
            }
            set
            {
                Control.Enabled = true;
            }
        }
    }
}
