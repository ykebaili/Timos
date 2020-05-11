using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TimosInventory.data.releve;
using sc2i.common.memorydb;
using TimosInventory.data;
using sc2i.common;

namespace TimosInventory.ControleInventaire
{
    public partial class CControleTypeEquipement : UserControl
    {
        private CReleveEquipement m_relEq = null;
        private CMemoryDbIndex<CTypeEquipement> m_indexType = null;
        private CMemoryDbIndex<CTypeEquipementConstructeur> m_indexConst = null;

        public CControleTypeEquipement()
        {
            InitializeComponent();
        }

        private bool m_bIsInitializing = false;
        public void Init(CReleveEquipement relEq, bool bModeEdit)
        {
            m_bIsInitializing = true;
            m_relEq = relEq;
            if (relEq != null && relEq.Equipement != null)
            {
                FillListeTypes(relEq.Equipement.Database);
            }
            else return;
            
            CTypeEquipement tp = relEq != null ?
                m_indexType.GetFromId(relEq.IdTypeEquipement) :
                null;
            if (tp != null)
            {
                m_txtSelectTypeEquipement.SelectedObject = tp;
                m_txtSelectTypeEquipement.LockEdition = !bModeEdit;
            }
            else
                m_txtSelectTypeEquipement.SelectedObject = null;

            CTypeEquipementConstructeur tpc = relEq != null ?
                m_indexConst.GetFromId(relEq.IdTypeEquipementConstructeur) :
                null;
            if (tpc != null)
                m_cmbRefConst.Text = tpc.Libelle;
            else
                m_cmbRefConst.Text = "";
            if (bModeEdit)
                FillListePN();
            m_bIsInitializing = false;
        }

        private void FillListeTypes(CMemoryDb db)
        {
            m_indexType = new CMemoryDbIndex<CTypeEquipement>(db);
            m_indexConst = new CMemoryDbIndex<CTypeEquipementConstructeur>(db);
            
            m_txtSelectTypeEquipement.InitAvecFiltreDeBase(
                db,
                typeof(CTypeEquipement),
                "Libelle",
                null,
                new CFiltreMemoryDb(CTypeEquipement.c_champLibelle + " LIKE @1"),
                true);
            
        }

        //-----------------------------------------------------------------------------
        private void m_cmbTypeEq_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FillListePN();
            if (!m_bIsInitializing && ValueChanged != null)
                ValueChanged(this, null);

        }

        //-----------------------------------------------------------------------------
        public event EventHandler ValueChanged;

        //-----------------------------------------------------------------------------
        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            if (m_relEq != null && m_relEq.Row.Row.RowState != DataRowState.Detached)
            {
                CEquipement eqpt = m_relEq.Equipement;
                if (eqpt != null)
                {
                    CTypeEquipement tp = m_txtSelectTypeEquipement.SelectedObject as CTypeEquipement;
                    if (tp != null)
                    {
                        m_relEq.TypeEquipement = tp;
                        if (m_cmbRefConst.SelectedValue as string != null)
                        {
                            CTypeEquipementConstructeur tpc = new CTypeEquipementConstructeur(eqpt.Database);
                            if (tpc.ReadIfExist(m_cmbRefConst.SelectedValue as string) &&
                                tpc.TypeEquipement.Id == tp.Id)
                                m_relEq.TypeEquipementConstructeur = tpc;
                        }
                    }
                }
            }
            return result;
        }

        //-----------------------------------------------------------------------------
        private void FillListePN()
        {
            CTypeEquipement tp = m_txtSelectTypeEquipement.SelectedObject as CTypeEquipement;
            if (tp != null)
            {
                m_cmbRefConst.DataSource = tp.RelationsConstructeurs.ToArray();
            }
            else
            {
                m_cmbRefConst.DataSource = new CListeEntitesDeMemoryDb<CTypeEquipementConstructeur>(CTimosInventoryDb.GetTimosDatas()).ToArray();
            }
            m_cmbRefConst.DisplayMember = "Libelle";
            m_cmbRefConst.ValueMember = "Id";
            CTypeEquipementConstructeur tpc = null;
            if (m_relEq != null)
            {
                tpc = m_relEq.TypeEquipementConstructeur;

            }
            if (tpc != null)
                m_cmbRefConst.SelectedValue = tpc.Id;
            else
                m_cmbRefConst.SelectedIndex = -1;


        }

        private void m_cmbRefConst_Enter(object sender, EventArgs e)
        {
            FillListePN();
        }

        private void m_cmbRefConst_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!m_bIsInitializing )
            {
                if (m_cmbRefConst.SelectedValue as string != null)
                {
                    CTypeEquipementConstructeur tpc = new CTypeEquipementConstructeur(CTimosInventoryDb.GetTimosDatas());
                    if (tpc.ReadIfExist(m_cmbRefConst.SelectedValue as string))
                        m_txtSelectTypeEquipement.SelectedObject = tpc.TypeEquipement;

                }
                if ( ValueChanged != null )
                    ValueChanged(this, null);
            }
        }
    }
}
