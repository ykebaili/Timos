using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using sc2i.data;
using timos.acteurs;

namespace timos.data.sites.releve
{
    public static class CEmplacementEquipementsTrouves
    {
        private static CStock m_stockPerduTrouve = null;

        //-------------------------------------------------------------
        public static CStock StockPerduTrouve
        {
            get
            {
                if (m_stockPerduTrouve == null)
                {
                    int nVal = (int)new CDataBaseRegistrePourClient(CContexteDonneeSysteme.GetInstance().IdSession).GetValeurLong("LOST&FOUND_STOCK", -1);
                    if (nVal >= 0)
                    {
                        CStock stock = new CStock(CContexteDonneeSysteme.GetInstance());
                        if (stock.ReadIfExists(nVal))
                            m_stockPerduTrouve = stock;
                    }

                }
                return m_stockPerduTrouve;
            }
            set
            {
                if ( value != null )
                {
                    new CDataBaseRegistrePourClient(CContexteDonneeSysteme.GetInstance().IdSession).SetValeur ( "LOST&FOUND_STOCK", value.Id.ToString() );
                }
            }
        }

        //-------------------------------------------------------------
        public static string Libelle
        {
            get
            {
                if (StockPerduTrouve != null)
                    return StockPerduTrouve.Libelle;
                return I.T("'lost & found' stock is not defined. Contact Timos Administrator|20216");
            }
        }
    }
}
