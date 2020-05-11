using System;
using System.Collections;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;
using System.Data;

namespace timos.data.snmp.serveur
{
    /// <summary>
    /// Description rÃ©sumÃ©e de CTypeAgentSnmpServeur.
    /// </summary>
    public class CTypeAgentSnmpServeur : CObjetServeurAvecBlob
    {
        //-------------------------------------------------------------------
#if PDA
		public CTypeAgentSnmpServeur()
			:base()
		{
		}
#endif
        //-------------------------------------------------------------------
        public CTypeAgentSnmpServeur(int nIdSession)
            : base(nIdSession)
        {
        }
        //-------------------------------------------------------------------
        public override string GetNomTable()
        {
            return CTypeAgentSnmp.c_nomTable;
        }
        //-------------------------------------------------------------------
        public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
        {
            CResultAErreur result = CResultAErreur.True;
            try
            {
                CTypeAgentSnmp TypeAgentSnmp = (CTypeAgentSnmp)objet;

                if (TypeAgentSnmp.Libelle == "")
                    result.EmpileErreur(I.T("Agent type label can not be empty|200145"));
                if (!CObjetDonneeAIdNumerique.IsUnique(TypeAgentSnmp, CTypeAgentSnmp.c_champLibelle, TypeAgentSnmp.Libelle))
                    result.EmpileErreur(I.T("An agent type with the same label already exists (@1)|20146", TypeAgentSnmp.Libelle));
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
            return typeof(CTypeAgentSnmp);
        }
        
    }
}
