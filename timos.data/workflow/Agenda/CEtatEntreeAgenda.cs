using System;
using System.Collections;

using sc2i.common;

namespace sc2i.workflow
{
	/// <summary>
	/// Description résumée de CEtatEntreeAgenda.
	/// </summary>
	public enum EtatEntreeAgenda
	{
		Info = 0,
		AFaire = 1,
		EnCours = 2,
		Terminee = 3,
		Annulee = 4
	}
	public class CEtatEntreeAgenda : IComparable
	{
		

		/// //////////////////////////////////////////////////////
		private EtatEntreeAgenda m_etat;

		/// //////////////////////////////////////////////////////
		public CEtatEntreeAgenda(EtatEntreeAgenda etat)
		{
			m_etat = etat;
		}

		/// //////////////////////////////////////////////////////
		public override string ToString()
		{
			switch ( m_etat )
			{
				case EtatEntreeAgenda.Info :
					return "Information|309";
				case EtatEntreeAgenda.AFaire :
					return "Planned|155";
				case EtatEntreeAgenda.EnCours :
					return "In progress|156";
				case EtatEntreeAgenda.Terminee :
					return "Ended|311";
				case EtatEntreeAgenda.Annulee :
					return "Cancelled|310";
			}
			return "";
		}

		/// //////////////////////////////////////////////////////
		[DynamicField("Label")]
		public string Libelle
		{
			get
			{
				return ToString();
			}
		}

		/// //////////////////////////////////////////////////////
		[DynamicField("Code")]
		public int EtatInt
		{
			get
			{
				return (int) m_etat;
			}
			set
			{
				m_etat = (EtatEntreeAgenda) value;
			}
		}

		/// //////////////////////////////////////////////////////
		public EtatEntreeAgenda Etat
		{
			get
			{
				return m_etat;
			}
			set
			{
				m_etat = value;
			}
		}

		/// //////////////////////////////////////////////////////
		public int CompareTo(object obj)
		{
			if (! (obj is CEtatEntreeAgenda) ) 
				return 1;

			return ( Etat.CompareTo( ((CEtatEntreeAgenda)obj).Etat) );
		}

		/// //////////////////////////////////////////////////////
		public override bool Equals ( object obj )
		{
			return CompareTo ( obj ) == 0;
		}

		
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
		

		public static CEtatEntreeAgenda[] Etats
		{
			get
			{
				ArrayList lst = new ArrayList();
				lst.Add ( new CEtatEntreeAgenda(EtatEntreeAgenda.Info));
				lst.Add(new CEtatEntreeAgenda( EtatEntreeAgenda.AFaire ));
				lst.Add(new CEtatEntreeAgenda( EtatEntreeAgenda.EnCours ));
				lst.Add(new CEtatEntreeAgenda( EtatEntreeAgenda.Terminee ));
				lst.Add(new CEtatEntreeAgenda( EtatEntreeAgenda.Annulee ));
				return (CEtatEntreeAgenda[])lst.ToArray(typeof(CEtatEntreeAgenda));
			}
		}
	}
}
