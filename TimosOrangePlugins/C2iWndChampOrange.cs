using System;
using System.Collections.Generic;
using System.Text;

using sc2i.common;
using sc2i.formulaire;
using sc2i.data.dynamic;
using System.Drawing;
using System.Drawing.Design;
using timos.data;
using System.Collections;

namespace TimosOrangePlugins
{
	[WndName("Champ Tibco")]
	[Serializable]
	public class C2iWndChampOrange : C2iWndComposantFenetre, I2iSerializable
	{
		private C2iWndChampCustom m_wndChampCustom;
		private C2iWndLabel m_wndLibelle;
		private C2iWndLabel m_wndValeurAutre;
		private bool m_bIsHorizontal = false;

		public C2iWndChampOrange()
			: base()
		{
			m_wndChampCustom = new C2iWndChampCustom();
			m_wndChampCustom.Parent = this;
			
			m_wndLibelle = new C2iWndLabel();
			m_wndLibelle.Parent = this;
			m_wndLibelle.Text = "";
			m_wndLibelle.Size = new Size(90, 43);
			
			m_wndValeurAutre = new C2iWndLabel();
			m_wndValeurAutre.Parent = this;
			m_wndValeurAutre.BackColor = Color.Orange;
			m_wndValeurAutre.Text = "Orange/FT";
			Size = new Size(200, 43);
		}

		//-----------------------------------
		private void RecalcLayout()
		{
			if (m_wndLibelle != null &&
				m_wndValeurAutre != null &&
				m_wndChampCustom != null)
			{
				m_wndLibelle.Position = new Point(0, 0);
				int nLabelSize = m_wndLibelle.Size.Width;
				m_wndLibelle.Size = new Size(nLabelSize, ClientSize.Height);
				int nWidth = ClientSize.Width - nLabelSize-1;
				int nHeight = ClientSize.Height;
				if (m_bIsHorizontal)
					nWidth /= 2;
				else
					nHeight /= 2;
				m_wndChampCustom.Position = new Point(nLabelSize + 1, 0);
				m_wndChampCustom.Size = new Size(nWidth, nHeight);
				m_wndChampCustom.Position = new Point(nLabelSize + 1, 0);

				if ( m_bIsHorizontal )
					m_wndValeurAutre.Position = new Point(m_wndChampCustom.Position.X + nWidth, 0);
				else
					m_wndValeurAutre.Position = new Point(m_wndChampCustom.Position.X, nHeight);
				m_wndValeurAutre.Size = m_wndChampCustom.Size;
				if (m_bIsHorizontal)
					m_wndValeurAutre.Position = new Point(m_wndChampCustom.Position.X + nWidth, 0);
				else
					m_wndValeurAutre.Position = new Point(m_wndChampCustom.Position.X, nHeight);
		
			}
		}

		//-----------------------------------
		public override Color BackColor
		{
			get
			{
				return base.BackColor;
			}
			set
			{
				base.BackColor = value;
				if (m_wndLibelle != null)
					m_wndLibelle.BackColor = BackColor;
			}
		}

		//-----------------------------------
		public override bool CanBeUseOnType(Type tp)
		{
			if (tp != null)
				return typeof(CSite).Equals(tp) || typeof(CEquipementLogique).Equals(tp);
			return false;
		}

		//-----------------------------------
		public override System.Drawing.Size Size
		{
			get
			{
				return base.Size;
			}
			set
			{
				base.Size = value;
				RecalcLayout();
			}
		}

		//-----------------------------------
		public bool IsHorizontal
		{
			get
			{
				return m_bIsHorizontal;
			}
			set
			{
				m_bIsHorizontal = value;
			}
		}


		//-----------------------------------
		public C2iWndChampCustom FieldZone
		{
			get
			{
				return m_wndChampCustom;
			}
		}

		//-----------------------------------
		public C2iWndLabel LabelZone
		{
			get
			{
				return m_wndLibelle;
			}
		}

		//-----------------------------------
		public C2iWndLabel OrangeZone
		{
			get
			{
				return m_wndValeurAutre;
			}
		}

		//-----------------------------------
		private int GetNumVersion()
		{
			return 1;
		}

		//-----------------------------------
		protected override CResultAErreur  MySerialize(C2iSerializer serializer)
		{
			int nVersion = GetNumVersion();
			CResultAErreur result = serializer.TraiteVersion(ref nVersion);
			if (!result)
				return result;
			result = m_wndChampCustom.Serialize(serializer);
			if (result)
				result = m_wndLibelle.Serialize(serializer);
			if (result)
				result = m_wndValeurAutre.Serialize(serializer);

			if (nVersion >= 1)
				serializer.TraiteBool(ref m_bIsHorizontal);
			return result;
		}

		//-----------------------------------
		public override bool AcceptChilds
		{
			get
			{
				return false;
			}
		}

		//-----------------------------------
		protected override void MyDraw(sc2i.drawing.CContextDessinObjetGraphique ctx)
		{
			Graphics g = ctx.Graphic;
			Brush b = new SolidBrush(BackColor);
			Rectangle rect = new Rectangle(Position, Size);
			g.FillRectangle(b, rect);
			b.Dispose();
			base.MyDraw(ctx);
		}

		//-----------------------------------
		public override void DrawInterieur(sc2i.drawing.CContextDessinObjetGraphique ctx)
		{
			m_wndLibelle.Draw(ctx);
			m_wndChampCustom.Draw(ctx);
			m_wndValeurAutre.Draw(ctx);
		}

		//-----------------------------------
		[System.ComponentModel.Editor(typeof(CProprieteChampCustomEditor), typeof(UITypeEditor))]
		public CChampCustom ChampCustom
		{
			get
			{
				return m_wndChampCustom.ChampCustom;
			}
			set
			{
				m_wndChampCustom.ChampCustom = value;
				if (value != null && m_wndLibelle.Text == "")
					m_wndLibelle.Text = value.LibelleConvivial;
			}
		}

		//-----------------------------------
		public string Text
		{
			get
			{
				return m_wndLibelle.Text;
			}
			set
			{
				m_wndLibelle.Text = value;
			}
		}

		//-----------------------------------
		public override void OnDesignSelect(
			Type typeEdite,
			object objetEdite,
			sc2i.expression.IFournisseurProprietesDynamiques fournisseurProprietes)
		{
			base.OnDesignSelect(typeEdite, objetEdite, fournisseurProprietes);
			CProprieteChampCustomEditor.SetTypeElementAChamp(typeEdite);
		}

		//-----------------------------------
		protected override void  GetAllChilds(ArrayList lst)
		{
			if (m_wndChampCustom != null)
				lst.Add(m_wndChampCustom);
			if ( m_wndLibelle != null )
				lst.Add ( m_wndLibelle );
			if ( m_wndValeurAutre != null )
				lst.Add ( m_wndValeurAutre );
		}

	}
}
