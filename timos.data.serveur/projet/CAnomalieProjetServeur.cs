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
	public class CAnomalieProjetServeur : CObjetServeur
    {
        //-------------------------------------------------------------------
#if PDA
		public CProjetServeur()
			:base()
		{
		}
#endif
        //-------------------------------------------------------------------
		public CAnomalieProjetServeur(int nIdSession)
            : base(nIdSession)
        {
        }
        //-------------------------------------------------------------------
        public override string GetNomTable()
        {
			return CAnomalieProjet.c_nomTable;
        }
        //-------------------------------------------------------------------
        public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
        {
            CResultAErreur result = CResultAErreur.True;
            try
            {
				CAnomalieProjet anomalie = (CAnomalieProjet)objet;


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
			return typeof(CAnomalieProjet);
        }
    }
}
