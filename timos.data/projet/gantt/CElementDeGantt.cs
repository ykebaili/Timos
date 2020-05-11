using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using sc2i.common;
using timos.data.projet.Contraintes;

namespace timos.data.projet.gantt
{
    /// <summary>
    /// Base pour les éléments de Gantt
    /// La gestion des fils se fait uniquement avec la propriete ElementParent
    /// qui se charge de gérer l'ajout et la suppression de la liste des fils
    /// </summary>
    public abstract class CElementDeGantt : IElementDeGantt, IDisposable
    {
        private IElementDeGantt m_elementParent = null;

        private HashSet<IElementDeGantt> m_listePredecesseurs = new HashSet<IElementDeGantt>();
        private List<IElementDeGantt> m_listeFils = new List<IElementDeGantt>();
        private List<IContrainteDeGantt> m_listeContraintes = new List<IContrainteDeGantt>();

        private bool m_bDatesDirty = true;


        private double m_fPoids = 1;
        private double m_fAvancement = 0;

        private Image m_image = null;

        private CIconeGantt[] m_iconesGauche = null;
        private CIconeGantt[] m_iconesDroite = null;
        private CIconeGantt[] m_iconesBarre = null;

        private Color m_couleurFondBarre1 = Color.Blue;
        private Color m_couleurFondBarre2 = Color.Blue;
        private Color m_couleurProgress = Color.Yellow;
        private Color m_couleurTexteBarre = Color.Black;
        private Color m_couleurTexteGauche = Color.Black;
        private Color m_couleurTexteDroite = Color.Black;

        private string m_strLibelleGauche = "";
        private string m_strLibelleDroite = "";
        private string m_strLibelleBarre = "";

        //------------------------------------------------------
        public CElementDeGantt(IElementDeGantt elementParent)
        {
            ElementParent = elementParent;
        }

        

        //------------------------------------------------------
        public virtual bool DatesAreDirty
        {
            get
            {
                return m_bDatesDirty;
            }
            set
            {
                m_bDatesDirty = value;
                if (value && ElementParent != null)
                    ElementParent.DatesAreDirty = true;
            }
        }

        //------------------------------------------------------
        CParametreDessinLigneGantt m_parametreAAppliquer = null;
        public virtual void AppliqueParametrageDessin(CParametreDessinLigneGantt parametre)
        {
            if (parametre == null)
                return;
            m_parametreAAppliquer = parametre;
        }

        //------------------------------------------------------
        private void AppliqueParametreDessin ()
        {
            if (m_parametreAAppliquer == null)
                return;
            CParametreDessinLigneGantt parametre = m_parametreAAppliquer;
            m_parametreAAppliquer = null;
            // Parametres de la barre centrale
            Color? couleur = parametre.ParametreBarre.GetCouleurFond1(this);
            if (couleur != null)
                CouleurFondBarre1 = couleur.Value;
            else
                CouleurFondBarre1 = Color.Blue;
            
            couleur = parametre.ParametreBarre.GetCouleurFond2(this);
            if (couleur != null)
                CouleurFondBarre2 = couleur.Value;
            else
                CouleurFondBarre2 = CouleurFondBarre1;

            couleur = parametre.ParametreBarre.GetCouleurProgress(this);
            if (couleur != null)
                CouleurProgress = couleur.Value;
            else
                CouleurProgress = Color.Yellow;


            couleur = parametre.ParametreBarre.GetCouleurTexte(this);
            if (couleur != null)
                CouleurTexteBarre = couleur.Value;
            else
                CouleurTexteBarre = Color.Black;

            string strLib = parametre.ParametreBarre.GetTexte(this);
            if (strLib != null)
                LibelleBarre = strLib;
            else
                LibelleBarre = "";

            // Icones de la barre centrale
            IconesBarre = parametre.ParametreBarre.GetIcones(this);

            // Parametres de la zone gauche
            strLib = parametre.ParametreZoneGauche.GetTexte(this);
            if (strLib != null)
            {
                LibelleGauche = strLib;
                couleur = parametre.ParametreZoneGauche.GetCouleurTexte(this);
                if (couleur != null)
                    CouleurTexteGauche = couleur.Value;
                else
                    CouleurTexteGauche = Color.Black;
            }
            else
                LibelleGauche = "";
            IconesGauche = parametre.ParametreZoneGauche.GetIcones(this);

            // Parametres de la zone droite
            strLib = parametre.ParametreZoneDroite.GetTexte(this);
            if (strLib != null)
            {
                LibelleDroite = strLib;
                couleur = parametre.ParametreZoneDroite.GetCouleurTexte(this);
                if (couleur != null)
                    CouleurTexteDroite = couleur.Value;
                else
                    CouleurTexteDroite = Color.Black;
            }
            else
                LibelleDroite = "";

            IconesDroite = parametre.ParametreZoneDroite.GetIcones(this);

            /*foreach (IElementDeGantt elementFils in ElementsFils)
                elementFils.AppliqueParametrageDessin(parametre);*/


        }

        //------------------------------------------------------
        public string LibelleBarre
        {
            get
            {
                return m_strLibelleBarre;
            }
            set
            {
                m_strLibelleBarre = value;
            }
        }

        public abstract string Libelle { get;}
        public abstract DateTime DateDebut { get; set; }
        public abstract DateTime DateFin { get; set; }
        public abstract DateTime? DateDebutReelle { get; set; }
        public abstract DateTime? DateFinReelle { get; set; }

        //------------------------------------------------------
        public virtual DateTime DateDebutPourParent
        {
            get
            {
                return DateDebut;
            }
        }

        //------------------------------------------------------
        public virtual DateTime DateFinPourParent
        {
            get
            {
                return DateFin;
            }
        }

        //------------------------------------------------------
        //public virtual CProjet ProjetAssocie
        //{
        //    get
        //    {
        //        return null;
        //    }
        //}

        //------------------------------------------------------
        public double PctAvancement
        {
            get
            {
                return m_fAvancement;
            }
            set
            {
                m_fAvancement = value;
                CElementDeGantt parentGantt = ElementParent as CElementDeGantt;
                if (parentGantt != null)
                    parentGantt.CalcAvancementSurFils( false );
            }
        }

        //------------------------------------------------------
        protected void SetPctAvancementSansCalculDeParent ( double fValue )
        {
            m_fAvancement = fValue;
        }


        //------------------------------------------------------
        public double Poids
        {
            get
            {
                return m_fPoids;
            }
            set
            {
                m_fPoids = value;
                CElementDeGantt parentGantt = ElementParent as CElementDeGantt;
                if (parentGantt != null)
                    parentGantt.CalcPoidsSurFils( false );
            }
        }

        //------------------------------------------------------
        protected void SetPoidSansCalculDeParent(double fValue)
        {
            m_fPoids = fValue;
        }


        public abstract string ElementKey { get; }
        public abstract string GanttBarId { get; }

        //------------------------------------------------------
        public IEnumerable<IElementDeGantt> Predecesseurs
        {
            get
            {
                return m_listePredecesseurs.ToArray();
            }
        }

        //------------------------------------------------------
        public virtual IEnumerable<IContrainteDeGantt> Contraintes
        {
            get
            {
                return new IContrainteDeGantt[0];
            }
            set
            {
            }
        }

        
        //------------------------------------------------------
        public Image Image
        {
            get
            {
                return m_image;
            }
            set
            {
                if (m_image != null)
                    m_image.Dispose();
                m_image = null;
                if (value != null)
                {
                    m_image = value.Clone() as Image;
                }
                else
                    m_image = null;
            }
        }

        //------------------------------------------------------
        public virtual void CalcAvancementSurFils(bool bRecursif)
        {
            if (ElementsFils.Count() == 0)
                return;
            double fSomme = 0;
            foreach (CElementDeGantt projetFils in ElementsFils)
            {
                if (bRecursif)
                    projetFils.CalcAvancementSurFils(true);
                fSomme += projetFils.PctAvancement*projetFils.Poids;
            }
            double fPoids = Poids;
            if (fPoids != 0)
                m_fAvancement = fSomme / fPoids;
        }

        //------------------------------------------------------
        public virtual void CalcPoidsSurFils( bool bRecursif)
        {
            m_fPoids = 1.0;
            double fPoids = 0;
            foreach (CElementDeGantt projetFils in ElementsFils)
            {
                if (bRecursif)
                    projetFils.CalcPoidsSurFils(bRecursif);
                fPoids += projetFils.Poids;
            }
            m_fPoids = fPoids;
        }

        //------------------------------------------------------
        public virtual void RecalculAvancement()
        {
            CalcPoidsSurFils(true);
            CalcAvancementSurFils(true);
        }


        //------------------------------------------------------
        public void AddPredecesseurSansCreation(IElementDeGantt element)
        {
            m_listePredecesseurs.Add(element);
            /*if ( !m_listePredecesseurs.Contains ( element ))
                m_listePredecesseurs.Add(element);*/
        }

        //------------------------------------------------------
        /// <summary>
        /// Ajoute un predecesseur et crée le lien projet
        /// </summary>
        /// <param name="element"></param>
        public CResultAErreur AddPredecesseur(IElementDeGantt element)
        {
            CResultAErreur result = CResultAErreur.True;
            if (!m_listePredecesseurs.Contains(element))
            {
                CElementDeGanttProjet eltThis = this as CElementDeGanttProjet;
                CElementDeGanttProjet eltPredecesseur = element as CElementDeGanttProjet;
                if (eltThis != null && eltPredecesseur != null)
                {

                    CLienDeProjet lien = eltThis.ProjetAssocie.AddPredecessor(eltPredecesseur.ProjetAssocie);
                    if (lien != null)
                    {
                        m_listePredecesseurs.Add(eltPredecesseur);
                    }
                        /*new CLienDeProjet(eltThis.ProjetAssocie.ContexteDonnee);
                    lien.CreateNewInCurrentContexte();
                    lien.ProjetA = eltPredecesseur.ProjetAssocie;
                    lien.ProjetB = eltThis.ProjetAssocie;
                    result = lien.ControleCoherenceLien();
                    if (!result)
                        lien.CancelCreate();
                    else
                        m_listePredecesseurs.Add(element);
                    eltPredecesseur.ProjetAssocie.OptimizeDates(eltPredecesseur.ProjetAssocie.DateDebutGantt);*/
                }
            }
            return result;
        }

        //------------------------------------------------------
        public void RemovePredecesseur(IElementDeGantt element)
        {
            //supprime le lien projet
            CElementDeGanttProjet predecesseur = element as CElementDeGanttProjet;
            CElementDeGanttProjet thisProjet = this as CElementDeGanttProjet;
            if (predecesseur != null && thisProjet != null)
            {
                //Trouve le lien
                foreach (CLienDeProjet lien in predecesseur.ProjetAssocie.LiensDeProjetAttaches)
                {
                    if ((lien.ProjetA == predecesseur.ProjetAssocie && lien.ProjetB == thisProjet.ProjetAssocie) ||
                        lien.ProjetB == predecesseur.ProjetAssocie && lien.ProjetA == thisProjet.ProjetAssocie)
                    {
                        if (!lien.Delete(true))
                            return;
                        break;
                    }
                }
            }
            m_listePredecesseurs.Remove ( element );
        }


        //------------------------------------------------------
        public IEnumerable<IElementDeGantt> ElementsFils
        {
            get 
            { 
                return m_listeFils.AsReadOnly();
            }
        }

        //------------------------------------------------------
        protected virtual void AddFils(CElementDeGantt elt)
        {
         
            if ( !m_listeFils.Contains ( elt ) )
                m_listeFils.Add(elt);
        }

        //------------------------------------------------------
        protected void RemoveFils ( CElementDeGantt elt )
        {
            m_listeFils.Remove ( elt );
        }

        //------------------------------------------------------
        public IElementDeGantt ElementParent
        {
            get
            {
                return m_elementParent;
            }
            set
            {
                if ( m_elementParent != value && m_elementParent != null)
                    ((CElementDeGantt)m_elementParent).RemoveFils( this );
                m_elementParent = value;
                if (m_elementParent != null)
                    ((CElementDeGantt)m_elementParent).AddFils(this);
            }
        }

        //------------------------------------------------------
        public double DureeHeures
        {
            get
            {
                return ((TimeSpan)(DateFin - DateDebut)).TotalHours;
            }
        }

        
        

        //------------------------------------------------------
        public virtual bool DrawHasGroup
        {
            get
            {
                return ElementsFils.Count() > 0;
            }
        }

        //------------------------------------------------------
        public virtual void Draw(
            Rectangle rct,
            IFournisseurXGantt fournisseurX, 
            System.Drawing.Graphics g)
        {
            AppliqueParametreDessin();
            Font ft = new Font("System", 7);
            if (!g.ClipBounds.IntersectsWith(rct))
                return;
            Brush br = null;
            Brush brFondBarre;
            
            if ( CouleurFondBarre1 == CouleurFondBarre2 )
                brFondBarre = new SolidBrush ( CouleurFondBarre1 );
            else
                brFondBarre = new HatchBrush(HatchStyle.Percent50, CouleurFondBarre1, CouleurFondBarre2);
            Rectangle rctBarre = rct;

            //Zone centrale
            if (!DrawHasGroup)//Gantt classique
            {
                if (DateDebut == DateFin)//Jalon
                {
                    rctBarre = new Rectangle(rct.Left - 5, rct.Top, 10, 10);
                    g.FillEllipse(brFondBarre, rctBarre);
                }
                else
                {
                    g.FillRectangle(brFondBarre, rct);
                    g.DrawRectangle(Pens.Black, rct);
                    br = new SolidBrush(CouleurProgress);
                    Rectangle rctProgress = rct;
                    rctProgress = new Rectangle(rctProgress.Left, rctProgress.Top + (rctProgress.Height/2 - 2),
                        rctProgress.Width, 4);
                    rctProgress.Width = (int)(rct.Width * PctAvancement / 100);
                    g.FillRectangle(br, rctProgress);
                    br.Dispose();
                }
            }
            else//Regroupement
            {
                Pen pen = new Pen(CouleurFondBarre1);
                g.FillRectangle(brFondBarre, new Rectangle(rct.Left, rct.Top, rct.Size.Width, 4));
                Point[] pts = new Point[]{
                    new Point(rct.Left, rct.Top),
                    new Point ( rct.Left, rct.Bottom),
                    new Point ( rct.Left + 8, rct.Top)};
                g.DrawPolygon(pen, pts);
                g.FillPolygon(brFondBarre, pts);
                pts = new Point[]{
                    new Point(rct.Right, rct.Top),
                    new Point ( rct.Right, rct.Bottom),
                    new Point ( rct.Right - 8, rct.Top)};
                g.DrawPolygon(pen, pts);
                g.FillPolygon(brFondBarre, pts);
                br = new SolidBrush(CouleurProgress);
                Rectangle rctProgress = rct;
                rctProgress.Width = (int)(rct.Width * PctAvancement / 100);
                rctProgress.Height = 2;
                rctProgress.Offset(0, 1);
                g.FillRectangle(br, rctProgress);
                br.Dispose();
            }
            
            Rectangle rctLibelleBarre = DrawIcones ( g, IconesBarre, rctBarre, false );
            
            //Libellé de la barre
            if (LibelleBarre != "")
            {
                SizeF szTmp = g.MeasureString(LibelleBarre, ft);
                szTmp = new SizeF ( Math.Min ( szTmp.Width, rctBarre.Width), Math.Min(szTmp.Height, rctBarre.Height ));

                br = new SolidBrush(Color.Transparent);
                Rectangle rctLibelle = new Rectangle ( rctBarre.Left + (rctBarre.Width - (int)szTmp.Width)/2, 
                    rctBarre.Top + ( rctBarre.Height - (int)szTmp.Height)/2, (int)szTmp.Width, (int)szTmp.Height );
                rctLibelle.Inflate(2, 0);
                g.FillRectangle(br, rctLibelle);
                br.Dispose();
                br = new SolidBrush(CouleurTexteBarre);
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                g.DrawString(LibelleBarre, ft, br, rctLibelle, sf);
                br.Dispose();
            }
            /*if ( DureeHeures != 0 )
            {
                if ( AvancementTheorique > PctAvancement )
                {
                    Image alerte = Resource.exclamation_rect;
                    g.DrawImageUnscaled ( alerte, new Point ( rct.Right+2, rct.Top+(rct.Height-alerte.Height)/2-1));
                    alerte.Dispose();
                }
            }*/
            //Affichage du pct avancement
            /*
            Brush brFond = new SolidBrush(Color.FromArgb(255, 255, 255));
            string strPct = PctAvancement.ToString("00")+" %";
            SizeF sz = g.MeasureString(strPct, ft);
            Point ptCenter = new Point ( rct.Left+(rct.Width-(int)(sz.Width))/2,
                rct.Top+(rct.Height-(int)sz.Height)/2 );
            g.FillRectangle ( brFond, new Rectangle ( ptCenter.X, ptCenter.Y,
                (int)sz.Width, (int)sz.Height ));
            g.DrawString ( strPct, ft, Brushes.Black, ptCenter);
            brFond.Dispose();
            */
            //Affichage zone de gauche
            Rectangle rctGauche = new Rectangle(0, rctBarre.Top, rctBarre.Left-2, rctBarre.Height);
            rctGauche = DrawIcones(g, IconesGauche, rctGauche, false);
            if (LibelleGauche != "")
            {
                br = new SolidBrush(CouleurTexteGauche);
                StringFormat sf = new StringFormat(StringFormatFlags.DirectionRightToLeft | StringFormatFlags.NoWrap);
                g.DrawString(LibelleGauche, ft, br, rctGauche, sf);
                br.Dispose();
            }

            //Affichage zone de droite
            Rectangle rctDroite = new Rectangle(rctBarre.Right+2, rctBarre.Top, 1000, rctBarre.Height);
            rctDroite = DrawIcones(g, IconesDroite, rctDroite, true);
            if (LibelleDroite != "")
            {
                br = new SolidBrush(CouleurTexteDroite);
                g.DrawString(LibelleDroite, ft, br, rctDroite);
                br.Dispose();
            }
            ft.Dispose();

            brFondBarre.Dispose();

            
        }

        private Rectangle DrawIcones(Graphics g, CIconeGantt[] icones, Rectangle bounds, bool bLeft)
        {
            Rectangle zoneRestante = bounds;
            if (icones == null)
                return bounds;
            foreach (CIconeGantt icone in icones)
            {
                Size sz = icone.Image.Size;
                if (sz.Height > bounds.Height)
                    sz = new Size(16, 16);
               
                Rectangle rctImage = new Rectangle(
                    bLeft ? zoneRestante.Left : zoneRestante.Right - sz.Width, zoneRestante.Top + zoneRestante.Height / 2 - sz.Height/2,
                    sz.Width, sz.Height);
                g.DrawImage(icone.Image, rctImage);
                if (bLeft)
                    zoneRestante = new Rectangle(zoneRestante.Left + sz.Width, zoneRestante.Top, zoneRestante.Width - sz.Width+1, zoneRestante.Height);
                else
                    zoneRestante = new Rectangle(zoneRestante.Left, zoneRestante.Top, zoneRestante.Width - sz.Width+1, zoneRestante.Height);
            }
            return zoneRestante;
        }


        //------------------------------------------------------
        public bool RespectePredecesseur(IElementDeGantt predecesseur)
        {
            if (DateDebut < predecesseur.DateFin)
                return false;
            return true;
        }


        //------------------------------------------------------
        public abstract void Move(
            TimeSpan spDeplacement, 
            TimeSpan ? duree,
            EModeDeplacementProjet mode,
            bool bForceForThisElement);
        

        //------------------------------------------------------
        public abstract bool HasWarnings{get;}

        //------------------------------------------------------
        public Color CouleurTexteDroite
        {
            get
            {
                return m_couleurTexteDroite;
            }
            set
            {
                m_couleurTexteDroite = value;
            }
        }

        //------------------------------------------------------
        public Color CouleurTexteGauche
        {
            get
            {
                return m_couleurTexteGauche;
            }
            set
            {
                m_couleurTexteGauche = value;
            }
        }

        //------------------------------------------------------
        public Color CouleurTexteBarre
        {
            get
            {
                return m_couleurTexteBarre;
            }
            set
            {
                m_couleurTexteBarre = value;
            }
        }

        //------------------------------------------------------
        public Color CouleurFondBarre1
        {
            get{
                return m_couleurFondBarre1;
            }
            set{
                m_couleurFondBarre1 = value;
            }
        }

        //------------------------------------------------------
        public Color CouleurFondBarre2
        {
            get
            {
                return m_couleurFondBarre2;
            }
            set
            {
                m_couleurFondBarre2 = value;
            }
        }

        //------------------------------------------------------
        public Color CouleurProgress
        {
            get
            {
                return m_couleurProgress;
            }
            set
            {
                m_couleurProgress = value;
            }
        }

        //------------------------------------------------------
        public CIconeGantt[] IconesGauche
        {
            get
            {
                return m_iconesGauche;
            }
            set
            {
                m_iconesGauche = value;
            }
        }

        //------------------------------------------------------
        public CIconeGantt[] IconesDroite
        {
            get
            {
                return m_iconesDroite;
            }
            set
            {
                m_iconesDroite = value;
            }
        }

        //------------------------------------------------------
        public CIconeGantt[] IconesBarre
        {
            get
            {
                return m_iconesBarre;
            }
            set
            {
                m_iconesBarre = value;
            }
        }

        //------------------------------------------------------
        public string LibelleGauche
        {
            get
            {
                return m_strLibelleGauche;
            }
            set
            {
                m_strLibelleGauche = value;
            }
        }

        //------------------------------------------------------
        public string LibelleDroite
        {
            get
            {
                return m_strLibelleDroite;
            }
            set
            {
                m_strLibelleDroite = value;
            }
        }


        //------------------------------------------------------
        public virtual bool EstTermine
        {
            get
            {
                return false;
            }
        }

        //-----------------------------------------------
        public virtual bool DatesAuto
        {
            get
            {
                return false;
            }
        }

        //-----------------------------------------------
        /// <summary>
        /// Si true, indique que l'élément a un index lui permettant d'être
        /// trié dans son parent
        /// </summary>
        public virtual bool CanBeSortedInParent
        {
            get
            {
                return false;
            }
        }


        //-----------------------------------------------
        /// <summary>
        /// Index de l'élément dans son parent
        /// </summary>
        public virtual int IndexTri
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }

        #region IDisposable Membres

        public void Dispose()
        {
            if (m_image != null)
            {
                m_image.Dispose();
                m_image = null;
            }
        }

        #endregion


        //-----------------------------------------------
        public void SortChilds(CParametreTriGantt parametre)
        {
            if (parametre == null)
                parametre = new CParametreTriGantt();
            m_listeFils.Sort( parametre );
        }

        //------------------------------------------------------
        [DynamicField("Associated project")]
        public virtual CProjet ProjetAssocie
        {
            get
            {
                return null;
            }
        }

        //------------------------------------------------------
        public virtual bool MoveAutorise
        {
            get
            {
                return true;
            }
        }

        //------------------------------------------------------
        public void RegroupeBarresEnMulti()
        {
            //trouve les idgantt avec plusieurs projets
            Dictionary<string, List<CElementDeGanttProjet>> dicMultiToProjets = new Dictionary<string, List<CElementDeGanttProjet>>();
            foreach ( IElementDeGantt elt in ElementsFils.ToArray() )
            {
                CElementDeGanttProjet eltPrj = elt as CElementDeGanttProjet;
                if ( eltPrj != null && eltPrj.ProjetAssocie.GanttId.Length > 0 )
                {
                    List<CElementDeGanttProjet> lst = null;
                    if ( !dicMultiToProjets.TryGetValue ( eltPrj.ProjetAssocie.GanttId, out lst ) )
                    {
                        lst = new List<CElementDeGanttProjet>();
                        dicMultiToProjets[eltPrj.ProjetAssocie.GanttId] = lst;
                    }
                    lst.Add ( eltPrj );
                }
            }


            Dictionary<string, CElementDeGanttMulti> dicMultis = new Dictionary<string,CElementDeGanttMulti>();
            foreach ( List<CElementDeGanttProjet> lstPrjs in dicMultiToProjets.Values )
            {
                if ( lstPrjs.Count > 1 )
                {
                    foreach (CElementDeGanttProjet eltProjet in lstPrjs)
                    {
                        CElementDeGanttMulti eltMulti = null;
                        if (!dicMultis.TryGetValue(eltProjet.ProjetAssocie.GanttId, out eltMulti))
                        {
                            eltMulti = new CElementDeGanttMulti(this, eltProjet.Libelle, eltProjet.ProjetAssocie.GanttId);
                            dicMultis[eltProjet.ProjetAssocie.GanttId] = eltMulti;

                        }
                        //Ajoute le fils
                        eltMulti.AddElementDeLaLigne(eltProjet);
                        eltProjet.ElementParent = null;
                        foreach (IElementDeGantt eltFils in eltProjet.ElementsFils.ToArray())
                        {
                            eltFils.ElementParent = eltMulti;
                        }
                    }
                }
            }

            //Regroupe les barres des fils
            foreach ( IElementDeGantt elt in ElementsFils.ToArray() )
            {
                elt.RegroupeBarresEnMulti();
            }
        }

        //------------------------------------------------------------------
        public virtual IEnumerable<IElementDeGantt> ElementsADessinerSurLaLigne
        {
            get
            {
                return new IElementDeGantt[] { this };
            }
        }

    }
}
