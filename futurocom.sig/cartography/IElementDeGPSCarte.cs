using sc2i.common.sig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace futurocom.sig.cartography
{
    public interface IElementDeGPSCarte
    {
        IEnumerable<IMapItem> CreateMapItems(CMapLayer layer);

        IEnumerable<IMapItem> FindMapItems(CMapDatabase database);
        IEnumerable<IMapItem> UpdateMapItems(CMapDatabase database, List<IMapItem> itemsToDelete);

        IEnumerable<CMoveablePoint> GetMoveablePoints(CMapDatabase database);

        //Supprime l'élément
        void DeleteThisMapItem();
    }


}
