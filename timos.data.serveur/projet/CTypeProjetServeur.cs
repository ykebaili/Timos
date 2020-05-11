using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;

using timos.securite;

namespace timos.data
{
    /// <summary>
    /// Description résumée de CProjetServeur.
    /// </summary>
    public class CTypeProjetServeur : CObjetServeurAvecBlob
    {
        //-------------------------------------------------------------------
#if PDA
		public CProjetServeur()
			:base()
		{
		}
#endif
        //-------------------------------------------------------------------
		public CTypeProjetServeur(int nIdSession)
            : base(nIdSession)
        {
        }
        //-------------------------------------------------------------------
        public override string GetNomTable()
        {
			return CTypeProjet.c_nomTable;
        }
        //-------------------------------------------------------------------
        public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
        {
            CResultAErreur result = CResultAErreur.True;
            try
            {
				CTypeProjet typeProj = (CTypeProjet)objet;
				if (typeProj.Libelle == null || typeProj.Libelle == "")
					result.EmpileErreur(I.T( "The Project Type label cannot be empty|448"));
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
			return typeof(CTypeProjet);
        }
    }
}
