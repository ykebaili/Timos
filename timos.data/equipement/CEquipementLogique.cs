using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using sc2i.data;
using sc2i.common;
using sc2i.process;
using sc2i.multitiers.client;
using sc2i.data.dynamic;
using sc2i.common.planification;

using timos.securite;
using timos.acteurs;
using timos.data.version;

using tiag.client;
using Lys.Licence.Types;
using Lys.Applications.Timos.Smt;
using System.Data;
using timos.data.supervision;
using timos.data.snmp;


namespace timos.data
{
	/// <summary>
	/// Mod�lise tout mat�riel logique faisant partie du r�f�rentiel r�seau g�r� dans l'application TIMOS.
	/// </summary>
    /// <remarks>
    /// Un �quipement logique repr�sente une fonction par exemple une installation VSAT
    /// dans son ensemble ou un atelier d'�nergie, etc.
    /// A un �quipement logique, il est possible d'associer un ou plusieurs <see cref="CEquipement">�quipements</see> physiques.
    /// </remarks>
	[DynamicClass("Logical Equipment")]
	[ObjetServeurURI("CEquipementLogiqueServeur")]
	[Table(CEquipementLogique.c_nomTable, CEquipementLogique.c_champId, true)]
	[AutoExec("Autoexec")]
    [LicenceCount(CConfigTypesTimos.c_appType_ElementDeReferentiel)]
	[RechercheRapide(CTypeEquipement.c_nomTable + "." + CTypeEquipement.c_champLibelle)]
	[RechercheRapide(CTypeEquipement.c_nomTable + "." + CTypeEquipement.c_champCode)]
	[TiagClass(CEquipementLogique.c_nomTiag, "Id", true)]
	public partial class CEquipementLogique : CElementAChamp,
							IElementAEvenementsDefinis,
							IObjetDonneeAutoReference,
							IElementAEO,
							IElementAInterfaceTiag,
							IElementATypeStructurant<CTypeEquipement>,
                            IElementASymbolePourDessin,
                            IElementALiensReseau,
                            IElementDeSchemaReseau,
                            IElementSupervise

	{
		#region D�claration des constantes
		public const string c_roleChampCustom = "LOGIC_EQUIPMENT";
		public const string c_nomTiag = "Logical equipment";

		public const string c_nomTable = "LOGIC_EQUIPMENTS";
		public const string c_champId = "EQTLGC_ID";
		public const string c_champLibelle = "EQTLGC_LABEL";
		public const string c_champIdEquipementLogiqueContenant = "EQTLGC_ID_CONTAINER_EPQT";
		#endregion

		//-------------------------------------------------------------------
		public static void Autoexec()
		{
			CRoleChampCustom.RegisterRole(c_roleChampCustom, "Logical Equipment", typeof(CEquipementLogique), typeof(CTypeEquipement));
		}

		//-------------------------------------------------------------------
		public CEquipementLogique(CContexteDonnee ctx)
			: base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CEquipementLogique(System.Data.DataRow row)
			: base(row)
		{
		}

        //-------------------------------------------------------------------
        public override CRoleChampCustom RoleChampCustomAssocie
        {
            get { return CRoleChampCustom.GetRole(c_roleChampCustom); }
        }


		//-------------------------------------------------------------------
		protected override void MyInitValeurDefaut()
		{
		}

		//-------------------------------------------------------------------
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] { c_champLibelle };
		}

		//-------------------------------------------------------------------
		public override string ToString()
		{
			return Libelle;
		}

		//-------------------------------------------------------------------
		public override string DescriptionElement
		{
			get { return I.T("The logical equipment @1|20023", Libelle); }
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Libell� de l'�quipement<br/>
		/// Permet de nommer l'<B>�quipement</B>
		/// </summary>
		[DescriptionField]
		[DynamicField("Label")]
		[TiagField("Label")]
		[TableFieldProperty(CEquipementLogique.c_champLibelle, 255)]
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

		public object[] TiagKeys
		{
			get { return new object[] { Id }; }
		}

		public string TiagType
		{
			get { return c_nomTiag; }
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Utilis� par TIAG pour affecter le type de site par ses cl�s
		/// </summary>
		/// <param name="lstCles"></param>
		public void TiagSetEquipmentTypeKeys(object[] lstCles)
		{
			CTypeEquipement typeEquipementLogique = new CTypeEquipement(ContexteDonnee);
			if (typeEquipementLogique.ReadIfExists(lstCles))
				TypeEquipement = typeEquipementLogique;
		}

		//-------------------------------------------------------------------
		/// <summary>
        /// <see cref="CTypeEquipement">Type de l'equipement</see>
		/// </summary>
		[Relation(
			CTypeEquipement.c_nomTable,
			CTypeEquipement.c_champId,
			CTypeEquipement.c_champId,
			true,
			false,
			true)]
		[DynamicField("Logical Equipment type")]
		[TiagRelation(typeof(CTypeEquipement), CAssociationTiag.c_methodeUseDelegate)]
		public CTypeEquipement TypeEquipement
		{
			get 
            {
                return (CTypeEquipement)GetParent(CTypeEquipement.c_champId, typeof(CTypeEquipement)); 
            }
			set
            {
                SetParent(CTypeEquipement.c_champId, value); 
            }
		}

		//----------------------------------------------------------------------------------
		/// <summary>
		/// Utilis� par TIAG pour affecter le type de site par ses cl�s
		/// </summary>
		/// <param name="lstCles"></param>
		public void TiagSetParentLogicalEquipmentKeys(object[] lstCles)
		{
			CEquipementLogique equipement = new CEquipementLogique(ContexteDonnee);
			if (equipement.ReadIfExists(lstCles))
			{
				EquipementLogiqueContenant = equipement;
				Site = equipement.Site;
			}
		}

		//-----------------------------------------------------------------------------------
		/// <summary>
		/// Equipement logique contenant cet �quipement
		/// </summary>
		[Relation(
			CEquipementLogique.c_nomTable,
			CEquipementLogique.c_champId,
			CEquipementLogique.c_champIdEquipementLogiqueContenant,
			false,
			false,
			true)]
		[DynamicField("Container logical equipment")]
		[TiagRelation(typeof(CEquipementLogique), "TiagSetParentLogicalEquipmentKeys")]
		public CEquipementLogique EquipementLogiqueContenant
		{
			get
			{
				return (CEquipementLogique)GetParent(c_champIdEquipementLogiqueContenant, typeof(CEquipementLogique));
			}
			set
			{
				SetParent(c_champIdEquipementLogiqueContenant, value);
			}
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Liste des �quipements logiques contenus
		/// </summary>
		[RelationFille(typeof(CEquipementLogique), "EquipementLogiqueContenant")]
		[DynamicChilds("Contained logical equipements", typeof(CEquipementLogique))]
		public CListeObjetsDonnees EquipementsLogiquesContenus
		{
			get
			{
				return GetDependancesListe(c_nomTable, c_champIdEquipementLogiqueContenant);
			}
        }

        #region champs custom
        //-------------------------------------------------------------------
		public override IDefinisseurChampCustom[] DefinisseursDeChamps
		{
			get
			{
				List<IDefinisseurChampCustom> lst = new List<IDefinisseurChampCustom>();
				if (TypeEquipement != null)
					foreach (CTypeEquipement typeEq in TypeEquipement.TousLesTypesParentsEtThis)
						lst.Add(typeEq.GetDefinisseurPourEquipementLogique());
				return lst.ToArray();
			}
		}

		//-------------------------------------------------------------------
		public override CRelationElementAChamp_ChampCustom GetNewRelationToChamp()
		{
			return new CRelationEquipementLogique_ChampCustom(ContexteDonnee);
		}

		//-------------------------------------------------------------------
        /// <summary>
        /// Liste des <see cref="CRelationEquipementLogique_ChampCustom">relations vers les Champs personnalis�s</see>
        /// </summary>
		[RelationFille(typeof(CRelationEquipementLogique_ChampCustom), "ElementAChamps")]
		[DynamicChilds("Custom fields relations", typeof(CRelationEquipementLogique_ChampCustom))]
		public override CListeObjetsDonnees RelationsChampsCustom
		{
			get
			{
				return GetDependancesListe(CRelationEquipementLogique_ChampCustom.c_nomTable, GetChampId());
			}
		}
        # endregion


        //-------------------------------------------------------------------
        /// <summary>
        /// Rafra�chit les codes des <see cref="CEntiteOrganisationnelle">entit�s organisationnelles</see> de cet �quipement logique
        /// </summary>
        [DynamicMethod("Refresh Organizational entities codes for this element")]
        public void RefreshCodesEOS()
        {
            CUtilElementAEO.UpdateEOs(this);
        }
		
		//-------------------------------------------------------------------
		/// <summary>
		/// Utilis� par TIAG pour affecter le site par ses cl�s
		/// </summary>
		/// <param name="lstCles"></param>
		public void TiagSetSitePlaceKeys(object[] lstCles)
		{
			CSite site = new CSite(ContexteDonnee);
			if (site.ReadIfExists(lstCles))
				Site = site;
		}

		//////////////////////////////////////////////////////
		/// <summary>
		/// Site o� se trouve l'�quipement logique.
        /// Contrairement � un <see cref="CEquipement">�quipement</see> physique, un �quipement logique
        /// ne peut se trouver que dans un site (jamais dans un stock ni sur un acteur)
		/// </summary>
		[Relation(CSite.c_nomTable,
			CSite.c_champId,
			CSite.c_champId,
			true,
			false,
			true)]
		[DynamicField("Site")]
		[TiagRelation(typeof(CSite), "TiagSetSitePlaceKeys")]
		public CSite Site
		{
			get
            {
                return (CSite)GetParent(CSite.c_champId, typeof(CSite)); 
            }
			set
			{
				SetParent(CSite.c_champId, value);
				foreach (CEquipementLogique eqpt in EquipementsLogiquesContenus)
					eqpt.Site = value;
			}
		}








		#region Membres de IElementAEvenementsDefinis

		/// ///////////////////////////////////////////////////
		public IDefinisseurEvenements[] Definisseurs
		{
			get
			{
				return new IDefinisseurEvenements[] { TypeEquipement };
			}
		}

		/// ///////////////////////////////////////////////////
		public bool IsDefiniPar(IDefinisseurEvenements definisseur)
		{
			CTypeEquipement typeEqptLogique = definisseur as CTypeEquipement;
			if (typeEqptLogique != null)
				return typeEqptLogique == TypeEquipement;
			return false;
		}

		/// ///////////////////////////////////////////////////
		#endregion

		#region IObjetDonneeAutoReference Membres

		//-------------------------------------------------------------------
		public string ChampParent
		{
			get { return c_champIdEquipementLogiqueContenant; }
		}

		//-------------------------------------------------------------------
		public string ProprieteListeFils
		{
			get { return "EquipementsLogiquesContenue"; }
		}

		#endregion

		//-------------------------------------------------------------------
        /// <summary>
        /// Codes complets (Full_system_code) de toutes les <see cref="CEntiteOrganisationnelle">entit�s organisationnelles</see> auxquels est affect� l'�quipement logique<br/>
        /// </summary>
        /// <remarks>
        /// Ces codes sont pr�sent�s sous la forme d'une cha�ne de caract�res<br/>
        /// Chaque code est encadr� par deux caract�res ~ (exemple : ~01051B~0201~061A0304~)
        /// </remarks>
		[TableFieldProperty(CUtilElementAEO.c_champEO, 500)]
		[DynamicField("Organisational entities codes")]
		public string CodesEntitesOrganisationnelles
		{
			get { return (string)Row[CUtilElementAEO.c_champEO]; }
			set { Row[CUtilElementAEO.c_champEO] = value; }
		}

		//--------------------------------------------
		public IElementAEO[] DonnateursEO
		{
			get { return new IElementAEO[] { Site, TypeEquipement, EquipementLogiqueContenant }; }
		}

		//--------------------------------------------
		public IElementAEO[] HeritiersEO
		{
			get { return (IElementAEO[])EquipementsLogiquesContenus.ToArray(typeof(IElementAEO)); }
		}

		//--------------------------------------------
		public void CompleteRestriction(CRestrictionUtilisateurSurType restriction)
		{
			CUtilElementAEO.CompleteRestriction(this, restriction);
		}
		//-----------------------------------------------------------------
		public CListeObjetsDonnees EntiteOrganisationnellesDirectementLiees
		{
			get
			{
				return CRelationElement_EO.GetEntitesOrganisationnellesDirectementLiees(this);
			}
		}

		//-----------------------------------------------------------------
        /// <summary>
        /// Affecte � l'�quipement logique une nouvelle <see cref="CEntiteOrganisationnelle">entit� organisationnelle</see>
        /// </summary>
        /// <param name="nIdEO">Identifiant (Id) de l'EO � affecter</param>
        /// <returns><see cref="sc2i.common.CResultAErreur">R�sultat � erreur</see></returns>
		[DynamicMethod(
			"Assign a new Organizational Entity to the Element",
			"The Organizational Entity Identifier")]
		public CResultAErreur AjouterEO(int nIdEO)
		{
			return CUtilElementAEO.AjouterEO(this, nIdEO);
		}

		//-----------------------------------------------------------------
        /// <summary>
        /// Ote de l'�quipement logique<see cref="CEntiteOrganisationnelle">l'entit� organisationnelle</see> pr�cis�e
        /// </summary>
        /// <param name="nIdEO">Identifiant (Id) de l'EO � �ter</param>
        /// <returns><see cref="sc2i.common.CResultAErreur">R�sultat � erreur</see></returns>
		[DynamicMethod(
			"Remove an Organizational Entity from the Element",
			"The Organizational Entity Identifier")]
		public CResultAErreur SupprimerEO(int nIdEO)
		{
			return CUtilElementAEO.SupprimerEO(this, nIdEO);
		}

        //----------------------------------------------------------------
        [DynamicMethod(
            "Set all Organizational Entities to the Element",
            "An array of Organizational Entity IDs")]
        public CResultAErreur SetAllOrganizationalEntities(int[] nIdsOE)
        {
            return CUtilElementAEO.SetAllOrganizationalEntities(this, nIdsOE);
        }

		//---------------------------------------------
		/// <summary>
        /// Liste des <see cref="CEquipement">�quipements</see> physiques associ�s
		/// </summary>
		[RelationFille(typeof(CEquipement), "EquipementLogique")]
		[DynamicChilds("Associated equipments", typeof(CEquipement))]
		public CListeObjetsDonnees Equipements
		{
			get
			{
				return GetDependancesListe(CEquipement.c_nomTable, c_champId);
			}
		}


        /// <summary>
        /// Liste des <see cref="CElementDeSchemaReseau">�l�ments de sch�mas r�seaux</see> dans lesquels se trouve cet �quipement logique
        /// </summary>
        [RelationFille(typeof(CElementDeSchemaReseau), "EquipementLogique")]
        [DynamicChilds("Associated network elements", typeof(CElementDeSchemaReseau))]
        public CListeObjetsDonnees ElementsDeSchemas
        {
            get
            {
                return GetDependancesListe(CElementDeSchemaReseau.c_nomTable, c_champId);
            }
        }


		#region IElementATypeStructurant<CTypeEquipement> Membres

		public CTypeEquipement ElementStructurant
		{
			get { return TypeEquipement; }
		}
		public int IdTypeStructurant
		{
			get
			{
				return (int)Row[CTypeEquipement.c_champId];
			}
		}
		#endregion


		public override CResultAErreur VerifieDonnees(bool bAuMomentDeLaSauvegarde)
		{
			CResultAErreur result =  base.VerifieDonnees(bAuMomentDeLaSauvegarde);
			if (!result)
				return result;
			foreach (CEquipement equipement in Equipements)
			{
				if (equipement.Emplacement == null)
					equipement.SetEmplacementSansHistorique ( Site, null );
				result += equipement.VerifieDonnees(bAuMomentDeLaSauvegarde);
			}
			return result;
		}

        //----------------------------------------------------
        public C2iSymbole SymboleADessiner
        {
            get
            {
                C2iSymbole symbole = null;
                if (TypeEquipement != null)
                    symbole = TypeEquipement.SymboleDefiniADessiner;
                if (symbole == null)
                    symbole = CSymbole.GetSymboleParDefaut(typeof(CEquipementLogique), ContexteDonnee);
                if (symbole != null)
                {
                    symbole = symbole.GetCloneSymbole();
                    symbole.ElementASymbole = this;
                }
                return symbole;
            }
        }

        public C2iObjetDeSchema GetObjetDeSchema(CElementDeSchemaReseau elementDeSchema)
        {
            C2iObjetDeSchema objet = new C2iObjetDeSchema();
            objet.ElementDeSchema = elementDeSchema;
            return objet;
        }


        /// <summary>
        /// Nombre utilis� pour le comptage des licences dans la base de donn�es
        /// </summary>
        /// <returns></returns>
        public static int GetNbUsedInDbForLicenceCount()
        {
            C2iRequeteAvancee requete = new C2iRequeteAvancee();
            requete.TableInterrogee = c_nomTable;
            C2iChampDeRequete champ = new C2iChampDeRequete(c_champId,
                new CSourceDeChampDeRequete(c_champId),
                typeof(int),
                OperationsAgregation.DistinctNumber,
                false);
            requete.ListeChamps.Add(champ);
            requete.FiltreAAppliquer = new CFiltreDataAvance(c_nomTable,
                "HasNo(" + CSc2iDataConst.c_champIdVersion + ") and hasno(" +
                CEquipement.c_nomTable + "." + CEquipement.c_champId + ")");
            requete.FiltreAAppliquer.IgnorerVersionDeContexte = true;
            requete.FiltreAAppliquer.IntegrerLesElementsSupprimes = false;
            CResultAErreur result = requete.ExecuteRequete(0);
            if (!result)
                throw new Exception(result.Erreur.ToString());
            DataTable table = result.Data as DataTable;
            return (int)table.Rows[0][0];
        }



        //---------------------------------------------
        /// <summary>
        /// Liste des <see cref="CEntiteSnmp">entit�s SNMP</see> qui correspondent � cet �quipement logique
        /// </summary>
        [RelationFille(typeof(CEntiteSnmp), "EquipementLogiqueSupervise")]
        [DynamicChilds("Snmp entities", typeof(CEntiteSnmp))]
        public CListeObjetsDonnees EntitesSnmp
        {
            get
            {
                return GetDependancesListe(CEntiteSnmp.c_nomTable, c_champId);
            }
        }



        #region IElementALien Membres

        /// <summary>
        /// Tableau de <see cref="CLienReseau">liens r�seau</see> dans lesquels cet �quipement logique figure
        /// </summary>
        [DynamicChilds("Links", typeof(CLienReseau))]
        public CLienReseau[] Liens
        {
            get
            {
                List<CLienReseau> lst = new List<CLienReseau>();
                foreach (CLienReseau lien in LiensEnTantQuelement1)
                    lst.Add(lien);
                foreach (CLienReseau lien in LiensEnTantQuelement2)
                    lst.Add(lien);
                return lst.ToArray();
            }
        }


        /// <summary>
        /// Liste de <see cref="CLienReseau">liens r�seau</see> dans lequel cet �quipement logique figure
        /// </summary>
        [DynamicChilds("Link list", typeof(CLienReseau))]
        public CListeObjetsDonnees ListeLiens
        {
            get
            {
                CListeObjetsDonnees liste = new CListeObjetsDonnees(ContexteDonnee);
                string strIds = ("");
                CFiltreData filtre;
                foreach (CLienReseau lien1 in LiensEnTantQuelement1)
                {
                    strIds += lien1.Id.ToString();
                    strIds += ",";
                }
                foreach (CLienReseau lien2 in LiensEnTantQuelement2)
                {
                    strIds += lien2.Id.ToString();
                    strIds += ",";
                }
                if (strIds != "")
                {
                    strIds = strIds.Substring(0, strIds.Length - 1);
                    filtre = new CFiltreData(CLienReseau.c_champId + " IN (" + strIds + ")");

                }
                else
                    filtre = new CFiltreDataImpossible();

                liste = new CListeObjetsDonnees(ContexteDonnee, typeof(CLienReseau), filtre);
                return liste;
            }

        }

        /// <summary>
        /// Liste de <see cref="CLienReseau">liens r�seau</see> dans lesquels cet �quipement logique<br/>
        /// intervient en tant qu'�quipement 1
        /// </summary>
        /// <remarks>Un lien r�seau entre �quipements logiques est entre deux �quipements</remarks>
        [RelationFille(typeof(CLienReseau), "Equipement1")]
        [DynamicChilds("Link as equipment 1", typeof(CLienReseau))]
        public CListeObjetsDonnees LiensEnTantQuelement1
        {
            get
            {
                return GetDependancesListe(CLienReseau.c_nomTable, CLienReseau.c_champEquipement1);
            }
        }

        /// <summary>
        /// Liste de <see cref="CLienReseau">liens r�seau</see> dans lesquels cet �quipement logique<br/>
        /// intervient en tant qu'�quipement 2
        /// </summary>
        /// <remarks>Un lien r�seau entre �quipements logiques est entre deux �quipements</remarks>
        [RelationFille(typeof(CLienReseau), "Equipement2")]
        [DynamicChilds("Link as equipment 2", typeof(CLienReseau))]
        public CListeObjetsDonnees LiensEnTantQuelement2
        {
            get
            {
                return GetDependancesListe(CLienReseau.c_nomTable, CLienReseau.c_champEquipement2);
            }
        }

        /// <summary>
        /// Liste de <see cref="CLienReseau">liens r�seau</see> entrant vis � vis de cet �quipement logique<br/>
        /// </summary>
        [DynamicChilds("Ingoing links", typeof(CLienReseau))]
        public CLienReseau[] LiensEntrants
        {
            get
            {
                List<CLienReseau> lst = new List<CLienReseau>();
                foreach (CLienReseau lien in LiensEnTantQuelement1)
                {
                    if (lien.Direction.Code == EDirectionLienReseau.Bidirectionnel ||
                        lien.Direction.Code == EDirectionLienReseau.DeuxVersUn)
                        lst.Add(lien);
                }
                foreach (CLienReseau lien in LiensEnTantQuelement2)
                {
                    if (lien.Direction.Code == EDirectionLienReseau.Bidirectionnel ||
                        lien.Direction.Code == EDirectionLienReseau.UnVersDeux)
                        lst.Add(lien);
                }
                return lst.ToArray();
            }

        }

        /// <summary>
        /// Liste de <see cref="CLienReseau">liens r�seau</see> sortant vis � vis de cet �quipement logique<br/>
        /// </summary>
        [DynamicChilds("Outgoing links", typeof(CLienReseau))]
        public CLienReseau[] LiensSortants
        {
            get
            {
                List<CLienReseau> lst = new List<CLienReseau>();
                foreach (CLienReseau lien in LiensEnTantQuelement1)
                {
                    if (lien.Direction.Code == EDirectionLienReseau.Bidirectionnel ||
                        lien.Direction.Code == EDirectionLienReseau.UnVersDeux)
                        lst.Add(lien);
                }
                foreach (CLienReseau lien in LiensEnTantQuelement2)
                {
                    if (lien.Direction.Code == EDirectionLienReseau.Bidirectionnel ||
                        lien.Direction.Code == EDirectionLienReseau.DeuxVersUn)
                        lst.Add(lien);
                }
                return lst.ToArray();
            }
        }

        /// <summary>
        /// Liste des <see cref="IComplementElementALiensReseau">compl�ments de lien r�seau</see> qui peuvent �tre associ�s � cet �quipement logique
        /// </summary>
        /// <remarks>
        /// Un lien r�seau peut �tre �tabli entre deux �quipements logiques, mais il peut l'�tre �galement
        /// entre objets pr�cisant mieux l'extr�mit� du lien (exemple un port d'�quipement)
        /// </remarks>
        [DynamicChilds("Possible complements", typeof(CLienReseau))]
        public IComplementElementALiensReseau[] ComplementsPossibles
        {
            get
            {
                List<IComplementElementALiensReseau> lst = new List<IComplementElementALiensReseau>();
                if (TypeEquipement != null)
                {
                    foreach (CPort port in TypeEquipement.Ports)
                        lst.Add(port);
                }
                return lst.ToArray();
            }
        }


        /// <summary>
        /// Type TIMOS d'un compl�ment de lien r�seau pour un �quipement logique (<see cref="CPort">port</see>)
        /// </summary>
        [DynamicField("Complement type")]
        public Type TypeComplement
        {
            get
            {
                return typeof(CPort);
            }
        }


        public Type TypeElement
        {
            get
            {
                return typeof(CEquipementLogique);
            }
        }


        #endregion
    }
}
