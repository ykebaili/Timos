using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using sc2i.common;
using sc2i.process;
using tiag.client;
//using timos.data;
//using timos.data.tiag;
using sc2i.process.serveur;
using sc2i.data;
using tiag.data;


namespace PasserelleTiag
{
	[AutoExec("Autoexec")]
	public class CActionEnvoyerVersTiag : IActionSurServeur
	{
		public const string c_strServerKey = "TIMOS_SMT";

		public const string c_parametreTypeAEnvoyer = "Type Element";
		public const string c_parametreIdElement = "Id Element";

		public CActionEnvoyerVersTiag( )
			: base(  )
		{
		}

		public static void Autoexec()
		{
			CDeclencheurActionSurServeur.RegisterAction ( new CActionEnvoyerVersTiag() );
		}

		
	
		#region IActionSurServeur Membres

		public string CodeType
		{
			get { return "SENDTOTIAG"; }
		}

		public string Description
		{
			get { return "Envoie l'objet demandé (type et id) à TIAG"; }
		}

		public CResultAErreur Execute(int nIdSession, System.Collections.Hashtable valeursParametres)
		{
			CResultAErreur resErreur = CResultAErreur.True;

			string strType = (string)valeursParametres[c_parametreTypeAEnvoyer];
			if ( strType == null )
			{
				resErreur.EmpileErreur("Le type d'élément à envoyer n'est pas renseigné");
				return resErreur;
			}
			Type typeElement = CActivatorSurChaine.GetType ( strType );
			if ( typeElement == null )
			{
				resErreur.EmpileErreur("Le type d'élément à envoyer n'est pas correct ("+strType+")");
				return resErreur;
			}
			if ( !(valeursParametres[c_parametreIdElement] is int ) )
			{
				resErreur.EmpileErreur("L'id de l'élément n'est pas correct");
				return resErreur;
			}

			DataSet ds = CUtilClientTiag.GetDataSetStructure();

			using ( CContexteDonnee contexteDonnee = new CContexteDonnee ( nIdSession, true, false ) )
			{
				CObjetDonneeAIdNumeriqueAuto objet = (CObjetDonneeAIdNumeriqueAuto)Activator.CreateInstance ( typeElement, contexteDonnee );
				if ( !objet.ReadIfExists ( (int)valeursParametres[c_parametreIdElement] ) )
				{
					resErreur.EmpileErreur("L'élément demandé n'existe pas ("+
						strType+" / "+valeursParametres[c_parametreIdElement].ToString()+")");
					return resErreur;
				}

			
				CUtilClientTiag.FillDataSet ( (IElementAInterfaceTiag)objet, ds );
			}

            CServiceDistantTiag service = new CServiceDistantTiag("tcp://127.0.0.1:8182");
			//TiagService.TiagService service = new TiagService.TiagService();

			resErreur = CResultAErreur.True;
			CResultDataSet result = service.OpenSession(c_strServerKey);
			int nIdSessionTiag = -1;
			try
			{
				nIdSessionTiag = (int)result.Data;
				result = service.OnModifieDonnees(nIdSessionTiag, ds);
			}
			catch (Exception e)
			{
				resErreur.EmpileErreur(new CErreurException(e));
			}
			finally
			{
				service.CloseSession(nIdSessionTiag);
			}
			if (!result)
			{
				foreach (string strErreur in result.GetErreurs())
					resErreur.EmpileErreur(strErreur);
			}
			return resErreur;
		}

		public string Libelle
		{
			get { return "Envoyer vers Tiag"; }
		}

		public string[] NomsParametres
		{
			get { return new string[]{c_parametreTypeAEnvoyer, c_parametreIdElement }; }
		}

		#endregion
	}
}
