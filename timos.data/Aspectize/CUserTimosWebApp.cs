using sc2i.common;
using sc2i.multitiers.client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timos.data.Aspectize
{
    public class CUserTimosWebApp : IEntiteTimosWebApp
    {
        public const string c_nomTable = "TIMOS_USERS";

        public const string c_champUserName = "TIMOS_USER_NAME";
        public const string c_champUserKey = "TIMOS_USER_KEY";
        public const string c_champUserLogin = "TIMOS_USER_LOGIN";
        public const string c_champSessionId = "TIMOS_SESSION_ID";
        public const string c_champIsAdministrator = "TIMOS_IS_ADMINISTRATOR";

        DataRow m_row = null;
        Dictionary<string, object> m_dicoProperties = null;

        public DataRow Row
        {
            get
            {
                return m_row;
            }
        }

        public Dictionary<string, object> Properties
        {
            get
            {
                return m_dicoProperties;

            }
        }

        //---------------------------------------------------------------------------------------------
        public CUserTimosWebApp(CSessionClient session, DataRow row, string strLogin)
        {
            if (session != null)
            {
                IInfoUtilisateur infosUser = session.GetInfoUtilisateur();
                if (infosUser != null)
                {
                    row[c_champUserName] = infosUser.NomUtilisateur;
                    row[c_champUserLogin] = strLogin;
                    row[c_champUserKey] = infosUser.KeyUtilisateur.StringValue;
                    row[c_champSessionId] = session.IdSession;
                    bool bIsAdministrator = false;
                    CDbKey keyGroupeAdminWeb = CTimosWebAppRegistre.WebAdminGroupKey;
                    if (keyGroupeAdminWeb != null && infosUser.ListeKeysGroupes.Contains(keyGroupeAdminWeb))
                        bIsAdministrator = true;
                    row[c_champIsAdministrator] = bIsAdministrator;

                    m_row = row;

                    m_dicoProperties = new Dictionary<string, object>();
                    m_dicoProperties[c_champUserName] = infosUser.NomUtilisateur;
                    m_dicoProperties[c_champUserLogin] = strLogin;
                    m_dicoProperties[c_champUserKey] = infosUser.KeyUtilisateur.StringValue;
                    m_dicoProperties[c_champSessionId] = session.IdSession;
                    m_dicoProperties[c_champIsAdministrator] = bIsAdministrator;
                }
            }
        }

        //---------------------------------------------------------------------------------------------
        public static DataTable GetStructureTable()
        {
            DataTable dt = new DataTable(c_nomTable);

            dt.Columns.Add(c_champUserName, typeof(string));
            dt.Columns.Add(c_champUserLogin, typeof(string));
            dt.Columns.Add(c_champUserKey, typeof(string));
            dt.Columns.Add(c_champSessionId, typeof(int));
            dt.Columns.Add(c_champIsAdministrator, typeof(bool));

            return dt;
        }

        //---------------------------------------------------------------------------------------------
        public CResultAErreur FillDataSet(DataSet ds)
        {
            return CResultAErreur.True;
        }
    }
}
