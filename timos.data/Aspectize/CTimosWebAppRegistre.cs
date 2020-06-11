using sc2i.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timos.data.Aspectize
{
    public class CTimosWebAppRegistre : C2iRegistre
    {
        public const string c_cleRegistre = "Software\\Futurocom\\TimosWebApp\\";

        public CTimosWebAppRegistre()
        {
        }

        protected override string GetClePrincipale()
        {
            return c_cleRegistre;
        }

        protected override bool IsLocalMachine()
        {
            return true;
        }

        //---------------------------------------------------------------------------------------------
        // Doit retourner une liste d'Ids de CTypeCaracteristiqueEntite séparés par une virgule ","
        public static string IdsTypesCaracteristiquesDocumentsAttendus
        {
            get
            {
              return new CTimosWebAppRegistre().GetValue("Entities", "DocumentsAttendus", "");
            }
        }

        //---------------------------------------------------------------------------------------------
        // Doit retourner un Id de CChampCustom
        public static int  IdChampCategorieDocuement
        {
            get
            {
                return new CTimosWebAppRegistre().GetIntValue("Fields", "CategorieDocument", -1);
            }
        }

        //---------------------------------------------------------------------------------------------
        // Doit retourner un Id de CChampCustom
        public static int IdChampDureeStandardTodo
        {
            get
            {
                return new CTimosWebAppRegistre().GetIntValue("Fields", "DureeStandardTodo", -1);
            }
        }
    }
}
