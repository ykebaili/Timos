using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using sc2i.win32.common;
using sc2i.common;

namespace HelpExtender
{
	public partial class CFormSelectHelpPage : Form
	{

		#region :: Propriétés ::
		private ETypeSelection m_typeSelection;
		private bool m_bAutoriserCreation;
		#endregion

		#region ++ Constructeurs ++
		public CFormSelectHelpPage()
		{
			InitializeComponent();
		}
		#endregion

		#region ~~ Méthodes ~~
		public static CHelpData SelectHelp()
		{
			return SelectHelp(ETypeSelection.SelonTitre);
		}

		public static CHelpData SelectHelp(ETypeSelection typeSelection)
		{
			CFormSelectHelpPage form = new CFormSelectHelpPage();
			form.Initialiser(typeSelection);
			CHelpData help = null;
			if (form.ShowDialog() == DialogResult.OK)
			{
				help = form.HelpSelectionne;
			}
			form.Dispose();
			return help;
		}



		public void Initialiser()
		{
			Initialiser(ETypeSelection.SelonTitre);
		}
		public void Initialiser(ETypeSelection typeliaison)
		{
			m_bAutoriserCreation = true;
			m_typeSelection = typeliaison;
			InitialiserCtrlsSelec();
			Afficher();
		}


		private void InitialiserCtrlsSelec()
		{
			ctrl_selectType.Dock = DockStyle.Fill;
			ctrl_selectIndependant.Dock = DockStyle.Fill;
			ctrl_selectControl.Dock = DockStyle.Fill;
			ctrl_selectMenu.Dock = DockStyle.Fill;
			ctrl_selectSelonTitre.Dock = DockStyle.Fill;

			ctrl_selectSelonTitre.Initialiser();
			ctrl_selectMenu.Initialiser(CHelpData.SourceAide.MenuRoot, false);
			ctrl_selectType.Initialiser();
			ctrl_selectIndependant.Initialiser();
			ctrl_selectControl.Initialiser(m_bAutoriserCreation);

			ctrl_selectTypeSelection.Liaison = m_typeSelection;
		}
		private void Afficher()
		{
			Control ctrlAffiche = null;
			switch (m_typeSelection)
			{
				case ETypeSelection.Menu: 
					ctrlAffiche = ctrl_selectMenu;
					Text = I.T("Document choice by menu navigation |30052");
					break;

				case ETypeSelection.Controles: 
					ctrlAffiche = ctrl_selectControl;
					Text = I.T("Choice between the documents linked to active window controls |30053");
					break;

				case ETypeSelection.Independants: 
					ctrlAffiche = ctrl_selectIndependant;
					Text = I.T("Choice between independant documents |30054");
					break;
				
				default:
				case ETypeSelection.SelonTitre:
					ctrlAffiche = ctrl_selectSelonTitre;
					Text = I.T("Choice between existing documents |30055");
					break;
			}

			foreach (Control ctrl in pan_contenu.Controls)
				ctrl.Visible = false;

			ctrlAffiche.Visible = true;
		}
		#endregion

		#region >> Assesseurs <<
		public bool AutoriserCreation
		{
			get
			{
				return m_bAutoriserCreation;
			}
			set
			{
				m_bAutoriserCreation = value;
				ctrl_selectControl.Initialiser(m_bAutoriserCreation);
			}
		}
		public CHelpData HelpSelectionne
		{
			get
			{
				CHelpData selec = null;
				switch (m_typeSelection)
				{
					case ETypeSelection.Controles: selec = ctrl_selectControl.HelpSelectionne; break;
					case ETypeSelection.Menu: selec = ctrl_selectMenu.HelpSelectionnee; break;
					case ETypeSelection.Independants: selec = ctrl_selectIndependant.HelpSelectionne; break;
					default:
					case ETypeSelection.SelonTitre: selec = ctrl_selectSelonTitre.HelpSelectionne; break;
				}
				return selec;
			}
		}
		public bool LiaisonModifiable
		{
			get
			{
				return ctrl_selectTypeSelection.Enabled;
			}
			set
			{
				ctrl_selectTypeSelection.Enabled = value;
			}
		}
		#endregion

		#region ** Evenements **


		private void ctrl_selectLiaison_ChangementTypeLiaison(object sender, EventArgs e)
		{
			m_typeSelection = ctrl_selectTypeSelection.Liaison;
			Afficher();
		}


		private void btn_annuler_Click(object sender, EventArgs e)
		{
			CHelpExtender.ArreterClignotementControl();
			DialogResult = DialogResult.Abort;
			Close();
		}

		private void btn_ok_Click(object sender, EventArgs e)
		{
			if (!m_bAutoriserCreation && !HelpSelectionne.DejaEnregistre)
				CFormAlerte.Afficher(I.T("This help has never had been created : it cannot be selected|30051"), EFormAlerteType.Exclamation);
			else
			{
				CHelpExtender.ArreterClignotementControl();
				DialogResult = DialogResult.OK;
				Close();
			}
		}
		private void DoubleClickHelp(object sender, EventArgs e)
		{
			btn_ok_Click(sender, e);

		}

		#endregion
	}
}