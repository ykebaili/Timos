using System;
using System.Collections;

using sc2i.common;

namespace timos.data
{
	/// <summary>
	/// LA gestion des etats NonPLanifiee, Preplanifiee et planifiée est géré par TIMOS.
	/// Les autres etats 30, 50 et 60 sont gerés par des process client. Il ne
	/// faut donc jamais implémenter dans TIMOS qqchose qui passe à ces états
	/// là, ou qui tienne compte de ces états, pour rester compatible avec les 
	/// process des clients
	/// (par exemple, chez audilog, les etat
	/// </summary>
    public enum EtatIntervention
	{
		NonPlanifiee = 0,
		Preplanifiee = 10,
		Planifiee = 20,
		EnCours = 30,
		Terminee = 50,
		Annulee = 60
	}
	public class CEtatIntervention : IComparable
	{
		/// //////////////////////////////////////////////////////
		private EtatIntervention m_statut;

		/// //////////////////////////////////////////////////////
		public CEtatIntervention(EtatIntervention statut)
		{
			m_statut = statut;
		}

		/// //////////////////////////////////////////////////////
		public override string ToString()
		{
			switch ( m_statut )
			{
				case EtatIntervention.NonPlanifiee:
					return I.T( "Not planned|153");
				case EtatIntervention.Preplanifiee :
					return I.T( "Pre-planned|154");
				case EtatIntervention.Planifiee :
					return I.T( "Planned|155");
				case EtatIntervention.EnCours :
					return I.T( "In progress|156");
				case EtatIntervention.Terminee :
					return I.T( "Ended|158");
				case EtatIntervention.Annulee :
					return I.T( "Cancelled|159");
			}
			return "";
		}

		 //////////////////////////////////////////////////////
		/// <summary>
		/// Label de l'Etat d'Intervention<br/>
		/// (obligatoire)
		/// </summary>
		[DynamicField("Label")]
		public string Libelle
		{
			get
			{
				return ToString();
			}
		}

		 //////////////////////////////////////////////////////
		/// <summary>
		/// Code de l'Etat d'Intervention
		/// </summary>
		[DynamicField("Code")]
		public int EtatInt
		{
			get
			{
				return (int) m_statut;
			}
			set
			{
				m_statut = (EtatIntervention) value;
			}
		}

		/// //////////////////////////////////////////////////////
		public EtatIntervention Etat
		{
			get
			{
				return m_statut;
			}
			set
			{
				m_statut = value;
			}
		}

		/// //////////////////////////////////////////////////////
		public int CompareTo(object obj)
		{
			if (! (obj is CEtatIntervention) ) 
				return 1;

			return ( Etat.CompareTo( ((CEtatIntervention)obj).Etat) );
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
		

		public static CEtatIntervention[] Etats
		{
			get
			{
				ArrayList lst = new ArrayList();
				foreach (EtatIntervention statut in Enum.GetValues(typeof(EtatIntervention)))
				{
					lst.Add ( new CEtatIntervention ( statut ));	
				}
				return (CEtatIntervention[])lst.ToArray ( typeof ( CEtatIntervention ) );
			}
		}
	}
}
