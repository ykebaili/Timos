using System;
using System.Collections;
using System.Text;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;

using timos.data.version;

using tiag.client;
using sc2i.expression;

namespace timos.data
{
    /// <summary>
    /// Les Contraintes permettent d'identifier un besoin, une exigence ou une obligation liée à un processus métier.<br/>
	/// Elles peuvent être levées par des <see cref="CRessourceMaterielle">Ressources</see>.
	/// Les Processus suivants utilisent les Contraintes / Ressources :<br/>
    /// </summary>
    /// <remarks>
    /// <list type="bullets">
    /// <item><term><see cref="CIntervention">Les Interventions</see></term></item>
    /// </list>
    /// </remarks>
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iContrainte)]
    [DynamicClass("Constraint")]
    [Table(CContrainte.c_nomTable, CContrainte.c_champId, true)]
    [ObjetServeurURI("CContrainteServeur")]
    [AutoExec("Autoexec")]
    [TiagClass(CContrainte.c_nomTiag, "Id", true)]
    public class CContrainte : CObjetDonneeAIdNumeriqueAuto,
                                    IObjetDonneeAChamps,
									ITypeRelationEntreePlanning_Ressource,
                                    IElementAInterfaceTiag,
									IElementATypeStructurant<CTypeContrainte>

    {
        public const string c_nomTiag = "Constraint";

        public const string c_nomTable = "CONSTRAINTE";
        public const string c_champId = "CONSTRAINT_ID";

        public const string c_champLibelle = "CONSTRAINTE_LABEL";
        public const string c_champInfoZoneProtege = "CONSTRAINTE_INFO";
        public const string c_champInfoRessource = "CONST_RESOURCE_INFO";
		public const string c_champIsInCheckList = "CONST_IS_IN_CHECKLIST";
       
        public const string c_roleChampCustom = "CONSTRAINTE";
 

        /// /////////////////////////////////////////////
        public CContrainte(CContexteDonnee contexte)
            : base(contexte)
        {
        }

        /// /////////////////////////////////////////////
        public CContrainte(DataRow row)
            : base(row)
        {
        }

        //-------------------------------------------------------------------
        public static void Autoexec()
        {
            CRoleChampCustom.RegisterRole(c_roleChampCustom, "Constraint", typeof(CContrainte), typeof(CTypeContrainte));
        }

        //-------------------------------------------------------------------
        public CRoleChampCustom RoleChampCustomAssocie
        {
            get
            {
                return CRoleChampCustom.GetRole(c_roleChampCustom);
            }
        }


        ////////////////////////////////////////////////
        /// <summary>
        /// Description
        /// </summary>
        public override string DescriptionElement
        {
            get
            {
                return I.T("Constraint @1 |246",Libelle);
            }
        }

		////////////////////////////////////////////////
        /// <summary>
        /// Libellé complet avec la liste des Attributs de la Contrainte entre parenthèses ( ).
        /// </summary>
		[DynamicField("Label with attributes")]
		[DescriptionField]
		public string LibelleAvecAttributs
		{
			get
			{
				string strLibelle = Libelle;
				string strAttribs=  "";
				foreach (CAttributContrainte attribut in AttributsListe)
				{
					strAttribs += attribut.AttributString + ",";
				}
				if (strAttribs.Length > 0)
					strAttribs = " (" + strAttribs.Substring(0, strAttribs.Length - 1) + ")";
				strLibelle += strAttribs;
				return strLibelle;
			}
		}

        ////////////////////////////////////////////////
        protected override void MyInitValeurDefaut()
        {
			IsInCheckListPropre = null;
        }

        /// /////////////////////////////////////////////
        public override string[] GetChampsTriParDefaut()
        {
            return new string[] { c_champLibelle };
        }

        ////////////////////////////////////////////////
        /// <summary>
        /// Le nom de la Contrainte
        /// </summary>
        [TableFieldProperty(c_champLibelle, 255)]
        [DynamicField("Label")]
        [RechercheRapide]
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


        ////////////////////////////////////////////////
        /// <summary>
        /// Informations complémentaires sur la Contrainte (commentaire)
        /// </summary>
        [TableFieldProperty(c_champInfoZoneProtege, 512)]
        [DynamicField("Information")]
        [TiagField("Information")]
        public string Informations
        {
            get
            {
                return (string)Row[c_champInfoZoneProtege];
            }
            set
            {
                Row[c_champInfoZoneProtege] = value;
            }
        }

        ////////////////////////////////////////////////
        /// <summary>
        /// Ce champ n'est pas utilisé actuellement
        /// </summary>
        [TableFieldProperty(c_champInfoRessource, 512)]
        //[DynamicField("Resource information")]
        public string InfoRessource
        {
            get
            {
                return (string)Row[c_champInfoRessource];
            }
            set
            {
                Row[c_champInfoRessource] = value;
            }
        }

        ////////////////////////////////////////////////
        /// <summary>
        /// Retourne la liste des Attributs de la Contrainte
        /// </summary>
        [RelationFille(typeof(CAttributContrainte), "Contrainte")]
        [DynamicChilds("Attributs list",typeof(CAttributContrainte))]
        public CListeObjetsDonnees AttributsListe
        {
            get
            {
                return GetDependancesListe(CAttributContrainte.c_nomTable, c_champId);
            }
        }

        //-------------------------------------------------------------------
        public void TiagSetConstraintTypeKeys(object[] lstCles)
        {
            CTypeContrainte typeCont= new CTypeContrainte(ContexteDonnee);
            if (typeCont.ReadIfExists(lstCles))
                TypeContrainte = typeCont;
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// Donne ou définit le Type de le Contrainte (obligatoire).
        /// </summary>
        [Relation(CTypeContrainte.c_nomTable, CTypeContrainte.c_champId, CTypeContrainte.c_champId, true, false)]
        [DynamicField("Constraint type")]
        [TiagRelation(typeof(CTypeContrainte), "TiagSetConstraintTypeKeys")]
        public CTypeContrainte TypeContrainte
        {
            get
            {
                return (CTypeContrainte)GetParent(CTypeContrainte.c_champId, typeof(CTypeContrainte));
            }
            set
            {
                SetParent(CTypeContrainte.c_champId, value);
            }
        }


        ////////////////////////////////////////////////
        /// <summary>
        /// Définit l'emplacement de la Contrainte. L'emplacement est l'entité à laquelle la Contrainte est liée. <br/>
        /// L'emplacement peut être une des entités suivantes: <br/>
        /// <list type="bullets">
        /// <item><see cref="CSite">Un Site</see></item>
        /// <item><see cref="CTypeSite">Un Type de Site</see></item>
        /// <item><see cref="CEquipement">Un Equipement</see></item>
        /// <item><see cref="CTypeIntervention">Un Type d'Intervention</see></item>
        /// <item><see cref="CProfilElement">Un Profil sur Element</see></item>
        /// </list>
        /// </summary>
        [DynamicField("Place")]
        public IPossesseurContrainte Emplacement
        {
            get
            {
                IPossesseurContrainte emplacement = Site;
                if (emplacement == null)
                    emplacement = TypeSite;
                if (emplacement == null)
                    emplacement = Equipement;
				if (emplacement == null)
					emplacement = TypeIntervention;
				if (emplacement == null)
					emplacement = ProfilElement;
                return emplacement;
            }
            set
            {
                if (value is CSite && value != null)
                    Site = (CSite)value;
                else
                    Site = null;

                if (value is CTypeSite && value != null)
                    TypeSite = (CTypeSite)value;
                else
                    TypeSite = null;

                if (value is CEquipement && value != null)
                    Equipement = (CEquipement)value;
                else
                    Equipement = null;
				
				if (value is CTypeIntervention && value != null)
					TypeIntervention = (CTypeIntervention)value;
				else
					TypeIntervention = null;

                if (value is CProfilElement && value != null)
                    ProfilElement = (CProfilElement)value;
                else
                    ProfilElement = null;
            }
        }


        //----------------------------------------------------------------------
        public void TiagSetSiteKeys(object[] lstCles)
        {
            CSite site = new CSite(ContexteDonnee);
            if (site.ReadIfExists(lstCles))
                Site = site;
        }

        //----------------------------------------------------------------------
        /// <summary>
        /// Donne ou définit le site lié à la Contrainte
        /// </summary>
        [Relation(CSite.c_nomTable, CSite.c_champId, CSite.c_champId, false, true)]
        [DynamicField("Site place")]
        [TiagRelation(typeof(CSite), "TiagSetSiteKeys")]
        public CSite Site
        {
            get
            {
                return (CSite)GetParent(CSite.c_champId, typeof(CSite));
            }
            set
            {
                SetParent(CSite.c_champId, value);
            }
        }


        //----------------------------------------------------------------------
        public void TiagSetSiteTypeKeys(object[] lstCles)
        {
            CTypeSite typeSite = new CTypeSite(ContexteDonnee);
            if (typeSite.ReadIfExists(lstCles))
                TypeSite = typeSite;
        }
        //----------------------------------------------------------------------
        /// <summary>
        /// Donne ou définit le type de site lié à la Contrainte.<br/>
        /// Si l'emplacment de la Contrainte est sur un Type de Site,<br/>
        /// alors toutes les instances de Site de ce Type hériteront de cette Contrainte.
        /// </summary>
        [Relation(
            CTypeSite.c_nomTable,
            CTypeSite.c_champId,
            CTypeSite.c_champId,
            false,
            true,
            false)]
        [DynamicField("Site type place")]
        [TiagRelation(typeof(CTypeSite), "TiagSetSiteTypeKeys")]
        public CTypeSite TypeSite
        {
            get
            {
                return (CTypeSite)GetParent(CTypeSite.c_champId, typeof(CTypeSite));
            }
            set
            {
                SetParent(CTypeSite.c_champId, value);
            }
        }


        //----------------------------------------------------------------------
        public void TiagSetEquipementKeys(object[] lstCles)
        {
            CEquipement equip = new CEquipement(ContexteDonnee);
            if (equip.ReadIfExists(lstCles))
                Equipement = equip;
        }
        //----------------------------------------------------------------------
        /// <summary>
        /// Donne ou définit l'Equipement lié à la Contrainte
        /// </summary>
        [Relation(CEquipement.c_nomTable, CEquipement.c_champId, CEquipement.c_champId, false, true)]
        [DynamicField("Equipment place")]
        [TiagRelation(typeof(CEquipement), "TiagSetEquipementKeys")]
        public CEquipement Equipement
        {
            get
            {
                return (CEquipement)GetParent(CEquipement.c_champId, typeof(CEquipement));
            }
            set
            {
                SetParent(CEquipement.c_champId, value);
            }
        }


       /*//----------------------------------------------------------------------
        public void TiagSetInterventionTypeKeys(object[] lstCles)
        {
            CTypeIntervention typeInter = new CTypeIntervention(ContexteDonnee);
            if (typeInter.ReadIfExists(lstCles))
                TypeIntervention = typeInter;
        }*/
        //-------------------------------------------------------------------
		/// <summary>
        /// Donne ou définit le type d'intervention lié à la Contrainte.<br/>
		/// Si la Contrainte est liée à un Type d'Intervention,<br/>
        /// alors toutes les Interventions de ce Type nécessiteront de lever cette Contrainte.
		/// </summary>
		[Relation(
			CTypeIntervention.c_nomTable,
			CTypeIntervention.c_champId,
			CTypeIntervention.c_champId,
			false,
			true,
			false)]
		[DynamicField("Intervention type")]
        //[TiagRelation(typeof(CTypeIntervention), "TiagSetInterventionTypeKeys")]
		public CTypeIntervention TypeIntervention
		{
			get
			{
				return (CTypeIntervention)GetParent(CTypeIntervention.c_champId, typeof(CTypeIntervention));
			}
			set
			{
				SetParent(CTypeIntervention.c_champId, value);
			}
		}



        //----------------------------------------------------------------------
        /*public void TiagSetElementProfileKeys(object[] lstCles)
        {
            CProfilElement profil = new CProfilElement(ContexteDonnee);
            if (profil.ReadIfExists(lstCles))
                ProfilElement = profil;
        }*/
        //-------------------------------------------------------------------
        /// <summary>
        /// Donne ou définit le ProfilElement lié à la Contrainte.<br/>
        /// </summary>
		[Relation(
			CProfilElement.c_nomTable,
		    CProfilElement.c_champId,
		    CProfilElement.c_champId,
			false,
			true,
			false)]
		[DynamicField("Element profile")]
        //[TiagRelation(typeof(CProfilElement), "TiagSetElementProfileKeys")]
		public CProfilElement ProfilElement
		{
			get
			{
				return (CProfilElement)GetParent(CProfilElement.c_champId, typeof(CProfilElement));
			}
			set
			{
				SetParent(CProfilElement.c_champId, value);
			}
		}

	



		//-------------------------------------------------------------------
        /// <summary>
        /// Renvoie la liste des relations avec les ressources
        /// </summary>
        [RelationFille(typeof(CRelationContrainte_Ressource), "Contrainte")]
        [DynamicChilds("Resources relations", typeof(CRelationContrainte_Ressource))]
        public CListeObjetsDonnees RelationRessourceListe
        {
            get
            {
                return GetDependancesListe(CRelationContrainte_Ressource.c_nomTable, c_champId);
            }
        }

        //--------------------------------------------------------------------
        /// <summary>
        /// Retourne la liste de toutes les ressources levant la contrainte
        /// </summary>
        [DynamicChilds("Raising resources", typeof(CRessourceMaterielle))]
        public CListeObjetsDonnees RessourcesLevant
        {
            get
            {
                return GetToutesLesRessourcesLevant(null);
            }
        }

		//------------------------------------------------------------------------------------------------
		public CResultAErreur GetIdsRessourcesLevant(CFiltreDataAvance filtreDeBaseAAppliquer)
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				int[] listeIds = ((IContrainteServeur)GetLoader()).GetIdsRessourcesLevant(this.Id, filtreDeBaseAAppliquer);
				result.Data = listeIds;
			}
			catch (Exception e)
			{
				result.EmpileErreur ( new CErreurException ( e ) );
			}
			return result;
		}


        //------------------------------------------------------------------------------------------------
        public CListeObjetsDonnees GetToutesLesRessourcesLevant(CFiltreDataAvance filtreDeBaseAAppliquer)
        {
            try
            {
                int[] listeIds = ((IContrainteServeur)GetLoader()).GetIdsRessourcesLevant(this.Id, filtreDeBaseAAppliquer);

                if (listeIds.Length == 0)
			    {
				    CListeObjetsDonnees liste = new CListeObjetsDonnees(ContexteDonnee, typeof(CRessourceMaterielle));
				    liste.Filtre = new CFiltreDataImpossible();
				    return liste;
			    }
			    string strIds = "";
			    foreach (int nId in listeIds)
				    strIds += nId + ",";
			    strIds = strIds.Substring(0, strIds.Length - 1);
			    CFiltreData filtre = new CFiltreData ( CRessourceMaterielle.c_champId+" in ("+strIds+")");
			    CListeObjetsDonnees lst = new CListeObjetsDonnees(ContexteDonnee, typeof(CRessourceMaterielle), filtre);
			    return lst;
            }
            catch
            {
                return new CListeObjetsDonnees(ContexteDonnee, typeof(CRessourceMaterielle), new CFiltreDataImpossible());
            }
        }

            
        //-----------------------------------------------------------------------------------
        /// <summary>
        /// Indique si la ressource passée en paramètre lève la contrainte
        /// </summary>
        /// <param name="ressource">La ressource à tester</param>
        /// <returns>TRUE si oui, FALSE si non</returns>
        [DynamicMethod("Is the given resource rasing this constraint", "The given resource")]
        public bool IsRessourceLevant(CRessourceMaterielle ressource)
        {
            if (ressource == null)
                return false;

            // Est-ce que la ressource lève la contrainte de façon explicite (relation directe)?
            foreach (CRelationContrainte_Ressource rel in this.RelationRessourceListe)
            {
                if (rel.Ressource == ressource)
                    return true;
            }

			//Est-ce que le type de la ressource lève le type de la contrainte ?
			bool bTypeRessourceOk = false;
			string strRessource = ressource.Libelle;
			string strContrainte = Libelle;
			foreach (CRelationTypeContrainte_TypeRessource rel in TypeContrainte.RelationsTypesRessourcesListe)
			{
				if (rel.TypeRessource.Equals(ressource.TypeRessource))
				{
					bTypeRessourceOk = true;
					break;
				}
			}
			if (!bTypeRessourceOk)
				return false;

			//Vérifie maintenant les attributs
			Hashtable tableAttribs = new Hashtable();
			foreach (CAttributContrainte attribut in AttributsListe)
			{
				if ( attribut.AttributTypeContrainte != null )
					tableAttribs[attribut.AttributTypeContrainte.Id] = false;
				else
					tableAttribs[attribut.Libelle] = true;
			}

			bool bTousNecessaires = TypeContrainte.OptionTousAttributsRessourceLevant;

			foreach ( CAttributRessource attribut in ressource.AttributsListe )
			{
				if ( attribut.AttributTypeContrainte != null )
				{
					if ( tableAttribs.Contains ( attribut.AttributTypeContrainte.Id ) )
					{
						tableAttribs[attribut.AttributTypeContrainte.Id] = true;
						if ( !bTousNecessaires )
							return true;
					}
				}
				else
					if ( tableAttribs.Contains ( attribut.Libelle ))
					{
						tableAttribs[attribut.Libelle] = true;
						if ( !bTousNecessaires )
							return true;
					}
			}
			foreach ( bool bTrouve in tableAttribs.Values )
			{
				if ( !bTrouve )
					return false;
			}
			return true;
        }

        //------------------------------------------------------------------------------------
        public CFiltreDataAvance GetFiltreForRechercheRessourcesSurAttributs()
        {
			//Crée le filtre sur les types de ressource qui lèvent le type de contrainte
			CFiltreDataAvance filtreFinal = new CFiltreDataAvance(
				CRessourceMaterielle.c_nomTable,
				CTypeRessource.c_nomTable+"."+
				CRelationTypeContrainte_TypeRessource.c_nomTable+"."+
				CTypeContrainte.c_champId + "=@1",
				TypeContrainte.Id);

			CFiltreData filtreAttributs = GetFiltreSurAttributsRessource();
			if ( filtreAttributs != null && !(filtreAttributs is CFiltreDataAvance))
			{
				filtreAttributs = CFiltreDataAvance.ConvertFiltreToFiltreAvance(CAttributRessource.c_nomTable, filtreAttributs);
			}
			if (filtreAttributs != null)
			{
				CFiltreDataAvance filtreAv = (CFiltreDataAvance)filtreAttributs;
				filtreAv.ChangeTableDeBase(CRessourceMaterielle.c_nomTable, CAttributRessource.c_nomTable);
			}

			filtreFinal = (CFiltreDataAvance)CFiltreData.GetAndFiltre(filtreAttributs, filtreFinal);

			return filtreFinal; 
		}

		public CFiltreData GetFiltreSurAttributsRessource()
		{
			string strFiltreAttributsLibre = "";
			string strFiltreAttributsListe = "";
			CFiltreData filtreAttributs = null;
			if (this.AttributsListe.Count == 0)
			{
				if (TypeContrainte.OptionToutesRessourcesDeTypeLevant)
					return null;
				else
					return new CFiltreDataImpossible();
			}
			foreach (CAttributContrainte att in this.AttributsListe)
			{
				if (att.AttributTypeContrainte == null && att.Libelle != "")
					strFiltreAttributsLibre += ("'" + att.Libelle + "'" + ",");
				else
					strFiltreAttributsListe += (att.AttributTypeContrainte.Id + ",");
			}
			if (strFiltreAttributsLibre.Length > 0)
				strFiltreAttributsLibre =
					 strFiltreAttributsLibre.Substring(0, strFiltreAttributsLibre.Length - 1);
			if (strFiltreAttributsListe.Length > 0)
				strFiltreAttributsListe =
					strFiltreAttributsListe.Substring(0, strFiltreAttributsListe.Length - 1);

			if (strFiltreAttributsLibre.Length > 0 ||
				strFiltreAttributsListe.Length > 0)
			{
				filtreAttributs = new CFiltreData();
				if (strFiltreAttributsLibre.Length > 0)
					filtreAttributs.Filtre += CAttributRessource.c_champLibelle + " in (" + strFiltreAttributsLibre + ")";
				if (strFiltreAttributsListe.Length > 0)
				{
					if (filtreAttributs.Filtre != "")
						filtreAttributs.Filtre += " or ";
					filtreAttributs.Filtre +=CAttributTypeContrainte.c_champId + " in (" + strFiltreAttributsListe + ")";
						
					//filtreAttributs.Parametres.Add(this.Id);
				}
			}
			return filtreAttributs;
		}


		/// <summary>
		/// Indique que la contrainte apparaît dans la check list des interventions<br/> 
		/// et n'a pas besoin d'être levée par une ressource.<br/>
		/// Cette valeur est la valeur propre de la contrainte.<br/>
        /// Si elle est nulle, la valeur du type de contrainte est appliquée<br/>
        /// (voir IsInCheckListApplique)
		/// </summary>
		[TableFieldProperty ( CContrainte.c_champIsInCheckList, NullAutorise = true )]
		[DynamicField("On check list (own)")]
        [TiagField("On check list")]
		public bool? IsInCheckListPropre
		{
			get
			{
				return (bool?)Row[c_champIsInCheckList,true];
			}
			set
			{
				Row[c_champIsInCheckList,true] = value;
			}
		}

        //-----------------------------------------------------
        public bool AfficherManquantDansPlanning
        {
            get
            {
                return true;
            }
        }

		/// <summary>
		/// Indique que la contrainte apparaît dans la check list des interventions<br/> 
		/// et n'a pas besoin d'être levée par une ressource.<br/>
		/// Cette valeur est la valeur appliquée à la contrainte.<br/>
        /// Si IsInCheckListPropre est null, c'est la valeur du type de contrainte qui est appliquée.
		/// </summary>
        [DynamicField("On check list (applied)")]
        public bool IsInCheckListApplique
		{
			get
			{
				bool bCheck = false;
				if (IsInCheckListPropre == null)
				{
					if (TypeContrainte != null)
						bCheck = TypeContrainte.IsInCheckList;
				}
				else
					bCheck = (bool)IsInCheckListPropre;
				return bCheck;
			}
		}

        //-------------------------------- IMPLEMENTATION DES INTERFACES --------------------------------------

        #region IObjetDonneeAChamps Membres

        public CRelationElementAChamp_ChampCustom GetNewRelationToChamp()
        {
            return new CRelationContrainte_ChampCustom(ContexteDonnee);
        }

        public string GetNomTableRelationToChamps()
        {
            return CRelationContrainte_ChampCustom.c_nomTable;
        }

        public CListeObjetsDonnees GetRelationsToChamps(int nIdChamp)
        {
            CListeObjetsDonnees liste = RelationsChampsCustom;
            liste.InterditLectureInDB = true;
            liste.Filtre = new CFiltreData(CChampCustom.c_champId + " = @1", nIdChamp);
            return liste;
        }

        #endregion

        #region IElementAChamps Membres

        public IDefinisseurChampCustom[] DefinisseursDeChamps
        {
            get
            {
                return new IDefinisseurChampCustom[] { TypeContrainte };
            }
        }

        public CChampCustom[] GetChampsHorsFormulaire()
        {
            if (TypeContrainte == null)
                return new CChampCustom[0];

            ArrayList lst = new ArrayList();
            foreach (CRelationTypeContrainte_ChampCustom rel in TypeContrainte.RelationsChampsCustomDefinis)
                lst.Add(rel.ChampCustom);

            foreach (CRelationTypeContrainte_Formulaire rel1 in TypeContrainte.RelationsFormulaires)
                foreach (CRelationFormulaireChampCustom rel2 in rel1.Formulaire.RelationsChamps)
                    lst.Remove(rel2.Champ);

            
            return (CChampCustom[])lst.ToArray(typeof(CChampCustom));
        }

        public CFormulaire[] GetFormulaires()
        {
            return CUtilElementAChamps.GetFormulaires(this);
        }

        /// <summary>
        /// Retourne la liste des relations de la contrainte avec les champs personnalisés
        /// </summary>
        [RelationFille(typeof(CRelationContrainte_ChampCustom), "ElementAChamps")]
        [DynamicChilds("Custom fields relations", typeof(CRelationContrainte_ChampCustom))]
        public CListeObjetsDonnees RelationsChampsCustom
        {
            get
            {
                return GetDependancesListe(CRelationContrainte_ChampCustom.c_nomTable, c_champId);
            }
        }

        #endregion

        #region IElementAVariables Membres

        //----------------------------------------------------------------------------
        public object GetValeurChamp(int nIdChamp)
        {
            return CUtilElementAChamps.GetValeurChamp(this, nIdChamp);
        }

        //-----------------------------------------------------------------------------
        public object GetValeurChamp(int nIdChamp, DataRowVersion version)
        {
            return CUtilElementAChamps.GetValeurChamp(this, nIdChamp, version);
        }

        public object GetValeurChamp(string strIdVariable)
        {
            return CUtilElementAChamps.GetValeurChamp(this, strIdVariable);
        }

        //-----------------------------------------------------------------------------
        public object GetValeurChamp(IVariableDynamique variable)
        {
            if (variable == null)
                return null;
            return GetValeurChamp(variable.IdVariable);
        }

        //---------------------------------------------
        public CResultAErreur SetValeurChamp(string strIdVariable, object valeur)
        {
            return CUtilElementAChamps.SetValeurChamp(this, strIdVariable, valeur);
        }

        //---------------------------------------------
        public CResultAErreur SetValeurChamp(IVariableDynamique variable, object valeur)
        {
            if (variable == null)
                return CResultAErreur.True;
            return SetValeurChamp(variable.IdVariable, valeur);
        }

        //-------------------------------------------------------------------
        public CResultAErreur SetValeurChamp(int nIdChamp, object valeur)
        {
            return CUtilElementAChamps.SetValeurChamp(this, nIdChamp, valeur);
        }

        #endregion

		#region ITypeRelationEntreePlanning_Ressource Membres

		public Type GetTypeRessource()
		{
			return typeof(CRessourceMaterielle);
		}

		public CProfilElement[] TousLesProfilsARemplir
		{
			get
			{
				return new CProfilElement[0];
			}
		}

		public Type TypeElementsProfiles
		{
			get
			{
				return typeof(CRessourceMaterielle);
			}
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


		#region IElementATypeStructurant<CTypeContrainte> Membres

		public CTypeContrainte ElementStructurant
		{
			get{ return TypeContrainte; }
		}
		public int IdTypeStructurant
		{
			get
			{
				return (int)Row[CTypeContrainte.c_champId];
			}
		}
		#endregion
	}

	public interface IContrainteServeur
	{
		int[] GetIdsRessourcesLevant(int nIdContrainte, CFiltreDataAvance filtreDeBaseAAppliquer);

	}
}
