using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using timos.data;
using sc2i.data;
using sc2i.data.dynamic;

namespace CamusatQowisioClientPlugin
{
    [AutoExec("Autoexec")]
    public class CMethodeSupplementaireSelectLastEquipmentData : CMethodeSupplementaire
    {
        public CMethodeSupplementaireSelectLastEquipmentData()
            :base(typeof(CEquipement))
        {
        }

        public static void Autoexec()
        {
            CGestionnaireMethodesSupplementaires.RegisterMethode(new CMethodeSupplementaireSelectLastEquipmentData());
        }

        public override string Description
        {
            get { return "Returns last Qowisio Data from this Equipment"; }
        }

        public override CInfoParametreMethodeDynamique[] InfosParametres
        {
            get
            {
                return new CInfoParametreMethodeDynamique[] { };
            }
        }

        public override object Invoke(object objetAppelle, params object[] parametres)
        {
            CEquipement equipementTank = objetAppelle as CEquipement;
            if (equipementTank == null)
                return null;

            CFiltreData filtreDatas = new CFiltreData(
                CCamusatQowisioData.c_champFuExTank_Id + " = @1 OR " +
                CCamusatQowisioData.c_champFuTank1_Id + " = @1 OR " +
                CCamusatQowisioData.c_champFuTank2_Id + " = @1 OR " +
                CCamusatQowisioData.c_champFuTank3_Id + " = @1 OR " +
                CCamusatQowisioData.c_champFuTank4_Id + " = @1",
                equipementTank.Id);

            CListeObjetDonneeGenerique<CCamusatQowisioData> listeDatas =
                new CListeObjetDonneeGenerique<CCamusatQowisioData>(equipementTank.ContexteDonnee, filtreDatas);
            listeDatas.Tri = CCamusatQowisioData.c_champQwDateTime + " desc";
            listeDatas.StartAt = 1;
            listeDatas.EndAt = 1;

            if (listeDatas.Count > 0)
                return listeDatas[0];
            
            return null; 
        }

        public override string Name
        {
            get { return "SelectLastEquipmentData"; }
        }

        public override bool ReturnArrayOfReturnType
        {
            get { return false; }
        }

        public override Type ReturnType
        {
            get { return typeof(CCamusatQowisioData); }
        }
    }
}
