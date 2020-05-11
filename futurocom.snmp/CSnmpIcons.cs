using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using futurocom.snmp.Mib;

namespace futurocom.snmp
{
    [Serializable]
    public class CSnmpIcons
    {
        public static Image IconInconnu
        {
            get
            {
                return Resources.stock_unknown;
            }
        }

        public static Image IconTable
        {
            get
            {
                return Resources.table16;
            }
        }
        public static Image IconColumn
        {
            get
            {
                return Resources.Column16;
            }
        }
        public static Image IconEntry
        {
            get
            {
                return Resources.table_select_row;
            }
        }

        public static Image IconNotification
        {
            get
            {
                return Resources.Warning;
            }
        }

        public static Image IconTrapV1
        {
            get
            {
                return Resources.TrapV1;
            }
        }

        public static Image IconScalar
        {
            get
            {
                return Resources.number16;
            }
        }

        public static Image IconFolder
        {
            get
            {
                return Resources.Folder16;
            }
        }

        public static Image[] GetImagesForDefinitionType()
        {
            List<Image> lst = new List<Image>();
            foreach (DefinitionType value in Enum.GetValues(typeof(DefinitionType)))
            {
                switch (value)
                {
                    case DefinitionType.Unknown:
                        lst.Add(IconInconnu);
                        break;
                    case DefinitionType.OidValueAssignment:
                        lst.Add(IconFolder);
                        break;
                    case DefinitionType.Scalar:
                        lst.Add(IconScalar);
                        break;
                    case DefinitionType.Table:
                        lst.Add(IconTable);
                        break;
                    case DefinitionType.Entry:
                        lst.Add(IconEntry);
                        break;
                    case DefinitionType.Column:
                        lst.Add(IconColumn);
                        break;
                    case DefinitionType.Notification:
                        lst.Add(IconNotification);
                        break;
                    case DefinitionType.Trap :
                        lst.Add(IconTrapV1);
                        break;
                }
            }
            return lst.ToArray();
        }
    }
}
