using sc2i.common;
using sc2i.data;
using sc2i.documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using timos.data;

namespace ImportDocsMyanmar
{
    public class CImporteurGED
    {

        public CImporteurGED()
        {

        }

        public CResultAErreur ImporteDossierProjet ( 
            CProjet projetNominal,
            CRepertoire repertoire, 
            string strPathGed )
        {
            repertoire.ClearDataImport();
            repertoire.ImportDone = true;
            //Trouve le projet candidat
            CProjet candidat = projetNominal.TousLesProjetsFils.FirstOrDefault(p => p.TypeProjet.Id == 14);
            if ( candidat == null )
            {
                repertoire.InfoImport = "No candidate for this directory";
                return CResultAErreur.True;
            }
            CResultAErreur result = CResultAErreur.True;
            object numCandidate = candidat.GetValeurChamp ( 2589 );
            if ( numCandidate == null )
            {
                repertoire.InfoImport = "Candidate "+candidat.Libelle+" has no candidate number";
                return result;
            }
            string strNomCandidat = "Candidate "+numCandidate.ToString().PadLeft(2, '0');
            //Cherche le répertoire du candidat
            
            foreach ( CRepertoire rep in repertoire.GetChilds<CRepertoire>())
                if ( rep.Nom.ToUpper().Equals(strNomCandidat.ToUpper()))
                {
                    result = ImportRepCandidat ( projetNominal, candidat, rep, strPathGed );
                    return result;
                }
            repertoire.InfoImport = "Can not find directory "+strNomCandidat;
            return result;
        }

        private CResultAErreur ImportRepCandidat ( CProjet projetNominal,
            CProjet projetCandidat, 
            CRepertoire repCandidat,
            string strPathGed )
        {
            strPathGed += "\\"+repCandidat.Nom;
            CResultAErreur result = CResultAErreur.True;
            repCandidat.ImportDone = true;
            foreach (CRepertoire repertoire in repCandidat.GetChilds<CRepertoire>())
            {
                result = ImportRep(projetNominal, projetCandidat, repertoire, strPathGed);
                if (!result)
                    return result;
            }
            return result;
        }

        private CResultAErreur ImportRep(CProjet projetNominal,
            CProjet projetCandidat,
            CRepertoire rep,
            string strPathGed)
        {
            CResultAErreur result = CResultAErreur.True;
            rep.ImportDone = true;
            strPathGed += "\\" + rep.Nom;
            CMappingRepToDocSetup map = CMappingRepToDocSetup.GetMapping(rep.Nom);
            foreach (CFichier fichier in rep.GetChilds<CFichier>())
            {
                if (map == null)
                    fichier.InfoImport = "No mapping for this directory";
                else
                {
                    CObjetDonneeAIdNumerique objet = map.GetObjet(projetNominal,
                        projetCandidat,
                        fichier.Nom);
                    if (objet == null)
                        fichier.InfoImport = "Can not find associated objet for this file";
                    else
                    {
                        CCategorieGED cat = map.GetCatégorie(projetNominal.ContexteDonnee);
                        if (cat == null)
                            fichier.InfoImport = "Can not find EDM category for this file";
                        else
                        {
                            string strCode = objet.IdUniversel + "/" + fichier.Nom;
                            CDocumentGED doc = new CDocumentGED(projetNominal.ContexteDonnee);
                            if (!doc.ReadIfExists(new CFiltreData(CDocumentGED.c_champCle + "=@1", strCode)))
                                doc.CreateNewInCurrentContexte();
                            doc.Libelle = fichier.Nom;
                            doc.Cle = strCode;
                            CReferenceDocument refDoc = new CReferenceDocument();
                            refDoc.TypeReference = new CTypeReferenceDocument(CTypeReferenceDocument.TypesReference.Fichier);
                            refDoc.NomFichier = strPathGed + "\\" + fichier.Nom;
                            doc.ReferenceDoc = refDoc;
                            doc.AddCategory(cat);
                            doc.AssocieA(objet);
                            fichier.SetObjetAssocie(objet);
                        }

                    }
                }
            }
            foreach (CRepertoire child in rep.GetChilds<CRepertoire>())
            {
                result = ImportRep(projetNominal, projetCandidat, child, strPathGed);
                if (!result)
                    return result;
            }

            return result;
        }
    }
}
