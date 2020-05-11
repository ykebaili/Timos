using System;
using System.Resources;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using timos.data.version;
using sc2i.data;

namespace timos.version
{
	public partial class CControlTypeOperationAuditVersion : UserControl, IControlVivant
	{
		public CControlTypeOperationAuditVersion()
		{

		}
		public CControlTypeOperationAuditVersion(CTypeOperationSurObjet typeOp)
		{
			InitializeComponent();
			DoubleBuffered = true;
			SetLabel(typeOp);
		}
		public CControlTypeOperationAuditVersion(CTypeOperationSurObjet.TypeOperation typeop)
		{
			InitializeComponent();
			DoubleBuffered = true;
			SetLabel(new CTypeOperationSurObjet(typeop));
		}

		private void SetLabel(CTypeOperationSurObjet typeOp)
		{
			
		}


		#region IControlVivant Membres

		public Control Controle
		{
			get { return this; }
		}

		private bool m_bMustBeRedraw = true;
		public bool MustBeRedraw
		{
			get
			{
				return m_bMustBeRedraw;
			}
			set
			{
				m_bMustBeRedraw = value;
			}
		}

		public Bitmap ScreenShot
		{
			get { return CUtilControlVivant.GetScreenShot(this); }
		}

		public bool Initialiser(object valeur)
		{
			try
			{
				m_typeOp = (CTypeOperationSurObjet)valeur;
			}
			catch
			{
				m_typeOp = null;
				return false;
			}
			if (m_lbl == null)
			{
				Controls.Clear();
				m_lbl = new Label();
				m_panIco = new Panel();
				Panel PanConteneur = new Panel();
				PanConteneur.Width = 20;
				PanConteneur.Controls.Add(m_panIco);
				m_panIco.Width = 20;
				m_panIco.Height = 20;
				m_panIco.BackgroundImageLayout = ImageLayout.Stretch;
				Controls.Add(m_lbl);
				Controls.Add(PanConteneur);
				m_panIco.Dock = DockStyle.Top;
				PanConteneur.Dock = DockStyle.Left;
				m_lbl.Dock = DockStyle.Fill;
				m_lbl.TextAlign = ContentAlignment.MiddleCenter;
			}
			m_lbl.Text = m_typeOp.Libelle;
			switch (m_typeOp.Code)
			{
				case CTypeOperationSurObjet.TypeOperation.Ajout:
					m_panIco.BackgroundImage = Properties.Resources.add;
					break;
				case CTypeOperationSurObjet.TypeOperation.Aucune:
					break;
				case CTypeOperationSurObjet.TypeOperation.Modification:
					m_panIco.BackgroundImage = Properties.Resources.modify;
					break;
				case CTypeOperationSurObjet.TypeOperation.Suppression:
					m_panIco.BackgroundImage = Properties.Resources.delete;
					break;
				default:
					break;
			}
			return true;
		}
		private CTypeOperationSurObjet m_typeOp;
		public object Valeur
		{
			get
			{
				return m_typeOp;
			}
			set
			{
				try
				{
					m_typeOp = (CTypeOperationSurObjet)value;
				}
				catch
				{
					m_typeOp = null;
				}
			}
		}
		#endregion
	}
}
