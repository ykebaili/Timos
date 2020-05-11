using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using sc2i.data;
using sc2i.win32.data.navigation;
using spv.data;
using timos.data;
using sc2i.common;

namespace spv.win32
{
    public partial class CExtenderFormSitePrestation : CExtendeurFormEditionStandardTabPage
    {
        private CSpvSite m_spvSite = null;

        public CExtenderFormSitePrestation()
        {
            InitializeComponent();
            Title = I.T("Concerned services|60006");

        }

        public override Type TypeObjetEtendu
        {
            get
            {
                return typeof(CSite);
            }
        }

        protected CSite LeSite
        {
            get
            {
                return ObjetEdite as CSite;
            }
        }


        public override CResultAErreur MyInitChamps()
        {
            if (ObjetEdite is CSite)
            {
                m_spvSite = CSpvSite.GetObjetSpvFromObjetTimos(ObjetEdite as CSite) as CSpvSite;
            }
            CResultAErreur result = base.MyInitChamps();
            if (!result)
                return result;

            if (m_spvSite == null)
            {
                CFiltreDataImpossible filtreImpossible = new CFiltreDataImpossible();
                CListeObjetsDonnees listeVideProg = new CListeObjetsDonnees(ObjetEdite.ContexteDonnee, typeof(CSpvSchemaReseau));
                listeVideProg.Filtre = filtreImpossible;

                m_PanelPrestations.InitFromListeObjets(
                    listeVideProg, typeof(CSpvSchemaReseau), null, null, "SpvSite");
            }
            else
            {
                m_PanelPrestations.InitFromListeObjets(
                m_spvSite.PrestationsConcernees,
                typeof(CSpvSchemaReseau),
                typeof(CFormEditSpvProg), //to be changed
                m_spvSite,
                "SpvSite");
            }
           
            return result;
        }
    }
}
