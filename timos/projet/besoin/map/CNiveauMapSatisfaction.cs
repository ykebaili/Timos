using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using timos.data.projet.besoin;

namespace timos.projet.besoin.map
{
    //---------------------------------------------------
    public class CNiveauMapSatisfaction
    {
        private List<CDessinSatisfaction> m_listeDessinsVisibleDuNiveau = new List<CDessinSatisfaction>();
        private CBaseMapSatisfaction m_baseSatsifactions = null;

        private int m_nNiveauSatisfaction = 0;

        //---------------------------------------------------
        public CNiveauMapSatisfaction(CBaseMapSatisfaction baseSatisfactions, int nNiveau)
        {
            m_baseSatsifactions = baseSatisfactions;
            m_nNiveauSatisfaction = nNiveau;
        }

        //---------------------------------------------------
        public int NiveauSatisfaction
        {
            get
            {
                return m_nNiveauSatisfaction;
            }
        }

        //---------------------------------------------------
        public CBaseMapSatisfaction BaseSatisfactions
        {
            get
            {
                return m_baseSatsifactions;
            }
        }

        //---------------------------------------------------
        public void AddSatisfactionVisible(CDessinSatisfaction dessin)
        {
            if (!m_listeDessinsVisibleDuNiveau.Contains(dessin))
                m_listeDessinsVisibleDuNiveau.Add(dessin);
        }

        //---------------------------------------------------
        public void RemoveSatisfactionVisible(CDessinSatisfaction dessin)
        {
            if ( m_listeDessinsVisibleDuNiveau.Contains ( dessin ) )
            {
                foreach ( CDessinSatisfaction dessinFils in dessin.DessinsFils )
                    RemoveSatisfactionVisible ( dessinFils );
                m_listeDessinsVisibleDuNiveau.Remove(dessin);
            }
        }

        //---------------------------------------------------
        public IEnumerable<CDessinSatisfaction> Dessins
        {
            get
            {
                return m_listeDessinsVisibleDuNiveau.AsReadOnly();
            }
        }

        //---------------------------------------------------
        public void RemoveDessinPourToujours(CDessinSatisfaction dessin)
        {
            if (m_nNiveauSatisfaction != 0)//On n'enlève jamais au niveau 0, car c'est le seul
                //Niveau qui n'est pas calculé
            {
                if (m_listeDessinsVisibleDuNiveau.Contains(dessin))
                {
                    foreach (CDessinSatisfaction dessinFils in dessin.DessinsFils)
                    {
                        RemoveDessinPourToujours(dessinFils);
                    }
                }
                m_listeDessinsVisibleDuNiveau.Remove(dessin);
                m_baseSatsifactions.UnregisterSatisfaction(dessin.Satisfaction);
            }
        }

        //---------------------------------------------------------------------------
        private int m_nLargeurNiveau = 0;
        public int LargeurNiveau
        {
            get
            {
                return m_nLargeurNiveau;
            }
        }
        //-----------------------------------------------------------------
        public void CalculeDessin( int nX )
        {
            int nYTop = 0;
            foreach ( CDessinSatisfaction dessin in m_listeDessinsVisibleDuNiveau )
            {
                //Déjà calculé ?
                if (dessin.IsVisible() && dessin.IsPositionValide() && dessin.Niveau == this)
                {
                    if (dessin.Rectangle.Left < nX)//recale le dessin sur la bonne position
                        dessin.Offset(nX - dessin.Rectangle.Left, 0);
                    nYTop = Math.Max(dessin.BasZoneOccupee, nYTop);
                }
            }

            foreach ( CDessinSatisfaction dessin in m_listeDessinsVisibleDuNiveau )
            {
                if (dessin.IsVisible() && !dessin.IsPositionValide() && dessin.DessinParent == null)
                {
                    nYTop = dessin.CalculeDessin(nX, nYTop);
                }
            }

            foreach (CDessinSatisfaction dessin in m_listeDessinsVisibleDuNiveau)
            {
                if (dessin.DessinParent == null && dessin.IsVisible() && dessin.IsPositionValide() && !dessin.IsCollapse() )
                {
                    dessin.OffsetChilds(0);
                }
            }

            int nRightNiveau = 0;
            foreach ( CDessinSatisfaction dessin in m_listeDessinsVisibleDuNiveau )
            {
                if (dessin.IsVisible() && dessin.IsPositionValide())
                {
                    nRightNiveau = Math.Max(nRightNiveau, dessin.Rectangle.Right);
                }
            }
            if (nRightNiveau > nX)
                m_nLargeurNiveau = nRightNiveau - nX;
            else
                m_nLargeurNiveau = 0;
        }

        //-----------------------------------------------------------------
        public void FillListeADessiner(List<CDessinSatisfaction> lstDessins)
        {
            foreach (CDessinSatisfaction dessin in Dessins)
            {
                if (dessin.IsVisible() && dessin.IsPositionValide() && dessin.DessinParent == null)
                    AddDessinADessinerAvecFils(dessin, lstDessins);
            }
            
        }

        //-----------------------------------------------------------------
        private void AddDessinADessinerAvecFils(CDessinSatisfaction dessin, List<CDessinSatisfaction> lstDessins)
        {
            lstDessins.Add(dessin);
            foreach (CDessinSatisfaction fils in dessin.DessinsFils)
            {
                if (fils.IsVisible() && fils.IsPositionValide())
                    AddDessinADessinerAvecFils(fils, lstDessins);
            }
        }


    }
}
