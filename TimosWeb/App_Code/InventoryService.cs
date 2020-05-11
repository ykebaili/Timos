using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using sc2i.web;
using System.Data;
using sc2i.data;
using sc2i.common.memorydb;
using sc2i.common;
using sc2i.multitiers.client;
using timos.client;
using timos.web;

/// <summary>
/// Description résumée de InventoryService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
// [System.Web.Script.Services.ScriptService]
public class InventoryService : C2iServiceWeb
{

    public InventoryService () {

        //Supprimez les marques de commentaire dans la ligne suivante si vous utilisez des composants conçus 
        //InitializeComponent(); 
        
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }

    [WebMethod]
    public DataSet GetBaseConfig(int nIdSession)
    {
        C2iSessionWeb session = GetSessionWeb(nIdSession);
        if (session == null)
            return null;
        using (CContexteDonnee ctx = new CContexteDonnee(session.Session.IdSession, true, false))
        {
            CMemoryDb db = new CMemoryDb();
            CInventoryConvertor.AddStaticDatas(ctx, db);
            return db;
        }
    }

    [WebMethod]
    public DataSet GetSites(int nIdSession, int[] nIdSites)
    {
        C2iSessionWeb session = GetSessionWeb(nIdSession);
        if (session == null)
            return null;
        return CInventoryConvertor.GetSites(session, nIdSites);
    }

    [WebMethod]
    public DataSet GetEquipments(int nIdSession, int nIdSiteContenant)
    {
        C2iSessionWeb session = GetSessionWeb(nIdSession);
        if (session == null)
            return null;
        return CInventoryConvertor.GetEquipments(session, nIdSiteContenant);
    }

    [WebMethod]
    public DataSet GetReferencesSites(int nIdSession)
    {
        C2iSessionWeb session = GetSessionWeb(nIdSession);
        if (session == null)
            return null;
        return CInventoryConvertor.GetListeSitesPourReferences(session);
    }

    [WebMethod]
    public int OpenSession()
    {
        C2iSessionWeb session = new C2iSessionInventaire();
        CResultAErreur result = PrivateOpenSession(session);
        if (result)
            return session.IdSessionWeb;
        return -1;
    }

    [WebMethod]
    public bool SendSurvey(int nIdSession, DataSet ds)
    {
        C2iSessionInventaire session = GetSessionWeb(nIdSession) as C2iSessionInventaire;
        if (session == null)
            return false;
        CMemoryDb db = CMemoryDb.FromDataSet(ds);
        CResultAErreur result = CInventoryConvertor.IntegreReleves(session, db);
        return result.Result;
    }
        
    
}

