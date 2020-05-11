using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Printing;
using sc2i.common;
using Crownwood.DotNetMagic.Docking;

namespace timos.process
{
    public class CTextPrintSetup
    {
        public const string c_paramImprimante = "PRINTER";
        public const string c_paramPageSize = "PAGE SIZE";
        public const string c_paramPaysage = "LANDSCAPE";
        public const string c_paramLeftMargin = "LEFTMARGIN";
        public const string c_paramRightMargin = "RIGHTMARGIN";
        public const string c_paramTopMargin = "TOPMARGIN";
        public const string c_paramBottomMargin = "BOTTOMMARGIN";

        public static CResultAErreur ApplyParameters(string strText, PrinterSettings printSettings, PageSettings pageSettings)
        {
            CResultAErreur result = CResultAErreur.True;
            try
            {
                string[] strParametres = strText.Split(';');
                foreach (string strParametre in strParametres)
                {
                    int nPosEgal = strParametre.IndexOf('=');
                    if (nPosEgal > 0 && nPosEgal < strParametre.Length - 1)
                    {
                        string strKey = strParametre.Substring(0, nPosEgal).ToUpper().Trim();
                        string strValeur = strParametre.Substring(nPosEgal + 1);
                        if (strKey == c_paramImprimante)
                            printSettings.PrinterName = strValeur;
                        else if (strKey == c_paramPageSize)
                        {
                            result = SetPaperSize(printSettings, pageSettings, strValeur);
                            if ( !result )
                                return result;
                        }
                        else if (strKey == c_paramPaysage)
                        {
                            bool bLandscape = false;
                            if (strValeur.Trim() == "1" || strValeur.ToUpper() == "TRUE")
                                bLandscape = true;
                            pageSettings.Landscape = bLandscape;
                        }
                        else if (strKey == c_paramBottomMargin)
                        {
                            try
                            {
                                pageSettings.Margins.Bottom = Int32.Parse(strValeur);
                            }
                            catch {
                                result.EmpileErreur(I.T("Value @1 is incorrect for parameter @2|20116",
                                    strKey, strValeur ));
                                return result;
                            }
                        }
                        else if (strKey == c_paramTopMargin)
                        {
                            try
                            {
                                pageSettings.Margins.Top = Int32.Parse(strValeur);
                            }
                            catch 
                            {
                                result.EmpileErreur(I.T("Value @1 is incorrect for parameter @2|20116",
                                    strKey, strValeur ));
                                return result;
                            }
                        }
                        else if (strKey == c_paramLeftMargin)
                        {
                            try
                            {
                                pageSettings.Margins.Left = Int32.Parse(strValeur);
                            }
                            catch 
                            {
                                result.EmpileErreur(I.T("Value @1 is incorrect for parameter @2|20116",
                                    strKey, strValeur ));
                                return result;
                            }
                        }
                        else if (strKey == c_paramRightMargin)
                        {
                            try
                            {
                                pageSettings.Margins.Right = Int32.Parse(strValeur);
                            }
                            catch 
                            {
                                result.EmpileErreur(I.T("Value @1 is incorrect for parameter @2|20116",
                                    strKey, strValeur ));
                                return result;
                            }
                        }
                        else
                        {
                            result.EmpileErreur(I.T("Bad print parametre (@1)|20115", strKey));
                            return result;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                result.EmpileErreur(new   CErreurException(e));
            }
            return result;
        }         
        

        public static CResultAErreur SetPaperSize(PrinterSettings printerSettings, PageSettings pageSettings, string strPaperSize)
        {
            CResultAErreur result = CResultAErreur.True;
            strPaperSize = strPaperSize.Replace(" ", "").ToUpper();
            foreach (PaperSize size in printerSettings.PaperSizes)
            {
                if (size.PaperName.ToUpper().Replace(" ","") == strPaperSize)
                {
                    pageSettings.PaperSize = size;
                    return result;
                }
            }
            result.EmpileErreur(I.T("Value @1 is incorrect for parameter @2|20116",
                                    c_paramPageSize, strPaperSize));
            return result;
        }
    }
}
