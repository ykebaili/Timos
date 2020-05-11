using System;
using System.Data;
using System.Collections;
using System.IO;

using sc2i.common;
using sc2i.data;
using sc2i.data.dynamic;
using sc2i.formulaire;
using sc2i.expression;
using sc2i.process;
using tiag.client;

namespace sc2i.workflow
{
	/// <summary>
    /// Le type de dossier définit la nature de l'élément suivi par le <see cref="CDossier">dossier</see>,<br/>
    /// ainsi que les liens possibles avec d'autres éléments. Chaque type de dossier est associé à une et une<br/>
    /// seule nature d'élément.
	/// </summary>
    [sc2i.doccode.DocRefMenusOrMenuItems(timos.data.CDocLabels.c_iDossier)]
    [Table(CTypeDossierSuivi.c_nomTable, CTypeDossierSuivi.c_champId, true)]
	[FullTableSync]
	[DynamicClass("Workbook type")]
	[ObjetServeurURI("CTypeDossierSuiviServeur")]
    //[Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_TypeDossier_ID)]
    [TiagClass(CTypeDossierSuivi.c_nomTiag, "Id", true)]
	public class CTypeDossierSuivi : CObjetDonneeAIdNumeriqueAuto, 
		IDefinisseurChampCustomRelationObjetDonnee, 
		IDefinisseurEvenements, 
		IObjetDonneeAutoReference, 
        IObjetALectureTableComplete, 
        ITypeElementALien,
        IElementAInterfaceTiag
	{
		public const string c_nomChampDossier = "Workbook";
        public const string c_nomTiag = "Workbook_type";


		public const string c_nomTable = "WORKBOOK_TYPE";
		public const string c_champId = "WKBTY_ID";
		public const string c_champLibelle = "WKBTY_LABEL";
		public const string c_champDescription = "WKBTY_DESCRIPTION";
		public const string c_champTypeSuivi = "WKBTY_TARGET_TYPE";
		public const string c_champTypeDossierParent = "WKBTY_PARENT_TYPE";
		public const string c_champFiltreElementsSuivisPossibles = "WKBTY_ELEMENT_FILTER";
		public const string c_champMasquerCartoucheSurEdition = "WKBTY_HIDE_HEADER";
		public const string c_champMasquerAgenda = "WKBTY_HIDE_DIARY";
        public const string c_champUnSeulParParent = "WKBTY_ONE_PER_PARENT";
        public const string c_champIdFormulaireResume = "WKBTY_SUMMARY_FORM";
		
#if PDA
		public CTypeDossierSuivi()
			:base ()
		{
		}
#endif
		/// <summary>
		/// //////////////////////////////////////////////
		/// </summary>
		/// <param name="ctx"></param>
		public CTypeDossierSuivi( CContexteDonnee ctx )
			:base (ctx)
		{
		}

		/// //////////////////////////////////////////////
		public CTypeDossierSuivi ( DataRow row )
			:base(row)
		{
		}

		/// //////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("Workbook Type @1|343",Libelle);
			}
		}

		/// //////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champLibelle};
		}

		/// //////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
            UnSeulParParent = false;
		}

		//-------------------------------------------------
        /// <summary>
        /// Donne ou définit le libellé du type de dossier
        /// </summary>
		[TableFieldProperty(c_champLibelle, 128)]
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

		//--------------------------------------------------
        /// <summary>
        /// Donne ou définit la description du type de dossier
        /// </summary>
		[TableFieldProperty(c_champDescription, 1024)]
		[DynamicField("Description")]
        [TiagField("Description")]
		public string Description
		{
			get
			{
				return (string)Row[c_champDescription];
			}
			set
			{
				Row[c_champDescription] = value;
			}
		}

		//-----------------------------------------------------------
        /// <summary>
        /// Si TRUE, donne ou définit le fait de masquer l'entête du formulaire
        /// lorsque le dossier est édité. L'entête affiche le nom du dossier,
        /// la date d'ouverture et l'objet suivi.
        /// </summary>
		[TableFieldProperty(c_champMasquerCartoucheSurEdition)]
		[DynamicField("Hide header")]
        [TiagField("Hide header")]
		public bool MasquerCartoucheSurEdition
		{
			get
			{
				return ( bool )Row[c_champMasquerCartoucheSurEdition];
			}
			set
			{
				Row[c_champMasquerCartoucheSurEdition] = value;
			}
		}

		//-------------------------------------------------------------
        /// <summary>
        /// Si TRUE, donne ou définit le fait de masquer l'agenda
        /// lorsque le dossier est édité.
        /// </summary>
		[TableFieldProperty(c_champMasquerAgenda)]
		[DynamicField("Hide diary")]
        [TiagField("Hide diary")]
		public bool MasquerAgenda
		{
			get
			{
				return ( bool )Row[c_champMasquerAgenda];
			}
			set
			{
				Row[c_champMasquerAgenda] = value;
			}
		}

        /// <summary>
        /// Si TRUE, indique qu'un parent ne peut avoir qu'un seul fils de ce type.
        /// Dans ce cas, ce fils devra être créé par process
        /// </summary>
        [TableFieldProperty(CTypeDossierSuivi.c_champUnSeulParParent)]
        [DynamicField("Only one per parent")]
        [TiagField("Only one per parent")]
        public bool UnSeulParParent
        {
            get
            {
                return (bool)Row[c_champUnSeulParParent];
            }
            set
            {
                Row[c_champUnSeulParParent] = value;
            }
        }

        //---------------------------------------------------------------
        /// <summary>
        /// Donne ou définit le formulaire résumé associé.
        /// Ceci concerne les types de dossiers fils.
        /// </summary>
        [Relation(
            CFormulaire.c_nomTable,
            CFormulaire.c_champId,
            CTypeDossierSuivi.c_champIdFormulaireResume,
            false,
            false,
            false)]
        [DynamicField("Summary form")]
        public CFormulaire FormulaireResume
        {
            get
            {
                return GetParent(c_champIdFormulaireResume, typeof(CFormulaire)) as CFormulaire;
            }
            set
            {
                SetParent(c_champIdFormulaireResume, value);
            }
        }



		/// //////////////////////////////////////////////
		[TableFieldProperty ( c_champTypeSuivi, 255)]
		public string TypeSuiviString
		{
			get
			{
				return ( string )Row[c_champTypeSuivi];
			}
			set
			{
				Row[c_champTypeSuivi] = value;
			}
		}

		/// //////////////////////////////////////////////
		public Type TypeSuivi
		{
			get
			{
				return CActivatorSurChaine.GetType(TypeSuiviString);
			}
			set
			{
				if(  value == null )
					TypeSuiviString = "";
				else
					TypeSuiviString = value.ToString();
			}
		}

		//--------------------------------------------------------
        /// <summary>
        /// Renvoie le type d'élément suivi sous la forme conviviale
        /// (exemple : Sites)
        /// </summary>
		[DynamicField("Friendly type name")]
		public string TypeSuiviConvivial
		{
			get
			{
				Type tp = TypeSuivi;
				if ( tp != null )
					return DynamicClassAttribute.GetNomConvivial ( tp );
				return "";
			}
		}

		//------------------------------------------------------
        /// <summary>
        /// Retourne la liste des relations du type de dossier
        /// avec les champs personnalisés.
        /// </summary>
		[RelationFille(typeof(CRelationTypeDossierSuivi_ChampCustom), "Definisseur")]
		[DynamicChilds("Custom fields relations", typeof(CRelationTypeDossierSuivi_ChampCustom))]
		public CListeObjetsDonnees RelationsChampsCustomListe
		{
			get
			{
				return GetDependancesListe ( CRelationTypeDossierSuivi_ChampCustom.c_nomTable, c_champId );
			}
		}

		/// //////////////////////////////////////////////
		public IRelationDefinisseurChamp_ChampCustom[] RelationsChampsCustomDefinis
		{
			get
			{
				return (IRelationDefinisseurChamp_ChampCustom[])GetDependancesListe ( CRelationTypeDossierSuivi_ChampCustom.c_nomTable, c_champId ).ToArray(typeof(IRelationDefinisseurChamp_ChampCustom));
			}
		}

		//-------------------------------------------------------------------
        /// <summary>
        /// Retourne la liste des relations du type de dossier
        /// avec les formulaires (hors formulaire résumé)
        /// </summary>
		[RelationFille(typeof(CRelationTypeDossierSuivi_Formulaire), "Definisseur")]
		[DynamicChilds("Forms relations", typeof(CRelationTypeDossierSuivi_Formulaire))]
		public CListeObjetsDonnees RelationsFormulairesListe
		{
			get
			{
				return  GetDependancesListe(CRelationTypeDossierSuivi_Formulaire.c_nomTable, CTypeDossierSuivi.c_champId);
			}
		}

		//-------------------------------------------------------------------
		public IRelationDefinisseurChamp_Formulaire[] RelationsFormulaires
		{
			get
			{
				return  (IRelationDefinisseurChamp_Formulaire[])RelationsFormulairesListe.ToArray(typeof(IRelationDefinisseurChamp_Formulaire));
			}
		}

		/// //////////////////////////////////////////////
		public CChampCustom[] TousLesChampsAssocies
		{
			get
			{
				return CRecuperateurTousChampsAssociesADefinisseur.GetTousLesChampsAssociesA( this );
			}
		}

		//------------------------------------------------
        /// <summary>
        /// Retourne la liste des relations du type de dossier
        /// avec les types d'éléments liés
        /// </summary>
		[RelationFille(typeof(CRelationTypeDossierSuivi_TypeElement), "TypeDossierSuivi")]
		[DynamicChilds("Element types relations", typeof(CRelationTypeDossierSuivi_TypeElement))]
		public CListeObjetsDonnees RelationsTypesElements
		{
			get
			{
				return GetDependancesListe(CRelationTypeDossierSuivi_TypeElement.c_nomTable, CTypeDossierSuivi.c_champId);
			}
		}

		/// //////////////////////////////////////////////
		public CListeObjetsDonnees Evenements
		{
			get
			{
				return CUtilDefinisseurEvenement.GetEvenementsFor ( this );
			}
		}

		/// //////////////////////////////////////////////
		public Type[] TypesCibleEvenement
		{
			get
			{
				return new Type[]{typeof(CDossierSuivi)};
			}
		}

		//-------------------------------------------------------------------
		public CComportementGenerique[] ComportementsInduits
		{
			get
			{
				return CUtilDefinisseurEvenement.GetComportementsInduits ( this );
			}
		}

		//-------------------------------------------------------------------
        public CRoleChampCustom RoleChampCustomDesElementsAChamp
		{
			get
			{
				return CRoleChampCustom.GetRole(CDossierSuivi.c_roleChampCustom);
			}
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Type de dossier parent auquel appartient ce type de dossier enfant
		/// </summary>
		[Relation ( CTypeDossierSuivi.c_nomTable,
			 CTypeDossierSuivi.c_champId,
			 CTypeDossierSuivi.c_champTypeDossierParent,
			 false,
			 true,
			 false)]
		[DynamicField("Parent workbook type")]
		public CTypeDossierSuivi TypeDossierParent
		{
			get
			{
				return ( CTypeDossierSuivi )GetParent ( c_champTypeDossierParent, typeof ( CTypeDossierSuivi ) );
			}
			set
			{
				SetParent ( c_champTypeDossierParent, value );
			}
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Retourne la liste des Types de dossiers fils
        /// de ce type de dossier parent
		/// </summary>
		[RelationFille(typeof(CTypeDossierSuivi), "TypeDossierParent")]
		[DynamicChilds("Child workbooks types", typeof ( CTypeDossierSuivi) )]
		public CListeObjetsDonnees TypesDossiersFils
		{
			get
			{
				return GetDependancesListe ( c_nomTable, c_champTypeDossierParent );
			}
		}

		/// /////////////////////////////////////////////////////////
		[TableFieldProperty(c_champFiltreElementsSuivisPossibles, NullAutorise=true)]
		public CDonneeBinaireInRow DataFiltre
		{
			get
			{
				if ( Row[c_champFiltreElementsSuivisPossibles] == DBNull.Value )
				{
					CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession ,Row, c_champFiltreElementsSuivisPossibles);
					CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champFiltreElementsSuivisPossibles, donnee);
				}
				object obj = Row[c_champFiltreElementsSuivisPossibles];
				return ((CDonneeBinaireInRow)obj).GetSafeForRow(Row.Row);
			}
			set
			{
				Row[c_champFiltreElementsSuivisPossibles] = value;
			}
		}

		/// /////////////////////////////////////////////////////////////
		/// <summary>
		/// Filtre indiquant les types éléments qui peuvent être suivis.
		/// </summary>
        [BlobDecoder]
        public CFiltreDynamique FiltreDynamiqueElementsSuivisPossibles
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
				AssureVariableDossierInFiltre ( filtre );
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
		public CFiltreDynamique GetNewFiltreElementsSuivis()
		{
			CFiltreDynamique filtre = new CFiltreDynamique(ContexteDonnee);
			AssureVariableDossierInFiltre(filtre);
			return filtre;
		}

		/// /////////////////////////////////////////////////////////////
		protected void AssureVariableDossierInFiltre ( CFiltreDynamique filtre )
		{
			if ( filtre == null )
				return;
			bool bVariableExiste = false;
			foreach ( IVariableDynamique variable in filtre.ListeVariables )
			{
				if ( variable.Nom == c_nomChampDossier )
				{
					bVariableExiste = true;
					break;
				}
			}
			if ( !bVariableExiste )
			{
				CVariableDynamiqueSysteme variable = new CVariableDynamiqueSysteme ( filtre );
				variable.Nom = c_nomChampDossier;
				variable.SetTypeDonnee( new CTypeResultatExpression ( typeof ( CDossierSuivi ), false ) );
                filtre.AddVariable(variable);
			}
			filtre.TypeElements = this.TypeSuivi;
		}
		#region Membres de ITypeElementALien

		public CListeObjetsDonnees TypesRelationsToElement
		{
			get
			{
				return RelationsTypesElements;
			}
		}

		#endregion



		#region IObjetDonneeAutoReference Membres

		public string ChampParent
		{
			get { return c_champTypeDossierParent; }
		}

		public string ProprieteListeFils
		{
			get { return "TypesDossiersFils"; }
		}

		#endregion

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
