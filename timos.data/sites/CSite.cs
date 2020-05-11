using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;
using sc2i.doccode;

using tiag.client;

using Lys.Licence;
using Lys.Applications.Timos.Smt;

using timos.securite;
using timos.data.version;
using timos.data.vuephysique;
using timos.data.composantphysique;
using Lys.Licence.Types;
using timos.data.supervision;
using timos.data.snmp;
using sc2i.expression;

namespace timos.data
{
    /// <summary>
    /// Un Site repr�sente un lieu g�ographique qui permet de localiser des Equipements.
    /// Un site est une entit� physique concr�te, passive et qui poss�de une localisation
    /// g�ographique en g�n�rale stable.
	/// Les Sites sont hi�rarchiques, ils peuvent inclure des Sites Fils.
    /// </summary>
    /// <remarks>
    /// Exemples de sites : POP (Point Of Presence), un b�timent dans un POP (site fils),
    /// une salle dans un b�timent, un pyl�ne dans un POP, etc.
    /// Les entit�s g�ographiques abstraites comme des r�gions, des villes, etc. ne doivent
    /// pas �tre mod�lis�es comme des sites mais comme des <see cref="CEntiteOrganisationnelle">entit�s organisationnelles</see>.
    /// </remarks>
	[DynamicClass("Sites")]
	[DocRefMenusOrMenuItems(CDocLabels.c_iSite)]
	[DocRefRessources(CDocLabels.c_dSite)]
	[Table(CSite.c_nomTable, CSite.c_champId, true)]
	[ObjetServeurURI("CSiteServeur")]
	[AutoExec("Autoexec")]
    [LicenceCount(CConfigTypesTimos.c_appType_ElementDeReferentiel)]
	[TiagClass(CSite.c_nomTiag, "Id", true)]
	public class CSite : CObjetHierarchique,        // Objet hi�r�rchique Prent/fils
						 IObjetDonneeAChamps,       // Permet la possibilit� d'ajouter des champs custom (et formulaires au Site)
						 IEmplacementEquipement,    // Peut contenir des �quipements
						 IElementAEO,               // Peut appartenir � des EO
						 IPossesseurRessource,      // Le site est un emplacment de Ressource
						 IPossesseurContrainte,     // Le Site est un �l�ment � contrainte
						 IElementAInterfaceTiag,		// Le site est export� dans tiag
						 IElementAIntervention,				//Le site peut avoir des t�ches
                         IObjetALectureTableComplete,   //Lecture de la table compl�te ( 25/11/2012) �a va plus vite   
						 IObjetAFilsACoordonnees,
						 IElementATableParametrable,
						 IObjetACoordonnees,
						 IElementACaracteristique,
					     IElementATypeStructurant<CTypeSite>,
                         IDefinisseurSymbole,
                         IElementASymbolePourDessin,
                         IElementALiensReseau,
                         IElementDeSchemaReseau,
                         IElementAVuePhysique,
                         IElementSupervise
	{




		public const string c_nomTiag = "Sites";
		public const string c_nomTable = "SITE";

		public const string c_champId = "SITE_ID";

		public const string c_champLibelle = "SITE_LABEL";
		public const string c_champCode = "SITE_CODE";

		public const string c_champCodeSystemePartiel = "SITE_PARTIAL_SYS_CODE";
		public const string c_champCodeSystemeComplet = "SITE_FULL_SYS_CODE";
		public const string c_champNiveau = "SITE_LEVEL";
		public const string c_champIdParent = "SITE_PARENT_ID";

		public const string c_roleChampCustom = "SITE";

		//IObjetAvecCoordonnees
		public const string c_champCoordonnee = "SITE_COORDINATE";
		public const string c_champOptionsControleCoordonnees = "SITE_COORD_CTRL_OPTION";
		public const string c_champEOCoor = "SITE_OECOOR";


		/// /////////////////////////////////////////////
		public CSite(CContexteDonnee contexte)
			: base(contexte)
		{
		}

		/// /////////////////////////////////////////////
		public CSite(DataRow row)
			: base(row)
		{
		}

		//-------------------------------------------------------------------
		public static void Autoexec()
		{
			CRoleChampCustom.RegisterRole(c_roleChampCustom, "Sites", typeof(CSite),typeof(CTypeSite));
		}

        //--------------------------------------------------------------------
        public CRoleChampCustom RoleChampCustomAssocie
        {
            get
            {
                return CRoleChampCustom.GetRole(c_roleChampCustom);
            }
        }


		////////////////////////////////////////////////
		/// <summary>
        /// Description + Label. Ce champ est en lecture seule
		/// </summary>
		public override string DescriptionElement
		{
			get
			{
				return I.T("Site: @1|275",Libelle);
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

		///////////////////////////////////////////////
        /// <summary>
        /// Le nom donn� au Site.
        /// Pour �viter toute ambigu�t�, il est recommand� que le nom de site soit unique.
        /// Nombre maximum de caract�res : 255.
        /// </summary>
		[TableFieldProperty(c_champLibelle, 255)]
		[DynamicField("Label")]
		[RechercheRapide]
		[TiagField("Label")]
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

		/////////////////////////////////////////////
        /// <summary>
        /// Le Code du Site est un texte libre de 255 caract�res maximum.
        /// </summary>
		[TableFieldProperty(c_champCode, 255)]
		[DynamicField("Site code")]
		[RechercheRapide]
		[TiagField("Code")]
		public string Code
		{
			get
			{
				return (string)Row[c_champCode];
			}
			set
			{
				Row[c_champCode] = value;
			}
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Utilis� par TIAG pour affecter le type de site par ses cl�s
		/// </summary>
		/// <param name="lstCles"></param>
		public void TiagSetSiteTypeKeys(object[] lstCles)
		{
			CTypeSite typeSite = new CTypeSite(ContexteDonnee);
			if (typeSite.ReadIfExists(lstCles))
				TypeSite = typeSite;
		}

		//-------------------------------------------------------------------
		/// <summary>
        /// Obtient ou d�finit le <see cref="CTypeSite">Type du Site</see>. Ce champ est obligatoire.
		/// </summary>
		[Relation(CTypeSite.c_nomTable, CTypeSite.c_champId, CTypeSite.c_champId, true, false, true)]
		[DynamicField("Site type")]
		[TiagRelation(typeof(CTypeSite), CAssociationTiag.c_methodeUseDelegate)]
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

       

		//----------------------------------------------------
		public override int NbCarsParNiveau
		{
			get
			{
				return 4;
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

		//-------------------------------------------------------------------
		/// <summary>
		/// Utilis� par TIAG pour affecter le site parent par ses cl�s
		/// </summary>
		/// <param name="lstCles"></param>
		public void TiagSetParentSiteKeys(object[] lstCles)
		{
			CSite site = new CSite(ContexteDonnee);
			if (site.ReadIfExists(lstCles))
				SiteParent = site;
		}
		//----------------------------------------------------
		/// <summary>
		/// Site parent dans la hi�rarchie. Si le Site n'a pas de Site parent la propri�t� retourne NULL.
		/// </summary>
		[Relation(
			c_nomTable,
			c_champId,
			c_champIdParent,
			false,
			false,
            true)]
		[DynamicField("Parent site")]
		[TiagRelation(typeof(CSite), "TiagSetParentSiteKeys")]
		public CSite SiteParent
		{
			get
			{
				return (CSite)ObjetParent;
			}
			set
			{
				if (value != null)
					ObjetParent = value;
			}
		}

		//----------------------------------------------------
		/// <summary>
		/// Liste des Sites fils dans la hi�rarchie (d'ordre imm�diatement inf�rieur)
		/// </summary>
		[RelationFille(typeof(CSite), "SiteParent")]
		[DynamicChilds("Child sites", typeof(CSite))]
		public CListeObjetsDonnees SitesFils
		{
			get
			{
				return ObjetsFils;
			}
		}

		//----------------------------------------------------
		/// <summary>
		/// Indique le code syst�me du Site dans sa hi�rarchie. Ce code est unique dans son parent.
        /// Ce code est exprim� sur 4 caract�res alphanum�riques.
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
				strVal = strVal.Trim().PadLeft(4, '0');
				return strVal;
			}
		}

		//----------------------------------------------------
		/// <summary>
        /// Indique le code syst�me complet du site.<br/>
        /// Ce code syst�me complet est la concat�nation du code syst�me partiel du site<br/>
        /// avec le code syst�me partiel de tous ses parents en remontant la hi�rarchie.<br/>
        /// Exemple : pour un code syst�me complet tel que : 0012000A0034 :<br/>
        /// 0034 est le code partiel du site courant<br/>
        /// 000A est le code partiel du site p�re<br/>
        /// 0012 est le code partiel du site grand p�re
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
		/// Indique le niveau hi�rarchique( nombre de parents ) du site.
        /// Le niveau d'un site sans parent est 0.
        /// Exemple : Site POP -> B�timent dans le POP -> Salle dans le b�timent :
        /// 'Site POP' a pour niveau 0,
        /// 'B�timent dans le POP' a pour niveau 1 (1 parent en remontant la hi�rarchie)
        /// 'Salle dans le b�timent' a pour niveau 2 (2 parents en remontant la hi�rachie)
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

		//---------------------------------------------------------------------
		/// <summary>
        /// Retourne la liste des <see cref="CContrainte">Contraintes</see> li�es au Site.
		/// </summary>
		[RelationFille(typeof(CContrainte), "Site")]
		[DynamicChilds("Constraints", typeof(CContrainte))]
		public CListeObjetsDonnees Contraintes
		{
			get
			{
				return GetDependancesListe(CContrainte.c_nomTable, c_champId);
			}

		}

		//---------------------------------------------------------------------
		public List<CContrainte> ToutesLesContraintes
		{
			get
			{
				List<CContrainte> lstContraintes = new List<CContrainte>();
				foreach (CContrainte contrainte in Contraintes)
				{
					if (!lstContraintes.Contains(contrainte))
						lstContraintes.Add(contrainte);
				}
				if (SiteParent != null)
				{
					foreach (CContrainte contrainte in SiteParent.ToutesLesContraintes)
						if (!lstContraintes.Contains(contrainte))
							lstContraintes.Add(contrainte);
				}
				if (TypeSite != null)
				{
					foreach (CContrainte contrainte in TypeSite.Contraintes)
						if (!lstContraintes.Contains(contrainte))
							lstContraintes.Add(contrainte);
				}
				return lstContraintes;
			}
			
		}
					

		//---------------------------------------------------------------------------
		/// <summary>
        /// Retourne la liste de tous les <see cref="CEquipement">Equipements</see> pr�sents sur le Site.
		/// </summary>
		[RelationFille(typeof(CEquipement), "EmplacementSite")]
		[DynamicChilds("Equipments", typeof(CEquipement))]
		public CListeObjetsDonnees Equipements
		{
			get
			{
				return GetDependancesListe(CEquipement.c_nomTable, c_champId);
			}
		}

		//---------------------------------------------------------------------------
		/// <summary>
        /// Retourne la liste de tous les <see cref="CEquipementLogique">�quipements logiques</see> li�s au site
		/// </summary>
		[RelationFille(typeof(CEquipementLogique), "Site")]
		[DynamicChilds("Logical equipments", typeof(CEquipementLogique))]
		public CListeObjetsDonnees EquipementsLogiques
		{
			get
			{
				return GetDependancesListe(CEquipementLogique.c_nomTable, c_champId);
			}
		}

		//-----------------------------------------------------------------------------
		/// <summary>
        /// Retourne la liste des <see cref="CStock">Stocks</see> pr�sents sur le Site.
		/// </summary>
        [RelationFille(typeof(CStock), "Site")]
		[DynamicChilds("Stocks", typeof(CStock))]
		public CListeObjetsDonnees Stocks
		{
			get
			{
				return GetDependancesListe(CStock.c_nomTable, c_champId);
			}
		}

		//------------------------------------------------------------------------------------
        /// <summary>
        /// Retourne la liste des <see cref="CRessourceMaterielle">Ressources</see> pr�sentes sur le Site
        /// </summary>
		[RelationFille(typeof(CRessourceMaterielle), "EmplacementSite")]
		[DynamicChilds("Held Resources", typeof(CRessourceMaterielle))]
        public CListeObjetsDonnees RessourcesDetenues
		{
			get
			{
				return GetDependancesListe(CRessourceMaterielle.c_nomTable, c_champId);
			}
		}

        
        //-----------------------------------------------------------------------------------
        /// <summary>
        /// Retourne la liste des Relations entre le Site et un <see cref="CTicket">Ticket</see>.
        /// </summary>
        [RelationFille(typeof(CRelationTicket_Site), "Site")]
        [DynamicChilds("Tickets relations", typeof(CRelationTicket_Site))]
        public CListeObjetsDonnees RelationsTicketListe
        {
            get
            {
                return GetDependancesListeProgressive(CRelationTicket_Site.c_nomTable, c_champId);
            }
        }

		//---------------------------------------------
		/// <summary>
        /// Liste des <see cref="CIntervention">interventions</see> ayant eu lieu sur le site
		/// </summary>
		[RelationFille(typeof(CIntervention), "Site")]
		[DynamicChilds("Interventions", typeof(CIntervention))]
		public CListeObjetsDonnees Interventions
		{
			get
			{
				return GetDependancesListe(CIntervention.c_nomTable, CIntervention.c_champIdElementLie);
			}
		}



        //---------------------------------------------
        /// <summary>
        /// Liste des <see cref="CExtremiteLienSurSite">Extr�mit�s de lien</see> de ce site
        /// </summary>
        [RelationFille(typeof(CExtremiteLienSurSite), "Site")]
        [DynamicChilds("Links ends", typeof(CExtremiteLienSurSite))]
        public CListeObjetsDonnees ExtremitesDeLiens
        {
            get
            {
                return GetDependancesListe(CExtremiteLienSurSite.c_nomTable, c_champId);
            }
        }


        
        /////////////////////////////////// INTERFACES //////////////////////////////////////
		#region IObjetDonneeAChamps Membres

		//----------------------------------------------------
		public CRelationElementAChamp_ChampCustom GetNewRelationToChamp()
		{
			return new CRelationSite_ChampCustom(ContexteDonnee);
		}

		//----------------------------------------------------
		public string GetNomTableRelationToChamps()
		{
			return CRelationSite_ChampCustom.c_nomTable;
		}

		//----------------------------------------------------
		public CListeObjetsDonnees GetRelationsToChamps(int nIdChamp)
		{
			CListeObjetsDonnees liste = RelationsChampsCustom;
			liste.InterditLectureInDB = true;
			liste.Filtre = new CFiltreData(CChampCustom.c_champId + " = @1", nIdChamp);
			return liste;
		}


        /// <summary>
        /// Le symbole graphique de biblioth�que associ� au site (lorsqu'il existe).
        /// Ce symbole de biblioth�que peut �tre exploit� pour repr�senter le site
        /// dans les sch�mas de <see cref="CLienReseau">lien</see> ou de <see cref="CSchemaReseau">r�seau</see>
        /// </summary>
        [Relation(
            CSymboleDeBibliotheque.c_nomTable,
           CSymboleDeBibliotheque.c_champId,
          CSymboleDeBibliotheque.c_champId,
            false,
            false,
            false)]
        [DynamicField("Library Symbol")]
        public CSymboleDeBibliotheque SymboleDeBibliotheque
        {
            get
            {
                return (CSymboleDeBibliotheque)GetParent(CSymboleDeBibliotheque.c_champId, typeof(CSymboleDeBibliotheque));
            }
            set
            {
                if (SymbolePropre != null)
                {

                    SymbolePropre = null;
                }
                SetParent(CSymboleDeBibliotheque.c_champId, value);

            }

        }

        //------------------------------------------------
        /// <summary>
        /// Le symbole graphique propre au site, lorsqu'il existe.<br/>
        /// Ce symbole propre peut �tre exploit� pour repr�senter le site<br/>
        /// dans les sch�mas de <see cref="CLienReseau">lien</see> ou de <see cref="CSchemaReseau">r�seau</see>
        /// </summary>
        [RelationFille(typeof(CSymbole), "Site")]
        [DynamicField("Proper symbol")]
        public CSymbole SymbolePropre
        {

            get
            {
                CListeObjetsDonneesContenus liste = GetDependancesListe(CSymbole.c_nomTable, CSite.c_champId);
                if (liste.Count > 0)
                    return (CSymbole)liste[0];
                else
                    return null;
            }

            set
            {

                Row[CSymboleDeBibliotheque.c_champId] = null;
                if (value == null)
                {
                    if(SymbolePropre!=null)
                      SymbolePropre.Delete();
               }
                else
                {
                    value.Site = this;
                }
            }
        }

        //------------------------------------------------
        /// <summary>
        /// Symbole graphique utilis� pour repr�senter le site dans les sch�mas.
        /// Ce symbole est exploit� pour repr�senter le site
        /// dans les sch�mas de <see cref="CLienReseau">lien</see> ou de <see cref="CSchemaReseau">r�seau</see>.
        /// Le symbole exploit� est par ordre de priorit� descendante :
        /// Le symbole propre au site
        /// Le symbole de biblioth�que li� au site
        /// Le symbole affect� au type de site.
        /// </summary>
        [DynamicField("Symbol")]
        public CSymbole Symbole
        {
            get
            {
                if (SymbolePropre != null)
                    return SymbolePropre;
                if (SymboleDeBibliotheque != null)
                    return SymboleDeBibliotheque.Symbole;
                if (TypeSite != null)
                    return TypeSite.Symbole;
                return null;
            }

        }


        //------------------------------------------------
        public C2iSymbole SymboleADessiner
        {
            get
            {
                C2iSymbole symbole = null;
                if (Symbole != null)
                    symbole = Symbole.Symbole;
                if (symbole == null)
                    symbole = CSymbole.GetSymboleParDefaut(typeof(CSite), ContexteDonnee);
                if (symbole != null)
                {
                    symbole = symbole.GetCloneSymbole();
                    symbole.ElementASymbole = this;
                }
                return symbole;
            }
            
        }

        public C2iSymbole SymboleDefiniADessiner
        {
            get
            {
                return SymboleADessiner;
            }
            
        }



        //--------------------------------------
        public Type GetTypePourLequelOnSelectionneUnSymbole()
        {
            return typeof(CSite);
        }

		#endregion

		#region IElementAChamps Membres

		//----------------------------------------------------
		public IDefinisseurChampCustom[] DefinisseursDeChamps
		{
			get
			{
				return new IDefinisseurChampCustom[] { TypeSite };
			}
		}

		//----------------------------------------------------
		public CChampCustom[] GetChampsHorsFormulaire()
		{
			if (TypeSite == null)
				return new CChampCustom[0];

			ArrayList lst = new ArrayList();
			foreach (CRelationTypeSite_ChampCustom rel in TypeSite.RelationsChampsCustomDefinis)
				lst.Add(rel.ChampCustom);

            foreach (CRelationTypeSite_Formulaire rel1 in TypeSite.RelationsFormulaires)
                foreach (CRelationFormulaireChampCustom rel2 in rel1.Formulaire.RelationsChamps)
                    lst.Remove(rel2.Champ);
            
            return (CChampCustom[])lst.ToArray(typeof(CChampCustom));

		}

		//----------------------------------------------------
		public CFormulaire[] GetFormulaires()
		{
            return CUtilElementAChamps.GetFormulaires(this);
		}

		//----------------------------------------------------
        /// <summary>
        /// Liste des <see cref="CRelationSite_ChampCustom">relations du site avec des champs personnalis�s</see>
        /// </summary>
        [RelationFille(typeof(CRelationSite_ChampCustom), "ElementAChamps")]
        [DynamicChilds("Custom fields relations", typeof(CRelationSite_ChampCustom))]
        public CListeObjetsDonnees RelationsChampsCustom
		{
			get
			{
				return GetDependancesListe(CRelationSite_ChampCustom.c_nomTable, c_champId);
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

		#region IElementAEO Membres

		//-------------------------------------------------------------------
        /// <summary>
        /// Codes complets (Full_system_code) de toutes les <see cref="CEntiteOrganisationnelle">entit�s organisationnelles</see> auxquelles est affect� le site<br/>
        /// Ces codes sont pr�sent�s sous la forme d'une cha�ne de caract�res<br/>
        /// Chaque code est encadr� par deux caract�res ~ (exemple : ~01051B~0201~061A0304~)
        /// </summary>
		[TableFieldProperty(CUtilElementAEO.c_champEO, 500)]
		[DynamicField("Organisational entities codes")]
		public string CodesEntitesOrganisationnelles
		{
		    get
		    {
			    return (string)Row[CUtilElementAEO.c_champEO];
		    }
		    set
		    {
			    Row[CUtilElementAEO.c_champEO] = value;
		    }
		}

		//-------------------------------------------------------------------
        /// <summary>
        /// Rafra�chit les codes des entit�s organisationnelles de cet �l�ment
        /// </summary>
		[DynamicMethod("Refresh Organisational entities codes for this element")]
		public void RefreshCodesEOS()
		{
			CUtilElementAEO.UpdateEOs(this);
		}

		//-------------------------------------------------------------------
		public IElementAEO[] DonnateursEO
		{
			get
			{
				return new IElementAEO[] { SiteParent, TypeSite };
			}
		}

		//-------------------------------------------------------------------
		public IElementAEO[] HeritiersEO
		{
			get
			{
				ArrayList lst = new ArrayList();
				lst.AddRange(Equipements);
				lst.AddRange(Stocks);
				lst.AddRange(SitesFils);
				lst.AddRange(RessourcesDetenues);
                lst.AddRange(EquipementsLogiques);
				return (IElementAEO[])lst.ToArray(typeof(IElementAEO));
			}
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
        /// Attribue une nouvelle entit� organisationnelle � l'�l�ment
        /// </summary>
        /// <param name="nIdEO">Id de l'entit� organisationnelle</param>
        /// <returns>retourne un <see cref="CResultAErreur">r�sultat � erreur</see></returns>
        [DynamicMethod(
            "Asigne a new Organisationnal Entity to the Element",
            "The Organisationnal Entity Identifier")]
        public CResultAErreur AjouterEO(int nIdEO)
        {
            return CUtilElementAEO.AjouterEO(this, nIdEO);
        }

        //-----------------------------------------------------------------
        /// <summary>
        /// Ote de l'�l�ment une entit� organisationnelle
        /// </summary>
        /// <param name="nIdEO">Id de l'entit� � enlever</param>
        /// <returns>retourne le <see cref="CResultAErreur">r�sultat</see></returns>
        [DynamicMethod(
            "Remove an Organisationnal Entity from the Element",
            "The Organisationnal Entity Identifier")]
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


		#endregion

		#region IObjetARestrictionSurEntite Membres

		public void CompleteRestriction(CRestrictionUtilisateurSurType restriction)
		{
            CUtilElementAEO.CompleteRestriction(this, restriction);
		}

		#endregion

		//Coordonnees

		#region IObjetAFilsACoordonnees

		//---------------------------------------------------------------------
		public List<IObjetACoordonnees> FilsACoordonnees
		{
			get
			{
				List<IObjetACoordonnees> lst = new List<IObjetACoordonnees>();
				CListeObjetsDonnees equipements = Equipements;
				equipements.Filtre = new CFiltreData(CEquipement.c_champIdEquipementContenant + " is null");
				equipements.InterditLectureInDB = true;
				foreach (CEquipement equipement in equipements)
					lst.Add(equipement);
				foreach (CSite site in SitesFils)
					lst.Add(site);
				foreach (CStock stock in Stocks)
					lst.Add(stock);
				return lst;
			}
		}

		//---------------------------------------------------------------------
		public CResultAErreur IsCoordonneeValide(string strCoordonnee, IObjetACoordonnees objet)
		{
			return SObjetAvecFilsAvecCoordonnees.VerifieCoordonneeFils(this, objet, strCoordonnee);
		}

		//---------------------------------------------------------------------
		public CResultAErreur VerifieCoordonneesFils()
		{
			return SObjetAvecFilsAvecCoordonnees.VerifieCoordonneesFils(this);
		}

		#endregion

		#region IObjetASystemeDeCoordonnee

		//---------------------------------------------------------------------
		/// <summary>
        /// <see cref="CParametrageSystemeCoordonnees">Syst�me de coordonn�es</see> appliqu� au site. 
        /// Le Syst�me de coordonn�es peut �tre h�rit� ou d�fini par le Site lui-m�me (Syst�me propre). 
        /// Cette propri�t� indique quel est le Syst�me appliqu� au Site: Le Syst�me h�rit� ou le Syst�me propre.
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

		//---------------------------------------------------------------------
		public IObjetASystemeDeCoordonnee DonnateurParametrageCoordonneeHerite
		{
			get 
			{
				return TypeSite;
			}
		}

		//---------------------------------------------------------------------
        /// <summary>
        /// Retourne le <see cref="CParametrageSystemeCoordonnees">Syst�me de coordonn�es</see> propre au Site
        /// </summary>
		[DynamicField("Own coordinate system")]
		public CParametrageSystemeCoordonnees ParametrageCoordonneesPropre
		{
			get 
			{
				CListeObjetsDonnees liste = GetDependancesListe(CParametrageSystemeCoordonnees.c_nomTable, c_champId);
				if (liste.Count == 1)
					return (CParametrageSystemeCoordonnees)liste[0];
				return null;
			}
		}

		//---------------------------------------------------------------------
		public bool CanHeriteParametrageCoordonnees
		{
			get { return IsNew(); }
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

		#region IObjetAOptionsDeControleDeCoordonnees

		//---------------------------------------------------------------------
		public EOptionControleCoordonnees? OptionsDisponibles
		{
			get
			{
				return EOptionControleCoordonnees.AutoriserPlusieursFilsSurLaMemeCoordonnee |
					EOptionControleCoordonnees.IgnorerLesFilsSansCoordonnees |
					EOptionControleCoordonnees.IgnorerLesUnites |
					EOptionControleCoordonnees.IgnorerLoccupation |
                    EOptionControleCoordonnees.IgnorerLesEquipements |
                    EOptionControleCoordonnees.IgnorerLesStocks | 
                    EOptionControleCoordonnees.IgnorerLesSites | 
					EOptionControleCoordonnees.TousControles;
			}
		}

		//---------------------------------------------------------------------
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

		//---------------------------------------------------------------------
		public IObjetAOptionsDeControleDeCoordonnees DonnateurOptionsControleCoordonneesHerite
		{
			get
			{
				return null;
			}
		}

		//------------------------------------------------------------------
		[TableFieldProperty(c_champOptionsControleCoordonnees, NullAutorise = true)]
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


		//---------------------------------------------------------------------
		public bool CanHeriteOptionsControleCoordonnees
		{
			get { return IsNew(); }
		}

		#endregion

		#region IObjetACoordonnees
		//////////////////////////////////////////////////////////////////////////
        //-------------------------------------------------------
        /// <summary>
        /// <see cref="CEntiteOrganisationnelle">Entit�s organisationnelles</see> d�finissant le syst�me de coordonn�es
        /// </summary>
		[RelationAttribute(
		 CEntiteOrganisationnelle.c_nomTable,
		 CEntiteOrganisationnelle.c_champId,
			CSite.c_champEOCoor,
			false,
			false,
			false)]
		[DynamicField("Organisational entity for Coordinate")]
		public CEntiteOrganisationnelle EOdeCoordonnee
		{
			get { return (CEntiteOrganisationnelle)GetParent(CSite.c_champEOCoor, typeof(CEntiteOrganisationnelle)); }
			set { SetParent(CSite.c_champEOCoor, value); }
		}


		//---------------------------------------------
        /// <summary>
        /// Coordonn�e du site
        /// </summary>
		[TableFieldProperty(c_champCoordonnee, 255 )]
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
        /// Coordonn�e compl�te du site (coordonn�e propre du site
        /// concat�n�e avec celle(s) du(des) site(s) parent(s))
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
        /// Coordonn�e compl�te du site parent
        /// </summary>
		[DynamicField("Parent Coordinate")]
		public string CoordonneeParente
		{
			get
			{
				if (SiteParent != null && (SiteParent.Coordonnee != "" && SiteParent.Coordonnee != null))
					return SiteParent.CoordonneeComplete;
				else if (SiteParent != null && (SiteParent.Coordonnee != "" && SiteParent.Coordonnee != null))
					return SiteParent.CoordonneeComplete;
				else if (EOdeCoordonnee != null && (EOdeCoordonnee.Coordonnee != "" && EOdeCoordonnee.Coordonnee != null))
					return EOdeCoordonnee.CoordonneeComplete;
				else
					return "";

			}
		}


		//---------------------------------------------------------------------
		public bool IgnorerUnite
		{
			get { return true; }
		}

		//---------------------------------------------------------------------
		public IObjetAFilsACoordonnees ConteneurFilsACoordonnees
		{
			get 
			{
				if (SiteParent != null && SiteParent.ParametrageCoordonneesApplique != null)
					return SiteParent;
				else
					return EOdeCoordonnee;
	
			}
		}

		//---------------------------------------------------------------------
		public CResultAErreur VerifieCoordonnee()
		{
			IObjetAFilsACoordonnees parent = ConteneurFilsACoordonnees;
			if (parent != null)
				return parent.IsCoordonneeValide(Coordonnee, this);
			return CResultAErreur.True;
		}

		#endregion

		#region IObjetAOccupation

		//---------------------------------------------------------------------
		public COccupationCoordonnees OccupationCoordonneeAppliquee
		{
			get 
			{
				return OccupationCoordonneesPropre;
			}
		}

		//---------------------------------------------------------------------
		public IObjetAOccupation DonnateurOccupationCoordonneeHerite
		{
			get { return null; }
		}

		//---------------------------------------------------------------------
		public COccupationCoordonnees OccupationCoordonneesPropre
		{
			get
			{
				return new COccupationCoordonnees(1, null);
			}
			set
			{
			}
		}

		//---------------------------------------------------------------------
		public bool CanHeriteOccupationCoordonnees
		{
			get { return false; }
		}

		#endregion

		#region IElementATableParametrable
		/// <summary>
        /// Liste des <see cref="CTableParametrable">tables param�trables</see> li�es au site
		/// </summary>
		[RelationFille(typeof(CTableParametrable), "Site")]
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
				if (TypeSite == null)
					return new CListeObjetsDonnees(ContexteDonnee, typeof(CTableParametrable), filtre);

				CListeObjetsDonnees rels = TypeSite.RelationsTypesTableParametrables;

				if (rels.CountNoLoad == 0)
					return new CListeObjetsDonnees(ContexteDonnee, typeof(CTableParametrable), filtre);

				string strIdsTypesPoss = "";				
				foreach (CRelationTypeSite_TypeTableParametrable r in rels)
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
				
				if (TypeSite == null)
					return new CListeObjetsDonnees(ContexteDonnee, typeof(CTypeTableParametrable),filtre);
				CListeObjetsDonnees rels = TypeSite.RelationsTypesTableParametrables;

				if(rels.CountNoLoad == 0)
					return new CListeObjetsDonnees(ContexteDonnee, typeof(CTypeTableParametrable),filtre);
				
				string strIdsTypesPoss = "";
				foreach (CRelationTypeSite_TypeTableParametrable r in rels)
					strIdsTypesPoss += r.TypeTableParametrable.Id + ",";

				strIdsTypesPoss = strIdsTypesPoss.Substring(0, strIdsTypesPoss.Length - 1);
				filtre = new CFiltreDataAvance(CTypeTableParametrable.c_nomTable, CTypeTableParametrable.c_champId + " IN (" + strIdsTypesPoss + ")");

				return new CListeObjetsDonnees(ContexteDonnee, typeof(CTypeTableParametrable), filtre);
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

		#region IElementATypeStructurant<CTypeSite> Membres

		public CTypeSite ElementStructurant
		{
			get { return TypeSite; }
		}

		public int IdTypeStructurant
		{
			get
			{
				return (int)Row[CTypeSite.c_champId];
			}
		}
		#endregion

		#region IElementACaracteristique Membres

		public CListeObjetsDonnees Caracteristiques
		{
			get
			{
				return CCaracteristiqueEntite.GetCaracteristiques(this);
			}
		}

		#endregion

        #region IElementALien Membres

        /// <summary>
        /// Tableau des <see cref="CLienReseau">liens r�seau</see> auxquels le site appartient
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
        /// Liste des <see cref="CLienReseau">liens r�seau</see> auxquels le site appartient
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

                liste = new CListeObjetsDonnees(ContexteDonnee,typeof(CLienReseau),filtre);
                return liste;
            }

        }


        /// <summary>
        /// Liste des <see cref="CStock">liens r�seau</see> auxquels le site appartient en tant que site N�1 
        /// </summary>
        [RelationFille(typeof(CLienReseau), "Site1")]
        [DynamicChilds("Link as site 1", typeof(CLienReseau))]
        public CListeObjetsDonnees LiensEnTantQuelement1
        {
            get
            {
                return GetDependancesListe(CLienReseau.c_nomTable, CLienReseau.c_champSite1);
            }
        }

        /// <summary>
        /// Liste des <see cref="CStock">liens r�seau</see> auxquels le site appartient en tant que site N�2 
        /// </summary>
        [RelationFille(typeof(CLienReseau), "Site2")]
        [DynamicChilds("Link as site 2", typeof(CLienReseau))]
        public CListeObjetsDonnees LiensEnTantQuelement2
        {
            get
            {
                return GetDependancesListe(CLienReseau.c_nomTable, CLienReseau.c_champSite2);
            }
        }


        /// <summary>
        /// Tableau des <see cref="CStock">liens r�seau</see> auxquels le site appartient en tant que site entrant 
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
        /// Tableau des <see cref="CStock">liens r�seau</see> auxquels le site appartient en tant que site sortant 
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

       
        public IComplementElementALiensReseau[] ComplementsPossibles
        {
            get
            {
                return (IComplementElementALiensReseau[])ExtremitesDeLiens.ToArray(typeof(IComplementElementALiensReseau));
            }
        }

        public Type TypeComplement
        {
            get
            {
                return typeof(CExtremiteLienSurSite);
            }
        }


        public Type TypeElement
        {
            get
            {
                return typeof(CSite);
            }
        }


        #endregion

        #region IElementDeSchemaReseau Membres


        public C2iObjetDeSchema GetObjetDeSchema(CElementDeSchemaReseau elementDeSchema)
        {
            C2iObjetDeSchema objet = new C2iObjetDeSchema();
            C2iSymbole symbole = SymboleADessiner;
            objet.ElementDeSchema = elementDeSchema;
            return objet;
        }


        //---------------------------------------------
        /// <summary>
        /// Liste des <see cref="CElementDeSchemaReseau">�l�ments de sch�ma r�seau</see> auxquels le site appartient
        /// </summary>
        [RelationFille(typeof(CElementDeSchemaReseau), "Site")]
        [DynamicChilds("Associated network elements", typeof(CElementDeSchemaReseau))]
        public CListeObjetsDonnees ElementsDeSchema
        {
            get
            {
                return GetDependancesListe(CElementDeSchemaReseau.c_nomTable, c_champId);
            }
        }

        #endregion



        #region IElementAVuePhysique Membres

        public CVuePhysique VuePhysique
        {
            get {
                CVuePhysique vue = new CVuePhysique(ContexteDonnee);
                if ( vue.ReadIfExists ( new CFiltreData ( CSite.c_champId+"=@1",
                    Id ) ))
                    return vue;
                return null;
            }
        }

        public CVuePhysique GetVuePhysiqueAvecCreation()
        {
            CVuePhysique vue = VuePhysique;
            if (vue == null)
            {
                vue = new CVuePhysique(ContexteDonnee);
                vue.CreateNewInCurrentContexte();
                vue.SiteAssocie = this;
                vue.CodeFacePrincipale = (int)EFaceVueDynamique.Top;
            }
            return vue;
        }

        #endregion

        //-------------------------------------------------------------
        public C2iComposant3D GetComposantPhysique()
        {
            return null;
        }

        //---------------------------------------------
        /// <summary>
        /// Liste des relations <see cref="CContrat_Site">contrat de maintenance/site</see> dans lesquelles figurent le site
        /// </summary>
        [RelationFille(typeof(CContrat_Site), "Site")]
        [DynamicChilds("Related site/contract", typeof(CContrat_Site))]
        public CListeObjetsDonnees ContratSites
        {
            get
            {
                return GetDependancesListe(CContrat_Site.c_nomTable, c_champId);
            }
        }

        //-------------------------------------------------------------
        /// <summary>
        /// Retourne un tableau des relations <see cref="CTypeTicketContrat">type de ticket / contrat</see>, valides
        /// pour la date pass�e en param�tre; pour qu'une telle relation soit dite
        /// 'valide', il faut que sa p�riode de validit� englobe la date pass�e en param�tre.
        /// </summary>
        /// <param name="dt">Date</param>
        /// <returns></returns>
        [DynamicMethod("Returns all activated contract/ticket type for a date","Date to test")]
        public CTypeTicketContrat[] GetAllContractTicket ( DateTime dt )
        {
            CListeObjetsDonnees lst = new CListeObjetsDonnees ( ContexteDonnee, typeof(CTypeTicketContrat) );
            lst.Filtre = new CFiltreDataAvance ( CTypeTicketContrat.c_nomTable,
                CTypeTicketContrat_Site.c_nomTable+"."+
                CContrat_Site.c_nomTable+"."+
                CSite.c_champId+"=@1 and "+
                CTypeTicketContrat_Site.c_nomTable+"."+
                CTypeTicketContrat_Site_Periode.c_nomTable+"."+
                CTypeTicketContrat_Site_Periode.c_champDateDebut+"<=@2 and "+
                CTypeTicketContrat_Site.c_nomTable+"."+
                CTypeTicketContrat_Site_Periode.c_nomTable+"."+
                CTypeTicketContrat_Site_Periode.c_champDateFin+">=@2",
                Id,
                dt );
            return (CTypeTicketContrat[])lst.ToArray(typeof(CTypeTicketContrat));
        }

        //---------------------------------------------
        /// <summary>
        /// Liste des <see cref="CEntiteSnmp">entit�s SNMP</see> en rapport avec le site
        /// </summary>
        [RelationFille(typeof(CEntiteSnmp), "SiteSupervise")]
        [DynamicChilds("Snmp entities", typeof(CEntiteSnmp))]
        public CListeObjetsDonnees EntitesSnmp
        {
            get
            {
                return GetDependancesListe(CEntiteSnmp.c_nomTable, c_champId);
            }
        }


        
    }
}
