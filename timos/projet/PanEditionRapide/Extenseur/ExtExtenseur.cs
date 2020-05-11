using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using sc2i.data;
using sc2i.common;

namespace timos.tables
{
	
	public class ExtExtenseur : Component
	{


		public event EventHandlerExtenseurAvantChangement AvantChangementEtat;
		public event EventHandlerExtenseurApresChangement ApresChangementEtat;

		private CCtrlBoutonExtenseur m_ext;


		public ExtExtenseur()
		{

		}

		#region Dessin Bouton Extenseur
		public enum EPositionBoutonExtenseur
		{
			ACheval,
			Exterieur,
			Interieur,
		}
		private EPositionBoutonExtenseur m_posExt = EPositionBoutonExtenseur.ACheval;
		public EPositionBoutonExtenseur PositionBoutonExtenseur
		{
			get
			{
				return m_posExt;
			}
			set
			{
				m_posExt = value;
				ConstruireExtenseur();
			}
		}

		private int m_nTaille = 20;
		public int TailleBoutonExtenseur
		{
			get
			{
				return m_nTaille;
			}
			set
			{
				m_nTaille = value;
				ConstruireExtenseur();
			}
		}

		private ContentAlignment m_locationExtenseur = ContentAlignment.MiddleCenter;
		public ContentAlignment LocationBoutonExtenseur
		{
			get
			{
				return m_locationExtenseur;
			}
			set
			{
				m_locationExtenseur = value;
				ConstruireExtenseur();
			}
		}

		#endregion

		private bool m_bMasque = false;
		public bool EtatInitialMasque
		{
			get
			{
				return m_bMasque;
			}
			set
			{
				CArgsEventExtenseurAvantChangementEtat arg = new CArgsEventExtenseurAvantChangementEtat(m_ctrl);
				if (AvantChangementEtat != null)
					AvantChangementEtat(arg);

				if (!arg.AnnulerAction)
				{
					m_bMasque = value;
					if (ApresChangementEtat != null)
						ApresChangementEtat(new CArgsEventExtenseurApresChangementEtat(m_ctrl));
				}

			}
		}
		private Control m_ctrl;
		public Control ControlConcerne
		{
			get
			{
				return m_ctrl;
			}
			set
			{
				m_ctrl = value;
				if (m_ctrl != null)
				{
					m_ctrl.SizeChanged += new EventHandler(m_ctrl_SizeChanged);
					m_ctrl.DockChanged += new EventHandler(m_ctrl_DockChanged);
				}
			}
		}

		void m_ctrl_SizeChanged(object sender, EventArgs e)
		{
			ConstruireExtenseur();
		}

		void m_ctrl_DockChanged(object sender, EventArgs e)
		{
			ConstruireExtenseur();
		}


		private void ActualiseTailleBoutonExtenseur()
		{
			if (m_ext != null)
			{
				//Modulo pour que la taille soit impaire pour un meilleur alignement
				int taille = m_nTaille;
				if (taille % 2 != 0)
					taille++;

				m_ext.Width = taille;
				m_ext.Height = taille;
			}
		}


		private void ConstruireExtenseur()
		{
			if (m_ext != null)
			{
				m_ext = new CCtrlBoutonExtenseur();
				m_ext.Masque = EtatInitialMasque;
			}

			ActualiseTailleBoutonExtenseur();

			int x = 0;
			int y = 0;
			
			switch (m_locationExtenseur)
			{
				case ContentAlignment.BottomCenter:
					x = m_ctrl.Location.X + (m_ctrl.Width / 2);
					y = m_ctrl.Location.Y;
					switch (m_posExt)
					{
						case EPositionBoutonExtenseur.ACheval:
							x = x - (m_ext.Width / 2);
							y = y - (m_ext.Height / 2);
							break;
						case EPositionBoutonExtenseur.Exterieur:
							x = x - (m_ext.Width / 2);
							break;
						case EPositionBoutonExtenseur.Interieur:
							x = x - (m_ext.Width / 2);
							y = y - m_ext.Height;
							break;
						default:
							break;
					}
					break;
				case ContentAlignment.BottomLeft:
					x = m_ctrl.Location.X + m_ctrl.Height;
					y = m_ctrl.Location.Y;
					switch (m_posExt)
					{
						case EPositionBoutonExtenseur.ACheval:
							x = x - (m_ext.Width / 2);
							y = y - (m_ext.Height / 2);
							break;
						case EPositionBoutonExtenseur.Exterieur:
							x = x - m_ext.Width;
							break;
						case EPositionBoutonExtenseur.Interieur:
							y = y - m_ext.Height;
							break;
						default:
							break;
					}
					break;
				case ContentAlignment.BottomRight:
					x = m_ctrl.Location.X + m_ctrl.Height;
					y = m_ctrl.Location.Y + m_ctrl.Width;
					switch (m_posExt)
					{
						case EPositionBoutonExtenseur.ACheval:
							x = x - (m_ext.Width / 2);
							y = y - (m_ext.Height / 2);
							break;
						case EPositionBoutonExtenseur.Exterieur:
							break;
						case EPositionBoutonExtenseur.Interieur:
							x = x - m_ext.Width;
							y = y - m_ext.Height;
							break;
						default:
							break;
					}
					break;
				case ContentAlignment.MiddleCenter:
					m_ext.Dispose();
					return;
				case ContentAlignment.MiddleLeft:
					x = m_ctrl.Location.X;
					y = m_ctrl.Location.Y + (m_ctrl.Height / 2);
					switch (m_posExt)
					{
						case EPositionBoutonExtenseur.ACheval:
							x = x - (m_ext.Width / 2);
							y = y - (m_ext.Height / 2);
							break;
						case EPositionBoutonExtenseur.Exterieur:
							y = y - (m_ext.Height / 2);
							x = x - m_ext.Width;
							break;
						case EPositionBoutonExtenseur.Interieur:
							y = y - (m_ext.Height / 2);
							break;
						default:
							break;
					}
					break;
				case ContentAlignment.MiddleRight:
					x = m_ctrl.Location.X;
					y = m_ctrl.Location.Y + (m_ctrl.Height / 2);
					switch (m_posExt)
					{
						case EPositionBoutonExtenseur.ACheval:
							x = x - (m_ext.Width / 2);
							y = y - (m_ext.Height / 2);
							break;
						case EPositionBoutonExtenseur.Exterieur:
							y = y - (m_ext.Height / 2);
							break;
						case EPositionBoutonExtenseur.Interieur:
							x = x - m_ext.Width;
							y = y - (m_ext.Height / 2);
							break;
						default:
							break;
					}
					break;
				case ContentAlignment.TopCenter:
					x = m_ctrl.Location.X + (m_ctrl.Width / 2);
					y = m_ctrl.Location.Y;
					switch (m_posExt)
					{
						case EPositionBoutonExtenseur.ACheval:
							x = x - (m_ext.Width / 2);
							y = y - (m_ext.Height / 2);
							break;
						case EPositionBoutonExtenseur.Exterieur:
							x = x - (m_ext.Width / 2);
							y = y - m_ext.Height;
							break;
						case EPositionBoutonExtenseur.Interieur:
							x = x - (m_ext.Width / 2);
							break;
						default:
							break;
					}
					break;
				case ContentAlignment.TopLeft:
					x = m_ctrl.Location.X;
					y = m_ctrl.Location.Y;
					switch (m_posExt)
					{
						case EPositionBoutonExtenseur.ACheval:
							x = x - (m_ext.Width / 2);
							y = y - (m_ext.Height / 2);
							break;
						case EPositionBoutonExtenseur.Exterieur:
							x = x - m_ext.Width;
							y = y - m_ext.Height;
							break;
						case EPositionBoutonExtenseur.Interieur:
						default:
							break;
					}
					break;
				case ContentAlignment.TopRight:
					x = m_ctrl.Location.X + m_ctrl.Height;
					y = m_ctrl.Location.Y;
					switch (m_posExt)
					{
						case EPositionBoutonExtenseur.ACheval:
							x = x - (m_ext.Width / 2);
							y = y - (m_ext.Height / 2);
							break;
						case EPositionBoutonExtenseur.Exterieur:
							y = y - m_ext.Height;
							break;
						case EPositionBoutonExtenseur.Interieur:
							x = x - m_ext.Width;
							break;
						default:
							break;
					}
					break;
				default:
					break;
			}


			m_ext.Location = new Point(x,y);
			m_ext.BringToFront();
			//m_ctrl.Parent.Controls.Add(m_ext);

		}



	}

	public delegate void EventHandlerExtenseurAvantChangement(CArgsEventExtenseurAvantChangementEtat arguments);
	public delegate void EventHandlerExtenseurApresChangement(CArgsEventExtenseurApresChangementEtat arguments);


	public class CArgsEventExtenseur
	{
		public CArgsEventExtenseur(Control ctrlConcerne)
		{
			m_ctrlConcerne = ctrlConcerne;
		}
		private Control m_ctrlConcerne;
		public Control ControlConcerne
		{
			get
			{
				return m_ctrlConcerne;
			}
		}
	}
	public class CArgsEventExtenseurApresChangementEtat : CArgsEventExtenseur
	{
		public CArgsEventExtenseurApresChangementEtat(Control ctrlConcerne):base(ctrlConcerne)
		{
		}
	}
	public class CArgsEventExtenseurAvantChangementEtat : CArgsEventExtenseur
	{
		public CArgsEventExtenseurAvantChangementEtat(Control ctrlConcerne):base(ctrlConcerne)
		{
			m_bAnnulerAction = false;
		}

		private bool m_bAnnulerAction;
		public bool AnnulerAction
		{
			get
			{
				return m_bAnnulerAction;
			}
			set
			{
				m_bAnnulerAction = value;
			}
		}
	}

}