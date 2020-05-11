using System;
using System.Diagnostics;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using sc2i.common;

namespace TimosDataServeur
{
	public partial class CtrlProgressBarDataBase : UserControl, IIndicateurProgression
	{
		private List<CtrlProgressBarDataBaseElement> m_barres;
		private List<string> m_strSegments;
		private int m_nEspacementBarres = 40;
		private int m_nLargeurTitre = 150;
		public int EspacementBarres
		{
			get
			{
				return m_nEspacementBarres;
			}
			set
			{
				m_nEspacementBarres = value;
			}
		}
		public int LargeurTitre
		{
			get
			{
				return m_nLargeurTitre;
			}
			set
			{
				m_nLargeurTitre = value;
				foreach (CtrlProgressBarDataBaseElement ele in m_barres)
					ele.LargeurTitre = m_nLargeurTitre;
			}
		}
		private CtrlProgressBarDataBaseElement PremiereBarre
		{
			get
			{
				if (m_barres != null && m_barres.Count > 0)
					return m_barres[0];
				return null;
			}
		}
		private CtrlProgressBarDataBaseElement DerniereBarre
		{
			get
			{
				if (m_barres != null && m_barres.Count > 0)
					return m_barres[m_barres.Count - 1];
				return null;
			}
		}
		private string DernierLibelle
		{
			get
			{
				if (m_strSegments != null && m_strSegments.Count > 0)
					return m_strSegments[m_strSegments.Count - 1];
				return "";
			}
		}

		public CtrlProgressBarDataBase()
		{
			InitializeComponent();

			m_barres = new List<CtrlProgressBarDataBaseElement>();
			m_strSegments = new List<string>();
			Height = 0;
		}

		delegate void DelegueAjoutBarre(string titre, int min, int max);
		public void AjouterBarre(string titre, int min, int max)
		{
			if (InvokeRequired)
			{
				DelegueAjoutBarre d = new DelegueAjoutBarre(AjouterBarreSafe);
				Invoke(d, new object[] { titre, min, max });
			}
			else
				AjouterBarreSafe(titre, min, max);
		}
		public void AjouterBarreSafe(string titre, int min, int max)
		{
			CtrlProgressBarDataBaseElement bar = new CtrlProgressBarDataBaseElement(min, max, titre, true, true, true, true);
			bar.Height = m_nEspacementBarres;
			bar.OperationEnCour = "";
			bar.LargeurTitre = m_nLargeurTitre;
			m_barres.Add(bar);
			Height += m_nEspacementBarres;
			Controls.Add(bar);
			bar.Dock = DockStyle.Top;
			bar.BringToFront();
		}

		delegate void DelegueSupprimerDerniereBarre();
		public void SupprimerDerniereBarre()
		{
			if (InvokeRequired)
			{
				DelegueSupprimerDerniereBarre d = new DelegueSupprimerDerniereBarre(SupprimerDerniereBarreSafe);
				Invoke(d, new object[] {});
			}
			else
				SupprimerDerniereBarreSafe();
		}
		public void SupprimerDerniereBarreSafe()
		{
			if (DerniereBarre == null)
				return;
			DerniereBarre.Visible = false;
			Controls.Remove(DerniereBarre);
			DerniereBarre.Dispose();
			m_barres.Remove(DerniereBarre);
			Height -= m_nEspacementBarres;
		}


		public bool ProgressionEnCour
		{
			get
			{
				return m_barres.Count > 0;
			}
		}

		public void Masquer(bool bMasquer)
		{
			Visible = !bMasquer;
			if (!bMasquer)
				Refresh();
		}

		#region IIndicateurProgression Membres

		public bool CanCancel
		{
			get
			{
				return true;
			}
			set
			{
			}
		}

		public bool CancelRequest
		{
			get { return true; }
		}

		public void PopSegment()
		{
			SupprimerDerniereBarre();
		}
		public void PushSegment(int nMin, int nMax)
		{
			AjouterBarre(DernierLibelle, nMin, nMax);
		}

		public void SetBornesSegment(int nMin, int nMax)
		{
			if (DerniereBarre != null)
			{
				DerniereBarre.Minimum = nMin;
				DerniereBarre.Maximum = nMax;
			}
			//else if (PremiereBarre != null && DerniereBarre != PremiereBarre)
			//{
			//    //PremiereBarre.
			//}
		}

		private string m_strInfoOp;
		public void SetInfo(string strInfo)
		{
			m_strInfoOp = strInfo;
		}

		public void SetValue(int nValue)
		{
			if (DerniereBarre != null)
			{
				DerniereBarre.ValeurActuelle = nValue;
				DerniereBarre.OperationEnCour = m_strInfoOp;
			}
				//DerniereBarre.Increment(nValue - DerniereBarre.);

			//if (PremiereBarre != null && PremiereBarre != DerniereBarre)
			//    PremiereBarre.Increment(1);
		}

		public void PopLibelle()
		{
			if(m_strSegments.Count > 0)
				m_strSegments.RemoveAt(m_strSegments.Count - 1);
		}

		public void PushLibelle(string strInfo)
		{
			m_strSegments.Add(strInfo);
		}
		#endregion
	}
}
