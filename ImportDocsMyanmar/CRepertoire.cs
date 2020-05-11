using sc2i.common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ImportDocsMyanmar
{
    public class CRepertoire : IElementDeFS    
    {
        private string m_strNom;
        private List<IElementDeFS> m_listeElements = new List<IElementDeFS>();
        private bool m_bImportDone = false;
        private string m_strInfoImport = "";

        private CRepertoire m_repertoireContenant = null;

        public CRepertoire()
        {
        }

        public CRepertoire RepertoireContenant
        {
            get
            {
                return m_repertoireContenant;
            }
            set { m_repertoireContenant = value; }
        }

        public string Nom
        {
            get
            {
                return m_strNom;
            }
            set
            {
                m_strNom = value;
            }
        }

        public List<IElementDeFS> ElementsContenus
        {
            get
            {
                return m_listeElements;
            }
        }

        public string InfoImport
        {
            get
            {
                return m_strInfoImport;
            }
            set
            {
                m_strInfoImport = value;
            }
        }

        public bool ImportDone
        {
            get
            {
                return m_bImportDone;
            }
            set { m_bImportDone = value; }
        }

        public bool HasErreurImport()
        {
            if (m_bImportDone && InfoImport.Length > 0)
                return true;
            if (m_listeElements.FirstOrDefault(u => u.HasErreurImport()) != null)
                return true;
            return false;
        }

        public void ClearDataImport()
        {
            ImportDone = false;
            InfoImport = "";
            foreach (IElementDeFS elt in m_listeElements)
                elt.ClearDataImport();
        }

        public IEnumerable<T> GetChilds<T>()
        {
            return from elt in m_listeElements where elt is T select (T)elt;
        }

        private int GetNumVersion()
        {
            return 0;
        }

        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            serializer.TraiteString(ref m_strNom);
            result = serializer.TraiteListe<IElementDeFS>(m_listeElements);
            serializer.TraiteBool(ref m_bImportDone);
            serializer.TraiteString(ref m_strInfoImport);
            if (serializer.Mode == ModeSerialisation.Lecture)
                foreach (IElementDeFS elt in m_listeElements)
                    elt.RepertoireContenant = this;
            return result;
        }

        public void FillFrom ( string strPathComplet )
        {
            Nom = Path.GetFileName(strPathComplet);
            foreach ( string strDir in Directory.GetDirectories(strPathComplet ))
            {
                CRepertoire dossier = GetChilds<CRepertoire>().FirstOrDefault(d => d.Nom == Path.GetFileName(strDir));
                if ( dossier == null )
                    dossier = new CRepertoire();
                dossier.FillFrom(strDir);
                m_listeElements.Add(dossier);
            }
            foreach (string strFile in Directory.GetFiles(strPathComplet))
            {
                CFichier fichier = GetChilds<CFichier>().FirstOrDefault(fi => fi.Nom == Path.GetFileName(strFile));
                if ( fichier == null )
                    fichier = new CFichier();
                fichier.Nom = Path.GetFileName(strFile);
                FileInfo f = new FileInfo(strFile);
                fichier.LastModifDate = f.LastWriteTime;
                fichier.Size = f.Length;
                m_listeElements.Add(fichier);
            }

        }

        public bool HasFiles
        {
            get
            {
                if (m_listeElements.FirstOrDefault(e => e is CFichier) != null)
                    return true;
                foreach (CRepertoire dossier in GetChilds<CRepertoire>())
                    if (dossier.HasFiles)
                        return true;
                return false;
            }
        }

        public CFichier FindNext(bool bCanGoUp, CRepertoire repertoireStart, CFichier fichierStart, Regex regExRepertoire, Regex regExFichier, IIndicateurProgression indicateur)
        {
            bool bStartSearch = fichierStart == null;
            if (repertoireStart != null && repertoireStart.RepertoireContenant == null)
                repertoireStart = null;
            if (regExRepertoire.IsMatch(Nom))
            {
                foreach (CFichier fichier in GetChilds<CFichier>())
                {
                    if (fichier == fichierStart)
                    {
                        bStartSearch = true;
                        continue;
                    }
                    if (!bStartSearch)
                        continue;
                    if (regExFichier.IsMatch(fichier.Nom))
                        return fichier;
                }
            }
            if ( RepertoireContenant == null && indicateur != null )
            {
                indicateur.SetBornesSegment(0, GetChilds<CRepertoire>().Count());
            }
            int nIndex = 0;
            bStartSearch = repertoireStart == null;
            foreach (CRepertoire rep in GetChilds<CRepertoire>())
            {
                if (RepertoireContenant == null)
                {
                    indicateur.SetInfo(rep.Nom);
                    nIndex++;
                    indicateur.SetValue(nIndex);
                }
                if (rep == repertoireStart)
                {
                    bStartSearch = true;
                    continue;
                }
                if (!bStartSearch)
                    continue;
                CFichier trouve = rep.FindNext(false, null, null, regExRepertoire, regExFichier, indicateur);
                if (trouve != null)
                    return trouve;
                if (indicateur.CancelRequest)
                    return null;
                

            }
            if (RepertoireContenant != null && bCanGoUp)
            {
                return RepertoireContenant.FindNext(true, this, null, regExRepertoire, regExFichier, indicateur);
            }
            return null;
        }

        public string FullName
        {
            get
            {
                StringBuilder bl = new StringBuilder();
                CRepertoire rep = this;
                while (rep.RepertoireContenant != null)
                {
                    bl.Insert(0, rep.Nom);
                    bl.Insert(0, "/");
                    rep = rep.RepertoireContenant;
                }
                return bl.ToString();
            }
        }

    }
}
