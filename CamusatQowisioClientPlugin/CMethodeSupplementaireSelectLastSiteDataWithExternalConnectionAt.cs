using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using timos.data;
using sc2i.data;
using System.Data;

namespace CamusatQowisioClientPlugin
{
    [AutoExec("Autoexec")]
    public class CMethodeSupplementaireSelectLastSiteDataWithExternalConnectionAt : CMethodeSupplementaire
    {
        public CMethodeSupplementaireSelectLastSiteDataWithExternalConnectionAt()
            :base(typeof(CSite))
        {
        }

        public static void Autoexec()
        {
            CGestionnaireMethodesSupplementaires.RegisterMethode(new CMethodeSupplementaireSelectLastSiteDataWithExternalConnectionAt());
        }

        public override string Description
        {
            get { return "Returns last Qowisio Data from this Site at a date with external probe connected"; }
        }

        public override CInfoParametreMethodeDynamique[] InfosParametres
        {
            get
            {
                return new CInfoParametreMethodeDynamique[] {
                    new CInfoParametreMethodeDynamique("Date","requiered date", typeof(DateTime))};
            }
        }

        

        public override object Invoke(object objetAppelle, params object[] parametres)
        {
            CSite site = objetAppelle as CSite;
            if (site == null)
                return null;
            DateTime? dtLimite = null;
            if (parametres.Length == 1 && parametres[0] is DateTime)
            {
                dtLimite = (DateTime?)parametres[0];
            }
            return CMethodeSupplementaireSelectLastSiteDataAt.GetDataAt(site, dtLimite, true);
        }
    

        public override string Name
        {
            get { return "SelectLastSiteDataWithExternalConnectionAt"; }
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
