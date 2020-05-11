using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.win32.common.customizableList;
using timos.data;
using sc2i.data;
using sc2i.win32.data.navigation;
using sc2i.win32.data;
using sc2i.workflow;
using timos.securite;
using timos.interventions.crintervention;

namespace timos.interventions.preventives
{
    public partial class CEditeurOperationsPreventives : CCustomizableListAvecNiveau
    {
        private IElementAOperationPrevisionnelle m_elementAOperations = null;


        public CEditeurOperationsPreventives()
        {
            InitializeComponent();
            if (!DesignMode)
            {
                ItemControl = new CEditeurUneOperationPreventive();
                ItemControl.OnLeaveLastControl += new CCustomizableListControl.OnLeaveLastControlEventHandler(ItemControl_OnLeaveLastControl);
            }
            sc2i.win32.common.CWin32Traducteur.Translate(this);
        }

        

        public void Init(IElementAOperationPrevisionnelle eltAOperations)
        {
            m_elementAOperations = eltAOperations;
            Items = new CCustomizableListItem[0];
            CListeObjetsDonnees lst = eltAOperations.Operations;
            lst.Filtre = new CFiltreData ( COperation.c_champIdOpParente+" is null");
            foreach ( COperation op in lst )
            {
                AddOperation ( op, null );
            }
            Refresh();
        }

        private void AddOperation(COperation operation, CItemOperation itemParent)
        {
            CItemOperation item = new CItemOperation(operation, itemParent);
            AddItem(item, false);
            foreach (COperation child in operation.OperationsFilles)
            {
                AddOperation(child, item);
            }
        }


        public IElementAOperationPrevisionnelle ElementAOperations
        {
            get
            {
                return m_elementAOperations;
            }
        }

        //--------------------------------------------------
        public override void RemoveItem(int nIndex, bool bRedraw)
        {
            if (nIndex >= 0 && nIndex < Items.Count())
            {
                CItemOperation item = Items[nIndex] as CItemOperation;
                if (item != null)
                {
                    CurrentItemIndex = null;
                    List<CCustomizableListItemANiveau> lstToDelete = GetItemsDependants(item);
                    lstToDelete.Insert(0, item);
                    lstToDelete.Reverse();
                    foreach (CItemOperation toDelete in lstToDelete)
                    {
                        item.Operation.Delete(true);
                        base.RemoveItem(item.Index, false);
                    }
                    Refresh();
                }
            }
        }

        //-------------------------------------------------------------
        bool ItemControl_OnLeaveLastControl(object sender, EventArgs args)
        {
            if (sender != null)
            {
                return AddOperationALaFin();
                
            }
            return false;
        }

        //-------------------------------------------------------------
        public bool AddOperationALaFin()
        {
            if (LockEdition)
                return false;
            //s'il y a des opérations sans type, on n'ajoute pas
            foreach (CItemOperation item in Items)
            {
                if (item.Operation == null || item.Operation.TypeOperation == null)
                {
                    CurrentItemIndex = item.Index;
                    return false;
                }
            }
            //Regarde si le dernier item est vide
            if (!LockEdition && ElementAOperations != null)
            {
                CItemOperation item = null;

                COperation operation = new COperation(ElementAOperations.ContexteDonnee);
                operation.CreateNewInCurrentContexte();
                operation.ElementAOperationPrevisionnelle = ElementAOperations;
                CItemOperation prec = null;
                CItemOperation itemParent = null;
                if (Items.Count() > 0)
                {
                    prec = GetVisibleItemBefore(Items.Count()) as CItemOperation;
                    if (prec != null)
                    {
                        if (prec.Operation != null && prec.Operation.TypeOperation != null &&
                            prec.Operation.TypeOperation.TypesOperationsFilles.Count > 0)
                        {
                            operation.OperationParente = prec.Operation;
                            itemParent = prec;
                        }
                        else
                        {
                            operation.OperationParente = prec.Operation.OperationParente;
                            itemParent = prec.ItemParent as CItemOperation;
                        }
                    }
                }
                if (operation.OperationParente != null)
                    operation.Niveau = operation.OperationParente.Niveau + 1;
                else
                    operation.Niveau = 0;
                item = new CItemOperation(operation, itemParent);
                AddItem(item, true);
                CurrentItemIndex = item.Index;
                if (AfterAddOperation != null)
                    AfterAddOperation(this, null);
                return true;

            }
            return false;
        }

        //----------------------------------------------------------------------
        private void m_picExtraireListe_Click(object sender, EventArgs e)
        {
            IElementAOperationPrevisionnelle elt = ((CObjetDonnee)ElementAOperations).GetObjetInContexte(CSc2iWin32DataClient.ContexteCourant) as IElementAOperationPrevisionnelle;
            if ( elt != null )
            {
                CFormListeExtraite.ShowListe(elt.Libelle, elt.Operations, null, "FROM_EDIT_OPERATIONS");
            }
        }

        //------------------------------------------------------------------------------
        private void m_btnAddOperation_LinkClicked(object sender, EventArgs e)
        {
            AddOperationALaFin();
        }

        //------------------------------------------------------------------------------
        public event EventHandler AfterAddOperation;

        //------------------------------------------------------------------------------
        public int HeaderHeight
        {
            get
            {
                return m_panelHeader.Height + m_panelTop.Height;
            }
        }

        //------------------------------------------------------------------------------
        public override bool LockEdition
        {
            get
            {
                return base.LockEdition;
            }
            set
            {
                m_extModeEdition.ModeEdition = !value;
                base.LockEdition = value;

            }
        }
    }
}
