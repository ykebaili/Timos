using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Reflection;
using System.Windows.Forms;

using sc2i.formulaire;
using sc2i.common;
using System.Collections.Generic;

using timos.data;

namespace timos
{
    /// <summary>
    /// Description r�sum�e de CPanelListe2iSymbole.
    /// </summary>
    public class CPanelListe2iSymbole: System.Windows.Forms.UserControl
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
            // CPanelListe2iSymbole
            // 
            this.AutoScroll = true;
            this.Name = "CPanelListe2iSymbole";
            this.Size = new System.Drawing.Size(152, 297);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.CPanelListe2iSymbole_DragDrop);
            this.ResumeLayout(false);

        }
        #endregion

        public CPanelListe2iSymbole()
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
                if (typeof(C2iSymbole).IsAssignableFrom(tp) && !tp.IsAbstract)
                {
                  if(tp.GetMember("m_bAfficheInterface").GetLength(0) >0)
                    AddTypeControl(tp);
                }
            }
        }

        //----------------------------------------------------------
        //Remet � jour la liste des contr�les disponibles et compatibles avec le type �dit�
        public void RefreshControls()
        {
            m_listeElements.Clear();
            SuspendLayout();
            Dictionary<Type, bool> typesTraites = new Dictionary<Type, bool>();
            ArrayList lstControles = new ArrayList(Controls);
            foreach (Control ctrl in lstControles)
            {
                CElementListeSymbole elt = ctrl as CElementListeSymbole;
                typesTraites.Add(elt.TypeAssocie, true);
                if (elt != null)
                {

                    C2iSymbole symbole = (C2iSymbole)Activator.CreateInstance(elt.TypeAssocie);
                 
                 /*   if (!wnd.CanBeUseOnType(m_typeEdite))
                    {
                        elt.Visible = false;
                        elt.Parent.Controls.Remove(elt);
                        elt.Dispose();
                    }
                    else*/
                        m_listeElements.Add(elt);
                }
                else
                    m_listeElements.Add(elt);
            }

            foreach (Type tp in m_listeTypesControlesConnus)
            {
                if (!typesTraites.ContainsKey(tp))
                {
                    if (!tp.IsAbstract)
                    {
                        C2iSymbole symbole = (C2iSymbole)Activator.CreateInstance(tp);
                       /* if (!wnd.CanBeUseOnType(m_typeEdite))
                            continue;*/
                    }

                    CElementListeSymbole elt = new CElementListeSymbole();
                  //  elt.Image = C2iWnd.GetImage(tp);
                    /*object[] atts = tp.GetCustomAttributes(typeof(AWndIcone), false);

                    if (atts.Length >= 1)
                    {
                        AWndIcone att = (AWndIcone)atts[0];
                        elt.Image = att.Icone;
                    }*/
                    elt.Parent = this;
                    elt.TypeAssocie = tp;
                    elt.Size = new Size(ClientRectangle.Width, c_nElementHeight);
                    elt.Left = 0;
                    elt.Top = m_listeElements.Count * (c_nElementHeight + c_nEcartYElements) + c_nEcartYElements;
                    elt.CreateControl();
                    elt.Dock = DockStyle.Top;
                    elt.Visible = true;
                    m_listeElements.Add(elt);

                }
            }
            ResumeLayout();
        }

        //----------------------------------------------------------
        public void AddTypeControl(Type tp)
        {
            if (!typeof(C2iSymbole).IsAssignableFrom(tp))
                return;
            if (!m_listeTypesControlesConnus.Contains(tp))
                m_listeTypesControlesConnus.Add(tp);
        }

        //----------------------------------------------------------
        public void AddAllLoadedAssemblies()
        {
            foreach (Assembly ass in AppDomain.CurrentDomain.GetAssemblies())
                AddAssembly(ass);
            RefreshControls();
        }

        private void CPanelListe2iSymbole_DragDrop(object sender, DragEventArgs e)
        {
            foreach (CElementListeSymbole ele in m_listeElements)
                ele.CElementListeSymbole_DragDrop(sender, e);
        }

        /*public void CPanelListe2iSymbole_DragDrop(object sender, DragEventArgs e)
        {
            
        }*/
    }
}
