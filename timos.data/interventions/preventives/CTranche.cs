using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using sc2i.data;
using sc2i.common;

namespace timos.data.preventives
{
	public class CTranche
	{
		public CTranche(DateTime dateDebut, DateTime dateFin)
		{
			m_dtStart = dateDebut;
			m_dtEnd = dateFin;
		}
		private DateTime m_dtStart;
		private DateTime m_dtEnd;

		public DateTime DateDebut
		{
			get
			{
				return m_dtStart;
			}
			set
			{
				m_dtStart = value;
			}
		}
		public DateTime DateFin
		{
			get
			{
				return m_dtEnd;
			}
			set
			{
				m_dtEnd = value;
			}
		}
	}
}