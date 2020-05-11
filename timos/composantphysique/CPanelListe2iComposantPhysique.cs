using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using sc2i.win32.common;

using sc2i.common;
using System.Collections.Generic;

using timos.data;
using timos.data.composantphysique;
using sc2i.formulaire;

namespace timos.composantphysique
{
    /// <summary>
    /// Description r�sum�e de CPanelListe2iComposantPhysique.
    /// </summary>
    public class CPanelListe2iComposantPhysique: System.Windows.Forms.UserControl
    {
        private Hashtable m_tableAssembliesCharges = new Hashtable();
		private const int c_nElementHeight = 24;
		private const int c_nEcartYElements = 2;

		private Type m_typeEdite = null;

		private ArrayList m_listeElements = new ArrayList();

		private List<Type> m_listeTypesControlesConnus = new List<Type>();

		#region Component Designer generated code

		/// <summary> 
		/// Variable n�cessaire au concepteur.
		/// </summary>
		private System.ComponentModel.Container components = null;




		/// <summary> 
		/// Nettoyage des ressources utilis�es.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		/// <summary> 
		/// M�thode requise pour la prise en charge du concepteur - ne modifiez pas 
		/// le contenu de cette m�thode avec l'�diteur de code.
		/// </summary>
		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// CPanelListe2iWnd
			// 
			this.AutoScroll = true;
			this.Name = "CPanelListe2iWnd";
			this.Size = new System.Drawing.Size(152, 368);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.CPanelListe2iWnd_DragDrop);
			this.ResumeLayout(false);

		}
		#endregion

        public CPanelListe2iComposantPhysique()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Indique pour l'�dition de quel type d'�l�ment les contr�les vont
		/// �tre utilis�s
		/// </summary>
		/// <param name="tp"></param>
		public void SetTypeEdite(Type tp)
		{
			m_typeEdite = tp;
			RefreshControls();
		}

		//----------------------------------------------------------
		public void AddAssembly(System.Reflection.Assembly assembly)
		{
			if (m_tableAssembliesCharges[assembly] != null)
				return;
			m_tableAssembliesCharges[assembly] = true;
            foreach (Type tp in assembly.GetExportedTypes())
            {
                if (typeof(C2iComposant3D).IsAssignableFrom(tp) && !tp.IsAbstract)
                {
                    if (tp.GetCustomAttributes(typeof(VisibleInInterfaceAttribute), true).Length != 0)
                        AddTypeControl(tp);
                }
            }
		}

		//----------------------------------------------------------
		//Remet � jour la liste des contr�les disponibles et compatibles avec le type �dit�
		public void RefreshControls()
		{
			m_listeElements.Clear();
			this.SuspendDrawing();
			Dictionary<Type, bool> typesTraites = new Dictionary<Type, bool>();
			ArrayList lstControles = new ArrayList ( Controls );
			foreach (Control ctrl in lstControles)
			{
                
				CElementListeComposantPhysique elt = ctrl as CElementListeComposantPhysique;
				typesTraites.Add(elt.TypeAssocie, true);
				if (elt != null)
				{
					m_listeElements.Add(elt);
				}
				else
					m_listeElements.Add(elt);
			}
			m_listeTypesControlesConnus.Sort  ( new TypeSorter() );

			foreach (Type tp in m_listeTypesControlesConnus)
			{
				if (!typesTraites.ContainsKey(tp))
				{
					CElementListeComposantPhysique elt = new CElementListeComposantPhysique();
					//elt.Image = C2iComposant3DEn2D.GetImage(tp);
                    Controls.Add(elt);
					elt.TypeAssocie = tp;
					elt.Size = new Size(ClientRectangle.Width, c_nElementHeight);
					elt.Left = 0;
					elt.Top = m_listeElements.Count * (c_nElementHeight + c_nEcartYElements) + c_nEcartYElements;
					elt.CreateControl();
					elt.Dock = DockStyle.Top;
					elt.SendToBack();
					elt.Visible = true;
					m_listeElements.Add(elt);

				}
			}
			this.ResumeDrawing();
		}

		private class TypeSorter : IComparer<Type>
		{
			public int Compare(Type tp1, Type tp2)
			{
			
				string strNom1 = DynamicClassAttribute.GetNomConvivial(tp1);
				string strNom2 = DynamicClassAttribute.GetNomConvivial(tp2);
				object[] attribs = tp1.GetCustomAttributes(typeof(WndNameAttribute), false);
				if (attribs.Length != 0)
					strNom1 = ((WndNameAttribute)attribs[0]).Name;
				attribs = tp2.GetCustomAttributes(typeof(WndNameAttribute), false);
				if(  attribs.Length != 0 )
					strNom2 = ((WndNameAttribute)attribs[0]).Name;
				return strNom2.CompareTo(strNom1);
			}
		}

		public void AddTypeControl(Type tp)
		{
			if (!typeof ( C2iComposant3D ).IsAssignableFrom ( tp ))
				return;
			if ( !m_listeTypesControlesConnus.Contains ( tp ) )
				m_listeTypesControlesConnus.Add(tp);
		}

		//----------------------------------------------------------
		public void AddAllLoadedAssemblies()
		{
			foreach (Assembly ass in AppDomain.CurrentDomain.GetAssemblies())
				AddAssembly(ass);
			RefreshControls();
		}

		public void CPanelListe2iWnd_DragDrop(object sender, DragEventArgs e)
		{
			foreach (CElementListeComposantPhysique ele in m_listeElements)
                ele.CElementListeWnd_DragDrop(sender, e);
		}
	}
}
