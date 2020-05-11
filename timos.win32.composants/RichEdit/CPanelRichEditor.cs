using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

using sc2i.common;
using sc2i.expression;
using sc2i.win32.common;
using sc2i.data.dynamic;

namespace timos.win32.composants.RichEdit
{
	public partial class CPanelRichEditor : UserControl, IControlALockEdition
	{
		public CPanelRichEditor()
		{
			InitializeComponent();
		}

		#region Outils pour l'édition du richtextBox

		//-------------------------------------------------------
		private void tbrFont_Click(object sender, EventArgs e)
		{
			SelectFontToolStripMenuItem_Click(this, e);
		}

		//-------------------------------------------------------
		private void tspColor_Click(object sender, EventArgs e)
		{
			FontColorToolStripMenuItem_Click(this, new EventArgs());
		}

		//-------------------------------------------------------
		private void tbrLeft_Click(object sender, EventArgs e)
		{
			m_txtBox.SelectionAlignment = HorizontalAlignment.Left;
		}

		//-------------------------------------------------------
		private void tbrCenter_Click(object sender, EventArgs e)
		{
			m_txtBox.SelectionAlignment = HorizontalAlignment.Center;
		}

		//-------------------------------------------------------
		private void tbrRight_Click(object sender, EventArgs e)
		{
			m_txtBox.SelectionAlignment = HorizontalAlignment.Right;
		}

		//-------------------------------------------------------
		private void tbrBold_Click(object sender, EventArgs e)
		{
			BoldToolStripMenuItem_Click(this, e);
		}

		//-------------------------------------------------------
		private void tbrItalic_Click(object sender, EventArgs e)
		{
			ItalicToolStripMenuItem_Click(this, e);
		}

		//-------------------------------------------------------
		private void tbrUnderline_Click(object sender, EventArgs e)
		{
			UnderlineToolStripMenuItem_Click(this, e);
		}

		//-------------------------------------------------------
		private void mnuUndo_Click(object sender, EventArgs e)
		{
			try
			{
				if (m_txtBox.CanUndo)
				{
					m_txtBox.Undo();
				}
			}
			catch (Exception ex)
			{
				CFormAlerte.Afficher(ex.Message.ToString(), EFormAlerteType.Erreur);
			}
		}

		//-------------------------------------------------------
		private void mnuRedo_Click(object sender, EventArgs e)
		{
			try
			{
				if (m_txtBox.CanRedo)
				{
					m_txtBox.Redo();
				}
			}
			catch (Exception ex)
			{
				CFormAlerte.Afficher(ex.Message.ToString(), EFormAlerteType.Erreur);
			}
		}

		//-------------------------------------------------------
		private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				m_txtBox.SelectAll();
			}
			catch (Exception)
			{
				CFormAlerte.Afficher(I.T("Unable to select all document content.|30034"), EFormAlerteType.Erreur);
			}
		}

		//-------------------------------------------------------
		private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				m_txtBox.Copy();
			}
			catch (Exception)
			{
                CFormAlerte.Afficher(I.T("Unable to copy document content.|30035"), EFormAlerteType.Erreur);
			}
		}

		//-------------------------------------------------------
		private void CutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				m_txtBox.Cut();
			}
			catch
			{
				CFormAlerte.Afficher(I.T("Unable to cut document content.|30036"), EFormAlerteType.Erreur);
			}
		}

		//-------------------------------------------------------
		private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				m_txtBox.Paste();
			}
			catch
			{
				CFormAlerte.Afficher("Unable to copy clipboard content to document.|30037", EFormAlerteType.Erreur);
			}
		}

		//-------------------------------------------------------
		private void SelectFontToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				if (!(m_txtBox.SelectionFont == null))
				{
					m_fontDialog.Font = m_txtBox.SelectionFont;
				}
				else
				{
					m_fontDialog.Font = null;
				}
				m_fontDialog.ShowApply = true;
                m_fontDialog.ScriptsOnly = false;
				if (m_fontDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					m_txtBox.SelectionFont = m_fontDialog.Font;
				}
			}
			catch (Exception ex)
			{
				CFormAlerte.Afficher(ex.Message.ToString(), EFormAlerteType.Erreur);
			}
		}

		//-------------------------------------------------------
		private void FontColorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				m_colorDialog.Color = m_txtBox.ForeColor;
				if (m_colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					m_txtBox.SelectionColor = m_colorDialog.Color;
				}
			}
			catch (Exception ex)
			{
				CFormAlerte.Afficher(ex.Message.ToString(), EFormAlerteType.Erreur);
			}
		}

		//-------------------------------------------------------
		private void BoldToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				if (!(m_txtBox.SelectionFont == null))
				{
					System.Drawing.Font currentFont = m_txtBox.SelectionFont;
					System.Drawing.FontStyle newFontStyle;

					newFontStyle = m_txtBox.SelectionFont.Style ^ FontStyle.Bold;

					m_txtBox.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);

				}
			}
			catch (Exception ex)
			{
				CFormAlerte.Afficher(ex.Message.ToString(), EFormAlerteType.Erreur);
			}
		}

		//-------------------------------------------------------
		private void ItalicToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				if (!(m_txtBox.SelectionFont == null))
				{
					System.Drawing.Font currentFont = m_txtBox.SelectionFont;
					System.Drawing.FontStyle newFontStyle;

					newFontStyle = m_txtBox.SelectionFont.Style ^ FontStyle.Italic;

					m_txtBox.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
				}
			}
			catch (Exception ex)
			{
				CFormAlerte.Afficher(ex.Message.ToString(), EFormAlerteType.Erreur);
			}
		}

		//-------------------------------------------------------
		private void UnderlineToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				if (!(m_txtBox.SelectionFont == null))
				{
					System.Drawing.Font currentFont = m_txtBox.SelectionFont;
					System.Drawing.FontStyle newFontStyle;

					newFontStyle = m_txtBox.SelectionFont.Style ^ FontStyle.Underline;

					m_txtBox.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
				}
			}
			catch (Exception ex)
			{
				CFormAlerte.Afficher(ex.Message.ToString(), EFormAlerteType.Erreur);
			}
		}

		//-------------------------------------------------------
		private void NormalToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				if (!(m_txtBox.SelectionFont == null))
				{
					System.Drawing.Font currentFont = m_txtBox.SelectionFont;
					System.Drawing.FontStyle newFontStyle;
					newFontStyle = FontStyle.Regular;
					m_txtBox.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
				}
			}
			catch (Exception ex)
			{
				CFormAlerte.Afficher(ex.Message.ToString(), EFormAlerteType.Erreur);
			}
		}

		//-------------------------------------------------------
		private void PageColorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				m_colorDialog.Color = m_txtBox.BackColor;
				if (m_colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					m_txtBox.BackColor = m_colorDialog.Color;
				}
			}
			catch (Exception ex)
			{
				CFormAlerte.Afficher(ex.Message.ToString(), EFormAlerteType.Erreur);
			}
		}

		//-------------------------------------------------------
		private void mnuIndent0_Click(object sender, System.EventArgs e)
        {
            try
            {
                m_txtBox.SelectionIndent = 0;
            }
            catch (Exception ex)
            {
                CFormAlerte.Afficher(ex.Message.ToString(), EFormAlerteType.Erreur);
            }
        }



		//-------------------------------------------------------
        private void mnuIndent5_Click(object sender, System.EventArgs e)
        {
            try
            {
                m_txtBox.SelectionIndent = 5;
            }
            catch (Exception ex)
            {
                CFormAlerte.Afficher(ex.Message.ToString(), EFormAlerteType.Erreur);
            }
        }



		//-------------------------------------------------------
        private void mnuIndent10_Click(object sender, System.EventArgs e)
        {
            try
            {
                m_txtBox.SelectionIndent = 10;
            }
            catch (Exception ex)
            {
                CFormAlerte.Afficher(ex.Message.ToString(), EFormAlerteType.Erreur);
            }
        }



		//-------------------------------------------------------
        private void mnuIndent15_Click(object sender, System.EventArgs e)
        {
            try
            {
                m_txtBox.SelectionIndent = 15;
            }
            catch (Exception ex)
            {
                CFormAlerte.Afficher(ex.Message.ToString(), EFormAlerteType.Erreur);
            }
        }



		//-------------------------------------------------------
        private void mnuIndent20_Click(object sender, System.EventArgs e)
        {
            try
            {
                m_txtBox.SelectionIndent = 20;
            }
            catch (Exception ex)
            {
                CFormAlerte.Afficher(ex.Message.ToString(), EFormAlerteType.Erreur);
            }

        }

		//-------------------------------------------------------
		private void LeftToolStripMenuItem_Click_1(object sender, System.EventArgs e)
		{
			try
			{
				m_txtBox.SelectionAlignment = HorizontalAlignment.Left;
			}
			catch (Exception ex)
			{
				CFormAlerte.Afficher(ex.Message.ToString(), EFormAlerteType.Erreur);
			}
		}



		//-------------------------------------------------------
		private void CenterToolStripMenuItem_Click_1(object sender, System.EventArgs e)
		{
			try
			{
				m_txtBox.SelectionAlignment = HorizontalAlignment.Center;
			}
			catch (Exception ex)
			{
				CFormAlerte.Afficher(ex.Message.ToString(), EFormAlerteType.Erreur);
			}
		}



		//-------------------------------------------------------
		private void RightToolStripMenuItem_Click_1(object sender, System.EventArgs e)
		{
			try
			{
				m_txtBox.SelectionAlignment = HorizontalAlignment.Right;
			}
			catch (Exception ex)
			{
				CFormAlerte.Afficher(ex.Message.ToString(), EFormAlerteType.Erreur);
			}
		}

		//-------------------------------------------------------
		private void AddBulletsToolStripMenuItem_Click(object sender, System.EventArgs e)
		{
			try
			{
				m_txtBox.BulletIndent = 10;
				m_txtBox.SelectionBullet = true;
			}
			catch (Exception ex)
			{
				CFormAlerte.Afficher(ex.Message.ToString(), EFormAlerteType.Erreur);
			}
		}



		//-------------------------------------------------------
		private void RemoveBulletsToolStripMenuItem_Click(object sender, System.EventArgs e)
		{
			try
			{
				m_txtBox.SelectionBullet = false;
			}
			catch (Exception ex)
			{
				CFormAlerte.Afficher(ex.Message.ToString(), EFormAlerteType.Erreur);
			}
		}

		#endregion

		//-------------------------------------------------------
		public void Init( IFournisseurProprietesDynamiques fournisseurProprietes, Type typeObjets )
		{
			m_wndFormule.Init(fournisseurProprietes, typeObjets);
		}

		//-------------------------------------------------------
		public byte[] TextBoxData
		{
			get
			{
				MemoryStream stream = new MemoryStream();
				try
				{
					m_txtBox.SaveFile( stream, RichTextBoxStreamType.RichText );
					return stream.GetBuffer();
				}
				catch 
				{
				}
				return null;
			}
			set
			{
				if (value != null)
				{
					MemoryStream stream = new MemoryStream(value);
					try
					{
						m_txtBox.LoadFile(stream, RichTextBoxStreamType.RichText);
						stream.Close();
					}
					catch
					{
					}
				}
				else
					m_txtBox.Clear();
			}
		}

        //-------------------------------------------------------
        public string TextModel
        {
            get
            {
                return m_txtBox.Text;
            }
        }

		//-------------------------------------------------------
		public Color TextBackColor
		{
			get
			{
				return m_txtBox.BackColor;
			}
			set
			{
				m_txtBox.BackColor = value;
			}
		}

		//-------------------------------------------------------
		private void m_lnkInsererFormule_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			C2iExpression formule = m_wndFormule.Formule;
			if (formule != null)
			{
				m_txtBox.SelectedText = "{" + m_wndFormule.Formule.GetString() + "}";
			}
		}



		#region IControlALockEdition Membres

		public bool LockEdition
		{
			get
			{
				return !m_panelFormule.Enabled;
			}
			set
			{
				m_panelFormule.Enabled = !value;
				m_txtBox.ReadOnly = value;
				m_toolbar.Enabled = !value;
				MenuStrip1.Enabled = !value;
				if (OnChangeLockEdition != null)
					OnChangeLockEdition(this, new EventArgs());
			}
		}

		public event EventHandler OnChangeLockEdition;

		#endregion

		
	}
}
