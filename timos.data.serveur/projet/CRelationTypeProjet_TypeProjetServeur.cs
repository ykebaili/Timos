using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;

using timos.securite;
using System.Collections.Generic;

namespace timos.data
{
    /// <summary>
    /// Description r�sum�e de CRelationTypeProjet_TypeProjetServeur.
    /// </summary>
    public class CRelationTypeProjet_TypeProjetServeur : CObjetServeur
    {
        //-------------------------------------------------------------------
#if PDA
		public CRelationTypeProjet_TypeProjetServeur()
			:base()
		{
		}
#endif
        //-------------------------------------------------------------------
        public CRelationTypeProjet_TypeProjetServeur(int nIdSession)
            : base(nIdSession)
        {
        }
        //-------------------------------------------------------------------
        public override string GetNomTable()
        {
            return CRelationTypeProjet_TypeProjet.c_nomTable;
        }
        //-------------------------------------------------------------------
        public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
        {
            CResultAErreur result = CResultAErreur.True;
            try
            {
                
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
            return typeof(CRelationTypeProjet_TypeProjet);
        }

        
    }
}
