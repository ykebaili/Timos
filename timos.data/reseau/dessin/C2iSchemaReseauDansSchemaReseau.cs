using System;
using System.Collections.Generic;
using System.Text;

namespace timos.data
{
    /// <summary>
    /// Représente un schéma de réseau inclu dans un autre schéma de réseau
    /// </summary>
    [Serializable]
    public class C2iSchemaReseauDansSchemaReseau : C2iObjetDeSchema
    {
        protected override IDonneeDessinElementDeSchemaReseau AlloueDonneeDessin()
        {
            return new CDonneeDessinSchemaDansSchema(-1);
        }

        public CDonneeDessinSchemaDansSchema DonneeDessinSchemaDansSchema
        {
            get
            {
                return DonneeDessin as CDonneeDessinSchemaDansSchema;
            }
        }

        public EModeOperationnelSchema OperationnalMode
        {
            get
            {
                return DonneeDessinSchemaDansSchema.ModeOperationnel;
            }
            set
            {
                DonneeDessinSchemaDansSchema.ModeOperationnel = value;
            }
        }
    }
}
