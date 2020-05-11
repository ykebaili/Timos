using System;
using System.Collections;

using sc2i.common;
using sc2i.data;
using sc2i.data.dynamic;
using sc2i.expression;
using timos.acteurs;
using sc2i.documents;
using sc2i.multitiers.client;
using sc2i.process;

namespace timos.process
{
    [Serializable]
    public class CMailSC2I
    {
        public readonly string Expediteur;
        public readonly string Sujet;
        public readonly string Message;
        public readonly string[] Destinataires;
        public readonly string[] DestinatairesCC;
        public readonly string[] DestinatairesBCC;
        public readonly int[] DocumentsGED;
        public readonly bool IsFormatHTML;
        // YK 24/05/2016 Ajout option "Utilise le Libellé du Doc GED comme nom de fichier local
        public readonly bool UseDocLabelAsFileName;

        public readonly string SMTPServer;
        public readonly int SMTPPort;
        public readonly string SMTPUser;
        public readonly string SMTPPassword;

        public CMailSC2I(
            string strExpediteur,
            string strSujet,
            string strMessage,
            string[] strDestinataires,
            string[] strDestinatairesCC,
            string[] strDestinatairesBCC,
            int[] documents,
            bool isFormatHTML,
            bool useDocLabelAsFileName,
            string strSMTPServer,
            int nSMTPPort,
            string strSMTPUser,
            string strSMTPPassword)
        {
            Expediteur = strExpediteur;
            Sujet = strSujet;
            Message = strMessage;
            Destinataires = strDestinataires;
            DestinatairesCC = strDestinatairesCC;
            DestinatairesBCC = strDestinatairesBCC;
            DocumentsGED = documents;
            IsFormatHTML = isFormatHTML;
            UseDocLabelAsFileName = useDocLabelAsFileName;
            SMTPServer = strSMTPServer;
            SMTPPort = nSMTPPort;
            SMTPUser = strSMTPUser;
            SMTPPassword = strSMTPPassword;
        }
    }

    public interface IExpediteurMail
    {
        CResultAErreur SendMail(CMailSC2I mail);
    }

    /// <summary>
    /// Description résumée de CActionEnvoyerMail.
    /// </summary>
    [AutoExec("Autoexec")]
    public class CActionEnvoyerMail : CActionLienSortantSimple
    {
        private C2iExpression m_formuleAdresseExpediteur = null;
        private C2iExpression m_formuleSujet = null;
        private C2iExpression m_formuleMessage = null;
        private ArrayList m_listeFormulesMailsDestinatairesTo = new ArrayList();
        private ArrayList m_listeFormulesMailsDestinatairesCC = new ArrayList();
        private ArrayList m_listeFormulesMailsDestinatairesBCC = new ArrayList();
        private ArrayList m_listeFormulesPiecesJointes = new ArrayList();
        private bool m_bFormatHTML = false; // indique si le corps du mail est au format HTML
        // YK 24/05/2016 Ajout option "Utilise le Libellé du Doc GED comme nom de fichier local
        private bool m_bUseDocLabelAsFileName = false;
        // YK 17/05/2018 Configutation d'un serveur SMTP custom pour chaque action (remplace les valeurs du registre)
        private string m_strSMTPServer = "";
        private int m_nSMTPPort = 0;
        private string m_strSMTPUser = "";
        private string m_strSMTPPassword = "";



        /// /////////////////////////////////////////////////////////
        public CActionEnvoyerMail(CProcess process)
            : base(process)
        {
            Libelle = I.T("Send an Email|387");
        }

        /// /////////////////////////////////////////////////////////
        public static void Autoexec()
        {
            CGestionnaireActionsDisponibles.RegisterTypeAction(
                I.T("Send an Email|387"),
                I.T("This action sends an Email|388"),
                typeof(CActionEnvoyerMail),
                CGestionnaireActionsDisponibles.c_categorieInterface);
        }

        /// /////////////////////////////////////////////////////////
        public override bool PeutEtreExecuteSurLePosteClient
        {
            get { return true; }
        }

        /// ////////////////////////////////////////////////////////
        public override void AddIdVariablesNecessairesInHashtable(Hashtable table)
        {
            AddIdVariablesExpressionToHashtable(m_formuleAdresseExpediteur, table);
            AddIdVariablesExpressionToHashtable(m_formuleSujet, table);
            AddIdVariablesExpressionToHashtable(m_formuleMessage, table);
            foreach (C2iExpression exp in m_listeFormulesMailsDestinatairesTo)
                AddIdVariablesExpressionToHashtable(exp, table);

            foreach (C2iExpression exp in m_listeFormulesMailsDestinatairesCC)
                AddIdVariablesExpressionToHashtable(exp, table);

            foreach (C2iExpression exp in m_listeFormulesMailsDestinatairesBCC)
                AddIdVariablesExpressionToHashtable(exp, table);

            foreach (C2iExpression exp in m_listeFormulesPiecesJointes)
                AddIdVariablesExpressionToHashtable(exp, table);
        }

        //--------------------------------------------------------------------
        public C2iExpression FormuleMailExpediteur
        {
            get
            {
                return m_formuleAdresseExpediteur;
            }
            set
            {
                m_formuleAdresseExpediteur = value;
            }
        }

        //--------------------------------------------------------------------
        public C2iExpression FormuleSujet
        {
            get
            {
                return m_formuleSujet;
            }
            set
            {
                m_formuleSujet = value;
            }
        }

        //--------------------------------------------------------------------
        public C2iExpression FormuleMessage
        {
            get
            {
                return m_formuleMessage;
            }
            set
            {
                m_formuleMessage = value;
            }
        }

        //--------------------------------------------------------------------
        public ArrayList ListeFormulesMailsDestinataires
        {
            get
            {
                return m_listeFormulesMailsDestinatairesTo;
            }
        }

        //--------------------------------------------------------------------
        public ArrayList ListeFormulesMailsDestinatairesCC
        {
            get
            {
                return m_listeFormulesMailsDestinatairesCC;
            }
        }

        //--------------------------------------------------------------------
        public ArrayList ListeFormulesMailsDestinatairesBCC
        {
            get
            {
                return m_listeFormulesMailsDestinatairesBCC;
            }
        }


        //--------------------------------------------------------------------
        public ArrayList ListeFormulesPiecesJointes
        {
            get
            {
                return m_listeFormulesPiecesJointes;
            }
        }

        //--------------------------------------------------------------------
        public bool IsFormatHTML
        {
            get
            {
                return m_bFormatHTML;
            }
            set
            {
                m_bFormatHTML = value;
            }
        }

        //--------------------------------------------------------------------
        public bool UseDocLabelAsFileName
        {
            get
            {
                return m_bUseDocLabelAsFileName;
            }
            set
            {
                m_bUseDocLabelAsFileName = value;
            }
        }

        //--------------------------------------------------------------------
        public string SMTPserver
        {
            get
            {
                return m_strSMTPServer;
            }
            set
            {
                m_strSMTPServer = value;
            }
        }

        //--------------------------------------------------------------------
        public int SMTPort
        {
            get
            {
                return m_nSMTPPort;
            }
            set
            {
                m_nSMTPPort = value;
            }
        }

        //--------------------------------------------------------------------
        public string SMTPUser
        {
            get
            {
                return m_strSMTPUser;
            }
            set
            {
                m_strSMTPUser = value;
            }
        }

        //--------------------------------------------------------------------
        public string SMTPPassword
        {
            get
            {
                return m_strSMTPPassword;
            }
            set
            {
                m_strSMTPPassword = value;
            }
        }

        /// /////////////////////////////////////////////////////////
        private int GetNumVersion()
        {
            //return 0;
            //return 1; // Ajout liste formules destinataires CC (en copie) et BCC (en copie cachée)
            //return 2; // option d'envoi de mail au format HTML
            //return 3; // Option Utiliser le Label du doc GED comme nom de fichier local
            return 4; // Configuration d'un serveur SMTP alternatif
        }

        /// /////////////////////////////////////////////////////////
        protected override CResultAErreur MySerialize(C2iSerializer serializer)
        {
            CResultAErreur result = CResultAErreur.True;
            int nVersion = GetNumVersion();
            result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            result = base.MySerialize(serializer);
            if (!result)
                return result;

            I2iSerializable objet = m_formuleAdresseExpediteur;
            result = serializer.TraiteObject(ref objet);
            if (!result)
                return result;
            m_formuleAdresseExpediteur = (C2iExpression)objet;

            objet = m_formuleSujet;
            result = serializer.TraiteObject(ref objet);
            if (!result)
                return result;
            m_formuleSujet = (C2iExpression)objet;

            objet = m_formuleMessage;
            result = serializer.TraiteObject(ref objet);
            if (!result)
                return result;
            m_formuleMessage = (C2iExpression)objet;

            result = serializer.TraiteArrayListOf2iSerializable(m_listeFormulesMailsDestinatairesTo);
            if (!result)
                return result;

            result = serializer.TraiteArrayListOf2iSerializable(m_listeFormulesPiecesJointes);
            if (!result)
                return result;

            if (nVersion >= 1)
            {
                result = serializer.TraiteArrayListOf2iSerializable(m_listeFormulesMailsDestinatairesCC);
                if (!result)
                    return result;

                result = serializer.TraiteArrayListOf2iSerializable(m_listeFormulesMailsDestinatairesBCC);
                if (!result)
                    return result;

            }

            if (nVersion >= 2)
                serializer.TraiteBool(ref m_bFormatHTML);

            if (nVersion >= 3)
                serializer.TraiteBool(ref m_bUseDocLabelAsFileName);

            if(nVersion >= 4)
            {
                serializer.TraiteString(ref m_strSMTPServer);
                serializer.TraiteInt(ref m_nSMTPPort);
                serializer.TraiteString(ref m_strSMTPUser);
                serializer.TraiteString(ref m_strSMTPPassword);
            }

            return result;
        }

        /// /////////////////////////////////////////////////////////
        public override CResultAErreur VerifieDonnees()
        {
            CResultAErreur result = base.VerifieDonnees();

            if (m_formuleAdresseExpediteur == null)
            {
                result.EmpileErreur(I.T("Incorrect Sender adress formula|389"));
            }
            else if (!m_formuleAdresseExpediteur.TypeDonnee.Equals(new CTypeResultatExpression(typeof(string), false)) &&
                m_formuleAdresseExpediteur.TypeDonnee.TypeDotNetNatif != typeof(timos.acteurs.CActeur))
                result.EmpileErreur(I.T("The sender adress formula must return a text, a Member or a Member Group|390"));

            if (m_formuleSujet == null)
                result.EmpileErreur(I.T("Incorrect subject formula|391"));
            else if (!m_formuleSujet.TypeDonnee.Equals(new CTypeResultatExpression(typeof(string), false)))
                result.EmpileErreur(I.T("The subject formula must return a text|392"));

            if (m_formuleMessage == null)
                result.EmpileErreur(I.T("The message formula is false|393"));
            else if (!m_formuleMessage.TypeDonnee.Equals(new CTypeResultatExpression(typeof(string), false)))
                result.EmpileErreur(I.T("The message formula must return a text|394"));

            // Vérifie qu'il y ai au moins un destinataire
            if (m_listeFormulesMailsDestinatairesTo.Count == 0 &&
                m_listeFormulesMailsDestinatairesCC.Count == 0 &&
                m_listeFormulesMailsDestinatairesBCC.Count == 0)
                result.EmpileErreur(I.T("No recipient|395"));

            // Vérifie les formules d'adresses des destinataires To
            int nDest = 0;
            foreach (C2iExpression exp in m_listeFormulesMailsDestinatairesTo)
            {
                nDest++;
                if (exp == null)
                    result.EmpileErreur(I.T("The recipient @1 formula is incorrect|396", nDest.ToString()));
                else if (exp.TypeDonnee.TypeDotNetNatif != typeof(string) &&
                    exp.TypeDonnee.TypeDotNetNatif != typeof(timos.acteurs.CActeur))
                    result.EmpileErreur(I.T("The recipient @1 formula must return a text, a member, a Member list, a Member Group|397", nDest.ToString()));
            }

            // Vérifie les formules d'adresses des destinataires CC (carbone copie)
            nDest = 0;
            foreach (C2iExpression exp in m_listeFormulesMailsDestinatairesCC)
            {
                nDest++;
                if (exp == null)
                    result.EmpileErreur(I.T("The CC recipient @1 formula is incorrect|10002", nDest.ToString()));
                else if (exp.TypeDonnee.TypeDotNetNatif != typeof(string) &&
                    exp.TypeDonnee.TypeDotNetNatif != typeof(timos.acteurs.CActeur))
                    result.EmpileErreur(I.T("The CC recipient @1 formula must return a text, a Member, a Member list or a Member Group|10003", nDest.ToString()));
            }

            // Vérifie les formules d'adresses des destinataires BCC (Blind carbone copie)
            nDest = 0;
            foreach (C2iExpression exp in m_listeFormulesMailsDestinatairesBCC)
            {
                nDest++;
                if (exp == null)
                    result.EmpileErreur(I.T("The BCC recipient @1 formula is incorrect|10004", nDest.ToString()));
                else if (exp.TypeDonnee.TypeDotNetNatif != typeof(string) &&
                    exp.TypeDonnee.TypeDotNetNatif != typeof(timos.acteurs.CActeur))
                    result.EmpileErreur(I.T("The CC recipient @1 formula must return a text, a Member, a Member list or a Member Group|10005", nDest.ToString()));
            }

            // Vérifie les formules des pièces jointes
            foreach (C2iExpression exp in m_listeFormulesPiecesJointes)
                if (exp.TypeDonnee.TypeDotNetNatif != typeof(sc2i.documents.CDocumentGED))
                    result.EmpileErreur(I.T("The attached file(s) formula must return at least one EDM documents|398"));


            return result;
        }


        /// /////////////////////////////////////////////////////////
        private string GetMail(object obj)
        {
            if (obj is CActeur)
                return ((CActeur)obj).EMail;
            return obj.ToString();
        }

        /// /////////////////////////////////////////////////////////
        protected override CResultAErreur MyExecute(CContexteExecutionAction contexte)
        {
            CResultAErreur result = CResultAErreur.True;

            string strExpediteur = "";
            string strSujet = "";
            string strMessage = "";
            ArrayList lstDestinataires = new ArrayList();
            ArrayList lstDestinatairesCC = new ArrayList();
            ArrayList lstDestinatairesBCC = new ArrayList();
            ArrayList lstIdsDocs = new ArrayList();
            CContexteEvaluationExpression contexteEval = new CContexteEvaluationExpression(contexte.Branche.Process);
            if (m_formuleAdresseExpediteur == null)
            {
                result.EmpileErreur(I.T("Incorrect Sender adress formula|389"));
                return result;
            }
            result = m_formuleAdresseExpediteur.Eval(contexteEval);
            if (!result)
            {
                result.EmpileErreur(I.T("Error during evaluation of the recipient address|399"));
                return result;
            }
            strExpediteur = GetMail(result.Data);

            if (m_formuleSujet == null)
            {
                result.EmpileErreur(I.T("Incorrect subject formula|391"));
                return result;
            }
            result = m_formuleSujet.Eval(contexteEval);
            if (!result)
            {
                result.EmpileErreur(I.T("Error during mail subject evaluation|400"));
                return result;
            }
            strSujet = result.Data.ToString();

            if (m_formuleMessage == null)
            {
                result.EmpileErreur(I.T("The message formula is false|393"));
                return result;
            }
            result = m_formuleMessage.Eval(contexteEval);
            if (!result)
            {
                result.EmpileErreur(I.T("Error during  mail content evaluation|401"));
                return result;
            }
            strMessage = result.Data.ToString();

            // Traite les destinataires To
            foreach (C2iExpression exp in m_listeFormulesMailsDestinatairesTo)
            {
                if (exp != null)
                {
                    result = exp.Eval(contexteEval);
                    if (!result)
                    {
                        result.EmpileErreur(I.T("Error while evaluating one of the recipients|402"));
                        return result;
                    }
                    object res = result.Data;
                    if (res is string)
                        res = ((string)res).Split(new char[] { ';', ',' });

                    if (res is IList)
                        foreach (object obj in ((IList)res))
                        {
                            string strMail = GetMail(obj);
                            if (strMail.Trim() != "")
                                lstDestinataires.Add(strMail);
                        }
                    else if (res.ToString().Trim() != "")
                    {
                        string strMail = GetMail(res);
                        if (strMail.Trim() != "")
                            lstDestinataires.Add(strMail);
                    }
                }
            }

            // Traite les destinataires CC
            foreach (C2iExpression exp in m_listeFormulesMailsDestinatairesCC)
            {
                if (exp != null)
                {
                    result = exp.Eval(contexteEval);
                    if (!result)
                    {
                        result.EmpileErreur(I.T("Error while evaluating one of the recipients|402"));
                        return result;
                    }
                    object res = result.Data;
                    if (res is string)
                        res = ((string)res).Split(new char[] { ';', ',' });

                    if (res is IList)
                        foreach (object obj in ((IList)res))
                        {
                            string strMail = GetMail(obj);
                            if (strMail.Trim() != "")
                                lstDestinatairesCC.Add(strMail);
                        }
                    else if (res.ToString().Trim() != "")
                    {
                        string strMail = GetMail(res);
                        if (strMail.Trim() != "")
                            lstDestinatairesCC.Add(strMail);
                    }
                }
            }

            // Traite les destinataires BCC
            foreach (C2iExpression exp in m_listeFormulesMailsDestinatairesBCC)
            {
                if (exp != null)
                {
                    result = exp.Eval(contexteEval);
                    if (!result)
                    {
                        result.EmpileErreur(I.T("Error while evaluating one of the recipients|402"));
                        return result;
                    }
                    object res = result.Data;
                    if (res is string)
                        res = ((string)res).Split(new char[] { ';', ',' });

                    if (res is IList)
                        foreach (object obj in ((IList)res))
                        {
                            string strMail = GetMail(obj);
                            if (strMail.Trim() != "")
                                lstDestinatairesBCC.Add(strMail);
                        }
                    else if (res.ToString().Trim() != "")
                    {
                        string strMail = GetMail(res);
                        if (strMail.Trim() != "")
                            lstDestinatairesBCC.Add(strMail);
                    }
                }
            }

            // Traite les pièces jointes
            foreach (C2iExpression exp in m_listeFormulesPiecesJointes)
            {
                if (exp != null)
                {
                    result = exp.Eval(contexteEval);
                    if (!result)
                    {
                        result.EmpileErreur(I.T("Error while evaluating one of the recipients|402"));
                        return result;
                    }
                    if (result.Data is IEnumerable)
                        foreach (object obj in ((IList)result.Data))
                        {
                            if (obj is CDocumentGED)
                                lstIdsDocs.Add(((CDocumentGED)obj).Id);
                        }
                    else if (result.Data is CDocumentGED)
                        lstIdsDocs.Add(((CDocumentGED)result.Data).Id);
                }
            }

            // Genere le Mail
            string[] destArray = (string[])lstDestinataires.ToArray(typeof(string));
            string[] destCCArray = (string[])lstDestinatairesCC.ToArray(typeof(string));
            string[] destBCCArray = (string[])lstDestinatairesBCC.ToArray(typeof(string));
            int[] docsArray = (int[])lstIdsDocs.ToArray(typeof(int));
            CMailSC2I mail = new CMailSC2I(
                strExpediteur,
                strSujet,
                strMessage,
                destArray,
                destCCArray,
                destBCCArray,
                docsArray,
                IsFormatHTML,
                UseDocLabelAsFileName,
                SMTPserver,
                SMTPort,
                SMTPUser,
                SMTPPassword);

            // Envoi le mail
            IExpediteurMail expediteur = (IExpediteurMail)C2iFactory.GetNewObjetForSession("CExpediteurMail", typeof(IExpediteurMail), contexte.IdSession);
            result = expediteur.SendMail(mail);

            return result;

        }
    }
}
