using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.data;
using sc2i.win32.data;
using System.Drawing;

namespace timos.General
{
    public class CObjetDonneeMenuItem : ToolStripMenuItem
    {
        private CObjetDonnee m_objetDonneeDragDrop = null;
        private CObjetDonneeAIdNumerique m_objetDonneeToEdit = null;


        //-----------------------------------------------------------------
        public CObjetDonneeMenuItem(CObjetDonnee objetDragDrop,
            CObjetDonneeAIdNumerique objetToEdit, 
            string strText)
            : this(
            objetDragDrop, 
            objetToEdit,
            strText, 
            true)
        {
        }

        //-----------------------------------------------------------------
        public CObjetDonneeMenuItem(CObjetDonnee objetDragDrop,
            CObjetDonneeAIdNumerique objetToEdit,
            string strText,
            bool bStandardClick)
            :base(strText)
        {
            m_objetDonneeDragDrop = objetDragDrop;
            m_objetDonneeToEdit = objetToEdit;
            if (bStandardClick)
            {
                Click += new EventHandler(CObjetDonneeMenuItem_Click);
            }
            MouseDown += new MouseEventHandler(CObjetDonneeMenuItem_MouseDown);
            MouseMove += new MouseEventHandler(CObjetDonneeMenuItem_MouseMove);
            MouseUp += new MouseEventHandler(CObjetDonneeMenuItem_MouseUp);
        }

        //-----------------------------------------------------------------
        public CObjetDonnee ObjetDragDrop
        {
            get
            {
                return m_objetDonneeDragDrop;
            }
        }

        //-----------------------------------------------------------------
        public CObjetDonnee ObjetToEdit
        {
            get
            {
                return m_objetDonneeToEdit;
            }
        }


        //------------------------------------------------------------------
        void CObjetDonneeMenuItem_MouseUp(object sender, MouseEventArgs e)
        {
            m_ptStartDrag = null;
        }

        //------------------------------------------------------------------
        Point? m_ptStartDrag = null;
        void CObjetDonneeMenuItem_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                m_ptStartDrag = new Point(e.X, e.Y);
        }

        //------------------------------------------------------------------
        void CObjetDonneeMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && m_ptStartDrag != null)
            {
                if (Math.Abs(e.X - m_ptStartDrag.Value.X) > 3 ||
                    Math.Abs(e.Y - m_ptStartDrag.Value.Y) > 3)
                {
                    CReferenceObjetDonnee refe = new CReferenceObjetDonnee(m_objetDonneeDragDrop);
                    DoDragDrop(refe, DragDropEffects.Link | DragDropEffects.Copy);
                }
            }
        }


        //------------------------------------------------------------------
        void CObjetDonneeMenuItem_Click(object sender, EventArgs e)
        {
            if (DropDownItems.Count == 0)
            {
                CObjetDonneeAIdNumerique objet = m_objetDonneeToEdit.GetObjetInContexte(CSc2iWin32DataClient.ContexteCourant) as CObjetDonneeAIdNumerique;
                CTimosApp.Navigateur.EditeElement(objet, false, "");
            }
        }
    }
}
