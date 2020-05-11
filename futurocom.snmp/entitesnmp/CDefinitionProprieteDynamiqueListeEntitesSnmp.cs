using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.expression;
using sc2i.common;
using System.Collections;

namespace futurocom.snmp.entitesnmp
{
    [Serializable]
    public class CDefinitionProprieteDynamiqueListeEntitesSnmp : CDefinitionProprieteDynamique
    {
        public const string c_cleType = "LSETTSNMP";

        //-------------------------------------------------------
        public CDefinitionProprieteDynamiqueListeEntitesSnmp()
        {
        }

        //-------------------------------------------------------
        public CDefinitionProprieteDynamiqueListeEntitesSnmp(CTypeEntiteSnmpPourSupervision typeEntite)
            : base("ListOf_"+typeEntite.Libelle, typeEntite.Id,
                new CTypeResultatExpression (typeof(CEntiteSnmpPourSupervision), true),
                true,
                true)
        {
        }

        //-------------------------------------------------------
        public override string CleType
        {
            get
            {
                return c_cleType;
            }
        }
    }

    //-------------------------------------------------------
    [AutoExec("Autoexec")]
    public class CIntepreteurProprieteDynamiqueListeEntitesSnmp : IInterpreteurProprieteDynamique
    {
        public static void Autoexec()
        {
            CInterpreteurProprieteDynamique.RegisterTypeDefinition(CDefinitionProprieteDynamiqueListeEntitesSnmp.c_cleType, typeof(CIntepreteurProprieteDynamiqueListeEntitesSnmp));
        }

        public CResultAErreur GetValue(object objet, string strPropriete)
        {
            CResultAErreur result = CResultAErreur.True;
            CAgentSnmpPourSupervision agentSNMP = objet as CAgentSnmpPourSupervision;
            if (agentSNMP != null)
            {
                CListeEntitesSnmp lst = new CListeEntitesSnmp();
                CTypeEntiteSnmpPourSupervision typeEntite = new CTypeEntiteSnmpPourSupervision(agentSNMP.Database);
                if (typeEntite.ReadIfExist(strPropriete))
                {
                    foreach (CEntiteSnmpPourSupervision entite in agentSNMP.GetEntites(typeEntite))
                    {
                        lst.Add(entite);
                    }
                }
                result.Data = lst;
            }
            return result;

        }

        public CResultAErreur SetValue(object objet, string strPropriete, object valeur)
        {
            CResultAErreur result = CResultAErreur.True;
            
            return result;
        }

        public bool ShouldIgnoreForSetValue(string strPropriete)
        {
            return true;
        }

        public IOptimiseurGetValueDynamic GetOptimiseur(Type tp, string strPropriete)
        {
            return null;
        }

    }

}
