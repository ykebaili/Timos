using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using timos.data;
using sc2i.data;

namespace CamusatQowisioClientPlugin
{
    [AutoExec("Autoexec")]
    public class CMethodeSupplementaireSelectEquipmentDatas : CMethodeSupplementaire
    {

        public CMethodeSupplementaireSelectEquipmentDatas()
            :base(typeof(CEquipement))
        {
        }

        public static void Autoexec()
        {
            CGestionnaireMethodesSupplementaires.RegisterMethode(new CMethodeSupplementaireSelectEquipmentDatas());
        }

        public override string Description
        {
            get 
            {
                return "Returns list of Datas between 2 dates";
            }
        }

        public override CInfoParametreMethodeDynamique[] InfosParametres
        {
            get
            {
                return new CInfoParametreMethodeDynamique[] 
                {
                    new CInfoParametreMethodeDynamique("Start Date", "", typeof(DateTime?)),
                    new CInfoParametreMethodeDynamique("End Date", "", typeof(DateTime?))
                };
            }
        }

        public override object Invoke(object objetAppelle, params object[] parametres)
        {
            CEquipement equipementTank = objetAppelle as CEquipement;
            if(equipementTank == null)
                return null;

            CFiltreData filtreDatas = new CFiltreData(
                CCamusatQowisioData.c_champFuExTank_Id + " = @1 OR " +
                CCamusatQowisioData.c_champFuTank1_Id + " = @1 OR " +
                CCamusatQowisioData.c_champFuTank2_Id + " = @1 OR " +
                CCamusatQowisioData.c_champFuTank3_Id + " = @1 OR " +
                CCamusatQowisioData.c_champFuTank4_Id + " = @1",
                equipementTank.Id);


            if (parametres.Length > 0)
            {
                try
                {
                    if (parametres[0] != null)
                    {
                        DateTime? dateDebut = (DateTime?)parametres[0];
                        filtreDatas = CFiltreData.GetAndFiltre(filtreDatas,
                            new CFiltreData(CCamusatQowisioData.c_champQwDateTime + " >= @1",
                                dateDebut.Value));
                    }
                }
                catch (Exception e)
                { }
            }
            if (parametres.Length > 1)
            {
                try
                {
                    if (parametres[1] != null)
                    {
                        DateTime? dateFin = (DateTime?)parametres[1];
                        filtreDatas = CFiltreData.GetAndFiltre(filtreDatas,
                            new CFiltreData(CCamusatQowisioData.c_champQwDateTime + " < @1",
                                dateFin.Value));
                    }
                }
                catch (Exception e)
                { }
            }

            CListeObjetDonneeGenerique<CCamusatQowisioData> listeDatas = 
                new CListeObjetDonneeGenerique<CCamusatQowisioData>(
                    equipementTank.ContexteDonnee, filtreDatas);

            return listeDatas.ToArray();
        }

        public override string Name
        {
            get { return "SelectEquipmentDatas"; }
        }

        public override bool ReturnArrayOfReturnType
        {
            get { return true; }
        }

        public override Type ReturnType
        {
            get { return typeof(CCamusatQowisioData); }
        }
    }
}
