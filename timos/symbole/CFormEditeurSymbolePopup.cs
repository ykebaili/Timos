using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using timos.data;
using sc2i.common;


namespace timos
{
    public partial class CFormEditeurSymbolePopup : Form
    {
        public CFormEditeurSymbolePopup()
        {
            InitializeComponent();
            sc2i.win32.common.CWin32Traducteur.Translate(this);
        }

     

        public static C2iSymbole EditeSymbole(C2iSymbole symboleEdite, Type typeEdite,bool bEditePorts)
        {

           
            CFormEditeurSymbolePopup form = new CFormEditeurSymbolePopup();
            C2iSymbole symbole;
             symbole = new C2iSymbole();
            if (bEditePorts)
                form.m_btnAnnuler.Visible = false;

            if (symboleEdite == null)
            {
               
                symbole.Size = new Size(300, 300);
                symbole.BackColor = Color.Transparent;
                symbole.TargetType = typeEdite;
                form.m_panelEditeurSymbole.Init(symbole, typeEdite, bEditePorts);
            }
            else

               
                form.m_panelEditeurSymbole.Init(symboleEdite, typeEdite, bEditePorts);

       

         
            
            if(form.ShowDialog()==DialogResult.OK)
            {


                symbole = form.m_panelEditeurSymbole.SymboleEdite;
                form.Dispose();
                


               return (symbole);
             


            }
            else 
            {
                form.Dispose();
                return null;
            }

           
        }

        private void m_btnOk_Click(object sender, EventArgs e)
        {

            DialogResult = DialogResult.OK;
            Close();
        }

        private void m_btnAnnuler_Click(object sender, EventArgs e)
        {
           
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void m_linkAjusterFond_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            m_panelEditeurSymbole.AjusterFond();
        }









    }
}