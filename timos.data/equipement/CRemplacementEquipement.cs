using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using timos.acteurs;
using timos.securite;

namespace timos.data
{
	/// <summary>
	/// Le remplacement d'<see cref="CEquipement">equipement</see>
	/// est une notion qu'il est possible d'enregistrer dans ce syst�me.<br/>
	/// Lorsqu'un equipement doit �tre remplac� deux 
	/// <see cref ="CMouvementEquipement">mouvements</see> interviennent dans
	/// cette proc�dure :
	/// <list type="bullet">
	///		<item>
	///			<term>Remplace</term>
	///			<description>Equipement pour lequel le remplacement est n�cessaire</description>
	///		</item>
	///		<item>
	///			<term>Remplacant</term>
	///			<description>Equipement entrant et prenant place de l'equipement � remplacer</description>
	///		</item>
	/// </list>
	/// </summary>
	[DynamicClass("Equipment replacement")]
	[Table(CRemplacementEquipement.c_nomTable, CRemplacementEquipement.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CRemplacementEquipementServeur")]
	[Unique(true, "Un remplacement existe d�j� pour cette op�ration", 
		COperation.c_champId)]
	public class CRemplacementEquipement : CObjetDonneeAIdNumeriqueAuto, IObjetSansVersion

	{
		public const string c_nomTable = "EQUIPMENT_REPLACEMENT";
		
		public const string c_champId = "EQURPL_ID";
		public const string c_champInfo = "EQURPL_INFO";

		public const string c_champIdEquipementRemplace = "EQURPL_REPLACED_EQPT";
		public const string c_champIdEquipementRemplacant = "EQURPL_REPLACING_EQPT";

		public const string c_champIdMouvementRemplace = "EQURPL_ID_MV_REMPLACED";
		public const string c_champIdMouvementRemplacant = "EQURPL_ID_MV_REMPLACING";
        public const string c_champNumSerieAvantRemplacement = "EQURPL_PREV_SN";
		public const string c_champNumSerieRemplace = "EQURPL_REPL_SN";
		public const string c_champIsDotation = "EQURPL_IS_DOTATION";

		/// /////////////////////////////////////////////
		public CRemplacementEquipement( CContexteDonnee contexte)
			:base(contexte)
		{
		}

		/// /////////////////////////////////////////////
		public CRemplacementEquipement(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("Equipment replacement @1|266", Info);
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
			IsDotation = false;
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champId};
		}


		
		//-----------------------------------------------------------
		/// <summary>
		/// Commentaire sur le remplacement
		/// </summary>
		[TableFieldProperty(c_champInfo, 3000)]
		[DynamicField("Info")]
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



		//-------------------------------------------------------------------
		/// <summary>
		/// Equipement Remplac�<br/>
		/// Si c'est un remplacement utilisant un �quipement en dotation,
		/// Cette valeur est vide
		/// </summary>
		[Relation(
			CEquipement.c_nomTable,
			CEquipement.c_champId,
			CRemplacementEquipement.c_champIdEquipementRemplace,
			false,
			false,
			true)]
		[DynamicField("Replaced equipment")]
		public CEquipement EquipementRemplace
		{
			get
			{
				return (CEquipement)GetParent(CRemplacementEquipement.c_champIdEquipementRemplace, typeof(CEquipement));
			}
			set
			{
				SetParent(CRemplacementEquipement.c_champIdEquipementRemplace, value);
			}
		}


		//-------------------------------------------------------------------
		/// <summary>
		/// Nouvel equipement
		/// </summary>
		[Relation(
			CEquipement.c_nomTable,
			CEquipement.c_champId,
		    CRemplacementEquipement.c_champIdEquipementRemplacant,
			false,
			false,
			true)]
		[DynamicField("Replacing equipment")]
		public CEquipement EquipementDeRemplacement
		{
			get
			{
				return (CEquipement)GetParent(CRemplacementEquipement.c_champIdEquipementRemplacant, typeof(CEquipement));
			}
			set
			{
				SetParent(CRemplacementEquipement.c_champIdEquipementRemplacant, value);
			}
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Operation <br/>
		/// Indique l'op�ration (dans le compte rendu d'intervention) qui a
		/// g�n�r� ce remplacement
		/// </summary>
		[Relation(
			COperation.c_nomTable,
			COperation.c_champId,
			COperation.c_champId,
			false,
			false,
			true)]
		[DynamicField("Operation")]
		public COperation Operation
		{
			get
			{
				return (COperation)GetParent(COperation.c_champId, typeof(COperation));
			}
			set
			{
				SetParent(COperation.c_champId, value);
			}
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Indique que ce remplacement concerne un �quipement en dotation
		/// </summary>
		[TableFieldProperty(CRemplacementEquipement.c_champIsDotation)]
		[DynamicField("Is Dotation")]
		public bool IsDotation
		{
			get
			{
				return (bool)Row[c_champIsDotation];
			}
			set
			{
				Row[c_champIsDotation] = value;
			}
		}

		//-------------------------------------------------------------------
		//////////////////////////////////////////////////////
		/// <summary>
		/// Indique le site sur lequel a �t� mis l'�quipement remplac� (pris sur le site), si
		/// cet �quipement a �t� mis sur un site apr�s le remplacement.
		/// </summary>
		[Relation(CSite.c_nomTable,
			CSite.c_champId,
			CSite.c_champId,
			false,
			false,
			true)]
		[DynamicField("Target site")]
		public CSite EmplacementSite
		{
			get
			{
				return (CSite)GetParent(CSite.c_champId, typeof(CSite));
			}
			set
			{
				EmplacementDestination = value;
			}
		}

		//////////////////////////////////////////////////////
		/// <summary>
		/// Indique le stock dans lequel a �t� mis l'�quipement remplac� (pris sur le site), si
		/// cet �quipement a �t� mis dans un stock apr�s le remplacement.
		/// </summary>
		[Relation(CStock.c_nomTable,
			CStock.c_champId,
			CStock.c_champId,
			false,
			false,
			true)]
		[DynamicField("Target stock")]
		public CStock EmplacementStock
		{
			get
			{
				return (CStock)GetParent(CStock.c_champId, typeof(CStock));
			}
			set
			{
				EmplacementDestination = value;
			}
		}

		//////////////////////////////////////////////////////
		/// <summary>
		/// Indique l'acteur auquel a �t� affect� l'�quipement remplac� (pris sur le site), si
		/// cet �quipement a �t� affect� � un acteur apr�s le remplacement.
		/// </summary>
		[Relation(CActeur.c_nomTable,
			CActeur.c_champId,
			CActeur.c_champId,
			false,
			false,
			true)]
		[DynamicField("Target member")]
		public CActeur EmplacementActeur
		{
			get
			{
				return (CActeur)GetParent(CActeur.c_champId, typeof(CActeur));
			}
			set
			{
				EmplacementDestination = value;
			}
		}

		//////////////////////////////////////////////////////
		/// <summary>
		/// Indique l'emplacement de destination de l'�quipement remplac� (
		/// site, stock ou acteur).
		/// </summary>
		[DynamicField("Target place")]
		public IEmplacementEquipement EmplacementDestination
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
			set
			{
				if (value is CSite)
					SetParent ( CSite.c_champId, (CSite) value );
				else
					SetParent ( CSite.c_champId, null );
				if (value is CActeur)
					SetParent(CActeur.c_champId, (CActeur)value);
				else
					SetParent ( CActeur.c_champId, null );
				if (value is CStock)
					SetParent(CStock.c_champId, (CStock)value);
				else
					SetParent(CStock.c_champId, null);
			}
		}

		//////////////////////////////////////////////////////

		//-------------------------------------------------------------------
		/// <summary>
		/// Pointe sur le mouvement g�n�r� pour l'�quipement remplac�, qui d�place
		/// cet �quipement du site o� il a �t� pris, vers l'emplacement de destination 
		/// du remplacement. 
		/// <BR/>En cas de remplacement de dotation, ce mouvement repr�sente le mouvement
		/// qui prend l'�quipement en dotation du site, vers la destination (l'�quipement remplac�)
		/// </summary>
		[Relation(
			CMouvementEquipement.c_nomTable,
			CMouvementEquipement.c_champId,
			CRemplacementEquipement.c_champIdMouvementRemplace,
			false,
			true,
			false)]
		[DynamicField("Replaced movement")]
		public CMouvementEquipement MouvementDuRemplace
		{
			get
			{
				return (CMouvementEquipement)GetParent(CRemplacementEquipement.c_champIdMouvementRemplace, typeof(CMouvementEquipement));
			}
			set
			{
				SetParent(CRemplacementEquipement.c_champIdMouvementRemplace, value);
			}
		}

		
		//-------------------------------------------------------------------
		/// <summary>
		/// Pointe sur le mouvement qui d�place l'�quipement remplac� sur le site.<BR/>
		/// En cas de gestion par dotation, pointe sur le mouvement qui d�place l'�quipement
		/// rempla�ant de son emplacement initial sur le site.
		/// </summary>
		[Relation(
			CMouvementEquipement.c_nomTable,
			CMouvementEquipement.c_champId,
			CRemplacementEquipement.c_champIdMouvementRemplacant,
			false,
			true,
			false)]
		[DynamicField("Replacing movement")]
		public CMouvementEquipement MouvementDuRemplacant
		{
			get
			{
				return (CMouvementEquipement)GetParent(CRemplacementEquipement.c_champIdMouvementRemplacant, typeof(CMouvementEquipement));
			}
			set
			{
				SetParent(CRemplacementEquipement.c_champIdMouvementRemplacant, value);
			}
		}

        //-------------------------------------------------------------------
        /// <summary>
        /// Abandonne le remplacement et les mouvements associ�s
        /// </summary>
        /// <returns></returns>
        [DynamicMethod("Cancel the current replacement, and its associated movements")]
        public CResultAErreur CancelReplacement()
        {
            return AnnuleRemplacement();
        }
		
        //-------------------------------------------------------------------
		public CResultAErreur AnnuleRemplacement()
		{
			CResultAErreur result = CResultAErreur.True;
			CRemplacementEquipement remplacementEdite = this;
			remplacementEdite.BeginEdit();


			try
			{

				if (remplacementEdite.MouvementDuRemplace != null)
				{
					if (IsDotation)
					{
						CMouvementEquipement mvt = remplacementEdite.MouvementDuRemplace;
						remplacementEdite.MouvementDuRemplace = null;//Pour �viter la suppression en casade
						result = mvt.Delete();
					}
					else
						result = remplacementEdite.MouvementDuRemplace.AnnuleDeplacement();
					if (!result)
					{
						result.EmpileErreur(I.T("Impossible to cancel the replacement|267"));
						return result;
					}
					else
						remplacementEdite.MouvementDuRemplace = null;
				}

				if (remplacementEdite.MouvementDuRemplacant != null)
				{
					if (IsDotation)
					{
						CMouvementEquipement mvt = remplacementEdite.MouvementDuRemplacant;
						remplacementEdite.MouvementDuRemplacant = null;//pour �viter la suppr en cascade
						result = mvt.Delete();
					}
					else
						result = remplacementEdite.MouvementDuRemplacant.AnnuleDeplacement();
					if (!result)
					{
                        result.EmpileErreur(I.T("Impossible to cancel the replacement|267"));
						return result;
					}
					else
					{
						remplacementEdite.MouvementDuRemplacant = null;
						if (IsDotation)
							remplacementEdite.EquipementDeRemplacement.NumSerie = NumSerieAvantRemplacement;
					}
				}
			}
			catch (Exception e)
			{
				result.EmpileErreur(new CErreurException(e));
			}
			finally
			{
				if (result)
					result = remplacementEdite.CommitEdit();
				else
					remplacementEdite.CancelEdit();
			}
			return result;
		}


        //-------------------------------------------------------------------
        /// <summary>
        /// Effectue le remplacement et les mouvements associ�s
        /// </summary>
        /// <param name="replacementDate">Date du remplacement</param>
        /// <returns><see cref="CResultAErreur">R�sultat � erreur</see></returns>
        [DynamicMethod("Performes the replacement and the associated �quipments movements","The replacement date")]
        public CResultAErreur DoReplacement(DateTime replacementDate)
        {
            return DoRemplacementInCurrentContexte(replacementDate);
        }

        //-------------------------------------------------------------------
		public CResultAErreur DoRemplacementInCurrentContexte( DateTime dateRemplacement )
		{
			CResultAErreur result = CResultAErreur.True;
			bool bIsDotation = EquipementDeRemplacement != null && EquipementDeRemplacement.IsDotationApplique;
			
            if (EmplacementDestination == null && !bIsDotation)
			{
				result.EmpileErreur(I.T("The destination place must be specified|268"));
				return result;
			}
			if (EquipementRemplace == null && !bIsDotation )
			{
				result.EmpileErreur(I.T("The replaced equipment must be specified|269"));
				return result;
			}

			CRemplacementEquipement remplacementEdite = this;
			//remplacementEdite.BeginEdit();

			try
			{
				#region annulation des mouvements gener�s pr�c�dements (annulation)
				result = AnnuleRemplacement();
				if (!result)
					return result;
				#endregion

				IsDotation = false;
				string strInfo = "";
				if ( remplacementEdite.EquipementDeRemplacement != null )
					strInfo = I.T("Replacement by @1|235", remplacementEdite.EquipementDeRemplacement.Libelle);
				else if (remplacementEdite.Operation != null )
					strInfo = I.T("Equipment removed during the operation @1|236", remplacementEdite.Operation.TypeOperation.Libelle);
				else
					strInfo = I.T("Replaced|237");

				CEquipementLogique equipementLogiqueDuRemplace = remplacementEdite.EquipementRemplace.EquipementLogique;
                // Detache l'�quipement logique associ� au remplac�
                remplacementEdite.EquipementRemplace.EquipementLogique = null;

				//D�placement de l'�quipement remplac�
				result.Data = null;
				if (!bIsDotation)
				{
					result = remplacementEdite.EquipementRemplace.DeplaceEquipementOptionPassage(
						strInfo,
						EmplacementDestination,
						null,
						"",
						null,
						null,
						dateRemplacement,
                        "",
                        false,
                        true);
				}
				if (!result)
				{
					result.EmpileErreur(I.T( "Movement of equipment @1 impossible|270", 
                        remplacementEdite.EquipementRemplace.Libelle));
					return result;
				}

				remplacementEdite.MouvementDuRemplace = (CMouvementEquipement)result.Data;

				//D�placement de l'�quipement de remplacement
				if (remplacementEdite.EquipementDeRemplacement != null)
				{
					IEmplacementEquipement emplacementOuALieuLeRemplacement = null;
					if (remplacementEdite.EquipementDeRemplacement.EquipementLogique == null)
						remplacementEdite.EquipementDeRemplacement.EquipementLogique = equipementLogiqueDuRemplace;
					string strLibelleRemplace = "";
					if (bIsDotation)
						strLibelleRemplace = remplacementEdite.NumSerieRemplace;
					else
					{
						strLibelleRemplace = remplacementEdite.EquipementRemplace.Libelle;
					}
					if (!bIsDotation)
					{
						result = remplacementEdite.EquipementDeRemplacement.DeplaceEquipementOptionPassage(
						    I.T("Replacement of @1 |271", remplacementEdite.EquipementRemplace.Libelle),
						    remplacementEdite.MouvementDuRemplace.EmplacementOrigine,
						    remplacementEdite.MouvementDuRemplace.EquipementOrigine,
						    remplacementEdite.MouvementDuRemplace.CoordonneeOrigine,
						    remplacementEdite.MouvementDuRemplace.OccupationOrigine,
						    null,
						    dateRemplacement,
                            "",
                            false,
                            true);

						if (result )
							remplacementEdite.MouvementDuRemplacant = (CMouvementEquipement)result.Data;
					}
					else
					{
						if (remplacementEdite.Operation != null &&
							remplacementEdite.Operation.FractionIntervention != null)
							emplacementOuALieuLeRemplacement = remplacementEdite.Operation.FractionIntervention.Intervention.Site;
						IsDotation = true;
						NumSerieAvantRemplacement = remplacementEdite.EquipementDeRemplacement.NumSerie;
						//D�place l'�quipement de remplacement sur le site,
						result = remplacementEdite.EquipementDeRemplacement.DeplaceEquipementOptionPassage(
							I.T("Replacement of @1 by @2|271", NumSerieRemplace, EquipementDeRemplacement.NumSerie),
							emplacementOuALieuLeRemplacement,
							null,
							null,
							null,
							null,
							dateRemplacement,
                            "",
                            false,
                            true);
						if (result)
							MouvementDuRemplacant = (CMouvementEquipement)result.Data;
						//et le place sur le lieu de destination
						if (result)
						{
							result = remplacementEdite.EquipementDeRemplacement.DeplaceEquipementOptionPassage(
								I.T("Replacement of @1 by @2|271", NumSerieRemplace, EquipementDeRemplacement.NumSerie),
								EmplacementDestination,
								null,
								null,
								null,
								null,
								dateRemplacement,
                                "",
                                false,
                                true);
							//Change le num�ro de s�rie de l'�quipement
							remplacementEdite.EquipementDeRemplacement.NumSerie = NumSerieRemplace;
							if (result)
								MouvementDuRemplace = (CMouvementEquipement)result.Data;
						}
					}



					if (!result)
					{
						result.EmpileErreur(I.T( "Movement of equipment @1 impossible|270",
							remplacementEdite.EquipementDeRemplacement.Libelle));
						return result;
					}
					
				}
			}


			catch (Exception e)
			{
				result.EmpileErreur(new CErreurException(e));
			}
			finally
			{
                //if ( result )
                //    result = remplacementEdite.CommitEdit();
                //else
                //    remplacementEdite.CancelEdit();
			}
			return result;
		}
        //-------------------------------------------------------------------
        public CResultAErreur DoRemplacementPourDotation(DateTime dateRemplacement)
        {
            CResultAErreur result = CResultAErreur.True;

            CRemplacementEquipement remplacementEdite = this;
            remplacementEdite.BeginEdit();

            try
            {
                #region annulation des mouvements gener�s pr�c�dements (annulation)
                result = AnnuleRemplacement();
                if (!result)
                    return result;
                #endregion

                string strInfo = "";
                if (remplacementEdite.EquipementDeRemplacement != null)
                    strInfo = I.T( "Replacement by @1|235", remplacementEdite.EquipementDeRemplacement.Libelle);
                else if (remplacementEdite.Operation != null)
                    strInfo = I.T( "Equipment removed during the operation @1|236", remplacementEdite.Operation.TypeOperation.Libelle);
                else
                    strInfo = I.T( "Replaced|237");


                //D�placement de l'�quipement de remplacement
                if (remplacementEdite.EquipementDeRemplacement != null)
                {
                    result = remplacementEdite.EquipementDeRemplacement.DeplaceEquipementOptionPassage(
                        I.T( "Replacement of @1 |271", remplacementEdite.EquipementDeRemplacement.Libelle),
                        remplacementEdite.EmplacementDestination,
                        null,
                        null,
                        null,
                        null,
                        dateRemplacement,
                        "",
                        false,
                        true);
                    if (!result)
                    {
                        result.EmpileErreur(I.T( "Movement of equipment @1 impossible|270",
                            remplacementEdite.EquipementDeRemplacement.Libelle));
                        return result;
                    }
                    remplacementEdite.MouvementDuRemplacant = (CMouvementEquipement)result.Data;

                    result = remplacementEdite.EquipementDeRemplacement.DeplaceEquipementOptionPassage(
                        strInfo,
                        remplacementEdite.MouvementDuRemplacant.EmplacementOrigine,
                        remplacementEdite.MouvementDuRemplacant.EquipementOrigine,
                        remplacementEdite.MouvementDuRemplacant.CoordonneeOrigine,
                        remplacementEdite.MouvementDuRemplacant.OccupationOrigine,
                        null,
                        dateRemplacement,
                        "",
                        false,
                        true);
                    if (!result)
                    {
                        result.EmpileErreur(I.T( "Movement of equipment @1 impossible|270",
                            remplacementEdite.EquipementDeRemplacement.Libelle));
                        return result;
                    }
                    remplacementEdite.MouvementDuRemplace = (CMouvementEquipement)result.Data;
                        
                }
            }


            catch (Exception e)
            {
                result.EmpileErreur(new CErreurException(e));
            }
            finally
            {
                if (result)
                    result = remplacementEdite.CommitEdit();
                else
                    remplacementEdite.CancelEdit();
            }
	


            return result;
        }
    

        //-----------------------------------------------------------------------------------
        /// <summary>
        /// Dans le compte rendu d'op�ration, on peut renseigner provisoirement seulement le Type d'�quipement.<br/>
        /// - Si l'�quipement remplac� n'est pas d�fini il faut d�finir le Type d'�quipement remplac�<br/>
        /// - Si l'�quipement remplac� est d�fini, il n'est plus n�cessaire de conserver le lien vers le Type d'�quipement remplac�<br/>
        /// </summary>
        [Relation(
            CTypeEquipement.c_nomTable,
            CTypeEquipement.c_champId,
            CTypeEquipement.c_champId,
            false,
            false,
            true)]
        [DynamicField("Equipment Type")]
        public CTypeEquipement TypeEquipementRemplace
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


        //-----------------------------------------------------------------------------------
		/// <summary>
		/// Num�ro de s�rie de l'�quipement avant le remplacement (celui de l'�quipement remplac�)
		/// </summary>
		[TableFieldProperty ( c_champNumSerieAvantRemplacement, 128 )]
		[DynamicField("Serial number before replace")]
		public string NumSerieAvantRemplacement
		{
			get
			{
				return (string)Row[c_champNumSerieAvantRemplacement];
			}
			set
			{
				Row[c_champNumSerieAvantRemplacement] = value;
			}
		}

		//-----------------------------------------------------------------------------------
		/// <summary>
		/// Num�ro de s�rie de l'�quipement apr�s le remplacement (celui de l'�quipement rempla�ant)
		/// </summary>
		[TableFieldProperty(CRemplacementEquipement.c_champNumSerieRemplace, 128)]
		[DynamicField("Replaced serial number")]
		public string NumSerieRemplace
		{
			get
			{
				return (string)Row[c_champNumSerieRemplace];
			}
			set
			{
				Row[c_champNumSerieRemplace] = value;
			}
		}


	}

}
