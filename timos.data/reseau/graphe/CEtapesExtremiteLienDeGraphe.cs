using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace timos.data.reseau.graphe
{
    public class CEtapesExtremiteLienDeGraphe
    {
        //Du schéma d'appartenance du lien au schéma de son extremité
        private List<int> m_listeIdsSchemas = new List<int>();

        public CEtapesExtremiteLienDeGraphe()
        {
        }

        public CEtapesExtremiteLienDeGraphe(CCheminLienReseau chemin)
        {
            m_listeIdsSchemas = new List<int>();
            while (chemin != null)
            {
                if (chemin.SchemaReseauUtilise != null)
                    m_listeIdsSchemas.Add(chemin.SchemaReseauUtilise.Id);
                chemin = chemin.CheminFils;
            }
        }

        public int[] IdsSchemas
        {
            get
            {
                return m_listeIdsSchemas.ToArray();
            }
        }
    }
}
