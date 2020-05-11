using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using futurocom.snmp.alarme;
using futurocom.snmp;
using sc2i.common;
using sc2i.expression;
using futurocom.supervision;
using futurocom.snmp.dynamic;
using sc2i.win32.common;
using sc2i.common.memorydb;
using futurocom.snmp.entitesnmp;

namespace futurocom.win32.snmp.alarmes
{
    public partial class CPanelEditTrapHandler : UserControl, IControlALockEdition
    {
        private CTrapHandler m_originalHandler = null;
        private CTrapHandler m_handler = null;
        private IBaseTypesAlarmes m_baseTypesAlarmes = null;

        public CPanelEditTrapHandler()
        {
            InitializeComponent();
        }

        public void Init(
            CTrapHandler handler, 
            IBaseTypesAlarmes baseAlarmes,
            IDefinition rootDefinition)
        {
            m_originalHandler = handler;
            CMemoryDb dbEdition = new CMemoryDb();
            m_handler = dbEdition.ImporteObjet(handler, true, true) as CTrapHandler;
            m_handler.TypeAgent = handler.TypeAgent;
            m_baseTypesAlarmes = baseAlarmes;
            InitChamps();
        }

        public CResultAErreur MajChamps()
        {
            CResultAErreur result = m_linkField.FillObjetFromDialog(m_handler);
            if (result)
            {
                m_handler.FormuleDeclenchement = m_txtFormuleCondition.Formule;
                m_handler.GenericRequestedValue = m_cmbGenericCode.SelectedItem as GenericCode?;
            }
            C2iExpressionGraphique exp = m_editeurPreTraitement.ExpressionGraphique;
            exp.RefreshFormuleFinale();
            m_handler.FormulePreTraitementTrap = exp;
            m_handler.TypeEntiteAssocie = m_cmbTypeEntite.SelectedValue as CTypeEntiteSnmpPourSupervision;
            m_handler.FormuleIndexEntite = m_txtFormuleIndexEntite.Formule;
            if (result)
                result = m_handler.VerifieDonnees();
            if (result)
            {

                m_originalHandler.Database.Merge(m_handler.Database, false);// ImporteObjet(m_handler, true, true);
                //CCloner2iSerializable.CopieTo(m_handler, m_originalHandler);
            }
            
            return result;
        }

        private void InitChamps()
        {
            m_linkField.FillDialogFromObjet(m_handler);
            m_cmbGenericCode.Items.Clear();
            m_cmbGenericCode.Items.Add(I.T("Any|20059"));
            
            foreach ( GenericCode code in Enum.GetValues ( typeof(GenericCode) ))
                m_cmbGenericCode.Items.Add ( code );
            if (m_handler.GenericRequestedValue == null)
                m_cmbGenericCode.SelectedIndex = 0;
            else
                m_cmbGenericCode.SelectedItem = m_handler.GenericRequestedValue.Value;
            m_txtFormuleCondition.Init ( m_handler,
                typeof (CTrapInstance) );
            m_txtFormuleCondition.Formule = m_handler.FormuleDeclenchement;

            C2iExpression formulePreTraitement = m_handler.FormulePreTraitementTrap;
            if (!(formulePreTraitement is C2iExpressionGraphique))
            {
                C2iExpressionGraphique graf = new C2iExpressionGraphique();
                graf.InitFromFormule(formulePreTraitement);
                formulePreTraitement = graf;
            }

            m_editeurPreTraitement.Init(formulePreTraitement as C2iExpressionGraphique,
                m_handler,
                new CObjetPourSousProprietes ( m_handler.TypeAgent ));

            FillListeTrapFields();
            FillListeFieldsSupplementaires();
            

            FillListeCreateurs();

            m_cmbTypeEntite.ListDonnees = m_handler.TypeAgent.TypesEntites;
            m_cmbTypeEntite.SelectedValue = m_handler.TypeEntiteAssocie;

            m_txtFormuleIndexEntite.Init(m_handler, typeof(CTrapInstance));
            m_txtFormuleIndexEntite.Formule = m_handler.FormuleIndexEntite;

        }

        //---------------------------------------------------------
        private void FillListeTrapFields()
        {
            m_wndListeChamps.ListeSource = m_handler.FieldsFromTrap.ToArray();
            m_wndListeChamps.Refresh();
        }

        //---------------------------------------------------------
        private void FillListeFieldsSupplementaires()
        {
            m_wndListeChampsSupplementaires.ListeSource = m_handler.FieldsSupplementaires.ToArray();
            m_wndListeChampsSupplementaires.Refresh();
        }

        //---------------------------------------------------------
        private void m_lnkRemoveChamp_LinkClicked(object sender, EventArgs e)
        {
            if (m_wndListeChamps.SelectedItems.Count == 1)
            {
                CTrapField field = m_wndListeChamps.SelectedItems[0] as CTrapField;
                if (field != null)
                {
                    m_handler.RemoveFieldFromTrap(field);
                    FillListeTrapFields();
                }
            }
        }

        //---------------------------------------------------------
        private void m_lnkAddChamp_LinkClicked(object sender, EventArgs e)
        {
            CTrapField field = new CTrapField();
            if (CFormEditTrapField.EditeField(field))
            {
                m_handler.AddFieldFromTrap(field);
                FillListeTrapFields();
            }
        }

        //---------------------------------------------------------
        private void m_wndListeChamps_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!m_extModeEdition.ModeEdition)
                return;
            EditeChampTrap();
        }

        private void EditeChampTrap()
        {
            if (m_wndListeChamps.SelectedItems.Count == 1)
            {
                CTrapField field = m_wndListeChamps.SelectedItems[0] as CTrapField;
                if (field != null)
                {
                    if (CFormEditTrapField.EditeField(field))
                    {
                        FillListeTrapFields();
                    }
                }
            }
        }

        //---------------------------------------------------------
        private void m_lnkRemoveChampSupplementaire_LinkClicked(object sender, EventArgs e)
        {
            if (m_wndListeChampsSupplementaires.SelectedItems.Count == 1)
            {
                CTrapFieldSupplementaire field = m_wndListeChampsSupplementaires.SelectedItems[0] as CTrapFieldSupplementaire;
                if (field != null)
                {
                    m_handler.RemoveFieldSupplementaire(field);
                    FillListeFieldsSupplementaires();
                }
            }
        }

        //---------------------------------------------------------
        private void m_lnkAddChampSupplementaires_LinkClicked(object sender, EventArgs e)
        {
            CTrapFieldSupplementaire field = new CTrapFieldSupplementaire();
            if (CFormEditTrapFieldSupplementaire.EditeField(field))
            {
                m_handler.AddFieldSupplementaire(field);
                FillListeFieldsSupplementaires();
            }
        }

        //---------------------------------------------------------
        private void m_wndListeChampsSupplementaires_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!m_extModeEdition.ModeEdition)
                return;
            EditeChampSupp();
        }

        private void EditeChampSupp()
        {
            if (m_wndListeChampsSupplementaires.SelectedItems.Count == 1)
            {
                CTrapFieldSupplementaire field = m_wndListeChampsSupplementaires.SelectedItems[0] as CTrapFieldSupplementaire;
                if (field != null)
                {
                    if (CFormEditTrapFieldSupplementaire.EditeField(field))
                    {
                        FillListeFieldsSupplementaires();
                    }
                }
            }
        }

        //---------------------------------------------------------------------
        private void FillListeCreateurs()
        {
            m_wndListeCreations.ListeSource = m_handler.CreateursAlarmes.ToArray();
        }

        //---------------------------------------------------------------------
        private void m_lnkAddCreation_LinkClicked(object sender, EventArgs e)
        {
            CCreateurAlarme createur = new CCreateurAlarme(m_handler.Database);
            createur.CreateNew();
            createur.TrapHandler = m_handler;
            if (CFormEditCreateurAlarme.EditeCreateur(createur, m_baseTypesAlarmes))
            {
                FillListeCreateurs();
            }
            else
                createur.Delete();
        }

        //---------------------------------------------------------------------
        private void m_lnkRemoveCreation_LinkClicked(object sender, EventArgs e)
        {
            if (m_wndListeCreations.SelectedItems.Count == 1)
            {
                CCreateurAlarme createur = m_wndListeCreations.SelectedItems[0] as CCreateurAlarme;
                if (createur != null)
                {
                    CResultAErreur result = createur.Delete();
                    if (!result)
                        CFormAlerte.Afficher(result.Erreur);
                    FillListeCreateurs();
                }
            }
        }

        //---------------------------------------------------------------------
        private void m_wndListeCreations_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!m_extModeEdition.ModeEdition)
                return;
            EditeCreateur();
        }

        //-------------------------------------------
        private void EditeCreateur()
        {
            if (m_wndListeCreations.SelectedItems.Count == 1)
            {
                CCreateurAlarme createur = m_wndListeCreations.SelectedItems[0] as CCreateurAlarme;
                if ( EditeCreateur ( createur ) )
                {
                        FillListeCreateurs();
                }
            }
        }

        //-------------------------------------------
        private bool EditeCreateur( CCreateurAlarme createur )
        {
            if ( createur == null )
            return false;
            return CFormEditCreateurAlarme.EditeCreateur(createur, m_baseTypesAlarmes);
        }


        //-------------------------------------------
        public bool LockEdition
        {
            get
            {
                return !m_extModeEdition.ModeEdition;
            }
            set
            {
                m_extModeEdition.ModeEdition = !value;
                if ( OnChangeLockEdition != null )
                    OnChangeLockEdition ( this, new EventArgs() );
            }
        }

        //-------------------------------------------
        public event EventHandler OnChangeLockEdition;

        private void m_lnkDetailChampTrap_LinkClicked(object sender, EventArgs e)
        {
            EditeChampTrap();
        }

        private void m_lnkEditChampSupp_LinkClicked(object sender, EventArgs e)
        {
            EditeChampSupp();
        }

        private void m_lnkDetailCreateur_LinkClicked(object sender, EventArgs e)
        {
            EditeCreateur();
        }

        private void m_tabControl_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void m_wndListeCreations_OnChangeSelection(object sender, EventArgs e)
        {
            m_lnkDupliqueCreator.Enabled = m_wndListeCreations.SelectedItems.Count == 1;
        }

        //------------------------------------------------------------------------
        private void m_lnkDupliqueCreator_LinkClicked(object sender, EventArgs e)
        {
            if (m_wndListeCreations.SelectedItems.Count == 1)
            {
                CCreateurAlarme createur = m_wndListeCreations.SelectedItems[0] as CCreateurAlarme;

                if (createur != null)
                {
                    CCreateurAlarme copie = createur.GetCopieSansFils() as CCreateurAlarme;
                    copie.Code = Guid.NewGuid().ToString();
                    if (!EditeCreateur(copie))
                    {
                        copie.Delete();
                    }
                    else
                        FillListeCreateurs();
                }
            }
        }
    }
}

