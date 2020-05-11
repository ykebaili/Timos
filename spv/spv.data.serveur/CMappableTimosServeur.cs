using System;
using System.Collections.Generic;
using System.Text;
using sc2i.data.serveur;
using sc2i.data;
using System.Collections;
using sc2i.common;
using System.Data;
using System.Reflection;

namespace spv.data.serveur
{
    public abstract class CMappableTimosServeur<TypeTimos, TypeSpv> : CObjetServeur
        where TypeSpv : CMappableAvecTimos<TypeTimos, TypeSpv>
        where TypeTimos : class, IObjetDonneeAIdNumerique
    {
        public CMappableTimosServeur(int nIdSession)
            : base(nIdSession)
        {
        }

        /// <summary>
        /// Enregistre une fonction de propagation des éléments timos
        /// vers les éléments SPV. Si un élément Timos est modifié, ou créé,
        /// la propagation avec création créera automatiquement l'élément SPV
        /// s'il n'existe pas
        /// </summary>
        public static void RegisterPropagation()
        {
            CGestionnaireHookTraitementAvantSauvegarde.RegisterHook(typeof(TypeTimos), PropageObjetTimos);
        }

        
        //////////////////////////////////////////////////////////////////
        /// <summary>
        /// fonctionnement interne, voir ShouldCreateObjetSpv
        /// </summary>
        /// <param name="objetTimos"></param>
        /// <returns></returns>
        private static bool StaticShouldCreateObjetSpv(TypeTimos objetTimos)
        {
            string strNomTable = CContexteDonnee.GetNomTableForType ( typeof(TypeSpv) );
            CMappableTimosServeur<TypeTimos, TypeSpv> instanceDeThis = CContexteDonnee.GetTableLoader(strNomTable, null, objetTimos.ContexteDonnee.IdSession) as CMappableTimosServeur<TypeTimos, TypeSpv>;
            if (instanceDeThis != null)
                return instanceDeThis.ShouldAutoCreateObjetSpv(objetTimos);
            return false;
        }

        //////////////////////////////////////////////////////////////////
        /// <summary>
        /// Retourne true si un objet SPV doit être créé automatiquement pour cet objet TIMOS (si cette fonction
        /// est appelée, c'est que l'objet SPV n'existe pas !)
        /// </summary>
        /// <param name="objetTimos"></param>
        /// <returns></returns>
        protected abstract bool ShouldAutoCreateObjetSpv(TypeTimos objetTimos);

        //////////////////////////////////////////////////////////////////
        private static void PropageObjetTimos(
            CContexteDonnee contexte,
            Hashtable tableData,
            ref CResultAErreur result)
        {
            if (!result)
                return;
            DataTable dt = contexte.Tables[CContexteDonnee.GetNomTableForType(typeof(TypeTimos))];
            ArrayList rows = new ArrayList(dt.Rows);
            foreach (DataRow row in rows)
            {
                if (row.RowState != DataRowState.Unchanged)
                {
                    switch (row.RowState)
                    {
                        case DataRowState.Added:
                        case DataRowState.Modified:
                            TypeTimos objetTimos = Activator.CreateInstance(typeof(TypeTimos), new object[] { row }) as TypeTimos;
                            try
                            {
                                
                                TypeSpv objetSpv = CMappableAvecTimos<TypeTimos, TypeSpv>.GetObjetSpvFromObjetTimos(objetTimos);
                                if (objetSpv == null && StaticShouldCreateObjetSpv(objetTimos))
                                    objetSpv = CMappableAvecTimos<TypeTimos, TypeSpv>.GetObjetSpvFromObjetTimosAvecCreation(objetTimos);
                                else if (objetSpv != null)
                                    objetSpv.CopyFromObjetTimos(objetTimos);
                            }
                            catch (Exception e)
                            {
                                result.EmpileErreur(new CErreurException(e));
                                result.EmpileErreur(I.T("Error while applying supervision datas from @1|20006", objetTimos.DescriptionElement));
                                return;
                            }

                            break;
                        default:
                            break;
                    }
                }
            }//foreach (DataRow row in rows)
        }

        ///////////////////////////////////////////////////////////////
        public override Type GetTypeObjets()
        {
            return typeof(TypeSpv);
        }
        
    }


}
