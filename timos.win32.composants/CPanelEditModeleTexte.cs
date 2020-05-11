using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using sc2i.common;
using sc2i.win32.common;
using sc2i.data;
using sc2i.data.dynamic;
using sc2i.workflow;
using sc2i.win32.data.dynamic;

namespace timos.win32.composants
{
	public partial class CPanelEditModeleTexte : UserControl, IControlALockEdition
	{
		private CFournisseurPropDynStd m_fournisseur = new CFournisseurPropDynStd();
		private CModeleTexte m_modele;
		private object m_objetTest = null;

		public CPanelEditModeleTexte()
		{
			InitializeComponent();
		}

		//-------------------------------------------------------------------------
		public CResultAErreur Init(CModeleTexte modele)
		{
			return Init ( modele, null );
		}

		public CResultAErreur Init ( CModeleTexte modele, object objetTest )
		{
			m_modele = modele;
			m_objetTest = objetTest;
			return InitChamps();
		}

		//-------------------------------------------------------------------------
		public CModeleTexte ModeleTexte
		{
			get
			{
				return m_modele;
			}
		}
		//-------------------------------------------------------------------------
		protected CResultAErreur InitChamps()
		{
			CResultAErreur result = CResultAErreur.True;
			result = m_exLinkField.FillDialogFromObjet(ModeleTexte);
			InitComboTypes(true);
			if (ModeleTexte.TypeAssocie != null)
				m_cmbTypeElements.SelectedValue = ModeleTexte.TypeAssocie;
			m_panelModele.Init(m_fournisseur, ModeleTexte.TypeAssocie);
			m_panelModele.TextBoxData = ModeleTexte.DataModele;
			m_panelModele.TextBackColor = ModeleTexte.CouleurFond;
			m_btnTest.Enabled = m_objetTest != null;
			return result;
		}
		//-------------------------------------------------------------------------
		public CResultAErreur MAJ_Champs()
		{
			CResultAErreur result = m_exLinkField.FillObjetFromDialog(ModeleTexte);
			if (result)
			{
				if (m_cmbTypeElements.SelectedValue == null || m_cmbTypeElements.SelectedValue == typeof(DBNull))
				{
					result.EmpileErreur(I.T( "Select element type for this model|473"));
				}
				else
					ModeleTexte.TypeAssocie = (Type)m_cmbTypeElements.SelectedValue;
			}
			if (result)
				ModeleTexte.DataModele = m_panelModele.TextBoxData;
            ModeleTexte.ModeleEnTexte = m_panelModele.TextModel;
			ModeleTexte.CouleurFond = m_panelModele.TextBackColor;
			return result;
		}

		//-------------------------------------------------------------------------
		private bool m_bComboRemplissageInitialized = false;
		protected void InitComboTypes(bool bForcerRemplissage)
		{
			if (!m_bComboRemplissageInitialized || bForcerRemplissage)
			{
				ArrayList classes = new ArrayList(DynamicClassAttribute.GetAllDynamicClass());
                classes.Insert(0, new CInfoClasseDynamique(typeof(DBNull), I.T("(None)|30291")));
                m_cmbTypeElements.DataSource = null;
				m_cmbTypeElements.DataSource = classes;
				m_cmbTypeElements.ValueMember = "Classe";
				m_cmbTypeElements.DisplayMember = "Nom";

				m_bComboRemplissageInitialized = true;
			}

		}

		//-------------------------------------------------------------------------
		private void m_cmbTypeElements_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (m_cmbTypeElements.SelectedValue is Type && m_cmbTypeElements.SelectedValue != typeof(DBNull) )
			{
				Type tp = (Type)m_cmbTypeElements.SelectedValue;
				m_panelModele.Init(m_fournisseur, tp);
				if (typeof(CObjetDonnee).IsAssignableFrom(tp))
					m_btnSelectElementTest.Enabled = true;
				else
					m_btnSelectElementTest.Enabled = false;
			}
		}

		//-------------------------------------------------------------------------
		private bool SelectObjetTest()
		{
			if (m_cmbTypeElements.SelectedValue is Type && m_cmbTypeElements.SelectedValue != typeof(DBNull))
			{
				CObjetDonnee objet = CFormSelectUnObjetDonnee.SelectObjetDonnee(
                    I.T("Select an element for test|20029"),
                    (Type)m_cmbTypeElements.SelectedValue);
				if (objet != null)
					m_objetTest = objet;
				m_btnTest.Enabled = m_objetTest != null;
				return objet != null;
			}
			return false;
		}

		//-------------------------------------------------------------------------
		private void m_btnSelectElementTest_Click(object sender, EventArgs e)
		{
			SelectObjetTest();
			
		}

		//-------------------------------------------------------------------------
		private void m_btnTest_Click(object sender, EventArgs e)
		{
			if (m_objetTest == null)
				SelectObjetTest();
			if (m_objetTest == null)
				return;
			CResultAErreur result = MAJ_Champs();
			if (!result)
			{
				CFormAlerte.Afficher(result.Erreur);
				return;
			}
			CRichTextViewerPopup.Popup(PointToScreen(m_btnTest.Location), ModeleTexte, m_objetTest);
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
	}
}
