using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;
using sc2i.process;
using tiag.client;
using sc2i.expression;

namespace timos.data
{

    /// <summary>
    /// Le Type de Ticket permet de définir, pour les <see cref="CTicket">tickets</see> de ce type:
    /// <ul>
    /// <li>Les formulaires personnalisés à associer</li>
    /// <li>Les <see cref="CPhaseTicket">phases</see> à respecter ainsi que leurs enchaînements</li>
    /// <li>Les <see cref="CContrat">contrats</see> de maintenance associés</li>
    /// </ul>
	/// </summary>
	[DynamicClass("Ticket type")]
	[Table(CTypeTicket.c_nomTable, CTypeTicket.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CTypeTicketServeur")]
    [Unique(true, "This Ticket Type Label already exist|220", CTypeTicket.c_champLibelle)]
    [AutoExec("Autoexec")]
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iTicket)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersCorrectives_ID)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_ParamTickets_ID)]
    [TiagClass(CTypeTicket.c_nomTiag, "Id", true)]
    public class CTypeTicket : CObjetDonneeAIdNumeriqueAuto,
                                IObjetALectureTableComplete,
                                IDefinisseurChampCustomRelationObjetDonnee,
		                        IDefinisseurEvenements,
								IObjetDonneeAChamps
        
                                
	{
        public const string c_nomTiag = "Ticket Type";
        public const string c_nomTable = "TICKET_TYPE";
		
		public const string c_champId = "TKTTYP_ID";
		public const string c_champLibelle = "TKTTYP_LABEL";
        public const string c_champCode = "TKTTYP_CODE";

        public const string c_roleChampCustom = "TICKET_TYPE";

		/// /////////////////////////////////////////////
		public CTypeTicket( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	    /// /////////////////////////////////////////////
		public CTypeTicket(DataRow row )
			:base(row)
		{
		}

        //-------------------------------------------------------------------
        public static void Autoexec()
        {
            CRoleChampCustom.RegisterRole(c_roleChampCustom, "Ticket type", typeof(CTypeTicket), typeof(CDefinisseurChampsPourTypeSansDefinisseur));
        }

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T( "Ticket Type|219 ")+": "+Libelle;
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champLibelle};
		}

		

		/////////////////////////////////////////////
        /// <summary>
        /// Le Libellé du Type de Ticket
        /// </summary>
		[TableFieldProperty(c_champLibelle, 100)]
		[DynamicField("Label")]
        [DescriptionField]
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

        
		//-----------------------------------------------------------
		/// <summary>
		/// Le code du type de ticket
		/// </summary>
		[TableFieldProperty ( c_champCode, 128 )]
		[DynamicField("Code")]
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


        //---------------------------------------------
        /// <summary>
        /// Donne la liste des relations avec les <see cref="CContrat">Contrats Clients</see> associés.
        /// </summary>
        [RelationFille(typeof(CTypeTicketContrat), "TypeTicket")]
        [DynamicChilds("Contracts", typeof(CTypeTicketContrat))]
        public CListeObjetsDonnees RelationsContratsListe
        {
            get
            {
                return GetDependancesListe(CTypeTicketContrat.c_nomTable, c_champId);
            }
        }


		//---------------------------------------------
		/// <summary>
		/// Donne la liste des relations avec les Types de Phases qui font partie du processus de résolution défini 
        /// par le Type de Ticket
		/// </summary>
		[RelationFille(typeof(CTypeTicket_TypePhase), "TypeTicket")]
		[DynamicChilds("Phase types relations", typeof(CTypeTicket_TypePhase))]
		public CListeObjetsDonnees RelationsTypesPhases
		{
			get
			{
				return GetDependancesListe(CTypeTicket_TypePhase.c_nomTable, c_champId);
			}
		}

		//---------------------------------------------------------------------------
		public CTypePhase[] TypePhasesDemarrage
		{
			get
			{
				List<CTypePhase> liste = new List<CTypePhase>();
				foreach (CTypeTicket_TypePhase rel in RelationsTypesPhases)
					if (rel.IsPointEntree)
						liste.Add(rel.TypePhase);
				return liste.ToArray();
			}
		}

        //----------------------------------------------------------------------------
        public CTypePhase[] TypePhasesFin
        {
            get
            {
                List<CTypePhase> liste = new List<CTypePhase>();
                foreach (CTypeTicket_TypePhase rel in RelationsTypesPhases)
                    if (rel.IsPointSortie)
                        liste.Add(rel.TypePhase);
                return liste.ToArray();
            }
        }



        #region IDefinisseurChampCustomRelationObjetDonnee Membres

		//----------------------------------------------------------------------
        [RelationFille(typeof(CRelationTypeTicket_ChampCustom), "Definisseur")]
        public CListeObjetsDonnees RelationsChampsCustomListe
        {
            get
            {
                return GetDependancesListe(CRelationTypeTicket_ChampCustom.c_nomTable, c_champId);
            }
        }
		//----------------------------------------------------------------------
        [RelationFille(typeof(CRelationTypeTicket_Formulaire), "Definisseur")]
        public CListeObjetsDonnees RelationsFormulairesListe
        {
            get
            {
                return GetDependancesListe(CRelationTypeTicket_Formulaire.c_nomTable, c_champId);
            }
        }

        #endregion

        #region IDefinisseurChampCustom Membres


		//----------------------------------------------------------------------
        public IRelationDefinisseurChamp_ChampCustom[] RelationsChampsCustomDefinis
        {
			get 
            {
                return (IRelationDefinisseurChamp_ChampCustom[])
                    RelationsChampsCustomListe.ToArray(typeof(IRelationDefinisseurChamp_ChampCustom));
            }
        }

		//----------------------------------------------------------------------
        public IRelationDefinisseurChamp_Formulaire[] RelationsFormulaires
        {
            get
            {
                return (IRelationDefinisseurChamp_Formulaire[])
                    RelationsFormulairesListe.ToArray(typeof(IRelationDefinisseurChamp_Formulaire));
            }
        }

		//----------------------------------------------------------------------
        public CRoleChampCustom RoleChampCustomDesElementsAChamp
        {
            get
            {
                return CRoleChampCustom.GetRole(CTicket.c_roleChampCustom);
            }
        }

        //----------------------------------------------------------------------
        public CRoleChampCustom RoleChampCustomAssocie
        {
            get
            {
                return CRoleChampCustom.GetRole(CTypeTicket.c_roleChampCustom);
            }
        }

		//----------------------------------------------------------------------
        public CChampCustom[] TousLesChampsAssocies
        {
            get
            {
                Hashtable tableChamps = new Hashtable();
                FillHashtableChamps(tableChamps);
                CChampCustom[] liste = new CChampCustom[tableChamps.Count];
                int nChamp = 0;
                foreach (CChampCustom champ in tableChamps.Values)
                    liste[nChamp++] = champ;
                return liste;
            }
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// Remplit une hashtable IdChamp->Champ
        /// avec tous les champs liés.(hiérarchique)
        /// </summary>
        /// <param name="tableChamps">HAshtable à remplir</param>
        private void FillHashtableChamps(Hashtable tableChamps)
        {
            foreach (IRelationDefinisseurChamp_ChampCustom relation in RelationsChampsCustomDefinis)
                tableChamps[relation.ChampCustom.Id] = relation.ChampCustom;
            foreach (IRelationDefinisseurChamp_Formulaire relation in RelationsFormulaires)
            {
                foreach (CRelationFormulaireChampCustom relFor in relation.Formulaire.RelationsChamps)
                    tableChamps[relFor.Champ.Id] = relFor.Champ;
            }
        }

        #endregion

        #region IDefinisseurEvenements Membres

        public CComportementGenerique[] ComportementsInduits
        {
            get
            {
                return CUtilDefinisseurEvenement.GetComportementsInduits(this);
            }
        }

        public CListeObjetsDonnees Evenements
        {
            get
            {
                return CUtilDefinisseurEvenement.GetEvenementsFor(this);
            }
        }

        public Type[] TypesCibleEvenement
        {
            get
            {
                return new Type[] { typeof(CTicket) };
            }
        }

        #endregion


        // Implémentation des champs custom sur le Type de Ticket
        #region IObjetDonneeAChamps Membres

        //----------------------------------------------------
        public CRelationElementAChamp_ChampCustom GetNewRelationToChamp()
        {
            return new CRelationTypeTicket_ChampCustomValeur(ContexteDonnee);
        }

        //----------------------------------------------------
        public string GetNomTableRelationToChamps()
        {
            return CRelationTypeTicket_ChampCustomValeur.c_nomTable;
        }

        //----------------------------------------------------
        public CListeObjetsDonnees GetRelationsToChamps(int nIdChamp)
        {
            CListeObjetsDonnees liste = RelationsChampsCustom;
            liste.InterditLectureInDB = true;
            liste.Filtre = new CFiltreData(CChampCustom.c_champId + " = @1", nIdChamp);
            return liste;
        }
        #endregion

        #region IElementAChamps Membres

        //----------------------------------------------------------------------------------
        public IDefinisseurChampCustom[] DefinisseursDeChamps
        {
            get
            {
                ArrayList definisseurs = new ArrayList();
                definisseurs.Add(new CDefinisseurChampsPourTypeSansDefinisseur(this.ContexteDonnee, 
                    CRoleChampCustom.GetRole ( c_roleChampCustom )));

                return (IDefinisseurChampCustom[])definisseurs.ToArray(typeof(IDefinisseurChampCustom));
            }
        }

        //----------------------------------------------------------------------------------
        public CChampCustom[] GetChampsHorsFormulaire()
        {
            return new CChampCustom[0];
        }

        //-------------------------------------------------------------------------------------
        public CFormulaire[] GetFormulaires()
        {
            List<CFormulaire> lstFormulaires = new List<CFormulaire>();

            foreach (IDefinisseurChampCustom definisseur in DefinisseursDeChamps)
            {
                foreach (IRelationDefinisseurChamp_Formulaire relation in definisseur.RelationsFormulaires)
                {
                    lstFormulaires.Add(relation.Formulaire);
                }
            }

            return lstFormulaires.ToArray();
        }

        //-----------------------------------------------------------------------------------
        /// <summary>
        /// Donne la liste des relations avec les valeurs de champs personnalisés
        /// </summary>
        [RelationFille(typeof(CRelationTypeTicket_ChampCustomValeur), "ElementAChamps")]
        [DynamicChilds("Custom fields relations", typeof(CRelationTypeTicket_ChampCustomValeur))]
        public CListeObjetsDonnees RelationsChampsCustom
        {
            get
            {
                return GetDependancesListe(CRelationTypeTicket_ChampCustomValeur.c_nomTable, c_champId);
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



    }

   
}
