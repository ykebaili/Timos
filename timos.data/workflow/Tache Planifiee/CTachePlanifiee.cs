using System;
using System.IO;
using System.Collections;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;
using sc2i.common.planification;

namespace sc2i.workflow
{
	/// <summary>
	/// Une tâche planifiée permet de planifier :
    /// <ul>
    /// <li>Le lancement d'un ou de plusieurs <see cref="CProcessInDb">process</see> et/ou</li>
    /// <li>Le lancement d'un ou de plusieurs <see cref="CTypeDonneeCumulee">calculs de données cumulées</see></li>
    /// </ul>
	/// </summary>
    [sc2i.doccode.DocRefMenusOrMenuItems(timos.data.CDocLabels.c_iProcess)]
    [DynamicClass("Planified task")]
	[ObjetServeurURI("CTachePlanifieeServeur")]
	[Table(CTachePlanifiee.c_nomTable, CTachePlanifiee.c_champId,true, IsGrandVolume = true)]
	[FullTableSync]
    //[Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_TachesPlanif_ID)]
    public class CTachePlanifiee : CObjetDonneeAIdNumeriqueAuto
	{
		#region Déclaration des constantes
		public const string c_nomTable = "PLANIFIED_TASKS";
		public const string c_champId = "PLNTSK_ID";
		public const string c_champLibelle = "PLNTSK_LABEL";
		public const string c_champCommentaires = "PLNTSK_COMMENT";
		public const string c_champBloquer = "PLNTSK_LOCK";
		public const string c_champParametrePlanification = "PLNTSK_PLANIF_SETTING";
		public const string c_champProchaineExecution = "PLNTSK_NEXT_EXEC";
		#endregion
		//-------------------------------------------------------------------
#if PDA
		public CTachePlanifiee()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CTachePlanifiee( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CTachePlanifiee( System.Data.DataRow row )
			:base(row)
		{
		}
		//-------------------------------------------------------------------
		protected override void MyInitValeurDefaut()
		{
		}
		//-------------------------------------------------------------------
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champLibelle};
		}
		//-------------------------------------------------------------------
		public override string DescriptionElement
		{
			get
			{
				return I.T("Planned Task @1|342", Libelle);
			}
		}
		//-------------------------------------------------------------------
        /// <summary>
        /// Libellé de la tâche planifiée
        /// </summary>
		[
		TableFieldProperty(c_champLibelle, 255),
		DynamicField("Label")
		]
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

		//-------------------------------------------------------------------
        /// <summary>
        /// Commentaire de la tâche planifiée
        /// </summary>
		[
		TableFieldProperty(c_champCommentaires, 2048),
		DynamicField("Comment")
		]
		public string Commentaires
		{
			get
			{
				return (string)Row[c_champCommentaires];
			}
			set
			{
				Row[c_champCommentaires] = value;
			}
		}

		/// /////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champParametrePlanification,NullAutorise=true)]
		public CDonneeBinaireInRow DataParametrePlanif
		{
			get
			{
				if ( Row[c_champParametrePlanification] == DBNull.Value )
				{
					CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession ,Row, c_champParametrePlanification);
					CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champParametrePlanification, donnee);
				}
				return ((CDonneeBinaireInRow)Row[c_champParametrePlanification]).GetSafeForRow(Row.Row);
			}
			set
			{
				Row[c_champParametrePlanification] = value;
			}
		}


		/// /////////////////////////////////////////////////////////////
        [BlobDecoder]
        public CParametrePlanificationTache ParametrePlanification
		{
			get
			{
                CParametrePlanificationTache parametre = new CParametrePlanificationTache();
				if ( DataParametrePlanif.Donnees != null )
				{
					MemoryStream stream = new MemoryStream(DataParametrePlanif.Donnees);
					BinaryReader reader = new BinaryReader(stream);
					CSerializerReadBinaire serializer = new CSerializerReadBinaire(reader);
					CResultAErreur result = parametre.Serialize(serializer);
					if ( !result )
					{
                        parametre = new CParametrePlanificationTache();
					}
                    reader.Close();
                    stream.Close();
				}
				return parametre;
			}
			set
			{
				if ( value == null )
				{
					CDonneeBinaireInRow data = DataParametrePlanif;
					data.Donnees = null;
					DataParametrePlanif = data;
				}
				else
				{
					MemoryStream stream = new MemoryStream();
					BinaryWriter writer = new BinaryWriter(stream);
					CSerializerSaveBinaire serializer = new CSerializerSaveBinaire(writer);
					CResultAErreur result = value.Serialize ( serializer );
					if ( result )
					{
						CDonneeBinaireInRow data = DataParametrePlanif;
						data.Donnees = stream.GetBuffer();
						DataParametrePlanif = data;
					}
                    writer.Close();
                    stream.Close();
				}
			}
		}

		/// /////////////////////////////////////////////////////////////
		/// <summary>
		/// Date de prochaine exécution de cette tâche
		/// </summary>
		[TableFieldProperty(c_champProchaineExecution, true)]
		[DynamicField("Next running date")]
		public CDateTimeEx DateProchaineExecution
		{
			get
			{
				if ( Row[c_champProchaineExecution] == DBNull.Value )
					return null;
				return new CDateTimeEx ( (DateTime)Row[c_champProchaineExecution]);
			}
			set
			{
				if ( value == null )
					Row[c_champProchaineExecution] = DBNull.Value;
				else
					Row[c_champProchaineExecution] = value.DateTimeValue;
			}
		}

		/// /////////////////////////////////////////////////////////////
		/// <summary>
        /// Si VRAI, la tâche est bloquée (même si elle est en cours),
		/// elle ne s'execute plus automatiquement
		/// </summary>
		[TableFieldProperty(c_champBloquer)]
		[DynamicField("Stop")]
		public bool Bloquer
		{
			get
			{
				return (bool)Row[c_champBloquer];
			}
			set
			{
				Row[c_champBloquer] = value;
			}
		}

		//-------------------------------------------------------------------
		/// <summary>
        /// Liste des relations avec les données cumulées qui doivent se recalculer
        /// à la prochaine exécution de la tâche
		/// </summary>
		[RelationFille(typeof(CRelationTachePlanifieeTypeDonneeCumulee), "TachePlanifiee")]
		[DynamicChilds("Cumulated data relations", typeof(CRelationTachePlanifieeTypeDonneeCumulee))]
		public CListeObjetsDonnees RelationsTypesDonneesCumulees
		{
			get
			{
				return GetDependancesListe ( CRelationTachePlanifieeTypeDonneeCumulee.c_nomTable, c_champId );
			}
		}

		//-------------------------------------------------------------------
		/// <summary>
        /// Liste des relations avec les process qui doivent être relancés
        /// à la prochaine exécution de la tâche
		/// </summary>
        [RelationFille(typeof(CRelationTachePlanifieeProcess), "TachePlanifiee")]
		[DynamicChilds("Planified tasks relations", typeof(CRelationTachePlanifieeProcess))]
		public CListeObjetsDonnees RelationsProcess
		{
			get
			{
				return GetDependancesListe ( CRelationTachePlanifieeProcess.c_nomTable, c_champId );
			}
		}

		//-------------------------------------------------------------------
		public CResultAErreur ExecuteTache ( IIndicateurProgression indicateur )
		{
			ITachePlanifieeServeur serveur = (ITachePlanifieeServeur)GetLoader();
			return serveur.ExecuteTache ( Id, indicateur );
		}
		
	}

	public interface ITachePlanifieeServeur
	{
		CResultAErreur ExecuteTache( int nIdIntervention, IIndicateurProgression indicateur );
	}
}
