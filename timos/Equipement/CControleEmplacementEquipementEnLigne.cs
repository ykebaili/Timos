using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using timos.data;
using sc2i.common;
using sc2i.data;
using timos.acteurs;

namespace timos.Equipement
{
    public partial class CControleEmplacementEquipementEnLigne : UserControl
    {
        private bool m_bAvecEntete = true;
        public CControleEmplacementEquipementEnLigne()
        {
            InitializeComponent();
        }

        //-------------------------------------------------
        public bool AvecEntete
        {
            get
            {
                return m_bAvecEntete;
            }
            set
            {
                m_bAvecEntete = value;
                if (m_bAvecEntete)
                {
                    Size = new Size(Size.Width, m_lblEmplacement.Height + m_cmbTypeEmplacement.Height);
                    foreach (Control ctrl in Controls)
                    {
                        if (ctrl.Name.StartsWith("m_lbl"))
                            ctrl.Visible = true;
                    }
                }
                else
                {
                    Size = new Size(Size.Width, m_cmbTypeEmplacement.Height);
                    foreach (Control ctrl in Controls)
                    {
                        if (ctrl.Name.StartsWith("m_lbl"))
                            ctrl.Visible = false;
                    }
                }
            }
        }


        public void Init(CEquipement equipementModele)
        {
            m_cmbTypeEmplacement.Init ( DynamicClassAttribute.GetAllDynamicClassHeritant(typeof(IEmplacementEquipement));
            if ( equipementModele != null && equipementModele.Emplacement != null)
                m_cmbTypeEmplacement.TypeSelectionne = equipementModele.Emplacement.GetType();
            if ( m_cmbTypeEmplacement.TypeSelectionne == null )
                m_cmbTypeEmplacement.TypeSelectionne = typeof(CStock);

            if ( m_cmbTypeEmplacement.TypeSelectionne != null )
            {
                m_selectEmplacement.Init (
                    m_cmbTypeEmplacement.TypeSelectionne,
                    "Libelle",
                    null,
                    true );
            }
            m_selectEmplacement.ElementSelectionne = equipementModele.Emplacement as CObjetDonnee;
        }

        private void InitSelectEmplacement()
        {
            if (m_cmbTypeEmplacement.TypeSelectionne != null)
            {
                m_selectEmplacement.Init(
                    m_cmbTypeEmplacement.TypeSelectionne,
                    "Libelle",
                    null,
                    true);
            }
        }


        //--------------------------------------------------------------------------------
        private void m_cmbTypeEmplacement_SelectionChangeCommitted(object sender, EventArgs e)
        {
            IEmplacementEquipement place = m_selectEmplacement.ElementSelectionne as IEmplacementEquipement;
            InitSelectEmplacement();
            Type tp = m_cmbTypeEmplacement.TypeSelectionne;
            if (place != null && tp != null && tp == place.GetType())
                m_selectEmplacement.ElementSelectionne = place as CObjetDonnee;
        }


        //-------------------------------------------------------------------------
        private void m_selectEmplacement_OnSelectedObjectChanged(object sender, EventArgs e)
        {

        }

        //-------------------------------------------------
        private void InitComboEquipementParent()
        {
            IEmplacementEquipement emplacement = m_selectEmplacement.ElementSelectionne as IEmplacementEquipement;
            if (emplacement == null)
            {
                m_cmbEquipement.Visible = false;
            }
            else
            {
                CFiltreData filtre = null;

                if (emplacement is CSite)
                    filtre = new CFiltreData(CSite.c_champId + "=@1",
                        emplacement.Id);
                if (emplacement is CStock)
                    filtre = new CFiltreData(CStock.c_champId + "=@1",
                        emplacement.Id);
                if (emplacement is CActeur)
                    filtre = new CFiltreData(CActeur.c_champId + "=@1",
                        emplacement.Id);


                m_cmbEquipement.Init(typeof(CEquipement),
                    "EquipementsContenus",
                    CEquipement.c_champIdEquipementContenant,
                    "Libelle",
                    null,
                    filtre);
                m_cmbEquipement.Visible = true;
            }
        }

        public IEmplacementEquipement Emplacement
        {
            get
            {
                return m_selectEmplacement.ElementSelectionne as IEmplacementEquipement;
            }
        }

        public CEquipement EquipementContenant
        {
            get
            {
                return m_cmbEquipement.ElementSelectionne as CEquipement;
            }
        }
    }
}
