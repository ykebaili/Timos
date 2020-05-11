using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.data;
using sc2i.common.memorydb;
using futurocom.supervision;

namespace timos.data.supervision
{
    public class CFournisseurAlarmesPourAffichage
    {
        public static CMemoryDb GetAlarmesAAfficher(int nIdSession)
        {
            using (CContexteDonnee ctx = new CContexteDonnee(nIdSession, true, false))
            {
                CMemoryDb db = CMemoryDbPourSupervision.GetMemoryDb(ctx);
                //Catégories de masquage
                CListeObjetDonneeGenerique<CCategorieMasquageAlarme> lstCat = new CListeObjetDonneeGenerique<CCategorieMasquageAlarme>(ctx);
                foreach (CCategorieMasquageAlarme cat in lstCat)
                {
                    CLocalCategorieMasquageAlarme local = cat.GetLocalCategorieForSupervision(db);
                }
                
                CListeObjetDonneeGenerique<CAlarme> lst = new CListeObjetDonneeGenerique<CAlarme>(ctx);
                lst.Filtre = new CFiltreData(CAlarme.c_champDateFin + " is null and " +
                    CAlarme.c_champIdParent + " is null");
                int nCount = 0;
                if (lst.Count == 0)
                    return db;
                CListeObjetsDonnees lstFilles = lst;
                while (ctx.Tables[CAlarme.c_nomTable].Rows.Count != nCount)
                {
                    nCount = ctx.Tables[CAlarme.c_nomTable].Rows.Count;
                    lstFilles = lstFilles.GetDependances("AlarmesFilles");
                }
                lst = new CListeObjetDonneeGenerique<CAlarme>(ctx);
                lst.InterditLectureInDB = true;
                lst.ReadDependances("RelationsChampsCustom");
                lst.Filtre = new CFiltreData(CAlarme.c_champIdParent + " is null");
                CListeObjetDonneeGenerique<CTypeAlarme> lstTypes = new CListeObjetDonneeGenerique<CTypeAlarme>(ctx);
                lstTypes.AssureLectureFaite();
                
                foreach (CAlarme alrm in lst)
                {
                    CLocalAlarme newAlrm = alrm.GetLocalAlarme(db, true);
                }
                return db;
            }
        }


    }
}
