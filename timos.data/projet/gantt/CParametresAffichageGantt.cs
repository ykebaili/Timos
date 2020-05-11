using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using sc2i.common;

namespace timos.data.projet.gantt
{
    public enum EGanttTimeUnit
    {
        Semaine = 0,
        Day =  1,
        Hour = 2,
        Mois = 3
    }
    public class CParametresAffichageGantt
    {
        //Date de début de l'affichage (date à gauche du gantt)
        private DateTime m_dateDebut = DateTime.Now;

        //Largeur d'une cellule de temps
        private int m_nCellWidth = 30;

        //Unité de temps
        private EGanttTimeUnit m_unit = EGanttTimeUnit.Hour;

        //Nombre d'unités dans une case de temps
        private int m_nPrecisionUnit = 1;

        //Hauteur d'une ligne
        private int m_nLineHeight = 40;

        //date de fin d'affichage (date à droite du gantt)
        private DateTime? m_dateFin = null;

        //Largeur utilisée pour calculer la date de fin
        private int m_lastWidthDateFin = 0;

        public CParametresAffichageGantt()
        {
            m_nLineHeight = 20;
        }

       

        public EventHandler OnChangeParametrage;

        private void SendChangeParametrage()
        {
            if (OnChangeParametrage != null)
                OnChangeParametrage(this, null);
            m_dateFin = null;
            
        }

        private void AjusteDateDebut()
        {
            DateTime dt = DateDebut;
            switch (Unit)
            {
                case EGanttTimeUnit.Hour:
                    dt = new DateTime(dt.Year, dt.Month, dt.Day, ((int)(dt.Hour / PrecisionUnit)) * PrecisionUnit, 0, 0);
                    break;
                case EGanttTimeUnit.Day:
                    int nDay = dt.Day-1;
                    nDay = ((int)(nDay/PrecisionUnit))*PrecisionUnit+1;
                    dt = new DateTime(dt.Year, dt.Month, nDay);
                    break;
                case EGanttTimeUnit.Semaine:
                    dt = sc2i.common.CUtilDate.LundiDeSemaine(dt);
                    break;
                case EGanttTimeUnit.Mois :
                    dt = new DateTime(dt.Year, dt.Month, 1);
                    break;
            }
            if (dt != DateDebut)
                m_dateFin = null;
            m_dateDebut = dt;
        }
        

        /// <summary>
        /// Date de début d'affichage
        /// </summary>
        public DateTime DateDebut
        {
            get
            {
                
                return m_dateDebut;
            }
            set
            {
                m_dateDebut = value;
                AjusteDateDebut();
                SendChangeParametrage();
            }
        }

        public DateTime AddUnits(DateTime dt, int nNbUnits)
        {
            switch (Unit)
            {
                case EGanttTimeUnit.Hour:
                    return dt.AddHours(nNbUnits);
                case EGanttTimeUnit.Day:
                    return dt.AddDays(nNbUnits);
                case EGanttTimeUnit.Semaine:
                    return dt.AddDays(nNbUnits * 7);
                case EGanttTimeUnit.Mois :
                    return dt.AddMonths(nNbUnits);
            }
            return dt;
        }

        //---------------------------------------------
        public DateTime AddCells(DateTime date, int nNbCells)
        {
            return AddUnits(date, nNbCells * PrecisionUnit);
        }

        //---------------------------------------------
        public double GetNbUnits(TimeSpan sp)
        {
            switch (Unit)
            {
                case EGanttTimeUnit.Hour:
                    return sp.TotalHours;
                case EGanttTimeUnit.Day:
                    return sp.TotalDays;
                case EGanttTimeUnit.Semaine:
                    return sp.TotalDays / 7;
                case EGanttTimeUnit.Mois :
                    return sp.TotalDays / 30.41;//Moyenne du nombre de jours par mois
            }
            return 0;
        }


        //---------------------------------------------
        public DateTime CalcDateFin(int nTotalWidth)
        {
            if (m_lastWidthDateFin == nTotalWidth && m_dateFin != null)
                return m_dateFin.Value;
            m_lastWidthDateFin = nTotalWidth;
            double fNbCells = (((double)nTotalWidth) / ((double)(CellWidth)));
            DateTime dt = AddCells(DateDebut, (int)fNbCells);
            double frac = fNbCells - (int)fNbCells;
            switch (Unit)
            {
                case EGanttTimeUnit.Hour:
                    dt = dt.AddHours(frac);
                    break;
                case EGanttTimeUnit.Day:
                    dt = dt.AddDays(frac);
                    break;
                case EGanttTimeUnit.Semaine:
                    dt = dt.AddDays(frac * 7);
                    break;
                case EGanttTimeUnit.Mois:
                    int nNbDays = (int)((dt.AddMonths(1) - dt).TotalDays);
                    dt = dt.AddDays(frac * (double)nNbDays);
                    break;
                default:
                    break;
            }
            m_dateFin = dt;
            return dt;
        }

        /// <summary>
        /// Unité d'affichage (heure, jour, mois)
        /// </summary>
        public EGanttTimeUnit Unit
        {
            get
            {
                return m_unit;
            }
            set
            {
                m_unit = value;
                AjusteDateDebut();
                SendChangeParametrage();
            }
        }

        /// <summary>
        /// taille de chaque cellule horizontale
        /// </summary>
        public int CellWidth
        {
            get
            {
                return Math.Max(10,m_nCellWidth);
            }
            set
            {
                m_nCellWidth = value;
                SendChangeParametrage();
            }
        }

        /// <summary>
        /// Précision de l'échélle. 1 indique 1 heure, 1 jour ou 1 mois,
        /// 2, indique 2 heures,  ...
        /// </summary>
        public int PrecisionUnit
        {
            get
            {
                return Math.Max(1,m_nPrecisionUnit);
            }
            set
            {
                m_nPrecisionUnit = Math.Max(1,value);
                AjusteDateDebut();
                SendChangeParametrage();
            }
        }

        /// <summary>
        /// Hauteur de chaque ligne
        /// </summary>
        public int LineHeight
        {
            get
            {
                return Math.Max(10,m_nLineHeight);
            }
            set
            {
                m_nLineHeight = value;
                SendChangeParametrage();
            }
        }

        /// <summary>
        /// Retourne les précisions possibles suivant l'unité
        /// </summary>
        /// <returns></returns>
        public int[] GetPrecisionsPossibles()
        {
            List<int> lstPrecisions = new List<int>();
            switch (Unit)
            {
                case EGanttTimeUnit.Hour:
                    lstPrecisions.AddRange(new int[] { 1, 2, 4, 8, 12 });
                    break;
                case EGanttTimeUnit.Day:
                    lstPrecisions.AddRange(new int[] { 1, 2, 4, 7 });
                    break;
                case EGanttTimeUnit.Semaine:
                    lstPrecisions.AddRange(new int[] { 1, 2, 3, 4, 8 });
                    break;
                case EGanttTimeUnit.Mois :
                    lstPrecisions.AddRange(new int[] { 1, 2, 3, 4, 6 });
                    break;
            }
            return lstPrecisions.ToArray();
        }

        
    }
}
