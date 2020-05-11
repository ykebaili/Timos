using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.expression;
using sc2i.common;
using System.Drawing;
using timos.data.projet.gantt.icones;
using sc2i.expression.expressions;

namespace timos.data.projet.gantt
{
    /// <summary>
    /// Définit comment une barre de gantt est affichée (avec zone gauche et zone droite)
    /// </summary>
    public class CParametreDessinLigneGantt : I2iSerializable
    {
        //Paramètre de dessin commun aux zones gauche, droite et barre
        public class CParametreDessinGantt : I2iSerializable
        {

            //Formules sur IElementDeGantt
            private C2iExpression m_formuleText;
            private C2iExpression m_formuleCouleurText;
            private List<IParametreIconeGantt> m_icones = new List<IParametreIconeGantt>();

            public CParametreDessinGantt()
            {
            
            }
            //-------------------------------------
            public C2iExpression FormuleTexte
            {
                get
                {
                    return m_formuleText;
                }
                set
                {
                    m_formuleText = value;
                }
            }

            
            //-------------------------------------
            public C2iExpression FormuleCouleurTexte
            {
                get
                {
                    return m_formuleCouleurText;
                }
                set
                {
                    m_formuleCouleurText = value;
                }
            }

            //-----------------------------------------------------
            public IParametreIconeGantt[] ParametresIcones
            {
                get
                {
                    return m_icones.ToArray();
                }
                set
                {
                    m_icones = new List<IParametreIconeGantt>(value);
                }
            }

            //-----------------------------------------------------------------------------
            public bool NeedAvancementTheorique
            {
                get{
                    return m_icones.First(p=>p is CParametreIconeGanttRetard) != null;
                }
            }
            

            //-----------------------------------------------------------------------------
            private int GetNumVersion()
            {
                return 0;
            }

            //-----------------------------------------------------------------------------
            public virtual CResultAErreur Serialize(C2iSerializer serializer)
            {
                int nVersion = GetNumVersion();
                CResultAErreur result = serializer.TraiteVersion(ref nVersion);
                if (!result)
                    return result;
                result = serializer.TraiteObject<C2iExpression>(ref m_formuleText);
                if (result)
                    result = serializer.TraiteObject<C2iExpression>(ref m_formuleCouleurText);
                if (result)
                    result = serializer.TraiteListe<IParametreIconeGantt>(m_icones);
                return result;
            }

            //------------------------------------------------------------------------------
            protected Color ? GetCouleur ( IElementDeGantt elt, C2iExpression formule, ref bool bIsConstante )
            {
                bIsConstante = false;
                if ( formule == null )
                    return null;
                C2iExpressionColor col = formule as C2iExpressionColor;
                if ( col != null )
                {
                    List<int> valeurs = new List<int>();
                    bool bAllInt =  true;
                    foreach ( C2iExpression param in col.Parametres2i )
                    {
                        C2iExpressionConstante cst = param as C2iExpressionConstante;
                        if ( cst == null )
                        {
                            bAllInt = false;
                            break;
                        }
                        try{
                            valeurs.Add ( Convert.ToInt32(cst.Valeur) );
                        }
                        catch{
                            bAllInt = false;
                            break;
                        }
                    }
                    if ( bAllInt )
                    {
                        try
                        {
                            bIsConstante = true;
                            if (valeurs.Count == 3)
                                return Color.FromArgb(valeurs[0], valeurs[1], valeurs[2]);
                            else
                                return Color.FromArgb(valeurs[0], valeurs[1], valeurs[2], valeurs[3]);
                        }
                        catch
                        {
                            return null;
                        }
                    }
                }
                else
                {
                    if ( formule != null )
                    {
                        CContexteEvaluationExpression ctx = new CContexteEvaluationExpression ( elt );
                        CResultAErreur result = formule.Eval ( ctx );
                        if ( result && result.Data is Color )
                            return (Color)result.Data;
                    }
                }
                return null;
            }


            //-------------------------------------------------------
            private Color? m_couleurTexteAsConstante = null;
            public Color? GetCouleurTexte(IElementDeGantt element)
            {
                if (m_couleurTexteAsConstante != null)
                    return m_couleurTexteAsConstante;

                bool bIsConstante = false;
                Color? c = GetCouleur(element, FormuleCouleurTexte, ref bIsConstante);
                if (bIsConstante)
                    m_couleurTexteAsConstante = c;
                return c;
            }

            //-------------------------------------------------------
            public string GetTexte(IElementDeGantt element)
            {
                if (FormuleTexte != null)
                {
                    CContexteEvaluationExpression ctx = new CContexteEvaluationExpression(element);
                    CResultAErreur result = FormuleTexte.Eval(ctx);
                    if (result)
                        return result.Data.ToString();
                }
                return null;
            }

            //-------------------------------------------------------
            public CIconeGantt[] GetIcones(IElementDeGantt element)
            {
                List<CIconeGantt> lst = new List<CIconeGantt>();
                foreach (IParametreIconeGantt parametre in ParametresIcones)
                {
                    CIconeGantt icone = parametre.GetIcone(element);
                    if (icone != null)
                        lst.Add(icone);
                }
                return lst.ToArray();
            }           
        }

        //Parametre spécifique pour la barre
        public class CParametreDessinBarreGantt : CParametreDessinGantt
        {
            private C2iExpression m_couleurFond1;
            private C2iExpression m_couleurFond2;
            private C2iExpression m_couleurProgress;
            private C2iExpression m_couleurTerminee;


            public CParametreDessinBarreGantt()
                :base()
            {
            }

            public C2iExpression FormuleCouleurFond1
            {
                get{
                    return m_couleurFond1;
                }
                set{
                    m_couleurFond1 = value;
                }
            }

            public C2iExpression FormuleCouleurFond2
            {
                get
                {
                    return m_couleurFond2;
                }
                set
                {
                    m_couleurFond2 = value;
                }
            }

            public C2iExpression FormuleCouleurProgress
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

            public C2iExpression FormuleCouleurTerminee
            {
                get
                {
                    return m_couleurTerminee;
                }
                set
                {
                    m_couleurTerminee = value;
                }
            }

            //------------------------------------------------------------
            Color? m_couleurFond1AsConstante = null;
            public Color? GetCouleurFond1(IElementDeGantt element)
            {
                if (m_couleurFond1AsConstante != null)
                    return m_couleurFond1AsConstante;

                bool bIsConstante = false;
                Color? c = GetCouleur(element, FormuleCouleurFond1, ref bIsConstante);;
                if (bIsConstante)
                    m_couleurFond1AsConstante = c;
                return c;
            }

            //------------------------------------------------------------
            Color? m_couleurFond2AsConstante = null;
            public Color? GetCouleurFond2(IElementDeGantt element)
            {
                if (m_couleurFond2AsConstante != null)
                    return m_couleurFond2AsConstante;

                bool bIsConstante = false;
                Color? c = GetCouleur(element, FormuleCouleurFond2, ref bIsConstante); ;
                if (bIsConstante)
                    m_couleurFond2AsConstante = c;
                return c;
            }

            //------------------------------------------------------------
            Color? m_couleurProgressAsConstante = null;
            public Color? GetCouleurProgress(IElementDeGantt element)
            {
                if (m_couleurProgressAsConstante != null)
                    return m_couleurProgressAsConstante;

                bool bIsConstante = false;
                Color? c = GetCouleur(element, FormuleCouleurProgress, ref bIsConstante); ;
                if (bIsConstante)
                    m_couleurProgressAsConstante = c;
                return c;
            }

            //------------------------------------------------------------
            Color? m_couleurTermineeAsConstante = null;
            public Color? GetCouleurTerminee(IElementDeGantt element)
            {
                if (m_couleurTermineeAsConstante != null)
                    return m_couleurTermineeAsConstante;

                bool bIsConstante = false;
                Color? c = GetCouleur(element, FormuleCouleurTerminee, ref bIsConstante); ;
                if (bIsConstante)
                    m_couleurTermineeAsConstante= c;
                return c;
            }

            //------------------------------------------------------------
            private int GetNumVersion()
            {
                return 1;
                //1 : ajout de couleur terminée
            }

            public override CResultAErreur Serialize(C2iSerializer serializer)
            {
                int nVersion = GetNumVersion();
                CResultAErreur result = serializer.TraiteVersion(ref nVersion);
                if (result)
                    result = base.Serialize(serializer);
                if (!result)
                    return result;
                result = serializer.TraiteObject<C2iExpression>(ref m_couleurFond1);
                if (result)
                    result = serializer.TraiteObject<C2iExpression>(ref m_couleurFond2);
                if (result)
                    result = serializer.TraiteObject<C2iExpression>(ref m_couleurProgress);
                if (result)
                {
                    if (nVersion >= 1)
                        result = serializer.TraiteObject<C2iExpression>(ref m_couleurTerminee);
                    else
                    {
                        if (serializer.Mode == ModeSerialisation.Lecture)
                        {
                            C2iExpressionColor c = new C2iExpressionColor();
                            c.Parametres.Add(new C2iExpressionConstante(0));
                            c.Parametres.Add(new C2iExpressionConstante(255));
                            c.Parametres.Add(new C2iExpressionConstante(0));
                            m_couleurTerminee = c;
                        }
                    }
                }
                
                return result;
            }

        }

        private CParametreDessinGantt m_parametreDessinZoneGauche = new CParametreDessinGantt();
        private CParametreDessinGantt m_parametreDessinZoneDroite = new CParametreDessinGantt();
        private CParametreDessinBarreGantt m_parametreDessinBarre = new CParametreDessinBarreGantt();

        private int m_nHauteurLigne = 20;
        private C2iExpression m_formuleDateDebut = null;
        private C2iExpression m_formuleDateFin = null;

        //-------------------------------------------------------------------------
        public CParametreDessinLigneGantt()
        {
            
        }

        //---------------------------------------------------------------------
        public bool NeedAvancementTheorique
        {
            get
            {
                return m_parametreDessinBarre.NeedAvancementTheorique ||
                    m_parametreDessinZoneDroite.NeedAvancementTheorique ||
                    m_parametreDessinZoneGauche.NeedAvancementTheorique;
            }
        }

        //---------------------------------------------------------------------
        public static CParametreDessinLigneGantt ParametreParDefaut
        {
            get
            {
                // Création d'un paramétrage par défaut
                CParametreDessinLigneGantt parametreDefaut = new CParametreDessinLigneGantt();
                parametreDefaut.HauteurLigne = 22;

                // Zone de gauche
                parametreDefaut.m_parametreDessinZoneGauche.FormuleTexte = new C2iExpressionChamp(
                    new CDefinitionProprieteDynamiqueDotNet("Label", "Libelle",
                        new CTypeResultatExpression(typeof(string), false),
                        false, false, ""));
                List<IParametreIconeGantt> lst = new List<IParametreIconeGantt>();
                lst.Add(new CParametreIconeGanttAuto());
                parametreDefaut.m_parametreDessinZoneGauche.ParametresIcones = lst.ToArray();
                
                // Zone de droite
                lst = new List<IParametreIconeGantt>();
                lst.Add(new CParametreIconeGanttWarning());
                lst.Add(new CParametreIconeGanttRetard());
                lst.Add(new CParametreIconeGanttTermine());
                parametreDefaut.m_parametreDessinZoneDroite.ParametresIcones = lst.ToArray();

                // Barre principale
                C2iExpressionChamp expAvancement = new C2iExpressionChamp(
                    new CDefinitionProprieteDynamiqueDotNet("Progress", "PctAvancement",
                    new CTypeResultatExpression(typeof(string), false),
                    false, false, ""));

                C2iExpressionEntier expAvancementInt = new C2iExpressionEntier();
                expAvancementInt.Parametres.Add(expAvancement);
                C2iExpressionConstante expPourcent = new C2iExpressionConstante(" %");
                C2iExpressionPlus formuleTexte = new C2iExpressionPlus();
                formuleTexte.Parametres.Add(expAvancementInt);
                formuleTexte.Parametres.Add(expPourcent);

                parametreDefaut.m_parametreDessinBarre.FormuleTexte = formuleTexte;
                parametreDefaut.m_parametreDessinBarre.FormuleCouleurTexte = GetFormuleCouleur(0, 0, 0);
                parametreDefaut.m_parametreDessinBarre.FormuleCouleurProgress = GetFormuleCouleur(255, 0, 0);
                parametreDefaut.m_parametreDessinBarre.FormuleCouleurFond1 = GetFormuleCouleur(70, 154, 255);
                parametreDefaut.m_parametreDessinBarre.FormuleCouleurFond2 = GetFormuleCouleur(70, 154, 255);
                parametreDefaut.m_parametreDessinBarre.FormuleCouleurTerminee = GetFormuleCouleur(0, 255, 0);

                return parametreDefaut;
            }
        }
        
        
        
        //---------------------------------------------------------------------
        public static C2iExpression GetFormuleCouleur(int r, int g, int b)
        {
            C2iExpressionColor co = new C2iExpressionColor();
            co.Parametres.Add(new C2iExpressionConstante(r));
            co.Parametres.Add(new C2iExpressionConstante(g));
            co.Parametres.Add(new C2iExpressionConstante(b));
            return co;
        }

        //---------------------------------------------------------------------
        public CParametreDessinGantt ParametreZoneGauche
        {
            get
            {
                return m_parametreDessinZoneGauche;
            }
            set
            {
                m_parametreDessinZoneGauche = value;
            }
        }

        //--------------------------------------------
        public CParametreDessinGantt ParametreZoneDroite
        {
            get
            {
                return m_parametreDessinZoneDroite;
            }
            set
            {
                m_parametreDessinZoneDroite = value;
            }
        }

        //--------------------------------------------
        public CParametreDessinBarreGantt ParametreBarre
        {
            get
            {
                return m_parametreDessinBarre;
            }
            set
            {
                m_parametreDessinBarre = value;
            }
        }

        //--------------------------------------------
        public int HauteurLigne
        {
            get
            {
                return m_nHauteurLigne;
            }
            set
            {
                m_nHauteurLigne = value;
            }
        }

        //--------------------------------------------
        public C2iExpression FormuleDateDebut 
        {
            get
            {
                return m_formuleDateDebut;
            }
            set
            {
                m_formuleDateDebut = value;
            }
        }

        //--------------------------------------------
        public C2iExpression FormuleDateFin
        {
            get
            {
                return m_formuleDateFin;
            }
            set
            {
                m_formuleDateFin = value;
            }
        }

        //----------------------------------------------------------------------------------
        public DateTime? GetDateFromExpression(IElementDeGantt element, C2iExpression formule)
        {
            if (formule != null)
            {
                CContexteEvaluationExpression ctx = new CContexteEvaluationExpression(element);
                CResultAErreur result = formule.Eval(ctx);
                if (result && result.Data is DateTime)
                    return (DateTime)result.Data;
            }
            return null;
        }

        //----------------------------------------------------------------------------------
        public DateTime? GetDateDebut(IElementDeGantt element)
        {
            return GetDateFromExpression(element, FormuleDateDebut);
        }
        
        //----------------------------------------------------------------------------------
        public DateTime? GetDateFin(IElementDeGantt element)
        {
            return GetDateFromExpression(element, FormuleDateFin);
        }

        //----------------------------------------------------------------------------------
        private int GetNumVersion()
        {
            //return 0;
            return 1; // Ajout des formules de date début et date fin
        }

        //------------------------------------------------------------------------------------
        public CResultAErreur Serialize ( C2iSerializer serializer )
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            result = serializer.TraiteObject<CParametreDessinBarreGantt>(ref m_parametreDessinBarre);
            if (result)
                result = serializer.TraiteObject<CParametreDessinGantt>(ref m_parametreDessinZoneGauche);
            if (result)
                result = serializer.TraiteObject<CParametreDessinGantt>(ref m_parametreDessinZoneDroite);
            serializer.TraiteInt(ref m_nHauteurLigne);

            if(nVersion >= 1)
            {
                if (result)
                    result = serializer.TraiteObject<C2iExpression>(ref m_formuleDateDebut);
                if (result)
                    result = serializer.TraiteObject<C2iExpression>(ref m_formuleDateFin);
            }

            return result;
        }
    }
}
