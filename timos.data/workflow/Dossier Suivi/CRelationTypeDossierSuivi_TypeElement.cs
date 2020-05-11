using System;
using System.Data;
using System.IO;

using sc2i.common;
using sc2i.data;
using sc2i.data.dynamic;

namespace sc2i.workflow
{
	/// <summary>
    /// Relation entre un <see cref="CTypeDossierSuivi">Type de dossier de suivi</see> et une 
    /// catégorie d'élément.
	/// </summary>
	[Table(CRelationTypeDossierSuivi_TypeElement.c_nomTable,
		  CRelationTypeDossierSuivi_TypeElement.c_champId,
		 true)]
	[ObjetServeurURI("CRelationTypeDossierSuivi_TypeElementServeur")]
	[DynamicClass("Workbook type / Element type")]
	[FullTableSync]
    //[Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_TypeDossier_ID)]
    public class CRelationTypeDossierSuivi_TypeElement : CObjetDonneeAIdNumeriqueAuto, IRelationTypeElementALien_TypeElement
	{
		public const string c_nomTable = "WORKBOOK_TYPE_ELT_TYPE";
		public const string c_champId = "WKBTYELTTY_ID";
		public const string c_champLibelle = "WKBTYELTTY_LABEL";
		public const string c_champCode = "WKBTYELTTY_CODE";
		public const string c_champTypeElement = "WKBTYELTTY_TYPE";
		public const string c_champSuppressionAutomatique = "WKBTYELTTY_AUTO_DEL";
		public const string c_champIsMultiple = "WKBTYELTTY_MULTIPLE";

		public const string c_champDataFiltre = "WKBTYELTTY_FILTER";

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ctx"></param>
		public CRelationTypeDossierSuivi_TypeElement( CContexteDonnee ctx )
			:base(ctx)
		{
			
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="row"></param>
		public CRelationTypeDossierSuivi_TypeElement ( DataRow row )
			:base(row)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		public override string DescriptionElement
		{
			get
			{
				return I.T( "Relation WorkBook type / Element type @1|337", Libelle);
			}
		}

		////////////////////////////////////////////////////////////////  
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] { c_champLibelle };
		}

		////////////////////////////////////////////////////////////////  
		protected override void MyInitValeurDefaut()
		{
		}

		//-------------------------------------------------------------
        /// <summary>
        /// Donne ou définit le libellé de la relation
        /// </summary>
		[TableFieldProperty(c_champLibelle, 256)]
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

		//------------------------------------------------------
        /// <summary>
        /// Donne ou définit le code de la relation
        /// </summary>
		[TableFieldProperty ( c_champCode, 255)]
		[DynamicField("Code")]
		public string Code
		{
			get
			{
				return ( string )Row[c_champCode];
			}
			set
			{
				Row[c_champCode] = value;
			}
		}


		//---------------------------------------------------
        /// <summary>
        /// Donne ou définit le type de dossier de suivi, objet de la relation
        /// </summary>
		[Relation(CTypeDossierSuivi.c_nomTable, CTypeDossierSuivi.c_champId, CTypeDossierSuivi.c_champId, true, true)]
		[DynamicField("Workbook type")]
		public CTypeDossierSuivi TypeDossierSuivi
		{
			get
			{
				return (CTypeDossierSuivi)GetParent ( CTypeDossierSuivi.c_champId, typeof(CTypeDossierSuivi) );
			}
			set
			{
				SetParent ( CTypeDossierSuivi.c_champId, value );
			}
		}

		//////////////////////////////////////////////////////////////// 
		[TableFieldProperty(c_champTypeElement, 1024)]
		public string TypeElementsString
		{
			get
			{
				return (string)Row[c_champTypeElement];
			}
			set
			{
				Row[c_champTypeElement] = value;
			}
		}

		//////////////////////////////////////////////////////////////// 
		public Type TypeElements
		{
			get
			{
				return CActivatorSurChaine.GetType ( TypeElementsString );
			}
			set
			{
				if ( value == null || value == typeof(DBNull) )
					TypeElementsString = "";
				else
					TypeElementsString = value.ToString();
			}
		}

		//--------------------------------------------------
        /// <summary>
        /// Renvoie le nom convivial du type d'élément, objet de la relation
        /// (Exemple : Equipment)
        /// </summary>
		[DynamicField("Element type")]
		public string TypeElementsConvivial
		{
			get
			{
				Type tp = TypeElements;
				if ( tp == null )
					return I.T("<All Entity Types>|338");
				return DynamicClassAttribute.GetNomConvivial(tp);
			}
		}


		/// /////////////////////////////////////////////////////////
		[TableFieldProperty(c_champDataFiltre, NullAutorise=true)]
		public CDonneeBinaireInRow DataFiltre
		{
			get
			{
				if ( Row[c_champDataFiltre] == DBNull.Value )
				{
					CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession ,Row, c_champDataFiltre);
					CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champDataFiltre, donnee);
				}
				object obj = Row[c_champDataFiltre];
				return ((CDonneeBinaireInRow)obj).GetSafeForRow(Row.Row);
			}
			set
			{
				Row[c_champDataFiltre] = value;
			}
		}

		/// /////////////////////////////////////////////////////////////
		/// <summary>
		/// Retourne le filtre dynamique associé au type (filtre de base pour sélectionner les éléments)
		/// </summary>
        [BlobDecoder]
        public CFiltreDynamique FiltreDynamiqueAssocie
		{
			get
			{
				CFiltreDynamique filtre = null;
				if ( DataFiltre.Donnees != null )
				{
					filtre = new CFiltreDynamique(ContexteDonnee);
					MemoryStream stream = new MemoryStream(DataFiltre.Donnees);
					BinaryReader reader = new BinaryReader(stream);
					CSerializerReadBinaire serializer = new CSerializerReadBinaire(reader);
					CResultAErreur result = filtre.Serialize(serializer);
					if ( !result )
					{
						filtre = null;
					}
                    reader.Close();
                    stream.Close();
				}
				return filtre;
			}
			set
			{
				if ( value == null )
				{
					CDonneeBinaireInRow data = DataFiltre;
					data.Donnees = null;
					DataFiltre = data;
				}
				else
				{
					MemoryStream stream = new MemoryStream();
					BinaryWriter writer = new BinaryWriter(stream);
					CSerializerSaveBinaire serializer = new CSerializerSaveBinaire(writer);
					CResultAErreur result = value.Serialize ( serializer );
					if ( result )
					{
						CDonneeBinaireInRow data = DataFiltre;
						data.Donnees = stream.GetBuffer();
						DataFiltre = data;
					}
                    writer.Close();
                    stream.Close();
				}
			}
		}

		/// /////////////////////////////////////////////////////////////
		/// /////////////////////////////////////////////////////////
		/// <summary>
		/// Si positionné à TRUE, indique pour les liens de ce type entre dossier et élément,
        /// que le dossier est supprimé si l'élément lié est supprimé
		/// </summary>
		[TableFieldProperty(c_champSuppressionAutomatique)]
		[DynamicField("Automatic delete")]
		public bool SuppressionAutomatique
		{
			get
			{
				return ( bool )Row[c_champSuppressionAutomatique];
			}
			set
			{
				Row[c_champSuppressionAutomatique] = value;
			}
		}

		/// /////////////////////////////////////////////////////////////
		/// /////////////////////////////////////////////////////////
		/// <summary>
        /// Si positionné à TRUE, indique pour les liens de ce type entre dossier et élément,
        /// que plusieurs éléments peuvent être liés au dossier via ce type de lien
		/// </summary>
		[TableFieldProperty(c_champIsMultiple)]
		[DynamicField("Multiple")]
		public bool Multiple
		{
			get
			{
				return ( bool )Row[c_champIsMultiple];
			}
			set
			{
				Row[c_champIsMultiple] = value;
			}
		}

		/// /////////////////////////////////////////////////////////////
		/// <summary>
		/// Retourne le filtre Data généré par le filtre dynamique
		/// </summary>
		public CFiltreData FiltreDataAssocie
		{
			get
			{
				CFiltreDynamique filtreDynamique = FiltreDynamiqueAssocie;
				if ( filtreDynamique == null )
					return null;
				try
				{
					CResultAErreur result = filtreDynamique.GetFiltreData();
					if ( result )
						return (CFiltreData)result.Data;
				}
				catch
				{
				}
				return null;
			}
		}
		#region Membres de IRelationTypeElementALien_TypeElement

		public ITypeElementALien TypeElementALien
		{
			get
			{
				return TypeDossierSuivi;
			}
			set
			{
				TypeDossierSuivi = (CTypeDossierSuivi)value;
			}
		}

		public IRelationElementALien_Element GetNewRelation(IElementALien elementALien, CObjetDonneeAIdNumerique elementLie)
		{
			CRelationDossierSuivi_Element rel = new CRelationDossierSuivi_Element ( elementALien.ContexteDonnee );
			rel.ElementLie = elementLie;
			rel.DossierSuivi = (CDossierSuivi)elementALien;
			rel.RelationParametre_TypeElement = this;
			return rel;
		}

		#endregion

		
	}
}
