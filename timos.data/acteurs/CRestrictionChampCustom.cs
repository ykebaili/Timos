using System;
using System.Collections;

using sc2i.data;
using sc2i.common;

using sc2i.data.dynamic;
using timos.acteurs;
using timos.data;

namespace timos.acteurs
{
	/// <summary>
	/// Permet de restreindre la visibilité de certains champs personnalisés à certains Acteurs ou Groupes d'Acteurs
	/// </summary>
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iSecurite)]
    [DynamicClass("Custom field restriction")]
	[ObjetServeurURI("CRestrictionChampCustomServeur")]
	[Table(CRestrictionChampCustom.c_nomTable, CRestrictionChampCustom.c_champId,true)]
	[FullTableSync]
	public class CRestrictionChampCustom : CObjetDonneeAIdNumeriqueAuto, IObjetALectureTableComplete
	{
		#region Déclaration des constantes
        public const string c_nomTable = "CUSTOM_FIELD_RESTRICTION";
		public const string c_champId = "CUST_FIELD_REST_ID";
        public const string c_champValeurFlag = "CUST_FIELD_REST_VALUE";
        public const string c_champLibelle = "CUST_FIELD_REST_LABEL";
		
		#endregion
		//-------------------------------------------------------------------

		//-------------------------------------------------------------------
		public CRestrictionChampCustom( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRestrictionChampCustom( System.Data.DataRow row )
			:base(row)
		{
		}
		//-------------------------------------------------------------------
		protected override void MyInitValeurDefaut()
		{
		}
		//-------------------------------------------------------------------
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champLibelle};
		}
		//-------------------------------------------------------------------
        /// <summary>
        /// Description
        /// </summary>
		public override string DescriptionElement
		{
			get
			{
				return I.T("Custom field restriction @1|288", Libelle);
			}
		}
		
		//-------------------------------------------------------------------
		/// <summary>
		/// Valeur de la restriction
		/// </summary>
		/// <remarks>
		/// Les restrictions sont attribués au champs sous forme de combinaison de ET binaire.<BR/>
		/// Par exemple, si la valeur du flag est 3,
		/// un champ ayant ce flag positionné vaudra 2^3 (8).<BR></BR>
		/// Un champ ayant comme valeur de flag 12 indique que les flags 
		/// 3 et 2 sont positionnés (2^2+2^3 = 12).<BR></BR>
		/// La valeur maximale d'un flag est 31.
		/// 
		/// </remarks>
		[TableFieldProperty(c_champValeurFlag)]
		[DynamicField("Flag value")]
		public int ValeurFlag
		{
			get
			{
				return (int)Row[c_champValeurFlag];
			}
			set
			{
				Row[c_champValeurFlag] = value;
			}
		}

		

		//-------------------------------------------------------------------
		/// <summary>
		/// Donne un nom à la restriction
		/// </summary>
		[TableFieldProperty(c_champLibelle, 255)]
		[DynamicField("Label")]
		public string Libelle
		{
			get
			{
				return(  string )Row[c_champLibelle];
			}
			set
			{
				Row[c_champLibelle] = value;
			}
		}
	}

	/// <summary>
	/// Permet de gérer un flag de champ custom de manière conviviale
	/// </summary>
	public class CRestrictionChampCustomConvivial
	{
		private int m_nFlag = 0;
		private string m_strLibelle = null;
		private CContexteDonnee m_contexte;
		
		public CRestrictionChampCustomConvivial ( CContexteDonnee contexte, int nFlag )
		{
			m_contexte = contexte;
			m_nFlag = nFlag;
		}

		[DynamicField("Flag")]
		public int Flag
		{
			get
			{
				return m_nFlag;
			}
			set
			{
				if ( value != m_nFlag )
					m_strLibelle = null;
				m_nFlag = value;
			}
		}

		[DynamicField("Label")]
		public string Libelle
		{
			get
			{
				if ( m_strLibelle != null )
					return m_strLibelle;
				CListeObjetsDonnees listeFlags = new CListeObjetsDonnees ( m_contexte, typeof(CRestrictionChampCustom));
				string strLibelle = "";
				foreach ( CRestrictionChampCustom flag in listeFlags )
					if ( (m_nFlag & ((int)Math.Pow ( 2, flag.ValeurFlag) ) ) != 0 )
						strLibelle += flag.Libelle+",";
				if ( strLibelle.Length > 0 )
					strLibelle = strLibelle.Substring ( 0, strLibelle.Length-1);
				m_strLibelle = strLibelle;
				return strLibelle;
			}
		}

		public override string ToString()
		{
			return Libelle;
		}

		//-------------------------------------------------------------------
		[DynamicMethod("Set a flag of this custom field to true","Value (power of 2) of flag")]
		public void PositionneFlag ( int nFlag )
		{
			Flag |= (int)Math.Pow(2, nFlag);
		}

		//-------------------------------------------------------------------
        [DynamicMethod("Set a flag of this custom field to false", "Value (power of 2) of flag")]
		public void EnleveFlag ( int nFlag )
		{
			Flag &= ~((int)Math.Pow(2, nFlag));
		}

		//-------------------------------------------------------------------
        [DynamicMethod("Indicates (true or false) if a flag is set", "Value (power of 2) of flag")]
		public bool HasFlag ( int nFlag )
		{
			return (Flag & ((int)Math.Pow ( 2, nFlag))) == (int)Math.Pow(2, nFlag);
		}
	}
}
