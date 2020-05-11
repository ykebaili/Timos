using System;
using System.Collections.Generic;
using System.Text;
using sc2i.common;
using sc2i.data;

namespace spv.data
{
    public interface ISpvObjetAvecAccesAlarmeCable
    {
        int ClassId { get; }  
      
        CListeObjetsDonnees AlarmesCables { get; }
        CListeObjetsDonnees AccesAlarmeBoucle{ get; }
        CListeObjetsDonnees AccesAlarmeBoucleNonCable { get; }

        /// <summary>
        /// Retourne les sites liés à l'objet. ce sont les sites qui "connaissent" l'objet.
        /// </summary>
        CSpvSite[] SitesPouvantContenirLeCollecteur{ get; }
        string GetName();
        string GetTypeName();
        CListeObjetsDonnees PrestationsConcernees { get; }
        
        
    }

}
