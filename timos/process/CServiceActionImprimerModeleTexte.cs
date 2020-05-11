using System;
using System.Windows.Forms;

using sc2i.common;
using sc2i.multitiers.client;
using sc2i.process;
using sc2i.expression;
using sc2i.win32.common;
using sc2i.win32.data;	
using sc2i.data;

using sc2i.win32.data.navigation;
using System.Threading;
using sc2i.win32.navigation;
using sc2i.workflow;
using System.Drawing.Printing;
using timos.win32.composants.RichEdit;
using System.Drawing;

namespace timos.process
{
	/// <summary>
	/// Description résumée de CServiceActionImprimerModeleTexte.
	/// </summary>
	[AutoExec("Autoexec")]
	public class CServiceActionImprimerModeleTexte : CServiceSurClient
	{
		/// ///////////////////////////////////////////
		public override string IdService
		{
			get
			{
				return CActionImprimerModeleTexte.c_idServiceClientImprimerModeleTexte;
			}
		}

		public static void Autoexec()
		{
			CSessionClient.RegisterServiceSurClient ( new CServiceActionImprimerModeleTexte() );
		}

		/// ///////////////////////////////////////////
        private CObjetDonnee m_objetToEdit = null;
        private CResultAErreur m_resultEdit = CResultAErreur.True;
        private string m_strCodeFormulaire = "";

        private void EditeElement()
        {

            CReferenceTypeForm refTypeForm = null;
            if (m_strCodeFormulaire != string.Empty)
                refTypeForm = CFormFinder.GetRefFormToEdit(m_objetToEdit.GetType(), m_strCodeFormulaire);
            else
                refTypeForm = CFormFinder.GetRefFormToEdit(m_objetToEdit.GetType());

            if (refTypeForm == null)
            {
                m_resultEdit.EmpileErreur(I.T("The system is not able to edit elements from type @1|1076", m_objetToEdit.GetType().ToString()));
                return;
            }

            try
            {
                CFormEditionStandard form = refTypeForm.GetForm((CObjetDonneeAIdNumeriqueAuto)m_objetToEdit) as CFormEditionStandard;
                if (form != null)
                    CFormNavigateurPopup.Show(form);

            }
            catch (Exception e)
            {
                m_resultEdit.EmpileErreur(new CErreurException(e));
            }
        }
       

		/// ///////////////////////////////////////////
        private CPrintRichTextBox m_textBoxToPrint = null;
        private int m_nPageToPrint = 0;
		public override sc2i.common.CResultAErreur RunService(object parametre)
		{
			CResultAErreur result = CResultAErreur.True;
			if ( !(parametre is CActionImprimerModeleTexte.CParametreImpressionModeleTexte) )
			{
				result.EmpileErreur (I.T( "Parameter type imcompatible with 'print text model' service|20113"));
				return result;
			}
			CActionImprimerModeleTexte.CParametreImpressionModeleTexte parametreEdition = (CActionImprimerModeleTexte.CParametreImpressionModeleTexte)parametre;
			CObjetDonnee objet = parametreEdition.ReferenceObjet.GetObjet ( CSc2iWin32DataClient.ContexteCourant );
			if ( objet == null )
			{
				result.EmpileErreur(I.T( "The object to edit doesn't exist|1078"));
				return result;
			}

            //Charge le modèle de texte
            CModeleTexte modele = new CModeleTexte(CSc2iWin32DataClient.ContexteCourant);
            if ( !modele.ReadIfExists ( parametreEdition.IdModeleTexte ) )
            {
                result.EmpileErreur(I.T("Text model @1 doesn't exists|20114", parametreEdition.IdModeleTexte.ToString()));
                return result;
            }

            PrinterSettings printSet = new PrinterSettings();
            PageSettings pageSet = new PageSettings();
            result = CTextPrintSetup.ApplyParameters ( parametreEdition.ParametresImpression, printSet, pageSet );
            if ( !result )
                return result;

            using (CPrintRichTextBox txtBox = new CPrintRichTextBox() )
            {
                result = CUtilModeleTexte.FillRichTextBox ( 
                    txtBox,
                    modele,
                    objet );
                if ( !result )
                    return result;
                
               using ( PrintDocument doc = new PrintDocument() )
               {
                   pageSet.PrinterSettings = printSet;
                   doc.DefaultPageSettings = pageSet;
                   doc.PrinterSettings = printSet;
                   m_textBoxToPrint = txtBox;
                   m_nPageToPrint = 0;
                   doc.PrintPage += new PrintPageEventHandler(doc_PrintPage);
                   doc.Print();
               }
            }
            return result;
        }

        void doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            m_nPageToPrint=m_textBoxToPrint.Print(m_nPageToPrint, m_textBoxToPrint.TextLength, e);
            e.HasMorePages = m_nPageToPrint < m_textBoxToPrint.TextLength;
        }
	}


}
