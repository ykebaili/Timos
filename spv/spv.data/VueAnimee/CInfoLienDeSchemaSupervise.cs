using System;
using System.Collections.Generic;
using System.Text;
using timos.data;
using sc2i.drawing;
using System.Drawing;
using sc2i.data;
using System.Collections;
using timos.data.reseau.arbre_operationnel;

namespace spv.data.VueAnimee
{
    public class CInfoLienDeSchemaSupervise : CInfoElementDeSchemaSupervise
    {
        private int m_nIdLienSmt;
        private int? m_nIdLienSpv;
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
            m_nIdLienSmt = lien.Id;
            CSpvLiai liaisonSpv = CSpvLiai.GetObjetSpvFromObjetTimos(lien);
            if (liaisonSpv != null)
            {
                m_dicLiaisonsSpvConcernant[liaisonSpv.Id] = true;
                m_nIdLienSpv = liaisonSpv.Id;
            }
            /* */
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
            CSpvSite site = new CSpvSite(m_base.ContexteDonnee);
            CSpvEquip equip = new CSpvEquip(m_base.ContexteDonnee);
            if (!bHasElement1)
            {
                if ( elt1 is CSite )
                {
                    if (site.ReadIfExists(new CFiltreData(CSpvSite.c_champSmtSite_Id + "=@1", elt1.Id), false))
                        m_dicSitesSpvConcernant[site.Id] = true;
                }
                else if ( elt1 is CEquipementLogique )
                {
                    if ( equip.ReadIfExists ( new CFiltreData ( CSpvEquip.c_champSmtEquipementLogique_Id+"=@1", elt1.Id), false ))
                        m_dicEquipementsSpvConcernant[equip.Id] = true;
                }
            }
            if (!bHasElement2)
            {
                if ( elt2 is CSite )
                {
                    if (site.ReadIfExists(new CFiltreData(CSpvSite.c_champSmtSite_Id + "=@1", elt2.Id), false))
                        m_dicSitesSpvConcernant[site.Id] = true;
                }
                else if ( elt2 is CEquipementLogique )
                {
                    if (equip.ReadIfExists(new CFiltreData(CSpvEquip.c_champSmtEquipementLogique_Id + "=@1", elt2.Id), false))
                        m_dicEquipementsSpvConcernant[equip.Id] = true;
                }
            }
        }


        public int IdLienTimos
        {
            get
            {
                return m_nIdLienSmt;
            }
        }

        public int? IdLienSpv
        {
            get
            {
                return m_nIdLienSpv;
            }
        }

        //---------------------------------------------------------------------------------------------
        private EEtatOperationnelSchema m_etatOperationnel = EEtatOperationnelSchema.OK;
        public EEtatOperationnelSchema EtatOperationnel
        {
            get
            {
                return m_etatOperationnel;
            }
            set
            {
                m_etatOperationnel = value;
            }
        }

        //---------------------------------------------------------------------------------------------
        protected override void RecalculeGravite()
        {
            //bool bOldOperationnel = m_bIsOperationnel;

            EEtatOperationnelSchema OldEtat = m_etatOperationnel;
            try
            {
                base.RecalculeGravite();
                //Normallement, il n'y a qu'un fils !
                m_bIsOperationnel = true;
                foreach (CInfoElementDeSchemaSupervise infoFils in m_listeFils)
                {
                    CInfoSchemaDeSchemaSupervise infoSchema = infoFils as CInfoSchemaDeSchemaSupervise;
                    if (infoSchema != null)
                    {
                        m_etatOperationnel = infoSchema.EtatOperationnel;
                        
                    }
                    if (infoFils.GraviteAlarme > GraviteAlarme)
                        ChangeGravite( infoFils.GraviteAlarme );
                }
                //if (GraviteAlarme >= EGraviteAlarme.Major && (m_dicSitesSpvConcernant.Count > 0 || m_dicEquipementsSpvConcernant.Count > 0))//Pas de schéma
                if (GraviteAlarme >= EGraviteAlarme.Major)// && (m_dicSitesSpvConcernant.Count > 0 || m_dicEquipementsSpvConcernant.Count > 0))//Pas de schéma
                    m_etatOperationnel = EEtatOperationnelSchema.HS;
            }
            finally
            {
                if (m_etatOperationnel != OldEtat)
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
            Color couleur = CSpvAlarmcouleur.GetColor(CouleurAlarme, dessinLien.ElementDeSchema.ContexteDonnee);
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
            Image img = m_base.GetImageEtatOperationnel(m_etatOperationnel);
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
            if (HasMasquageAdministrateur)
                imgMask = SpvDataResource.Mask_adm;
            else if (HasMasquageBrigadier)
                imgMask = SpvDataResource.mask_bri;
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

        public override CReferenceObjetDonnee GetReferenceObjetSpvAssocie()
        {
            if (m_nIdLienSpv != null)
                return new CReferenceObjetDonnee(typeof(CSpvLiai), m_nIdLienSpv.Value);
            return null;
        }
    }
}
