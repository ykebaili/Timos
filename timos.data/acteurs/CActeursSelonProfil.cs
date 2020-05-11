using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;
using sc2i.process;
using timos.acteurs;
using sc2i.expression;

using timos.securite;

namespace timos.data
{
	/// <summary>
	/// L'acteur selon profil permet de mettre en relation certain types d'entit�s 
	/// avec des profils qui retournent des <see cref="CActeur">acteurs</see>.<br/><br/>
	/// Voici les types d'entit�s concern�es :<br/>
	/// <list type="bullet">
	///		<item><term><see cref="CTypeIntervention">	Types Intervention	</see></term></item>
	///		<item><term><see cref="CTypePhase">			Types Phase			</see></term></item>
	/// </list>
	/// <br/>
	/// Lorsqu'une liste d'acteur est demand�e pour l'une de ces entit�s
	/// le <see cref="CCalendrier">calendrier</see> des acteurs est interrog� et, 
	/// selon leurs occupations du moment, les acteurs retourn�s sont tri�s du 
	/// plus au moins disponible (voir ordre de priorit� d�finie dans les
	/// <see cref="CTypeOccupationHoraire"> types d'occupation horaire</see>).<br/>
	/// Il est egalement possible de ne retourner que les acteurs disponibles.<br/>
	/// Si l'acteur ne dispose pas de calendrier param�tr� ou ne dispose d'aucune
	/// information quant � son activit� actuelle, son statut sera not� comme ind�fini.<br/>
	/// <br/>
	/// <remarks>
	/// A noter que les <see cref="CProfilElement">profils</see> concern�s seront ceux dont
	/// le <see cref="CProfilElement.TypeSource">type source</see> d�fini correspondra 
	/// au type d'entit� choisi et dont le TypeElements d�fini correspondra � 
	/// <see cref="CActeur">Acteur</see>
	/// </remarks>
	/// </summary>
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iActeur)]
    [DynamicClass("Profiled members")]
	[Table(CActeursSelonProfil.c_nomTable, CActeursSelonProfil.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CActeursSelonProfilServeur")]
	public class CActeursSelonProfil :
		CObjetDonneeAIdNumeriqueAuto,
		IObjetALectureTableComplete
                                
	{
		public const string c_nomTable = "PROFILED_MEMBERS";
		public const string c_champId = "PROF_MEMBERS_ID";
		public const string c_champOrdre = "PROF_MEMBERS_ORDER";

		/// /////////////////////////////////////////////
		public CActeursSelonProfil( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	    /// /////////////////////////////////////////////
		public CActeursSelonProfil(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T( "Members according to profile : @1|279") + Id;
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champOrdre};
		}

		/// <summary>
		/// Profil retournant des acteurs
		/// </summary>
		[RelationAttribute(
		  CProfilElement.c_nomTable,
			CProfilElement.c_champId,
			CProfilElement.c_champId,
			true,
			true,
			false)]
		[DynamicField("Element profile")]
		public CProfilElement Profil
		{
			get { return (CProfilElement)GetParent(CProfilElement.c_champId, typeof(CProfilElement)); }
			set { SetParent(CProfilElement.c_champId, value); }
		}

		/// <summary>
		/// Cette methode permet de retourner les acteurs du profil en les filtrant ou 
		/// non sur leur etat (Actif / Inactif)<br/>
		/// De plus, les acteurs retourn�s seront tri�s selon l'ordre de priorit� d�finie
		/// dans le type d'occupation horaire de leur activit� actuelle
		/// </summary>
		/// <param name="elemAActeursPoss"></param>
		/// <param name="AvecInnactif"></param>
		/// <returns></returns>
		public List<CActeur> GetActeurs(IElementAContacts elemAActeursPoss, bool AvecInnactif)
		{
			List<CActeur> m_lstacteurs = new List<CActeur>();

			CListeObjetsDonnees lst = Profil.GetElementsForSource(elemAActeursPoss, new CFiltreData());
			foreach (CObjetDonnee act in lst)
				if (act is CActeur)
					m_lstacteurs.Add((CActeur)act);

			if (!AvecInnactif)
				m_lstacteurs = FiltrerInnactifs(m_lstacteurs);


			return m_lstacteurs;
		}
		

		private List<CActeur> FiltrerInnactifs(List<CActeur> lstActeurs)
		{
			List<CActeur> m_lstacteurstries = new List<CActeur>();
			foreach (CActeur act in lstActeurs)
				if (act.GetHoraires(DateTime.Now, DateTime.Now).Length > 0)
					m_lstacteurstries.Add(act);

			return lstActeurs;
		}

        /// <summary>
        /// Ordre
        /// </summary>
		[TableFieldProperty(c_champOrdre)]
        [DynamicField("Order")]
        public int Ordre
        {
            get
            {
                return (int)Row[c_champOrdre];
            }
            set
            {
				Row[c_champOrdre] = value;
            }
		}


		public ITypeElementAContacts TypeElementAActeursPossibles
		{
			get
			{
				if (TypeIntervention != null)
					return TypeIntervention;
				else if (TypePhase != null)
					return TypePhase;
				else
					return null;
			}
		}


		#region Champs des ITypeElementAActeursPossibles couvert par l'objet
		/// <summary>
		/// Definit que le profil sera affect� � un Type de Phase
		/// </summary>
		[RelationAttribute(
		  CTypePhase.c_nomTable,
		CTypePhase.c_champId,
		CTypePhase.c_champId,
		   false,
			true,
			false)]
		[DynamicField("Phase type")]
		public CTypePhase TypePhase
		{
			get { return (CTypePhase)GetParent(CTypePhase.c_champId, typeof(CTypePhase)); }
			set { SetParent(CTypePhase.c_champId, value); }
		}


		/// <summary>
		/// Definit que le profil sera affect� � un Type d'Intervention
		/// </summary>
		[RelationAttribute(
			 CTypeIntervention.c_nomTable,
			CTypeIntervention.c_champId,
			CTypeIntervention.c_champId,
			false,
			true,
			false)]
		[DynamicField("Intervention type")]
		public CTypeIntervention TypeIntervention
		{
			get { return (CTypeIntervention)GetParent(CTypeIntervention.c_champId, typeof(CTypeIntervention)); }
			set { SetParent(CTypeIntervention.c_champId, value); }
		}
		#endregion
	}

	/// <summary>
	/// Tri les contacts Phase du plus petit au plus grand
	/// </summary>
	public class CActeursSelonProfilPositionComparer : System.Collections.Generic.IComparer<CActeursSelonProfil>
	{
		public int Compare(CActeursSelonProfil x, CActeursSelonProfil y)
		{
			if (x.Ordre > y.Ordre)
				return -1;
			else if (x.Ordre == y.Ordre)
				return 0;
			else
				return 1;
		}
	}
}
