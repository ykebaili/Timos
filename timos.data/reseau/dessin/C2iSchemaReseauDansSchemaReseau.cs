using System;
using System.Collections.Generic;
using System.Text;

namespace timos.data
{
    /// <summary>
    /// Repr�sente un sch�ma de r�seau inclu dans un autre sch�ma de r�seau
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
