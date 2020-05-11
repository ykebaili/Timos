using System;
using System.Windows.Forms;

using sc2i.common;
using sc2i.multitiers.client;
using sc2i.process;
using sc2i.expression;
using sc2i.win32.common;
using System.Data;
using sc2i.data.dynamic;
using sc2i.win32.data.dynamic;
using System.Threading;
using sc2i.formulaire;
using System.IO;
using sc2i.formulaire.win32.editor;

namespace timos.process
{
	/// <summary>
	/// Description résumée de CServiceActionExporterDonnees.
	/// </summary>
	[AutoExec("Autoexec")]
	public class CServiceActionExporterDonnees : CServiceSurClient
	{
		/// ///////////////////////////////////////////
		public override string IdService
		{
			get
			{
                return CActionExporterDonnees.c_idServiceClientExporterDonnees;
			}
		}

		public static void Autoexec()
		{
			CSessionClient.RegisterServiceSurClient ( new CServiceActionExporterDonnees() );
		}

		/// ///////////////////////////////////////////
        CActionExporterDonnees m_actionExport;
        CMultiStructureExport m_structure;
        CResultAErreur m_resultForm = CResultAErreur.True;
        public override sc2i.common.CResultAErreur RunService(object parametre)
		{
			CResultAErreur result = CResultAErreur.True;

            m_actionExport = parametre as CActionExporterDonnees;
            if (m_actionExport == null)
            {
                result.EmpileErreur(I.T("Parameter type incompatible with 'Data Export' service|10045"));
                return result;
            }

            m_structure = m_actionExport.StructureEnExecution;
            if (m_structure.Formulaire != null && m_structure.Formulaire.Childs.Length > 0)
            {
                Thread th = new Thread(new ThreadStart(ShowFormulaire));
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
                th.Join();

            }

            if (!m_resultForm)
            {
                result.EmpileErreur(I.T("Error or cancel in the form|10047"));
                return result;
            }

			return m_resultForm;
		}

        public void ShowFormulaire()
        {
            using (C2iSponsor sponsor = new C2iSponsor())
            {
                sponsor.Register(m_structure);
                CResultAErreur result = CResultAErreur.True;

                //Fait passer le formulaire par le réseau
                byte[] dataFormulaire = m_actionExport.GetDataSerialisationFormulairePourClient();
                MemoryStream stream = new MemoryStream(dataFormulaire);
                BinaryReader reader = new BinaryReader(stream);
                CSerializerReadBinaire serializer = new CSerializerReadBinaire(reader);
                serializer.AttacheObjet(typeof(IElementAVariablesDynamiquesBase), m_structure);
                I2iSerializable formulaireSer = null;
                result = serializer.TraiteObject(ref formulaireSer);

                reader.Close();
                stream.Close();
                
                if (!result)
                {
                    m_resultForm.EmpileErreur(I.T("Error while retrieving the form|30253"));
                }
                
                C2iWnd formulaire = (C2iWnd)formulaireSer;
       
                CFormFormulairePopup form = new CFormFormulairePopup();

                if (form.EditeElement(CTimosApp.Navigateur, formulaire, m_structure, I.T("Exporting data|10046")))
                {
                    m_resultForm = CResultAErreur.True;
                    m_resultForm.Data = E2iDialogResult.OK;
                }
                else
                    m_resultForm.Data = E2iDialogResult.Cancel;

            }
        }


	}
}
