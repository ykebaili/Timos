using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace spv.win32
{

    /// <summary>
    /// Retourne le tableau des données à afficher pour l'objet
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="datas"></param>
    public delegate void GetDonneesLigneEventHandler ( object obj, ref object[]datas );

    /// <summary>
    /// ListView qui charge ses données lorsqu'elles sont affichées, par ligne
    /// Fonctionnement : Initialiser avec la fonction Init, qui prend la liste d'objets
    /// à afficher et le nom des colonnes.
    /// Mettre un handler sur OnGetDonneesObjet. Cette fonction a un objet en paramètre
    /// et doit retourner la liste des données à afficher sous forme d'un tableau.
    /// ATTENTION, Mettre VirtualMode à true et affichage en mode détail pour que tout
    /// marche bien
    /// </summary>
    public class CListeViewOptimiseeParLigne : ListView
    {
        private Dictionary<int, object[]> m_cacheDatas = new Dictionary<int, object[]>();
        private int m_nCacheSize = 200;
        List<object> m_listeObjets = new List<object>();

        public event GetDonneesLigneEventHandler OnGetDonneesObjet;
        

        public CListeViewOptimiseeParLigne()
            : base()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // CListeViewOptimiseeParLigne
            // 
            this.FullRowSelect = true;
            this.View = System.Windows.Forms.View.Details;
            this.VirtualListSize = 150;
            this.VirtualMode = true;
            this.ResumeLayout(false);

        }

        protected override void  OnRetrieveVirtualItem(RetrieveVirtualItemEventArgs e)
        {
 	        base.OnRetrieveVirtualItem(e);

            if (OnGetDonneesObjet != null)
            {
                object[] datas = null;
                e.Item = new ListViewItem();
                if (e.ItemIndex >= 0 && e.ItemIndex < m_listeObjets.Count)
                {
                    object obj = m_listeObjets[e.ItemIndex];
                    if ( !m_cacheDatas.TryGetValue ( e.ItemIndex, out datas ))
                    {
                        OnGetDonneesObjet(obj, ref datas);
                        if ( m_cacheDatas.Count > m_nCacheSize )
                            m_cacheDatas.Clear();
                        m_cacheDatas[e.ItemIndex] = datas;
                    }
                    int nIndex = 0;
                    e.Item.SubItems.Clear();
                    if (datas != null)
                    {
                        foreach (object data in datas)
                        {
                            if (nIndex == 0)
                                e.Item.Text = data == null ? "" : data.ToString();
                            else
                            {
                                if (nIndex < Columns.Count)
                                    e.Item.SubItems.Add(data == null ? "" : data.ToString());
                            }
                            nIndex++;
                        }
                    }

                    AfterItemCreation(e, obj);                    
                }
            }
        }

        public void Init ( string[] strNomColonnes, object[] objets )
        {
            BeginUpdate();
            Items.Clear();
            Columns.Clear();
            foreach (string strNomColonne in strNomColonnes)
            {
                ColumnHeader header = new ColumnHeader();
                header.Text = strNomColonne;
                Columns.Add(header);
            }
            VirtualListSize = objets.Length;
            m_listeObjets.Clear();
            m_listeObjets.AddRange(objets);
            m_cacheDatas.Clear();
            EndUpdate();
        }

        public void AddObject(object objet, bool triCroissant)
        {
            if (triCroissant)
                m_listeObjets.Add(objet);
            else
                m_listeObjets.Insert(0, objet);

            m_cacheDatas.Clear();
            VirtualListSize = m_listeObjets.Count;
        }

        public void RemoveObjet(object objet)
        {
            m_listeObjets.Remove(objet);
            m_cacheDatas.Clear();
            VirtualListSize = m_listeObjets.Count;
        }

        public object[] SelectedObjets
        {
            get
            {
                List<object> lst = new List<object>();
                foreach (int nIndex in SelectedIndices)
                {
                    if (nIndex >= 0 && nIndex < m_listeObjets.Count)
                        lst.Add(m_listeObjets[nIndex]);
                }
                return lst.ToArray();
            }
        }

        public object GetObjectFromList(int index)
        {
            if (index >= 0 && index < m_listeObjets.Count)
                return m_listeObjets[index];
            else 
                return null;
        }

        public int GetCount()
        {
            return m_listeObjets.Count;
        }

        protected virtual void AfterItemCreation(RetrieveVirtualItemEventArgs e, object obj)
        {
        }

    }
}
