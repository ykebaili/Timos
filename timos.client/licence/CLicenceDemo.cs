using Lys.Applications.Timos.Smt;
using Lys.Licence;
using sc2i.common;
using sc2i.data;
using sc2i.data.dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timos.client.Licence
{
    [Serializable]
    public class CLicenceDemo : CLicenceLogicielPrtct
    {
        //----------------------------------------------------------
        public CLicenceDemo()
            :base()
        {
            IdLys = -1;
		    DateDeMiseEnService = DateTime.Now;
            Numero = Guid.NewGuid().ToString();
            Info = I.T("Free Licence|20006");
            DateLimiteUtilisation = null;
            Password = "";
            //Contrat
            CContratPrtct contrat = new CContratPrtct();
            contrat.AppliName = "Timos SMT";
            contrat.IdAppli = "TIMOS_SMT";
            contrat.Date = DateTime.Now;
            //Client
            CClientPrtct client = new CClientPrtct();
            client.Nom = I.T("Unregistered company|20007");
            client.Inactif = false;
            contrat.Client = client;

            //Modules App
            CApplicationProtegeeTimos app = new CApplicationProtegeeTimos();
            foreach (CLicenceModuleAppPrtct moduleApp in app.ModulesApp)
                ModulesApp.Add(moduleApp);

            //Profile administrateur
            CUserProfilPrtct profilAdmin = new CUserProfilPrtct();
            profilAdmin.Description = I.T("Application administrator|20008");
            profilAdmin.Id = "ADMIN";
            profilAdmin.Nom = I.T("Administrator|20009");
            profilAdmin.Nombre = 1000;
            profilAdmin.Priorite = 0;
            foreach (CLicenceModuleClientPrtct moduleClient in app.ModulesClient)
                profilAdmin.ModulesClient.Add(moduleClient);
            ProfilsUtilisateurs.Add(profilAdmin);

            //Profil utilisateur
            CUserProfilPrtct profilUser = new CUserProfilPrtct();
            profilUser.Description = I.T("Standard user|20010");
            profilUser.Id = "USER";
            profilUser.Nom = I.T("User|20011");
            profilUser.Nombre = 1000;
            profilUser.Priorite = 1;
            ProfilsUtilisateurs.Add(profilUser);

            CUserLicencePrtct licenceUser = new CUserLicencePrtct();
            licenceUser.IdLys = -1;
            licenceUser.NbSimultane = 1000;
            UserLicences.Add(licenceUser);


            
        }

        //--------------------------------------------------------
        public void InitTypesProteges()
        {
            this.Types.Clear();
            foreach ( Type tp in CContexteDonnee.GetAllTypes())
            {
                if (!typeof(CRelationElementAChamp_ChampCustom).IsAssignableFrom(tp))
                {
                    string strNomType = DynamicClassAttribute.GetNomConvivial(tp);
                    CLicenceTypePrtct lc = new CLicenceTypePrtct(strNomType,
                        strNomType, "");
                    lc.Nombre = 1000;
                    Types.Add(lc);
                }
            }
        }
    }
}
