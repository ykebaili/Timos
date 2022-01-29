using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using timos.securite;
using timos.acteurs;

namespace timos.data
{
	/// <summary>
	/// Le mouvement d'un <see cref="CEquipement">équipement</see> est, par cette
	/// entité, sauvegardé pour en concerver une trace.<br/>
	/// Vous pourrez donc garder tracer des informations majeures du mouvement tel
	/// que la date, l'auteur, l'emplacement d'origine et de destination.<br/><br/>
	/// La notion de quantité existe dans les mouvements d'équipement; vous pourrez
	/// donc spécifier le nombre d'equipement concerné par ce mouvement.
	/// </summary>
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iEquipement)]
    [DynamicClass("Equipment movement")]
	[Table(CMouvementEquipement.c_nomTable, CMouvementEquipement.c_champId, true)]
	[FullTableSync]
	[ObjetServeurURI("CMouvementEquipementServeur")]
    [NoMacro]
	public class CMouvementEquipement :
		CObjetDonneeAIdNumeriqueAuto,
        IObjetDonneeAutoReference, IObjetSansVersion
	{
		public const string c_nomTable = "EQUIPEMENT_MOVEMENT";

		public const string c_champId = "EQTMOV_ID";
		public const string c_champInfo = "EQTMOV_INFO";
		public const string c_champDateMouvement = "EQTMOV_MVT_DATE";
		public const string c_champIdEquipementOrigine = "EQTMOV_SOURCE_EQT_ID";
		public const string c_champCoordonneeOrigine = "EQTMOV_SOURCE_COORDINATE";
		public const string c_champOccupationOrigine = "EQTMOV_SOURCE_OCCUPATION";
        public const string c_champCodeCause = "EQTMOV_CAUSE_CODE";
        public const string c_champIdMouvementSuivant = "EQTMOV_NEXT_MVT_ID";
        public const string c_champNumeroMouvement = "EQTMOV_NUM";
		

		/// /////////////////////////////////////////////
		public CMouvementEquipement(CContexteDonnee contexte)
			: base(contexte)
		{
		}

		/// /////////////////////////////////////////////
		public CMouvementEquipement(DataRow row)
			: base(row)
		{
		}

		/// /////////////////////////////////////////////
        [DescriptionField]
        public override string DescriptionElement
		{
			get
			{
				return I.T( "The equipment movement @1|112", Info);
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
			DateMouvement = DateTime.Now;
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] { c_champNumeroMouvement+" desc,"+c_champId+" desc" };
		}

		/// /////////////////////////////////////////////
        /// <summary>
        /// Commentaire pour fournir des indications complémentaires concernant le mouvement
        /// </summary>
		[TableFieldProperty(c_champInfo, 1024)]
		[DynamicField("Info")]
		[RechercheRapide]
		public string Info
		{
			get
			{
				return (string)Row[c_champInfo];
			}
			set
			{
				Row[c_champInfo] = value;
			}
		}

		//---------------------------------------------
        /// <summary>
        /// Date auquelle le mouvement a eu lieu
        /// </summary>
		[TableFieldProperty(CMouvementEquipement.c_champDateMouvement)]
		[DynamicField("Movement date")]
		public DateTime DateMouvement
		{
			get
			{
				return (DateTime)Row[c_champDateMouvement];
			}
			set
			{
				Row[c_champDateMouvement] = value;
			}
		}

		//---------------------------------------------
		/// <summary>
        /// <see cref="CEquipement">Equipement</see> auquel correspond ce déplacement
		/// </summary>
		[Relation(
			CEquipement.c_nomTable,
			CEquipement.c_champId,
			CEquipement.c_champId,
			true,
			false,
			true)]
		[DynamicField("Moved equipment")]
		public CEquipement EquipementDeplace
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

		//---------------------------------------------
		/// <summary>
        /// <see cref="CSite">Site</see> sur lequel se trouvait l'équipement, avant son déplacement<br/>
        /// (si l'équipement était sur un site)
		/// </summary>
		[Relation(
			CSite.c_nomTable,
			CSite.c_champId,
			CSite.c_champId,
			false,
			false,
			false)]
		[DynamicField("Original site")]
		public CSite SiteOrigine
		{
			get
			{
				return (CSite)GetParent(CSite.c_champId, typeof(CSite));
			}
			set
			{
				if (value != null)
					EmplacementOrigine = value;
				else
					SetParent(CSite.c_champId, value);
			}
		}

		//---------------------------------------------
        /// <summary>
        /// <see cref="CStock">Stock</see> sur lequel se trouvait l'équipement, avant son déplacement<br/>
        /// (si l'équipement était sur un stock)
        /// </summary>
		[Relation(
			CStock.c_nomTable,
			CStock.c_champId,
			CStock.c_champId,
			false,
			false)]
		[DynamicField("Original stock")]
		public CStock StockOrigine
		{
			get
			{
				return (CStock)GetParent(CStock.c_champId, typeof(CStock));
			}
			set
			{
				if (value != null)
					EmplacementOrigine = value;
				else
					SetParent(CStock.c_champId, value);
			}
		}

		//---------------------------------------------
		/// <summary>
        /// <see cref="CActeur">Acteur</see> qui détenait l'équipement, avant son déplacement<br/>
        /// (si l'équipement était détenu par un acteur)
		/// </summary>
		[Relation(
			CActeur.c_nomTable,
			CActeur.c_champId,
			CActeur.c_champId,
			false,
			false,
			false)]
		[DynamicField("Original actor")]
		public CActeur ActeurOrigine
		{
			get
			{
				return (CActeur)GetParent(CActeur.c_champId, typeof(CActeur));
			}
			set
			{
				if (value != null)
					EmplacementOrigine = value;
				else
					SetParent(CActeur.c_champId, value);
			}
		}

		//---------------------------------------------
        /// <summary>
        /// <see cref="CActeur">Emplacement origine</see> de l'équipement, avant son déplacement<br/>
        /// Suivant le cas, cet emplacement est un <see cref="CSite">site</see> ou un <see cref="CStock">stock</see> ou un <see cref="CActeur">acteur</see>
        /// </summary>
		[DynamicField("Original place")]
		public IEmplacementEquipement EmplacementOrigine
		{
			get
			{
				IEmplacementEquipement emplacement = SiteOrigine;
				if (emplacement == null)
					emplacement = StockOrigine;
				if (emplacement == null)
					emplacement = ActeurOrigine;
				return emplacement;
			}
			set
			{
				if (value is CSite)
					SetParent(CSite.c_champId, (CObjetDonnee)value);
				if (value is CStock)
					SetParent(CStock.c_champId, (CObjetDonnee)value);
				if (value is CActeur)
					SetParent(CActeur.c_champId, (CObjetDonnee)value);
				if (value != null)
				{
					if (!(value is CSite))
						SiteOrigine = null;
					if (!(value is CStock))
						StockOrigine = null;
					if (!(value is CActeur))
						ActeurOrigine = null;
				}
			}
		}


		//---------------------------------------------
		/// <summary>
		/// Equipement conteneur dans lequel se trouvait l'équipement avant son déplacement<br/>
        /// (dans le cas où l'équipement était inclus dans un autre)
		/// </summary>
		[Relation(
			CEquipement.c_nomTable,
			CEquipement.c_champId,
			CMouvementEquipement.c_champIdEquipementOrigine,
			false,
			false,
			false)]
		[DynamicField("Original equipment")]
		public CEquipement EquipementOrigine
		{
			get
			{
				return (CEquipement)GetParent(c_champIdEquipementOrigine, typeof(CEquipement));
			}
			set
			{
				SetParent(c_champIdEquipementOrigine, value);
			}
		}

		//---------------------------------------------
		/// <summary>
        /// <see cref="CDonneesActeurUtilisateur">Utilisateur</see> ayant fait le mouvement
		/// </summary>
		[Relation(
			CDonneesActeurUtilisateur.c_nomTable,
			CDonneesActeurUtilisateur.c_champId,
			CDonneesActeurUtilisateur.c_champId,
			false,
			false,
			false)]
		[DynamicField("User")]
		public CDonneesActeurUtilisateur Utilisateur
		{
			get
			{
				return (CDonneesActeurUtilisateur)GetParent(CDonneesActeurUtilisateur.c_champId, typeof(CDonneesActeurUtilisateur));
			}
			set
			{
				SetParent(CDonneesActeurUtilisateur.c_champId, value);
			}
		}

		//-----------------------------------------------------------
		/// <summary>
		/// Coordonnée de l'équipement avant son déplacement
		/// </summary>
		[TableFieldProperty ( c_champCoordonneeOrigine, 255)]
		[DynamicField("Original coordinate")]
		public string CoordonneeOrigine
		{
			get
			{
				return (string)Row[c_champCoordonneeOrigine];
			}
			set
			{
				Row[c_champCoordonneeOrigine] = value;
			}
		}

		//-----------------------------------------------------------
		/// <summary>
		/// Nombre d'unités qu'occupait l'équipement avant son déplacement
		/// </summary>
		[TableFieldProperty ( c_champOccupationOrigine, NullAutorise = true)]
		[DynamicField("Original units number")]
		public int? NbUnitesOrigine
		{
			get
			{
				return (int?)Row[c_champOccupationOrigine,true];
			}
			set
			{
				Row[c_champOccupationOrigine,true] = value;
			}
		}

        //-----------------------------------------------------------
        /// <summary>
        /// Permet d'indiquer sous forme d'un codage texte<br/>
        /// des informations sur le mouvement.<br/>
        /// Ces informations pourront être utilisées<br/>
        /// par des process ou des formules pour identifier la<br/>
        /// cause, ou le fait déclencheur du mouvement<br/>
        /// </summary>
        [TableFieldProperty(c_champCodeCause, 1024)]
        [DynamicField("Cause code")]
        public string CodeCause
        {
            get
            {
                return (string)Row[c_champCodeCause];
            }
            set
            {
                Row[c_champCodeCause] = value;
            }
        }



		//-------------------------------------------------------------------
		/// <summary>
		/// Unité de coordonnée utilisée au niveau de l'équipement avant son déplacement
		/// </summary>
		[Relation  (
			CUniteCoordonnee.c_nomTable,
			CUniteCoordonnee.c_champId,
		   	CUniteCoordonnee.c_champId,
			false, 
			false, 
			true)]
		[DynamicField("Original unit")]
		public CUniteCoordonnee UniteOrigine
		{
			get
			{
				return (CUniteCoordonnee)GetParent(CUniteCoordonnee.c_champId, typeof(CUniteCoordonnee));
			}
			set
			{
				SetParent(CUniteCoordonnee.c_champId, value);
			}
		}

		//---------------------------------------------
		public COccupationCoordonnees OccupationOrigine
		{
			get
			{
				if ( NbUnitesOrigine != null )
					return new COccupationCoordonnees ( (int)NbUnitesOrigine, UniteOrigine );
				return null;
			}
			set
			{
				if ( value != null )
				{
					NbUnitesOrigine = value.NbUnitesOccupees;
					UniteOrigine = value.Unite;
				}
				else
				{
					NbUnitesOrigine = null;
					UniteOrigine = null;
				}
			}
		}



		//---------------------------------------------
		/// <summary>
		/// Génère un mouvement qui annule celui-ci
		/// </summary>
		/// <returns></returns>
		public CResultAErreur AnnuleDeplacement()
		{
			CResultAErreur result = CResultAErreur.True;
			CMouvementEquipement mouvement = this;

			mouvement.BeginEdit();
			try
			{
				CListeObjetsDonnees mvts = EquipementDeplace.Mouvements;
				mvts.Tri = c_champDateMouvement;
				if (!mvts[mvts.Count - 1].Equals(mouvement))
				{
					result.EmpileErreur(I.T("Impossible to cancel the movement of the equipment '@1' because it is not the last movement of this equipment|30036", EquipementDeplace.Libelle));
					return result;
				}

			
				result = EquipementDeplace.DeplaceEquipement ( 
					"Annulation du mouvement précédent",
					EmplacementOrigine,
					EquipementOrigine,
					CoordonneeOrigine,
					OccupationOrigine,
					null,
					DateTime.Now,
                    "");
			}
			catch ( Exception e )
			{
				result.EmpileErreur ( new CErreurException (e));
			}
			finally
			{
				if ( result )
					result = mouvement.CommitEdit();
				else
					mouvement.CancelEdit();
			}
			return result;
		}


        //-------------------------------------------------------------------------------------
        /// <summary>
        /// Liste des <see cref="CRemplacementEquipement">remplacements</see> pour lesquels le mouvement<br/>
        /// concerne le 'remplacé'
        /// </summary>
        [RelationFille(typeof(CRemplacementEquipement), "MouvementDuRemplace")]
        [DynamicChilds("Replacements as replaced movement", typeof(CRemplacementEquipement))]
        public CListeObjetsDonnees RemplacementsEnTantQueRemplace
        {
            get
            {
                return GetDependancesListe(CRemplacementEquipement.c_nomTable, c_champId);
            }
        }

        //-------------------------------------------------------------------------------------
        /// <summary>
        /// Liste des <see cref="CRemplacementEquipement">remplacements</see> pour lesquels le mouvement<br/>
        /// concerne le 'remplaçant'
        /// </summary>
        [RelationFille(typeof(CRemplacementEquipement), "MouvementDuRemplacant")]
        [DynamicChilds("Replacements as replacing movement", typeof(CRemplacementEquipement))]
        public CListeObjetsDonnees RemplacementEnTantQueRemplacant
        {
            get
            {
                return GetDependancesListe(CRemplacementEquipement.c_nomTable, c_champId);
            }
        }

        //-------------------------------------------------------------------------------------
        /// <summary>
        /// Donne le <see cref="CRemplacementEquipement">Remplacement d'équipement associé</see> au mouvement lorsqu'il existe.
        /// </summary>
        /// <remarks>
        /// Lorsqu'un équipement est remplacé par un autre, il y a deux mouvements :
        /// <list type="bullet">
        ///     <item><term>Le mouvement de l'équipement remplacé</term></item>
        ///     <item><term>Le mouvement de l'équipement remplaçant</term></item>
        /// </list>
        /// L'objet de remplacement fait alors référence aux deux mouvements.
        /// </remarks>
        [DynamicField("Associated replacement")]
        public CRemplacementEquipement RemplacementAssocie
        {
            get
            {
                CListeObjetsDonnees lstRemplacements = new CListeObjetsDonnees(ContexteDonnee, typeof(CRemplacementEquipement));
                lstRemplacements.Filtre =  new CFiltreData(
                    CRemplacementEquipement.c_champIdMouvementRemplacant+" =@1 or "+
                    CRemplacementEquipement.c_champIdMouvementRemplace+" =@1",
                    this.Id);

                if (lstRemplacements.CountNoLoad > 0)
                    return (CRemplacementEquipement)lstRemplacements[0];
                return null;
            }
        }

        /// <summary>
        /// Mouvement suivant dans l'ordre de création des mouvements
        /// </summary>
        [Relation ( 
            CMouvementEquipement.c_nomTable,
            CMouvementEquipement.c_champId,
            CMouvementEquipement.c_champIdMouvementSuivant,
            false, 
            false,
            true)]
        [DynamicField("Next movement")]
        public CMouvementEquipement MouvementSuivant
        {
            get
            {
                return (CMouvementEquipement)GetParent ( c_champIdMouvementSuivant, typeof(CMouvementEquipement));
            }
            set
            {
                SetParent ( c_champIdMouvementSuivant, value );
            }
        }

        /// <summary>
        /// Mouvement précédent dans l'ordre de création des mouvements
        /// </summary>
        [DynamicField("Previous movement")]
        public CMouvementEquipement MouvementPrecedent
        {
            get
            {
                CListeObjetsDonnees lstMvts = this.EquipementDeplace.Mouvements;
                lstMvts.Filtre = new CFiltreData(c_champIdMouvementSuivant + "=@1",
                    Id);
                if (lstMvts.Count > 0)
                    return lstMvts[0] as CMouvementEquipement;
                return null;
            }
        }

        /// <summary>
        /// Numéro du mouvement ( le premier commence à 0 )
        /// </summary>
        [TableFieldProperty(CMouvementEquipement.c_champNumeroMouvement)]
        [DynamicField("Number")]
        public int NumeroMouvement
        {
            get
            {
                return (int)Row[c_champNumeroMouvement];
            }
        }

        internal void SetNumeroMouvement(int nNumero)
        {
            Row[c_champNumeroMouvement] = nNumero;
        }

        /// <summary>
        /// <see cref="CActeur">Emplacement destination</see> de l'équipement, après son déplacement<br/>
        /// Suivant le cas, cet emplacement est un <see cref="CSite">site</see> ou un <see cref="CStock">stock</see> ou un <see cref="CActeur">acteur</see>
        /// </summary>
        [DynamicField("Destination place")]
        public IEmplacementEquipement EmplacementDestination
        {
            get
            {
                if (MouvementSuivant != null)
                    return MouvementSuivant.EmplacementOrigine;
                else
                    return EquipementDeplace.Emplacement;
            }
        }

        /// <summary>
        /// Equipement conteneur dans lequel se trouve l'équipement après son déplacement<br/>
        /// (dans le cas où l'équipement est inclus dans un autre)
        /// </summary>
        [DynamicField("Destination equipment")]
        public CEquipement EquipementDestination
        {
            get
            {
                if (MouvementSuivant != null)
                    return MouvementSuivant.EquipementOrigine;
                else
                    return EquipementDeplace.EquipementContenant;
            }
        }



        #region IObjetDonneeAutoReference Membres

        public string ChampParent
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public string ProprieteListeFils
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        #endregion
    }
}
