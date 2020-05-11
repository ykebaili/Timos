using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

using sc2i.common;
using sc2i.expression;
using sc2i.data.dynamic;
using sc2i.workflow;
using timos.win32.composants.RichEdit;

namespace timos.win32.composants
{
	public partial class CRichTextViewer : UserControl
	{
		delegate void InitFenetreDelegate(CModeleTexte mode, object objet);

		private CModeleTexte m_modele;
		private object m_objetAffiche;

		public CRichTextViewer()
		{
			InitializeComponent();
		}

		public void Init(CModeleTexte modele, object objet)
		{
			m_modele = modele;
			m_objetAffiche = objet;
			if ( IsHandleCreated )
				BeginInvoke(new InitFenetreDelegate(InitFenetre), m_modele, m_objetAffiche);
		}

		private void InitFenetre ( CModeleTexte modele, object objet) 
		{
			m_txtBox.Visible = false;
			m_txtBox.Clear();
			if ( objet == null )
				return;
            CResultAErreur result = CResultAErreur.True;
            try
            {
                result = CUtilModeleTexte.FillRichTextBox(
                    m_txtBox, modele, objet);
            }
            catch (Exception e)
            {
                result.EmpileErreur(new CErreurException(e));
            }
            if (!result)
                m_txtBox.Text = result.Erreur.ToString();
			m_txtBox.BackColor = modele.CouleurFond;
			m_txtBox.Visible = true;
		}

		private void m_timerDemarrage_Tick(object sender, EventArgs e)
		{

		}

		private void CRichTextViewer_Load(object sender, EventArgs e)
		{
			if ( m_modele != null && m_objetAffiche != null )
				BeginInvoke(new InitFenetreDelegate(InitFenetre), m_modele, m_objetAffiche);
		}

		public object ObjetAffiche
		{
			get
			{
				return m_objetAffiche;
			}
		}
	}
}
