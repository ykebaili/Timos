using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;

using tiag.client;

using timos.data;

namespace timos.acteurs
{
	/// <summary>
	/// Permet de définir la civilité d'un acteur (ex: Monsieur, Madame, société...)
	/// </summary>
    /// <remarks>
    /// Le terme acteur est pris au sens large; ce peut être une personne physique ou morale
    /// </remarks>
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iActeur)]
    [DynamicClass("Civility")]
	[Table(CCivilite.c_nomTable, CCivilite.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CCiviliteServeur")]
	[TiagClass(CCivilite.c_nomTiag, "Id", true)]
	public class CCivilite : CObjetDonneeAIdNumeriqueAuto,
		IObjetALectureTableComplete,
		IElementAInterfaceTiag
	{
		public const string c_nomTiag = "Civility";
		public const string c_nomTable = "CIVILITY";
		public const string c_champId = "CIVILITY_ID";
		public const string c_champLibelle = "CIVILITY_LABEL";

		/// /////////////////////////////////////////////
		public CCivilite( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	/// /////////////////////////////////////////////
		public CCivilite(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("Civility : @1|280",Libelle);
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champLibelle};
		}


		

		/// <summary>
		/// Le libellé de la civilité
		/// </summary>
		[TableFieldProperty(c_champLibelle, 30)]
		[DynamicField("Label")]
		[TiagField("Label")]
		public string Libelle
		{
			get
			{
				return (string)Row[c_champLibelle];
			}
			set
			{
				Row[c_champLibelle] = value;
			}
		}

		#region IElementAInterfaceTiag Membres

		public object[] TiagKeys
		{
			get { return new object[] { Id }; }
		}

		public string TiagType
		{
			get { return c_nomTiag; }
		}

		#endregion


	}
}
