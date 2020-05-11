using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using sc2i.data;
using sc2i.common;

using timos.data.preventives;

namespace timos.data
{
	/// <summary>
	/// Cette classe permet de préparer un découpage
	/// </summary>
	public class CDecoupage
	{
		
		public CDecoupage(DateTime dtStart, DateTime dtEnd, int nbPeriode, EEchelleTemps periodicite, bool arrondire, EEchelleTemps niveauArrondit)
		{
			m_bArrondire = arrondire;
			m_dtFin = dtEnd;
			m_dtStart = dtStart;
			m_nivArrondit = niveauArrondit;
			if (m_bArrondire)
			{
				m_dtFin = Arrondire(m_dtFin, m_nivArrondit);
				m_dtStart = Arrondire(m_dtStart, m_nivArrondit);
			}
			m_periodicite = periodicite;
			m_nbPeriode = nbPeriode;
			m_nLimiteTranche = -1;

			MAJDecoupage();
		}

		public static DateTime Arrondire(DateTime date, EEchelleTemps periode)
		{
			switch (periode)
			{
				case EEchelleTemps.Heure:
					return new DateTime(date.Year, date.Month, date.Day, date.Hour, 0, 0);
				case EEchelleTemps.Jour:
					return date.Date;
				case EEchelleTemps.Mois:
					return new DateTime(date.Year, date.Month, 1);
				case EEchelleTemps.Semaine:
					return CUtilDate.LundiDeSemaine(date);
					
				case EEchelleTemps.Annee:
					return new DateTime(date.Year,1,1);
			}
			return date;
		}

		private bool m_bArrondire;
		public bool ArrondireDatesAuPlusPetit
		{
			get
			{
				return m_bArrondire;
			}
			set
			{
				m_bArrondire = value;
			}
		}

		private bool m_bValide;
		private EEchelleTemps m_periodicite;
		private int m_nbPeriode;
		private DateTime m_dtStart;
		private DateTime m_dtFin;
		private EEchelleTemps m_nivArrondit;
		public EEchelleTemps NiveauArrondit
		{
			get
			{
				return m_nivArrondit;
			}
			set
			{
				m_nivArrondit = value;
			}
		}

		public string Erreur
		{
			get
			{
				if (DateDebut > DateFin)
					return I.T("The start date cannot be before the end date|543");
				if (NombreLimiteDeTranche != -1 && NbTranche > NombreLimiteDeTranche)
					return I.T("Current number of sections exceeds the maximum number of sections authorized (@1 section(s) authorized)|542", NombreLimiteDeTranche.ToString());
				return "";
			}
		}

		public void Avancer()
		{
			TimeSpan diff = m_dtFin - m_dtStart;
			m_dtStart = m_dtFin;
			m_dtFin = m_dtFin.Add(diff);
			MAJDecoupage();
		}
		public void Reculer()
		{
			TimeSpan diff = m_dtFin - m_dtStart;
			m_dtFin = m_dtStart;
			m_dtStart = m_dtStart.Subtract(diff);
			MAJDecoupage();
		}

		private List<CTranche> m_tranches;
		private int m_nLimiteTranche;
		public int NombreLimiteDeTranche
		{
			get
			{
				return m_nLimiteTranche;
			}
			set
			{
				m_nLimiteTranche = value;
				m_bValide = value == -1 || value >= NbTranche;
			}
		}

		public DateTime DateFin
		{
			get
			{
				return m_dtFin;
			}
			set
			{
				m_dtFin = value;

				if (ArrondireDatesAuPlusPetit)
					m_dtFin = Arrondire(m_dtFin,NiveauArrondit);

				MAJDecoupage();
			}
		}
		public DateTime DateFinSelonTranches
		{
			get
			{
				if (NbTranche > 0)
					return Tranches[NbTranche - 1].DateFin;
				else
					return DateFin;
			}
		}
		public DateTime DateDebut
		{
			get
			{
				return m_dtStart;
			}
			set
			{
				m_dtStart = value;

				if (ArrondireDatesAuPlusPetit)
					m_dtStart = Arrondire(m_dtStart, NiveauArrondit);
				MAJDecoupage();
			}
		}


		public EEchelleTemps Periodicite
		{
			get
			{
				return m_periodicite;
			}
			set
			{
				m_periodicite = value;
				MAJDecoupage();
			}
		}
		public int NombrePeriode
		{
			get
			{
				return m_nbPeriode;
			}
			set
			{
                if (value > 0)
                {
                    m_nbPeriode = value;
                    MAJDecoupage();
                }
			}
		}

		public List<CTranche> Tranches
		{
			get
			{
				return m_tranches;
			}
		}

		public int NbTranche
		{
			get
			{
                if(Tranches != null)
				    return Tranches.Count;
                return 0;
			}
		}

		//Retourne les tranches concernées par l'interval
		public List<CTranche> GetTranchesConcernees(DateTime dtStart, DateTime dtEnd)
		{
			if (ArrondireDatesAuPlusPetit)
			{
				dtStart = Arrondire(dtStart, NiveauArrondit);
				dtEnd = Arrondire(dtEnd, NiveauArrondit);
			}
			List<CTranche> retour = new List<CTranche>();
			if (dtStart < dtEnd)
				foreach (CTranche t in m_tranches)
					if (dtStart < t.DateFin && dtEnd > t.DateDebut)
						retour.Add(t);
			return retour;
		}
		//Retourne les dates des tranches concernées
		public List<DateTime> GetDatesConcernees(DateTime dtStart, DateTime dtEnd)
		{
			if (ArrondireDatesAuPlusPetit)
			{
				dtStart = Arrondire(dtStart, NiveauArrondit);
				dtEnd = Arrondire(dtEnd, NiveauArrondit);
			}

			List<DateTime> retour = new List<DateTime>();
			if (dtStart < dtEnd)
			{
				foreach (CTranche t in m_tranches)
					if (t.DateDebut >= dtStart && t.DateDebut <= dtEnd)
						retour.Add(t.DateDebut);

				if (m_tranches.Count > 0)
				{
					CTranche t = m_tranches[m_tranches.Count - 1];
					if (t.DateFin >= dtStart && t.DateFin <= dtEnd)
						retour.Add(t.DateFin);
				}
			}
			return retour;
		}

		public CTranche this[int indexTranche]
		{
			get
			{
				return m_tranches[indexTranche];
			}
		}

		private void MAJDecoupage()
		{
			m_tranches = new List<CTranche>();

			m_bValide = m_dtFin > m_dtStart;
			if (m_bValide)
			{
				DateTime dt = m_dtStart;
				while (dt < m_dtFin)
				{
					DateTime dtNextPos = AvancerDate(dt);
					m_tranches.Add(new CTranche(dt, dtNextPos));
					dt = dtNextPos;
				}
			}
			m_bValide = m_nLimiteTranche == -1 || m_nLimiteTranche >= NbTranche;

		}
		private DateTime AvancerDate(DateTime dt)
		{
			switch (m_periodicite)
			{
				case EEchelleTemps.Heure:
					return dt.AddHours(m_nbPeriode);
				case EEchelleTemps.Semaine:
					return dt.AddDays(7 * m_nbPeriode);
				case EEchelleTemps.Jour:
					return dt.AddDays(m_nbPeriode);
				default:
				case EEchelleTemps.Mois:
					return dt.AddMonths(m_nbPeriode);
				case EEchelleTemps.Annee:
					return dt.AddYears(m_nbPeriode);
			}
		}

		public bool Valide
		{
			get
			{
				return m_bValide;
			}
		}
	}
}