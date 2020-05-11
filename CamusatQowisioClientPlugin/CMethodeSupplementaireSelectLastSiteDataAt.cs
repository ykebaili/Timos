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
    public class CMethodeSupplementaireSelectLastSiteDataAt : CMethodeSupplementaire
    {
        public CMethodeSupplementaireSelectLastSiteDataAt()
            :base(typeof(CSite))
        {
        }

        public static void Autoexec()
        {
            CGestionnaireMethodesSupplementaires.RegisterMethode(new CMethodeSupplementaireSelectLastSiteDataAt());
        }

        public override string Description
        {
            get { return "Returns last Qowisio Data from this Site at a date"; }
        }

        public override CInfoParametreMethodeDynamique[] InfosParametres
        {
            get
            {
                return new CInfoParametreMethodeDynamique[] {
                    new CInfoParametreMethodeDynamique("Date","requiered date", typeof(DateTime))};
            }
        }

        public static CCamusatQowisioData GetDataAt(
            CSite site,
            DateTime? dtLimite,
            bool bOnlyWithExternalProbeConnected)
        {
            if (site == null)
                return null;

            CFiltreData filtreDatas = new CFiltreData("(" +
                CCamusatQowisioData.c_champFuSite_Id + " = @1 OR " +
                CCamusatQowisioData.c_champFuPickup_Id + " = @1)",
                site.Id);

            if (dtLimite != null)
            {
                filtreDatas.Filtre += " and " +
                    CCamusatQowisioData.c_champQwDateTime + "< @2";
                filtreDatas.Parametres.Add(dtLimite.Value.AddSeconds(10));
            }
            if (bOnlyWithExternalProbeConnected)
            {
                filtreDatas.Filtre += " and " + CCamusatQowisioData.c_champQwExFP_Id + "<>@3";
                filtreDatas.Parametres.Add("");
            }

            C2iRequeteAvancee rq = new C2iRequeteAvancee();
            rq.TableInterrogee = CCamusatQowisioData.c_nomTable;
            rq.FiltreAAppliquer = filtreDatas;
            rq.ListeChamps.Add(new C2iChampDeRequete(
                "MAXDATE", new CSourceDeChampDeRequete(CCamusatQowisioData.c_champQwDateTime),
                typeof(DateTime), OperationsAgregation.Max, false));
            CResultAErreur result = rq.ExecuteRequete(site.ContexteDonnee.IdSession);
            if (result)
            {
                DataTable table = result.Data as DataTable;
                if (table != null && table.Rows.Count == 1)
                {
                    if (table.Rows[0][0] is DateTime)
                    {
                        DateTime dtMax = (DateTime)table.Rows[0][0];
                        CFiltreData filtre = new CFiltreData("(" +
                        CCamusatQowisioData.c_champFuSite_Id + " = @1 OR " +
                        CCamusatQowisioData.c_champFuPickup_Id + " = @1) and " +
                        CCamusatQowisioData.c_champQwDateTime + "=@2",
                        site.Id,
                        dtMax);
                        CCamusatQowisioData data = new CCamusatQowisioData(site.ContexteDonnee);
                        if (data.ReadIfExists(filtre))
                        {
                            return data;
                        }
                    }
                }
            }
           /*CListeObjetDonneeGenerique<CCamusatQowisioData> listeDatas =
                new CListeObjetDonneeGenerique<CCamusatQowisioData>(site.ContexteDonnee, filtreDatas);
            listeDatas.Tri = CCamusatQowisioData.c_champQwDateTime + " desc";
            listeDatas.StartAt = 0;
            listeDatas.EndAt = 0;

            foreach (object obj in listeDatas)
            {
                return obj as CCamusatQowisioData;
            }*/

            return null;
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
            return GetDataAt(site, dtLimite, false);
        }
    

        public override string Name
        {
            get { return "SelectLastSiteDataAt"; }
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
