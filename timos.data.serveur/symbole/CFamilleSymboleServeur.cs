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
    /// Description résumée de CFamilleSymboleServeur
    /// </summary>
    public class CFamilleSymboleServeur : CObjetHierarchiqueServeur
    {
        //-------------------------------------------------------------------
        public CFamilleSymboleServeur(int nIdSession)
            : base(nIdSession)
        {
        }

        //-------------------------------------------------------------------
        public override string GetNomTable()
        {
            return CFamilleSymbole.c_nomTable;
        }

        //-------------------------------------------------------------------
        public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
        {
            CResultAErreur result = CResultAErreur.True;

            try
            {
                CFamilleSymbole qualifappel = (CFamilleSymbole)objet;

                if (qualifappel.Libelle == "")
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
            return typeof(CFamilleSymbole);
        }
        //-------------------------------------------------------------------
    }
}
