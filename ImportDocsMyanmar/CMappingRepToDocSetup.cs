using sc2i.common;
using sc2i.data;
using sc2i.documents;
using sc2i.workflow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using timos.data;

namespace ImportDocsMyanmar
{
    public delegate CObjetDonneeAIdNumerique GetObjetDelegate ( 
        CProjet projetRacine,
        CProjet projetCandidat,
        string strNomFichier);


    [AutoExec("Autoexec")]
    public class CMappingRepToDocSetup
    {
        private static Dictionary<string, CMappingRepToDocSetup> m_dicSetup = new Dictionary<string, CMappingRepToDocSetup>();

        //chaque répertoire commence par un numéro 01-01 par exemple, c'est SAR/Picture of access
        private string m_strCodeRepertoire = "";
        private int? m_nIdCategorieGed = null;
        private GetObjetDelegate m_functionGetObjet;
        private string m_strTemplateKey = "";

        //-------------------------------------------------
        public CMappingRepToDocSetup(
            string strCodeRepertoire,
            int? nIdCategorieGed,
            string strTemplateKey)
        {
            m_strCodeRepertoire = strCodeRepertoire;
            m_nIdCategorieGed = nIdCategorieGed;
            m_strTemplateKey = strTemplateKey;
        }

        //-------------------------------------------------
        public CMappingRepToDocSetup ( 
            string strCodeRepertoire,
            int? nIdCategorieGed,
            GetObjetDelegate functionGetObjet )
        {
            m_strCodeRepertoire = strCodeRepertoire;
            m_nIdCategorieGed = nIdCategorieGed;
            m_functionGetObjet = functionGetObjet;
        }

        //-------------------------------------------------
        public CCategorieGED GetCatégorie ( CContexteDonnee ctx )
        {
            if ( m_nIdCategorieGed == null )
                return null;
            CCategorieGED cat = new CCategorieGED(ctx);
            if (!cat.ReadIfExists(m_nIdCategorieGed.Value))
                return null;
            return cat;
        }

        //-------------------------------------------------
        public CObjetDonneeAIdNumerique GetObjet(
            CProjet projetRacine,
            CProjet projetCandidat,
            string strFichier)
        {
            if ( m_strTemplateKey.Length > 0 )
            {
                return GetObjetProjetFromTemplate(
                    m_strTemplateKey,
                    projetRacine);
            }
            if (m_functionGetObjet != null)
                return m_functionGetObjet.Invoke(
                    projetRacine,
                    projetCandidat,
                    strFichier);
            return null;
        }

        //-------------------------------------------------
        public static void Autoexec()
        {
            m_dicSetup.Add("01", new CMappingRepToDocSetup("01", 15, new GetObjetDelegate(GetObjetProjetCandidat)));
            m_dicSetup.Add("01-01", new CMappingRepToDocSetup("01-01",15, new GetObjetDelegate(GetObjetProjetCandidat)));
            m_dicSetup.Add("01-02", new CMappingRepToDocSetup("01-02",41, new GetObjetDelegate(GetObjetProjetCandidat)));
            m_dicSetup.Add("01-03", new CMappingRepToDocSetup("01-03",40, new GetObjetDelegate(GetObjetProjetCandidat)));
            m_dicSetup.Add("01-04", new CMappingRepToDocSetup("01-04",28, new GetObjetDelegate(GetObjetProjetCandidat)));
            m_dicSetup.Add("01-05", new CMappingRepToDocSetup("01-05",29, new GetObjetDelegate(GetObjetProjetCandidat)));
            m_dicSetup.Add("01-06", new CMappingRepToDocSetup("01-06",30, new GetObjetDelegate(GetObjetProjetCandidat)));
            m_dicSetup.Add("01-07", new CMappingRepToDocSetup("01-07",31, new GetObjetDelegate(GetObjetProjetCandidat)));
            m_dicSetup.Add("01-08", new CMappingRepToDocSetup("01-08",32, new GetObjetDelegate(GetObjetProjetCandidat)));
            m_dicSetup.Add("01-09", new CMappingRepToDocSetup("01-09",33, new GetObjetDelegate(GetObjetProjetCandidat)));
            m_dicSetup.Add("01-10", new CMappingRepToDocSetup("01-10",34, new GetObjetDelegate(GetObjetProjetCandidat)));
            m_dicSetup.Add("01-11", new CMappingRepToDocSetup("01-11",35, new GetObjetDelegate(GetObjetProjetCandidat)));
            m_dicSetup.Add("01-12", new CMappingRepToDocSetup("01-12",36, new GetObjetDelegate(GetObjetProjetCandidat)));
            m_dicSetup.Add("01-13", new CMappingRepToDocSetup("01-13",37, new GetObjetDelegate(GetObjetProjetCandidat)));
            m_dicSetup.Add("01-14", new CMappingRepToDocSetup("01-14", 38, new GetObjetDelegate(GetObjetProjetCandidat)));
            m_dicSetup.Add("01-15", new CMappingRepToDocSetup("01-15", 39, new GetObjetDelegate(GetObjetProjetCandidat)));
            m_dicSetup.Add("01-16", new CMappingRepToDocSetup("01-16", 42, new GetObjetDelegate(GetObjetProjetCandidat)));
            m_dicSetup.Add("01-17", new CMappingRepToDocSetup("01-17", 66, new GetObjetDelegate(GetObjetProjetCandidat)));
            m_dicSetup.Add("01-16-01", new CMappingRepToDocSetup("01-16-01", 43, new GetObjetDelegate(GetObjetProjetCandidat)));
            m_dicSetup.Add("01-16-02", new CMappingRepToDocSetup("01-16-02", 44, new GetObjetDelegate(GetObjetProjetCandidat)));
            m_dicSetup.Add("02", new CMappingRepToDocSetup("02", 16, "TSS"));
            m_dicSetup.Add("03-01", new CMappingRepToDocSetup("03-01", 46, "CW_DESIGN"));
            m_dicSetup.Add("03-02", new CMappingRepToDocSetup("03-02", 18, "CW_DESIGN"));
            m_dicSetup.Add("03-03", new CMappingRepToDocSetup("03-03", 19, "PW_DESIGN"));
            m_dicSetup.Add("03-04", new CMappingRepToDocSetup("03-04", 50, "PW_DESIGN"));
            m_dicSetup.Add("03-05", new CMappingRepToDocSetup("03-05", 45, "CW_DESIGN"));
            m_dicSetup.Add("04", new CMappingRepToDocSetup("04", 26, new GetObjetDelegate(GetObjetProjetCandidat)));
            m_dicSetup.Add("05", new CMappingRepToDocSetup("05", 45, "LEASE_CONTRACT"));
            m_dicSetup.Add("07", new CMappingRepToDocSetup("07", 20, new GetObjetDelegate(GetBuildPermitSubmission)));
            m_dicSetup.Add("08", new CMappingRepToDocSetup("08", 47, "CW_INSTALL"));
            m_dicSetup.Add("09", new CMappingRepToDocSetup("09", 48, "PW_INSTALL"));
            m_dicSetup.Add("10", new CMappingRepToDocSetup("10", 49, "PWO_INSTALL"));
            m_dicSetup.Add("11", new CMappingRepToDocSetup("11", 24, "ACCEPTANCE"));
            m_dicSetup.Add("11-01", new CMappingRepToDocSetup("11-01", 63, "ACCEPTANCE"));
            m_dicSetup.Add("11-02", new CMappingRepToDocSetup("11-02", 64, "ACCEPTANCE"));
        }

        //-------------------------------------------------
        public static CMappingRepToDocSetup GetMapping ( string strRepertoire )
        {
            string[] strParts = strRepertoire.Split(' ');
            if (strParts.Length < 1)
                return null;
            string strStart = strParts[0].Trim();
            CMappingRepToDocSetup map = null;
            m_dicSetup.TryGetValue(strStart, out map);
            return map;

        }

        //-------------------------------------------------
        public static CObjetDonneeAIdNumerique GetObjetProjetRacine(
            CProjet projetRacine,
            CProjet projetCandidat,
            string strNomFichier)
        {
            return projetRacine;
        }

        //-------------------------------------------------
        public static CObjetDonneeAIdNumerique GetBuildPermitSubmission(
            CProjet projetRacine,
            CProjet projetCandidat,
            string strNomFichier)
        {
            //Cherche le projet "Build permit"
            CProjet projet = GetObjetProjetFromTemplate("BUILD_PERMIT", projetRacine) as CProjet;
            if ( projet != null )
            {
                foreach (CDossierSuivi dossier in CDossierSuivi.GetListeDossiersForElement(projet))
                {
                    if (dossier.TypeDossier.Id == 9)
                        return dossier;
                }
            }
            return projet;
        }

        //-------------------------------------------------
        public static CObjetDonneeAIdNumerique GetObjetProjetCandidat(
            CProjet projetRacine,
            CProjet projetCandidat,
            string strNomFichier)
        {
            return projetCandidat;
        }

        //-------------------------------------------------
        private static CObjetDonneeAIdNumerique GetObjetProjetFromTemplate(
            string strTemplateKey,
            CProjet projetRacine)
        {
            if ( projetRacine != null )
            {
                return projetRacine.TousLesProjetsFils.FirstOrDefault(
                    p => p.SourceTemplateKey == strTemplateKey);
            }
            return null;
        }

       

    }

}
