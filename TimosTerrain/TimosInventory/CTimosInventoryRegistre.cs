using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using System.Security.Permissions;
using Microsoft.Win32;
using System.Security.AccessControl;
using System.Windows.Forms;

namespace TimosInventory
{
    public class CTimosInventoryRegistre : C2iRegistre
    {

        //-----------------------------------------------------
        protected override string GetClePrincipale()
        {
            return "Software\\Futurocom\\timosInventory\\";
        }


        //-----------------------------------------------------
        protected override bool IsLocalMachine()
        {
            return false;
        }

        //-----------------------------------------------------
        public static DateTime? DateDonneesTimos
        {
            get
            {
                string strVal = new CTimosInventoryRegistre().GetValue("Data", "Data date", "");
                if (strVal.Length > 0)
                {
                    try
                    {
                        DateTime dt = CUtilDate.FromUniversalString(strVal);
                        return dt;
                    }
                    catch { }
                }
                return null;
            }
            set
            {
                if (value != null)
                    new CTimosInventoryRegistre().SetValue("Data", "Data date", CUtilDate.GetUniversalString(value.Value));
                else
                    new CTimosInventoryRegistre().SetValue("Data", "Data date", "");
            }
        }

        //-----------------------------------------------------
        public static string TimosServiceURL
        {
            get
            {
                CTimosInventoryRegistre reg = new CTimosInventoryRegistre();
                string strURL = reg.GetValue(false, "Timos", "URL", "");
                if (strURL == "")
                    strURL = reg.GetValue(true, "Timos", "URL", "");
                return strURL;
            }
            set
            {
                new CTimosInventoryRegistre().SetValue("Timos", "URL", value);
            }
        }

        /*//-----------------------------------------------------
        public static string[] IdChampsReleve
        {
            get
            {
                string strChaine = new CTimosInventoryRegistre().GetValue("Timos", "Inventory fields", "");
                string[] strVals = strChaine.Split(';');
                List<string> lstIds = new List<string>();
                foreach (string strVal in strVals)
                {
                    if (strVal.Trim().Length > 0)
                    {
                        lstIds.Add(strVal);
                    }
                }
                return lstIds.ToArray();
            }
            set
            {
                if (value != null)
                {
                    StringBuilder bl = new StringBuilder();
                    foreach (string strId in value)
                    {
                        bl.Append(strId);
                        bl.Append(';');
                    }
                    if (bl.Length > 0)
                        bl.Remove(bl.Length - 1, 1);
                    new CTimosInventoryRegistre().SetValue("Timos", "Inventory fields", bl.ToString());
                }
                else
                    new CTimosInventoryRegistre().SetValue("Timos", "Inventory fields", "");
            }
        }*/
    }
}
