using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using sc2i.workflow;
using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;
using sc2i.expression;
using System.IO;

namespace timos.win32.composants.RichEdit
{
    public class CUtilModeleTexte
    {
        public static CResultAErreur FillRichTextBox ( 
            RichTextBox txtBox,
            CModeleTexte modele,
            object sourceDuModele )
        {
            CResultAErreur result = CResultAErreur.True;
            byte[] data = modele.DataModele;
            if (data != null)
            {
                MemoryStream stream = new MemoryStream(data);
                try
                {
                    txtBox.LoadFile(stream, RichTextBoxStreamType.RichText);
                }
                catch
                {
                    result.EmpileErreur(I.T("Erreur while loading Text Model|20000"));
                    return result;
                }
            }

            CFournisseurPropDynStd fournisseur = new CFournisseurPropDynStd();
            CContexteAnalyse2iExpression contexteAnalyse = new CContexteAnalyse2iExpression(fournisseur, sourceDuModele.GetType());
            CAnalyseurSyntaxiqueExpression analyseur = new CAnalyseurSyntaxiqueExpression(contexteAnalyse);

            CContexteEvaluationExpression contexteEval = new CContexteEvaluationExpression(sourceDuModele);
            //recherche les zones de formule
            int nPosStart = txtBox.Find("{");
            while (nPosStart >= 0)
            {
                int nPosFin = txtBox.Find("}", nPosStart, RichTextBoxFinds.None);
                if (nPosFin > 0)
                {
                    txtBox.Select(nPosStart, nPosFin - nPosStart + 1);
                    string strFormule = txtBox.SelectedText;
                    //Supprime les accolades
                    strFormule = strFormule.Substring(1, strFormule.Length - 2);
                    result = analyseur.AnalyseChaine(strFormule);
                    if (!result)
                    {
                        result.EmpileErreur(I.T("Error in formula @1|20001", strFormule));
                        return result;
                    }
                    else
                    {
                        C2iExpression exp = (C2iExpression)result.Data;
                        if (exp != null)
                        {
                            result = exp.Eval(contexteEval);
                            if (result)
                            {
                                if (result.Data != null)
                                {
                                    string strTmp = result.Data.ToString();
                                    if (strTmp == "")
                                        txtBox.SelectedText = " ";
                                    else
                                        txtBox.SelectedText = strTmp;
                                }
                                else
                                    txtBox.SelectedText = " ";
                            }
                            else
                                txtBox.SelectedText = "##";
                        }
                        else
                            txtBox.SelectedText = " ";
                    }
                    nPosFin = nPosStart + txtBox.SelectedText.Length;
                }
                if (nPosFin < txtBox.Text.Length)
                    nPosStart = txtBox.Find("{", nPosFin, RichTextBoxFinds.None);
                else
                    nPosStart = -1;
            }
            return result;
        }
    }
}
