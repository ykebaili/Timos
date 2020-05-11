using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.formulaire;
using System.Collections.Generic;
using timos.acteurs;
using timos.securite;

namespace sc2i.custom
{
	/// <summary>
	/// Objet menu utilisateur<br/>
    /// Le menu général de l'application présenté à l'utilisateur est constitué<br/>
    /// d'un assemblage de ces objets menu.
	/// </summary>
	[DynamicClass("Menu")]
	[Table(CMenuCustom.c_nomTable, CMenuCustom.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CMenuCustomServeur")]
	public class CMenuCustom : CObjetDonneeAIdNumeriqueAuto, IObjetDonneeAutoReference, IObjetALectureTableComplete
	{
		public const string c_nomTable = "MENUS";
		
		public const string c_champId = "MENU_ID";
		public const string c_champNum = "MENU_NUM";
		public const string c_champLibelle = "MENU_LABEL";
		public const string c_champAction = "MENU_ACTION";
		public const string c_champIdMenuParent = "MENU_PARENT_ID";
		public const string c_champKeysGroupes = "MENU_GROUPS_ID";
        public const string c_champIdsProfils = "MENU_PROFILES_ID";

		/// /////////////////////////////////////////////
		public CMenuCustom( CContexteDonnee contexte)
			:base(contexte)
		{
		}

		/// /////////////////////////////////////////////
		public CMenuCustom(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("Custom Menu @1|356",Libelle);
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champNum+","+c_champLibelle};
		}

		//----------------------------------------------
        /// <summary>
        /// Libellé du menu
        /// </summary>
		[TableFieldProperty(c_champLibelle, 128)]
		[DynamicField("Label")]
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

		//---------------------------------------------
        /// <summary>
        /// Numéro du menu dans la branche du menu parent
        /// </summary>
		[TableFieldProperty(c_champNum, false)]
		[DynamicField("Number")]
		public int NumMenu
		{
			get
			{
				return ( int )Row[c_champNum];
			}
			set
			{
				Row[c_champNum] = value;
			}
		}

		/// /////////////////////////////////////////////
        [TableFieldProperty(c_champAction, 4000)]
		public string ActionString
		{
			get
			{
				return (string)Row[c_champAction];
			}
			set
			{
				Row[c_champAction] = value;
			}
		}

		/// /////////////////////////////////////////////
		public CActionSur2iLink Action
		{
			get
			{
				CStringSerializer serializer = new CStringSerializer(ActionString, ModeSerialisation.Lecture);
				I2iSerializable objet = null;
				CResultAErreur result = serializer.TraiteObject ( ref objet );
				if ( !result )
					return null;
				return (CActionSur2iLink)objet;
			}
			set
			{
				CStringSerializer serializer = new CStringSerializer ( ModeSerialisation.Ecriture );
				I2iSerializable objet = value;
				CResultAErreur result = serializer.TraiteObject ( ref objet );
				if ( result )
					ActionString = serializer.String;
				else
					ActionString = "";
			}
		}

		//-----------------------------------------------
        /// <summary>
        /// Menu parent
        /// </summary>
		[Relation( CMenuCustom.c_nomTable,
			 CMenuCustom.c_champId,
			 CMenuCustom.c_champIdMenuParent,
			 false,
			 true,
			 true)]
		[DynamicField("Parent menu")]
		public CMenuCustom MenuParent
		{
			get
			{
				return ( CMenuCustom )GetParent ( c_champIdMenuParent, typeof ( CMenuCustom ) );
			}
			set
			{
				SetParent ( c_champIdMenuParent, value );
			}
		}

		//------------------------------------------------------
        /// <summary>
        /// Retourne la liste des menus enfants de ce menu<br/>
        /// (niveau immédiatement inférieur)
        /// </summary>
		[RelationFille(typeof(CMenuCustom), "MenuParent")]
		[DynamicChilds("Childs menus", typeof(CMenuCustom))]
		public CListeObjetsDonnees ListeMenusFils
		{
			get
			{
				return GetDependancesListe ( CMenuCustom.c_nomTable, CMenuCustom.c_champIdMenuParent );
			}
		}

		//--------------------------------------------------
		/// <summary>
		/// Clés des groupes d'acteurs qui voient ce menu (liste d'entiers séparés par des ,)
		/// </summary>
		[TableFieldProperty(c_champKeysGroupes, 1500)]
		[DynamicField("Members groups keys String")]
		public string KeysGroupesString
		{
			get
			{
				return ( string )Row[c_champKeysGroupes];
			}
			set
			{
				Row[c_champKeysGroupes] = value;
			}
		}

        

		/// /////////////////////////////////////////////
		/// <summary>
		/// Tableau d'universal id contenant la liste des DbKey des groupes qui voient ce menu
		/// </summary>
		[DynamicField("Groups keys")]
		public CDbKey[] KeysGroupes
		{
			get
			{
				string[] strListe = KeysGroupesString.Split(',');
                List<CDbKey> lstKeys = new List<CDbKey>();
				foreach ( string strId in strListe )
				{
                    if (strId.Trim().Length > 0)
                    {
                        int nId;
                        if (int.TryParse(strId, out nId))
                        {
                            CGroupeActeur grp = new CGroupeActeur(ContexteDonnee);
                            if (grp.ReadIfExists(nId))
                                lstKeys.Add(grp.DbKey);
                        }
                        else
                        {
                            CDbKey key = CDbKey.CreateFromStringValue(strId);
                            if (key != null)
                                lstKeys.Add(key);
                        }
                    }
				}
                return lstKeys.ToArray();
			}
			set
			{
				if(  value == null || value.Length == 0)
					KeysGroupesString = "";
				else
				{
					string strText = "";
                    foreach (CDbKey key in value)
                        strText += key.StringValue + ",";
					strText = strText.Substring(0, strText.Length-1);
					KeysGroupesString = strText;
				}
			}
		}

        //-----------------------------------------------------------
        /// <summary>
        /// Ids des  d'profils qui voient ce menu (liste de CDbKey séparés par des ,)
        /// </summary>
        [TableFieldProperty(c_champIdsProfils, 1500)]
        [DynamicField("Member Profiles keys String")]
        public string KeysProfilsString
        {
            get
            {
                return (string)Row[c_champIdsProfils];
            }
            set
            {
                Row[c_champIdsProfils] = value;
            }
        }

        /// /////////////////////////////////////////////
        /// <summary>
        /// Tableau de CDbKey contenant la liste des CDbKey des profils d'acteurs qui voient ce menu
        /// </summary>
        [DynamicField("Profiles keys")]
        public CDbKey[] KeysProfils
        {
            get
            {
                string[] strListe = KeysProfilsString.Split(',');
                List<CDbKey> lstKeys = new List<CDbKey>();
				foreach ( string strId in strListe )
				{
                    if (strId.Trim().Length > 0)
                    {
                        int nId;
                        if (int.TryParse(strId, out nId))
                        {
                            CProfilUtilisateur profile = new CProfilUtilisateur(ContexteDonnee);
                            if (profile.ReadIfExists(nId))
                                lstKeys.Add(profile.DbKey);
                        }
                        else
                        {
                            CDbKey key = CDbKey.CreateFromStringValue(strId);
                            if (key != null)
                                lstKeys.Add(key);
                        }
                    }
				}
                return lstKeys.ToArray();
			}
			set
			{
				if(  value == null || value.Length == 0)
					KeysProfilsString = "";
				else
				{
					string strText = "";
                    foreach (CDbKey key in value)
                        strText += key.StringValue + ",";
					strText = strText.Substring(0, strText.Length-1);
					KeysProfilsString = strText;
				}
			}
        }



		#region IObjetDonneeAutoReference Membres

		public string ChampParent
		{
			get { return c_champIdMenuParent; }
		}

		public string ProprieteListeFils
		{
			get { return "ListeMenusFils"; }
		}

		#endregion
	}
}
