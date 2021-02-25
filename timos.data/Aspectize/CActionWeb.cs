using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sc2i.common;
using sc2i.process;
using sc2i.expression;

namespace timos.data.Aspectize
{
    public class CActionWeb : IEntiteTimosWebApp
    {
        public const string c_nomTable = "Action";

        public const string c_champId = "Id";
        public const string c_champLibelle = "Libelle";
        public const string c_champInstructions = "Instructions";
        public const string c_champVarText1 = "VarText1";
        public const string c_champVarText2 = "VarText2";
        public const string c_champVarInt1 = "VarInt1";
        public const string c_champVarInt2 = "VarInt2";

        DataRow m_row;

        //---------------------------------------------------------------------------------------
        public CActionWeb(DataSet ds, CProcessInDb action)
        {
            DataTable dt = ds.Tables[c_nomTable];
            if (dt == null)
                return;

            DataRow row = dt.NewRow();

            int nId = -1;
            string strLibelle = "";
            string strInstructions = "";
            string strNomVariableText1 = "Variable texte 1";
            string strNomVariableText2 = "Variable texte 2";
            string strNomVariableInt1 = "Variable entier 1";
            string strNomVariableInt2 = "Variable entier 2";

            if(action != null)
            {
                nId = action.Id;
                strLibelle = action.Libelle;
                strInstructions = action.Description;

                // Remplissage des variables
                CProcess process = action.Process;
                if(process != null)
                {
                    foreach (CVariableDynamique variable in process.ListeVariables)
                    {

                    }
                }

            }

            row[c_champId] = nId;
            row[c_champLibelle] = strLibelle;
            row[c_champInstructions] = strInstructions;
            row[c_champVarText1] = strNomVariableText1;
            row[c_champVarText2] = strNomVariableText2;
            row[c_champVarInt1] = strNomVariableInt1;
            row[c_champVarInt2] = strNomVariableInt2;

            m_row = row;
            dt.Rows.Add(row);
        }

        //---------------------------------------------------------------------------------------
        public DataRow Row
        {
            get
            {
                return m_row;
            }
        }

        //---------------------------------------------------------------------------------------
        public CResultAErreur FillDataSet(DataSet ds)
        {
            CResultAErreur result = CResultAErreur.True;



            return result;
        }

        //---------------------------------------------------------------------------------------
        public static DataTable GetStructureTable()
        {
            DataTable dt = new DataTable(c_nomTable);

            dt.Columns.Add(c_champId, typeof(int));
            dt.Columns.Add(c_champLibelle, typeof(string));
            dt.Columns.Add(c_champInstructions, typeof(string));
            dt.Columns.Add(c_champVarText1, typeof(string));
            dt.Columns.Add(c_champVarText2, typeof(string));
            dt.Columns.Add(c_champVarInt1, typeof(string));
            dt.Columns.Add(c_champVarInt2, typeof(string));

            return dt;
        }
    }
}
