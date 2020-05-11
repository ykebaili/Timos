using System;
using System.Collections.Generic;
using System.Text;
using spv.data;
using sc2i.common;
using sc2i.data;


namespace spv.win32
{
    class CFormEditionTypeAccesAlarmeBoucle:CFormEditionTypeAccesAlarme
    {
        public CFormEditionTypeAccesAlarmeBoucle()
			:base()
		{
			
		}
		//-------------------------------------------------------------------------
		public CFormEditionTypeAccesAlarmeBoucle(CSpvTypeAccesAlarme acces)
			:base(acces)
		{
			
		}
		//-------------------------------------------------------------------------
        public CFormEditionTypeAccesAlarmeBoucle(CSpvTypeAccesAlarme acces, CListeObjetsDonnees liste)
			: base(acces, liste)
		{
			
		}
        protected override CResultAErreur InitChamps()
        {
            CResultAErreur result = base.InitChamps();
            if (!result)
                return result;

            CCategorieAccesAlarme boucle = new CCategorieAccesAlarme(ECategorieAccesAlarme.SortieBoucle);
            List<IEnumALibelle> lst = new List<IEnumALibelle>();
            lst.Add(boucle as IEnumALibelle);

            m_cmbTypeAcces.Fill(lst, "Libelle", false);

        /*    TypeAccesAlarme.CategorieAccesAlarme = boucle;
            m_cmbTypeAcces.SelectedValue = TypeAccesAlarme.CategorieAccesAlarme;

            UpdateAffichagePanelTrap();

            UpdatePanelAlarmeGeree();*/

            return result;
        }
    }
}
