using System;
using System.Collections.Generic;
using System.Text;
using sc2i.expression;
using sc2i.common;
using sc2i.formulaire;

namespace timos.data.workflow.ConsultationHierarchique
{
    [Serializable]
    [AutoExec("Autoexec")]
    public class CDefinitionProprieteDynamiqueFolderHierarchiqueParent : CDefinitionProprieteDynamiqueDeportee
    {
        private static string c_strCleType = "PRFLHI";

        public const string c_strProprieteFolderParent = "Parent folder";

        private CFolderConsultationHierarchique m_folder = null;

        //--------------------------------------------------------
        public CDefinitionProprieteDynamiqueFolderHierarchiqueParent()
        {
        }

        //--------------------------------------------------------
        public CDefinitionProprieteDynamiqueFolderHierarchiqueParent(CFolderConsultationHierarchique folderParent)
            : base(
            folderParent.Libelle,
            c_strProprieteFolderParent,
            new CTypeResultatExpression ( typeof(CNodeConsultationHierarchique), false),
            true,
            true,
            "")
        {
            m_folder = folderParent;
        }

        //--------------------------------------------------------
        public static new void Autoexec()
        {
            CInterpreteurProprieteDynamique.RegisterTypeDefinition(c_strCleType, typeof(CInterpreteurProprieteDynamiqueFolderHierarchiqueParent));
        }

        //--------------------------------------------------------
        public override string CleType
        {
            get
            {
                return c_strCleType;
            }
        }

        //------------------------------------------------
        public override CObjetPourSousProprietes GetObjetPourAnalyseSousProprietes()
        {
            if (m_folder != null)
                return new CObjetPourSousProprietes(m_folder);
            return base.GetObjetPourAnalyseSousProprietes();
        }

        //------------------------------------------------
        public override void CopyTo(CDefinitionProprieteDynamique def)
        {
            base.CopyTo(def);
            CDefinitionProprieteDynamiqueFolderHierarchiqueParent defInstance = def as CDefinitionProprieteDynamiqueFolderHierarchiqueParent;
            if (defInstance != null)
                defInstance.m_folder = m_folder;
        }
    }

    //--------------------------------------------------------
    public class CInterpreteurProprieteDynamiqueFolderHierarchiqueParent : IInterpreteurProprieteDynamique
    {
        public CResultAErreur GetValue(object objet, string strPropriete)
        {
            CResultAErreur result = CResultAErreur.True;
            CNodeConsultationHierarchique node = objet as CNodeConsultationHierarchique;
            if (node != null)
                result.Data = node.NodeParent;
            return result;
        }

        public CResultAErreur SetValue(object objet, string strPropriete, object valeur)
        {
            return CResultAErreur.True;
        }

        public bool ShouldIgnoreForSetValue(string strPropriete)
        {
            return false;
        }

        public IOptimiseurGetValueDynamic GetOptimiseur(Type tp, string strPropriete)
        {
            return null;
        }
    }
}
