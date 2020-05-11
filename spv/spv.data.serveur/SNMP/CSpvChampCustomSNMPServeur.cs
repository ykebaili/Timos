using System;
using System.Data;
using System.Collections;

using sc2i.data;
using sc2i.common;
using sc2i.data.serveur;
using spv.data;
using timos.data;
using sc2i.data.dynamic;

namespace spv.data.serveur
{
   [AutoExec("Autoexec")]
	public class CSpvChampCustomSNMPServeur : CMappableTimosServeur<CChampCustom, CSpvChampCustomSNMP>
	{
        public static void Autoexec()
        {
            RegisterPropagation();
        }

		///////////////////////////////////////////////////////////////
		public CSpvChampCustomSNMPServeur ( int nIdSession )
			:base(nIdSession)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public override string GetNomTable()
		{
			return CSpvChampCustomSNMP.c_nomTable;
		}
		
		///////////////////////////////////////////////////////////////
		public override CResultAErreur VerifieDonnees ( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
			}
			catch ( Exception e )
			{
				result.EmpileErreur( new CErreurException ( e ) );
			}

			return result;
		}


        ///////////////////////////////////////////////////////////////
        public override Type GetTypeObjets()
        {
            return typeof(CSpvChampCustomSNMP);
        }


        //////////////////////////////////////////////////////////////////
        protected override bool ShouldAutoCreateObjetSpv(CChampCustom objetTimos)
        {
            return objetTimos != null && objetTimos.CodeRole == CEquipementLogique.c_roleChampCustom;
        }

        public override CResultAErreur BeforeSave(CContexteSauvegardeObjetsDonnees contexte, IDataAdapter adapter, DataRowState etatsAPrendreEnCompte)
        {
            return CResultAErreur.True;
        }

       
	}
}
