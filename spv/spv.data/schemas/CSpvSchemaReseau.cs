using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using timos.data;
using sc2i.data;
using sc2i.common;
using System.Data;
using timos.data.reseau.graphe;
using timos.data.reseau.arbre_operationnel;

namespace spv.data
{
    [Table(CSpvSchemaReseau.c_nomTable, CSpvSchemaReseau.c_nomTableInDb, new string[]{CSpvSchemaReseau.c_champId})]
    [ObjetServeurURI("CSpvSchemaReseauServeur")]
    [DynamicClass("Spv network diagram")]
    [AutoExec("CompleteProprietesSchemaReseau")]
    public class CSpvSchemaReseau : CMappableAvecTimos<CSchemaReseau,CSpvSchemaReseau>,
        IObjetSansVersion
    {
        public const string c_nomTable = "SPVNETW_DIAG";
        public const string c_nomTableInDb = "NETWORK_DIAG";

        public const string c_champId = "NTWDIAG_ID";
        public const string c_champLibelle = "NTWDIAG_LABEL";
        public const string c_champMasque = "NTWDIAG_MASQUE";

        public const string c_champIdTimos = "NTWDIAG_SMT_ID";

        ///////////////////////////////////////////////////////////////
		public CSpvSchemaReseau( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		
		///////////////////////////////////////////////////////////////
        public CSpvSchemaReseau(DataRow row)
			:base(row)
		{
		}

        
        ///////////////////////////////////////////////////////////////
        public static void CompleteProprietesSchemaReseau()
        {
            CMappableAvecTimos<CSchemaReseau, CSpvSchemaReseau>.CompleteProprietesObjetTimos("Supervision datas");
        }

        ///////////////////////////////////////////////////////////////
        public override string[] GetChampsTriParDefaut()
        {
            return new string[] { c_champLibelle };
        }

        ///////////////////////////////////////////////////////////////
        public override string DescriptionElement
        {
            get
            {
                return I.T("Supervised network diagram @1|20028", Libelle);
            }
        }

        ///////////////////////////////////////////////////////////////
        protected override void MyInitValeurDefaut()
        {
        }

        ///////////////////////////////////////////////////////////////
        [TableFieldProperty(CSpvSchemaReseau.c_champLibelle, 400)]
        [DynamicField("Label")]
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


        // La mise à jour de ce champ est faite
        // par trigger BDD
        [TableFieldProperty(c_champMasque, true)]
        [DynamicField("Masking state")]
        public EEtatMasquageService EtatMasquage
        {
            get
            {
                if (Row[c_champMasque] == DBNull.Value)
                    return EEtatMasquageService.NomMasque;
                return (EEtatMasquageService)Row[c_champMasque];
            }
        }

        ///////////////////////////////////////////////////////////////
        [Relation(
            CSchemaReseau.c_nomTable,
            CSchemaReseau.c_champId,
            CSpvSchemaReseau.c_champIdTimos,
            false,
            true,
            IsInDb=false)]
        [DynamicField("Timos diagram")]
        public override CSchemaReseau ObjetTimosAssocie
        {
            get
            {
                return ObjetTimosAssocieProtected;
            }
            set
            {
                ObjetTimosAssocieProtected = value;
            }
        }

        ///////////////////////////////////////////////////////////////
        /// <summary>
        /// Lien représenté par ce schéma s'il s'agit d'un schéma de lien
        /// </summary>
        /// <param name="objetTimos"></param>

        [Relation(
            CSpvLiai.c_nomTable,
            CSpvLiai.c_champLIAI_ID,
            CSpvLiai.c_champLIAI_ID,
            false,
            true)]
        [DynamicField("Represented link")]
        public CSpvLiai LienRepresente
        {
            get
            {
                return GetParent(CSpvLiai.c_champLIAI_ID, typeof(CSpvLiai)) as CSpvLiai;
            }
            set
            {
                SetParent(CSpvLiai.c_champLIAI_ID, value);
            }
        }



        //-----------------------------------------------------------------
        public override void CopyFromObjetTimos(CSchemaReseau objetTimos)
        {
            Libelle = objetTimos.Libelle;
            if (objetTimos.LienReseau != null)
                LienRepresente = CSpvLiai.GetObjetSpvFromObjetTimosAvecCreation(objetTimos.LienReseau);
            else
                LienRepresente = null;
        }

        //-----------------------------------------------------------------
        [RelationFille(typeof(CSpvElementDeGraphe), "SpvSchema")]
        [DynamicChilds("network graph elements", typeof(CSpvElementDeGraphe))]
        public CListeObjetsDonnees ElementsDeGraphe
        {
            get
            {
                return GetDependancesListe(CSpvElementDeGraphe.c_nomTable, CSpvSchemaReseau.c_champId);
            }
        }

        //-----------------------------------------------------------------
        public override string GetChampIdObjetTimos()
        {
            return c_champIdTimos;
        }

        //-----------------------------------------------------------------
        /// <summary>
        /// recalcule l'arbre opérationnel
        /// </summary>
        /// <param name="baseGraphes"></param>
        /// <returns></returns>
        public CResultAErreur RecalculeArbreOperationnelInContexte( CBaseGraphesReseau baseGraphes )
        {
            if ( baseGraphes == null )
                baseGraphes = new CBaseGraphesReseau();
            CResultAErreur result = CResultAErreur.True;
            CSchemaReseau schema = ObjetTimosAssocie;

            //Supprime toutes les dépendances à des elements de graphe
            result = CObjetDonneeAIdNumerique.Delete(ElementsDeGraphe, true);
            if (!result)
                return result;

            foreach (ESensAllerRetourLienReseau sens in Enum.GetValues(typeof(ESensAllerRetourLienReseau)))
            {
                ESensAllerRetourLienReseau? sensRetenu = null;
                if (schema.LienReseau == null)
                    sensRetenu = sens;
                //Calcule le graphe 
                CGrapheReseau graphe = baseGraphes.GetGrapheExistant(schema, sensRetenu);
                if (graphe == null)
                {
                    graphe = new CGrapheReseau(baseGraphes);
                    result = graphe.CalculeGraphe(schema, sensRetenu);
                    if (!result)
                        return result;
                }
                CArbreOperationnel arbre = new CArbreOperationnel();
                result = arbre.CalculArbreRedondanceAuto(schema, graphe);
                if (!result)
                    return result;
                result = CSpvElementDeGraphe.CreateFromElementDeArbreOperationnel(this, arbre.ElementRacine, sensRetenu);
                if (!result)
                    return result;
                if (schema.LienReseau != null)
                    break;
            }

            //Recalcule les éléments de graphe qui utilisent ce schéma
            CListeObjetsDonnees lstEltsUtilisantLeSchema = new CListeObjetsDonnees(ContexteDonnee, typeof(CSpvElementDeGraphe));
            lstEltsUtilisantLeSchema.Filtre = new CFiltreData(CSpvElementDeGraphe.c_champIdSchemaSmt + "=@1",
                schema.Id);
            foreach (CSpvElementDeGraphe elt in lstEltsUtilisantLeSchema.ToArrayList())
            {

                CSpvElementDeGrapheSousSchema eltSpvSousSchema = elt.GetElementDuBonType() as CSpvElementDeGrapheSousSchema;
                if (eltSpvSousSchema != null)
                {
                    CNoeudDeGrapheReseau noeudDepart = eltSpvSousSchema.NoeudDepart;
                    CNoeudDeGrapheReseau noeudArrive = eltSpvSousSchema.NoeudArrive;
                    CArbreOperationnel arbre = new CArbreOperationnel();
                    CGrapheReseau graphe = baseGraphes.GetGrapheExistant(schema, eltSpvSousSchema.SensGraphe);
                    if (graphe == null)
                    {
                        graphe = new CGrapheReseau(baseGraphes);
                        result = graphe.CalculeGraphe(schema, eltSpvSousSchema.SensGraphe);
                        if (!result)
                            return result;
                    }
                    result = arbre.CalculArbreRedondanceAuto(schema, graphe, noeudDepart, noeudArrive);
                    if (!result)
                        return result;
                    CElementDeArbreOperationnelSousSchema eltOp = new CElementDeArbreOperationnelSousSchema(null);
                    eltOp.ElementDeArbre = arbre.ElementRacine;
                    eltOp.IdSchema = schema.Id;
                    eltOp.NoeudArrive = noeudArrive;
                    eltOp.NoeudDepart = noeudDepart;

                    result = CObjetDonneeAIdNumerique.Delete(eltSpvSousSchema.ElementsFils, true);
                    if (!result)
                        return result;
                    result = eltSpvSousSchema.FillFromElementDeGraphe(eltOp);
                    if (!result)
                        return result;
                }

            }

            return result;
        }
    }
}
