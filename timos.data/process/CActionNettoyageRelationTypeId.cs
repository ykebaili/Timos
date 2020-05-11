using System;
using System.Drawing;
using System.Data;
using System.Collections;
using System.Collections.Generic;

using sc2i.data;
using sc2i.process;
using sc2i.common;
using sc2i.expression;
using sc2i.data.dynamic;
using sc2i.formulaire;

using sc2i.workflow;
using sc2i.documents;
using sc2i.multitiers.client;
using timos.acteurs;
using timos.securite;
using timos.data;
using System.IO;
using sc2i.data.Excel;
using sc2i.process.workflow;
using timos.data.process.workflow;
using System.Text;


namespace sc2i.process
{
	/// <summary>
	/// Description résumée de CActionModifierPropriete.
	/// </summary>
	[AutoExec("Autoexec")]
	public class CActionNettoyageRelationsTypeId : CActionLienSortantSimple
	{
        /// /////////////////////////////////////////
        private List<Type> m_typesANettoyer = new List<Type>();

		/// /////////////////////////////////////////
		public CActionNettoyageRelationsTypeId( CProcess process )
			:base(process)
		{
			Libelle = I.T("Clean non RI relations|20201");
		}

		/// /////////////////////////////////////////////////////////
		public static void Autoexec()
		{
			CGestionnaireActionsDisponibles.RegisterTypeAction(
                I.T("Clean non RI relations|20201"),
				I.T( "Database utility : clean database relations without referential integrity|20202"),
				typeof(CActionNettoyageRelationsTypeId),
				CGestionnaireActionsDisponibles.c_categorieDonnees );
		}


		

		/// /////////////////////////////////////////////////////////
		public override bool PeutEtreExecuteSurLePosteClient
		{
			get { return false; }
		}

        /// /////////////////////////////////////////
        public IEnumerable<Type> TypesANettoyer
        {
            get
            {
                return m_typesANettoyer.AsReadOnly();
            }
            set
            {
                if (value == null)
                    m_typesANettoyer = new List<Type>();
                else
                    m_typesANettoyer = new List<Type>(value);
            }
        }


        /// /////////////////////////////////////////
        private int GetNumVersion()
        {
            return 0;
        }
		
		/// ////////////////////////////////////////////////////////
		protected override CResultAErreur MySerialize ( C2iSerializer serializer )
		{
			int nVersion = GetNumVersion();
			CResultAErreur result = serializer.TraiteVersion ( ref nVersion );
			if ( !result )
				return result;
			result = base.MySerialize( serializer );

            int nNb = m_typesANettoyer.Count;
            serializer.TraiteInt(ref nNb);
            switch (serializer.Mode)
            {
                case ModeSerialisation.Ecriture:
                    {
                        foreach (Type tp in m_typesANettoyer)
                        {
                            Type tpTemp = tp;
                            serializer.TraiteType(ref tpTemp);
                        }
                    }
                    break;
                case ModeSerialisation.Lecture:
                    {
                        List<Type> lst = new List<Type>();
                        for (int n = 0; n < nNb; n++)
                        {
                            Type tpTemp = null;
                            serializer.TraiteType(ref tpTemp);
                            if (tpTemp != null)
                                lst.Add(tpTemp);
                        }
                        m_typesANettoyer = lst;

                    }
                    break;
            }
			return result;
		}

		
		/// ////////////////////////////////////////////////////////
		public override CResultAErreur VerifieDonnees()
		{
			CResultAErreur result = base.VerifieDonnees();
           
			return result;
		}

		/// ////////////////////////////////////////////////////////
        protected override CResultAErreur MyExecute(CContexteExecutionAction contexte)
        {
            CResultAErreur result = CResultAErreur.True;

            foreach (Type tp in m_typesANettoyer)
            {
                object[] attribs = tp.GetCustomAttributes(typeof(RelationTypeIdAttribute), true);
                if (attribs.Length == 1)
                {
                    RelationTypeIdAttribute rel = attribs[0] as RelationTypeIdAttribute;
                    result = CleanType(
                        contexte,
                        tp, 
                        rel);
                    if (!result)
                        return result;
                }
            }

            return result;
        }

        /// ////////////////////////////////////////////////////////
        private CResultAErreur CleanType(
            CContexteExecutionAction contexteExecution,
            Type tpToClean,
            RelationTypeIdAttribute rel)
        {
            if (tpToClean == typeof(CVersionDonneesObjet))
                return CResultAErreur.True;
            if (contexteExecution.IndicateurProgression != null)
                contexteExecution.IndicateurProgression.SetInfo("Cleaning " +
                    DynamicClassAttribute.GetNomConvivial(tpToClean));
            CResultAErreur result = CResultAErreur.True;
            //Identifie tous les types liés
            C2iRequeteAvancee requete = new C2iRequeteAvancee(null);
            requete.TableInterrogee = rel.TableFille;
            requete.ListeChamps.Add(new C2iChampDeRequete(
                "TYPE_ELEMENT",
                new CSourceDeChampDeRequete(rel.ChampType),
                typeof(string),
                OperationsAgregation.None,
                true));
            result = requete.ExecuteRequete(contexteExecution.IdSession);
            if (!result)
                return result;
            if (!typeof(CObjetDonneeAIdNumerique).IsAssignableFrom(tpToClean))
                return result;
            DataTable table = result.Data as DataTable;
            if (table == null || table.Rows.Count == 0)
                return result;
            CStructureTable structRel = CStructureTable.GetStructure (tpToClean); 
            foreach (DataRow row in table.Rows)
            {
                if (row[0] is string)
                {
                    Type tpLie = CActivatorSurChaine.GetType((string)row[0]);
                    string strNomTable = tpLie != null ? CContexteDonnee.GetNomTableForType(tpLie) : null;
                    if (strNomTable != null && typeof(CObjetDonneeAIdNumerique).IsAssignableFrom(tpLie))
                    {
                        System.Console.WriteLine(tpToClean.ToString() + " / " + tpLie.ToString());
                        //trouve tous les ids associés
                        requete = new C2iRequeteAvancee(null);
                        requete.TableInterrogee = rel.TableFille;
                        requete.ListeChamps.Add(new C2iChampDeRequete(
                            "ETT_ID",
                            new CSourceDeChampDeRequete(rel.ChampId),
                            typeof(int),
                            OperationsAgregation.None,
                            true));
                        requete.FiltreAAppliquer = new CFiltreData(rel.ChampType + "=@1",
                            tpLie.ToString());
                        result = requete.ExecuteRequete(contexteExecution.IdSession);
                        if (!result)
                            return result;
                        DataTable tableIds = result.Data as DataTable;
                        List<int> lstIdsCherchees = new List<int>();
                        if (tableIds != null)
                        {
                            StringBuilder bl = new StringBuilder();
                            foreach (DataRow rowId in tableIds.Rows)
                            {
                                if (rowId[0] is int)
                                {
                                    lstIdsCherchees.Add((int)rowId[0]);
                                    bl.Append((int)rowId[0]);
                                    bl.Append(',');
                                }
                            }
                            if (bl.Length > 0)
                            {
                                CStructureTable structure = CStructureTable.GetStructure(tpLie);
                                bl.Remove(bl.Length - 1, 1);
                                requete = new C2iRequeteAvancee(null);
                                requete.TableInterrogee = strNomTable;
                                requete.ListeChamps.Add(new C2iChampDeRequete(
                                    "ETT_ID",
                                    new CSourceDeChampDeRequete(structure.ChampsId[0].NomChamp),
                                    typeof(int),
                                    OperationsAgregation.None,
                                    false));
                                requete.FiltreAAppliquer = new CFiltreData(
                                    structure.ChampsId[0].NomChamp + " in (" +
                                    bl.ToString() + ")");
                                result = requete.ExecuteRequete(contexteExecution.IdSession);
                                if (!result)
                                    return result;
                                DataTable tableIdsTrouvees = result.Data as DataTable;
                                HashSet<int> setTrouves = new HashSet<int>();
                                if (tableIdsTrouvees != null)
                                {
                                    foreach (DataRow rowId in tableIdsTrouvees.Rows)
                                    {
                                        if (rowId[0] is int)
                                            setTrouves.Add((int)rowId[0]);
                                    }
                                    bl = new StringBuilder();
                                    foreach (int nId in lstIdsCherchees.ToArray())
                                    {
                                        if (!setTrouves.Contains(nId))
                                        {
                                            bl.Append(nId);
                                            bl.Append(',');
                                        }
                                    }
                                    if (bl.Length > 0)
                                    {
                                        bl.Remove(bl.Length - 1, 1);
                                        //Trouve la liste des relTypesIds à virer
                                        requete = new C2iRequeteAvancee(null);
                                        requete.TableInterrogee = rel.TableFille;
                                        requete.ListeChamps.Add(new C2iChampDeRequete(
                                            structRel.ChampsId[0].NomChamp,
                                            new CSourceDeChampDeRequete(structRel.ChampsId[0].NomChamp),
                                            typeof(int),
                                            OperationsAgregation.None,
                                            true));
                                        requete.FiltreAAppliquer = new CFiltreData(
                                            rel.ChampId + " in (" + bl.ToString() + ") and "+
                                            rel.ChampType+"=@1", tpLie.ToString());
                                        result = requete.ExecuteRequete(contexteExecution.IdSession);
                                        if (!result)
                                            return result;
                                        DataTable tableIdsToDelete = result.Data as DataTable;
                                        if (tableIdsToDelete != null)
                                        {
                                            List<int> lstToDelete = new List<int>();
                                            foreach (DataRow rowDel in tableIdsToDelete.Rows)
                                            {
                                                if (rowDel[0] is int)
                                                    lstToDelete.Add((int)rowDel[0]);
                                            }
                                            if (contexteExecution.IndicateurProgression != null)
                                            {
                                                contexteExecution.IndicateurProgression.PushLibelle(
                                                    DynamicClassAttribute.GetNomConvivial(tpToClean) + "/" +
                                                    DynamicClassAttribute.GetNomConvivial((tpLie)));
                                            }
                                            for (int nPart = 0; nPart < lstToDelete.Count; nPart += 100)
                                            {
                                                List<int> lstTmp = new List<int>();
                                                int nMin = Math.Min(nPart + 100, lstToDelete.Count);
                                                for (int n = nPart; n < nMin; n++)
                                                    lstTmp.Add(lstToDelete[n]);
                                                if (contexteExecution.IndicateurProgression != null)
                                                    contexteExecution.IndicateurProgression.SetInfo(nPart.ToString()+"/"+
                                                        lstToDelete.Count);
                                                result = CActionSupprimerEntite.PurgeEntites(contexteExecution.IdSession,
                                                    tpToClean, lstTmp.ToArray());
                                                if (contexteExecution.IndicateurProgression != null &&
                                                    contexteExecution.IndicateurProgression.CancelRequest)
                                                {
                                                    result.EmpileErreur("User cancellation");
                                                }
                                                if (!result)
                                                    return result;
                                            }
                                            if (contexteExecution.IndicateurProgression != null)
                                                contexteExecution.IndicateurProgression.PopLibelle();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }


        public override void AddIdVariablesNecessairesInHashtable(Hashtable table)
        {
            
        }
    }
}
