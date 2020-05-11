using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using sc2i.win32.data.navigation;
using spv.data;
using timos.data;
using sc2i.common;

namespace spv.win32
{
    public partial class CExtenderFormTypeqMIB : CExtendeurFormEditionStandardTabPage
    {
        private CSpvTypeq m_spvTypeq = null;

        public CExtenderFormTypeqMIB()
        {
             InitializeComponent();
             Title = I.T("MIB Modules|30008");
        }



        protected CTypeEquipement TypeEquipement
        {
            get
            {
                return ObjetEdite as CTypeEquipement;
            }
        }



        public override CResultAErreur MyInitChamps()
        {

            CResultAErreur result = CResultAErreur.True;

            if (ObjetEdite is CTypeEquipement)
            {
                m_spvTypeq = CSpvTypeq.GetSpvTypeqFromTypeEquipement(ObjetEdite as CTypeEquipement) as CSpvTypeq;
            }

                       
            result = base.MyInitChamps();


            return result;
        }


        public override CResultAErreur MyMajChamps()
        {
            CResultAErreur result = CResultAErreur.True;
       
            
            result = base.MyMajChamps();

            return result;

        }
    }
}
