using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Drawing;

using sc2i.common;
using sc2i.formulaire;
using sc2i.drawing;



namespace timos.data
{
	/// <summary>
	/// Dessine les sous tâches d'une Intervention
	/// </summary>
	public class CWndTypeTicket : C2iObjetGraphique
	{
		private CTypeTicket m_typeTicket = null;

		private List<I2iObjetGraphique> m_listeChilds = new List<I2iObjetGraphique>();

		//--------------------------------------------
		public CWndTypeTicket( CTypeTicket typeTicket)
			: base()
		{
			m_typeTicket = typeTicket;
			Position = new Point(0, 0);
			Size = new Size(1000, 1000);
		}

		//--------------------------------------------
		public CTypeTicket TypeTicket
		{
			get
			{
				return m_typeTicket;
			}
			set
			{
				m_typeTicket = value;
			}
		}


		//--------------------------------------------
		public override bool AcceptChilds
		{
			get
			{
				return true;
			}
		}

		//--------------------------------------------------
		private int GetNumVersion()
		{
			return 0;
		}

		//--------------------------------------------------
		protected override sc2i.common.CResultAErreur MySerialize(sc2i.common.C2iSerializer serializer)
		{
			int nVersion = GetNumVersion();
			CResultAErreur result = serializer.TraiteVersion(ref nVersion);
			if (!result)
				return result;

			return result;
		}

		//--------------------------------------------------
		public static CWndTypeTicket GetNewWnd(CTypeTicket typeTicket)
		{
			CWndTypeTicket wnd = new CWndTypeTicket( typeTicket );
			Dictionary<CTypeTicket_TypePhase, CWndTypeTypeTicket_TypePhase> tablePhases = new Dictionary<CTypeTicket_TypePhase, CWndTypeTypeTicket_TypePhase>();
			foreach (CTypeTicket_TypePhase typePhase in typeTicket.RelationsTypesPhases)
			{
				CWndTypeTypeTicket_TypePhase wndTypePhase = new CWndTypeTypeTicket_TypePhase(typePhase);
				tablePhases[typePhase] = wndTypePhase;
				wnd.AddChild(wndTypePhase);
			}
			foreach (CTypeTicket_TypePhase typePhase in typeTicket.RelationsTypesPhases)
			{
				foreach (CLienTypePhase lien in typePhase.RelationsTypesPhasesSuivantes)
				{
					CWndLienTypePhase_TypePhase wndLien = new CWndLienTypePhase_TypePhase();
					wndLien.TypePhaseDepart = tablePhases[typePhase];
					wndLien.TypePhaseArrivee = tablePhases[lien.ToTypePhase];
					wndLien.Lien = lien;
					wnd.AddChild(wndLien);
				}
			}
			return wnd;
		}

		//-------------------------------------------------------
		public CWndTypeTypeTicket_TypePhase GetTypePhaseFromPoint(System.Drawing.Point ptSouris)
		{
			foreach (I2iObjetGraphique wnd in Childs)
			{
				if (wnd is CWndTypeTypeTicket_TypePhase &&
					wnd.IsPointIn(ptSouris))
					return (CWndTypeTypeTicket_TypePhase)wnd;
			}
			return null;
		}

		//-------------------------------------------------------
		public override I2iObjetGraphique[] Childs
		{
			get 
			{
				return m_listeChilds.ToArray();
			}
		}

		//-------------------------------------------------------
		public override bool AddChild(I2iObjetGraphique child)
		{
			child.Parent = this;
			m_listeChilds.Add(child);
			return true;
		}

		//-------------------------------------------------------
		public override bool ContainsChild(I2iObjetGraphique child)
		{
			return m_listeChilds.Contains(child);
			
		}

		//-------------------------------------------------------
		public override void RemoveChild(I2iObjetGraphique child)
		{

			CResultAErreur result = CResultAErreur.True;
			if (child is IObjetGraphiqueASuppressionSurveillee)
				result = ((IObjetGraphiqueASuppressionSurveillee)child).OnDelete();
			if ( result )
				m_listeChilds.Remove(child);
			
		}

		public override void BringToFront(I2iObjetGraphique child)
		{
			if (!ContainsChild(child))
				return;
			m_listeChilds.Remove(child);
			m_listeChilds.Add(child);
		}

		public override void FrontToBack(I2iObjetGraphique child)
		{
			if (!ContainsChild(child))
				return;
			m_listeChilds.Remove(child);
			m_listeChilds.Insert(0, child);
		}




		//-------------------------------------------------------
		protected override void MyDraw(CContextDessinObjetGraphique ctx)
		{
			foreach (I2iObjetGraphique objet in m_listeChilds)
			{
				objet.Draw(ctx);
			}
		}

		//-------------------------------------------------------
		public void NettoieObjetsInvalides()
		{
			foreach (I2iObjetGraphique objet in Childs)
				if (objet is IObjetGraphiqueASuppressionSurveillee)
					if (!((IObjetGraphiqueASuppressionSurveillee)objet).IsValide())
						RemoveChild(objet);		}
	}

}
