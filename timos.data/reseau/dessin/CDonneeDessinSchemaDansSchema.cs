using System;
using System.Drawing;

using System.Drawing.Design;
using System.Drawing.Drawing2D;

using sc2i.common;
using sc2i.drawing;
using sc2i.formulaire;

using sc2i.expression;

namespace timos.data
{
    public class CDonneeDessinSchemaDansSchema : CDonneeDessinElementDeSchemaReseau
    {
        private EModeOperationnelSchema m_modeOperationnel = EModeOperationnelSchema.AutomaticRedundancy;

        public CDonneeDessinSchemaDansSchema(int nIdContexteDonnee)
            : base(nIdContexteDonnee)
        {
        }




        public virtual int GetNumVersion()
        {
            return 0;
        }

        public EModeOperationnelSchema ModeOperationnel
        {
            get
            {
                return m_modeOperationnel;
            }
            set
            {
                m_modeOperationnel = value;
            }
        }




        public override CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;

            int nMode = (int)ModeOperationnel;
            serializer.TraiteInt(ref nMode);
            ModeOperationnel = (EModeOperationnelSchema)nMode;

            return CResultAErreur.True;
        }

    }

}
