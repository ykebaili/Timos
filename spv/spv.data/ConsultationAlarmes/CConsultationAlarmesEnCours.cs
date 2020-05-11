using System;
using System.Collections.Generic;
using System.Text;
using sc2i.common;
using sc2i.expression;
using sc2i.data.dynamic;

using spv.data.ConsultationAlarmes;
using System.Collections;

namespace spv.data
{
    [Serializable]
    public class CConsultationAlarmesEnCours : I2iSerializable
    {
        private C2iExpression m_formuleFiltre = null;
        private int m_nDelaiMasquageTerminees = 10; // en minutes
        //private List<CFormuleNommee> m_listeColonnes = new List<CFormuleNommee>();
        private List<C2iChampExport> m_listeColonnes = new List<C2iChampExport>();

        public CConsultationAlarmesEnCours()
        {
        }

        public C2iExpression FormuleFiltre
        {
            get
            {
                return m_formuleFiltre;
            }
            set
            {
                m_formuleFiltre = value;

            }
        }

        public int DelaiMasquageTerminnees
        {
            get
            {
                return m_nDelaiMasquageTerminees;
            }
            set
            {
                m_nDelaiMasquageTerminees = value;
            }
        }

        /*
        public CFormuleNommee[] ListeColonnes
        {
            get
            {
                if (m_listeColonnes == null)
                    m_listeColonnes = new List<CFormuleNommee>();
                return m_listeColonnes.ToArray();
            }
            set
            {
                m_listeColonnes.Clear();
                if (value != null)
                    foreach (CFormuleNommee formule in value)
                        m_listeColonnes.Add(formule);
            }
        }*/

        public C2iChampExport[] ListeColonnes
        {
            get
            {
                if (m_listeColonnes == null)
                    m_listeColonnes = new List<C2iChampExport>();
                return m_listeColonnes.ToArray();
            }
            set
            {
                m_listeColonnes.Clear();
                if (value != null)
                    foreach (C2iChampExport champ in value)
                        m_listeColonnes.Add(champ);
            }
        }

        private int GetNumVersion()
        {
            return 2;
            //V1 : transformation de la liste de CDEfinitionProprietesDynamiques en liste de formules
            //V2 : transformation de la liste de "CFormuleNommee" en liste de "C2iChampExport"
        }


        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;

            result = serializer.TraiteObject<C2iExpression>(ref m_formuleFiltre);
            if (!result)
                return result;
            serializer.TraiteInt(ref m_nDelaiMasquageTerminees);
            if (nVersion < 1)
            {
                List<CDefinitionProprieteDynamique> lstTmp = new List<CDefinitionProprieteDynamique>();
                result = serializer.TraiteListe<CDefinitionProprieteDynamique>(lstTmp);
            }
            else if (nVersion < 2)
            {
                //Transformation de la liste de "CFormuleNommee" en liste de "C2iCHampExport"
                if (m_listeColonnes == null)
                    m_listeColonnes = new List<C2iChampExport>();

                List<CFormuleNommee> tmpListe = new List<CFormuleNommee>();
                result = serializer.TraiteListe<CFormuleNommee>(tmpListe);
                if (result)
                {
                    foreach (CFormuleNommee formule in tmpListe)
                    {
                        C2iChampExport tmpChamp = new C2iChampExport();
                        tmpChamp.Origine = new C2iOrigineChampExportExpression(formule.Formule);
                        tmpChamp.NomChamp = formule.Libelle;
                        m_listeColonnes.Add(tmpChamp);
                    }
                }
            }
            else
            {
                if (m_listeColonnes == null)
                    m_listeColonnes = new List<C2iChampExport>();
                result = serializer.TraiteListe<C2iChampExport>(m_listeColonnes);
            }

            if (!result)
                return result;

            
            return result;
        }

        //-----------------------------------------------------------------
        public ArrayList GetDataToDisplay(CInfoAlarmeAffichee infoAlarme)
        {
            /*
            ArrayList lst = new ArrayList();
            CContexteEvaluationExpression ctxEval = new CContexteEvaluationExpression(infoAlarme);
            foreach (CFormuleNommee formule in ListeColonnes)
            {
                object valeur = null;
                if (formule.Formule != null)
                {
                    CResultAErreur result = formule.Formule.Eval(ctxEval);
                    if (result)
                        valeur = result.Data;
                    else
                        valeur = I.T("#Error|20016");
                }
                lst.Add(valeur);
            }
            return lst;*/
            ArrayList lst = new ArrayList();
            CContexteEvaluationExpression ctxEval = new CContexteEvaluationExpression(infoAlarme);

            foreach (C2iChampExport champ in m_listeColonnes)
            {
                object valeur = champ.GetValeur ( infoAlarme, null );
                lst.Add(valeur);
            }
            return lst;
        }

        public List<string> GetColumnNames()
        {
            List<string> lst = new List<string>();
            /*
            foreach (CFormuleNommee formule in ListeColonnes)
            {
                lst.Add(formule.Libelle);
            }*/

            foreach (C2iChampExport champ in m_listeColonnes)
            {
                lst.Add(champ.NomChamp);
            }
            return lst;
        }
    }
}
