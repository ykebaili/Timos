using System;
using System.Data;
using sc2i.data;
using sc2i.common;
using sc2i.data.serveur;
using spv.data;
using System.Collections;
using System.Data.OracleClient;

namespace spv.data.serveur
{
	public class CSpvAcces_Accesc2Serveur : CObjetServeur
	{
		
		///////////////////////////////////////////////////////////////
		public CSpvAcces_Accesc2Serveur ( int nIdSession )
			:base(nIdSession)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public override string GetNomTable()
		{
			return CSpvAcces_Accesc2.c_nomTable;
		}
		
		///////////////////////////////////////////////////////////////
		public override CResultAErreur VerifieDonnees ( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				//TODO : Insérer la logique de vérification de donnée
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
			return typeof(CSpvAcces_Accesc2);
		}

        public override IDataAdapter GetDataAdapter(DataRowState rowsPriseEnCharge, params string[] champsExclus)
        {
            IDataAdapter adapter = base.GetDataAdapter(rowsPriseEnCharge, champsExclus);
            C2iOracleDataAdapter oracleAdapter = adapter as C2iOracleDataAdapter;
            if (oracleAdapter != null)
            {
                oracleAdapter.RowUpdated += new OracleRowUpdatedEventHandler(OnRowUpdated);
            }
            return oracleAdapter;
        }

        void OnRowUpdated(object sender, OracleRowUpdatedEventArgs e)
        {
            if (e.StatementType == StatementType.Insert)
            {
                CSpvAcces_Accesc2 accesAccesc2 = new CSpvAcces_Accesc2(e.Row);
                OracleCommand cmd = e.Command.Connection.CreateCommand();
                cmd.Transaction = e.Command.Transaction;

                CSpvLienAccesAlarme accesAccesc = accesAccesc2.Acces_Accesc;

                if (accesAccesc.Surveiller == false && accesAccesc.SpvAlarmgeree != null)
                {
                    cmd.CommandText = "Begin SetMaskAdmAccess (" +
                        accesAccesc.Id + ",2); end;";
                    cmd.ExecuteScalar();
                }
            }
        }
	}
}
