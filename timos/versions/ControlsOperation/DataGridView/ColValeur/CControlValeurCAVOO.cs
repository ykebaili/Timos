using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Reflection;


using sc2i.data.dynamic;
using sc2i.common;
using sc2i.data;

using timos.data.version;

namespace timos.version
{
	public partial class CControlValeurCAVOO : UserControl, IControlVivant
	{
		public CControlValeurCAVOO()
		{
			InitializeComponent();
			DoubleBuffered = true;
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

		private CControlListeOperationsSurCAVO.CValeurCAVOO m_valeur;

		public bool Initialiser(object valeur)
		{
			Controls.Clear();
			try
			{
				m_valeur = (CControlListeOperationsSurCAVO.CValeurCAVOO)valeur;
			}
			catch
			{
				return false;
			}

			CAuditVersionObjetOperation cavoo = m_valeur.CAVOO;
			Type tpEntite = cavoo.TypeEntite;
			string strType = cavoo.IDifferencesBlobType == null || cavoo.IDifferencesBlobType == "" ? cavoo.TypeValeurString : cavoo.IDifferencesBlobType;
			Type tpValeur = CActivatorSurChaine.GetType(strType);

			Control ctrl = null;

			//ENTITE LIEE ?
			if(tpValeur == typeof(int))
			{
				if (cavoo.Champ.GetType() == typeof(CChampCustomPourVersion))
				{
					//SAVOIR SI LE CHAMP CUSTOM POINTE VERS UNE ENTITE...
					//((CChampPourVersionInDb)cavoo.Champ).
				}
				else
				{
					PropertyInfo[] props = tpEntite.GetProperties();
					foreach (PropertyInfo p in props)
					{
						object[] atts = p.GetCustomAttributes(typeof(RelationAttribute), false);
						if (atts.Length == 1)
						{
							RelationAttribute att = (RelationAttribute)atts[0];
							if (att.ChampsParent.Length == 1 
								&& att.ChampsFils.Length == 1
								&& att.ChampsParent[0] == cavoo.Champ.FieldKey)
							{
								string strDescrip = "";
								
								if (m_valeur.Valeur != null)
								{
									CFiltreData filtre = new CFiltreData(att.ChampsFils[0] + " =@1", (int)m_valeur.Valeur);
									CListeObjetsDonnees lstObj = new CListeObjetsDonnees(cavoo.ContexteDonnee, p.PropertyType, filtre);
									bool bElementAccessible = lstObj.Count == 1;
									CObjetDonneeAIdNumerique obj = null;

                                    if (bElementAccessible)
                                    {
                                        obj = (CObjetDonneeAIdNumerique)lstObj[0];
                                        strDescrip = obj.DescriptionElement;
                                    }
                                    else
                                        strDescrip = I.T("Indefinite element from type @1 |30278", DynamicClassAttribute.GetNomConvivial(p.PropertyType));
									CControlListeOperationsSurCAVO.CValeurCAVOOEntite valeurEntite = new CControlListeOperationsSurCAVO.CValeurCAVOOEntite(strDescrip, (int)m_valeur.Valeur, p.PropertyType, obj);
									CControlOpertionCAVOOEntite ctrlEntite = new CControlOpertionCAVOOEntite();
									ctrlEntite.Initialiser(valeurEntite);
									ctrl = ctrlEntite;
									break;
								}
								return true;
								
							}
						}
					}
				}
			}
			if (ctrl == null)
			{
				//if (tpValeur == typeof(DateTime))
				//{
				//}
				//else if (tpValeur == typeof(int))
				//{
				//}
				//else if (tpValeur == typeof(bool))
				//{
				//}
				if (typeof(IDifferencesBlob).IsAssignableFrom(tpValeur))
				{
					if (tpValeur == typeof(timos.data.CDifferencesTables))
					{
						CControlOpertionCAVOOBlobTableParametrable ctrlTable = new CControlOpertionCAVOOBlobTableParametrable();
						ctrlTable.Init(m_valeur);
						ctrl = ctrlTable;
					}
					else
					{
					}
				}
				//else if (tpValeur == typeof(byte[]))
				//{
				//}
				else
				{
					try
					{
						Label lbl = new Label();
						if (m_valeur.Valeur != null)
							lbl.Text = m_valeur.Valeur.ToString();
						ctrl = lbl;
					}
					catch
					{
					}
				}
			}
			if (ctrl != null)
			{
				Controls.Add(ctrl);
				ctrl.Dock = DockStyle.Fill;
			}
			return true;
		}

		public object Valeur
		{
			get
			{
				return m_valeur;
			}
			set
			{
				try
				{
					m_valeur = (CControlListeOperationsSurCAVO.CValeurCAVOO)value;
				}
				catch
				{
				}
			}
		}

		#endregion
	}
}
