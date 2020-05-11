using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using sc2i.expression;
using futurocom.snmp.Mib;
using System.Net;
using System.Data;
using futurocom.snmp.dynamic;
using futurocom.easyquery;
using futurocom.easyquery.snmp;
using futurocom.snmp.entitesnmp;

namespace futurocom.snmp.dynamic
{
    [Serializable]
    public class CInterrogateurSnmp : CInterrogateurSnmpSimplePourFiller,
                IElementAVariableInstance,
                IElementARunnableEasyQueryDynamique

    {
        private List<CDefinitionProprieteDynamique> m_listeDefinitions = null;

        private List<IRunnableEasyQuery> m_listeEasyQueries = new List<IRunnableEasyQuery>();

        private CEasyQuerySource m_easyQuerySource = null;

        //------------------------------------------------------------------
        public CInterrogateurSnmp()
            :base()
        {
        }

        //------------------------------------------------------------------
        public CInterrogateurSnmp(IDefinition root)
            :base(root)
        {
        }

        

        //-------------------------------------------
        public static string CalcRubriqueChamp(IDefinition definition)
        {
            string strRubrique = "";
            IDefinition parent = definition.ParentDefinition;
            while (parent != null)
            {
                strRubrique = parent.Name + "/" + strRubrique;
                parent = parent.ParentDefinition;
            }
            return strRubrique;
        }

        //-------------------------------------------
        private void FillAllDefs(List<IDefinition> allDefs, IDefinition definition)
        {
            if (definition == null)
                return;
            foreach (IDefinition child in definition.Children)
            {
                allDefs.Add(child);
                FillAllDefs(allDefs, child);
            }
        }

        //------------------------------------------------------------------
        public CDefinitionProprieteDynamique[] GetProprietesInstance()
        {
            List<CDefinitionProprieteDynamique> lst = new List<CDefinitionProprieteDynamique>();
            if (m_listeDefinitions == null)
            {
                m_listeDefinitions = new List<CDefinitionProprieteDynamique>();
                if (m_rootDefinition != null)
                {
                    List<IDefinition> lstDefs = new List<IDefinition>();
                    FillAllDefs(lstDefs, m_rootDefinition);
                    foreach (IDefinition def in lstDefs)
                    {
                        CDefinitionProprieteDynamique defProp = null;
                        switch (def.Type)
                        {
                            case DefinitionType.Scalar:
                                defProp = new CDefinitionProprieteDynamiqueSNMPVariable(def);
                                break;
                            case DefinitionType.Table :
                                defProp = new CDefinitionProprieteDynamiqueSnmpTable(def);
                                break;
                        }
                        if (defProp != null)
                            m_listeDefinitions.Add(defProp);
                    }
                }
            }
            lst.AddRange(m_listeDefinitions);
            foreach (IRunnableEasyQuery query in Queries)
            {
                CDefinitionProprieteDynamiqueRunnableEasyQuery def = new CDefinitionProprieteDynamiqueRunnableEasyQuery(query);
                def.Rubrique = "Queries";
                lst.Add(def);
            }
            return lst.ToArray();
        }

        
        //---------------------------------------------------------------
        public CEasyQuerySource EasyQuerySource
        {
            get
            {
                if (m_easyQuerySource == null)
                {
                    m_easyQuerySource = new CEasyQuerySource();
                    m_easyQuerySource.Connexion = new CSnmpConnexionForEasyQuery(this);
                }
                return m_easyQuerySource;
            }
        }

        //---------------------------------------------------------------
        public IEnumerable<IRunnableEasyQuery> Queries
        {
            get
            {
                return m_listeEasyQueries.AsReadOnly();
            }
        }

        //---------------------------------------------------------------
        public void AddQuery(CEasyQuery query)
        {
            m_listeEasyQueries.Add(new CEasyQueryFromEasyQueryASourcesSpecifique(query, EasyQuerySource));
        }

            
        //---------------------------------------------------
        public IRunnableEasyQuery GetQuery(string strLibelle)
        {
            IRunnableEasyQuery query = m_listeEasyQueries.FirstOrDefault(q => q.Libelle == strLibelle);
            return query;
        }


        
    }
}
