using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using sc2i.process.web;
using timos.client;
using timos.web;
using sc2i.multitiers.client;

/// <summary>
/// Description résumée de WebService
/// </summary>
[WebService(Namespace = "http://TimosUri/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
// [System.Web.Script.Services.ScriptService]
public class TimosActionService : ActionService
{


    public TimosActionService()
        :base()
    {
        
    }

   

}

