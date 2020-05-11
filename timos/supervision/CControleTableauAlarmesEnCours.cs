using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using sc2i.common;
using sc2i.common.memorydb;
using futurocom.supervision.alarmes;
using futurocom.supervision;

namespace timos.supervision
{
    public partial class CControleTableauAlarmesEnCours : UserControl
    {

        CMemoryDb m_database;

        public CControleTableauAlarmesEnCours()
        {
            InitializeComponent();
        }

        //-------------------------------------------------------------------------------
        internal void Init(CMemoryDb db, CParametreAffichageListeAlarmes parametreAffichage, Dictionary<string, Image> tableauImages, bool bAlarmesEnCours)
        {
            m_database = db;
            m_treeListViewAlarmes.Init(db, parametreAffichage, tableauImages, bAlarmesEnCours);
            m_treeListViewAlarmes.FiltreAlarmes = GetFiltreAlarmesParDefaut();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CFiltreMemoryDb FiltreAlarmes
        {
            get
            {
                return m_treeListViewAlarmes.FiltreAlarmes;
            }
            set
            {
                m_treeListViewAlarmes.FiltreAlarmes = value;
            }
        }

        private void CControleTableauAlarmesEnCours_Load(object sender, EventArgs e)
        {
        }

            

        private void m_txtBoxRechercheRapide_TextChanged(object sender, EventArgs e)
        {

        }
        
        internal void UpdateDataBase(CMemoryDb dataBase)
        {
            m_database = dataBase;
            m_treeListViewAlarmes.UpdateAlarmDataBase(dataBase);
        }

        private void m_treeListViewAlarmes_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Node node = m_treeListViewAlarmes.FocusedNode;
            if (node != null)
            {
                CLocalAlarmeAffichee alarme = node.Tag as CLocalAlarmeAffichee;
                m_explorateur.Init(alarme, alarme.TypeAlarme);
            }
        }


        private CFiltreMemoryDb GetFiltreAlarmesParDefaut()
        {
            CFiltreMemoryDb filtre = null;
            // Par défaut, Filtrer les alarmes masquées
            filtre = new CFiltreMemoryDb(
                CLocalAlarme.c_champIdMasquageHerite + " is null");

            return filtre;
        }

        private void m_toolStripCmbCategorieMask_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void testMenuNespasisiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        
    }



}
