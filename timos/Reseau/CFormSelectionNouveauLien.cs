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
    public partial class CFormSelectionNouveauLien : Form
    {

     
        private bool m_bExistant=true;

        private CListeObjetsDonnees m_listeObjets=null;

        private CFiltreData m_filtreLiens;

        public CFormSelectionNouveauLien()
        {
            InitializeComponent();
            sc2i.win32.common.CWin32Traducteur.Translate(this);
            Init(); 
          
        }


        public CFormSelectionNouveauLien(
            IElementALiensReseau source,
            IElementALiensReseau destination,
            CLienReseau lienSupporte)
        {
            InitializeComponent();
            sc2i.win32.common.CWin32Traducteur.Translate(this);
            m_filtreLiens = GetFiltreListeLiens(source, destination, lienSupporte);
            
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

     
       public CFiltreData FiltreLiens
       {
           get
           {
               return m_filtreLiens;
           }
           set
           {
               m_filtreLiens = value;

           }

       }




        public static CLienReseau SelectExistant(
            IElementALiensReseau source,
            IElementALiensReseau destination,
            IEtapeLienReseau[] etapesCheminSrc,
            IEtapeLienReseau[] etapesCheminDest,
            CLienReseau lienSupporté,
            ref bool bCreate)
        {

            CLienReseau lien = null;


            bool bCreation = false;

            CFormSelectionNouveauLien frm = new CFormSelectionNouveauLien(source, destination, lienSupporté);

            if (!frm.ListeVide)
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (frm.m_bExistant)
                    {
                        lien = (CLienReseau)frm.m_panelListeLiensExistants.ElementSelectionne;

                    }
                    else
                    {
                        bCreation = true;
                    }

                }
            }
            else
                bCreation = true;
            frm.Dispose();



            bCreate = bCreation;
            return lien;


        }


        public void Init()
        {
           
            if (m_filtreLiens != null)
            {
                m_listeObjets = new CListeObjetsDonnees(CSc2iWin32DataClient.ContexteCourant, typeof(CLienReseau));

                m_listeObjets.Filtre = m_filtreLiens;

                

/*
                if (m_etapesSource != null)
                {
                    for (int i = 0; i < m_listeObjets.Count; i++)
                    {
                        CLienReseau lien = (CLienReseau)m_listeObjets[i];
                        CCheminLienReseau chemin1 = lien.RacineChemin1;
                        if (!CheminContientEtape(chemin1, m_etapesSource, 0))
                        {
                            m_listeObjets.RemoveAt(i);
                        }

                    }
                }


                if (m_etapesDest != null)
                {
                    for (int i = 0; i < m_listeObjets.Count; i++)
                    {
                        CLienReseau lien = (CLienReseau)m_listeObjets[i];
                        CCheminLienReseau chemin2 = lien.RacineChemin2;
                        if (!CheminContientEtape(chemin2, m_etapesDest, 0))
                        {
                            m_listeObjets.RemoveAt(i);
                        }

                    }
                }
                */
                
                m_panelListeLiensExistants.InitFromListeObjets(
                    m_listeObjets, typeof(CLienReseau),
                    null, "");
            }
               

        }

        private void m_btnExistant_CheckedChanged(object sender, EventArgs e)
        {
            m_bExistant = m_btnExistant.Checked;
        }

        private void m_btnOk_Click(object sender, EventArgs e)
        {

            if (m_bExistant && m_panelListeLiensExistants.ElementSelectionne == null)
            {
                CFormAlerte.Afficher(I.T("Please select a link in the list|30404"), EFormAlerteType.Erreur);

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

        private void m_btnCreerNouveau_CheckedChanged(object sender, EventArgs e)
        {
           
        }


        public CFiltreData GetFiltreListeLiens(
            IElementALiensReseau element1, 
            IElementALiensReseau element2,
            CLienReseau lienSupporte)
        {

            CFiltreData filtre = null ;

            if ( lienSupporte != null )
            {
                CTypeLienReseau typeLien = lienSupporte.TypeLienReseau;
                StringBuilder bl = new StringBuilder();
                if ( typeLien != null )
                {
                    foreach ( CTypeLienReseauSupport supportant in typeLien.TypesPouvantSupporterCeType )
                    {
                        bl.Append ( supportant.TypeSupportant.Id );
                        bl.Append(',');
                    }
                }
                if ( bl.Length > 0 )
                {
                    bl.Remove ( bl.Length-1, 1 );
                    filtre = new CFiltreData ( CTypeLienReseau.c_champId+" in ("+bl.ToString()+")");
                }
            }

            StringBuilder blIdsLiens = new StringBuilder();
            foreach ( CLienReseau lien in element1.LiensSortants )
            {
                IElementALiensReseau elt = lien.GetAutreExtremite ( element1 );
                if ( elt != null && elt.Equals ( element2 ))
                {
                    blIdsLiens.Append(lien.Id);
                    blIdsLiens.Append(',');
                }
            }
           
            if ( blIdsLiens.Length > 0 )
            {
                blIdsLiens.Remove ( blIdsLiens.Length-1, 1 );
                filtre = CFiltreData.GetAndFiltre ( filtre, new CFiltreData ( 
                    CLienReseau.c_champId+" in ("+blIdsLiens.ToString()+")"));
                return filtre;
            }
            return null;
        }
        /*
            foreach (CLienReseau lien in element1.LiensSortants)
            {
                CCheminLienReseau chemin = null;
                IElementALiensReseau eltALien = lien.Element1;
                chemin = lien.RacineChemin1;
                if ( eltALien != element1 || lien.Direction == EDirectionLienReseau.DeuxVersUn )
                {
                    eltALien = null;
                    chemin = null;
                }
                if ( eltALien == null )
                {
                    eltALien = lien.Element2;
                    chemin = lien.RacineChemin2;
                    if ( eltALien != element1 || lien.Direction == EDirectionLienReseau.UnVersDeux )
                    {
                        eltALien = null;
                        chemin = null;
                    }

                if ( lien.Element1 == element1 && lien.Direction != EDirectionLienReseau.DeuxVersUn ||
                    lien.Element2 == element1 && lien.Direction != EDirectionLienReseau.UnVersDeux )
                {
                if (lien.Element1 != null)
                {
                    if (lien.Element1.Id == element1.Id)
                    {

                        if (m_etapesSource != null)
                        {
                            CCheminLienReseau chemin1 = lien.RacineChemin1;
                            if (chemin1 != null)
                            {
                                if (CheminContientEtape(chemin1, m_etapesSource, 0))
                                {
                                    strIds1 += lien.Id.ToString() + ",";
                                }
                            }

                        }
                        else
                        {
                            if (lien.RacineChemin1 == null)
                                strIds1 += lien.Id.ToString() + ",";
                        }

                    }
                }

                

            }

            foreach (CLienReseau lien in element2.Liens)
            {
                if (lien.Element2 != null)
                {
                    if (lien.Element2.Id == element2.Id)
                    {

                        if (m_etapesDest != null)
                        {
                            CCheminLienReseau chemin2 = lien.RacineChemin2;
                            if (chemin2 != null)
                            {
                                if (CheminContientEtape(chemin2, m_etapesDest, 0))
                                {
                                    strIds2 += lien.Id.ToString() + ",";
                                }
                            }



                        }
                        else
                        {
                            if (lien.RacineChemin2 == null)
                                strIds2 += lien.Id.ToString() + ",";
                        }

                    }
                }
            }

            if ((strIds1 != "") && (strIds2 != ""))
            {

                strIds1 = strIds1.Substring(0, strIds1.Length - 1);
                strIds2 = strIds2.Substring(0, strIds2.Length - 1);
                filtre = new CFiltreData(CLienReseau.c_champId + " IN (" + strIds1 + ")");
                filtre = CFiltreData.GetAndFiltre(filtre, new CFiltreData(CLienReseau.c_champId + " IN (" + strIds2 + ")"));
                return filtre;

            }
            else
                return null;









        }*/


       


        private bool CheminContientEtape(CCheminLienReseau chemin, IEtapeLienReseau[] etapes, int index)
        {
            bool bResult = true;
            if ( chemin == null && (etapes == null || etapes.Length == 0 ))//Pas de chemin ou pas d'étapes
                return true;
            if (chemin != null && etapes == null)//Un chemin, mais pas d'étapes 
                return false;
            if(index >= etapes.Length)
                return false;
            if (chemin == null)
                return false;

            if (chemin.Etape.Equals( etapes[index]))
            {
                CSchemaReseau sch1 = (CSchemaReseau)chemin.Etape;
                string sch1lib = sch1.Libelle;
                CSchemaReseau sch2 = (CSchemaReseau)(etapes[index]);
                string sch2lib = sch2.Libelle;


                if (chemin.CheminParent != null)
                {
                    bResult = CheminContientEtape(chemin.CheminParent, etapes, index + 1);

                }
                else
                    bResult = true;

            }
            else
                bResult = false;
             


            return bResult;

        }

        private void m_panelListeLiensExistants_OnObjetDoubleClick(object sender, EventArgs e)
        {
            if (m_panelListeLiensExistants.ElementSelectionne != null)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

      

       


    /*    private void m_panelListeLiensExistants_OnObjetDoubleClick(object sender, EventArgs e)
        {
            if (m_panelListeLiensExistants.ElementSelectionne != null)
            {
                CLienReseau lien = (CLienReseau)m_panelListeLiensExistants.ElementSelectionne;
                CFormEditionLienReseau frm = new CFormEditionLienReseau(lien);
                CTimosApp.Navigateur.AffichePage(frm);

            }
        }*/



    }
}