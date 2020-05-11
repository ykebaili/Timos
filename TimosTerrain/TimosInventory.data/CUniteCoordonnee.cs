using System;
using System.Collections;
using System.Data;

using sc2i.common;
using sc2i.common.memorydb;

namespace TimosInventory.data
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
    [DynamicClass("Coordinate unit")]
	[MemoryTable(CUniteCoordonnee.c_nomTable, CUniteCoordonnee.c_champId )]
    public class CUniteCoordonnee : CEntiteLieeATimos
	{
        #region [[ Constantes ]]

		public const string c_nomTable = "COORDINATE_UNIT";

        public const string c_champId = "COORUNIT_ID";
		public const string c_champLibelle = "COORUNIT_LABEL";
		public const string c_champAbreviation = "COORUNIT_ABBREV";

        #endregion

		/// /////////////////////////////////////////////
		public CUniteCoordonnee( CMemoryDb contexte)
			:base(contexte)
		{
		}

		/// /////////////////////////////////////////////
		public CUniteCoordonnee(DataRow row )
			:base(row)
		{
		}

		

		/// /////////////////////////////////////////////
		public override void  MyInitValeursParDefaut()
		{
		}

		



        #region >> Accesseurs <<
		/// <summary>
		/// Label de l'unit� <br/>
		/// (obligatoire)
		/// </summary>
        [MemoryField(c_champLibelle)]
        [DynamicField("Label")]
        public string Libelle
        {
            get { return (string)Row[c_champLibelle]; }
            set { Row[c_champLibelle] = value; }
		}

		/// <summary>
		/// Abr�viation de l'unit�
		/// </summary>
		[MemoryField(c_champAbreviation)]
		[DynamicField("abbreviation")]
		public string Abreviation
		{
			get	{ return (string)Row[c_champAbreviation]; }
			set	{ Row[c_champAbreviation] = value; }
		}


		

        #endregion

        //-------------------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //-------------------------------------------------------------
        protected override CResultAErreur MySerialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion ( ref nVersion );
            if (!result)
                return result;
            result = SerializeChamps(serializer,
                c_champIdTimos,
                c_champLibelle,
                c_champAbreviation);
            return result;
        }


    }
}
