using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Drawing;

namespace timos
{
	/// <summary>
	/// Permet d'unifier la tailler sur plusieurs controles
	/// </summary>
	public partial class CSizeUnifier : Component
	{
		public CSizeUnifier(Size taille)
		{
			m_bSizeInitialized = false;
			InitializeComponent();
			TailleReference = taille;
		}
		public CSizeUnifier()
		{
			m_bSizeInitialized = false;
			InitializeComponent();
		}

		public void Init(Size taille)
		{
			m_controles.Clear();
			m_bSizeInitialized = false;
			m_size = Size.Empty;
			TailleReference = taille;
		}
		public void Init()
		{
			m_controles.Clear();
			m_size = Size.Empty;
			m_bSizeInitialized = false;

		}


		private bool m_bVerouillerTaille;
		public bool VerouillerTaille
		{
			get
			{
				return m_bChangementTaille;
			}
			set
			{
				m_bChangementTaille = value;
			}
		}

		private List<Control> m_controles = new List<Control>();
		public List<Control> Controles
		{
			get
			{
				return m_controles;
			}
		}

		public void AjouterControle(Control ctrl)
		{
			m_controles.Add(ctrl);

			if (m_bSizeInitialized)
			{
				ctrl.Size = TailleReference;
			}
			else
			{
				TailleReference = ctrl.Size;
			}

			ctrl.SizeChanged += new EventHandler(ctrl_SizeChanged);
		}

		
		public void SupprimerControle(Control ctrl)
		{
			if (m_controles.Contains(ctrl))
			{
				m_controles.Remove(ctrl);
				ctrl.SizeChanged -= ctrl_SizeChanged;
			}
		}

		private bool m_bSizeInitialized = false;
		private Size m_size;
		public Size TailleReference
		{
			get
			{
				return m_size;
			}
			set
			{
				m_bChangementTaille = true;
				m_size = value;
				foreach (Control c in m_controles)
					c.Size = TailleReference;
				m_bSizeInitialized = true;
				m_bChangementTaille = false;
			}
		}

		private bool m_bChangementTaille = false;
		private void ctrl_SizeChanged(object sender, EventArgs e)
		{
			if (!m_bChangementTaille)
			{
				try
				{
					m_bChangementTaille = true;
					Control ctrl = (Control)sender;
					if (ctrl.Size != TailleReference)
					{
						if (VerouillerTaille)
						{
							ctrl.Size = TailleReference;
						}
						else
						{
							m_size = ctrl.Size;
							foreach (Control c in m_controles)
							{
								if (c == ctrl)
									continue;
								c.Size = m_size;
							}
						}
					}
					m_bChangementTaille = false;
				}
				catch
				{
					m_bChangementTaille = false;
				}
			}
		}



		public CSizeUnifier(IContainer container)
		{
			container.Add(this);

			InitializeComponent();
		}
	}
}
