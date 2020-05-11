using System;
using System.Data;

using sc2i.common;
using sc2i.data;
using sc2i.multitiers.client;
using timos.securite;

namespace timos.acteurs
{
	/// <summary>
    /// Objet de relation entre <see cref="CDonneesActeurUtilisateur">un utilisateur</see>
    /// et ses droits
	/// </summary>
    [DynamicClass("Application User Rights relation")]
	[Table(CRelationActeurUtilisateur_Droit.c_nomTable, CRelationActeurUtilisateur_Droit.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CRelationActeurUtilisateur_DroitServeur")]
	public class CRelationActeurUtilisateur_Droit : CRelationElement_Droit
	{
		public const string c_nomTable = "USER_RIGHTS";
		public const string c_champId = "USER_RIGHTS_ID";
        public const string c_champOptions = "USER_RIGHTS_OPTION";
        public const string c_champData = "USER_RIGHTS_DATA";

		/// //////////////////////////////////////////////////
		public CRelationActeurUtilisateur_Droit(CContexteDonnee ctx)
			:base(ctx)
		{
		}

		/// //////////////////////////////////////////////////
		public CRelationActeurUtilisateur_Droit(DataRow row )
			:base ( row )
		{
		}

		/// //////////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("Relation User / Right @1|285",CodeDroit);
			}
		}

		/// //////////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{CDroitUtilisateur.c_champCode};
		}

		/// //////////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
			Options = OptionsDroit.Aucune;
		}

		/// //////////////////////////////////////////////////
		protected override int NumVersionData
		{
			get
			{
				return 0;
			}
		}

		/// //////////////////////////////////////////////////
		[TableFieldProperty(c_champOptions)]
		public override int OptionsInt
		{
			get
			{
				return (int)Row[c_champOptions];
			}
			set
			{
				Row[c_champOptions] = value;
			}
		}

		


		/// //////////////////////////////////////////////////
		[TableFieldProperty(c_champData, 2048)]
		public override string Data
		{
			get
			{
				return (string)Row[c_champData];
			}
			set
			{
				Row[c_champData] = value;
			}
		}

		/// //////////////////////////////////////////////////
		[Relation(CDonneesActeurUtilisateur.c_nomTable, 
			 CDonneesActeurUtilisateur.c_champId, 
			 CDonneesActeurUtilisateur.c_champId,
			 true,
			 true)]
		public CDonneesActeurUtilisateur DonneeActeurUtilisateur
		{
			get
			{
				return ( CDonneesActeurUtilisateur )GetParent(CDonneesActeurUtilisateur.c_champId, typeof(CDonneesActeurUtilisateur));
			}
			set
			{
				SetParent ( CDonneesActeurUtilisateur.c_champId, value );
			}
		}

		/// //////////////////////////////////////////////////
		public override IElementDefinissantDesDroits ElementDefinisseur
		{
			get
			{
				return DonneeActeurUtilisateur;
			}
			set
			{
				DonneeActeurUtilisateur = (CDonneesActeurUtilisateur)value;
			}
		}
	

		/// //////////////////////////////////////////////////
		///Retourne le droit de l'utilisateur en fusionnant
		///les données hiérarchiques du droit et les données des groupes de l'utilisateur
		public static CDonneeDroitForUser GetDonneesDroit ( CDonneesActeurUtilisateur utilisateur, string strCode )
		{
			return null;
		}
	}
}
