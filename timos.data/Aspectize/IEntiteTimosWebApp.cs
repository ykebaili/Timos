using sc2i.common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timos.data.Aspectize
{
    public interface IEntiteTimosWebApp
    {
        //DataTable GetStructureTable();
        DataRow Row { get; }
        CResultAErreur FillDataSet(DataSet ds);
    }
}
