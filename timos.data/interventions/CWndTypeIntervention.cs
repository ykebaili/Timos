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
	public class CWndTypeIntervention : C2iObjetGraphique
	{
		private CTypeIntervention m_typeIntervention = null;

		private List<I2iObjetGraphique> m_listeChilds = new List<I2iObjetGraphique>();

		//--------------------------------------------
		public CWndTypeIntervention( CTypeIntervention typeIntervention)
			: base()
		{
			m_typeIntervention = typeIntervention;
			Position = new Point(0, 0);
			Size = new Size(1000, 1000);
		}

		//--------------------------------------------
		public CTypeIntervention TypeIntervention
		{
			get
			{
				return m_typeIntervention;
			}
			set
			{
				m_typeIntervention = value;
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
		public static CWndTypeIntervention GetNewWnd(CTypeIntervention typeIntervention)
		{
            CWndTypeIntervention wnd = new CWndTypeIntervention( typeIntervention );
            //Dictionary<CTypeIntervention_SousIntervention, CWndTypeIntervention_SousIntervention> tableSousInterventionToWnd = new Dictionary<CTypeIntervention_SousIntervention, CWndTypeIntervention_SousIntervention>();
            //foreach (CTypeIntervention_SousIntervention sousIntervention in typeIntervention.RelationsInterventionsFilles)
            //{
            //    CWndTypeIntervention_SousIntervention wndSousIntervention = new CWndTypeIntervention_SousIntervention(sousIntervention);
            //    tableSousInterventionToWnd[sousIntervention] = wndSousIntervention;
            //    wnd.AddChild(wndSousIntervention);
            //}
            //foreach (CTypeIntervention_SousIntervention sousIntervention in typeIntervention.RelationsInterventionsFilles)
            //{
            //    foreach (CLienTypeIntervention lien in sousIntervention.LiensType1)
            //    {
            //        CWndLienTypeIntervention_SousIntervention wndLien = new CWndLienTypeIntervention_SousIntervention();
            //        wndLien.InterventionDepart = tableSousInterventionToWnd[sousIntervention];
            //        wndLien.InterventionArrivee = tableSousInterventionToWnd[lien.SousIntervention2];
            //        wndLien.Lien = lien;
            //        wnd.AddChild(wndLien);
            //    }
            //}
            return wnd;
		}

		//-------------------------------------------------------
		public CWndTypeIntervention_SousIntervention GetSousInterventionFromPoint(System.Drawing.Point ptSouris)
		{
			foreach (I2iObjetGraphique wnd in Childs)
			{
				if (wnd is CWndTypeIntervention_SousIntervention &&
					wnd.IsPointIn(ptSouris))
					return (CWndTypeIntervention_SousIntervention)wnd;
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

	public interface IObjetGraphiqueASuppressionSurveillee
	{
		bool IsValide();
		CResultAErreur OnDelete();
	}
}
