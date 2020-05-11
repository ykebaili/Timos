using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using timos.data.projet.Contraintes;
using sc2i.multitiers.client;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace timos.data.projet.gantt
{
    public class CElementDeGanttProjet : CElementDeGantt, IElementAUniteGanttParDefaut
    {
        private CProjet m_projet = null;
        private List<IContrainteDeGantt> m_listeContraintes = null;

        //-----------------------------------------------
        public CElementDeGanttProjet(IElementDeGantt elementParent, CProjet projet)
            :base ( elementParent )
        {
            m_projet = projet;
            if (projet.TypeProjet != null)
                Image = projet.TypeProjet.Image;
            SetPctAvancementSansCalculDeParent ( projet.PctAvancement );
            SetPoidSansCalculDeParent ( Poids = projet.Poids );
        }

        //-----------------------------------------------
        public override bool DatesAreDirty
        {
            get
            {
                return false;
            }
            set
            { }
        }




        //-----------------------------------------------
        public override string Libelle
        {
            get
            {
                if (ProjetAssocie != null)
                    return ProjetAssocie.Libelle;
                return "";
            }
        }

        //-----------------------------------------------
        [DynamicField("Associated project")]
        public override CProjet ProjetAssocie
        {
            get
            {
                return m_projet;
            }
        }

        //-----------------------------------------------
        public override DateTime DateDebut
        {
            get
            {
                if ( m_projet != null )
                    return m_projet.DateDebutGantt;
                return DateTime.Now;
            }
            set
            {
                if (m_projet != null && value != m_projet.DateDebutGantt)
                {
                    m_projet.DateDebutGantt = value;
                }
            }
        }

        //-----------------------------------------------
        public override bool MoveAutorise
        {
            get
            {
                //Vérifie qu'on a le droit
                CSessionClient session = CSessionClient.GetSessionForIdSession(ProjetAssocie.ContexteDonnee.IdSession);
                if (session != null)
                {
                    IInfoUtilisateur user = session.GetInfoUtilisateur();
                    if (user != null)
                    {
                        CRestrictionUtilisateurSurType res = user.GetRestrictionsSurObjet(ProjetAssocie, ProjetAssocie.ContexteDonnee.IdVersionDeTravail);
                        if (!res.CanModify(CProjet.c_champDateDebutPlanifiee) ||
                            !res.CanModify(CProjet.c_champDateFinPlanifiee))
                            return false;
                    }
                }
                return true;
            }
        }

        //-----------------------------------------------
        public override void Move(
            TimeSpan spDeplacement, 
            TimeSpan ? duree,
            EModeDeplacementProjet mode,
            bool bForceForThisElement)
        {
            if (!MoveAutorise)
                return;
            ProjetAssocie.Move(spDeplacement, duree, mode, bForceForThisElement);
            if (ElementParent != null)
                ElementParent.DatesAreDirty = true;
        }

        //-----------------------------------------------
        private bool m_bIsCheckingDates = false;
        private void CheckDatesPourParent()
        {
            if (m_bIsCheckingDates)
                return;
            m_bIsCheckingDates = true;
            DateTime valeur = DateDebut;
            if (ProjetAssocie != null)
            {
                DateTime? dt = ProjetAssocie.DateDebutPlanifieePourParent;
                if (dt != null)
                    valeur = dt.Value;
            }
            if (valeur != m_lastDateDebutPourParent)
            {
                m_lastDateDebutPourParent = valeur;
                if (ElementParent != null)
                    ElementParent.DatesAreDirty = true;
            }

            valeur = DateFin;
            if (ProjetAssocie != null)
            {
                DateTime? dt = ProjetAssocie.DateFinPlanifieePourParent;
                if (dt != null)
                    valeur = dt.Value;
            }
            if (valeur != m_lastDateFinPourParent)
            {
                m_lastDateFinPourParent = valeur;
                if (ElementParent != null)
                    ElementParent.DatesAreDirty = true;
            }
            m_bIsCheckingDates = false;
            
        }

        //-----------------------------------------------
        public override DateTime DateFin
        {
            get
            {
                CheckDatesPourParent();
                if (m_projet != null)
                    return m_projet.DateFinGantt;
                return DateTime.Now;
            }
            set
            {
                if (m_projet != null && value != m_projet.DateFinGantt)
                {
                    m_projet.DateFinGantt = value;
                }
            }
        }

        private DateTime? m_lastDateDebutPourParent = null;
        //-----------------------------------------------
        public override DateTime DateDebutPourParent
        {
            get
            {
                CheckDatesPourParent();
                return m_lastDateDebutPourParent.Value;
            }
        }

        private DateTime? m_lastDateFinPourParent = null;
        //-----------------------------------------------
        public override DateTime DateFinPourParent
        {
            get
            {
                CheckDatesPourParent();
                return m_lastDateFinPourParent.Value;
            }
        }

        //-------------------------------------------------------------
        public override DateTime? DateDebutReelle
        {
            get
            {
                if (m_projet != null)
                    return m_projet.DateDebutReel;
                return null;
            }
            set
            {
                if (m_projet != null)
                    m_projet.DateDebutReel = value;
            }
        }

        //-------------------------------------------------------------
        public override DateTime? DateFinReelle
        {
            get
            {
                if (m_projet != null)
                    return m_projet.DateFinRelle;
                return null;
            }
            set
            {
                if (m_projet != null)
                    m_projet.DateFinRelle = value;
            }
        }



        //-----------------------------------------------
        public void AddChildsTrouvesParmis(Dictionary<int, List<CProjet>> dicIdsToChilds)
        {
            List<CProjet> lstFils = null;
            if ( dicIdsToChilds.TryGetValue ( ProjetAssocie.Id, out lstFils ) )
                foreach (CProjet projet in lstFils)
                {
                    CElementDeGanttProjet eltFils = new CElementDeGanttProjet(this, projet);
                    eltFils.AddChildsTrouvesParmis(dicIdsToChilds);
                }
        }
            /*IEnumerable<CProjet> projetsFils = from p in lstProjets
                                               where p.ObjetParent != null &&
                                               p.ObjetParent.Equals(this.Projet)
                                               select p;
            foreach (CProjet prj in projetsFils)
            {
                CElementDeGanttProjet eltFils = new CElementDeGanttProjet(this, prj);
                eltFils.AddChildsTrouvesParmis(lstProjets);
            }
        }*/

        //-----------------------------------------------
        public override string ElementKey
        {
            get
            {
                if (m_projet != null && m_projet.IsValide())
                    return "PRJ_"+m_projet.Id.ToString();
                return "";
            }
        }

        //--------------------------------------------------------
        /// <summary>
        /// retourne l'identifiant de la barre de gantt associée
        /// </summary>
        public override string GanttBarId
        {
            get
            {
                if (m_projet != null)
                    return "PRJ_" + m_projet.Id.ToString();
                return "";
            }
        }


        //-----------------------------------------------
        public override void CalcPoidsSurFils(bool bRecursif)
        {
            if (ElementsFils.Count() == 0)
            {
                SetPoidSansCalculDeParent(ProjetAssocie.CalcPoidsDepuisFormule());
            }
            else
                base.CalcPoidsSurFils(bRecursif);
        }
        
        //-----------------------------------------------
        public override void CalcAvancementSurFils(bool bRecursif)
        {
            if (ElementsFils.Count() == 0)
            {
                SetPctAvancementSansCalculDeParent(ProjetAssocie.CalcProgressDepuisFormule());
            }
            else
                base.CalcAvancementSurFils(bRecursif);
        }

        //-----------------------------------------------
        
        public override bool HasWarnings
        {
            get
            {
                if (ProjetAssocie != null)
                {
                    if (ProjetAssocie.AnomaliesDuProjet.Count > 0)
                        return true;
                    foreach (IContrainteDeProjet contrainte in Contraintes)
                    {
                        if (!ProjetAssocie.RespectConstraint(contrainte))
                            return true;
                    }
                }
                return false;
            }
        }

        //-----------------------------------------------
        public override bool EstTermine
        {
            get
            {
                if (ProjetAssocie != null)
                {
                    return (ProjetAssocie.DateFinRelle != null);
                }
                return false;
            }
        }

        //-------------------------------------------------------------------------------
        public override bool DatesAuto
        {
            get
            {
                if (ProjetAssocie != null)
                {
                    if (ProjetAssocie.DateDebutReel != null || ProjetAssocie.DateFinRelle != null)
                        return false;
                    return (ProjetAssocie.DateDebutAuto);
                }
                return false;
            }
        }

        //-------------------------------------------------------------------------------
        public override IEnumerable<IContrainteDeGantt> Contraintes
        {
            get
            {
                if (m_listeContraintes == null)
                    m_listeContraintes = new List<IContrainteDeGantt>(ProjetAssocie.GetAllConstraints());
                return m_listeContraintes;
            }
            set
            {
                if (value == null)
                    m_listeContraintes = null;
                else
                    m_listeContraintes = new List<IContrainteDeGantt>(value);
            }
        }

        //-------------------------------------------------------------------------------
        public override bool CanBeSortedInParent
        {
            get
            {
                return true;
            }
        }

        //-------------------------------------------------------------------------------
        public override int IndexTri
        {
            get
            {
                if (m_projet != null)
                    return m_projet.IndexTri;
                return 0;
            }
            set
            {
                if (m_projet != null)
                    m_projet.IndexTri = value;
            }
        }

        //-------------------------------------------------------------------------------
        public override bool DrawHasGroup
        {
            get
            {
                if (m_projet != null)
                    return m_projet.HasChilds();
                return base.DrawHasGroup;
            }
        }

        //-----------------------------------------------
        public override void Draw(
            Rectangle rct,
            IFournisseurXGantt fournisseurX,
            System.Drawing.Graphics g)
        {
            base.Draw(rct, fournisseurX, g);
            if (ProjetAssocie != null && ProjetAssocie.HasChilds() && !ProjetAssocie.DateDebutAuto && 
                ProjetAssocie.DateDebutPlanifieeCalculee != null && 
                ProjetAssocie.DateFinPlanifieeCalculee != null)
            {
                Brush brFondBarre;
                if (CouleurFondBarre1 == CouleurFondBarre2)
                    brFondBarre = new SolidBrush(Color.FromArgb(128, CouleurFondBarre1));
                else
                    brFondBarre = new HatchBrush(HatchStyle.Percent50,
                        Color.FromArgb(128, CouleurFondBarre1),
                        Color.FromArgb(128, CouleurFondBarre2));

                Rectangle rctTmp = new Rectangle(
                    fournisseurX.GetX ( ProjetAssocie.DateDebutPlanifieeCalculee.Value ),
                    rct.Top + 4, 
                    fournisseurX.GetX(ProjetAssocie.DateFinPlanifieeCalculee.Value)-fournisseurX.GetX(ProjetAssocie.DateDebutPlanifieeCalculee.Value),
                    4); 
                g.FillRectangle(brFondBarre, rctTmp);
                brFondBarre.Dispose();
            }
        }



       //------------------------------------------------------------------------
        public EGanttTimeUnit UniteParDefaut
        {
            get
            {
                if (ProjetAssocie != null && ProjetAssocie.TypeProjet != null)
                    return ProjetAssocie.TypeProjet.DefaultTimeUnit;
                return EGanttTimeUnit.Semaine;
            }
            set
            {
                if (ProjetAssocie != null && ProjetAssocie.TypeProjet != null)
                {
                    CTypeProjet type = ProjetAssocie.TypeProjet;
                    type.BeginEdit();
                    type.DefaultTimeUnit = value;
                    type.CommitEdit();
                }
            }
        }

        //------------------------------------------------------------------------
        public int PrecisionParDefault
        {
            get
            {
                if (ProjetAssocie != null && ProjetAssocie.TypeProjet != null)
                    return ProjetAssocie.TypeProjet.DefaultTimePrecision;
                return 1;
            }
            set
            {
                if (ProjetAssocie != null && ProjetAssocie.TypeProjet != null)
                {
                    CTypeProjet type = ProjetAssocie.TypeProjet;
                    type.BeginEdit();
                    type.DefaultTimePrecision = value;
                    type.CommitEdit();
                }
            }
        }
    }
}
