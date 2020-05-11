using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;

using timos.acteurs;
using timos.securite;
using timos.data.projet.gantt;

namespace timos.data.serveur.projet.gantt
{
    /// <summary>
    /// Description résumée de CParametrageDessinGanttServeur.
    /// </summary>
    public class CParametrageDessinGanttServeur : CObjetServeurAvecBlob
    {
        //-------------------------------------------------------------------
#if PDA
		public CParametrageDessinGanttServeur()
			:base()
		{
		}
#endif
        //-------------------------------------------------------------------
        public CParametrageDessinGanttServeur(int nIdSession)
            : base(nIdSession)
        {
        }
        //-------------------------------------------------------------------
        public override string GetNomTable()
        {
            return CParametrageDessinGantt.c_nomTable;
        }
        //-------------------------------------------------------------------
        public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
        {
            CResultAErreur result = CResultAErreur.True;
            try
            {
                CParametrageDessinGantt parametre = (CParametrageDessinGantt)objet;

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
            return typeof(CParametrageDessinGantt);
        }

        
    }
}
