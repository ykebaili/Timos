using System;
using System.Collections.Generic;
using System.Text;
using sc2i.common;
using sc2i.data.serveur;
using sc2i.data;
using spv.data;
using sc2i.data.dynamic;

namespace spv.serveur
{
	[AutoExec("Autoexec")]
	public class CSpvServeur
	{
		public const string c_spvConnection = "SPV_DATA";
		//Récuperation du type de connection

		public static void Autoexec()
		{
			CSc2iDataServer.AddDefinitionConnexion(
				new CDefinitionConnexionDataSource(
				c_spvConnection,
				typeof(COracleDatabaseConnexion),
				CSpvServeurRegistre.DatabaseConnexionString,
                CSpvServeurRegistre.PrefixeTablesSPV));
			CSc2iDataServer.SetIdConnexionForAssembly("spv.data.serveur", c_spvConnection);
            COracleDatabaseConnexion cnx = CSc2iDataServer.GetInstance().GetDatabaseConnexion(0, c_spvConnection) as COracleDatabaseConnexion;
            ((COracleDatabaseConnexion)cnx).NomTableSpaceIndex = CSpvServeurRegistre.NomTableSpaceIndexOracle;
            cnx.RunStatement("SET TRANSACTION ISOLATION LEVEL SERIALIZABLE");
            

            
            
		}
	}
}
