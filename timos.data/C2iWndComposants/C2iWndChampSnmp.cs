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
using timos.data.snmp;
using sc2i.formulaire.datagrid;
using sc2i.formulaire.datagrid.Filters;

namespace timos.data.C2iWndComposants
{
	[WndName("Snmp field")]
	[Serializable]
	public class C2iWndChampSnmp : C2iWndComposantFenetre, I2iSerializable,IWndIncluableDansDataGridADrawCustom
	{
		private C2iWndChampCustom m_wndChampCustom;
		private C2iWndLabel m_wndValeurAutre;
		private bool m_bIsHorizontal = false;

        //-----------------------------------
        public C2iWndChampSnmp()
			: base()
		{
            m_wndChampCustom = new C2iWndChampCustom();
			m_wndChampCustom.Parent = this;
			
			m_wndValeurAutre = new C2iWndLabel();
			m_wndValeurAutre.Parent = this;
			m_wndValeurAutre.BackColor = Color.LightGray;
			m_wndValeurAutre.Text = "SNMP";
            IsHorizontal = true;
			Size = new Size(200, 21);
		}

		//-----------------------------------
		private void RecalcLayout()
		{
			if (m_wndValeurAutre != null &&
				m_wndChampCustom != null)
			{
				int nWidth = ClientSize.Width;
				int nHeight = ClientSize.Height;
				if (m_bIsHorizontal)
					nWidth /= 2;
				else
					nHeight /= 2;
				m_wndChampCustom.Position = new Point(0, 0);
				m_wndChampCustom.Size = new Size(nWidth, nHeight);
				m_wndChampCustom.Position = new Point(0, 0);

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
			}
		}

		//-----------------------------------
		public override bool CanBeUseOnType(Type tp)
		{
			if (tp != null)
				return typeof(CEntiteSnmp).Equals(tp);
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
                RecalcLayout();
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
		public C2iWndLabel SnmpZone
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
			}
		}


		//-----------------------------------
		public override void OnDesignSelect(
			Type typeEdite,
			object objetEdite,
			sc2i.expression.IFournisseurProprietesDynamiques fournisseurProprietes)
		{
			base.OnDesignSelect(typeEdite, objetEdite, fournisseurProprietes);
			CProprieteChampCustomEditor.SetTypeElementAChamp(GetObjetPourAnalyseThis(typeEdite).TypeAnalyse);
		}

		//-----------------------------------
		protected override void  GetAllChilds(ArrayList lst)
		{
			if (m_wndChampCustom != null)
				lst.Add(m_wndChampCustom);
			if ( m_wndValeurAutre != null )
				lst.Add ( m_wndValeurAutre );
		}


        
        //------------------------------------------------------------------------
        public string ConvertObjectValueToStringForGrid(object valeur)
        {
           /* CEntiteSnmp entite = element as CEntiteSnmp;
            if (entite != null )
            {
                string strRetour = "(";
                    strRetour += valeur == null ? "" : valeur.ToString();
                    strRetour += ")";
                    return strRetour;
            }*/
            if (m_wndChampCustom != null)
                return m_wndChampCustom.ConvertObjectValueToStringForGrid(valeur);
            else if (valeur != null)
                    return valeur.ToString();
            return "";
        }

        //------------------------------------------------------------------------
        public object GetObjectValueForGrid(object element)
        {
            CEntiteSnmp entite = element as CEntiteSnmp;
            if (entite != null)
            {
                CRelationEntiteSnmp_ChampCustom rel = CUtilElementAChamps.GetRelationToChamp(entite, m_wndChampCustom.ChampCustom.Id) as CRelationEntiteSnmp_ChampCustom;
                if (rel != null)
                {
                    string strRetour = rel.Valeur == null ? "" : rel.Valeur.ToString();
                    strRetour += "  (";
                    object val = rel.LastSnmpValue;
                    return val;
                }
            }
            if (m_wndChampCustom != null)
                return m_wndChampCustom.GetObjectValueForGrid(element);
            return "";
        }

        //------------------------------------------------------------------------
        public Type ValueTypeForGrid
        {
            get 
            {
                if (m_wndChampCustom != null)
                    return m_wndChampCustom.ValueTypeForGrid;
                return typeof(string);
            }
        }

        public IEnumerable<CGridFilterForWndDataGrid> GetPossibleFilters()
        {
            if (m_wndChampCustom != null)
                return m_wndChampCustom.GetPossibleFilters();
            return CGridFilterTextComparison.GetFiltresTexte();
        }

        //------------------------------------------------------------------------
        public bool Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, object element)
        {
            CEntiteSnmp entite = element as CEntiteSnmp;
            if (entite != null)
            {
                CRelationEntiteSnmp_ChampCustom rel = CUtilElementAChamps.GetRelationToChamp(entite, m_wndChampCustom.ChampCustom.Id) as CRelationEntiteSnmp_ChampCustom;
                if (rel != null)
                {
                    int nWidthChampCustom = Math.Max((cellBounds.Width * m_wndChampCustom.Size.Width) / Math.Max(Size.Width, 1), 10);
                    object val = rel.Valeur;
                    object valSnmp = rel.LastSnmpValue;
                    Rectangle rct = new Rectangle(new Point(0, 0), new Size(nWidthChampCustom, cellBounds.Height));
                    rct.Offset ( cellBounds.Location );
                    Pen pen = new Pen(Color.Black, 1);
                    Brush br = new SolidBrush(m_wndChampCustom.BackColor);
                    graphics.FillRectangle(br, rct);
                    graphics.DrawRectangle(pen, rct);
                    
                    br.Dispose();
                    
                    StringFormat format = new StringFormat();
                    format.LineAlignment = StringAlignment.Center;
                    format.Alignment = StringAlignment.Near;
                    br = new SolidBrush ( m_wndChampCustom.ForeColor );
                    graphics.DrawString(val == null ? "" : val.ToString(), m_wndChampCustom.Font, br, rct, format);
                    br.Dispose();
                    string strVal1 = val != null ? val.ToString() : "";
                    string strVal2 = valSnmp != null ? valSnmp.ToString() : "";
                    bool bHasDif = strVal1 != strVal2 && rel.DateSynchroSnmp!=null;
                    rct = cellBounds;
                    rct.Offset(nWidthChampCustom, 0);
                    rct.Size = new Size(rct.Size.Width - nWidthChampCustom, rct.Size.Height);
                    if (bHasDif)
                        rct.Size = new Size(rct.Size.Width - 16, rct.Size.Height);
                    br = new SolidBrush(m_wndValeurAutre.BackColor);
                    graphics.FillRectangle(br, rct);
                    graphics.DrawRectangle(pen, rct);
                    br.Dispose();
                    pen.Dispose();
                    br = new SolidBrush(m_wndValeurAutre.ForeColor);
                    graphics.DrawString(valSnmp == null ? "" : valSnmp.ToString(), m_wndValeurAutre.Font, br, rct, format);
                    format.Dispose();
                    br.Dispose();
                    if (bHasDif)
                    {
                        rct = new Rectangle(cellBounds.Right - 16, cellBounds.Top, 16, cellBounds.Height);
                        br = new SolidBrush(BackColor);
                        graphics.FillRectangle(br, rct);
                        br.Dispose();
                        rct.Location = new Point ( rct.Left, rct.Top + rct.Height / 2 - 8);
                        rct.Height = 16;
                        graphics.DrawImage(Resource.alerte, rct);
                    }
                    return false;
                }
            }
            return true;
        }

    }
}
