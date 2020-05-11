using System;
using System.Collections;
using System.Text;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;

using timos.data;

namespace timos.data.serveur
{
    /// <summary>
    /// Description résumée de CSymboleDeBibliothequeServeur
    /// </summary>
    public class CSymboleDeBibliothequeServeur : CObjetServeur
    {
        //-------------------------------------------------------------------
        public CSymboleDeBibliothequeServeur(int nIdSession)
            : base(nIdSession)
        {
        }

        //-------------------------------------------------------------------
        public override string GetNomTable()
        {
            return CSymboleDeBibliotheque.c_nomTable;
        }

        //-------------------------------------------------------------------
        public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
        {
            CResultAErreur result = CResultAErreur.True;

            try
            {
                CSymboleDeBibliotheque symbole = (CSymboleDeBibliotheque)objet;

                if (symbole.Libelle == "")
                    result.EmpileErreur(I.T("The label cannot be empty|126"));

            }
            catch (Exception e)
            {
                result.EmpileErreur(new CErreurException(e));
            }

            return result;
        }

        //-------------------------------------------------------------------
        public override Type GetTypeObjets()
        {
            return typeof(CSymboleDeBibliotheque);
        }
        //-------------------------------------------------------------------
    }
}
