using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using timos.data;
using sc2i.data;
using timos.data.reseau.graphe;
using sc2i.drawing;
using System.Drawing;
using timos.data.reseau.arbre_operationnel;
using futurocom.supervision;
using sc2i.common;

namespace timos.data.supervision.vueanimee
{
    
    public abstract class CInfoElementDeSchemaSupervise : IComparable<CInfoElementDeSchemaSupervise>
    {

        private CInfoElementDeSchemaSupervise m_parent = null;
        
        protected List<CInfoElementDeSchemaSupervise> m_listeFils = new List<CInfoElementDeSchemaSupervise>();

        private int m_nNiveauProfondeur = 0;
        private Dictionary<string, CDonneesSupervisionAlarme> m_dicAlarmesEnCours = new Dictionary<string, CDonneesSupervisionAlarme>();

        //Tous les éléments concernant directemnt cet élément
        protected Dictionary<CDbKey, bool> m_dicSitesConcernant = new Dictionary<CDbKey, bool>();
        protected Dictionary<CDbKey, bool> m_dicEquipementsConcernant = new Dictionary<CDbKey, bool>();
        protected Dictionary<CDbKey, bool> m_dicLiaisonsConcernant = new Dictionary<CDbKey, bool>();
        protected Dictionary<CDbKey, bool> m_dicServicesConcernant = new Dictionary<CDbKey, bool>();
        protected Dictionary<CDbKey, bool> m_dicEntitesSnmpConcernant = new Dictionary<CDbKey, bool>();
        
        //Liste des acces concernant cet élément
        private Dictionary<int, bool> m_dicLiensAlarmeConcernant = new Dictionary<int, bool>();


        protected CBasePourVueAnimee m_base = null;

        private CLocalSeveriteAlarme m_severite = null;
        private bool m_bHasMasquage = false;
        //private CLocalParametrageFiltrageAlarmes m_masquage = null;
        private EEtatOperationnelSchema m_etatOperationel = EEtatOperationnelSchema.OK;

        //Indique si l'élément ou un de ses sous éléments a des alarmes masquées brigadier
        //private bool m_bHasMasquageAdmin = false;

        //Indique si l'élément ou un de ses sous éléments a des alarmes masquées administrateur
        //private bool m_bHasMasquageBrigadier = false;

        //private Dictionary<int, bool> m_dicLienAlarmeMasquesAdmin = new Dictionary<int, bool>();
        //private Dictionary<int, bool> m_dicLienAlarmeMasquesBrigadier = new Dictionary<int, bool>();

        //Inidique si l'élément ou un de ses sous éléments a des LienAcessAlarme
        private bool m_bIsConcernéParAlarmes = false;

        private int? m_nIdElementDeSchema;

        

        /// <summary>
        /// Informations sur une alarme qui concerne cet élément
        /// </summary>
        private class CDonneesSupervisionAlarme
        {
            public readonly CLocalAlarme LocalAlarme;
            public readonly bool IsFromChild;

            private bool m_bIsMasqueAdministrateur = false;
            private bool m_bIsMasqueBrigadier = false;

            public CDonneesSupervisionAlarme ( CLocalAlarme info, bool bIsFromChild )
            {
                LocalAlarme = info;
                IsFromChild = bIsFromChild;
            }

        }

        //------------------------------------
        public bool IsConcernéParAlarmes
        {
            get
            {
                return m_bIsConcernéParAlarmes;
            }
            
        }

        public bool HasMasquage
        {
            get
            {
                return m_bHasMasquage;
            }
        }

        //------------------------------------
        //protected bool HasMasquageBrigadier
        //{
        //    get
        //    {
        //        return m_bHasMasquageBrigadier;
        //    }
        //}

        //------------------------------------
        //protected bool HasMasquageAdministrateur
        //{
        //    get
        //    {
        //        return m_bHasMasquageAdmin;
        //    }
        //}

        /// <summary>
        /// Indique que l'élément est concerné par des alarmes
        /// </summary>
        public void SetConcerneParAlarmes()
        {
            m_bIsConcernéParAlarmes = true;
            if (Parent != null)
                Parent.SetConcerneParAlarmes();
        }

        //------------------------------------
        protected bool IsConcerneParAlarme
        {
            get
            {
                return true;
                //return m_bIsConcernéParAlarmes;
            }
        }


        


        //------------------------------------
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

        //------------------------------------
        private void OnChangeEtatSupervise()
        {
            if (m_nIdElementDeSchema != null)
                m_base.OnChangementEtatSupervise(this);
        }

        //------------------------------------
        protected void ChangeGravite(CLocalSeveriteAlarme severite)
        {
            if (severite != m_severite)
                OnChangeEtatSupervise();
        }



        //------------------------------------
        public CInfoElementDeSchemaSupervise Parent
        {
            get
            {
                return m_parent;
            }
        }

        //------------------------------------
        public int? IdElementDeSchema
        {
            get
            {
                return m_nIdElementDeSchema;
            }
        }

        //------------------------------------
        public Color CouleurAlarme
        {
            get
            {
                if (m_severite != null)
                    return m_severite.Couleur;
                return Color.White;
            }
        }


        //------------------------------------
        internal virtual void InitFromElementDeSchema ( CElementDeSchemaReseau elementDeSchema )
        {
            if ( elementDeSchema != null )
                m_base.SetInfoPourElementDeSchema(this, elementDeSchema.Id);
            m_dicEquipementsConcernant.Clear();
            m_dicEntitesSnmpConcernant.Clear();
            m_dicSitesConcernant.Clear();
            m_dicLiaisonsConcernant.Clear();
            m_dicServicesConcernant.Clear();
            m_listeFils.Clear();
        }

        //------------------------------------
        public CInfoElementDeSchemaSupervise[] ListeFils
        {
            get
            {
                return m_listeFils.ToArray();
            }
        }

        //------------------------------------
        public CLocalSeveriteAlarme SeveriteAlarme
        {
            get
            {
                return m_severite;
            }
            set
            {
                m_severite = value;
            }
        }

        //------------------------------------
        public virtual EEtatOperationnelSchema EtatOperationnel
        {
            get
            {
                return m_etatOperationel;
            }
            protected set
            {
                m_etatOperationel = value;
            }
        }


        //------------------------------------
        internal void FillDicsConcernes(
            CDictionnaireConcerne dicConcernesParSite, 
            CDictionnaireConcerne dicConcernesParLiaison, 
            CDictionnaireConcerne dicConcernesParEquipement,
            CDictionnaireConcerne dicConcernesParEntiteSnmp,
            CDictionnaireConcerne dicConcernesParService)
        {
            foreach (CDbKey dbKey in m_dicSitesConcernant.Keys)
                dicConcernesParSite.Add(dbKey, this);
            foreach (CDbKey dbKey in m_dicLiaisonsConcernant.Keys)
                dicConcernesParLiaison.Add(dbKey, this);
            foreach (CDbKey dbKey in m_dicEquipementsConcernant.Keys)
                dicConcernesParEquipement.Add(dbKey, this);
            foreach (CDbKey dbKey in m_dicEntitesSnmpConcernant.Keys)
                dicConcernesParEntiteSnmp.Add(dbKey, this);
            foreach (CDbKey dbKey in m_dicServicesConcernant.Keys)
                dicConcernesParService.Add(dbKey, this);
            foreach (CInfoElementDeSchemaSupervise fils in m_listeFils)
                fils.FillDicsConcernes(
                    dicConcernesParSite,
                    dicConcernesParLiaison,
                    dicConcernesParEquipement,
                    dicConcernesParEntiteSnmp,
                    dicConcernesParService);
        }


        //------------------------------------
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

        //------------------------------------
        public virtual void FillDicNoeudArbreRacineToInfoElement(
            Dictionary<CElementDeArbreOperationnel, CInfoElementDeSchemaSupervise> dicNoeudArbreRacineToInfoElement)
        {
            foreach (CInfoElementDeSchemaSupervise fils in m_listeFils)
            {
                fils.FillDicNoeudArbreRacineToInfoElement(dicNoeudArbreRacineToInfoElement);
            }

        }

        //------------------------------------
        /// <summary>
        /// recalcul simple : s'il y a une alarme sur le fils, l'objet est en alarme
        /// </summary>
        protected virtual void RecalculeGraviteEtMasquage()
        {
            CLocalSeveriteAlarme oldSeverite = m_severite;
            CLocalSeveriteAlarme severite = null;
            m_etatOperationel = EEtatOperationnelSchema.OK;
            m_bHasMasquage = false;
            foreach (CDonneesSupervisionAlarme donnee in m_dicAlarmesEnCours.Values)
            {
                if (donnee.LocalAlarme.MasquageApplique == null || donnee.LocalAlarme.MasquageApplique.Priorite <= m_base.NiveauMasquageMaxAffiche)
                {
                    if (severite == null || donnee.LocalAlarme.Severite.Priorite > severite.Priorite)
                        severite = donnee.LocalAlarme.TypeAlarme.Severite;
                    if (donnee.LocalAlarme.IsHS && !donnee.IsFromChild)
                        m_etatOperationel = EEtatOperationnelSchema.HS;
                }
                else
                    m_bHasMasquage = true;
            }
            m_severite = severite;
            if ( oldSeverite != m_severite )
                m_base.OnChangementEtatSupervise(this);
        }

        //------------------------------------
        internal void StopAlarme(string strIdAlarme)
        {
            if ( m_dicAlarmesEnCours.ContainsKey ( strIdAlarme ) )
            {
                m_dicAlarmesEnCours.Remove ( strIdAlarme );
            }
            RecalculeGraviteEtMasquage();
            List<CInfoElementDeSchemaSupervise> lstTmp = new List<CInfoElementDeSchemaSupervise>();
            //RecalculeToutLeMasquage(lstTmp);
        }

        //------------------------------------
        internal void StartAlarme(CLocalAlarme alarme, bool bIsFromChild)
        {
            CDonneesSupervisionAlarme data = null;
            if (m_dicAlarmesEnCours.TryGetValue(alarme.Id, out data))
            {
                if ( bIsFromChild )//Si c'est une alarme fille, pas besoin d'écraser l'actuelle,
                    return;
            }
            data = new CDonneesSupervisionAlarme(alarme, bIsFromChild);
            m_dicAlarmesEnCours[alarme.Id] = data;
            RecalculeGraviteEtMasquage();
            List<CInfoElementDeSchemaSupervise> lstTmp = new List<CInfoElementDeSchemaSupervise>();
            //RecalculeToutLeMasquage(lstTmp);

        }

        //------------------------------------
        internal void MaskAlarme(int nIdAlarme)
        {
            // Masquage manuel à implémenter

        }

        //------------------------------------
        public void AddLienAlarme(int nIdLien)
        {
            m_dicLiensAlarmeConcernant[nIdLien] = true;
        }


        //------------------------------------
        public virtual void AfterDrawObjet(CContextDessinObjetGraphique ctx, C2iObjetDeSchema objet)
        {
            if (!IsConcerneParAlarme)
                return;
            int nSizeTour = 2;
            Color couleur = m_severite != null ? m_severite.Couleur : Color.White;

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

            if (HasMasquage)
            {
                imgMasquage = timos.data.Resource.Mask_adm;
            }

            if (imgMasquage != null)
                ctx.Graphic.DrawImageUnscaled(imgMasquage, rct.Right - imgMasquage.Width, rct.Bottom - imgMasquage.Height);

        }

        //------------------------------------
        public virtual void BeforeDrawObjet(CContextDessinObjetGraphique ctx, C2iObjetDeSchema objet)
        {
            if (!m_bIsConcernéParAlarmes)
                return;
        }

        //------------------------------------
        public int NiveauProfondeur
        {
            get
            {
                return m_nNiveauProfondeur;
            }
        }

        //------------------------------------
        public int CompareTo(CInfoElementDeSchemaSupervise other)
        {
            return other.m_nNiveauProfondeur.CompareTo(m_nNiveauProfondeur);
        }

        //------------------------------------
        //private void SetMasquage ( int nIdLienAlarme, bool bMasque, Dictionary<int, bool> dicMasquage )
        //{
        //    bool? bOld = null;
        //    if (dicMasquage.ContainsKey(nIdLienAlarme))
        //        bOld = dicMasquage[nIdLienAlarme];
        //    if ( bOld != null && !bMasque )
        //        dicMasquage.Remove ( nIdLienAlarme );
        //    if ( bMasque )
        //        dicMasquage[nIdLienAlarme] = bMasque;
        //}

        //------------------------------------
        /// <summary>
        /// Attention cette fonction ne recalcule pas l'état de masquage
        /// </summary>
        /// <param name="nIdLienAlarme"></param>
        /// <param name="bMasque"></param>
        //internal void SetMasquageBrigadier(int nIdLienAlarme, bool bMasque)
        //{
        //    SetMasquage ( nIdLienAlarme, bMasque, m_dicLienAlarmeMasquesBrigadier );

        //}

        //------------------------------------
        /// <summary>
        /// Attention cette fonction ne recalcule pas l'état de masquage
        /// </summary>
        /// <param name="nIdLienAlarme"></param>
        /// <param name="bMasque"></param>
        //internal void SetMasquageAdministrateur(int nIdLienAlarme, bool bMasque)
        //{
        //   SetMasquage ( nIdLienAlarme, bMasque, m_dicLienAlarmeMasquesAdmin );
        //}

        /*//----------------------------------------------------------------------------
        public virtual void RecalculeToutLeMasquage(List<CInfoElementDeSchemaSupervise> lstModifies)
        {
            while (Parent != null)//recalcule à partir de la racine
            {
                Parent.RecalculeToutLeMasquage(lstModifies);
                return;
            }


            RecalculeMasquageAvecFils(lstModifies);
        }

        //----------------------------------------------------------------------------
        private void RecalculeMasquageAvecFils ( List<CInfoElementDeSchemaSupervise> lstModifies )
        {
            RecalculeMasquageFromAlarmes(lstModifies);

            CLocalParametrageFiltrageAlarmes oldMask = Masquage;
            CLocalParametrageFiltrageAlarmes masqueAPrendre = null;

            foreach (CInfoElementDeSchemaSupervise fils in ListeFils)
            {
                fils.RecalculeMasquageAvecFils(lstModifies);
                CLocalParametrageFiltrageAlarmes masque = fils.Masquage;
                if (masque == null)
                {
                    masqueAPrendre = null;
                    break;
                }
                else
                {
                    if (masqueAPrendre == null ||
                        masque.CategorieMasquage.Priorite < masqueAPrendre.CategorieMasquage.Priorite)
                    {
                        masqueAPrendre = masque;
                    }
                }
            }
            if (masqueAPrendre != null)
            {
                if (Masquage == null)
                    m_masquage = masqueAPrendre;
                else if (masqueAPrendre.CategorieMasquage.Priorite < Masquage.CategorieMasquage.Priorite)
                {
                    m_masquage = masqueAPrendre;
                }
            }
            if (Masquage != oldMask)
                lstModifies.Add(this);

        }*/

        //----------------------------------------------------------------------------
        /*private void RecalculeMasquageFromAlarmes(List<CInfoElementDeSchemaSupervise> lstModifies)
        {
            CLocalParametrageFiltrageAlarmes oldMask = Masquage;
            CLocalParametrageFiltrageAlarmes masqueAPrendre = null;
            foreach (CDonneesSupervisionAlarme dataSupervise in m_dicAlarmesEnCours.Values)
            {
                CLocalParametrageFiltrageAlarmes masque = dataSupervise.LocalAlarme.MasquageHerite;
                if (masque == null)
                {
                    masqueAPrendre = null;
                    break;
                }
                else
                {
                    if (masqueAPrendre == null ||
                        masque.CategorieMasquage.Priorite < masqueAPrendre.CategorieMasquage.Priorite)
                    {
                        masqueAPrendre = masque;
                    }
                }
            }
            if (masqueAPrendre != null)
            {
                if (Masquage == null)
                    m_masquage = masqueAPrendre;
                else if (masqueAPrendre.CategorieMasquage.Priorite < Masquage.CategorieMasquage.Priorite)
                {
                    m_masquage = masqueAPrendre;
                }
            }
            if (Masquage != oldMask)
                lstModifies.Add(this);
        }*/

        //-----------------------------------------------------------------------------------
        public string[] GetIdsAlarmesEnCours()
        {
            List<string> lstIds = new List<string>();
            lstIds.AddRange(m_dicAlarmesEnCours.Keys);
            return lstIds.ToArray();
        }

        //------------------------------------
        public abstract CReferenceObjetDonnee GetReferenceObjetAssocie();





    }
}
