using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.win32.common;
using sc2i.common;
using sc2i.expression;
using sc2i.data.dynamic;
using timos.data;

namespace timos.releve.CustomField
{
    [AutoExec("Autoexec")]
    public class CControleChampTexte : C2iTextBox, IControlChampCustom
    {
        private CChampCustom m_champ;
        private IElementAChamps m_element = null;

        public event EventHandler OnValueChanged;

        //-----------------------------------------
        public CControleChampTexte()
        {
            InitializeComponent();
        }

        //-----------------------------------------
        public CChampCustom ChampCustom
        {
            get
            {
                return m_champ;
            }
            set
            {
                m_champ = value;
            }
        }

        //-----------------------------------------------------------
        public static void Autoexec()
        {
            CAllocateurControlChampCustom.RegisterControle(TypeDonnee.tString, typeof(CControleChampTexte));
        }
        //-----------------------------------------------------------
        public void InitChamps(IElementAChamps elt)
        {
            if (m_champ != null)
            {
                m_element = elt;
                object valeur = elt.GetValeurChamp(m_champ.Id);
                if (valeur == null)
                    Text = "";
                else
                    Text = valeur.ToString();
            }
        }

        //-----------------------------------------------------------
        public sc2i.common.CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            if ( m_element != null && m_champ != null )
                m_element.SetValeurChamp ( m_champ.Id, Text );
            return result;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // CControleChampTexte
            // 
            this.TextChanged += new System.EventHandler(this.CControleChampTexte_TextChanged);
            this.ResumeLayout(false);

        }

        private void CControleChampTexte_TextChanged(object sender, EventArgs e)
        {
            if (OnValueChanged != null)
                OnValueChanged(this, e);
        }
    }
}
