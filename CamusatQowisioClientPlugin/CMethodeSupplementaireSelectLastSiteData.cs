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
    public class CMethodeSupplementaireSelectLastSiteData : CMethodeSupplementaire
    {
        public CMethodeSupplementaireSelectLastSiteData()
            :base(typeof(CSite))
        {
        }

        public static void Autoexec()
        {
            CGestionnaireMethodesSupplementaires.RegisterMethode(new CMethodeSupplementaireSelectLastSiteData());
        }

        public override string Description
        {
            get { return "Returns last Qowisio Data from this Site"; }
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
            CSite site = objetAppelle as CSite;
            if (site == null)
                return null;

            return CMethodeSupplementaireSelectLastSiteDataAt.GetDataAt(site, null, false);
        }


        public override string Name
        {
            get { return "SelectLastSiteData"; }
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
