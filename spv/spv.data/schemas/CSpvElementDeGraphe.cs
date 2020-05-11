using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using timos.data;
using sc2i.data;
using sc2i.common;
using System.Data;
using timos.data.reseau.arbre_operationnel;


namespace spv.data
{
    public enum ETypeElementDeGrapheSpv
    {
        Ou = 0,
        Et,
        Entite,
        SousSchema
    }


    /// <summary>
    /// classe de base pour les éléments de graphe réseau
    /// Cette classe ne devrait pas exister dans un monde objet parfait,
    /// mais pour simplifier la bdd et les triggers, tous les types d'éléments sont stockés dans la même
    /// table, il faut donc cet objet qui regroupe tous les autres pour avoir la
    /// structure de la table.
    /// En programmation, on utilisera SYSTEMATIQUEMENT les classes dérivées de celle
    /// ci.
    /// Les propriétés commençant par _sys_ ne sont là que pour la structure, et ne doivent
    /// pas être appellées. Elles ont leur équivalent dans les classes dérivées et si
    /// des traitements doivent être faits, ils doivent être faits dans la classe dérivée.
    /// </summary>
    [Table(CSpvElementDeGraphe.c_nomTable, CSpvElementDeGraphe.c_nomTableInDb, new string[]{CSpvElementDeGraphe.c_champId}, ModifiedByTrigger = true)]
    [ObjetServeurURI("CSpvElementDeGrapheServeur")]
    [DynamicClass("Spv network graph element")]
    [NoTriggerAutoIncrement(CSpvElementDeGraphe.c_champId)]
    public class CSpvElementDeGraphe : CObjetDonneeAIdNumeriqueAuto,
        IObjetSansVersion,
        IObjetDonneeAutoReference
    {
        public const string c_nomTable = "SPVNETW_GRAPH";
        public const string c_nomTableInDb = "NETWORK_GRAPH";

        public const string c_champId = "NTWGPH_ID";

        public const string c_champParentId = "NTWGPH_PARENT_ID";

        public const string c_champSensReseau = "NTWGPH_DIRECTION";

        //Type de l'élément de graphe
        public const string c_champType = "NTWGPH_TYPE";

        public const string c_champCoefOperationnel = "NTWGPH_COEF_OPER";

        public const string c_champIdSchemaSmt = "NTWGPH_NTWD_SMT_ID";

        public const string c_champKeyNoeudDepart = "NTWGPH_START_NODE_KEY";
        public const string c_champKeyNoeudArrive = "NTWGPH_END_NODE_KEY";

        public const string c_sequenceAssociee = "SEQ_NETWORK_GRAPH";

        ///////////////////////////////////////////////////////////////
		public CSpvElementDeGraphe( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		
		///////////////////////////////////////////////////////////////
        public CSpvElementDeGraphe(DataRow row)
			:base(row)
		{
		}



        ///////////////////////////////////////////////////////////////
        public override string[] GetChampsTriParDefaut()
        {
            return new string[] { c_champId };
        }

        ///////////////////////////////////////////////////////////////
        public override string DescriptionElement
        {
            get
            {
                return I.T("network graph element @1|20028", SpvSchema != null?SpvSchema.Libelle:"");
            }
        }

        ///////////////////////////////////////////////////////////////
        protected override void MyInitValeurDefaut()
        {
            CoefficientOperationnel = 1.0;
        }

        ///////////////////////////////////////////////////////////////
        [TableFieldProperty(CSpvElementDeGraphe.c_champType)]
        [DynamicField("Type code")]
        public int CodeType
        {
            get
            {
                return (int)Row[c_champType];
            }
        }

        ///////////////////////////////////////////////////////////////
        protected void SetType(ETypeElementDeGrapheSpv type)
        {
            Row[c_champType] = (int)type;
        }

        ///////////////////////////////////////////////////////////////
        [TableFieldProperty(CSpvElementDeGraphe.c_champCoefOperationnel)]
        [DynamicField("operational coefficient")]
        public double CoefficientOperationnel
        {
            get
            {
                return (double)Row[c_champCoefOperationnel];
            }
            set
            {
                Row[c_champCoefOperationnel] = value;
            }
        }


        

        ///////////////////////////////////////////////////////////////
        /// <summary>
        /// Retourne le schéma réseau SPV auquel appartient cet élément de graphe
        /// </summary>
        [Relation(
            CSpvSchemaReseau.c_nomTable,
            CSpvSchemaReseau.c_champId,
            CSpvSchemaReseau.c_champId,
            true,
            true,
            DeleteEnCascadeManuel=true)]
        [DynamicField("Spv network diagram")]
        public CSpvSchemaReseau SpvSchema
        {
            get
            {
                return GetParent(CSpvSchemaReseau.c_champId, typeof(CSpvSchemaReseau)) as CSpvSchemaReseau;
            }
            set
            {
                SetParent(CSpvSchemaReseau.c_champId, value);
            }
        }

        ///////////////////////////////////////////////////////////////
        [Relation(
            CSpvElementDeGraphe.c_nomTable,
            CSpvElementDeGraphe.c_champId,
            CSpvElementDeGraphe.c_champParentId,
            false,
            true,
            DeleteEnCascadeManuel=true)]
        [DynamicField("Parent element")]
        public CSpvElementDeGraphe ElementParent
        {
            get
            {
                return GetParent(c_champParentId, typeof(CSpvElementDeGraphe)) as CSpvElementDeGraphe;
            }
            set
            {
                SetParent(c_champParentId, value);
            }
        }

        ///////////////////////////////////////////////////////////////
        [DynamicChilds("Childs elements", typeof(CSpvElementDeGraphe))]
        [RelationFille ( typeof(CSpvElementDeGraphe), "ElementParent")]
        public CListeObjetsDonnees ElementsFils
        {
            get
            {
                return GetDependancesListe(c_nomTable, c_champParentId);
            }
        }

        ///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champSensReseau, NullAutorise=true)]
        [DynamicField("Direction code")]
        public int? CodeSensGraphe
        {
            get
            {
                return (int?)Row[c_champSensReseau, true];
            }
            set
            {
                Row[c_champSensReseau, true] = value;
            }
        }

        ///////////////////////////////////////////////////////////////
        public ESensAllerRetourLienReseau? SensGraphe
        {
            get
            {
                return (ESensAllerRetourLienReseau?)CodeSensGraphe;
            }
            set
            {
                CodeSensGraphe = (int?)value;
            }
        }


        ///////////////////////////////////////////////////////////////
        public string ChampParent
        {
            get { return c_champParentId; }
        }

        ///////////////////////////////////////////////////////////////
        public string ProprieteListeFils
        {
            get { return "ElementsFils"; }
        }


        #region champs pour structure de CSpvElementDeGrapheElementDeSchema
        ///Ces champs sont nécéssaires pour gérer la structure
        ///de la base, mais ils ne doivent pas être utilisés
        ///directement !
        ///////////////////////////////////////////////////////////////
        /// <summary>
        /// Site associé si cet élément est lié à un site
        /// </summary>
        [Relation(
            CSpvSite.c_nomTable,
            CSpvSite.c_champSITE_ID,
            CSpvSite.c_champSITE_ID,
            false,
            true)]
        [DynamicField("Spv Site")]
        public CSpvSite _sys_SpvSite
        {
            get
            {
                return GetParent(CSpvSite.c_champSITE_ID, typeof(CSpvSite)) as CSpvSite;
            }
            set
            {
                SetParent(CSpvSite.c_champSITE_ID, value);
                if (value != null)
                {
                    _sys_SpvLiai = null;
                    _sys_SpvEquip = null;
                }
            }
        }

        ///////////////////////////////////////////////////////////////
        /// <summary>
        /// Liaison associé si cet élément est lié à une liaison
        /// </summary>
        [Relation(
            CSpvLiai.c_nomTable,
            CSpvLiai.c_champLIAI_ID,
            CSpvLiai.c_champLIAI_ID,
            false,
            true)]
        [DynamicField("Spv link")]
        public CSpvLiai _sys_SpvLiai
        {
            get
            {
                return GetParent(CSpvLiai.c_champLIAI_ID, typeof(CSpvLiai)) as CSpvLiai;
            }
            set
            {
                SetParent(CSpvLiai.c_champLIAI_ID, value);
                if (value != null)
                {
                    _sys_SpvSite = null;
                    _sys_SpvEquip = null;
                }
            }
        }

        ///////////////////////////////////////////////////////////////
        /// <summary>
        /// Equipement associé si cet élément est lié à un équipement
        /// </summary>
        [Relation(
            CSpvEquip.c_nomTable,
            CSpvEquip.c_champEQUIP_ID,
            CSpvEquip.c_champEQUIP_ID,
            false,
            true)]
        [DynamicField("Spv equipment")]
        public CSpvEquip _sys_SpvEquip
        {
            get
            {
                return GetParent(CSpvEquip.c_champEQUIP_ID, typeof(CSpvEquip)) as CSpvEquip;
            }
            set
            {
                SetParent(CSpvEquip.c_champEQUIP_ID, value);
                if (value != null)
                {
                    _sys_SpvSite = null;
                    _sys_SpvLiai = null;
                }
            }
        }
        #endregion

        #region champs pour les CSpvElementDeGrapheSousSchema
        ///////////////////////////////////////////////////////////////
        /// <summary>
        /// schéma timos associé, si cet élément est un élément de type sous schéma.
        /// L'élément doit savoir à quel schéma SMt il est lié pour
        /// simplifier le recalcul des schémas.
        /// </summary>
        [Relation(
            CSchemaReseau.c_nomTable,
            CSchemaReseau.c_champId,
            CSpvElementDeGraphe.c_champIdSchemaSmt,
            false,
            true,
            IsInDb = false)]
        [DynamicField("Smt network diagram")]
        public CSchemaReseau _sys_SmtSchema
        {
            get
            {
                return GetParent(c_champIdSchemaSmt, typeof(CSchemaReseau)) as CSchemaReseau;
            }
            set
            {
                SetParent(c_champIdSchemaSmt, value);
            }
        }

        /// <summary>
        /// Clé indiquant le noeud de départ dans un sous schéma
        /// </summary>
        [TableFieldProperty(CSpvElementDeGraphe.c_champKeyNoeudDepart, 500)]
        public string _sys_CleNoeudDepart
        {
            get
            {
                return (string)Row[c_champKeyNoeudDepart];
            }
            set
            {
                Row[c_champKeyNoeudDepart] = value;
            }
        }

        /// <summary>
        /// Clé indiquant le noeud d'arrivé dans un sous schéma
        /// </summary>
        [TableFieldProperty ( CSpvElementDeGraphe.c_champKeyNoeudArrive, 500)]
        public string _sys_CleNoeudArrivee
        {
            get
            {
                return (string)Row[c_champKeyNoeudArrive];
            }
            set
            {
                Row[c_champKeyNoeudArrive] = value;
            }
        }
        #endregion

        ///////////////////////////////////////////////////////////////
        protected virtual CResultAErreur MyFillFromElementDeGraphe(CElementDeArbreOperationnel elementSource)
        {
            return CResultAErreur.True;
        }

        ///////////////////////////////////////////////////////////////
        public virtual CResultAErreur FillFromElementDeGraphe(CElementDeArbreOperationnel elementSource)
        {
            CResultAErreur result = MyFillFromElementDeGraphe(elementSource);
            foreach (CElementDeArbreOperationnel child in elementSource.Fils)
            {
                result = CreateFromElementDeArbreOperationnel(SpvSchema, child, SensGraphe);
                if (result)
                {
                    CSpvElementDeGraphe elt = result.Data as CSpvElementDeGraphe;
                    elt.ElementParent = this;
                }
                else
                    return result;
            }
            return result;
        }

        ///////////////////////////////////////////////////////////////
        /// <summary>
        /// Le data du result contient l'élément créé
        /// </summary>
        /// <param name="spvSchema"></param>
        /// <param name="elementSource"></param>
        /// <returns></returns>
        public static CResultAErreur CreateFromElementDeArbreOperationnel(
            CSpvSchemaReseau spvSchema,
            CElementDeArbreOperationnel elementSource,
            ESensAllerRetourLienReseau ? sens)
        {
            CResultAErreur result = CResultAErreur.True;
            CSpvElementDeGraphe newElt = null;
            if (elementSource is CElementDeArbreOperationnelOperateurEt)
                newElt = new CSpvElementDeGrapheOperateurEt(spvSchema.ContexteDonnee);
            if ( elementSource is CElementDeArbreOperationnelOperateurOu )
                newElt = new CSpvElementDeGrapheOperateurOu( spvSchema.ContexteDonnee );
            if (elementSource is CElementDeArbreOperationnelSousSchema)
                newElt = new CSpvElementDeGrapheSousSchema(spvSchema.ContexteDonnee);
            if (elementSource is CElementDeArbreOperationnelEntite)
                newElt = new CSpvElementDeGrapheElementDeSchema(spvSchema.ContexteDonnee);
            newElt.CreateNewInCurrentContexte();
            newElt.SpvSchema = spvSchema;
            newElt.SensGraphe = sens;
            newElt.CoefficientOperationnel = elementSource.CoeffOperationnel;
            result = newElt.FillFromElementDeGraphe(elementSource);
            if (!result)
                return result;
            result.Data = newElt;
            return result;
        }

        public CSpvElementDeGraphe GetElementDuBonType()
        {
            switch ((ETypeElementDeGrapheSpv)CodeType)
            {
                case ETypeElementDeGrapheSpv.Entite:
                    return new CSpvElementDeGrapheElementDeSchema(Row.Row);
                case ETypeElementDeGrapheSpv.Et:
                    return new CSpvElementDeGrapheOperateurEt(Row.Row);
                case ETypeElementDeGrapheSpv.Ou:
                    return new CSpvElementDeGrapheOperateurOu(Row.Row);
                case ETypeElementDeGrapheSpv.SousSchema:
                    return new CSpvElementDeGrapheSousSchema(Row.Row);
            }
            return null;
        }

        public virtual string GetStringDebugDescription()
        {
            CSpvElementDeGraphe elt = GetElementDuBonType();
            return elt.GetStringDebugDescription();
        }

    }

    
}
