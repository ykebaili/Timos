using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sc2i.common;
using sc2i.process;
using sc2i.expression;
using sc2i.data.dynamic;
using timos.process;
using sc2i.formulaire;
using System.Collections;

namespace timos.data.Aspectize
{
    public class CActionWeb : IEntiteTimosWebApp
    {
        public const string c_nomTable = "Action";

        public const string c_champId = "Id";
        public const string c_champLibelle = "Libelle";
        public const string c_champInstructions = "Instructions";

        public const string c_champIdVarText1 = "IdVarText1";
        public const string c_champLabelVarText1 = "LabelVarText1";
        public const string c_champIdVarText2 = "IdVarText2";
        public const string c_champLabelVarText2 = "LabelVarText2";
        public const string c_champIdVarText3 = "IdVarText3";
        public const string c_champLabelVarText3 = "LabelVarText3";
        public const string c_champIdVarText4 = "IdVarText4";
        public const string c_champLabelVarText4 = "LabelVarText4";
        public const string c_champIdVarText5 = "IdVarText5";
        public const string c_champLabelVarText5 = "LabelVarText5";

        public const string c_champIdVarInt1 = "IdVarInt1";
        public const string c_champLabelVarInt1 = "LabelVarInt1";
        public const string c_champIdVarInt2 = "IdVarInt2";
        public const string c_champLabelVarInt2 = "LabelVarInt2";
        public const string c_champIdVarInt3 = "IdVarInt3";
        public const string c_champLabelVarInt3 = "LabelVarInt3";

        public const string c_champIdVarDate1 = "IdVarDate1";
        public const string c_champLabelVarDate1 = "LabelVarDate1";
        public const string c_champIdVarDate2 = "IdVarDate2";
        public const string c_champLabelVarDate2 = "LabelVarDate2";
        public const string c_champIdVarDate3 = "IdVarDate3";
        public const string c_champLabelVarDate3 = "LabelVarDate3";

        public const string c_champIdVarBool1 = "IdVarBool1";
        public const string c_champLabelVarBool1 = "LabelVarBool1";
        public const string c_champIdVarBool2 = "IdVarBool2";
        public const string c_champLabelVarBool2 = "LabelVarBool2";
        public const string c_champIdVarBool3 = "IdVarBool3";
        public const string c_champLabelVarBool3 = "LabelVarBool3";

        DataRow m_row;

        //---------------------------------------------------------------------------------------
        public CActionWeb(DataSet ds, CProcessInDb processDb)
        {
            DataTable dt = ds.Tables[c_nomTable];
            if (dt == null)
                return;

            DataRow row = dt.NewRow();

            int nId = -1;
            string strLibelle = "";
            string strInstructions = "";

            // Forecer toutes les valeurs par défaut à chaine vide
            foreach (DataColumn col in dt.Columns)
            {
                if (col.DataType == typeof(string))
                    row[col] = "hidden";
            }

            if(processDb != null)
            {
                nId = processDb.Id;
                strLibelle = processDb.Libelle;
                strInstructions = processDb.Description;

                int nIndexTextVar = 1;
                int nIndexIntVar = 1;
                int nIndexDateVar = 1;
                int nIndexBoolVar = 1;

                // Remplissage des variables
                CProcess process = processDb.Process;
                if(process != null)
                {
                    CActionFormulaire actionFormulaire = null;

                    foreach (CAction action in process.ListeActions)
                    {
                        if (action is CActionFormulaire)
                        {
                            // On trouve le premier bloc Formulaire
                            actionFormulaire = (CActionFormulaire)action;
                            break;
                        }
                    }

                    if (actionFormulaire != null)
                    {
                        C2iWndFenetre fenetre = actionFormulaire.Formulaire;
                        ArrayList lstChilds = fenetre.AllChilds();

                        List<C2iWndVariable> lstWndVariables = new List<C2iWndVariable>();
                        foreach (object objWnd in lstChilds)
                        {
                            if (objWnd is C2iWndVariable)
                                lstWndVariables.Add((C2iWndVariable)objWnd);
                        }
                        lstWndVariables = lstWndVariables.OrderBy(v => v.WebNumOrder).ToList();

                        foreach (C2iWndVariable wndVariable in lstWndVariables)
                        {
                            CVariableDynamique variable = wndVariable.Variable as CVariableDynamique;
                            if (wndVariable.WebLabel != "" && variable != null && variable is CVariableDynamiqueSaisie)
                            {
                                switch (((CVariableDynamiqueSaisie)variable).TypeDonnee2i.TypeDonnee)
                                {
                                    case TypeDonnee.tEntier:
                                        if (nIndexIntVar <= 3)
                                        {
                                            row["IdVarInt" + nIndexIntVar] = variable.IdVariable;
                                            row["LabelVarInt" + nIndexIntVar++] = wndVariable.WebLabel;
                                        }
                                        break;
                                    case TypeDonnee.tDouble:
                                        if (nIndexTextVar <= 5)
                                        {
                                            row["IdVarText" + nIndexTextVar] = variable.IdVariable;
                                            row["LabelVarText" + nIndexTextVar++] = wndVariable.WebLabel;
                                        }
                                        break;
                                    case TypeDonnee.tString:
                                        if (nIndexTextVar <= 5)
                                        {
                                            row["IdVarText" + nIndexTextVar] = variable.IdVariable;
                                            row["LabelVarText" + nIndexTextVar++] = wndVariable.WebLabel;
                                        }
                                        break;
                                    case TypeDonnee.tDate:
                                        if (nIndexDateVar <= 3)
                                        {
                                            row["IdVarDate" + nIndexDateVar] = variable.IdVariable;
                                            row["LabelVarDate" + nIndexDateVar++] = wndVariable.WebLabel;
                                        }
                                        break;
                                    case TypeDonnee.tBool:
                                        if (nIndexBoolVar <= 3)
                                        {
                                            row["IdVarBool" + nIndexBoolVar] = variable.IdVariable;
                                            row["LabelVarBool" + nIndexBoolVar++] = wndVariable.WebLabel;
                                        }
                                        break;
                                    case TypeDonnee.tObjetDonneeAIdNumeriqueAuto:
                                        break;
                                    default:
                                        break;
                                }

                            }
                        }
                    }
                }

            }

            row[c_champId] = nId;
            row[c_champLibelle] = strLibelle;
            row[c_champInstructions] = strInstructions;

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

            dt.Columns.Add(c_champIdVarText1, typeof(string));
            dt.Columns.Add(c_champLabelVarText1, typeof(string));
            dt.Columns.Add(c_champIdVarText2, typeof(string));
            dt.Columns.Add(c_champLabelVarText2, typeof(string));
            dt.Columns.Add(c_champIdVarText3, typeof(string));
            dt.Columns.Add(c_champLabelVarText3, typeof(string));
            dt.Columns.Add(c_champIdVarText4, typeof(string));
            dt.Columns.Add(c_champLabelVarText4, typeof(string));
            dt.Columns.Add(c_champIdVarText5, typeof(string));
            dt.Columns.Add(c_champLabelVarText5, typeof(string));

            dt.Columns.Add(c_champIdVarInt1, typeof(string));
            dt.Columns.Add(c_champLabelVarInt1, typeof(string));
            dt.Columns.Add(c_champIdVarInt2, typeof(string));
            dt.Columns.Add(c_champLabelVarInt2, typeof(string));
            dt.Columns.Add(c_champIdVarInt3, typeof(string));
            dt.Columns.Add(c_champLabelVarInt3, typeof(string));

            dt.Columns.Add(c_champIdVarDate1, typeof(string));
            dt.Columns.Add(c_champLabelVarDate1, typeof(string));
            dt.Columns.Add(c_champIdVarDate2, typeof(string));
            dt.Columns.Add(c_champLabelVarDate2, typeof(string));
            dt.Columns.Add(c_champIdVarDate3, typeof(string));
            dt.Columns.Add(c_champLabelVarDate3, typeof(string));

            dt.Columns.Add(c_champIdVarBool1, typeof(string));
            dt.Columns.Add(c_champLabelVarBool1, typeof(string));
            dt.Columns.Add(c_champIdVarBool2, typeof(string));
            dt.Columns.Add(c_champLabelVarBool2, typeof(string));
            dt.Columns.Add(c_champIdVarBool3, typeof(string));
            dt.Columns.Add(c_champLabelVarBool3, typeof(string));

            return dt;
        }
    }
}
