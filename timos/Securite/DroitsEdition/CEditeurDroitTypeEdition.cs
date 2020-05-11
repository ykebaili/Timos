using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.win32.common.customizableList;
using timos.securite;
using sc2i.common;
using sc2i.expression;
using sc2i.win32.data;

namespace timos.Securite.DroitsEdition
{
    public partial class CEditeurDroitTypeEdition : CCustomizableListControl
    {
        private Type m_typeObjets = null;
        private CFournisseurGeneriqueProprietesDynamiques m_fournisseur;

        //------------------------------------------------------------------------
        public CEditeurDroitTypeEdition()
        {
            m_fournisseur = new CFournisseurGeneriqueProprietesDynamiques();
            InitializeComponent();
        }

        //------------------------------------------------------------------------
        public Type TypeObjets
        {
            get{
                return m_typeObjets;
            }
            set
            {
                m_typeObjets = value;
            }
        }


        //------------------------------------------------------------------------
        public CParametreDroitEditionType.CCoupleFormuleToGroupeRestrictions CoupleEdite
        {
            get{
                return CurrentItem != null?CurrentItem.Tag as CParametreDroitEditionType.CCoupleFormuleToGroupeRestrictions:null;
            }
        }

        //------------------------------------------------------------------------
        protected override bool ShouldDrawInImage(Control ctrl)
        {
            bool bDraw = base.ShouldDrawInImage(ctrl);
            if (ctrl == m_txtFormule)
                return false;
            if (ctrl == m_lblFormule)
            {
                m_lblFormule.Location = m_txtFormule.Location;
                m_lblFormule.Size = m_txtFormule.Size;
                return true;
            }
            return bDraw;
        }

        //------------------------------------------------------------------------
        private bool m_bIsInit = false;
        protected override CResultAErreur MyInitChamps(CCustomizableListItem item)
        {
            CResultAErreur result =  base.MyInitChamps(item);
            CParametreDroitEditionType.CCoupleFormuleToGroupeRestrictions couple=  item!=null?item.Tag as CParametreDroitEditionType.CCoupleFormuleToGroupeRestrictions:null;
            if (item != null && couple != null)
            {
                if (!m_bIsInit)
                {
                    m_bIsInit = true;
                    m_txtFormule.Init(m_fournisseur, m_typeObjets);
                    string strField = DescriptionFieldAttribute.GetDescriptionField(m_typeObjets, "DescriptionElement");
                    m_txtGroupe.Init(typeof(CGroupeRestrictionSurType), "Libelle", false);
                    m_txtGroupe.Init(m_typeObjets, strField, false);
                }
                m_lblFormule.Visible = IsCreatingImage;
                m_txtFormule.Visible = !IsCreatingImage;
                m_lblFormule.Text = couple.Formule != null ? couple.Formule.GetString() : "";
                m_txtFormule.Visible = true;
                m_lblFormule.Visible = false;
                m_txtFormule.Formule = couple.Formule;

                m_txtGroupe.ElementSelectionne = couple.GetGroupeRestrictions(CSc2iWin32DataClient.ContexteCourant);
            }
            return result;
        }

        //-----------------------------------------------------------------
        public override bool HasChange
        {
            get
            {
                return true;
            }
            set
            {
                base.HasChange = value;
            }
        }


        //-----------------------------------------------------------------
        protected override CResultAErreur MyMajChamps()
        {
            CResultAErreur result =  base.MyMajChamps();
            if (result)
            {
                CParametreDroitEditionType.CCoupleFormuleToGroupeRestrictions couple = CoupleEdite;
                if (couple != null)
                {
                    C2iExpression formule = m_txtFormule.Formule;
                    if (!m_txtFormule.ResultAnalyse)
                        result.EmpileErreur(result.Erreur);
                    else
                        couple.Formule = formule;
                    m_lblFormule.Text = formule != null ? formule.GetString() : "";
                    couple.SetGroupeRestrictions(m_txtGroupe.ElementSelectionne as CGroupeRestrictionSurType);
                    if (result)
                        result = couple.VerifieDonnees();
                }
            }
            return result;
        }
        
    }
}
