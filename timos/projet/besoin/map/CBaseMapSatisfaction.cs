using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using timos.data.projet.besoin;
using System.Drawing;

namespace timos.projet.besoin.map
{
    public class CBaseMapSatisfaction
    {
        private List<CNiveauMapSatisfaction> m_listeNiveaux = new List<CNiveauMapSatisfaction>();

        private Dictionary<ISatisfactionBesoin, CDessinSatisfaction> m_dicSatisfactionToDessin = new Dictionary<ISatisfactionBesoin, CDessinSatisfaction>();

        public int m_nLargeurNiveauDefaut = 150;
        public int m_nHauteurSatisfactionDefaut = 40;
        public int m_nMargeVerticale = 15;
        public int m_nLargeurFleches = 140;
        public int m_nOffestNiveau = 30;

        //---------------------------------------------------
        public CBaseMapSatisfaction()
        {
        }

        //---------------------------------------------------
        public void Init ( List<ISatisfactionBesoin> lstSatisfactions )
        {
            m_dicSatisfactionToDessin = new Dictionary<ISatisfactionBesoin, CDessinSatisfaction>();
            m_listeNiveaux = new List<CNiveauMapSatisfaction>();

            //Création du niveau 0
            CNiveauMapSatisfaction niveau = new CNiveauMapSatisfaction(this, 0);
            m_listeNiveaux.Add ( niveau );
            foreach ( ISatisfactionBesoin satisfaction in lstSatisfactions )
            {
                if (!IsDejaIntegréee(satisfaction))
                {
                    CDessinSatisfaction dessin = new CDessinSatisfaction(niveau, satisfaction);
                    niveau.AddSatisfactionVisible(dessin);
                }
            }
            RecalculePrecedents(niveau );
            RecalculeSuivants(niveau);
        }

        //---------------------------------------------------
        public void RecalculePrecedents(CNiveauMapSatisfaction niveau)
        {
            //Récupère le niveau précédent
            CNiveauMapSatisfaction niveauPrec = null;
            foreach ( CNiveauMapSatisfaction niveauAutre in m_listeNiveaux )
            {
                if ( niveauAutre.NiveauSatisfaction == niveau.NiveauSatisfaction-1 )
                {
                    niveauPrec = niveauAutre;
                    break;
                }
            }
            if ( niveauPrec == null )
            {
                //Création du niveau précédent
                niveauPrec = new CNiveauMapSatisfaction(this, niveau.NiveauSatisfaction-1);
                m_listeNiveaux.Insert ( 0, niveauPrec );
            }

            HashSet<CDessinSatisfaction> dessinsRacinesToRemove = new HashSet<CDessinSatisfaction>();
            foreach (CDessinSatisfaction dessin in niveauPrec.Dessins)
            {
                if (dessin.DessinParent == null)
                    dessinsRacinesToRemove.Add(dessin);
            }

            foreach (CDessinSatisfaction dessin in niveau.Dessins)
            {
                foreach (CRelationBesoin_Satisfaction rel in dessin.Satisfaction.RelationsSatisfaits)
                {
                    CDessinSatisfaction dessinBesoin = GetDessin(rel.Besoin);
                    if (dessinBesoin == null )
                    {
                        dessinBesoin = new CDessinSatisfaction(niveauPrec, rel.Besoin);
                        niveauPrec.AddSatisfactionVisible(dessinBesoin);
                    }
                    dessinsRacinesToRemove.Remove(dessinBesoin);
                }
            }

            //retire les besoins racine qui doivent virer
            foreach (CDessinSatisfaction dessin in dessinsRacinesToRemove)
            {
                niveauPrec.RemoveDessinPourToujours(dessin);
            }

            if (niveauPrec.Dessins.Count() > 0)
                RecalculePrecedents(niveauPrec);
        }

        //---------------------------------------------------
        public void RecalculeSuivants(CNiveauMapSatisfaction niveau)
        {
            //Récupère le niveau suivant
            CNiveauMapSatisfaction niveauSuiv = null;
            foreach (CNiveauMapSatisfaction niveauAutre in m_listeNiveaux)
            {
                if (niveauAutre.NiveauSatisfaction == niveau.NiveauSatisfaction + 1)
                {
                    niveauSuiv = niveauAutre;
                    break;
                }
            }
            if (niveauSuiv == null)
            {
                //Création du niveau précédent
                niveauSuiv = new CNiveauMapSatisfaction(this, niveau.NiveauSatisfaction + 1);
                m_listeNiveaux.Add(niveauSuiv);
            }

            HashSet<CDessinSatisfaction> dessinsRacinesToRemove = new HashSet<CDessinSatisfaction>();
            foreach (CDessinSatisfaction dessin in niveauSuiv.Dessins)
            {
                if (dessin.DessinParent == null)
                    dessinsRacinesToRemove.Add(dessin);
            }

            foreach (CDessinSatisfaction dessin in niveau.Dessins)
            {
                CBesoin besoin = dessin.Satisfaction as CBesoin;
                if ( besoin != null )
                {
                    string strLib = besoin.Libelle;
                    foreach (CRelationBesoin_Satisfaction rel in besoin.RelationsSatisfactions)
                    {
                        CDessinSatisfaction dessinBesoin = GetDessin(rel.Satisfaction);
                        if (dessinBesoin == null && rel.Satisfaction != null)
                        {
                            dessinBesoin = new CDessinSatisfaction(niveauSuiv, rel.Satisfaction);
                            niveauSuiv.AddSatisfactionVisible(dessinBesoin);
                        }
                        dessinsRacinesToRemove.Remove(dessinBesoin);
                    }
                }
            }

            //retire les besoins racine qui doivent virer
            foreach (CDessinSatisfaction dessin in dessinsRacinesToRemove)
            {
                niveauSuiv.RemoveDessinPourToujours(dessin);
            }

            if (niveauSuiv.Dessins.Count() > 0)
                RecalculeSuivants(niveauSuiv);
        }

        //---------------------------------------------------
        private Size m_totalSize = new Size(10, 10);
        public void CalculeDessin()
        {
            foreach ( CDessinSatisfaction dessin in m_dicSatisfactionToDessin.Values )
                dessin.SetPositionInvalide();

            int nX = m_nLargeurFleches / 2;
            int nY = m_nMargeVerticale;

            foreach (CNiveauMapSatisfaction niveau in m_listeNiveaux)
            {
                niveau.CalculeDessin(nX);
                if ( niveau.LargeurNiveau > 0 )
                    nX += niveau.LargeurNiveau + m_nLargeurFleches;
            }
            int nWidth = 10;
            int nHeight = 10;
            foreach (CDessinSatisfaction dessin in m_dicSatisfactionToDessin.Values)
            {
                if (dessin.IsVisible() && dessin.IsPositionValide())
                {
                    nWidth = Math.Max(nWidth, dessin.Rectangle.Right);
                    nHeight = Math.Max(nHeight, dessin.Rectangle.Height);
                }
            }
            m_totalSize = new Size(nWidth, nHeight);
            if (OnChangementDansDessin != null)
                OnChangementDansDessin(this, null);
        }

        //---------------------------------------------------
        public Size TotalSize
        {
            get
            {
                return m_totalSize;
            }
        }
                
        

        //---------------------------------------------------
        public bool IsDejaIntegréee ( ISatisfactionBesoin satisfaction )
        {
            return m_dicSatisfactionToDessin.ContainsKey  ( satisfaction );
        }

        //---------------------------------------------------
        public CDessinSatisfaction GetDessin(ISatisfactionBesoin satisfaction)
        {
            CDessinSatisfaction de = null;
            if (satisfaction == null)
                return null;
            m_dicSatisfactionToDessin.TryGetValue(satisfaction, out de);
            return de;
        }

        //---------------------------------------------------
        public void RegisterDessin ( CDessinSatisfaction dessin )
        {
            m_dicSatisfactionToDessin[dessin.Satisfaction] = dessin;
        }

        //---------------------------------------------------
        public void UnregisterSatisfaction(ISatisfactionBesoin satisfaction)
        {
            if (m_dicSatisfactionToDessin.ContainsKey(satisfaction))
                m_dicSatisfactionToDessin.Remove(satisfaction);
        }

        //---------------------------------------------------
        public int NiveauMin
        {
            get
            {
                if (m_listeNiveaux.Count > 0)
                    return m_listeNiveaux[0].NiveauSatisfaction;
                return 0;
            }
        }

        //---------------------------------------------------
        public int NiveauMax
        {
            get
            {
                if (m_listeNiveaux.Count > 0)
                    return m_listeNiveaux[m_listeNiveaux.Count - 1].NiveauSatisfaction;
                return 0;
            }
        }

        //---------------------------------------------------
        public CDessinSatisfaction GetDessinAt(Point pt)
        {
            CDessinSatisfaction dessinTrouve = null;
            foreach (CDessinSatisfaction dessin in m_dicSatisfactionToDessin.Values)
            {
                if (dessin.IsVisible() && dessin.Rectangle.Contains(pt) && (dessinTrouve == null ||dessinTrouve.Rectangle.Height > dessin.Rectangle.Height))
                {
                    dessinTrouve = dessin;
                }
            }
            return dessinTrouve;
        }

        //---------------------------------------------------
        public List<CDessinSatisfaction> GetListeADessiner()
        {
            List<CDessinSatisfaction> lstDessins = new List<CDessinSatisfaction>();
            foreach (CNiveauMapSatisfaction niveau in m_listeNiveaux)
                niveau.FillListeADessiner(lstDessins);
            return lstDessins;
        }

        public event EventHandler OnChangementDansDessin;

        //---------------------------------------------------
        internal void OnChangeNiveau(CNiveauMapSatisfaction niveauQuiABougé)
        {
            //Recalcule à partir du niveau 0
            CNiveauMapSatisfaction niveau0 = null;
            foreach (CNiveauMapSatisfaction test in m_listeNiveaux)
            {
                if (test.NiveauSatisfaction == 0)
                {
                    niveau0 = test;
                    break;
                }
            }
            if (niveau0 != null)
            {
                RecalculePrecedents(niveau0);
                RecalculeSuivants(niveau0);
                CalculeDessin();
            }
        }
    }


    
}
