using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common.memorydb;
using System.Data;

namespace futurocom.supervision
{
    /// <summary>
    /// Représente des informations hors ligne (sans connexion à la base de données)
    /// sur une alarme locale à afficher dans la fenêtre d'éxploitation des alarmes
    /// </summary>
    public class CLocalAlarmeAffichee : CLocalAlarme
    {

        public CLocalAlarmeAffichee(CMemoryDb db)
            :base(db)
        {
        }

        public CLocalAlarmeAffichee(DataRow row)
            : base(row)
        {
        }

        public List<CLocalAlarmeAffichee> AlarmesFilles
        {
            get
            {
                List<CLocalAlarmeAffichee> listeRetournee = new List<CLocalAlarmeAffichee>();
                foreach (CLocalAlarme localAlarme in Childs)
                {
                    listeRetournee.Add(new CLocalAlarmeAffichee(localAlarme.Row.Row));
                }
                return listeRetournee;
            }
        }

        public CLocalAlarmeAffichee AlarmeParente
        {
            get
            {
                if(Parent != null)
                    return new CLocalAlarmeAffichee(Parent.Row.Row);
                return null;
            }
        }


        
    }
}
