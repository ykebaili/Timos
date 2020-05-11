using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using sc2i.common;
using sc2i.expression;
using System.Drawing;
using sc2i.formulaire;

namespace futurocom.supervision.alarmes
{
    public class CParametreAffichageListeAlarmes : I2iSerializable
    {
        private int m_nItemHeight = 22;
        private int m_nRowHeaderWidth = 15;
        private int m_nColumnHeaderHeight = 22;
        private C2iExpression m_formuleFiltreListe = null;
        private C2iExpression m_formuleSurNouvelleAlarme = null;
        private C2iExpression m_formuleItemForeColor = null;
        private C2iExpression m_formuleItemBackColor = null;
        private int m_fDureePersistanceAlarmesRetombees = 10; // En minutes

        private List<CColonneAlarmeAffichee> m_listeColonnes = new List<CColonneAlarmeAffichee>();


        public CParametreAffichageListeAlarmes()
        {

        }

        //------------------------------------------------------------------------------
        public int HauteurLigne
        {
            get
            {
                return m_nItemHeight;
            }
            set
            {
                m_nItemHeight = value;
            }
        }

        //------------------------------------------------------------------------------
        public int LargeurEnteteLigne
        {
            get
            {
                return m_nRowHeaderWidth;
            }
            set
            {
                m_nRowHeaderWidth = value;
            }
        }

        //------------------------------------------------------------------------------
        public int HauteurEnteteColonne
        {
            get
            {
                return m_nColumnHeaderHeight;
            }
            set
            {
                m_nColumnHeaderHeight = value;
            }
        }

        //------------------------------------------------------------------------------
        public C2iExpression FormuleFiltre
        {
            get
            {
                return m_formuleFiltreListe;
            }
            set
            {
                m_formuleFiltreListe = value;
            }
        }

        //------------------------------------------------------------------------------
        public C2iExpression FormuleOnNewAlarme
        {
            get
            {
                return m_formuleSurNouvelleAlarme;
            }
            set
            {
                m_formuleSurNouvelleAlarme = value;
            }
        }

        //------------------------------------------------------------------------------
        public C2iExpression FormuleItemForeColor
        {
            get
            {
                return m_formuleItemForeColor;
            }
            set
            {
                m_formuleItemForeColor = value;
            }
        }

        //------------------------------------------------------------------------------
        public C2iExpression FormuleItemBackColor
        {
            get
            {
                return m_formuleItemBackColor;
            }
            set
            {
                m_formuleItemBackColor = value;
            }
        }

        //------------------------------------------------------------------------------
        public int DureePersistanceAlarmesRetombees
        {
            get
            {
                return m_fDureePersistanceAlarmesRetombees;
            }
            set
            {
                m_fDureePersistanceAlarmesRetombees = value;
            }
        }

        //------------------------------------------------------------------------------
        public List<CColonneAlarmeAffichee> Colonnes
        {
            get
            {
                return m_listeColonnes;
            }
            set
            {
                m_listeColonnes = value;
            }
        }

        //------------------------------------------------------------------------------
        public static CParametreAffichageListeAlarmes ParametreParDefaut
        {
            get
            {
                CParametreAffichageListeAlarmes parametre = new CParametreAffichageListeAlarmes();
                parametre.m_nRowHeaderWidth = 15;
                parametre.m_nItemHeight = 22;
                parametre.m_formuleFiltreListe = new C2iExpressionVrai();
                parametre.m_formuleSurNouvelleAlarme = null;

                // Colonnes par défaut
                parametre.SetDefaultColumns();

                return parametre;
            }
        }

        //------------------------------------------------------------------------
        private void SetDefaultColumns()
        {
            m_listeColonnes.Clear();

            CColonneAlarmeAffichee colonneLibelle = new CColonneAlarmeAffichee(
                I.T("Label|10000"),
                new C2iExpressionChamp(new CDefinitionProprieteDynamiqueDotNet(
                    "Label",
                    "Libelle",
                    new CTypeResultatExpression(typeof(string), false),
                    false, false,
                    "")),
                300);

            CColonneAlarmeAffichee colonneDateDetbut = new CColonneAlarmeAffichee(
                I.T("Start Date|10001"),
                new C2iExpressionChamp(new CDefinitionProprieteDynamiqueDotNet(
                    "Start Date",
                    "DateDebut",
                    new CTypeResultatExpression(typeof(DateTime), false),
                    false, false,
                    "")),
                120);

            CColonneAlarmeAffichee colonneDateFin = new CColonneAlarmeAffichee(
                I.T("End date|10002"),
                new C2iExpressionChamp(new CDefinitionProprieteDynamiqueDotNet(
                    "End Date",
                    "DateFin",
                    new CTypeResultatExpression(typeof(DateTime?), false),
                    false, false,
                    "")),
                120);

            m_listeColonnes.AddRange(
                new CColonneAlarmeAffichee[] {
                    colonneLibelle,
                    colonneDateDetbut,
                    colonneDateFin
                    });
        }
        

        //------------------------------------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //------------------------------------------------------------------------------
        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            CResultAErreur result = CResultAErreur.True;
            int nVersion = GetNumVersion();
            result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;

            serializer.TraiteInt(ref m_nRowHeaderWidth);
            serializer.TraiteInt(ref m_nItemHeight);
            serializer.TraiteInt(ref m_nColumnHeaderHeight);
            serializer.TraiteInt(ref m_fDureePersistanceAlarmesRetombees);
            result = serializer.TraiteObject<C2iExpression>(ref m_formuleFiltreListe);
            if(result)
                result = serializer.TraiteObject<C2iExpression>(ref m_formuleSurNouvelleAlarme);
            if (result)
                result = serializer.TraiteObject<C2iExpression>(ref m_formuleItemForeColor);
            if (result)
                result = serializer.TraiteObject<C2iExpression>(ref m_formuleItemBackColor);
            if(result)
                result = serializer.TraiteListe<CColonneAlarmeAffichee>(m_listeColonnes);


            return result;
        }

    }

    #region classe CColonne
    /// <summary>
    /// Permet de stocker le paralmétrage d'un colonne de liste d'alarmes à afficher
    /// </summary>
    public class CColonneAlarmeAffichee : I2iSerializable
    {
        private string m_strTitle = "Undefined";
        private C2iExpression m_expression = null;
        private int m_nWidth = 100;
        private Color m_couleurFond = Color.Transparent;
        private Color m_couleurText = Color.Transparent;
        private Font m_font = null;
        private CActionSur2iLink m_actionLink = null;

        //----------------------------------------------------------
        public CColonneAlarmeAffichee()
        {
        }

        //----------------------------------------------------------
        public CColonneAlarmeAffichee(string strTitre, C2iExpression formule, int nLargeur)
        {
            m_strTitle = strTitre;
            m_expression = formule;
            m_nWidth = nLargeur;
        }

        //----------------------------------------------------------
        public string Title
        {
            get
            {
                return m_strTitle;
            }
            set
            {
                m_strTitle = value;
            }
        }

        //-------------------------------------------------------
        public C2iExpression FormuleDonnee
        {
            get
            {
                return m_expression;
            }
            set
            {
                m_expression = value;
            }
        }

        //----------------------------------------------
        public CActionSur2iLink ActionSurLink
        {
            get
            {
                return m_actionLink;
            }
            set
            {
                m_actionLink = value;
            }
        }

        //----------------------------------------------
        public int Width
        {
            get
            {
                return m_nWidth;
            }
            set
            {
                m_nWidth = Math.Max(0, value);
            }
        }

        //----------------------------------------------
        public Color BackColor
        {
            get
            {
                return m_couleurFond;
            }
            set
            {
                m_couleurFond = value;
            }
        }

        //----------------------------------------------
        public Color TextColor
        {
            get
            {
                return m_couleurText;
            }
            set
            {
                m_couleurText = value;
            }
        }

        //----------------------------------------------
        public Font Font
        {
            get
            {
                return m_font;
            }
            set
            {
                m_font = value;
            }
        }


        //----------------------------------------------
        public override string ToString()
        {
            return m_strTitle;
        }

        #region I2iSerializable Membres
        //----------------------------------------------------------------
        private int GetNumVersion()
        {
            //return 0;
            return 1; // Action sur 2iLink
        }

        //----------------------------------------------------------------
        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;

            serializer.TraiteString(ref m_strTitle);
            serializer.TraiteInt(ref m_nWidth);
            result = serializer.TraiteObject<C2iExpression>(ref m_expression);
            if (!result)
                return result;

            int nVal = m_couleurFond.ToArgb();
            serializer.TraiteInt(ref nVal);
            m_couleurFond = Color.FromArgb(nVal);

            nVal = m_couleurText.ToArgb();
            serializer.TraiteInt(ref nVal);
            m_couleurText = Color.FromArgb(nVal);

            result = SerializeFont(serializer, ref m_font);

            if (nVersion >= 1)
                result = serializer.TraiteObject<CActionSur2iLink>(ref m_actionLink);

            return result;
        }

        //-----------------------------------------------------------------
        private CResultAErreur SerializeFont(C2iSerializer serializer, ref Font ft)
        {
            CResultAErreur result = CResultAErreur.True;
            bool bHasFont = ft != null;
            serializer.TraiteBool(ref bHasFont);
            if (bHasFont)
            {
                if (serializer.Mode == ModeSerialisation.Lecture)
                    ft = new Font("Arial", 1, FontStyle.Regular);

                Byte gdiCharset = ft.GdiCharSet;
                bool gdiVerticalFont = ft.GdiVerticalFont;
                int nUnit = (int)ft.Unit;
                string strName = ft.Name;
                double fSize = ft.Size;
                int nStyle = (int)ft.Style;
                serializer.TraiteByte(ref gdiCharset);
                serializer.TraiteBool(ref gdiVerticalFont);
                serializer.TraiteString(ref strName);
                serializer.TraiteDouble(ref fSize);
                serializer.TraiteInt(ref nStyle);
                serializer.TraiteInt(ref nUnit);
                if (serializer.Mode == ModeSerialisation.Lecture)
                    ft = new Font(strName, (float)fSize, (FontStyle)nStyle, (GraphicsUnit)nUnit, gdiCharset, gdiVerticalFont);
            }
            return result;
        }
        #endregion


    }
    #endregion


}
