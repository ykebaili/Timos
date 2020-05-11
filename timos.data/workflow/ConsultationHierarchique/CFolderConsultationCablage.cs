using System;
using System.Collections.Generic;
using System.Text;
using sc2i.common;
using sc2i.expression;
using sc2i.data;
using System.Collections;
using System.Linq;

namespace timos.data.workflow.ConsultationHierarchique
{

	[Serializable]
	public class CFolderConsultationCablage : CFolderConsultationHierarchique
	{

        private CSchemaReseau m_schemaCablage = null;

        public CFolderConsultationCablage(CFolderConsultationHierarchique folderParent)
			: base(folderParent)
		{
            this.Image = timos.data.Resource.wiring;
		}

		private int GetNumVersion()
		{
			return 0;
		}

		public override sc2i.common.CResultAErreur Serialize(sc2i.common.C2iSerializer serializer)
		{
			int nVersion = GetNumVersion();
			CResultAErreur result = serializer.TraiteVersion(ref nVersion);
			if (!result)
				return result;
			result = base.Serialize(serializer);
			if (!result)
				return result;

            return result;
		}

        public CSchemaReseau SchemaCablage 
        {
            get
            {
                return m_schemaCablage;
            }
            set
            {
                m_schemaCablage = value;
            }
        }


        //---------------------------------------------
		public override object[] GetObjets(CNodeConsultationHierarchique nodeParent, sc2i.data.CContexteDonnee contexteDonnee)
		{
            List<CSchemaReseau> lstCablages = new List<CSchemaReseau>();

            CSite site = m_schemaCablage.SiteApparenance;
            if (site != null)
            {
                CSchemaReseau schemaParent = m_schemaCablage.SchemaParent;
                if (schemaParent != null)
                {

                    IEnumerable<CLienReseau> lstLiens = 
                        from elt in schemaParent.GetElementsForType<CLienReseau>()
                        where elt.LienReseau.Site1 == site || elt.LienReseau.Site2 == site
                        select elt.LienReseau;
                    
                    foreach (CLienReseau lien in lstLiens)
                    {
                        CSchemaReseau schema = lien.SchemaReseau;
                        if(schema != null)
                        {
                            foreach (CSchemaReseau sche in schema.SchemaFils)
                            {
                                if (sche.SiteApparenance == site)
                                    lstCablages.Add(sche);
                            }
                        }
                    }

                }
            }

            return lstCablages.ToArray();
        }

        //---------------------------------------------
        public override Type TypeElements
        {
            get
            {
                return typeof(CSchemaReseau);
            }
        }

        public override string GetLibelleNode(object source)
        {
            CNodeConsultationHierarchique node = source as CNodeConsultationHierarchique;
            CSchemaReseau schema = node.ObjetLie as CSchemaReseau;
            if (schema != null)
                return schema.Libelle;

            return "???";

        }


        public override string FolderTypeName
        {
            get { return I.T("Wiring|10006"); }
        }
	}
}
