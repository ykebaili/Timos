using System;
using System.Collections.Generic;
using System.Text;
using timos.data;
using sc2i.data;
using spv.data.ConsultationAlarmes;
using timos.data.reseau.graphe;
using sc2i.drawing;
using System.Drawing;
using timos.data.reseau.arbre_operationnel;

namespace spv.data.VueAnimee
{
    
    public abstract class CInfoElementDeSchemaSupervise : IComparable<CInfoElementDeSchemaSupervise>
    {

        private CInfoElementDeSchemaSupervise m_parent = null;
        
        protected List<CInfoElementDeSchemaSupervise> m_listeFils = new List<CInfoElementDeSchemaSupervise>();

        private int m_nNiveauProfondeur = 0;

        //Tous les éléments SPV concernant directemnt cet élément
        protected Dictionary<int, bool> m_dicSitesSpvConcernant = new Dictionary<int, bool>();
        protected Dictionary<int, bool> m_dicEquipementsSpvConcernant = new Dictionary<int, bool>();
        protected Dictionary<int, bool> m_dicLiaisonsSpvConcernant = new Dictionary<int, bool>();
        protected Dictionary<int, bool> m_dicServicesSpvConcernant = new Dictionary<int, bool>();
        
        //Liste des acces concernant cet élément
        private Dictionary<int, bool> m_dicLiensAlarmeConcernant = new Dictionary<int, bool>();

        private ECouleurAlarme m_couleurEnCours = ECouleurAlarme.NoAlarm;

        protected CBasePourVueAnimee m_base = null;

        private EGraviteAlarme m_gravite = EGraviteAlarme.NoAlarm;

        //Indique si l'élément ou un de ses sous éléments a des alarmes masquées brigadier
        private bool m_bHasMasquageAdmin = false;

        //Indique si l'élément ou un de ses sous éléments a des alarmes masquées administrateur
        private bool m_bHasMasquageBrigadier = false;

        private Dictionary<int, bool> m_dicLienAlarmeMasquesAdmin = new Dictionary<int, bool>();
        private Dictionary<int, bool> m_dicLienAlarmeMasquesBrigadier = new Dictionary<int, bool>();

        //Inidique si l'élément ou un de ses sous éléments a des LienAcessAlarme
        private bool m_bIsConcernéParAlarmes = false;

        private int? m_nIdElementDeSchema;

        

        /// <summary>
        /// Informations sur une alarme qui concerne cet élément
        /// </summary>
        private class CDonneesSupervisionAlarme
        {
            public readonly CInfoAlarmeAffichee InfoAlarme;
            public readonly bool IsFromChild;

            private bool m_bIsMasqueAdministrateur = false;
            private bool m_bIsMasqueBrigadier = false;

            public CDonneesSupervisionAlarme ( CInfoAlarmeAffichee info, bool bIsFromChild )
            {
                InfoAlarme = info;
                IsFromChild = bIsFromChild;
            }

        }

        public bool IsConcernéParAlarmes
        {
            get
            {
                return m_bIsConcernéParAlarmes;
            }
            
        }

        protected bool HasMasquageBrigadier
        {
            get
            {
                return m_bHasMasquageBrigadier;
            }
        }

        protected bool HasMasquageAdministrateur
        {
            get
            {
                return m_bHasMasquageAdmin;
            }
        }

        /// <summary>
        /// Indique que l'élément est concerné par des alarmes
        /// </summary>
        public void SetConcerneParAlarmes()
        {
            m_bIsConcernéParAlarmes = true;
            if (Parent != null)
                Parent.SetConcerneParAlarmes();
        }

        protected bool IsConcerneParAlarme
        {
            get
            {
                return m_bIsConcernéParAlarmes;
            }
        }


        

        private Dictionary<int, CDonneesSupervisionAlarme> m_dicAlarmesEnCours = new Dictionary<int, CDonneesSupervisionAlarme>();


        public CInfoElementDeSchemaSupervise ( 
            CInfoElementDeSchemaSupervise parent, 
            CElementDeSchemaReseau eltDeSchema,
            CBasePourVueAnimee basePourVue,
            int nNiveauProfondeur )
        {
            m_parent = parent;
            if (eltDeSchema != null)
                m_nIdElementDeSchema = eltDeSchema.Id;
            m_base = basePourVue;
            m_nNiveauProfondeur = nNiveauProfondeur;
        }

        private void OnChangeEtatSupervise()
        {
            if (m_nIdElementDeSchema != null)
                m_base.OnChangementEtatSupervise(this);
        }

        protected void ChangeGravite(EGraviteAlarme gravite)
        {
            if (gravite != m_gravite)
                OnChangeEtatSupervise();
        }



        public CInfoElementDeSchemaSupervise Parent
        {
            get
            {
                return m_parent;
            }
        }

        public int? IdElementDeSchema
        {
            get
            {
                return m_nIdElementDeSchema;
            }
        }

        public ECouleurAlarme CouleurAlarme
        {
            get
            {
                return m_couleurEnCours;
            }
        }

        
        internal virtual void InitFromElementDeSchema ( CElementDeSchemaReseau elementDeSchema )
        {
            if ( elementDeSchema != null )
                m_base.SetInfoPourElementDeSchema(this, elementDeSchema.Id);
            m_dicEquipementsSpvConcernant.Clear();
            m_dicSitesSpvConcernant.Clear();
            m_dicLiaisonsSpvConcernant.Clear();
            m_dicServicesSpvConcernant.Clear();
            m_listeFils.Clear();
        }

        public CInfoElementDeSchemaSupervise[] ListeFils
        {
            get
            {
                return m_listeFils.ToArray();
            }
        }

        public EGraviteAlarme GraviteAlarme
        {
            get
            {
                return m_gravite;
            }
            set
            {
                m_gravite = value;
            }
        }

        
        internal void FillDicsConcernes(
            CDictionnaireConcerne dicConcernesParSite, 
            CDictionnaireConcerne dicConcernesParLiaison, 
            CDictionnaireConcerne dicConcernesParEquipement,
            CDictionnaireConcerne dicConcernesParService)
        {
            foreach (int nId in m_dicSitesSpvConcernant.Keys)
                dicConcernesParSite.Add(nId, this);
            foreach (int nId in m_dicLiaisonsSpvConcernant.Keys)
                dicConcernesParLiaison.Add(nId, this);
            foreach (int nId in m_dicEquipementsSpvConcernant.Keys)
                dicConcernesParEquipement.Add(nId, this);
            foreach (int nId in m_dicServicesSpvConcernant.Keys)
                dicConcernesParService.Add(nId, this);
            foreach (CInfoElementDeSchemaSupervise fils in m_listeFils)
                fils.FillDicsConcernes(
                    dicConcernesParSite,
                    dicConcernesParLiaison,
                    dicConcernesParEquipement,
                    dicConcernesParService);
        }

        
        public virtual void FillDicsElementToNoeudsArbre(
            CDictionnaireElementToNoeudArbre dicEquipementToNoeudArbreOp,
            CDictionnaireElementToNoeudArbre dicSiteToNoeudArbreOp,
            CDictionnaireElementToNoeudArbre dicLiaisonToNoeudArbreOp,
            CDictionnaireElementToNoeudArbre dicServiceToNoeudArbreOp)
        {

            foreach (CInfoElementDeSchemaSupervise fils in m_listeFils)
            {
                fils.FillDicsElementToNoeudsArbre(
                    dicEquipementToNoeudArbreOp,
                    dicSiteToNoeudArbreOp,
                    dicLiaisonToNoeudArbreOp,
                    dicServiceToNoeudArbreOp);
            }


        }

        public virtual void FillDicNoeudArbreRacineToInfoElement(
            Dictionary<CElementDeArbreOperationnel, CInfoElementDeSchemaSupervise> dicNoeudArbreRacineToInfoElement)
        {
            foreach (CInfoElementDeSchemaSupervise fils in m_listeFils)
            {
                fils.FillDicNoeudArbreRacineToInfoElement(dicNoeudArbreRacineToInfoElement);
            }

        }

        /// <summary>
        /// recalcul simple : s'il y a une alarme sur le fils, l'objet est en alarme
        /// </summary>
        protected virtual void RecalculeGravite()
        {
            ECouleurAlarme oldCouleurAlarme = m_couleurEnCours;
            m_gravite = EGraviteAlarme.NoAlarm;
            foreach (CDonneesSupervisionAlarme donnee in m_dicAlarmesEnCours.Values)
            {
                EGraviteAlarme graviteAlarme = CGraviteAlarme.ConvertFrom((EGraviteAlarmeAvecMasquage)donnee.InfoAlarme.SeverityCode);
                    m_gravite = (EGraviteAlarme)Math.Max((int)m_gravite, (int)graviteAlarme);
            }
            switch (m_gravite)
            {
                case EGraviteAlarme.NoAlarm:
                    m_couleurEnCours = ECouleurAlarme.NoAlarm;
                    break;
                case EGraviteAlarme.Warning:
                    m_couleurEnCours = ECouleurAlarme.Warning;
                    break;
                case EGraviteAlarme.Undetermined:
                    m_couleurEnCours = ECouleurAlarme.Undetermined;
                    break;
                case EGraviteAlarme.Minor:
                    m_couleurEnCours = ECouleurAlarme.Minor;
                    break;
                case EGraviteAlarme.Major:
                    m_couleurEnCours = ECouleurAlarme.Major;
                    break;
                case EGraviteAlarme.Critical:
                    m_couleurEnCours = ECouleurAlarme.Critical;
                    break;
            }
            if (m_couleurEnCours != oldCouleurAlarme)
                m_base.OnChangementEtatSupervise(this);
        }


        internal void StopAlarme(int nIdAlarme)
        {
            if ( m_dicAlarmesEnCours.ContainsKey ( nIdAlarme ) )
            {
                m_dicAlarmesEnCours.Remove ( nIdAlarme );
            }
            RecalculeGravite();
        }

        internal void StartAlarme(CInfoAlarmeAffichee infoAlarme, bool bIsFromChild)
        {
            CDonneesSupervisionAlarme data = null;
            if (m_dicAlarmesEnCours.TryGetValue(infoAlarme.IdSpvEvtAlarme, out data))
            {
                if ( bIsFromChild )//Si c'est une alarme fille, pas besoin d'écraser l'actuelle,
                    return;
            }
            data = new CDonneesSupervisionAlarme(infoAlarme, bIsFromChild);
            //m_dicAlarmesEnCours[infoAlarme.IdSpvEvtAlarme] = data;
            m_dicAlarmesEnCours[infoAlarme.IdSpvAlarmeData] = data;
            RecalculeGravite();
        }

        internal void MaskAlarme(int nIdAlarme)
        {
        }

        public void AddLienAlarme(int nIdLien)
        {
            m_dicLiensAlarmeConcernant[nIdLien] = true;
        }


        public virtual void AfterDrawObjet(CContextDessinObjetGraphique ctx, C2iObjetDeSchema objet)
        {
            if (!m_bIsConcernéParAlarmes)
                return;
            int nSizeTour = 2;
            Color couleur = CSpvAlarmcouleur.GetColor(CouleurAlarme, m_base.ContexteDonnee);
            //couleur = Color.FromArgb(255, couleur);
            Rectangle rct = objet.RectangleAbsolu;

            Brush br = new SolidBrush(couleur);
            ctx.Graphic.FillRectangle(br, new Rectangle(rct.Left - nSizeTour, rct.Top - nSizeTour, rct.Width + nSizeTour, nSizeTour));
            ctx.Graphic.FillRectangle(br, new Rectangle(rct.Right, rct.Top - nSizeTour, nSizeTour, rct.Height + nSizeTour * 2));
            ctx.Graphic.FillRectangle(br, new Rectangle(rct.Left - nSizeTour, rct.Bottom, rct.Width + 2 * nSizeTour, nSizeTour));
            ctx.Graphic.FillRectangle(br, new Rectangle(rct.Left - nSizeTour, rct.Top - nSizeTour, nSizeTour, rct.Height + nSizeTour));
            br.Dispose();
            br = new SolidBrush(Color.FromArgb(100, couleur));
            ctx.Graphic.FillRectangle(br, rct);
            br.Dispose();

            Image imgMasquage = null;

            if (HasMasquageAdministrateur)
            {
                imgMasquage = SpvDataResource.Mask_adm;
            }
            else if ( HasMasquageBrigadier )
            {
                imgMasquage = SpvDataResource.mask_bri;
            }
            if (imgMasquage != null)
                ctx.Graphic.DrawImageUnscaled(imgMasquage, rct.Right - imgMasquage.Width, rct.Bottom - imgMasquage.Height);

        }

        public virtual void BeforeDrawObjet(CContextDessinObjetGraphique ctx, C2iObjetDeSchema objet)
        {
            if (!m_bIsConcernéParAlarmes)
                return;
        }

        public int NiveauProfondeur
        {
            get
            {
                return m_nNiveauProfondeur;
            }
        }

        #region IComparable<CInfoElementDeSchemaSupervise> Membres

        public int CompareTo(CInfoElementDeSchemaSupervise other)
        {
            return other.m_nNiveauProfondeur.CompareTo(m_nNiveauProfondeur);
        }

        #endregion

        private void SetMasquage ( int nIdLienAlarme, bool bMasque, Dictionary<int, bool> dicMasquage )
        {
            bool? bOld = null;
            if (dicMasquage.ContainsKey(nIdLienAlarme))
                bOld = dicMasquage[nIdLienAlarme];
            if ( bOld != null && !bMasque )
                dicMasquage.Remove ( nIdLienAlarme );
            if ( bMasque )
                dicMasquage[nIdLienAlarme] = bMasque;
        }

        /// <summary>
        /// Attention cette fonction ne recalcule pas l'état de masquage
        /// </summary>
        /// <param name="nIdLienAlarme"></param>
        /// <param name="bMasque"></param>
        internal void SetMasquageBrigadier(int nIdLienAlarme, bool bMasque)
        {
            SetMasquage ( nIdLienAlarme, bMasque, m_dicLienAlarmeMasquesBrigadier );

        }

        /// <summary>
        /// Attention cette fonction ne recalcule pas l'état de masquage
        /// </summary>
        /// <param name="nIdLienAlarme"></param>
        /// <param name="bMasque"></param>
        internal void SetMasquageAdministrateur(int nIdLienAlarme, bool bMasque)
        {
           SetMasquage ( nIdLienAlarme, bMasque, m_dicLienAlarmeMasquesAdmin );
        }

        public virtual void RecalculeToutLeMasquage( List<CInfoElementDeSchemaSupervise> lstModifies)
        {
            while (Parent != null)//recalcule à partir de la racine
            {
                Parent.RecalculeToutLeMasquage(lstModifies);
                return;
            }
            RecalculeMasquageAvecFils ( lstModifies );
        }

        private void RecalculeMasquageAvecFils ( List<CInfoElementDeSchemaSupervise> lstModifies )
        {
            bool bOldMasqueAdmin = m_bHasMasquageAdmin;
            bool bOldMasqueBrigadier = m_bHasMasquageBrigadier;
            bool bHasFilsMasqueAdmin = false;
            bool bHasFilsMasqueBrigadier = false;
            foreach (CInfoElementDeSchemaSupervise fils in ListeFils)
            {
                fils.RecalculeMasquageAvecFils(lstModifies);
                bHasFilsMasqueAdmin |= fils.m_bHasMasquageAdmin;
                bHasFilsMasqueBrigadier |= fils.m_bHasMasquageBrigadier;
            }
            bool bOldAdmin = m_bHasMasquageAdmin;
            bool bOldBrigadier = m_bHasMasquageBrigadier;
            if (m_dicLienAlarmeMasquesAdmin.Count > 0 || bHasFilsMasqueAdmin)
                m_bHasMasquageAdmin = true;
            if (m_dicLienAlarmeMasquesBrigadier.Count > 0 || bHasFilsMasqueBrigadier)
                m_bHasMasquageBrigadier = true;
            if (m_bHasMasquageBrigadier != bOldMasqueBrigadier || m_bHasMasquageAdmin != bOldMasqueAdmin)
                lstModifies.Add(this);                
        }

        public int[] GetIdsAlarmesEnCours()
        {
            List<int> lstIds = new List<int>();
            lstIds.AddRange(m_dicAlarmesEnCours.Keys);
            return lstIds.ToArray();
        }

        public abstract CReferenceObjetDonnee GetReferenceObjetSpvAssocie();




    }
}
