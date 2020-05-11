using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


using sc2i.data.dynamic;
using sc2i.data;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;
using sc2i.common;
using sc2i.win32.data;
using sc2i.win32.common;
using sc2i.win32.data.dynamic;

using timos.data;

namespace timos
{
    public partial class CFormSelectionModeleEtiquette : Form
    {


        private CListeObjetsDonnees m_listeObjets = null;

        private CFiltreData m_filtre;

        public CFormSelectionModeleEtiquette()
        {
            InitializeComponent();
            sc2i.win32.common.CWin32Traducteur.Translate(this);
            Init();

        }


        public CFormSelectionModeleEtiquette(Type typeObjet)
        {

            InitializeComponent();
            sc2i.win32.common.CWin32Traducteur.Translate(this);

            m_filtre = new CFiltreData(CModeleEtiquetteSchema.c_nomTable + "." + CModeleEtiquetteSchema.c_champTypeCible + " = @1", typeObjet.ToString());
            Init();
        }
        

        public bool ListeVide
        {
            get
            {
                if (m_listeObjets == null)
                    return true;
                else
                {
                    if (m_listeObjets.Count > 0)
                        return false;
                    else
                        return true;
                }
            }

        }

        public CModeleEtiquetteSchema ModeleSiteListeAUnElement
        {
            get
            {
                if (m_listeObjets == null || m_listeObjets.Count != 1)
                    return null;
                return m_listeObjets[0] as CModeleEtiquetteSchema;
            }
        }


        public CFiltreData Filtre
        {
            get
            {
                return m_filtre;
            }
            set
            {
                m_filtre = value;

            }

        }



        public static CModeleEtiquetteSchema SelectModele(Type typeObjet)
        {

            CModeleEtiquetteSchema modele = null;

            //bool bCreation = false;

            CFormSelectionModeleEtiquette frm = new CFormSelectionModeleEtiquette(typeObjet);
            if (!frm.ListeVide)
            {
                modele = frm.ModeleSiteListeAUnElement;
                if (modele == null && frm.ShowDialog() == DialogResult.OK)
                {
                    modele = (CModeleEtiquetteSchema)frm.m_panelListeModeleEtiquettes.ElementSelectionne;
                }

            }
            else
            {
                CFormAlerte.Afficher(I.T("There is no label type for this object type|30407"), EFormAlerteType.Erreur);
                
            }
            frm.Dispose();

            return modele;
        }




   

        public void Init()
        {

            if (m_filtre != null)
            {
                m_listeObjets = new CListeObjetsDonnees(CSc2iWin32DataClient.ContexteCourant, typeof(CModeleEtiquetteSchema));

                m_listeObjets.Filtre = m_filtre;            

                m_panelListeModeleEtiquettes.InitFromListeObjets(
                    m_listeObjets, typeof(CModeleEtiquetteSchema),
                    null, "");
            }


        }

        private void m_btnOk_Click(object sender, EventArgs e)
        {
            
            if (m_panelListeModeleEtiquettes.ElementSelectionne == null)
            {
                CFormAlerte.Afficher(I.T("Please select a model in the list|30408"), EFormAlerteType.Erreur);

            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void m_btnAnnuler_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

     /*   private void m_panelListeModeleEtiquettes_OnObjetDoubleClick(object sender, EventArgs e)
        {
            if (m_panelListeModeleEtiquettes.ElementSelectionne != null)
            {
                CModeleEtiquetteSchema modele = (CModeleEtiquetteSchema)m_panelListeModeleEtiquettes.ElementSelectionne;
                CFormEditionModeleEtiquetteSchema frm = new CFormEditionModeleEtiquetteSchema();
                CTimosApp.Navigateur.AffichePage(frm);

            }
        }*/



    }
}