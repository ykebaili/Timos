using System;
using System.Collections.Generic;
using System.Text;
using sc2i.expression;
using sc2i.formulaire;

namespace timos.data.workflow.ConsultationHierarchique
{
    public class CNodeConsultationHierarchique : IElementAProprietesDynamiquesDeportees
    {
        private object m_objet = null;

        private CNodeConsultationHierarchique m_nodeParent = null;

        private CFolderConsultationHierarchique m_folder = null;

        public CNodeConsultationHierarchique(
            object obj, 
            CFolderConsultationHierarchique folder,
            CNodeConsultationHierarchique nodeParent)
        {
            m_objet = obj;
            m_nodeParent = nodeParent;
            m_folder = folder;
        }

        //---------------------------------------
        public CFolderConsultationHierarchique Folder
        {
            get
            {
                return m_folder;
            }
        }

        //---------------------------------------
        public object ObjetLie
        {
            get
            {
                return m_objet;
            }
        }

        //---------------------------------------
        public CNodeConsultationHierarchique NodeParent
        {
            get
            {
                return m_nodeParent;
            }
        }

        //---------------------------------------
        public object GetValeurDynamiqueDeportee(string strPropriete)
        {
            if ( strPropriete == CFolderConsultationFolder.c_strProprieteValue )
            {
                return ObjetLie;
            }
            if ( strPropriete == CDefinitionProprieteDynamiqueFolderHierarchiqueParent.c_strProprieteFolderParent )
                return m_nodeParent;
            return null;
        }

        public void SetValeurDynamiqueDeportee(string strPropriete, object valeur)
        {
            //Non implémenté, lecture seule
        }

    }
}
