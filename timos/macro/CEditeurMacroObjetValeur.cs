using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.data.dynamic.Macro;
using sc2i.data;
using sc2i.win32.data;
using sc2i.common;
using sc2i.expression;

namespace timos.macro
{
    [AutoExec("Autoexec")]
    public partial class CEditeurMacroObjetValeur : UserControl, IEditeurElementDeMacro
    {
        private CMacroObjetValeur m_macroObjetValeur = null;
        public CEditeurMacroObjetValeur()
        {
            InitializeComponent();
        }

        public static void Autoexec()
        {
            CControleEditeMacro.RegisterEditeur(typeof(CMacroObjetValeur), typeof(CEditeurMacroObjetValeur));
        }

        public void InitChamps(object obj)
        {
            m_macroObjetValeur=  obj as CMacroObjetValeur;
            if (m_macroObjetValeur != null)
            {
                m_macroObjetValeur.MacroObjet.Macro.VariableCurrentElement.SetTypeDonnee(new CTypeResultatExpression(m_macroObjetValeur.MacroObjet.TypeObjet, false));
                m_lblPropriété.Text = m_macroObjetValeur.Champ.Nom;
                m_txtFormule.Formule = m_macroObjetValeur.FormuleValeur;
                m_txtFormule.Init(m_macroObjetValeur.MacroObjet.Macro, new CObjetPourSousProprietes(m_macroObjetValeur.MacroObjet.Macro));
            }
        }

        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            if ( m_macroObjetValeur != null )
            {
                m_macroObjetValeur.FormuleValeur = m_txtFormule.Formule;
            }
            return result;

        }

        

    }
}
