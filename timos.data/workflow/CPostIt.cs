using System;
using System.Collections;

using sc2i.data;
using sc2i.common;
using timos.acteurs;
using sc2i.multitiers.client;
using timos.securite;

namespace sc2i.workflow
{
	#region RelationToPostitAttribute
	[AttributeUsage(AttributeTargets.Class)]
	[Serializable]
	public class RelationToPostitAttribute : RelationTypeIdAttribute
	{
		public override string TableFille
		{
			get
			{
				return CPostIt.c_nomTable;
			}
		}

		//////////////////////////////////////
		public override int Priorite
		{
			get
			{
				return 1000;
			}
		}

		protected override string MyIdRelation
		{
			get
			{
				return "RELPOSTIT";
			}
		}

		
		public override string ChampId
		{
			get
			{
				return CPostIt.c_champIdElement;
			}
		}

		public override string ChampType
		{
			get
			{
				return CPostIt.c_champTypeElementLie;
			}
		}
		
		public override bool Composition
		{
			get
			{
				return true;
			}
		}
		public override bool CanDeleteToujours
		{
			get
			{
				return true;
			}
		}

		public override string NomConvivialPourParent
		{
			get
			{
				return I.T("Notes|330");
			}
		}

		protected override bool MyIsAppliqueToType(Type tp)
		{
			return tp.IsSubclassOf ( typeof(CObjetDonneeAIdNumerique) );
		}
	}

	#endregion
	/// <summary>
	/// Un postit est une note qu'il est possible d'associer à nombre d'entités<br/>
    /// de TIMOS, afin, en général, de rappeler quelque chose d'important lié<br/>
    /// à l'élément.
	/// </summary>
	[DynamicClass("PostIt")]
	[ObjetServeurURI("CPostItServeur")]
	[Table(CPostIt.c_nomTable, CPostIt.c_champId,true)]
	[RelationToPostit]
	public class CPostIt : CObjetDonneeAIdNumeriqueAuto
	{
		#region Déclaration des constantes
		public const string c_nomTable = "POSTIT";
		public const string c_champId = "POSTIT_ID";
		public const string c_champTexte = "POSTIT_TEXT";
		public const string c_champDateFin = "POSTIT_END_DATE";
		public const string c_champTypeElementLie = "POSTIT_ELEMENT_TYPE";
		public const string c_champIdElement = "POSTIT_ELEMENT_ID";
		public const string c_champTitre = "POSTIT_TITLE";
		public const string c_champNotePublique = "POSTIT_PUBLIC";

		#endregion
		//-------------------------------------------------------------------
		public CPostIt( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CPostIt( System.Data.DataRow row )
			:base(row)
		{
		}
		//-------------------------------------------------------------------
		protected override void MyInitValeurDefaut()
		{
			DateFin = DateTime.Now.AddMonths(1);
			try
			{
				CSessionClient session = CSessionClient.GetSessionForIdSession ( ContexteDonnee.IdSession );
				if ( session != null )
				{
                    //TESTDBKEYOK
					CDbKey keyUser = session.GetInfoUtilisateur().KeyUtilisateur;
					CDonneesActeurUtilisateur user = new CDonneesActeurUtilisateur ( ContexteDonnee );
					if ( user.ReadIfExists ( keyUser ) )
						Auteur = user;
				}
			}
			catch
			{}
			IsPublique = true;
		}
		//-------------------------------------------------------------------
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champTexte};
		}
		//-------------------------------------------------------------------
		public override string DescriptionElement
		{
			get
			{
				return I.T("Note number @1|331",Id.ToString());
			}
		}
		//-------------------------------------------------------------------
        /// <summary>
        /// Si VRAI, la note est publique, c'est à dire qu'elle peut être
        /// modifiée par n'importe quel utilisateur
        /// </summary>
		[TableFieldProperty ( c_champNotePublique )]
		[DynamicField("Public note")]
		public bool IsPublique
		{
			get
			{
				return (bool)Row[c_champNotePublique];
			}
			set
			{
				Row[c_champNotePublique] = value;
			}
		}
		
		//-------------------------------------------------------------------
        /// <summary>
        /// Texte de la note
        /// </summary>
		[
		TableFieldProperty(c_champTexte, 2048),
		DynamicField("Texte")
		]
		public string Texte
		{
			get
			{
				return (string)Row[c_champTexte];
			}
			set
			{
				Row[c_champTexte] = value;
			}
		}

		//-------------------------------------------------------------------
        /// <summary>
        /// Date d'expiration. Lorsque cette date est atteinte, la note
        /// disparaît de l'élément automatiquement
        /// </summary>
		[TableFieldProperty(c_champDateFin, NullAutorise = true)]
		[DynamicField("Expiration date")]
		public DateTime? DateFin
		{
			get
			{
				return ( DateTime? )Row[c_champDateFin, true];
			}
			set
			{
				Row[c_champDateFin, true] = value;
			}
		}

		//-------------------------------------------------------------------
        /// <summary>
        /// Type TIMOS de l'élément auquel la note est associée
        /// (exemple : timos.data.CSite)
        /// </summary>
		[TableFieldProperty( c_champTypeElementLie, 1024)]
		[DynamicField("Element type")]
		public string TypeElementString
		{
			get
			{
				return ( string )Row[c_champTypeElementLie];
			}
			set
			{
				Row[c_champTypeElementLie] = value;
			}
		}

		//-------------------------------------------------------------------
        /// <summary>
        /// Identifiant (Id) de l'élément auquel la note est associée
        /// </summary>
		[TableFieldProperty(c_champIdElement)]
		[DynamicField("Element id")]
		public int IdElementLie
		{
			get
			{
				return (int)Row[c_champIdElement];
			}
			set
			{
				Row[c_champIdElement] = value;
			}
		}

		//-------------------------------------------------------------------
        /// <summary>
        /// Elément associé à la note
        /// </summary>
		[DynamicField("Linked element")]
		public CObjetDonneeAIdNumerique ElementLie
		{
			get
			{
				try
				{
					Type tp = CActivatorSurChaine.GetType ( TypeElementString );
					if ( tp == null )
						return null;
					CObjetDonneeAIdNumerique objet = (CObjetDonneeAIdNumerique)Activator.CreateInstance ( tp, new object[]{ContexteDonnee} );
					if ( objet.ReadIfExistInternalKey ( IdElementLie ) )
						return objet;
				}
				catch
				{
				}
				return null;
			}
			set
			{
				if ( value != null )
				{
					TypeElementString = value.GetType().ToString();
					IdElementLie = value.Id;
				}
			}
		}

		//-------------------------------------------------------------------
        /// <summary>
        /// Utilisateur de l'application, auteur de la note
        /// </summary>
		[Relation(CDonneesActeurUtilisateur.c_nomTable,
			 CDonneesActeurUtilisateur.c_champId,
			 CDonneesActeurUtilisateur.c_champId,
			 true,
			 false,
			 true)]
		[DynamicField("Author")]
		public CDonneesActeurUtilisateur Auteur
		{
			get
			{
				return (CDonneesActeurUtilisateur)GetParent ( CDonneesActeurUtilisateur.c_champId, typeof(CDonneesActeurUtilisateur) );
			}
			set
			{
				SetParent ( CDonneesActeurUtilisateur.c_champId, value );
			}
		}

		//-------------------------------------------------------------------
        /// <summary>
        /// Titre de la note
        /// </summary>
		[TableFieldProperty(c_champTitre, 255)]
		[DynamicField("Title")]
		public string Titre
		{
			get
			{
				return ( string )Row[c_champTitre];
			}
			set
			{
				Row[c_champTitre] = value;
			}
		}
		
		//-------------------------------------------------------------------
	}
}
