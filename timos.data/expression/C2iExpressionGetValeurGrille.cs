using System;
using System.Collections;
using System.Reflection;

using sc2i.common;
using sc2i.data;
using sc2i.expression;
using sc2i.multitiers.client;
using sc2i.workflow;



namespace timos.data
{
	/// <summary>
	/// Récupère une données cumulée précalculée à partir d'un
	/// <see cref="sc2i.data.dynamic.CTypeDonneeCumulee">Type de donnée cumulé</see>
	/// </summary>
	[Serializable]
	[AutoExec("Autoexec")]
	public class C2iExpressionGetValeurGrille : C2iExpressionAnalysable
	{
		/// //////////////////////////////////////////
		public C2iExpressionGetValeurGrille()
		{
		}

	
		/// //////////////////////////////////////////
		public static void Autoexec()
		{
			CAllocateur2iExpression.Register2iExpression ( new C2iExpressionGetValeurGrille().IdExpression,
				typeof(C2iExpressionGetValeurGrille) );
		}

		/// //////////////////////////////////////////
        protected override CInfo2iExpression GetInfosSansCache()
		{
			CInfo2iExpression info = new CInfo2iExpression( 0, "GetGridValue", 
				new CTypeResultatExpression(typeof(double), false), 
				"GetGridValue(Code, line, Column)\r\nReturns the grid value (according to code) for the requested line and column",
				CInfo2iExpression.c_categorieDivers);
			info.AddDefinitionParametres( new CInfo2iDefinitionParametres(typeof(string), typeof(double), typeof(double) ) );
			info.AddDefinitionParametres( new CInfo2iDefinitionParametres(typeof(string), typeof(string), typeof(double) ) );
			info.AddDefinitionParametres( new CInfo2iDefinitionParametres(typeof(string), typeof(double), typeof(string) ) );
			info.AddDefinitionParametres( new CInfo2iDefinitionParametres(typeof(string), typeof(string), typeof(string) ) );
			return info;
		}

		/// //////////////////////////////////////////
		public override int GetNbParametresNecessaires()
		{
			return 3;//Nombre variable
		}


		/// //////////////////////////////////////////
		public override CResultAErreur MyEval ( CContexteEvaluationExpression ctx, object[] listeParametres )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				//Cherche un objet donnée dans le contexte d'évaluation pour pouvoir
				//avoir un contexte de donnee;
				CContexteDonnee contexte = null;
				bool bMyOwnContexte = false;
				if ( !(ctx.ObjetSource is CObjetDonnee) )
				{
					contexte = new CContexteDonnee ( CSessionClient.GetSessionUnique().IdSession, true, false );
					bMyOwnContexte = true;
				}
				else
					contexte = ((CObjetDonnee)ctx.ObjetSource).ContexteDonnee;
				try
				{
					CGrilleGenerique grille = new CGrilleGenerique ( contexte );
					if ( !grille.ReadIfExists ( new CFiltreData ( 
						CGrilleGenerique.c_champCode +"=@1",
						listeParametres[0].ToString() ) ) )
					{
						result.EmpileErreur(I.T("Can not find grid @1|20003",listeParametres[0].ToString()));
						return result;
					}
					CMatriceDonnee matrice = grille.MatriceDonnee;
					double fVal = 0;
					try
					{
						fVal = matrice.GetValeur ( listeParametres[1], listeParametres[2] );
					}
					catch
					{
						fVal = matrice.ValeurDefaut;
					}
					result.Data= fVal;
					return result;
				}
				catch ( Exception e )
				{
					result.EmpileErreur ( new CErreurException ( e ) );
				}
				finally
				{
					if ( bMyOwnContexte )
						contexte.Dispose();
				}
			}
			catch ( Exception e )
			{
				result.EmpileErreur ( new CErreurException ( e ) );
				return result;
			}
			return result;
		}
	}
}
