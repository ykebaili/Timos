using System;
using System.Collections.Generic;
using System.Text;
using sc2i.drawing;
using sc2i.common;
using sc2i.data;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace timos.data
{
    /// <summary>
    /// Représente un schéma réseau et tous les éléments qui le composent
    /// </summary>
    [Serializable]
    public class C2iSchemaReseau : C2iObjetDeSchema
    {
        private List<C2iObjetDeSchema> m_listeSousObjets = new List<C2iObjetDeSchema>();
        private CSchemaReseau m_schema;

        /// <summary>
        /// Sert à allouer les ids aux nouveaux fils de ce schéma
        /// </summary>
        private int m_nNextIdObjetDeSchema = -1;

        //---------------------------------------------------
        public C2iSchemaReseau()
        {
        }

        //---------------------------------------------------
        public C2iSchemaReseau(CSchemaReseau schema)
        {
            m_schema = schema;
        }

        //---------------------------------------------------
        public CSchemaReseau Schema
        {
            get
            {
                return m_schema;
            }
        }

        //---------------------------------------------------
        public void ClearDrawingCache()
        {
            foreach (I2iObjetGraphique objet in Childs)
            {
                C2iObjetDeSchema o = objet as C2iObjetDeSchema;
                if (o != null)
                    o.ClearDrawingCache();
            }
        }

        //---------------------------------------------------
        public override bool AcceptChilds
        {
            get
            {
                return true;
            }
        }

        //---------------------------------------------------
        protected override Size ClientSize
        {
            get
            {
                Size sz = base.ClientSize;
                sz = new Size(sz.Width - 2, sz.Height - 2);
                return sz;
            }
        }

        //---------------------------------------------------
        protected override Point OrigineCliente
        {
            get
            {
                return new Point(1, 1);
            }
        }

        //---------------------------------------------------
        /// <summary>
        /// Alloue un nouvel ID pour un objet fils
        /// </summary>
        /// <returns></returns>
        private int AlloueNextIdObjet()
        {
            if (m_nNextIdObjetDeSchema < 0)
            {
                m_nNextIdObjetDeSchema = 0;
                foreach (C2iObjetDeSchema fils in Childs)
                    m_nNextIdObjetDeSchema = Math.Max(m_nNextIdObjetDeSchema, fils.IdObjetDeSchema);
                
                if(m_nNextIdObjetDeSchema >0)
                    m_nNextIdObjetDeSchema++;
            }
            return m_nNextIdObjetDeSchema++;
        }

        //---------------------------------------------------
        /// <summary>
        /// force le recalcul du prochain id d'objet de schéma
        /// </summary>
        internal void ResetNextIdObjetDeSchema()
        {
            m_nNextIdObjetDeSchema = -1;
        }

        //---------------------------------------------------
        public void VerifieUniciteIds()
        {
            Dictionary<int, List<C2iObjetDeSchema>> objetsParId = new Dictionary<int, List<C2iObjetDeSchema>>();
            objetsParId[IdObjetDeSchema] = new List<C2iObjetDeSchema>();
            objetsParId[IdObjetDeSchema].Add(this);
            int nId = 0;
            foreach (C2iObjetDeSchema objet in Childs)
            {
                List<C2iObjetDeSchema> lst = null;
                if (!objetsParId.TryGetValue(objet.IdObjetDeSchema, out lst))
                {
                    lst = new List<C2iObjetDeSchema>();
                    objetsParId[objet.IdObjetDeSchema] = lst;
                }
                lst.Add(objet);
                nId = Math.Max(objet.IdObjetDeSchema, nId);
            }
            nId++;
            foreach (KeyValuePair<int, List<C2iObjetDeSchema>> kv in objetsParId)
            {
                if (kv.Value.Count > 1)
                {
                    for (int n = 1; n < kv.Value.Count; n++)
                    {
                        kv.Value[n].IdObjetDeSchema = nId++;
                    }
                }
            }
            ResetNextIdObjetDeSchema();
        }


        
        //---------------------------------------------------
        public override bool AddChild(I2iObjetGraphique child)
        {
            C2iObjetDeSchema obj = child as C2iObjetDeSchema;
            if (obj != null && !m_listeSousObjets.Contains ( obj ))
            {
                m_listeSousObjets.Add(obj);
                obj.IdObjetDeSchema = AlloueNextIdObjet();
                return true;
            }
            return false;
        }


        //---------------------------------------------------
        public override void BringToFront(I2iObjetGraphique child)
        {
            C2iObjetDeSchema obj = child as C2iObjetDeSchema;
            if (m_listeSousObjets.Contains(obj))
            {
                m_listeSousObjets.Remove(obj);
                m_listeSousObjets.Add(obj);
            }
        }

        //---------------------------------------------------
        public override I2iObjetGraphique[] Childs
        {
            get
            {
                return m_listeSousObjets.ToArray();
            }
        }

        //---------------------------------------------------
        public override bool ContainsChild(I2iObjetGraphique child)
        {
            C2iObjetDeSchema obj = child as C2iObjetDeSchema;
            return m_listeSousObjets.Contains ( obj );
        }

        //---------------------------------------------------
        public override void FrontToBack(I2iObjetGraphique child)
        {
            C2iObjetDeSchema obj = child as C2iObjetDeSchema;
            if ( m_listeSousObjets.Contains ( obj ) )
            {
                m_listeSousObjets.Remove ( obj );
                m_listeSousObjets.Insert ( 0, obj );
            }
        }

        //---------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //---------------------------------------------------
        protected override sc2i.common.CResultAErreur MySerialize(sc2i.common.C2iSerializer serializer)
        {
            int nVersion = this.GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion ( ref nVersion );
            if ( !result )
                return result;
            result = base.MySerialize(serializer);
            if (!result)
                return result;
            return result;
        }

        //---------------------------------------------------
        public override void RemoveChild(I2iObjetGraphique child)
        {
            C2iObjetDeSchema obj = child as C2iObjetDeSchema;
            m_listeSousObjets.Remove ( obj );
        }

        //---------------------------------------------------
        public override void DeleteChild ( I2iObjetGraphique child )
        {
            C2iObjetDeSchema objDeSchema = child as C2iObjetDeSchema;
            if ( objDeSchema != null && objDeSchema.ElementDeSchema != null && objDeSchema.ElementDeSchema.IsValide() )
            {
                C2iSchemaReseauDansSchemaReseau schemaFilsAsupprimer = objDeSchema as C2iSchemaReseauDansSchemaReseau;
                if (schemaFilsAsupprimer != null)
                {
                    if(schemaFilsAsupprimer.ElementDeSchema!=null)
                    {
                        if (schemaFilsAsupprimer.ElementDeSchema.SchemaReseauInclus != null)
                        {
                            if(schemaFilsAsupprimer.ElementDeSchema.SchemaReseauInclus.SchemaParent == objDeSchema.ElementDeSchema.SchemaReseau)
                            {
                                objDeSchema.ElementDeSchema.DeleteObjetLie(true);
                            }

                        }
                    }
                }                
                
                if ( !objDeSchema.ElementDeSchema.Delete(true) )
                    return;
            }

            foreach (I2iObjetGraphique fils in Childs)
            {
                C2iEtiquetteSchema etiq = fils as C2iEtiquetteSchema;
                if (etiq != null)
                {
                    if (etiq.ObjetSchemaAssocie == child)
                        DeleteChild(etiq);
                }

            }
            base.DeleteChild ( child );
        }



        public C2iObjetDeSchema GetObjetFromPoint(Point pt)
        {
           
            foreach (I2iObjetGraphique child in Childs)
            {
                C2iObjetDeSchema objet = child as C2iObjetDeSchema;
                if ((objet != null) && (child.RectangleAbsolu.Contains(pt.X, pt.Y)))
                    return objet;
            }
            return null;
        }


        public C2iObjetDeSchema GetChildFromId(int id)
        {
            foreach (I2iObjetGraphique child in Childs)
            {
                C2iObjetDeSchema objet = child as C2iObjetDeSchema;
                if (objet != null)
                {
                    if (objet.IdObjetDeSchema == id)
                        return objet;
                }
            }
            return null;



        }

        //---------------------------------------------------
        protected override void MyDraw(CContextDessinObjetGraphique ctx)
        {
            Rectangle rct = new Rectangle ( Position.X, Position.Y, Size.Width, Size.Height );
            ctx.Graphic.FillRectangle ( Brushes.White, rct );
            ctx.Graphic.DrawRectangle(Pens.Black, rct);

        }

        //---------------------------------------------------
        //S'arrange pour que les liaisons ne se chevauchent pas
        public void ArrangerLiaisons()
        {
            foreach (C2iObjetDeSchema obj in Childs)
            {
                C2iLienDeSchemaReseau lien = obj as C2iLienDeSchemaReseau;
                if (lien != null && !typeof(C2iLienDeSchemaReseauNoDelete).IsAssignableFrom(lien.GetType()))
                    ArrangerLien(lien);
            }
        }

        public void ArrangerLien ( C2iLienDeSchemaReseau lien )
        {
            if (lien.Points.Length != 2)
                return;
            C2iObjetDeSchema parent = lien.Parent as C2iObjetDeSchema;
            
            if (parent == null)
                return;
            foreach (C2iObjetDeSchema objetDeSchema in parent.Childs)
            {
                C2iLienDeSchemaReseau lien2 = objetDeSchema as C2iLienDeSchemaReseau;
                if (lien2 != null && lien2 != lien && lien2.Points.Length == 2 &&
                    lien2.PositionAbsolue == lien.PositionAbsolue &&
                    lien2.Size == lien.Size)
                {
                    //Les deux liens se chevauchent : Ajoute un point intermédiaire
                    Point ptMilieu = new Point((lien.Points[0].X + lien.Points[1].X) / 2,
                        (lien.Points[0].Y + lien.Points[1].Y) / 2);
                    if (lien.Points[0].Y == lien.Points[1].Y)
                        ptMilieu.Offset(00, 20);
                    else
                    {
                        double fPente = -((lien.Points[0].X - lien.Points[1].X) / (lien.Points[0].Y - lien.Points[1].Y));
                        double fX = 20 / (Math.Sqrt(1 + fPente * fPente));
                        double fY = fPente * fX;
                        ptMilieu.Offset((int)fX, (int)fY);
                        Point[] pts = new Point[]
                        {
                            lien.Points[0],
                            ptMilieu,
                            lien.Points[1]
                        };
                        lien.Points = pts;
                    }
                }
            }
        }

        public override CSchemaReseau SchemaContenant
        {
            get
            {
                return Schema;
            }
        }
    }
}
