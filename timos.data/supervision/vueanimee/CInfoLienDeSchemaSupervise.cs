using System;
using System.Collections.Generic;
using System.Text;
using timos.data;
using sc2i.drawing;
using System.Drawing;
using sc2i.data;
using System.Collections;
using timos.data.reseau.arbre_operationnel;
using sc2i.common;

namespace timos.data.supervision.vueanimee
{
    public class CInfoLienDeSchemaSupervise : CInfoElementDeSchemaSupervise
    {
        private CDbKey m_dbKeyLien;
        private bool m_bIsOperationnel = true;

        public CInfoLienDeSchemaSupervise(
            CInfoElementDeSchemaSupervise parent,
            CElementDeSchemaReseau eltDeSchema,
            CBasePourVueAnimee basePourVue,
            int nNiveauProfondeur)
            :base ( parent, eltDeSchema, basePourVue, nNiveauProfondeur )
        {
        }

        internal override void InitFromElementDeSchema(CElementDeSchemaReseau elementDeSchema)
        {
            base.InitFromElementDeSchema(elementDeSchema);
            CLienReseau lien = elementDeSchema.LienReseau;
            if (lien == null)
                throw new Exception("Bad element for supervision data ");
            m_dbKeyLien = lien.DbKey;

            CSchemaReseau schemaDeLiaison = lien.SchemaReseau;
            if (schemaDeLiaison != null)
            {
                CInfoSchemaDeSchemaSupervise info = new CInfoSchemaDeSchemaSupervise(this, null, m_base, NiveauProfondeur+1);
                m_listeFils.Add(info);
                info.InitFromSchema(schemaDeLiaison);
            }

            //Si pas de schéma ou que le schéma ne contient pas les sites
            bool bHasElement1 = false;
            bool bHasElement2 = false;
            IElementALiensReseau elt1 = lien.Element1;
            IElementALiensReseau elt2 = lien.Element2;
            if (schemaDeLiaison != null)
            {
                foreach ( CElementDeSchemaReseau elt in schemaDeLiaison.ElementsDeSchema )
                {
                    IElementALiensReseau eltAssocie = elt.ElementAssocie as IElementALiensReseau;
                    if ( eltAssocie != null && eltAssocie.Equals ( elt1 ) )
                        bHasElement1 = true;
                    if ( eltAssocie != null && eltAssocie.Equals ( elt2 ) )
                        bHasElement2 = true;
                    if (bHasElement1 && bHasElement2)
                        break;
                }
            }
            IElementALiensReseau extremite = lien.Element1;
            if (extremite is CSite)
                m_dicSitesConcernant[extremite.DbKey] = true;
            if (extremite is CEquipementLogique)
                m_dicEquipementsConcernant[extremite.DbKey] = true;
            extremite = lien.Element2;
            if (extremite is CSite)
                m_dicSitesConcernant[extremite.DbKey] = true;
            if (extremite is CEquipement)
                m_dicEquipementsConcernant[extremite.DbKey] = true;
            m_dicLiaisonsConcernant[lien.DbKey] = true;
        }


        public CDbKey IdLien
        {
            get
            {
                return m_dbKeyLien;
            }
        }


        //---------------------------------------------------------------------------------------------
        protected override void RecalculeGraviteEtMasquage()
        {
            //bool bOldOperationnel = m_bIsOperationnel;

            EEtatOperationnelSchema oldEtat = EtatOperationnel;
            try
            {
                base.RecalculeGraviteEtMasquage();
                //Normallement, il n'y a qu'un fils !
                m_bIsOperationnel = true;
                foreach (CInfoElementDeSchemaSupervise infoFils in m_listeFils)
                {
                    CInfoSchemaDeSchemaSupervise infoSchema = infoFils as CInfoSchemaDeSchemaSupervise;
                    if (infoSchema != null && EtatOperationnel > infoSchema.EtatOperationnel)
                    {
                        EtatOperationnel = infoSchema.EtatOperationnel;
                    }
                }
            }
            finally
            {
                if (EtatOperationnel != oldEtat)
                    m_base.OnChangementEtatSupervise(this);
            }
        }


        public override void FillDicNoeudArbreRacineToInfoElement(
            Dictionary<CElementDeArbreOperationnel, CInfoElementDeSchemaSupervise> dicNoeudArbreRacineToInfoElement)
        {
            //base.FillDicNoeudArbreRacineToInfoElement(dicNoeudArbreRacineToInfoElement);
            

            foreach (CInfoElementDeSchemaSupervise infoFils in m_listeFils)
            {
                CInfoSchemaDeSchemaSupervise infoSchema = infoFils as CInfoSchemaDeSchemaSupervise;
                if (infoSchema != null)
                {
                    if (!dicNoeudArbreRacineToInfoElement.ContainsKey(infoSchema.ArbreAller.ElementRacine))
                    {
                        dicNoeudArbreRacineToInfoElement.Add(infoSchema.ArbreAller.ElementRacine, this);
                    }
                    
                }
            }
        }

        //---------------------------------------------------------------------------------------------
        public override void BeforeDrawObjet(CContextDessinObjetGraphique ctx, C2iObjetDeSchema objet)
        {
            if (!IsConcerneParAlarme)
                return;
            C2iLienDeSchemaReseau dessinLien = objet as C2iLienDeSchemaReseau;
            Color couleur = SeveriteAlarme != null ? SeveriteAlarme.Couleur : Color.White; 
            Pen pen = new Pen(couleur, 3);
            Point[] pts = dessinLien.Points;
            for (int nPoint = 0; nPoint <= pts.Length - 2; nPoint++)
            {
                ctx.Graphic.DrawLine(pen, pts[nPoint], pts[nPoint + 1]);
            }
            pen.Dispose();
        }

        public bool IsOperationnel
        {
            get
            {
                return m_bIsOperationnel;
            }
        }

        public override void AfterDrawObjet(CContextDessinObjetGraphique ctx, C2iObjetDeSchema objet)
        {
            if (!IsConcerneParAlarme)
                return;
            C2iLienDeSchemaReseau dessinLien = objet as C2iLienDeSchemaReseau;
            if (dessinLien == null)
                return;
            //Image img = m_base.GetImageIsOperationnel(m_bIsOperationnel);
            Image img = m_base.GetImageEtatOperationnel(EtatOperationnel);

            Point[] pts = dessinLien.Points;
            Point pt;
            if (pts.Length % 2 == 0)
            {
                //trouve les points du milieu
                Point pt1 = pts[pts.Length / 2 - 1];
                Point pt2 = pts[pts.Length / 2];
                pt = new Point((pt1.X + pt2.X) / 2, (pt1.Y + pt2.Y) / 2);
            }
            else
            {
                pt = pts[pts.Length / 2];
            }
            Image imgMask = null;
            if (HasMasquage)
                imgMask = timos.data.Resource.Mask_adm;
            //else if (HasMasquageBrigadier)
            //    imgMask = timos.data.Resource.mask_bri;
            Size sz = new Size(0,0);
            if ( img != null )
                sz = new Size ( img.Size.Width, img.Size.Height );
            if ( imgMask != null )
                sz = new Size ( sz.Width+imgMask.Width, Math.Max ( sz.Height, imgMask.Height ) );
            if ( img != null )
            {
                Point ptImg = pt;
                ptImg.Offset ( -sz.Width/2, -img.Height/2);
                pt.Offset ( -sz.Width/2+img.Width, 0);
                ctx.Graphic.DrawImageUnscaled(img, ptImg);
            }
            else
                pt.Offset(sz.Width/2,0);


            if (imgMask != null)
            {
                pt.Offset(0, -imgMask.Height / 2);
                ctx.Graphic.DrawImageUnscaled(imgMask, pt);
            }
        }

        public override CReferenceObjetDonnee GetReferenceObjetAssocie()
        {
            return new CReferenceObjetDonnee(typeof(CLienReseau), m_dbKeyLien);
        }
    }
}
