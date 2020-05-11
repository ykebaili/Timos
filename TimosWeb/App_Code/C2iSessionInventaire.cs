using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using sc2i.web;
using sc2i.multitiers.client;
using sc2i.common;

/// <summary>
/// Description résumée de C2iSessionInventaire
/// </summary>
public class C2iSessionInventaire : C2iSessionWeb
{
    //---------------------------------------------
	public C2iSessionInventaire()
	{
		
	}

    //---------------------------------------------
    protected override void BeforeAuthentification(CSessionClient session)
    {
        session.Authentification = new CAuthentificationSessionLoginPassword("ù", "ù");
    }

    //---------------------------------------------
    public override sc2i.common.CResultAErreur MyClose()
    {
        return CResultAErreur.True;
    }
}
