using System;
using System.Collections;

using System.Drawing;
using sc2i.common;
using sc2i.multitiers.client;
using sc2i.expression;
using sc2i.data;
using System.Reflection;
using spv.data;
using System.Collections.Generic;
using System.Data;

namespace sc2i.process
{
	/// <summary>
	/// Description résumée de CActionVerifSynchroTimosToSpv.
	/// </summary>
	[AutoExec("Autoexec")]
	public class CActionVerifSynchroTimosToSpv : CActionLienSortantSimple
	{
		private C2iExpression m_expressionDateLimite = null;

		/// /////////////////////////////////////////////////////////
		public CActionVerifSynchroTimosToSpv( CProcess process )
			:base(process)
		{
			Libelle = I.T("Supervision entites check|20033");
		}

		/// /////////////////////////////////////////////////////////
		public static void Autoexec()
		{
			CGestionnaireActionsDisponibles.RegisterTypeAction(
                I.T("Supervision entites check|20033"),
                I.T("Supervision entites check|20033"),
				typeof(CActionVerifSynchroTimosToSpv),
				CGestionnaireActionsDisponibles.c_categorieMetier );
		}

		/// ////////////////////////////////////////////////////////
		public override void AddIdVariablesNecessairesInHashtable ( Hashtable table )
		{
			AddIdVariablesExpressionToHashtable(m_expressionDateLimite, table);
		}

		/// /////////////////////////////////////////////////////////
		public override bool PeutEtreExecuteSurLePosteClient
		{
			get { return false; }
		}

		

		// ////////////////////////////////////////////////////////
		public override CResultAErreur VerifieDonnees()
		{
			CResultAErreur result = CResultAErreur.True;

			return result;
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
			if ( !result )
				return result;
		
	
			return result;
		}

		
		/// ////////////////////////////////////////////////////////
		protected override CResultAErreur  MyExecute(CContexteExecutionAction contexte)
		{
			CResultAErreur result = CResultAErreur.True;

            List<Type> lstTypesAVerifier = new List<Type>();
			//Trouve tous les types héritant de CMappableTimos
            foreach (Assembly ass in sc2i.common.CGestionnaireAssemblies.GetAssemblies())
            {
                foreach (Type tp in ass.GetTypes())
                {
                    if (typeof(IObjetSPVAvecObjetTimos).IsAssignableFrom(tp))
                        lstTypesAVerifier.Add(tp);
                }
            }
            List<string> lstTablesDansOrdre = new List<string>();
            using (CContexteDonnee ctxTmp = new CContexteDonnee(contexte.IdSession, true, false))
            {
                foreach (Type tp in lstTypesAVerifier)
                {
                    string strTable = CContexteDonnee.GetNomTableForType(tp);
                    if ( strTable != null )
                        ctxTmp.GetTableSafe(strTable);
                }
                foreach (DataTable table in ctxTmp.GetTablesOrderInsert())
                    lstTablesDansOrdre.Add(table.TableName);
            }
            foreach (string strNomTable in lstTablesDansOrdre)
            {
                Type tp = CContexteDonnee.GetTypeForTable(strNomTable);
                Type tpParent = tp;
                Type[] generics = new Type[0];
                while (tpParent != null && generics.Length == 0)
                {
                    if (tpParent.IsGenericType && tpParent.GetGenericTypeDefinition() == typeof(CMappableAvecTimos<,>))
                        generics = tpParent.GetGenericArguments();
                    tpParent = tpParent.BaseType;
                }
                if (generics.Length == 0)
                    continue;
                
                IObjetSPVAvecObjetTimos obj = Activator.CreateInstance(tp, new object[] { contexte.ContexteDonnee }) as IObjetSPVAvecObjetTimos;
                Type typeTimos = obj.GetTypeObjetsTimos();
                //Lit tous les objets TIMOS
                CListeObjetsDonnees lstObjetsTimos = new CListeObjetsDonnees(contexte.ContexteDonnee, typeTimos);
                lstObjetsTimos.AssureLectureFaite();
                CListeObjetsDonnees lstObjetsSpv = new CListeObjetsDonnees(contexte.ContexteDonnee, obj.GetType());
                lstObjetsSpv.AssureLectureFaite();
                string strIdObjetTimosInObjetSpv = obj.GetChampIdObjetTimos();
                Type tpMappable = typeof(CMappeurTimos<,>).MakeGenericType ( generics );
                IMappeurTimosNonGenerique mappeur = Activator.CreateInstance ( tpMappable ) as IMappeurTimosNonGenerique;
                foreach (CObjetDonneeAIdNumerique objTimos in (CObjetDonneeAIdNumerique[])lstObjetsTimos.ToArray(typeof(CObjetDonneeAIdNumerique)))
                {
                    CObjetDonneeAIdNumerique objSpv = Activator.CreateInstance(tp, new object[] { contexte.ContexteDonnee }) as CObjetDonneeAIdNumerique;
                    if (!objSpv.ReadIfExists(new CFiltreData(strIdObjetTimosInObjetSpv + "=@1",
                        objTimos.Id), false))
                    {

                        mappeur.GetObjetSpvFromObjetTimosAvecCreationSansGenerique(objTimos);
                    }
                }
            }
			return result;
		}
	}
}
