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
using timos.data;

using tiag.client;
using timos.data.equipement;
using timos.data.vuephysique;
using timos.data.composantphysique;
using Lys.Licence.Types;
using Lys.Applications.Timos.Smt;
using timos.data.commandes;
using sc2i.data.dynamic.StructureImport.SmartImport;


namespace timos.data
{
	/// <summary>
	/// Mod�lise tout mat�riel physique faisant partie du r�f�rentiel r�seau g�r� dans l'application TIMOS.
	/// </summary>
    /// <remarks>
    /// Tout �quipement est associ� � un <see cref="CTypeEquipement">type d'�quipement</see> qui en d�finit le comportement.
    /// Chaque �quipement poss�de un identifiant (g�n�ralement le num�ro de s�rie) qui permet d'identifier
    /// l'�quipement parmi tous ceux du r�f�rentiel.
    /// </remarks>
	[sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iEquipement)]
	[DynamicClass("Equipment")]
	[ObjetServeurURI("CEquipementServeur")]
	[Table(CEquipement.c_nomTable, CEquipement.c_champId, true)]
	[AutoExec("Autoexec")]
    [LicenceCount(CConfigTypesTimos.c_appType_ElementDeReferentiel)]
	[RechercheRapide(CTypeEquipement.c_nomTable + "." + CTypeEquipement.c_champLibelle)]
	[RechercheRapide(CTypeEquipement.c_nomTable + "." + CTypeEquipement.c_champMnemonique)]
	[RechercheRapide(CTypeEquipement.c_nomTable + "." + CTypeEquipement.c_champCode)]
	[TiagClass(CEquipement.c_nomTiag, "Id", true)]
	public partial class CEquipement : CElementAChamp,
							IElementAEvenementsDefinis,
							IObjetDonneeAutoReference,
							IElementAEO,
							IPossesseurContrainte,
							IObjetAFilsACoordonnees,
							IObjetACoordonnees,
							IElementATableParametrable,
							IElementAInterfaceTiag,
							IElementATypeStructurant<CTypeEquipement>,
                            IElementAVuePhysique
                        
	{


		#region D�claration des constantes
        /// <summary>
        /// Utilis�e notamment dans le fen�tre de d�placement d'un �quipement
        /// </summary>
        public const string c_strCleFormuleGlobaleLibelleEquipement = "EQUIPMENT_LABEL";

		public const string c_roleChampCustom = "EQUIPMENT";
		public const string c_nomTiag = "Equipment";

		public const string c_nomTable = "EQUIPMENTS";
		public const string c_champId = "EQT_ID";
		public const string c_champIdEquipementContenant = "EQPT_ID_CONTAINER_EPQT";

		public const string c_champNumSerie = "EQPT_SERIAL";

		public const string c_champCoordonnee = "EQPT_COORDINATE";
		public const string c_champNbUnitesOccupation = "EQPT_UNITS_NB";
		public const string c_champUniteOccupation = "EQPT_OCCUPATION_UNIT_ID";
		public const string c_champOptionsControleCoordonnees = "EQPT_CTRL_COOR_OPTION";
		public const string c_champIsDotation = "EQPT_DOTATION";

		#endregion

		//-------------------------------------------------------------------
		public static void Autoexec()
		{
			CRoleChampCustom.RegisterRole(c_roleChampCustom, "Equipment", typeof(CEquipement), typeof(CDefinisseurChampsTypeEquipement));
            CFormulesGlobaleParametrage.RegisterFormuleGlobale(c_strCleFormuleGlobaleLibelleEquipement,
                I.T("Equipment label for movement|20133"),
                typeof(CEquipement));
		}

        //-------------------------------------------------------------------
        public override CRoleChampCustom RoleChampCustomAssocie
        {
            get { return CRoleChampCustom.GetRole(c_roleChampCustom); }
        }


		//-------------------------------------------------------------------
		public CEquipement(CContexteDonnee ctx)
			: base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CEquipement(System.Data.DataRow row)
			: base(row)
		{
		}

		//-------------------------------------------------------------------
		protected override void MyInitValeurDefaut()
		{
			Coordonnee = "";
			IsDotationPropre = null;
		}

		//-------------------------------------------------------------------
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] { c_champNumSerie };
		}

		//-------------------------------------------------------------------
		public override string ToString()
		{
			return Libelle;
		}

		//-------------------------------------------------------------------
		public override string DescriptionElement
		{
			get { return I.T("Equipment @1|262", Libelle); }
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Libell� de l'�quipement<br/>
		/// Permet de nommer l'<B>�quipement</B>
		/// </summary>
		[DescriptionField]
		[DynamicField("Label")]
		[TiagField("Label")]
		public string Libelle
		{
			get
			{
				string strRetour = "";
				if (TypeEquipement != null)
					strRetour = TypeEquipement.Libelle + " ";
				strRetour += NumSerie;
                if (Coordonnee.Trim() != "")
                    strRetour += " / " + Coordonnee;
				return strRetour;
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
			CTypeEquipement typeEquipement = new CTypeEquipement(ContexteDonnee);
			if (typeEquipement.ReadIfExists(lstCles))
				TypeEquipement = typeEquipement;
		}

		//-------------------------------------------------------------------
		/// <summary>
        /// <see cref="CTypeEquipement">Type de l'�quipement</see>
		/// </summary>
		[Relation(
			CTypeEquipement.c_nomTable,
			CTypeEquipement.c_champId,
			CTypeEquipement.c_champId,
			true,
			false,
			true)]
		[DynamicField("Equipment type")]
		[TiagRelation(typeof(CTypeEquipement), "TiagSetEquipmentTypeKeys")]
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
		public void TiagSetParentEquipmentKeys(object[] lstCles)
		{
			CEquipement equipement = new CEquipement(ContexteDonnee);
			if (equipement.ReadIfExists(lstCles))
			{
                IEmplacementEquipement emplacement = equipement.Emplacement;
				if (emplacement != null)
				{
					DeplaceEquipementOptionPassage("Tiag", emplacement, equipement, null, null, null, DateTime.Now, "TIAG", false, false);
				}
			}
		}

        //-----------------------------------------------------------------------------------
        public void SetEquipementParentPourImport ( CEquipement equipement )
        {
            if ( equipement != null )
                TiagSetParentEquipmentKeys ( new object[]{equipement.Id});
        }

		//-----------------------------------------------------------------------------------
		/// <summary>
		/// Equipement contenant cet �quipement (exemple un ch�ssis, une baie...)
		/// </summary>
		[Relation(
			CEquipement.c_nomTable,
			CEquipement.c_champId,
			CEquipement.c_champIdEquipementContenant,
			false,
			false,
			true)]
		[DynamicField("Container equipment")]
		[TiagRelation(typeof(CEquipement), "TiagSetParentEquipmentKeys")]
        [SpecificImportSet("SetEquipementParentPourImport")]
		public CEquipement EquipementContenant
		{
			get
			{
				return (CEquipement)GetParent(c_champIdEquipementContenant, typeof(CEquipement));
			}
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Liste des �quipements contenus (exemple : les cartes dans un ch�ssis)
		/// </summary>
		[RelationFille(typeof(CEquipement), "EquipementContenant")]
		[DynamicChilds("Contained equipements", typeof(CEquipement))]
		public CListeObjetsDonnees EquipementsContenus
		{
			get
			{
				return GetDependancesListe(c_nomTable, c_champIdEquipementContenant);
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
						lst.Add(typeEq.GetDefinisseurPourEquipementPhysique());
				return lst.ToArray();
			}
		}

		//-------------------------------------------------------------------
		public override CRelationElementAChamp_ChampCustom GetNewRelationToChamp()
		{
			return new CRelationEquipement_ChampCustom(ContexteDonnee);
		}

		//-------------------------------------------------------------------
		[RelationFille(typeof(CRelationEquipement_ChampCustom), "ElementAChamps")]
		[DynamicChilds("Custom fields relations", typeof(CRelationEquipement_ChampCustom))]
		public override CListeObjetsDonnees RelationsChampsCustom
		{
			get
			{
				return GetDependancesListe(CRelationEquipement_ChampCustom.c_nomTable, GetChampId());
			}
		}
        # endregion

		//-------------------------------------------------------------------
		/// <summary>
		/// N� de s�rie de l'�quipement
		/// </summary>
        [TableFieldProperty(CEquipement.c_champNumSerie, 255)]
		[DynamicField("Serial number")]
		[RechercheRapide]
		[TiagField("Serial number")]
		public string NumSerie
		{
			get
			{
				return (string)Row[c_champNumSerie];
			}
			set
			{
				Row[c_champNumSerie] = value;
			}
		}

		//-------------------------------------------------------------------
		public void TiagSetStatuteEquipmentKeys(object[] keys)
		{
			CStatutEquipement statut = new CStatutEquipement(ContexteDonnee);
			if (statut.ReadIfExists(keys))
				Statut = statut;
		}

		//-------------------------------------------------------------------
		/// <summary>
        /// <see cref="CStatutEquipement">Statut de l'�quipement</see> (exemple : en service, en spare...)
		/// </summary>
		[Relation(
			CStatutEquipement.c_nomTable,
			CStatutEquipement.c_champId,
			CStatutEquipement.c_champId,
			true,
			false,
			true)]
		[DynamicField("Status")]
		[TiagRelation(typeof(CStatutEquipement), "TiagSetStatuteEquipmentKeys")]
		public CStatutEquipement Statut
		{
			get { return (CStatutEquipement)GetParent(CStatutEquipement.c_champId, typeof(CStatutEquipement)); }
			set { SetParent(CStatutEquipement.c_champId, value); }
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
                DeplaceEquipementOptionPassage("Tiag", site, null, null, null, null, DateTime.Now, "TIAG", false, false);
		}

        //----------------------------------------------------------------
        public void SetSiteForImport ( CSite site )
        {
            if (site != null)
                TiagSetSitePlaceKeys(new object[]{site.Id});
        }

		//----------------------------------------------------------------
		/// <summary>
        /// <see cref="CSite">Site</see> o� se trouve l'�quipement, (s'il n'est pas dans un <see cref="CStock">stock</see> ou affect� � un <see cref="CActeur">acteur</see>)
		/// </summary>
		[Relation(CSite.c_nomTable,
			CSite.c_champId,
			CSite.c_champId,
			false,
			false,
			true)]
		[DynamicField("Site")]
		[TiagRelation(typeof(CSite), "TiagSetSitePlaceKeys")]
        [SpecificImportSet("SetSiteForImport")]
		public CSite EmplacementSite
		{
			get
            {
                return (CSite)GetParent(CSite.c_champId, typeof(CSite)); 
            }
		}


		//-------------------------------------------------------------------
		/// <summary>
		/// Utilis� par TIAG pour affecter le type de site par ses cl�s
		/// </summary>
		/// <param name="lstCles"></param>
		public void TiagSetStockPlaceKeys(object[] lstCles)
		{
			CStock stock = new CStock(ContexteDonnee);
			if (stock.ReadIfExists(lstCles))
                DeplaceEquipementOptionPassage("Tiag", stock, null, null, null, null, DateTime.Now, "TIAG", false, false);
		}

        //-------------------------------------------------------------------
        public void SetStockForImport ( CStock stock )
        {
            if ( stock != null )
                TiagSetSitePlaceKeys(new object[]{stock.Id});
        }
		//////////////////////////////////////////////////////
		/// <summary>
        /// <see cref="CStock">Stock</see> o� se trouve l'�quipement s'il n'est pas affect� dans un <see cref="CSite">site</see> ou � un <see cref="CActeur">acteur</see>
		/// </summary>
		[Relation(CStock.c_nomTable,
			CStock.c_champId,
			CStock.c_champId,
			false,
			false,
			true)]
		[DynamicField("Stock")]
		[TiagRelation(typeof(CStock), "TiagSetStockPlaceKeys")]
        [SpecificImportSet("SetStockForImport")]
		public CStock EmplacementStock
		{
			get
			{
				return (CStock)GetParent(CStock.c_champId, typeof(CStock));
			}
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Utilis� par TIAG pour affecter le type de site par ses cl�s
		/// </summary>
		/// <param name="lstCles"></param>
		public void TiagSetMemberPlaceKeys(object[] lstCles)
		{
			CActeur acteur = new CActeur(ContexteDonnee);
			if (acteur.ReadIfExists(lstCles))
                DeplaceEquipementOptionPassage("Tiag", acteur, null, null, null, null, DateTime.Now, "TIAG", false, false);
		}

        //////////////////////////////////////////////////////
        public void SetActeurForImport ( CActeur acteur )
        {
            if ( acteur != null )
                TiagSetMemberPlaceKeys ( new object[]{acteur.Id} );
        }

		//////////////////////////////////////////////////////
		/// <summary>
        /// <see cref="CTypeEquipement">Acteur</see> qui d�tient l'�quipement (en cas de r�paration, de pr�t, ...), s'il n'est pas affect�
        /// � un <see cref="CSite">site</see> ou � un <see cref="CStock">stock</see>
		/// </summary>
		[Relation(CActeur.c_nomTable,
			CActeur.c_champId,
			CActeur.c_champId,
			false,
			false,
			true)]
		[DynamicField("Owner member")]
		[TiagRelation(typeof(CActeur), "TiagSetMemberPlaceKeys")]
        [SpecificImportSet("SetActeurForImport")]
		public CActeur EmplacementActeur
		{
			get { return (CActeur)GetParent(CActeur.c_champId, typeof(CActeur)); }
		}

		//////////////////////////////////////////////////////
		/// <summary>
		/// Retourne l'entit� 'emplacement' dans laquelle se trouve l'�quipement<br/>
		/// <ul>
		///		<li><see cref="CSite">		Site			</see></li>
		///		<li><see cref="CStock">		Stock			</see></li>
		///		<li><see cref="CActeur">	Acteur			</see></li>
		/// </ul>
		/// </summary>
		[DynamicField("Place")]
		public IEmplacementEquipement Emplacement
		{
			get
			{
				IEmplacementEquipement emplacement = EmplacementSite;
				if (emplacement == null)
					emplacement = EmplacementStock;
				if (emplacement == null)
					emplacement = EmplacementActeur;
				return emplacement;
			}

		}

		//////////////////////////////////////////////////////
		/// <summary>
		/// D�finit l'emplacement initial de l'�quipement.<br/>
		/// Cette propori�t� ne fonctionne que sur un nouvel �quipement
		/// </summary>
		[DynamicField("Initial Place")]
		public IEmplacementEquipement EmplacementInitial
		{
			set
			{
				if (IsNew())//Autoris� uniquement pour un nouvel �l�ment
				{
					SetEmplacementSansHistorique(value, null);
				}
			}
		}

		//////////////////////////////////////////////////////
		/// <summary>
		/// D�finit l'�quipement initial contenant l'�quipement.<br/>
		/// Cette propori�t� ne fonctionne que sur un nouvel �quipement
		/// </summary>
        [DynamicField("Initial Parent Equipment")]
		public CEquipement EquipementParentInitial
		{
			set
			{
				if (IsNew())//Autoris� uniquement pour un nouvel �l�ment
				{
					SetParent(CEquipement.c_champIdEquipementContenant, value);
					if (value != null)
						//EmplacementInitial = value.Emplacement;   X.L.
                        //car EmplacementInitial ne prend pas en compte l'�quipement englobant
                        SetEmplacementSansHistorique(value.Emplacement, value);
				}
			}
		}



		//-------------------------------------------------------------------
		/// <summary>
		/// Modifie l'emplacement de l'�quipement sans cr�er de mouvement
		/// </summary>
		/// <param name="emplacement"></param>
		public void SetEmplacementSansHistorique(IEmplacementEquipement emplacement, CEquipement equipementParent)
		{
			SetParent(c_champIdEquipementContenant, null);
			if (emplacement is CSite)
			{
				SetParent(CSite.c_champId, (CObjetDonnee)emplacement);
				SetParent(c_champIdEquipementContenant, equipementParent);
			}
			else
				SetParent(CSite.c_champId, null);
            if (emplacement is CStock)
            {
                SetParent(CStock.c_champId, (CObjetDonnee)emplacement);
                SetParent(c_champIdEquipementContenant, equipementParent);
            }
            else
                SetParent(CStock.c_champId, null);
			if (emplacement is CActeur)
				SetParent(CActeur.c_champId, (CObjetDonnee)emplacement);
			else
				SetParent(CActeur.c_champId, null);
		}

		//-------------------------------------------------------------------
		/// <summary>
        /// Historique des <see cref="CMouvementEquipement">mouvements</see> de l'�quipement.
        /// Permet de retracer l'ensemble des changements de place (<see cref="CSite">site</see>, <see cref="CStock">stock</see>, <see cref="CActeur">acteur</see>)
        /// qu'a pu subir un �quipement tout au long de sa vie.
		/// </summary>
		[RelationFille(typeof(CMouvementEquipement), "EquipementDeplace")]
		[DynamicChilds("Movements", typeof(CMouvementEquipement))]
		public CListeObjetsDonnees Mouvements
		{
			get { return GetDependancesListe(CMouvementEquipement.c_nomTable, c_champId); }
		}


        /// <summary>
        /// Renum�rote les <see cref="CMouvementEquipement">mouvements</see>
        /// </summary>
        [DynamicMethod("Reorder movements")]
        public void RenumerotteMouvements()
        {
            CListeObjetsDonnees lstMvts = Mouvements;
            int nIndex = lstMvts.Count - 1;
            lstMvts.Filtre = new CFiltreData(CMouvementEquipement.c_champIdMouvementSuivant + " is null");
            if (lstMvts.Count == 1)
            {
                CMouvementEquipement mvt = lstMvts[0] as CMouvementEquipement;
                while (mvt != null)
                {
                    mvt.SetNumeroMouvement(nIndex--);
                    mvt = mvt.MouvementPrecedent;
                }
            }
        }

		/// <summary>
		/// Permet de d�placer un equipement vers un autre emplacement
		/// </summary>
		/// <param name="strInfoDeplacement">Commentaire sur le d�placement</param>
		/// <param name="emplacementDestination">Emplacement de destination</param>
		/// <param name="equipementDestination">Equipement de destination (pour un �quipement inclus)</param>
		/// <param name="strNouvelleCoordonnee">Nouvelle coordonn�e</param>
		/// <param name="utilisateur">Utilisateur de l'application ayant effectu� le d�placement</param>
		/// <param name="dateDeplacement">Date et heure du d�placement</param>
        /// <returns><see cref="sc2i.common.CResultAErreur">Resultat � erreur</see></returns>
		[DynamicMethod("D�place un �quipement vers un autre emplacement",
			"Informations sur le d�placement",
			"Emplacement de destination",
			"Equipement de destination (ou null)",
			"Nouvelle coordonn�e",
			"Utilisateur ayant r�alis� ce d�placement",
			"Date du d�placement")]
		public CResultAErreur MoveEquipment(
			string strInfoDeplacement,
			IEmplacementEquipement emplacementDestination,
			CEquipement equipementDestination,
			string strNouvelleCoordonnee,
			CDonneesActeurUtilisateur utilisateur,
			DateTime dateDeplacement)
		{
            return MoveEquipmentWithCause(strInfoDeplacement,
                emplacementDestination,
                equipementDestination,
                strNouvelleCoordonnee,
                utilisateur,
                dateDeplacement,
                "",
                true);
        }

        /// <summary>
        /// Permet de d�placer un equipement vers un autre emplacement, en pr�cisant la cause de ce d�placement
        /// </summary>
        /// <param name="strInfoDeplacement">Commentaire sur le d�placement</param>
        /// <param name="emplacementDestination">Emplacement de destination</param>
        /// <param name="equipementDestination">Equipement de destination (pour un �quipement inclus)</param>
        /// <param name="strNouvelleCoordonnee">Nouvelle coordonn�e</param>
        /// <param name="utilisateur">Utilisateur de l'application ayant effectu� le d�placement</param>
        /// <param name="dateDeplacement">Date et heure du d�placement</param>
        /// <param name="strCause">Cause du d�placement</param>
        /// <returns><see cref="sc2i.common.CResultAErreur">Resultat � erreur</see></returns>
        [DynamicMethod("D�place un �quipement vers un autre emplacement",
            "Informations sur le d�placement",
            "Emplacement de destination",
            "Equipement de destination (ou null)",
            "Nouvelle coordonn�e",
            "Utilisateur ayant r�alis� ce d�placement",
            "Date du d�placement",
            "Cause du d�placement (code)",
            "True si le d�placement provoque une sauvegarde")]
        public CResultAErreur MoveEquipmentWithCause (
            string strInfoDeplacement,
            IEmplacementEquipement emplacementDestination,
			CEquipement equipementDestination,
			string strNouvelleCoordonnee,
			CDonneesActeurUtilisateur utilisateur,
			DateTime dateDeplacement,
            string strCause,
            bool bSauvegarder)
        {
			return DeplaceEquipementOptionPassage(
			            strInfoDeplacement,
			            emplacementDestination,
			            equipementDestination,
			            strNouvelleCoordonnee,
			            OccupationCoordonneesPropre,
			            utilisateur,
			            dateDeplacement,
                        strCause,
                        bSauvegarder,
                        false);
		}

        


		public CResultAErreur DeplaceEquipement(
			string strInfoDeplacement,
			IEmplacementEquipement emplacementDestination,
			CEquipement equipementDestination,
			string strNouvelleCoordonnee,
			COccupationCoordonnees nouvelleOccupation,
			CDonneesActeurUtilisateur utilisateur,
			DateTime dateDeplacement,
            string strCause)
		{
			return DeplaceEquipementOptionPassage(strInfoDeplacement,
				emplacementDestination,
				equipementDestination,
				strNouvelleCoordonnee,
				nouvelleOccupation,
				utilisateur,
				dateDeplacement,
                strCause,
				true,
                false);
		}

		public CResultAErreur DeplaceEquipementOptionPassage(
					string strInfoDeplacement,
					IEmplacementEquipement emplacementDestination,
					CEquipement equipementDestination,
					string strNouvelleCoordonnee,
					COccupationCoordonnees nouvelleOccupation,
					CDonneesActeurUtilisateur utilisateur,
					DateTime dateDeplacement,
                    string strCause,
					bool bPasserEnEdition,
                    bool bVerifieDonneesAuMomentDeLaSauvegarde)
		{
			CResultAErreur result = CResultAErreur.True;
			if (emplacementDestination == null)
			{
				result.EmpileErreur(I.T("Movement must have a destination Place|248"));
			}
			if (utilisateur == null)
			{
				utilisateur = sc2i.workflow.CUtilSession.GetUserForSession(ContexteDonnee);
			}
			if (!result)
				return result;

			try
			{
				if (emplacementDestination.Equals(Emplacement))
				{
                    if (equipementDestination == EquipementContenant)
                        return result;
				}
			}
			catch { }

            if (equipementDestination != null &&
                !equipementDestination.Emplacement.Equals(emplacementDestination))
            {
                result.EmpileErreur(I.T("Container equipment is not at the same place that the contained equipment|20045"));
                return result;
            }
			
			CEquipement equipementToEdit = this;
			if (bPasserEnEdition)
				equipementToEdit.BeginEdit();

            

            CListeObjetsDonnees mouvementsExistants = equipementToEdit.Mouvements;
            CMouvementEquipement mouvementPrecedent = null;
            mouvementsExistants.Filtre = new CFiltreData(CMouvementEquipement.c_champIdMouvementSuivant + " is null");
            if (mouvementsExistants.Count != 0)
                mouvementPrecedent = mouvementsExistants[0] as CMouvementEquipement;


			CMouvementEquipement mouvement = null;

			if (EquipementContenant != null ||
				Emplacement != null)
			{
				mouvement = new CMouvementEquipement(equipementToEdit.ContexteDonnee);
				mouvement.CreateNewInCurrentContexte();
				mouvement.EquipementDeplace = this;
				mouvement.EquipementOrigine = EquipementContenant;
				mouvement.EmplacementOrigine = Emplacement;
				mouvement.Info = strInfoDeplacement;
				mouvement.DateMouvement = dateDeplacement;
				mouvement.Utilisateur = utilisateur;
				mouvement.OccupationOrigine = OccupationCoordonneeAppliquee;
				mouvement.CoordonneeOrigine = Coordonnee;
                mouvement.CodeCause = strCause;
                if (mouvementPrecedent != null)
                {
                    mouvementPrecedent.MouvementSuivant = mouvement;
                    mouvement.SetNumeroMouvement(mouvementPrecedent.NumeroMouvement + 1);
                }
                else
                    mouvement.SetNumeroMouvement(0);
			}
			if (strNouvelleCoordonnee != null)
				equipementToEdit.Coordonnee = strNouvelleCoordonnee;
			if (nouvelleOccupation != null &&
				!nouvelleOccupation.Equals(OccupationCoordonneeAppliquee))
				OccupationCoordonneesPropre = nouvelleOccupation;
            System.Console.WriteLine("D�placement vers " + emplacementDestination.Libelle);
			equipementToEdit.SetEmplacementSansHistorique(emplacementDestination, equipementDestination);

			//D�placement des �quipements contenus
			foreach (CEquipement equipementContenu in EquipementsContenus)
			{
				result = equipementContenu.DeplaceEquipementOptionPassage(
					strInfoDeplacement,
					emplacementDestination,
					equipementToEdit,
					equipementContenu.Coordonnee,
					equipementContenu.OccupationCoordonneesPropre,
					utilisateur,
					dateDeplacement,
                    strInfoDeplacement,
					false,
                    bVerifieDonneesAuMomentDeLaSauvegarde);

				if (!result)
					break;
			}

			if (mouvement != null && result && bPasserEnEdition)
                result = equipementToEdit.VerifieDonnees(bVerifieDonneesAuMomentDeLaSauvegarde);
			if (result && mouvement != null)
                result = mouvement.VerifieDonnees(bVerifieDonneesAuMomentDeLaSauvegarde);
			if (result)
			{
				if (bPasserEnEdition)
					result = equipementToEdit.CommitEdit();
			}
			else if (bPasserEnEdition)
				equipementToEdit.CancelEdit();
			//D�tache l'�quipement logique si on d�place en dehors d'un site
			if (!(emplacementDestination is CSite))
				EquipementLogique = null;
            if ( result )
			    result.Data = mouvement;
			return result;
		}

		




		#region Membres de IElementAEvenementsDefinis

		/// ///////////////////////////////////////////////////
		public IDefinisseurEvenements[] Definisseurs
		{
			get
			{
				if (TypeEquipement == null)
					return new IDefinisseurEvenements[0];
				return (IDefinisseurEvenements[])TypeEquipement.TousLesTypesParentsEtThis;
			}
		}

		/// ///////////////////////////////////////////////////
		public bool IsDefiniPar(IDefinisseurEvenements definisseur)
		{
			if (TypeEquipement == null || !(definisseur is CTypeEquipement))
				return false;
			if (TypeEquipement.Equals(definisseur))
				return true;
			if (TypeEquipement.HeriteDe((CTypeEquipement)definisseur))
				return true;
			return false;
		}

		/// ///////////////////////////////////////////////////


		#endregion

		#region IObjetDonneeAutoReference Membres

		//-------------------------------------------------------------------
		public string ChampParent
		{
			get { return c_champIdEquipementContenant; }
		}

		//-------------------------------------------------------------------
		public string ProprieteListeFils
		{
			get { return "EquipementsContenus"; }
		}

		#endregion

		//-------------------------------------------------------------------
		/// <summary>
        /// Codes complets (Full_system_code) de toutes les <see cref="CEntiteOrganisationnelle">entit�s organisationnelles</see> auxquels est affect� l'�quipement<br/>
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
			get { return new IElementAEO[] { Emplacement, TypeEquipement, EquipementContenant }; }
		}

		//--------------------------------------------
		public IElementAEO[] HeritiersEO
		{
			get { return (IElementAEO[])EquipementsContenus.ToArray(typeof(IElementAEO)); }
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
        /// Affecte � l'�quipement une nouvelle <see cref="CEntiteOrganisationnelle">entit� organisationnelle</see>
        /// </summary>
        /// <param name="nIdEO">Identifiant (Id) de l'EO � affecter</param>
        /// <returns><see cref="sc2i.common.CResultAErreur">R�sultat � erreur</see></returns>
		[DynamicMethod(
			"Asigne a new Organizational Entity to the Element",
			"The Organizational Entity Identifier")]
		public CResultAErreur AjouterEO(int nIdEO)
		{
			return CUtilElementAEO.AjouterEO(this, nIdEO);
		}

		//-----------------------------------------------------------------
        /// <summary>
        /// Ote de l'�quipement <see cref="CEntiteOrganisationnelle">l'entit� organisationnelle</see> pr�cis�e
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
        //-------------------------------------------------------------------
        /// <summary>
        /// Remet � jour les codes des <see cref="CEntiteOrganisationnelle">entit�s organisationnelles</see> de cet �quipement
        /// </summary>
        [DynamicMethod("Refresh Organizational entities codes for this element")]
        public void RefreshCodesEOS()
        {
            CUtilElementAEO.UpdateEOs(this);
        }



		//---------------------------------------- ------------------------------
		/// <summary>
        /// Liste des <see cref="CContrainte">Contraintes</see> (Serrure, lecteur de badge, etc.) associ�es � l'�quipement
		/// </summary>
		[RelationFille(typeof(CContrainte), "Equipement")]
		[DynamicChilds("Constraints", typeof(CContrainte))]
		public CListeObjetsDonnees Contraintes
		{
			get { return GetDependancesListe(CContrainte.c_nomTable, c_champId); }
		}

		//---------------------------------------- ------------------------------
		public List<CContrainte> ToutesLesContraintes
		{
			get
			{
				List<CContrainte> lst = new List<CContrainte>();
				foreach (CContrainte contrainte in Contraintes)
					lst.Add(contrainte);
				return lst;
			}
		}



        //-------------------------------------------------------------------
        /// <summary>
        /// Utilis� par TIAG pour affecter la Relation constructeur
        /// </summary>
        /// <param name="lstCles"></param>
        public void TiagSetManufacturerRelationKeys(object[] lstCles)
        {
            CRelationTypeEquipement_Constructeurs rel = new CRelationTypeEquipement_Constructeurs(ContexteDonnee);
            if (rel.ReadIfExists(lstCles))
                RelationConstructeur = rel;
        }

		//-------------------------------------------------------------------
		/// <summary>
        /// <see cref="CRelationTypeEquipement_Constructeurs">Relation avec le constructeur</see> de l'�quipement 
		/// </summary>
		[Relation(
			CRelationTypeEquipement_Constructeurs.c_nomTable,
			CRelationTypeEquipement_Constructeurs.c_champId,
			CRelationTypeEquipement_Constructeurs.c_champId,
			false,
			false,
			true)]
		[DynamicField("Manufacturer relation")]
        [TiagRelation(typeof(CRelationTypeEquipement_Constructeurs), "TiagSetManufacturerRelationKeys")]
		public CRelationTypeEquipement_Constructeurs RelationConstructeur
		{
			get
			{
				return (CRelationTypeEquipement_Constructeurs)GetParent(CRelationTypeEquipement_Constructeurs.c_champId, typeof(CRelationTypeEquipement_Constructeurs));
			}
			set
			{
				SetParent(CRelationTypeEquipement_Constructeurs.c_champId, value);
			}
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Utilis� par TIAG pour affecter le constructeur par ses cl�s
		/// </summary>
		/// <param name="lstCles"></param>
		public void TiagSetManufacturerKeys(object[] lstCles)
		{
			CDonneesActeurConstructeur constructeur = new CDonneesActeurConstructeur(ContexteDonnee);
			if (constructeur.ReadIfExists(lstCles))
				Constructeur = constructeur;
		}

		//-------------------------------------------------------------------
        /// <summary>
        /// <see cref="CDonneesActeurConstructeur">Constructeur</see> de l'�quipement
        /// </summary>
		[DynamicField("Manufacturer")]
		[TiagRelation(typeof(CDonneesActeurConstructeur), "TiagSetManufacturerKeys")]
		[OptimiseReadDependance("RelationConstructeur.Constructeur")]
		public CDonneesActeurConstructeur Constructeur
		{
			get
			{
				if (RelationConstructeur != null)
					return RelationConstructeur.Constructeur;
				return null;
			}
			set
			{
				if (value == null)
					RelationConstructeur = null;
				if (TypeEquipement != null)
				{
					foreach (CRelationTypeEquipement_Constructeurs rel in TypeEquipement.RelationsConstructeurs)
					{
						if (rel.Constructeur != null && rel.Constructeur.Equals(value))
						{
							RelationConstructeur = rel;
							break;
						}
					}
				}
			}
		}

        /// <summary>
        /// R�f�rence de l'�quipement chez le <see cref="CDonneesActeurConstructeur">constructeur</see>
        /// </summary>
        [DynamicField("Manufacturer Reference")]
        [TiagField("Manufacturer Reference")]
        public string ManufacturerReference
        {
            get
            {
                if (RelationConstructeur != null)
                    return RelationConstructeur.Reference;

                return string.Empty;
            }
        }



		//---------------------------------------------------------------------
		/// <summary>
		/// Bool�en indiquant si l'Equipement est en mode de gestion par "Dotation"
		/// </summary>
		[TableFieldProperty(c_champIsDotation, NullAutorise = true)]
		[DynamicField("Is Dotation Management")]
		public bool? IsDotationPropre
		{
			get
			{
				return (bool?)Row[c_champIsDotation, true];
			}
			set
			{
				Row[c_champIsDotation, true] = value;
			}
		}

		/// <summary>
		/// Bool�en indiquant si le mode de gestion par dotation<br/>
        /// est appliqu� � l'�quipement
		/// </summary>
		[DynamicField("Is Dotation Management applied")]
		public bool IsDotationApplique
		{
			get
			{
				bool bRetour = false;
				if (IsDotationPropre == null)
				{
					if (TypeEquipement != null)
					{
						if (TypeEquipement.IsDotationByDefault)
							bRetour = true;
					}
				}
				else
				{
					bRetour = (bool)IsDotationPropre;
				}
				return bRetour;
			}
		}


		//-------------------------------------------------------------------
		/// <summary>
        /// <see cref="CEquipementLogique">Equipement logique</see> associ�
		/// </summary>
		[Relation(
			CEquipementLogique.c_nomTable,
			CEquipementLogique.c_champId,
			CEquipementLogique.c_champId,
			false,
			false,
			true)]
		[DynamicField("Associated logical equipment")]
		public CEquipementLogique EquipementLogique
		{
			get
			{ 
				return (CEquipementLogique)GetParent(CEquipementLogique.c_champId, typeof(CEquipementLogique));
			}
			set
			{
				SetParent(CEquipementLogique.c_champId, value);
			}
		}


		#region IObjetAFilsACoordonnees Membres

		//------------------------------------------------------------------
		public List<IObjetACoordonnees> FilsACoordonnees
		{
			get
			{
				List<IObjetACoordonnees> fils = new List<IObjetACoordonnees>();
				foreach (CEquipement eqpt in EquipementsContenus)
					fils.Add(eqpt);
				return fils;
			}
		}

		//------------------------------------------------------------------
		public CResultAErreur IsCoordonneeValide(string strCoordonnee, IObjetACoordonnees objet)
		{
			return SObjetAvecFilsAvecCoordonnees.VerifieCoordonneeFils(this, objet, strCoordonnee);
		}

		//------------------------------------------------------------------
		public CResultAErreur VerifieCoordonneesFils()
		{
			return SObjetAvecFilsAvecCoordonnees.VerifieCoordonneesFils(this);
		}

		//------------------------------------------------------------------
		public EOptionControleCoordonnees? OptionsControleCoordonneesApplique
		{
			get
			{
				EOptionControleCoordonnees? option = OptionsControleCoordonneesPropre;
				if (option == null && IsNew())
				{
					IObjetAOptionsDeControleDeCoordonnees donnateur = DonnateurOptionsControleCoordonneesHerite;
					if (donnateur != null)
						option = donnateur.OptionsControleCoordonneesPropre;
				}
				return option;
			}
		}

		//------------------------------------------------------------------
		public IObjetAOptionsDeControleDeCoordonnees DonnateurOptionsControleCoordonneesHerite
		{
			get
			{
				if (TypeEquipement != null)
					return TypeEquipement;
				return null;
			}
		}

		//------------------------------------------------------------------
		[TableFieldProperty(CEquipement.c_champOptionsControleCoordonnees, NullAutorise = true)]
		public int? OptionsControleCoordonneesPropreInt
		{
			get
			{
				if (Row[c_champOptionsControleCoordonnees] == DBNull.Value)
					return null;
				return (int?)Row[c_champOptionsControleCoordonnees];
			}
			set
			{
				if (value == null)
					Row[c_champOptionsControleCoordonnees] = DBNull.Value;
				else
					Row[c_champOptionsControleCoordonnees] = (int)value;
			}
		}


		//------------------------------------------------------------------
		public EOptionControleCoordonnees? OptionsControleCoordonneesPropre
		{
			get
			{
				return (EOptionControleCoordonnees?)OptionsControleCoordonneesPropreInt;
			}
			set
			{
				OptionsControleCoordonneesPropreInt = (int?)value;
			}
		}

		//------------------------------------------------------------------
		public bool CanHeriteOptionsControleCoordonnees
		{
			get
			{
				return IsNew();
			}
		}

		public EOptionControleCoordonnees? OptionsDisponibles
		{
			get
			{
				return EOptionControleCoordonnees.AutoriserPlusieursFilsSurLaMemeCoordonnee |
					EOptionControleCoordonnees.IgnorerLesFilsSansCoordonnees |
					EOptionControleCoordonnees.IgnorerLesUnites |
					EOptionControleCoordonnees.IgnorerLoccupation |
                    EOptionControleCoordonnees.IgnorerLesEquipements | 
					EOptionControleCoordonnees.TousControles;
			}
		}


		#endregion

		#region IObjetASystemeDeCoordonnee Membres

		//----------------------------------------------------------------------
		public IObjetASystemeDeCoordonnee DonnateurParametrageCoordonneeHerite
		{
			get
			{
				if (TypeEquipement != null && TypeEquipement.ParametrageCoordonneesPropre != null)
					return TypeEquipement;
				if (TypeEquipement != null && TypeEquipement.ParametrageCoordonneesPropre == null)
					return TypeEquipement.DonnateurParametrageCoordonneeHerite;
				return null;
			}
		}

		//------------------------------------------------------------------
        /// <summary>
        /// Donne le <see cref="CParametrageSystemeCoordonnees">syst�me de coordonn�es</see> appliqu� � l'�quipement
        /// </summary>
		[DynamicField("Applied coordinate system")]
		public CParametrageSystemeCoordonnees ParametrageCoordonneesApplique
		{
			get
			{
				CParametrageSystemeCoordonnees parametrage = ParametrageCoordonneesPropre;
				if (parametrage == null && IsNew())
				{
					IObjetASystemeDeCoordonnee donnateur = DonnateurParametrageCoordonneeHerite;
					if (donnateur != null)
						parametrage = donnateur.ParametrageCoordonneesPropre;
				}
				return parametrage;
			}
		}

        //------------------------------------------------------------------

        //---------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [RelationFille(typeof(CParametrageSystemeCoordonnees), "Equipement")]
        public CListeObjetsDonnees ParametragesSystemesCoordonnees
        {
            get
            {
                return GetDependancesListe(CParametrageSystemeCoordonnees.c_nomTable, c_champId);
            }
        }

		//------------------------------------------------------------------
        /// <summary>
        /// Donne le <see cref="CParametrageSystemeCoordonnees">syst�me de coordonn�es</see> qui est propre � l'�quipement
        /// </summary>
		[DynamicField("Own coordinate system")]
		public CParametrageSystemeCoordonnees ParametrageCoordonneesPropre
		{
			get
			{
                CListeObjetsDonnees liste = ParametragesSystemesCoordonnees;
				if (liste.Count == 1)
					return (CParametrageSystemeCoordonnees)liste[0];
				return null;
			}
		}

		//----------------------------------------------------------------------
		public bool CanHeriteParametrageCoordonnees
		{
			get
			{
				return IsNew();
			}
		}

		//----------------------------------------------------------------------
		public string ProprieteVersObjetsAFilsACoordonneesUtilisantLeParametrage
		{
			get
			{
				return "";
			}
		}

		#endregion

		#region IObjetACoordonnees

		//-----------------------------------------------------------
		/// <summary>
		/// Cha�ne de caract�res donnant la coordonn�e propre � l'�quipement
		/// </summary>
		[TableFieldProperty(c_champCoordonnee, 255)]
		[DynamicField("Coordinate")]
		[TiagField("Coordinate")]
		public string Coordonnee
		{
			get
			{
				return (string)Row[c_champCoordonnee];
			}
			set
			{
				Row[c_champCoordonnee] = value;
			}
		}

        /// <summary>
        /// Cha�ne de caract�res donnant les coordonn�es compl�tes de l'�quipement<br/>
        /// y compris celles de ses contenants
        /// </summary>
		[DynamicField("Full Coordinate")]
		public string CoordonneeComplete
		{
			get
			{
				if (CoordonneeParente == "" || CoordonneeParente == null)
					return Coordonnee;
				else
				{
					if (Coordonnee == "" || Coordonnee == null)
						return CoordonneeParente;
					else
						return CoordonneeParente + CSystemeCoordonnees.c_separateurNumerotations + Coordonnee;
				}
			}
		}

        /// <summary>
        /// Cha�ne de caract�res donnant les coordonn�es compl�tes du parent de l'�quipement
        /// </summary>
        /// <remarks>Le parent peut �tre suivant les cas l'�quipement contenant ou le stock ou le site</remarks>
		[DynamicField("Parent Coordinate")]
		public string CoordonneeParente
		{
			get
			{
				if (EquipementContenant != null && (EquipementContenant.Coordonnee != "" && EquipementContenant.Coordonnee != null))
					return EquipementContenant.CoordonneeComplete;
				else if (EmplacementStock != null && (EmplacementStock.Coordonnee != "" && EmplacementStock.Coordonnee != null))
					return EmplacementStock.CoordonneeComplete;
				else if (EmplacementSite != null && (EmplacementSite.Coordonnee != "" && EmplacementSite.Coordonnee != null))
					return EmplacementSite.CoordonneeComplete;
				else
					return "";

			}
		}


        
		//-------------------------------------------------------------------
        /// <summary>
        /// Nombre <see cref="CUniteCoordonnee">d'unit�s</see> qu'occupe l'�quipement dans son contenant
        /// </summary>
		[TableFieldProperty(CEquipement.c_champNbUnitesOccupation, NullAutorise = true)]
		[DynamicField("Unit number")]
		[TiagField("Unit number")]
		public int? NbUnitesOccupees
		{
			get
			{
				return (int?)Row[c_champNbUnitesOccupation, true];
			}
			set
			{
				Row[c_champNbUnitesOccupation, true] = value;
			}
		}


		//-------------------------------------------------------------------
		/// <summary>
        /// <see cref="CUniteCoordonnee">Unit�</see> employ�e pour donner l'encombrement de l'�quipement
		/// </summary>
		[Relation(
			CUniteCoordonnee.c_nomTable,
			CUniteCoordonnee.c_champId,
			CEquipement.c_champUniteOccupation,
			false,
			false,
			false)]
		[DynamicField("Occupation unit")]
		public CUniteCoordonnee UniteOccupee
		{
			get
			{
				return (CUniteCoordonnee)GetParent(CEquipement.c_champUniteOccupation, typeof(CUniteCoordonnee));
			}
			set
			{
				SetParent(CEquipement.c_champUniteOccupation, value);
			}
		}

		//-------------------------------------------------------------------
		public IObjetAFilsACoordonnees ConteneurFilsACoordonnees
		{
			get
			{
				if (EquipementContenant != null)
					return EquipementContenant;
				if (Emplacement is IObjetAFilsACoordonnees)
					return (IObjetAFilsACoordonnees)Emplacement;
				return null;
			}
		}

		//-------------------------------------------------------------------
		public CResultAErreur VerifieCoordonnee()
		{
			CResultAErreur result = CResultAErreur.True;
			IObjetAFilsACoordonnees parent = ConteneurFilsACoordonnees;
			if (parent != null)
				return parent.IsCoordonneeValide(Coordonnee, this);
			return result;
		}

		#endregion

		#region IObjetAOccupation
		//--------------------------------------------------------------
		public COccupationCoordonnees OccupationCoordonneeAppliquee
		{
			get
			{
				COccupationCoordonnees occupation = OccupationCoordonneesPropre;
				if (occupation == null && IsNew())
				{
					IObjetAOccupation donnateur = DonnateurOccupationCoordonneeHerite;
					if (donnateur != null)
						occupation = donnateur.OccupationCoordonneesPropre;
				}
				return occupation;
			}
		}

		//--------------------------------------------------------------
		public IObjetAOccupation DonnateurOccupationCoordonneeHerite
		{
			get
			{
				return TypeEquipement;
			}
		}

		//--------------------------------------------------------------
		public COccupationCoordonnees OccupationCoordonneesPropre
		{
			get
			{
				if (NbUnitesOccupees != null)
					return new COccupationCoordonnees((int)NbUnitesOccupees, UniteOccupee);
				return null;
			}
			set
			{
				if (value == null)
				{
					NbUnitesOccupees = null;
					UniteOccupee = null;
				}
				else
				{
					NbUnitesOccupees = value.NbUnitesOccupees;
					UniteOccupee = value.Unite;
				}
			}
		}

		//--------------------------------------------------------------
		public bool CanHeriteOccupationCoordonnees
		{
			get
			{
				return IsNew();
			}
		}

		//--------------------------------------------------------------
		/// <summary>
		/// On ignore l'unit� si elle est nulle !
		/// tiens pourquoi ? parce que c'est une id�e comme �a.
		/// </summary>
		public bool IgnorerUnite
		{
			get
			{
				return UniteOccupee == null;
			}
		}

		#endregion

		//-------------------------------------------------------------------


		#region IElementATableParametrable


		/// <summary>
		/// </summary>
		[RelationFille(typeof(CTableParametrable), "Equipement")]
		[DynamicChilds("Custom Tables", typeof(CTableParametrable))]
		public CListeObjetsDonnees TablesParametrables
		{
			get { return GetDependancesListe(CTableParametrable.c_nomTable, c_champId); }
		}




		public CListeObjetsDonnees TablesParametrablesPossibles
		{
			get
			{
				CFiltreData filtre = new CFiltreDataImpossible();
				if (TypeEquipement == null)
					return new CListeObjetsDonnees(ContexteDonnee, typeof(CTableParametrable), filtre);

				CListeObjetsDonnees rels = TypeEquipement.RelationsTypesTableParametrables;

				if (rels.CountNoLoad == 0)
					return new CListeObjetsDonnees(ContexteDonnee, typeof(CTableParametrable), filtre);

				string strIdsTypesPoss = "";
				foreach (CRelationTypeEquipement_TypeTableParametrable r in rels)
					strIdsTypesPoss += r.TypeTableParametrable.Id + ",";

				strIdsTypesPoss = strIdsTypesPoss.Substring(0, strIdsTypesPoss.Length - 1);
				filtre = new CFiltreDataAvance(CTableParametrable.c_nomTable, CTypeTableParametrable.c_nomTable + "." + CTypeTableParametrable.c_champId + " IN (" + strIdsTypesPoss + ")");

				return new CListeObjetsDonnees(ContexteDonnee, typeof(CTableParametrable), filtre);
			}
		}
		public CListeObjetsDonnees TypesTableParametrablePossibles
		{
			get
			{
				CFiltreData filtre = new CFiltreDataImpossible();

				if (TypeEquipement == null)
					return new CListeObjetsDonnees(ContexteDonnee, typeof(CTypeTableParametrable), filtre);
				CListeObjetsDonnees rels = TypeEquipement.RelationsTypesTableParametrables;

				if (rels.CountNoLoad == 0)
					return new CListeObjetsDonnees(ContexteDonnee, typeof(CTypeTableParametrable), filtre);

				string strIdsTypesPoss = "";
				foreach (CRelationTypeEquipement_TypeTableParametrable r in rels)
					strIdsTypesPoss += r.TypeTableParametrable.Id + ",";

				strIdsTypesPoss = strIdsTypesPoss.Substring(0, strIdsTypesPoss.Length - 1);
				filtre = new CFiltreDataAvance(CTypeTableParametrable.c_nomTable, CTypeTableParametrable.c_champId + " IN (" + strIdsTypesPoss + ")");

				return new CListeObjetsDonnees(ContexteDonnee, typeof(CTypeTableParametrable), filtre);
			}
		}
		#endregion

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

		/// <summary>
		/// Cr�e automatiquement l'�quipement logique associ� � l'equipement
		/// </summary>
		public void CreateEquipementLogiqueAutomatiqueInContexte()
		{
			if (EquipementLogique != null)
				return;
			CEquipementLogique eqptLogique = new CEquipementLogique ( ContexteDonnee);
			eqptLogique.CreateNewInCurrentContexte();
			if ( TypeEquipement != null  )
				eqptLogique.TypeEquipement = TypeEquipement;
			eqptLogique.Site = EmplacementSite;
			if (EquipementContenant != null &&
				EquipementContenant.EquipementLogique != null)
				eqptLogique.EquipementLogiqueContenant = EquipementContenant.EquipementLogique;
			EquipementLogique = eqptLogique;
		}

		public override CResultAErreur VerifieDonnees(bool bAuMomentDeLaSauvegarde)
		{
			CResultAErreur result = base.VerifieDonnees(bAuMomentDeLaSauvegarde);
			if (result)
			{
				if (EquipementLogique != null && EquipementLogique.Site == null && EmplacementSite != null)
					EquipementLogique.Site = EmplacementSite.SiteParent;
				if (EquipementLogique != null && 
					EquipementLogique.EquipementLogiqueContenant == null &&
					EquipementContenant != null &&
					EquipementContenant.EquipementLogique != null)
					EquipementLogique.EquipementLogiqueContenant = EquipementContenant.EquipementLogique;
			}
			return result;
		}

        #region IElementAVuePhysique Membres

        public CVuePhysique VuePhysique
        {
            get
            {
                CVuePhysique vue = new CVuePhysique(ContexteDonnee);
                if (vue.ReadIfExists(new CFiltreData(CEquipement.c_champId + "=@1",
                    Id)))
                    return vue;
                return null;
            }
        }

        //-------------------------------------------------------------------------
        public CVuePhysique GetVuePhysiqueAvecCreation()
        {
            CVuePhysique vue = VuePhysique;
            if (vue == null)
            {
                vue = new CVuePhysique(ContexteDonnee);
                vue.CreateNewInCurrentContexte();
                vue.EquipementAssocie = this;
                vue.CodeFacePrincipale = (int)EFaceVueDynamique.Front;
            }
            return vue;
        }

        #endregion

        public C2iComposant3D GetComposantPhysique()
        {
            if (TypeEquipement == null)
                return null;
            CComposantPhysiqueInDb composantInDb = TypeEquipement.ComposantPhysiqueAssocie;
            if (composantInDb == null)
                return null;
            C2iComposant3D composant = composantInDb.Composant;
            if (composant == null)
                return null;
            composant.SetElementToEvalFormules(TypeEquipement);
            //Ajoute les fils au composant
            foreach (CEquipement equipement in EquipementsContenus)
            {
                composant.PlaceFilsACoordonn�es(equipement);
            }
            return composant;
        }


        //-------------------------------------------------------------------
        /// <summary>
        /// <see cref="CValorisationEquipement">Valorisation</see> associ�e � l'�quipement
        /// </summary>
        [Relation(
            CValorisationElement.c_nomTable,
            CValorisationElement.c_champId,
            CValorisationElement.c_champId,
            false,
            false,
            true)]
        [DynamicField("Valuation")]
        public CValorisationElement ValorisationEquipement
        {
            get
            {
                return (CValorisationElement)GetParent(CValorisationElement.c_champId, typeof(CValorisationElement));
            }
            set
            {
                SetParent(CValorisationElement.c_champId, value);
            }
        }

	

    }
}
