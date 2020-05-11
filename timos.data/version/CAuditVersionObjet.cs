using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.IO.Compression;

using sc2i.data;
using sc2i.common;
using sc2i.process;
using sc2i.multitiers.client;


namespace timos.data.version
{
	/// <summary>
	/// Objet de version d'audit
	/// </summary>
    /// <remarks>
    /// IL EST IMPORTANT DE PRECISER QUE :
    /// le CAVO conserve un lien vers les objets de chaque version intermédiaire<br/>
    /// lors de sa création grace à l'utilisation de la méthode EmpilerVersionElement.
    /// <br/>
    /// <br/>
    /// L'id de l'élément source et de l'élément cible sera différent uniquement<br/>
    /// dans le cas d'un mappage par formule, dans le cas d'un mappage par ID<br/>
    /// les ids seront identiques et il appartient au développeur de préparer<br/>
    /// son contexte dans la version indiquée par les propriétés IdVersionDonnee<br/>
    /// pour récupérer les valeurs correctes de son élément pour la version.
    /// </remarks>
    [NoRelationTypeId]
	[DynamicClass("Audit Version Object")]
	[ObjetServeurURI("CAuditVersionObjetServeur")]
	[Table(CAuditVersionObjet.c_nomTable, CAuditVersionObjet.c_champId, true)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IngeReferentiel_ID)]
    public class CAuditVersionObjet : CObjetDonneeAIdNumeriqueAuto, IObjetSansVersion
	{
		#region Déclaration des constantes
		public const string c_nomTable = "AUDITVERSIONOBJECT";
		public const string c_champId = "AUDTVO_ID";

		public const string c_champTypeObj = "AUDTVO_TYPEOBJ";

		public const string c_champDescrip = "AUDTVO_DESCRIP";

		public const string c_champIdEleSource = "AUDTVO_IDELESRC";
		public const string c_champIdVDonneeEleSource = "AUDTVO_IDVDATAELESRC";

		public const string c_champIdEleCible = "AUDTVO_IDELETARGET";
		public const string c_champIdVDonneeEleCible = "AUDTVO_IDVDATAELETARGET";

		public const string c_champCle = "AUDTVO_CLE";
		#endregion

		//-------------------------------------------------------------------
		public CAuditVersionObjet(CContexteDonnee ctx)
			: base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CAuditVersionObjet(System.Data.DataRow row)
			: base(row)
		{
		}

		//-------------------------------------------------------------------
		public override string ToString()
		{
			return Id.ToString();
		}

        /// /////////////////////////////////////////////
        public override string DescriptionElement
        {
			get { return I.T( "Audit Version Object|563"); }
        }

        /// /////////////////////////////////////////////
        protected override void MyInitValeurDefaut()
        {
        }

        /// /////////////////////////////////////////////
        public override string[] GetChampsTriParDefaut()
        {
            return new string[] { c_champId };
        }


		//-------------------------------------------------------------------
		/// <summary>
		/// Version d'audit correspondante
		/// </summary>
		[Relation(
			CAuditVersion.c_nomTable,
			CAuditVersion.c_champId,
			CAuditVersion.c_champId,
			true,
			true,
			true)]
		[DynamicField("Audit Version")]
		public CAuditVersion AuditVersion
		{
			get
			{
				return (CAuditVersion)GetParent(CAuditVersion.c_champId, typeof(CAuditVersion));
			}
			set
			{
				SetParent(CAuditVersion.c_champId, value);
			}
		}

		//---------------------------------------------
		/// <summary>
		/// Retourne la liste des opérations effectuées sur l'objet
		/// </summary>
		[RelationFille(typeof(CAuditVersionObjetOperation), "VersionObjet")]
		[DynamicChilds("Datas", typeof(CAuditVersionObjetOperation))]
		[DebuggerBrowsable( DebuggerBrowsableState.Never)]
		public CListeObjetsDonnees Datas
		{
			get
			{
				return GetDependancesListe(CAuditVersionObjetOperation.c_nomTable, c_champId);
			}
		}

        /// <summary>
        /// Type système de l'entité (exemple : timos.data.CSite)
        /// </summary>
		[DynamicField("Type of Entity")]
		[TableFieldProperty(c_champTypeObj,255)]
		public string StringTypeElement
		{
			get
			{
				return (string)Row[c_champTypeObj];
			}
			set
			{
				Row[c_champTypeObj] = value;
			}
		}
		public Type TypeElement
		{
			get
			{
				return CActivatorSurChaine.GetType(StringTypeElement);
			}
			set
			{
				StringTypeElement = value.ToString();
			}
		}

        /// <summary>
        /// Type convivial de l'entité (exemple : Sites)
        /// </summary>
		[DynamicField("Friendly element type")]
		public string TypeElementConvivial
		{
			get
			{
				return DynamicClassAttribute.GetNomConvivial(TypeElement);
			}
		}


        /// <summary>
        /// Clé calculée par formule (ID de l'objet si aucune formule définie au niveau<br/>
        /// du type de'audit).
        /// </summary>
		[TableFieldProperty(c_champCle,2000)]
		[DynamicField("Entity key calculated with formulate")]
		public string Cle
		{
			get
			{
				return (string)Row[c_champCle];
			}
			set
			{
				Row[c_champCle] = value;
			}
		}

        /// <summary>
        /// Description de l'entité, à partir de la formule définie<br/>
        /// au niveau du type d'audit, pour cette catégorie d'objet.
        /// </summary>
		[TableFieldProperty(c_champDescrip, 4000)]
		[DynamicField("Entity description calculated with formulate")]
		public string Description
		{
			get
			{
				return (string)Row[c_champDescrip];
			}
			set
			{
				Row[c_champDescrip] = value;
			}
		}
		private bool m_bInit = false;
		//Verifie que l'élément peut être empilé
		private bool CanEmpileVersionElement(CObjetDonneeAIdNumerique obj)
		{
			if(obj == null)
				return IdObjetCible != null;

			foreach (CObjetDonneeAIdNumerique o in m_pileVersionsObjs)
				if (o != null && o.ContexteDonnee.IdVersionDeTravail == obj.ContexteDonnee.IdVersionDeTravail)
					return false;

			return true;
		}
		public void EmpilerVersionElement(CObjetDonneeAIdNumerique obj)
		{
			if (m_bInit && !CanEmpileVersionElement(obj))
				return;

			if (obj != null)
			{
				if (TypeElement != null && TypeElement != obj.GetType())
					return;

				if (TypeElement == null)
					TypeElement = obj.GetType();
			}

			if (!PresentVersionSource)
			{
				IdVersionDonneeSource = IdVersionDonneeCible;
				IdObjetSource = IdObjetCible;
			}

			IdVersionDonneeCible = obj == null ? null : obj.ContexteDonnee.IdVersionDeTravail;
			IdObjetCible = obj == null ? null : (int?)obj.Id;

			if (!m_bInit)
				m_pileVersionsObjs = new List<CObjetDonneeAIdNumerique>();
			m_pileVersionsObjs.Add(obj);

			
			m_bInit = true;
			
		}

		#region Version Source
        /// <summary>
        /// Indicateur de présence de l'objet dans la version source<br/>
        /// (VRAI si présent)
        /// </summary>
		[DynamicField("Is in Original Version")]
		public bool PresentVersionSource
		{
			get
			{
				return IdObjetSource != null;
			}
		}
		[TableFieldProperty(c_champIdVDonneeEleSource, NullAutorise = true)]
		public int? IdVersionDonneeSource
		{
			get
			{
				return (int?)Row[c_champIdVDonneeEleSource, true];
			}
			set
			{
				Row[c_champIdVDonneeEleSource, true] = value;
			}
		}


        /// <summary>
        /// ID de l'entité dans la version source
        /// </summary>
		[DynamicField("Entity Id in Original Version")]
		[TableFieldProperty(c_champIdEleSource, NullAutorise = true)]
		public int? IdObjetSource
		{
			get
			{
				return (int?)Row[c_champIdEleSource,true];
			}
			set
			{
				Row[c_champIdEleSource, true] = value;
			}
		}
		public CObjetDonneeAIdNumerique GetObjetSourceFromContexte(CContexteDonnee ctxSource)
		{
			if (IdObjetSource == null)
				return null;
			return GetObjetWithSpecifiedID(IdObjetSource.Value, ctxSource);
		}
		public CObjetDonneeAIdNumerique GetObjetSourceFromPile()
		{
			return m_pileVersionsObjs[0];
		}
		#endregion

		#region Version Cible
        /// <summary>
        /// Indicateur de présence de l'objet dans la version cible<br/>
        /// (VRAI si présent)
        /// </summary>
		[DynamicField("Is in Target Version")]
		public bool PresentVersionCible
		{
			get
			{
				return IdObjetCible != null;
			}
		}
		[TableFieldProperty(c_champIdVDonneeEleCible, NullAutorise = true)]
		public int? IdVersionDonneeCible
		{
			get
			{
				return (int?)Row[c_champIdVDonneeEleCible, true];
			}
			set
			{
				Row[c_champIdVDonneeEleCible, true] = value;
			}
		}

        /// <summary>
        /// ID de l'entité dans la version cible
        /// </summary>
		[DynamicField("Entity Id in Target Version")]
		[TableFieldProperty(c_champIdEleCible, NullAutorise= true)]
		public int? IdObjetCible
		{
			get
			{
				return (int?)Row[c_champIdEleCible, true];
			}
			set
			{
				Row[c_champIdEleCible, true] = value;
			}
		}
		public CObjetDonneeAIdNumerique GetObjetCibleFromContexte(CContexteDonnee ctxCible)
		{
			if (IdObjetCible == null)
				return null;
			return GetObjetWithSpecifiedID(IdObjetCible.Value, ctxCible);
		}
		public CObjetDonneeAIdNumerique GetObjetCibleFromPile()
		{
			return m_pileVersionsObjs[m_pileVersionsObjs.Count - 1];
		}
		#endregion

		public CObjetDonneeAIdNumerique GetObjetWithSpecifiedID(int nId, CContexteDonnee ctxUsed)
		{
			string strChampID = ContexteDonnee.GetTableSafe(CContexteDonnee.GetNomTableForType(TypeElement)).PrimaryKey[0].ColumnName;
			CFiltreData filtre = new CFiltreData(strChampID + " =@1", nId);
			CListeObjetsDonnees lstEle = new CListeObjetsDonnees(ctxUsed, TypeElement, filtre);
			if (lstEle.Count == 1)
				return (CObjetDonneeAIdNumerique)lstEle[0];
			return null;
		}




		//Pile des objets
		private List<CObjetDonneeAIdNumerique> m_pileVersionsObjs;
		/// <summary>
		/// Retourne l'objet de la version précédante à la version cible
		/// </summary>
		/// <returns></returns>
		public CObjetDonneeAIdNumerique GetObjetLastVersion()
		{
			return m_pileVersionsObjs[m_pileVersionsObjs.Count - 2];
		}
	}
}
