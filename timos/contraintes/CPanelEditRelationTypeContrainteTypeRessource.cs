using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using sc2i.data.dynamic;
using sc2i.data;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;
using sc2i.common;
using sc2i.win32.data;
using sc2i.win32.common;

using timos.data;

namespace timos
{
    public partial class CPanelEditRelationTypeContrainteTypeRessource : UserControl
    {
        public CPanelEditRelationTypeContrainteTypeRessource()
        {
            InitializeComponent();
        }

        private void m_GestionnaireEditionRelation_InitChamp(object sender, sc2i.data.CObjetDonneeResultEventArgs args)
        {
        }

        private void m_GestionnaireEditionRelation_MAJ_Champs(object sender, sc2i.data.CObjetDonneeResultEventArgs args)
        {
        }


        public void InitPanel(CListeObjetsDonnees listeObjets, string propriete)
        {
            if (listeObjets == null)
            {
                return;
            }

            columnLibelle.Field = propriete;
            //m_extLinkField.SetLinkField(m_lblTypeObjet, propriete);

            if (listeObjets.Count != 0)
            {
                foreach (CRelationTypeContrainte_TypeRessource rel in listeObjets)
                {
                    ListViewItem item = new ListViewItem();
                    m_listeRelations.Items.Add(item);
                    m_listeRelations.UpdateItemWithObject(item, rel);
                }
            }

            m_GestionnaireEditionRelation.ObjetEdite = listeObjets;
            m_panelElement.Visible = false;

            

        }

        public CResultAErreur MAJ_Champs()
        {
            CResultAErreur result;

            result = m_GestionnaireEditionRelation.ValideModifs();

            return result;

        }


        public void AddRelation(CListeObjetsDonnees listeObjets, CTypeRessource newTypeRessource, CTypeContrainte newTypeContainte)
        {

            if (listeObjets == null || newTypeRessource == null || newTypeContainte == null) return;


            // Vérifie que la ralation n'es pas déjà créée
            listeObjets.Filtre = new CFiltreData(CTypeRessource.c_champId + " = @1 AND " + CTypeContrainte.c_champId + " = @2 ",
                newTypeRessource.Id, newTypeContainte.Id);

            if (listeObjets.Count != 0)
            {
				CFormAlerte.Afficher(I.T("This Relation is already added|286"), EFormAlerteType.Erreur);
                return;
            }

            //Créer une nouvelle relation
            CRelationTypeContrainte_TypeRessource rel = new CRelationTypeContrainte_TypeRessource(listeObjets.ContexteDonnee);
            rel.CreateNewInCurrentContexte();
            rel.TypeContrainte = newTypeContainte;
            rel.TypeRessource = newTypeRessource;

            ListViewItem item = new ListViewItem();
            m_listeRelations.Items.Add(item);
            m_listeRelations.UpdateItemWithObject(item, rel);

        }

        private void m_lnkSupprimer_LinkClicked(object sender, EventArgs e)
        {
            if (m_listeRelations.SelectedItems.Count == 0)
            {
				CFormAlerte.Afficher(I.T("Please selcet a Resource Type to remove|287"), EFormAlerteType.Exclamation);
                return;
            }
            // Supprimer la relation
            CRelationTypeContrainte_TypeRessource rel = (CRelationTypeContrainte_TypeRessource)m_listeRelations.SelectedItems[0].Tag;
            CResultAErreur result = rel.Delete();
            if (!result)
            {
                CFormAlerte.Afficher(result.Erreur);
                return;
            }

            if (m_listeRelations.SelectedItems.Count != 0 && m_listeRelations.SelectedItems[0] != null)
            {
                m_listeRelations.SelectedItems[0].Remove();
            }

        }



    }


}

