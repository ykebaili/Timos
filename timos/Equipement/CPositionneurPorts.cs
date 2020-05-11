using System;
using System.Collections.Generic;
using System.Text;
using timos.data;

namespace timos.Equipement
{
    public static class CPositionneurPorts
    {
        public static bool PositionnePorts(CTypeEquipement typeEquipement)
        {
            if ( typeEquipement == null )
                return false;
            C2iSymbole symbole = new C2iSymbole();
            C2iSymbole symboleTypeEq = typeEquipement.SymboleADessinerSansPorts;
            if (symboleTypeEq != null)
            {
                symbole.Size = symboleTypeEq.Size;
                C2iSymboleVerrouille verrou = new C2iSymboleVerrouille();
                verrou.SymboleContenu = symboleTypeEq;
                verrou.LockPosition = true;
                verrou.LockSize = true;
                symbole.AddChild(verrou);
                verrou.Parent = symbole;
            }
            foreach (CPort port in typeEquipement.Ports)
            {
                C2iSymbolePort symbolePort = new C2iSymbolePort();
                symbolePort.Port = port;
                symbole.AddChild(symbolePort);
                symbolePort.Parent = symbole;
            }
            CFormEditeurSymbolePopup.EditeSymbole(symbole, typeEquipement.GetType(), true);
            return true;
        }
    }
}
