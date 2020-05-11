using futurocom.snmp.HotelPolling;
using futurocom.snmp.polling;
using sc2i.common;
using sc2i.data;
using sc2i.data.dynamic;
using sc2i.expression;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using timos.snmp.polling;

namespace timos.data.snmp.polling
{
    //Configuration d'un champ de polling pour un type d'entité SNMP
    public class CSnmpPollingFieldSetup : I2iSerializable
    {
        private string m_strPollingFieldUId = "";

        private C2iExpression m_formulePolling = null;
        private C2iExpression m_formuleEntiteId = null;

        //-------------------------------------------------
        public CSnmpPollingFieldSetup()
        {

        }

        //-------------------------------------------------
        public string PollingFieldUID
        {
            get
            {
                if (m_strPollingFieldUId == null)
                    return "";
                return m_strPollingFieldUId;
            }
            set
            {
                if (value == null)
                    m_strPollingFieldUId = "";
                else
                    m_strPollingFieldUId = value;
            }
        }

        //-------------------------------------------------
        /// <summary>
        /// formule basée sur les champs du type d'entité SNMP.
        /// La formule n'est jamais évaluée telle quelle,
        /// elle est convertie et transmise dans la config de polling de chaque agent
        /// </summary>
        public C2iExpression FormulePolling
        {
            get
            {
                return m_formulePolling;
            }
            set
            {
                m_formulePolling = value;
            }
        }

        //-------------------------------------------------
        public C2iExpression FormuleIdEntite
        {
            get
            {
                return m_formuleEntiteId;
            }
            set 
            {
                m_formuleEntiteId = value; 
            }
        }

        //-------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }
        
        //-------------------------------------------------
        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            serializer.TraiteString(ref m_strPollingFieldUId);
            result = serializer.TraiteObject<C2iExpression>(ref m_formulePolling);
            if (result)
                result = serializer.TraiteObject<C2iExpression>(ref m_formuleEntiteId);
            if (!result)
                return result;
            return result;
        }

        //-------------------------------------------------
        public CResultAErreurType<CSnmpHotelPolledData> GetHotelPolledData ( CEntiteSnmp entite )
        {
            CResultAErreurType<CSnmpHotelPolledData> result = new CResultAErreurType<CSnmpHotelPolledData>();

            //trouve le champ
            CSnmpPollingField field = new CSnmpPollingField(entite.ContexteDonnee);
            if ( !field.ReadIfExistsUniversalId(PollingFieldUID) ||
                field.HotelTableId.Length == 0 ||
                field.HotelColumnId.Length == 0 )
            {
                result.EmpileErreur(I.T("Incorrect polling field|20256"));
                return result;
            }
            CSnmpHotelPolledData polledData = new CSnmpHotelPolledData();
            polledData.HotelTable = field.HotelTableId;
            polledData.HotelField = field.HotelColumnId;

            //calcule l'id de l'entité
            CContexteEvaluationExpression ctx = new CContexteEvaluationExpression(entite);
            if (FormuleIdEntite == null)
            {
                result.EmpileErreur(I.T("Invalid entity id formula|20257"));
                return result;
            }
            CResultAErreur resTmp = FormuleIdEntite.Eval(ctx);
            if ( !resTmp || resTmp.Data == null)
            {
                result.EmpileErreur(I.T("Invalid entity id formula|20257"));
                result.EmpileErreur(resTmp.Erreur);
                return result;
            }
            polledData.EntityId = resTmp.Data.ToString();

            CResultAErreurType<C2iExpression> resFormule = GetFormuleFinaleForEntite(entite);
            if ( !resFormule || !(resFormule.Data is C2iExpression))
            {
                result.EmpileErreur(I.T("Error while converting Polling formula|20258"));
                return result;
            }
            polledData.Formule = resFormule.DataType;
            result.DataType = polledData;
            return result;
        }

        //-------------------------------------------------
        private CResultAErreurType<C2iExpression> GetFormuleFinaleForEntite ( CEntiteSnmp entite )
        {
            CResultAErreurType<C2iExpression> result = new CResultAErreurType<C2iExpression>();
            if ( m_formulePolling == null )
            {
                result.EmpileErreur(I.T("Can not apply formula to entity @1|20254",
                    entite.Libelle));
                return result;
            }
            C2iExpression formule = CCloner2iSerializable.Clone(m_formulePolling) as C2iExpression;
            ArrayList lst = formule.ExtractExpressionsType(typeof(C2iExpressionChamp));
            foreach ( C2iExpressionChamp exp in lst )
            {
                CDefinitionProprieteDynamiqueChampCustom def = exp.DefinitionPropriete as CDefinitionProprieteDynamiqueChampCustom;
                string strOID = null;
                if (def != null)
                {
                    CChampCustom champ = new CChampCustom(CContexteDonneeSysteme.GetInstance());
                    if ( champ.ReadIfExists(def.DbKeyChamp ))
                    {
                        strOID = entite.GetFieldOID(champ.Id);
                        if (strOID.Trim().Length == 0)
                            strOID = null;
                        else
                            exp.DefinitionPropriete = new CDefinitionProprieteDynamiqueOID(strOID);
                    }
                }
                if ( strOID == null )
                {
                    result.EmpileErreur(I.T("Can not find SNMP field for @1|20255", def.Nom));
                    return result;
                }
            }
            result.Data = formule;
            return result;
        }
    }
}
