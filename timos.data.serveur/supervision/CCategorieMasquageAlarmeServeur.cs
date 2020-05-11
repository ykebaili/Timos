using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;

using timos.acteurs;
using timos.securite;
using timos.data.supervision;

namespace timos.data.serveur.supervision
{
    /// <summary>
    /// Description résumée de CCategorieMasquageAlarmes.
    /// </summary>
    public class CCategorieMasquageAlarmeServeur : CObjetServeurAvecBlob
    {
        //-------------------------------------------------------------------
#if PDA
		public CCategorieMasquageAlarmes()
			:base()
		{
		}
#endif
        //-------------------------------------------------------------------
        public CCategorieMasquageAlarmeServeur(int nIdSession)
            : base(nIdSession)
        {
        }

        //-------------------------------------------------------------------
        public override string GetNomTable()
        {
            return CCategorieMasquageAlarme.c_nomTable;
        }

        //-------------------------------------------------------------------
        public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
        {
            CResultAErreur result = CResultAErreur.True;
            try
            {
                CCategorieMasquageAlarme parametre = (CCategorieMasquageAlarme)objet;
                if (parametre.Libelle == string.Empty)
                    result.EmpileErreur(I.T("The Label cannot be empty|181"));

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
            return typeof(CCategorieMasquageAlarme);
        }

        
    }
}
