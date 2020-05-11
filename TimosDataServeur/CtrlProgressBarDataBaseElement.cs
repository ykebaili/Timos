using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace TimosDataServeur
{
	public partial class CtrlProgressBarDataBaseElement : UserControl
	{

		public CtrlProgressBarDataBaseElement(int min, int max, string title, bool afficherTitre, bool afficherPourCent, bool afficherCompteurElement, bool afficherOperationEnCour)
		{
			InitializeComponent();
			m_ctrlProgressBar.Value = min;
			m_ctrlProgressBar.Minimum = min;
			m_ctrlProgressBar.Maximum = max;
			m_lblTitre.Text = title;
			m_panOp.Visible = afficherOperationEnCour;
			m_panNbs.Visible = afficherCompteurElement;
			m_panTitre.Visible = afficherTitre;
			m_panPourCent.Visible = afficherPourCent;
			ActualiserLabels();
		}

		private void ActualiserLabels()
		{
			ActualiserTitre();
			ActualiserCompteur();
			ActualiserPourCent();
		}

		private void ActualiserTitre()
		{
			//m_lblTitre.Text = getin
		}
		private void ActualiserPourCent()
		{
			if (Maximum == 0)
				return;
			double nbPourCent = (m_ctrlProgressBar.Value * 100) / Maximum;
			m_lblPourCent.Text = nbPourCent.ToString() + "%";
		}
		private void ActualiserCompteur()
		{
			m_lblNbs.Text = m_ctrlProgressBar.Value.ToString() + "/" + Maximum.ToString();
		}

		public int Maximum
		{
			get
			{
				return m_ctrlProgressBar.Maximum;
			}
			set
			{
				m_ctrlProgressBar.Maximum = value;

			}
		}
		public int Minimum
		{
			get
			{
				return m_ctrlProgressBar.Minimum;
			}
			set
			{
				m_ctrlProgressBar.Minimum = value;
			}
		}

		public int ValeurActuelle
		{
			get
			{
				return m_ctrlProgressBar.Value;
			}
			set
			{
				m_ctrlProgressBar.Value = value;
				ActualiserLabels();
			}
		}

		public bool AfficherTitre
		{
			get
			{
				return m_panTitre.Visible;
			}
			set
			{
				m_panTitre.Visible = value;
			}
		}
		public bool AfficherCompteurElements
		{
			get
			{
				return m_panNbs.Visible;
			}
			set
			{
				m_panNbs.Visible = value;
			}
		}
		public bool AfficherPourCent
		{
			get
			{
				return m_panPourCent.Visible;
			}
			set
			{
				m_panPourCent.Visible = value;
			}
		}
		public bool AfficherOperationEnCour
		{
			get
			{
				return m_panOp.Visible;
			}
			set
			{
				m_panOp.Visible = value;
			}
		}
		public string Titre
		{
			get
			{
				return m_lblTitre.Text;
			}
			set
			{
				m_lblTitre.Text = value;
			}
		}
		public string OperationEnCour
		{
			get
			{
				return m_lblOp.Text;
			}
			set
			{
				m_lblOp.Text = value;
			}
		}

		public int LargeurTitre
		{
			get
			{
				return m_panTitre.Width;
			}
			set
			{
				m_panTitre.Width = value;
			}
		}

		public void Increment(int val)
		{
			m_ctrlProgressBar.Increment(val);
			ActualiserLabels();
		}

		public void Decrement(int val)
		{
			m_ctrlProgressBar.Decrement(val);
			ActualiserLabels();
		}


	}
}
