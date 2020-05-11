using System;
using System.Collections.Generic;
using System.Text;
using sc2i.common;

namespace timos.data.reseau.graphe
{
    //Permet de stocker les graphes réseau calculés
    public class CBaseGraphesReseau
    {
        private class CIdGraphe : IEquatable<CIdGraphe>
        {
            public readonly int IdSchema;
            public readonly ESensAllerRetourLienReseau? Sens;
 
            public CIdGraphe ( int nIdSchema, ESensAllerRetourLienReseau ?sens )
            {
                IdSchema = nIdSchema;
                Sens = sens;
            }

            public override int GetHashCode()
            {
                if (Sens == null)
                    return -IdSchema;
                if (Sens == ESensAllerRetourLienReseau.Backward)
                    return 1000000 + IdSchema;
                return IdSchema;
            }
             

             #region IEquatable<CIdGraphe> Membres

             public bool Equals(CIdGraphe other)
             {
                 return IdSchema == other.IdSchema && Sens == other.Sens;
             }

             #endregion
         }

        private Dictionary<CIdGraphe, CGrapheReseau> m_dicGraphes = new Dictionary<CIdGraphe, CGrapheReseau>();

        public void AddGrapheReseau(int nIdSchema, ESensAllerRetourLienReseau? sens, CGrapheReseau graphe)
        {
            m_dicGraphes[new CIdGraphe ( nIdSchema, sens)] = graphe;

        }

        public CGrapheReseau GetGrapheExistant(CSchemaReseau schema, ESensAllerRetourLienReseau? sens)
        {
            CGrapheReseau graphe = null;
            m_dicGraphes.TryGetValue(new CIdGraphe(schema.Id, sens), out graphe);
            return graphe;
        }

        public void RemoveGraphe(CSchemaReseau schema, ESensAllerRetourLienReseau? sens)
        {
            CIdGraphe id = new CIdGraphe(schema.Id, sens);
            if (m_dicGraphes.ContainsKey(id))
                m_dicGraphes.Remove(id);
        } 
 
    }
}
