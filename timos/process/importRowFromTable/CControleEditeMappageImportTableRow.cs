using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using timos.data.process;
using sc2i.process;
using timos.data;
using sc2i.data;
using sc2i.expression;
using sc2i.data.dynamic;
using sc2i.common;

namespace timos.process.importRowFromTable
{
    public partial class CControleEditeMappageImportTableRow : UserControl
    {
        private CActionImportFromTableRow.CMappageColonne m_mappage = null;

        public CControleEditeMappageImportTableRow()
        {
            InitializeComponent();
        }

        public CActionImportFromTableRow.CMappageColonne Mappage
        {get{
            return m_mappage;
        }
        }

        public void Init ( CProcess process, Type typeObjet,CActionImportFromTableRow.CMappageColonne mappage )
        {
            m_mappage = mappage;
            CColonneTableParametrable col = new CColonneTableParametrable(CContexteDonneeSysteme.GetInstance() );
            col.ReadIfExists ( mappage.IdColonne );
            m_lblColonne.Text = col.Libelle;
            Type tp = col.TypeDonneeChamp.TypeDotNetAssocie;
            List<CDefinitionProprieteDynamique> lst=  new List<CDefinitionProprieteDynamique>();
            foreach ( CDefinitionProprieteDynamique def in new CFournisseurPropDynStd(false).GetDefinitionsChamps(typeObjet) )
            {
                Type defType = def.TypeDonnee.TypeDotNetNatif;
                if (defType.IsGenericType && defType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    defType = defType.GetGenericArguments()[0];
                if (defType == tp && !def.TypeDonnee.IsArrayOfTypeNatif)
                    lst.Add ( def );
            }
            
            m_cmbChamp.ListDonnees = lst;
            m_cmbChamp.ProprieteAffichee = "Nom";

            m_cmbChamp.SelectedValue = mappage.ProprieteCible;
            m_txtFormuleCondition.Init ( process, typeof(CProcess));
            m_txtFormuleCondition.Formule = mappage.FormuleCondition;
        }

        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            CDefinitionProprieteDynamique def = m_cmbChamp.SelectedValue as CDefinitionProprieteDynamique;
            
            m_mappage.ProprieteCible = def;
            m_mappage.FormuleCondition = m_txtFormuleCondition.Formule;
            return result;
        }

    }
}
