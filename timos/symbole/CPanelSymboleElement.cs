using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;



using sc2i.common;
using sc2i.win32.common;
using sc2i.drawing;
using timos.data;
using sc2i.data;


namespace timos
{
    public partial class CPanelSymboleElement : UserControl , IControlALockEdition
    {

        private IDefinisseurSymbole m_objetEdite;

        private IDefinisseurSymbole m_definisseurExterieurAObjetEdite;

        private Type m_typeEdite;
                

        public CResultAErreur InitChamps(IDefinisseurSymbole objetEdite,IDefinisseurSymbole definisseurExterieurAObjetEdite)
        {
            CResultAErreur result = CResultAErreur.True;

            if (objetEdite==null)
                return CResultAErreur.False;

            m_objetEdite = objetEdite;
            m_definisseurExterieurAObjetEdite = definisseurExterieurAObjetEdite;
            m_typeEdite = objetEdite.GetType();

            if (m_definisseurExterieurAObjetEdite == null)
                m_radioSymboleType.Visible = false;
            else
                m_radioSymboleType.Visible = true;

            InitSymbolesBibliotheque();

            if ( objetEdite.SymbolePropre != null )
                m_radioSymbolePropre.Checked = true;
            else if ( objetEdite.SymboleDeBibliotheque != null || m_definisseurExterieurAObjetEdite==null)
            {
                m_cmbSymboleBib.ElementSelectionne = objetEdite.SymboleDeBibliotheque;
                m_radioSymboleBib.Checked = true;
            }
            else
                m_radioSymboleType.Checked = true;

            RefreshSymbole();

            UpdateEnabled();

            
            return result;
        }

        //Met à jour l'état des contrôles
        private void UpdateEnabled()
        {
            m_linkEditSymbole.Visible = m_gestionnaireModeEdition.ModeEdition && m_radioSymbolePropre.Checked;
            m_cmbSymboleBib.LockEdition = !m_gestionnaireModeEdition.ModeEdition || !m_radioSymboleBib.Checked;

        }

        public CPanelSymboleElement()
        {
            InitializeComponent();
        }


        private void InitSymbolesBibliotheque()
        {
            string strFiltre;
            if ( m_objetEdite == null )
                return;
            Type typePourSymbole = m_objetEdite.GetTypePourLequelOnSelectionneUnSymbole();
            strFiltre = typePourSymbole.ToString();
            CFiltreData filtre = new CFiltreData(CSymboleDeBibliotheque.c_champTypeCible + " = @1", strFiltre);

            m_cmbSymboleBib.InitAvecFiltreDeBase<CSymboleDeBibliotheque>(
               "Libelle",
                 filtre, true);
            
        }

        public CResultAErreur MAJ_Champs()
        {
            CResultAErreur result = CResultAErreur.True;
            if (m_radioSymboleBib.Checked)
            {
                m_objetEdite.SymboleDeBibliotheque = m_cmbSymboleBib.ElementSelectionne as CSymboleDeBibliotheque;
                if(m_objetEdite.SymbolePropre!=null)
                     m_objetEdite.SymbolePropre = null;
            }
            else if(m_radioSymboleType.Checked)
            {
                if(m_objetEdite.SymboleDeBibliotheque!=null)
                     m_objetEdite.SymboleDeBibliotheque = null;
                if(m_objetEdite.SymbolePropre!=null)
                     m_objetEdite.SymbolePropre = null;
            }
            
            return result;
        }


       

       

       
      
     

        public void RefreshSymbole()
        {
            if ( m_objetEdite != null )
            {
                m_controleDessin.InitSymbole(m_objetEdite.SymboleDefiniADessiner);
                m_controleDessin.Refresh();
            }
        }


        #region IControlALockEdition Membres

        public bool LockEdition
        {
            get
            {
                return !m_gestionnaireModeEdition.ModeEdition;
            }
            set
            {
                m_gestionnaireModeEdition.ModeEdition = !value;
                if (OnChangeLockEdition != null)
                    OnChangeLockEdition(this, new EventArgs());
                UpdateEnabled();
            }
        }

        public event EventHandler OnChangeLockEdition;

        #endregion

        

        private void m_radioSymboleBib_CheckedChanged_1(object sender, EventArgs e)
        {
            MAJ_Champs();
            UpdateEnabled();
            RefreshSymbole();
        }

        private void m_radioSymbolePropre_CheckedChanged_1(object sender, EventArgs e)
        {

            MAJ_Champs();
            UpdateEnabled();
            RefreshSymbole();
        }

        private void m_radioSymboleType_CheckedChanged_1(object sender, EventArgs e)
        {
            MAJ_Champs();
            UpdateEnabled();
            RefreshSymbole();
        }

        private void m_cmbSymboleBib_ElementSelectionneChanged_1(object sender, EventArgs e)
        {
            MAJ_Champs();
            RefreshSymbole();
        }

        private void m_linkEditSymbole_LinkClicked_1(object sender, EventArgs e)
        {
            if (m_radioSymbolePropre.Checked)
            {
                if (m_objetEdite.SymbolePropre == null)
                {
                    m_objetEdite.SymboleDeBibliotheque = null;
                    CSymbole sym = new CSymbole(((CObjetDonnee)m_objetEdite).ContexteDonnee);
                    sym.CreateNewInCurrentContexte();
                    m_objetEdite.SymbolePropre = sym;
                }
                C2iSymbole symboleEdite = CFormEditeurSymbolePopup.EditeSymbole(m_objetEdite.SymbolePropre.Symbole, m_typeEdite, false);

                if (symboleEdite != null)
                {
                    m_objetEdite.SymbolePropre.Symbole = symboleEdite;

                    RefreshSymbole();
                }

            }
        }

/*
           private C2iSymbole GetSymboleToDraw(C2iSymbole symbole)
           {

               C2iSymbole symboleADessiner = symbole;
               
               if(m_objetEdite.GetType()==typeof(CTypeEquipement))
               {
                   CTypeEquipement typeq = (CTypeEquipement)m_objetEdite;
                   
                   foreach (CPort port in typeq.Ports)
                   {
                       if (port.Symbole != null)
                       {
                           if (port.SymboleADessiner != null)
                           {
                               C2iSymbolePort groupeSymbole = new C2iSymbolePort();
                               groupeSymbole.Port = port;
                               ArrayList arraySymbole = new ArrayList();
                               ArrayList arrayPos = new ArrayList();
                               symboleADessiner.AddChild(groupeSymbole);
                               foreach (C2iSymbole element in port.SymboleADessiner.Childs)
                               {
                                   arraySymbole.Add(element);
                                   arrayPos.Add(element.PositionAbsolue);
                               }
                               foreach (C2iSymbole element in port.SymboleADessiner.Childs)
                              {
                                   if (element.Parent != null)
                                       element.Parent.RemoveChild(element);
                                   groupeSymbole.AddChild(element);
                                   element.Parent = groupeSymbole;
                               }
                               for (int i = 0; i < arrayPos.Count; i++)
                               {
                                   ((C2iSymbole)groupeSymbole.Childs[i]).PositionAbsolue = (Point)arrayPos[i];
                               }
                               //groupeSymbole.Parent = symboleADessiner;
                               groupeSymbole.PositionAbsolue = new Point(port.PosX, port.PosY);
                               C2iSymboleVerrouille symbolePort = new C2iSymboleVerrouille();
                               symbolePort.SymboleContenu = groupeSymbole;
                               symbolePort.LockSize = true;
                               symbolePort.LockPosition = false;
                               symboleADessiner.AddChild(groupeSymbole);
                               groupeSymbole.Parent = symboleADessiner;
                           }

                       }
                   }
               }

               return symboleADessiner;





           }
  */

    }



 

}
