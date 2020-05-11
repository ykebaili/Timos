using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;
using timos.securite;

using timos.acteurs;
using sc2i.expression;

namespace timos.data
{

	/// <summary>
	/// Le profil d'élément permet de créer une relation entre 2 types d'entité<br/>
	/// La propriété 'type source' définit le type d'entité de départ et la propriété
	/// 'type elements' le type des entités que l'on souhaite atteindre<br/>
	/// Une fois ces propriétés définies il vous sera possible de
	/// naviguer depuis la structure de l'entité source pour atteindre une ou plusieurs
	/// entités du type de destination.<br/><br/>
	/// Au travers de filtres vous pourrez rapidement créer un WorkFlow facilement
	/// utilisable pour disposer de liens calculés entre deux objets<br/><br/>
	/// 
	/// Pour plus d'information vous pouvez consulter les procédures :
	/// <list type="bullet">
	///		<item><term><see cref="CTypeIntervention">	Créer un Profil Element	</see></term></item>
	///		<item><term><see cref="CTypePhase">			Créer un Filtre			</see></term></item>
	/// </list>
	/// </summary>
    [DynamicClass("Element Profile")]
	[Table(CProfilElement.c_nomTable, CProfilElement.c_champId, true)]
	[ObjetServeurURI("CProfilElementServeur")]
	[Unique (
	false,"The profile '@1' already exist",	CProfilElement.c_champLibelle)]
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iIntervention)]
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iSecurite)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_ProfilElement_ID)]
    public class CProfilElement : CObjetHierarchique,        // Objet hiérarchique Prent/fils
						 IPossesseurContrainte,
						 IElementAFiltreEO,
						IProfilElement		
	{
		public const string c_nomChampSource = "Source";

		public const string c_nomChampElement = "Element";


		public const string c_nomTable = "ELEMENT_PROFILE";
		public const string c_champId = "ELTPR_ID";

		public const string c_champLibelle = "ELTPR_LABEL";

		public const string c_champCodeSystemePartiel = "ELTPR_PARTIAL_SYSCODE";
		public const string c_champCodeSystemeComplet = "ELTPR_FULL_SYSCODE";
		public const string c_champNiveau = "ELTPR_LEVEL";
		public const string c_champIdParent = "ELTPR_PARENT_ID";

		public const string c_champTypeElements = "ELTPR_ELEMENT_TYPE";
		public const string c_champTypeSource = "ELTPR_SOURCE_TYPE";
		
		public const string c_champDataFiltre = "ELTPR_FILTER";
		public const string c_champConditionApplication = "ELTPR_APPLICATION_FRML";
		
		public const string c_champConditionIntegration = "ELTPR_INTEGRATION_FRML";

		public const string c_champFormuleElementAEOSource = "ELTPR_SRV_ELTOE_FRML";

		public const string c_champCheminToElementAEOElt = "ELTPR_SRV_ELTOE_ROUTE";
		




		/// /////////////////////////////////////////////
		public CProfilElement(CContexteDonnee contexte)
			: base(contexte)
		{
		}

		/// /////////////////////////////////////////////
		public CProfilElement(DataRow row)
			: base(row)
		{
		}

		/// /////////////////////////////////////////////
		// Propriété de la classe 
		public override string DescriptionElement
		{
			get
			{
				return I.T( "Element Profile @1|239",Libelle);
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
			base.MyInitValeurDefaut();
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] { c_champLibelle };
		}

		//----------------------------------------------
        /// <summary>
        /// Libellé du profil
        /// </summary>
		[TableFieldProperty(c_champLibelle, 255)]
		[DynamicField("Label")]
		[RechercheRapide]
		public override string Libelle
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
		//----------------------------------------------------
		public override int NbCarsParNiveau
		{
			get
			{
				return 2;
			}
		}

		//----------------------------------------------------
		public override string ChampCodeSystemePartiel
		{
			get
			{
				return c_champCodeSystemePartiel;
			}
		}

		//----------------------------------------------------
		public override string ChampCodeSystemeComplet
		{
			get
			{
				return c_champCodeSystemeComplet;
			}
		}

		//----------------------------------------------------
		public override string ChampNiveau
		{
			get
			{
				return c_champNiveau;
			}
		}

		//----------------------------------------------------
		public override string ChampLibelle
		{
			get
			{
				return c_champLibelle;
			}
		}

		//----------------------------------------------------
		public override string ChampIdParent
		{
			get
			{
				return c_champIdParent;
			}
		}

		//----------------------------------------------------

		//-----------------------------------------------------------
		/// <summary>
		/// Type des éléments retournés par le profil
		/// </summary>
		[TableFieldProperty(c_champTypeElements, 300)]
		[DynamicField("Elements type")]
		public string TypeElementsString
		{
			get
			{
				return (string)Row[c_champTypeElements];
			}
			set
			{
				Row[c_champTypeElements] = value;
			}
		}

		//-----------------------------------------------------------
		public Type TypeElements
		{
			get
			{
				try
				{
					Type tp = CActivatorSurChaine.GetType ( TypeElementsString );
					return tp;
				}
				catch{}
				return null; 
			}
			set
			{
				if (value == null)
					TypeElementsString = "";
				else
					TypeElementsString = value.ToString();
			}
		}



		//-----------------------------------------------------------
		/// <summary>
		/// Definit le type d'entité auquel est attaché le profil
		/// </summary>
		[TableFieldProperty(c_champTypeSource, 300)]
		[DynamicField("Source type")]
		public string TypeSourceString
		{
			get
			{
				return (string)Row[c_champTypeSource];
			}
			set
			{
				Row[c_champTypeSource] = value;
			}
		}

		//-----------------------------------------------------------
		public Type TypeSource
		{
			get
			{
				try
				{
					Type tp = CActivatorSurChaine.GetType(TypeSourceString);
					return tp;
				}
				catch { }
				return null;
			}
			set
			{
				if (value == null)
					TypeSourceString = "";
				else
					TypeSourceString = value.ToString();
			}
		}



		//----------------------------------------------------
		/// <summary>
		/// ProfilElement parent dans la hiérarchie
		/// </summary>
		[Relation(
			c_nomTable,
			c_champId,
			c_champIdParent,
			false,
			false)]
		[DynamicField("Parent element profile")]
		public CProfilElement ProfilElementParent
		{
			get
			{
				return (CProfilElement)ObjetParent;
			}
			set
			{
				if (value != null)
					ObjetParent = value;
			}
		}

		//----------------------------------------------------
		/// <summary>
		/// Liste des ProfilElements fils dans la hiérarchie
		/// </summary>
		[RelationFille(typeof(CProfilElement), "ProfilElementParent")]
		[DynamicChilds("Child profiles", typeof(CProfilElement))]
		public CListeObjetsDonnees ProfilElementsFils
		{
			get
			{
				return ObjetsFils;
			}
		}

		//----------------------------------------------------
		/// <summary>
		/// Indique le code système propre (unique dans son parent) du ProfilElement
		/// </summary>
		[TableFieldProperty(c_champCodeSystemePartiel, 4)]
		[DynamicField("Partial system code")]
		public override string CodeSystemePartiel
		{
			get
			{
				string strVal = "";
				if (Row[c_champCodeSystemePartiel] != DBNull.Value)
					strVal = (string)Row[c_champCodeSystemePartiel];
				strVal = strVal.Trim().PadLeft(2, '0');
				return (string)Row[c_champCodeSystemePartiel];
			}
		}

		//----------------------------------------------------
		/// <summary>
		/// Indique le code système complet du ProfilElement<br/>
        /// Le code complet est composé du code de l'entité parente, et du code partiel
		/// </summary>
		[TableFieldProperty(c_champCodeSystemeComplet, 400)]
		[DynamicField("Full system code")]
		public override string CodeSystemeComplet
		{
			get
			{
				return (string)Row[c_champCodeSystemeComplet];
			}
		}

		//----------------------------------------------------
		/// <summary>
		/// Indique le niveau hiérarchique( nombre de parents ) du ProfilElement<br/>
        /// Le niveau d'un ProfilElement sans parent est 0
		/// </summary>
		[TableFieldProperty(c_champNiveau)]
		[DynamicField("Level")]
		public override int Niveau
		{
			get
			{
				return (int)Row[c_champNiveau];
			}
		}

		//---------------------------------------- ------------------------------
		/// <summary>
		/// Retourne la liste des Contrainte d'accès (Serrures, ...) liées au profil
		/// </summary>
		[RelationFille(typeof(CContrainte), "ProfilElement")]
		[DynamicChilds("Constraints", typeof(CContrainte))]
		public CListeObjetsDonnees Contraintes
		{
			get
			{
				return GetDependancesListe(CContrainte.c_nomTable, c_champId);
			}

		}


		/// /////////////////////////////////////////////////////////
		[TableFieldProperty(CProfilElement.c_champDataFiltre, NullAutorise = true)]
		public CDonneeBinaireInRow DataFiltre
		{
			get
			{
				if (Row[c_champDataFiltre] == DBNull.Value)
				{
					CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession, Row, c_champDataFiltre);
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
		/// Filtre indiquant les éléments qui entrent dans le profil
		/// </summary>
        [BlobDecoder]
		public CFiltreDynamique FiltreDynamiqueElementsSuivisPossibles
		{
			get
			{
				CFiltreDynamique filtre = null;
				if (DataFiltre.Donnees != null)
				{
					filtre = new CFiltreDynamique(ContexteDonnee);
					MemoryStream stream = new MemoryStream(DataFiltre.Donnees);
					BinaryReader reader = new BinaryReader(stream);
					CSerializerReadBinaire serializer = new CSerializerReadBinaire(reader);
					CResultAErreur result = filtre.Serialize(serializer);
					if (!result)
					{
						filtre = null;
					}
                    reader.Close();
                    stream.Close();
				}
				AssureVariableSourceInFiltre(filtre, TypeSource);
				return filtre;
			}
			set
			{
				if (value == null)
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
					CResultAErreur result = value.Serialize(serializer);
					if (result)
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
		public CFiltreDynamique GetNewFiltreElements()
		{
			CFiltreDynamique filtre = new CFiltreDynamique(ContexteDonnee);
			AssureVariableSourceInFiltre(filtre, TypeSource);
			return filtre;
		}

		/// /////////////////////////////////////////////////////////////
		public IVariableDynamique AssureVariableSourceInFiltre(CFiltreDynamique filtre, Type typeSource)
		{
			if (filtre == null)
				return null;
			bool bVariableExiste = false;
			IVariableDynamique variableRetenue = null;
			foreach (IVariableDynamique variable in filtre.ListeVariables)
			{
				if (variable.Nom == c_nomChampSource)
				{
					if (TypeSource != typeSource)
						filtre.RemoveVariable(variable);
					else
					{
						bVariableExiste = true;
						variableRetenue = variable;
					}
					break;
				}
			}
			if (!bVariableExiste)
			{
				variableRetenue = new CVariableDynamiqueSysteme(filtre);
				variableRetenue.Nom = c_nomChampSource;
				((CVariableDynamiqueSysteme)variableRetenue).SetTypeDonnee(new CTypeResultatExpression(typeSource, false));
                filtre.AddVariable(variableRetenue);
			}
			filtre.TypeElements = TypeElements;
			return variableRetenue;
		}


		//-----------------------------------------------------------
		[TableFieldProperty ( CProfilElement.c_champConditionApplication, 2000 )]
		public string FormuleApplicationString
		{
			get
			{
				return (string)Row[c_champConditionApplication];
			}
			set
			{
				Row[c_champConditionApplication] = value;
			}
		}

		public C2iExpression FormuleApplication
		{
			get
			{
				C2iExpression expression = C2iExpression.FromPseudoCode(FormuleApplicationString);
				if (expression == null)
					expression = new C2iExpressionVrai();
				return expression;
			}
			set
			{
				if (value == null)
					FormuleApplicationString = "";
				else
					FormuleApplicationString = C2iExpression.GetPseudoCode(value);
			}		
		}

		//---------------------------------------------
		[TableFieldProperty(CProfilElement.c_champConditionIntegration, 2000)]
		
		public string FormuleIntegrationString
		{
			get
			{
				return (string)Row[c_champConditionIntegration];
			}
			set
			{
				Row[c_champConditionIntegration] = value;
			}
		}

		//---------------------------------------------
		public C2iExpression FormuleIntegration
		{
			get
			{
				C2iExpression formule = C2iExpression.FromPseudoCode(FormuleIntegrationString);
				if (formule == null)
					formule = new C2iExpressionVrai();
				return formule;
			}
			set
			{
				if (value == null)
					FormuleIntegrationString = "";
				else
					FormuleIntegrationString = C2iExpression.GetPseudoCode(value);
			}
		}


		//---------------------------------------------
		[TableFieldProperty(CProfilElement.c_champFormuleElementAEOSource, 500)]
		public string FormuleElementAEOSourceString
		{
			get
			{
				return (string)Row[c_champFormuleElementAEOSource];
			}
			set
			{
				Row[c_champFormuleElementAEOSource] = value;
			}
		}

		//---------------------------------------------
		public C2iExpression FormuleElementAEOSource
		{
			get
			{
				C2iExpression formule = C2iExpression.FromPseudoCode(FormuleElementAEOSourceString);
				return formule;
			}
			set
			{
				if (value == null)
					FormuleElementAEOSourceString = "";
				else
					FormuleElementAEOSourceString = C2iExpression.GetPseudoCode(value);
			}
		}


		//---------------------------------------------
		[TableFieldProperty (CProfilElement.c_champCheminToElementAEOElt, 1000 )]
		public string CheminToElementAEoElement
		{
			get
			{
				return (string)Row[c_champCheminToElementAEOElt];
			}
			set
			{
				Row[c_champCheminToElementAEOElt] = value;
			}
		}

		//---------------------------------------------
		public CDefinitionProprieteDynamique ProprieteCheminToEOElement
		{
			get
			{
				if (CheminToElementAEoElement != "")
				{
					CStringSerializer serializer = new CStringSerializer(CheminToElementAEoElement, ModeSerialisation.Lecture);
					I2iSerializable def = null;
					CResultAErreur result = serializer.SerializeObjet(ref def);
					if (!result || !(def is CDefinitionProprieteDynamique) )
						return null;
					return (CDefinitionProprieteDynamique)def;
				}
				return null;
			}
			set
			{
				if (value == null)
					CheminToElementAEoElement = "";
				else
				{
					CStringSerializer serializer = new CStringSerializer(ModeSerialisation.Ecriture);
					I2iSerializable def = (I2iSerializable)value;
					CResultAErreur result = serializer.SerializeObjet(ref def);
					if (result)
						CheminToElementAEoElement = serializer.String;
				}
			}
		}


		//---------------------------------------------
		/// <summary>
		/// Liste des types d'entités organisationnelles déterminant<br/>
        /// les entités organisationnelles que les éléments filtrés<br/>
        /// doivent avoir en commun avec la source à comparer,<br/>
        /// pour que les éléments filtrés soient sélectionnés.
		/// </summary>
		[RelationFille(typeof(CProfilElement_TypeEO), "ProfilElement")]
		[DynamicChilds("OE type relations", typeof(CProfilElement_TypeEO))]
		public CListeObjetsDonnees TypesEO
		{
			get
			{
				return GetDependancesListe(CProfilElement_TypeEO.c_nomTable, c_champId);
			}
		}


		//-------------------------------------------------------------------------
		public CFiltreData GetFiltreEOS(IElementAEO element)
		{
			List<COptionCorrespondanceEO> lst = new List<COptionCorrespondanceEO>();
			foreach (COptionCorrespondanceEO eo in ToutesLesCorrespondancesEO)
				lst.Add(eo);
			return CUtilElementAEO.GetFiltrePourTypeEosCommuns(element, lst);

		}


		//---------------------------------------------

		//---------------------------------------------
		/// <summary>
		/// Retourne la liste des profils inclus
		/// </summary>
		[RelationFille(typeof(CProfilElement_ProfilInclu), "ProfilIncluant")]
		[DynamicChilds("Inclusions", typeof(CProfilElement_ProfilInclu))]
		public CListeObjetsDonnees ProfilsInclus
		{
			get
			{
				return GetDependancesListe(CProfilElement_ProfilInclu.c_nomTable, CProfilElement_ProfilInclu.c_champIdProfilIncluant);
			}
		}

		

		#region Applatissons la hiérarchie
		//---------------------------------------------
		/// <summary>
		/// Retourne tous les types d'eo que le acteur doit avoir en
		/// commun avec le site pour appartenir à ce profil
		/// </summary>
		public List<COptionCorrespondanceEO> ToutesLesCorrespondancesEO
		{
			get
			{
				//TypeEO->n'importe quoi
				Hashtable tbl = new Hashtable();
				FillTableCorrespondancesTypesEONecessaires(tbl);
				List<COptionCorrespondanceEO> lst = new List<COptionCorrespondanceEO>();
				foreach (COptionCorrespondanceEO tp in tbl.Keys)
					lst.Add(tp);
				return lst;
			}
		}

		//---------------------------------------------
		public void FillTableCorrespondancesTypesEONecessaires(Hashtable tbl)
		{
			foreach (CProfilElement_TypeEO rel in TypesEO)
			{
				tbl[new COptionCorrespondanceEO ( rel.TypeEntiteOrganisationnelle, rel.ModeComparaison )] = true;
			}
			if (ProfilElementParent != null)
				ProfilElementParent.FillTableCorrespondancesTypesEONecessaires(tbl);
		}


		//---------------------------------------------
		/// <summary>
		/// Retourne toutes les contraintes de ce profil
		/// </summary>
		public List<CContrainte> ToutesLesContraintes
		{
			get
			{
				Hashtable tbl = new Hashtable();
				FillTableContraintesNecessaires(tbl);
				List<CContrainte> lst = new List<CContrainte>();
				foreach (CContrainte ctr in tbl.Keys)
					lst.Add(ctr);
				return lst;
			}
		}

		//---------------------------------------------
		public void FillTableContraintesNecessaires(Hashtable tbl)
		{
			foreach (CContrainte contrainte in Contraintes)
				tbl[contrainte] = true;
			if (ProfilElementParent != null)
				ProfilElementParent.FillTableContraintesNecessaires(tbl);
		}

		
		#endregion

		
		#region IElementAFiltreEO Membres

		public COptionCorrespondanceEO[] OptionsPropres
		{
			get
			{
				List<COptionCorrespondanceEO> lst = new List<COptionCorrespondanceEO>();
				foreach ( CProfilElement_TypeEO rel in TypesEO )
					lst.Add ( new COptionCorrespondanceEO ( rel.TypeEntiteOrganisationnelle, rel.ModeComparaison ));
				return lst.ToArray();

			}
			set
			{
				Hashtable tableRelations = new Hashtable();
				Hashtable tableRelationsToDelete = new Hashtable();
				foreach ( CProfilElement_TypeEO rel in TypesEO )
				{
					tableRelations[rel.TypeEntiteOrganisationnelle] = rel;
					tableRelationsToDelete[rel] = true;
				}
				foreach ( COptionCorrespondanceEO option in value )
				{
					CProfilElement_TypeEO relToSet = (CProfilElement_TypeEO)tableRelations[option.TypeEO];
					if ( relToSet == null )
					{
						relToSet = new CProfilElement_TypeEO ( ContexteDonnee );
						relToSet.CreateNewInCurrentContexte();
						relToSet.ProfilElement = this;
					}
					relToSet.TypeEntiteOrganisationnelle = option.TypeEO;
					relToSet.ModeComparaison = option.ModeComparaison;
					tableRelationsToDelete[relToSet] = false;
					tableRelations[option.TypeEO] = relToSet;
				}
				
				foreach (DictionaryEntry entry in tableRelationsToDelete )
				{
					if ( (bool)entry.Value )
					{
						CProfilElement_TypeEO rel = (CProfilElement_TypeEO)entry.Key;
						rel.Delete();
					}
				}
			}
		}

		#endregion

		/*//---------------------------------------------
		public CListeObjetsDonnees GetElementsForSource(IObjetDonneeAIdNumeriqueAuto source, CFiltreData filtreSupplementaire)
		{
			CListeObjetsDonnees liste = null;
			if ( source == null )
			{
				liste = new CListeObjetsDonnees ( ContexteDonnee, TypeElements, new CFiltreDataImpossible());
			}
			else
			{	
				IProfilElementServeur serveur = (IProfilElementServeur)GetLoader();
				CResultAErreur result = serveur.GetIdsElementsForSource(Id, source.Id, filtreSupplementaire);
				if (result )
				{
					liste = CListeObjetsDonnees.GetListeFromIds(ContexteDonnee, TypeElements, (int[])result.Data);
				}
			}
			return liste;
		}*/


		//-------------------------------------------------------------------
		protected CResultAErreur GetIdsForEOSEtContraintes ( 
			List<CContrainte> contraintes,
			CObjetDonneeAIdNumerique objetSource,
			IElementAEO objetAEO,
			CFiltreData filtreDeBase,
			bool bTousSiPasDeFiltre,
            ref CFiltreData filtreApplicableGlobal)
		{
			CResultAErreur  result = CResultAErreur.True;

			CObjetDonneeAIdNumerique objetElementTmp = ( CObjetDonneeAIdNumerique )Activator.CreateInstance ( TypeElements, new object[]{objetSource.ContexteDonnee} );
			string strId = objetElementTmp.GetChampId();
			
			CFiltreData newFiltreDeBase = filtreDeBase;
			if ( objetAEO is IElementAEO )
			{
				CFiltreData filtreEos = GetFiltreEOS((IElementAEO)objetAEO);
                if (filtreEos != null && filtreEos.HasFiltre)
                {
                    CDefinitionProprieteDynamique propEO = this.ProprieteCheminToEOElement;
                    if (propEO != null)
                    {
                        string strTableElt = CContexteDonnee.GetNomTableForType(propEO.TypeDonnee.TypeDotNetNatif);
                        //convertit le filtre en filtre avance
                        CFiltreDataAvance fEOTmp = CFiltreDataAvance.ConvertFiltreToFiltreAvance(strTableElt, filtreEos);
                        fEOTmp.ChangeTableDeBase(objetElementTmp.GetNomTable(), propEO.NomPropriete);
                        filtreEos = fEOTmp;
                    }
                    newFiltreDeBase = CFiltreData.GetAndFiltre(newFiltreDeBase, filtreEos);
                }
			}

			if ((newFiltreDeBase == null || !newFiltreDeBase.HasFiltre) && (contraintes == null || contraintes.Count == 0 ) && !bTousSiPasDeFiltre)//Si pas de filtre, on sélectionne tout !
			{
                filtreApplicableGlobal = null;
				result.Data = new int[0];
				return result;
			}



            filtreApplicableGlobal = newFiltreDeBase;
			

			C2iRequeteAvancee requete = new C2iRequeteAvancee(ContexteDonnee.IdVersionDeTravail);
			requete.TableInterrogee = objetElementTmp.GetNomTable();
			C2iChampDeRequete champ = new C2iChampDeRequete(
				"Id",
				new CSourceDeChampDeRequete(strId),
				typeof(int),
				OperationsAgregation.None,
				false);
			requete.ListeChamps.Add(champ);
			requete.FiltreAAppliquer = newFiltreDeBase;
			result = requete.ExecuteRequete(ContexteDonnee.IdSession);
			if (!result)
				return result;

            StringBuilder blIds = new StringBuilder();
			List<int> listeIdsElements = new List<int>();
			DataTable table = (DataTable)result.Data;
			foreach (DataRow row in table.Rows)
			{
				listeIdsElements.Add(Convert.ToInt32(row[0]));
                blIds.Append(row[0]);
                blIds.Append(';');
			}
			result.Data = listeIdsElements.ToArray();

			#region Gestion des contraintes à lever
			if ( (typeof(IPossesseurRessource).IsAssignableFrom ( TypeElements) || TypeElements == typeof(CRessourceMaterielle) )&&  blIds.Length>0 && contraintes != null && contraintes.Count > 0)
			{
				string strChampId = objetElementTmp.GetChampId();
                blIds.Remove(blIds.Length - 1, 1);
				foreach ( CContrainte contrainte in contraintes )	
				{
					CFiltreDataAvance filtre = new CFiltreDataAvance(CRessourceMaterielle.c_nomTable,
						strId + " in (" + blIds.ToString() + ")");
					CListeObjetsDonnees listeRessources = contrainte.GetToutesLesRessourcesLevant(filtre);

					//Refiltre les éléments avec ceux qui peuvent lever les contraintes
					Hashtable tblIds = new Hashtable();
					foreach (CRessourceMaterielle res in listeRessources)
					{
						if ( res.Emplacement != null && res.Emplacement.GetType() == TypeElements && 
							res.Emplacement is IObjetDonneeAIdNumerique )
							tblIds[((IObjetDonneeAIdNumerique)res.Emplacement).Id] = true;
						else
							 if ( TypeElements == typeof(CRessourceMaterielle ))
								 tblIds[res.Id] = true;
							
					}
                    blIds = new StringBuilder();

					listeIdsElements.Clear();
					foreach (int nId in tblIds.Keys)
					{
                        blIds.Append(nId);
                        blIds.Append(';');
						listeIdsElements.Add(nId);

					}
                    if ( blIds.Length == 0 )
					{
						result.Data = new int[0];
						break;
					}
                    blIds.Remove(blIds.Length - 1, 1);
					result.Data = listeIdsElements.ToArray();
                    filtreApplicableGlobal = new CFiltreDataAvance(CRessourceMaterielle.c_nomTable,
                        strChampId + " in (" + blIds.ToString() + ")");
				}
			}
			#endregion
			return result;
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// 
		/// </summary>
		/// <param name="inclusion"></param>
		/// <param name="source"></param>
		/// <param name="contrainteUniqueALever"></param>
		/// <param name="filtreDeBase"></param>
		/// <param name="filtreApplicablePourInclusion">
        /// si non null, il est possible d'appliquer ce filtre pour les sous éléments
        /// sinon, il faut passer par les ids des éléments
        /// </param>
		/// <returns></returns>
        public CResultAErreur GetIdsElementsForInclusion ( CProfilElement_ProfilInclu inclusion, 
			CObjetDonneeAIdNumerique source, 
			CContrainte contrainteUniqueALever,
			CFiltreData filtreDeBase,
            ref CFiltreData filtreApplicablePourInclusion)
		{
			CResultAErreur result = CResultAErreur.True;
            filtreApplicablePourInclusion = new CFiltreData();
			if ( inclusion.ModeInclusion == EModeInclusionProfilElement.Profil && inclusion.ProfilInclu != null )
				return inclusion.ProfilInclu.GetIdsElementsForSource ( source, contrainteUniqueALever, filtreDeBase, ref filtreApplicablePourInclusion );
			else
			{
				List<int[]> lstListeIds = new List<int[]>();
                List<CFiltreData> lstFiltresInclusion = new List<CFiltreData>();
				foreach ( CProfilElement_ProfilInclu sousProfil in inclusion.InclusionsFilles )
				{
                    CFiltreData filtrePartiel = null;
					result = GetIdsElementsForInclusion ( sousProfil, source, contrainteUniqueALever, filtreDeBase, ref filtrePartiel );
					if ( !result )
						return result;
					lstListeIds.Add ( (int[])result.Data );
                    lstFiltresInclusion.Add(filtrePartiel);
				}
				Hashtable tableIds = new Hashtable();
                
				if ( inclusion.ModeInclusion == EModeInclusionProfilElement.Ou )
				{
					
					foreach ( int[] liste in lstListeIds )
						foreach ( int nId in liste )
							tableIds[nId] = true;
                    foreach (CFiltreData filtrePartiel in lstFiltresInclusion)
                    {
                        if (filtrePartiel == null)
                            filtreApplicablePourInclusion = null;
                        if (filtrePartiel != null && filtreApplicablePourInclusion != null)
                            filtreApplicablePourInclusion = CFiltreData.GetOrFiltre(filtreApplicablePourInclusion, filtrePartiel);
                    }
                }
				if ( inclusion.ModeInclusion == EModeInclusionProfilElement.Et )
				{
					int nIndex = 0;
					foreach ( int[] liste in lstListeIds )
					{
						foreach ( int nId in liste )
						{
							if ( nIndex == 0 )
								tableIds[nId] = nIndex;
							else
							{
								if ( tableIds.Contains ( nId ) )
									tableIds[nId] = nIndex;
							}
						}
						foreach ( DictionaryEntry entry in new ArrayList ( tableIds ) )
						{
							if ( (int)entry.Value != nIndex )
								tableIds.Remove ( entry.Key );
						}
						nIndex++;
					}
                    foreach (CFiltreData filtrePartiel in lstFiltresInclusion)
                    {
                        if (filtrePartiel == null)
                            filtreApplicablePourInclusion = null;
                        if (filtrePartiel != null && filtreApplicablePourInclusion != null)
                            filtreApplicablePourInclusion = CFiltreData.GetAndFiltre(filtreApplicablePourInclusion, filtrePartiel);
                    }
				}
				ArrayList lst = new ArrayList();
				foreach ( int nId in tableIds.Keys )
						lst.Add (nId );
					result.Data = lst.ToArray(typeof(int));
					return result;
			}
							
						

		}

		public CResultAErreur GetIdsElementsForSource(
			IObjetDonneeAIdNumerique source,
			CFiltreData filtreDeBase,
            ref CFiltreData filtreApplicableGlobal)
		{
			return GetIdsElementsForSource(source, null, filtreDeBase, ref filtreApplicableGlobal);
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// SI contrainte unique a lever n'est pas null, les contraintes du profil sont utilisée,
		/// sinon, c'est la contrainte demandée qui est utilisée
		/// </summary>
		/// <param name="source"></param>
		/// <param name="filtreDeBase"></param>
        /// <param name="filtreApplicableGlobal">
        /// Filtre qu'il est possible d'appliquer pour avoir tous les éléments au lieu d'utiliser les ids
        /// Si null, il n'est pas possible d'appliquer un filtre optimisé, il faudra
        /// filtrer sur les ids des éléments
        /// </param>
		/// <returns></returns>
		public CResultAErreur GetIdsElementsForSource(
			IObjetDonneeAIdNumerique source, 
			CContrainte contrainteUniqueALever,
			CFiltreData filtreDeBase,
            ref CFiltreData filtreApplicableGlobal)
		{
			CResultAErreur result = CResultAErreur.True;
            filtreApplicableGlobal = new CFiltreData();
			//Calcule le filtre de base
			//Vérifie la condition d'application du profil
			C2iExpression formuleApplication = FormuleApplication;
			if (formuleApplication != null && formuleApplication.GetType() != typeof(C2iExpressionVrai))
			{
				CElementAVariablesDynamiques eltAVariable = GetElementInterrogePourApplication(TypeSource);
				FillElementInterrogePourApplication(eltAVariable, source);
				CContexteEvaluationExpression contexte = new CContexteEvaluationExpression(eltAVariable);
				result = formuleApplication.Eval(contexte); ;
				if (!result || !(result.Data is bool))
				{
					result.EmpileErreur(I.T("Error during the evaluation of applying condition|240"));
					return result;
				}
				bool bAppliquer = (bool)result.Data;
				if (!bAppliquer)
					return CResultAErreur.True;
			}

			CFiltreData newFiltreDeBase = filtreDeBase;
			CFiltreDynamique filtreDyn = FiltreDynamiqueElementsSuivisPossibles;
			//Calcule le filtre d'intégration
			if ( filtreDyn != null  )
			{
				filtreDyn.SetValeurChamp(AssureVariableSourceInFiltre(filtreDyn, TypeSource), source);
				result = filtreDyn.GetFiltreData();
				if (!result)
				{
					result.EmpileErreur(I.T("Impossible to calculate filter|241"));
					return result;
				}
				CFiltreData filtreTmp = (CFiltreData)result.Data;
				newFiltreDeBase = CFiltreData.GetAndFiltre(filtreDeBase, filtreTmp);
			}

			IElementAEO elementAEo = null;
			C2iExpression formuleElementAEo = FormuleElementAEOSource;
			if (formuleElementAEo != null)
			{
				CElementAVariablesDynamiques elt = GetElementInterrogePourApplication(source.GetType());
				FillElementInterrogePourApplication(elt, source);
				CContexteEvaluationExpression contexteEvaluation = new CContexteEvaluationExpression(elt);
				result = formuleElementAEo.Eval(contexteEvaluation);
				if (!result) return result;
				if (result.Data is IElementAEO)
					elementAEo = (IElementAEO)result.Data;
			}
			else if (source is IElementAEO)
				elementAEo = (IElementAEO)source;

			//Si on cherche une ressource pour un contrainte, il faut que la ressource lève la contrainte !
			List<CContrainte> contraintes = ToutesLesContraintes;
			if (contrainteUniqueALever != null)
			{
				contraintes = new List<CContrainte>();
				contraintes.Add(contrainteUniqueALever);
			}


			if (contrainteUniqueALever == null && 
				TypeElements == typeof(CActeur) && 
				source is CIntervention && 
				((CIntervention)source).ElementLiePrincipal is CSite)
			{
				foreach (CContrainte contrainte in ((CSite)((CIntervention)source).ElementLiePrincipal).ToutesLesContraintes)
				{
					if (contrainte.TypeContrainte.IsContrainteNecessaireActeur)
						contraintes.Add(contrainte);
				}
			}

			result = GetIdsForEOSEtContraintes (
				contraintes,
				(CObjetDonneeAIdNumerique)source,
				elementAEo,
				newFiltreDeBase,
				!(FormuleIntegration is C2iExpressionVrai),
                ref filtreApplicableGlobal);

			if ( !result )
				return result;
			List<int> idsRetenus = new List<int>();
            ///Indique que le filtre applicable est plus qu'un filtre applicable avec des ids
			if (FormuleIntegration.GetType() != typeof(C2iExpressionVrai))
			{
                filtreApplicableGlobal = null;
				CListeObjetsDonnees listeObjets = CListeObjetsDonnees.GetListeFromIds(ContexteDonnee, TypeElements, (int[])result.Data);
				CElementAVariablesDynamiques eltAVariable = GetElementInterrogePourIntegration(TypeElements, TypeSource);
				CContexteEvaluationExpression contexte = new CContexteEvaluationExpression(eltAVariable);
				foreach (CObjetDonneeAIdNumerique objet in listeObjets)
				{
					FillElementInterrogePourIntegration(eltAVariable, objet, source);
					result = formuleApplication.Eval(contexte); ;
					if (!result || !(result.Data is bool))
					{
						result.EmpileErreur(I.T("Error during the evaluation of applying condition|240"));
						return result;
					}
					bool bAppliquer = (bool)result.Data;
					if (bAppliquer)
						idsRetenus.Add(objet.Id);
				}
			}
			else
				if (result.Data is int[])
					idsRetenus.AddRange((int[])result.Data);


			Hashtable tableIds = new Hashtable();
			foreach ( int nId in idsRetenus )
				tableIds[nId] = true;
			//Ajoute les ids des profils inclus
			foreach ( CProfilElement_ProfilInclu inclusion in ProfilsInclus )
			{
                CFiltreData filtreApplicablePartiel = null;
				result = GetIdsElementsForInclusion ( 
                    inclusion, 
                    (CObjetDonneeAIdNumerique)source, 
                    contrainteUniqueALever, 
                    newFiltreDeBase,
                    ref filtreApplicablePartiel);
				if ( !result )
					return result;
				foreach ( int nId in (int[])result.Data )
					tableIds[nId] = true;
                if (filtreApplicableGlobal != null && filtreApplicablePartiel != null)
                    filtreApplicableGlobal = CFiltreData.GetOrFiltre(filtreApplicableGlobal, filtreApplicablePartiel);
                if (filtreApplicablePartiel == null)
                    filtreApplicableGlobal = null;
			}
			ArrayList lst = new ArrayList();
			foreach (int nId in tableIds.Keys)
				lst.Add(nId);
			result.Data = lst.ToArray(typeof(int));
			return result;
		}

		//---------------------------------------------
		/// <summary>
		/// Retourne un clisteobjetdonnee des éléments qui font partie du profil
		/// </summary>
		/// <param name="source"></param>
		/// <param name="filtre"></param>
		/// <returns></returns>
		public CListeObjetsDonnees GetElementsForSource(IObjetDonneeAIdNumerique source, CFiltreData filtre)
		{
			return GetElementsForSource(source, null, filtre);
		}

		//-----------------------------------------------------------------------------
		public CListeObjetsDonnees GetElementsForSource(IObjetDonneeAIdNumerique source, CContrainte contrainteUniqueALever, CFiltreData filtre)
		{
            CFiltreData filtreTmp = null;
			CResultAErreur result = GetIdsElementsForSource(source, contrainteUniqueALever, filtre, ref filtreTmp);
			if (result && result.Data is int[])
			{
                CListeObjetsDonnees liste = null;
                if ( filtreTmp != null )
                    liste = new CListeObjetsDonnees(ContexteDonnee, TypeElements, filtreTmp);
                else
				    liste = CListeObjetsDonnees.GetListeFromIds(ContexteDonnee, TypeElements, (int[])result.Data);
				return liste;
			}
			else
			{
				CListeObjetsDonnees liste = new CListeObjetsDonnees(ContexteDonnee, TypeElements, new CFiltreData("1=0"));
				return liste;
			}

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="profil"></param>
		/// <param name="source"></param>
		/// <param name="contrainteUniqueALever">Si defini, les contraintes du profil sont remplacées par cette contrainte</param>
		/// <param name="filtreDeBase"></param>
		/// <returns></returns>
		public static CListeObjetsDonnees GetElementsForSource(
			IProfilElement profil, 
			IObjetDonneeAIdNumerique source, 
			CContrainte contrainteUniqueALever,
			CFiltreData filtreDeBase)
		{
			CResultAErreur result = CResultAErreur.True;
			CFiltreData leFiltreAAppliquer = filtreDeBase;
			CListeObjetsDonnees listeFinale = null;
			if (profil == null)
				return null;
            CFiltreData filtreApplicableGlobal = new CFiltreData();
			foreach (CProfilElement profilElement in profil.TousLesProfilsARemplir)
			{
                CFiltreData filtrePartiel = null;
				result = profilElement.GetIdsElementsForSource(source, contrainteUniqueALever, leFiltreAAppliquer, ref filtrePartiel);
                if (filtrePartiel == null)
                    filtreApplicableGlobal = null;
                else if (filtreApplicableGlobal != null)
                    filtreApplicableGlobal = CFiltreData.GetAndFiltre(filtreApplicableGlobal, filtrePartiel);
				if (result && result.Data is int[])
				{
					int[] ids = (int[])result.Data;
					if (ids.Length == 0)
						return null;
					string strIds = "";
					foreach (int nId in ids)
						strIds += nId.ToString() + ";";
					strIds = strIds.Substring(0, strIds.Length - 1);
					///récupère le champ id
					CObjetDonneeAIdNumerique objTmp = (CObjetDonneeAIdNumeriqueAuto)Activator.CreateInstance(profilElement.TypeElements, source.ContexteDonnee);
					string strChampId = objTmp.GetChampId();
					CFiltreDataAvance filtre = new CFiltreDataAvance(
						objTmp.GetNomTable(),
						strChampId + " in (" + strIds + ")");
					leFiltreAAppliquer = CFiltreData.GetAndFiltre(filtre, filtreDeBase);
					listeFinale = new CListeObjetsDonnees(source.ContexteDonnee, profilElement.TypeElements);
					listeFinale.Filtre = leFiltreAAppliquer;
				}
				else
					return null;
			}
            if (filtreApplicableGlobal != null && listeFinale != null)
                listeFinale.Filtre = filtreApplicableGlobal;
			return listeFinale;
		}


		//---------------------------------------------
        /// <summary>
        /// Retourne la liste des éléments filtrés par le profil en fonction<br/>
        /// de la source passée en paramètre.
        /// </summary>
        /// <param name="source">Source</param>
        /// <returns>Liste d'éléments</returns>
		[DynamicMethod("Returns the elements in the profil for the source",	"Source")]
		public CListeObjetsDonnees GetElementListForSource(IObjetDonneeAIdNumerique source)
		{

            return GetElementsForSource(source, null);
			//return (CObjetDonneeAIdNumerique[])GetElementsForSource(source, null).ToArray(typeof(CObjetDonneeAIdNumerique));
		}

        //---------------------------------------------
        /// <summary>
        /// Retourne le nombre d'éléments filtrés par le profil en fonction<br/>
        /// de la source passée en paramètre.
        /// </summary>
        /// <param name="source">Source</param>
        /// <returns>Nombre d'éléments</returns>
        [DynamicMethod("Returns the number of elements in the profil for the source", "Source")]
        public int GetNumberOfElementsForSource(IObjetDonneeAIdNumeriqueAuto source)
        {
            CFiltreData filtreTotal = null;
            CResultAErreur result = GetIdsElementsForSource(source, null, ref filtreTotal);
            if (result)
                return ((int[])result.Data).Length;
            return 0;
        }

		//-----------------------------------------------------------------
		/// <summary>
		/// Retourne vrai si ce profil utilise un autre profil
		/// </summary>
		/// <param name="profil"></param>
		/// <returns></returns>
		public bool UtiliseLeProfil(CProfilElement profil)
		{
			if (profil == null)
				return false;
			if (ProfilElementParent != null && ProfilElementParent.UtiliseLeProfil(profil))
				return true;
			foreach (CProfilElement_ProfilInclu inclusion in ProfilsInclus)
			{
				if (inclusion.UtiliseLeProfil(profil))
					return true;
			}
			return false;
		}

		//--------------------------------------------------------------------
		private IVariableDynamique GetVariableElementForExpressions(IElementAVariablesDynamiques elt, Type typeElement)
		{
			CVariableDynamiqueStatique variable = new CVariableDynamiqueStatique(elt);
			variable.SetTypeDonnee(new CTypeResultatExpression(typeElement, false));
			variable.Nom = c_nomChampElement;
			return variable;
		}

		//--------------------------------------------------------------------
		private IVariableDynamique GetVariableSourceForExpression(IElementAVariablesDynamiques elt, Type typeSource)
		{
			CVariableDynamiqueStatique variable = new CVariableDynamiqueStatique(elt);
			variable.Nom = c_nomChampSource;
			variable.SetTypeDonnee(new CTypeResultatExpression(typeSource, false));
			return variable;
		}

		//--------------------------------------------------------------------
		public CElementAVariablesDynamiques GetElementInterrogePourIntegration(Type typeElements, Type typeSource)
		{
			CElementAVariablesDynamiques elt = new CElementAVariablesDynamiques();
			if (typeElements != null)
			{
                elt.AddVariable(GetVariableElementForExpressions(elt, typeElements));
			}
			if (typeSource != null)
                elt.AddVariable(GetVariableSourceForExpression(elt, typeSource));
			return elt;
		}

		//--------------------------------------------------------------------
		public void FillElementInterrogePourIntegration(CElementAVariablesDynamiques eltAVariables, object elt, object source)
		{
			foreach (IVariableDynamique variable in eltAVariables.ListeVariables)
			{
				if (variable.Nom == c_nomChampElement)
					eltAVariables.SetValeurChamp(variable, elt);
				if (variable.Nom == c_nomChampSource)
					eltAVariables.SetValeurChamp(variable, source);
			}

		}

		//--------------------------------------------------------------------
		public void FillElementInterrogePourApplication(CElementAVariablesDynamiques eltAVariables, object source)
		{
			foreach (IVariableDynamique variable in eltAVariables.ListeVariables)
			{
				if (variable.Nom == c_nomChampSource)
					eltAVariables.SetValeurChamp(variable, source);
			}

		}


		//--------------------------------------------------------------------
		public CElementAVariablesDynamiques GetElementInterrogePourApplication ( Type typeSource )
		{
			CElementAVariablesDynamiques elt = new CElementAVariablesDynamiques();
			if ( typeSource != null )
                elt.AddVariable(GetVariableSourceForExpression(elt, typeSource));
			return elt;
		}

		//---------------------------------------------
		public CProfilElement[] TousLesProfilsARemplir
		{
			get
			{
				return new CProfilElement[] { this };
			}
		}


		//---------------------------------------------------
		public Type TypeElementsProfiles
		{
			get
			{
				return TypeElements;
			}
		}


		//---------------------------------------------------
		public bool IsInProfil(CObjetDonneeAIdNumerique element, CObjetDonneeAIdNumerique source)
		{
			if (element == null)
				return false;
            CFiltreData filtreGlobal = null;
			CResultAErreur result = GetIdsElementsForSource(source, null, ref filtreGlobal);
			if (result && result.Data is int[])
			{
				foreach (int nId in (int[])result.Data)
					if (element.Id == nId)
						return true;
			}
			return false;
		}


	}

}
