using System;
using System.Data;
using System.IO;

using sc2i.common;
using sc2i.data;
using sc2i.data.dynamic;

namespace sc2i.workflow
{
	/// <summary>
    /// Relation entre un <see cref="CTypeEntreeAgenda">Type d'entrée à agenda</see> et un 
    /// type d'élément à agenda.
	/// </summary>
	[Table(CRelationTypeEntreeAgenda_TypeElementAAgenda.c_nomTable,
		  CRelationTypeEntreeAgenda_TypeElementAAgenda.c_champId,
		 true)]
	[ObjetServeurURI("CRelationTypeEntreeAgenda_TypeElementAAgendaServeur")]
	[DynamicClass("Diary entry / Element type")]
	[FullTableSync]
    //[Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_TypeEntreeAgenda_ID)]
    public class CRelationTypeEntreeAgenda_TypeElementAAgenda : CObjetDonneeAIdNumeriqueAuto, IRelationTypeElementALien_TypeElement
	{
		public const string c_nomTable = "DIARY_TYPE_ELEMENT_TYPE";
		public const string c_champId = "DT_ET_ID";
		public const string c_champLibelle = "DT_ET_LABEL";
		public const string c_champCode = "DT_ET_CODE";
		public const string c_champTypeElement = "DT_ET_TYPE";
		public const string c_champObligatoire = "DT_ET_OBLIGATORY";
		public const string c_champMasquerSurAgenda = "DT_ET_HIDE";
		public const string c_champSupprimerEntreeSiSuppressionElement = "DT_ET_CASCADE_DEL";
		public const string c_champDroitModif = "DT_ET_MODIF_RIGHT";
		public const string c_champLienMaitre = "DT_ET_MASTER_LINK";
		public const string c_champMultiple = "DT_ET_MULTIPLE";

		public const string c_champDataFiltre = "DT_ET_FILTER";

#if PDA
		public CRelationTypeEntreeAgenda_TypeElementAAgenda()
			:base()
		{
			
		}
#endif
		/// <summary>
		/// 
		/// </summary>
		/// <param name="ctx"></param>
		public CRelationTypeEntreeAgenda_TypeElementAAgenda( CContexteDonnee ctx )
			:base(ctx)
		{
			
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="row"></param>
		public CRelationTypeEntreeAgenda_TypeElementAAgenda ( DataRow row )
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
				return I.T("Relation Diary entry / Element type @1|339",Libelle);
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

		//-----------------------------------------------------
        /// <summary>
        /// Libellé de la relation
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
        /// Code de la relation. Ce code permet d'effectuer des recherches<br/>
        /// d'une manière plus fiable que le libellé
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


		//-----------------------------------------------
        /// <summary>
        /// Indique que pour les entrées d'agenda du type d'entrée correspondant,<br/>
        /// le lien avec un élément de ce type d'élément est obligatoire.
        /// </summary>
		[TableFieldProperty(c_champObligatoire)]
		[DynamicField("Obligatory")]
		public bool Obligatoire
		{
			get
			{
				return ( bool)Row[c_champObligatoire];
			}
			set
			{
				Row[c_champObligatoire] = value;
			}
		}

		//////////////////////////////////////////////////////////////// 
		/// <summary>
		/// Indique que l'entrée d'agenda sera masquée<br/>
		/// sur l'agenda de l'élément associé.
		/// </summary>
		[TableFieldProperty(c_champMasquerSurAgenda)]
		[DynamicField("Hide")]
		public bool Masquer
		{
			get
			{
				return ( bool)Row[c_champMasquerSurAgenda];
			}
			set
			{
				Row[c_champMasquerSurAgenda] = value;
			}
		}

		//----------------------------------------------------
        /// <summary>
        /// Type d'entrée d'agenda, objet de la relation
        /// </summary>
		[Relation(CTypeEntreeAgenda.c_nomTable, CTypeEntreeAgenda.c_champId, CTypeEntreeAgenda.c_champId, true, true)]
		[DynamicField("Entry type")]
		public CTypeEntreeAgenda TypeEntree
		{
			get
			{
				return (CTypeEntreeAgenda)GetParent ( CTypeEntreeAgenda.c_champId, typeof(CTypeEntreeAgenda) );
			}
			set
			{
				SetParent ( CTypeEntreeAgenda.c_champId, value );
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

		//---------------------------------------------------
        /// <summary>
        /// Type d'élément à agenda (convivial), objet de la relation
        /// </summary>
		[DynamicField("Element type")]
		public string TypeElementsConvivial
		{
			get
			{
				Type tp = TypeElements;
				if ( tp == null )
					return I.T("<Any entity type>|30083");
				return DynamicClassAttribute.GetNomConvivial(tp);
			}
		}

		/// /////////////////////////////////////////////////////////
		/// <summary>
		/// Si VRAI, indique que l'entrée d'agenda est <br/>
		/// supprimée si l'élément lié est supprimé
		/// </summary>
		[TableFieldProperty(c_champSupprimerEntreeSiSuppressionElement)]
		[DynamicField("Automatic delete")]
		public bool SuppressionAutomatique
		{
			get
			{
				return (bool)Row[c_champSupprimerEntreeSiSuppressionElement];
			}
			set
			{
				Row[c_champSupprimerEntreeSiSuppressionElement] = value;
			}
		}

		//--------------------------------------------------------
		/// <summary>
		/// Indique que l'acteur lié lui-même a le droit de modification sur l'entrée d'agenda.
        /// <br/>
        /// <br/>
		/// Cette option est à utiliser en combinaison avec le champ 'Droits limites' de l'entité
		/// <see cref="CTypeEntreeAgenda">Type d'entrée d'agenda</see>. Elle n'est utile
		/// qu'en cas de droit limités
		/// <P>
		/// Le tableau suivant indique les droits donnés suivant le type d'entité lié par
		/// la relation
		/// <table>
		/// <TH>
		///		<TD>Type lié</TD>
		///		<TD>Entités pouvant modifier</TD>
		/// </TH>
		/// <TR>
		/// <TD>Acteur ou utilisateur</TD>
		/// <TD>Le acteur correspondant et ses collaborateurs d'agenda</TD>
		/// </TR>
		/// <TR>
		/// <TD>Eleveur ou Elevage</TD>
		/// <TD>Le acteur eleveur correspondant,le technicien en charge de l'elevage ou un de ses
		/// collaborateurs d'agenda</TD>
		/// </TR>
		/// <TR>
		/// <TD>Lot de produit</TD>
		/// <TD>Le acteur eleveur, le technicien en charge de l'elevage ou un de ses
		/// collaborateurs d'agenda</TD>
		/// </TR>
		/// </table>
		/// </P>
        /// </summary>
		[TableFieldProperty(c_champDroitModif)]
		[DynamicField(c_champDroitModif)]
		public bool DroitModification
		{
			get
			{
				return ( bool )Row[c_champDroitModif];
			}
			set
			{
				Row[c_champDroitModif] = value;
			}
		}

		
		//////////////////////////////////////////////////////////////// 
		/// <summary>
		/// Si VRAI, Lors de la visualisation de l'agenda d'un élément du type associé,
		/// une nouvelle entrée d'agenda pourra être créée
		/// </summary>
		[TableFieldProperty(c_champLienMaitre)]
		[DynamicField("Master link")]
		public bool LienMaitre
		{
			get
			{
				return ( bool )Row[c_champLienMaitre];
			}
			set
			{
				Row[c_champLienMaitre] = value;
			}
		}

		//////////////////////////////////////////////////////////////// 
		/// <summary>
		/// Si vrai, Il est possible de sélectionner plusieurs éléments
		/// pour ce lien
		/// </summary>
		[TableFieldProperty(c_champMultiple)]
		[DynamicField("Multiple")]
		public bool Multiple
		{
			get
			{
				return ( bool )Row[c_champMultiple];
			}
			set
			{
				Row[c_champMultiple] = value;
			}
		}


		//---------------------------------------------------------
        /// <summary>
        /// Rôle affecté à la relation
        /// </summary>
		[Relation ( CRoleSurEntreeAgenda.c_nomTable,
		CRoleSurEntreeAgenda.c_champId,
		CRoleSurEntreeAgenda.c_champId,
		false,
		false,
		false)]
		[DynamicField("Role")]
		public CRoleSurEntreeAgenda Role
		{
			get
			{
				return ( CRoleSurEntreeAgenda )GetParent ( CRoleSurEntreeAgenda.c_champId, typeof(CRoleSurEntreeAgenda));
			}
			set
			{
				SetParent ( CRoleSurEntreeAgenda.c_champId, value );
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
				return TypeEntree;
			}
			set
			{
				TypeEntree = (CTypeEntreeAgenda)value;
			}
		}

		public IRelationElementALien_Element GetNewRelation(IElementALien elementALien, CObjetDonneeAIdNumerique elementLie)
		{
			CRelationEntreeAgenda_ElementAAgenda rel = new CRelationEntreeAgenda_ElementAAgenda ( elementALien.ContexteDonnee );
			rel.ElementLie = (CObjetDonneeAIdNumerique)elementLie;
			rel.RelationType = this;
			rel.EntreeAgenda = (CEntreeAgenda)elementALien;
			return rel;
		}

		#endregion


	}
}
