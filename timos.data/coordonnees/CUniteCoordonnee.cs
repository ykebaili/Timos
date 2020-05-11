using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;

namespace timos.data
{

	/// <summary>
	/// Objet permettant de d�finir une unit� de mesure<br/>
    /// Exemple : pouce, cm, unit�, etc.<br/><br/>
	/// 
	/// 
	/// Les Unit�s sont fortement li�es au fonctionnement des
	/// <see cref="CSystemeCoordonnees">Syst�mes de Coordonn�es</see>.
	/// <br/><br/>
	/// Pour en savoir plus sur les 
	/// <see cref="CSystemeCoordonnees">Syst�me de Coordonn�es</see> vous pouvez vous r�f�rer
	/// aux multiples ressources.
	/// </summary>
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iCoordonnees)]
    [DynamicClass("Coordinate unit")]
	[Table(CUniteCoordonnee.c_nomTable, CUniteCoordonnee.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CUniteCoordonneeServeur")]
	[Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_SystemeCoor_ID)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_ParamSysCoord_ID)]
    public class CUniteCoordonnee : CObjetDonneeAIdNumeriqueAuto, IObjetALectureTableComplete
	{
        #region [[ Constantes ]]

		public const string c_nomTable = "COORDINATE_UNIT";

        public const string c_champId = "COORUNIT_ID";
		public const string c_champLibelle = "COORUNIT_LABEL";
		public const string c_champAbreviation = "COORUNIT_ABBREV";

        #endregion

		/// /////////////////////////////////////////////
		public CUniteCoordonnee( CContexteDonnee contexte)
			:base(contexte)
		{
		}

		/// /////////////////////////////////////////////
		public CUniteCoordonnee(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get	{ return I.T("Unit @1|196", Libelle); }
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


        #region >> Accesseurs <<
		/// <summary>
		/// Label de l'unit� <br/>
		/// (obligatoire)
		/// </summary>
        [TableFieldProperty(c_champLibelle, 30)]
        [DynamicField("Label")]
        public string Libelle
        {
            get { return (string)Row[c_champLibelle]; }
            set { Row[c_champLibelle] = value; }
		}

		/// <summary>
		/// Abr�viation de l'unit�
		/// </summary>
		[TableFieldProperty(c_champAbreviation, 30)]
		[DynamicField("abbreviation")]
		public string Abreviation
		{
			get	{ return (string)Row[c_champAbreviation]; }
			set	{ Row[c_champAbreviation] = value; }
		}


		

        #endregion

    }
}
