using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;
using timos.data;

using sc2i.workflow.serveur;

namespace timos.data.serveur
{
    public class  CTypeLienReseauSupportServeur : CObjetServeur
    {

        		//-------------------------------------------------------------------
		public CTypeLienReseauSupportServeur( int nIdSession )
			:base ( nIdSession )
		{
		}

		
		/// ////////////////////////////////////////////////////////////
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CTypeLienReseauSupport relation = (CTypeLienReseauSupport)objet;
				if ( relation.TypeSupporté == null )
					result.EmpileErreur(I.T("Supported link type must be defined|30005"));
				if ( relation.TypeSupportant == null )
					result.EmpileErreur(I.T("Supporting link type must be defined|30006"));
			}
			catch ( Exception e )
			{
				result.EmpileErreur( new CErreurException(e));
			}
			return result;
		}

		/// ////////////////////////////////////////////////////////////
		public override string GetNomTable()
		{
			return CTypeLienReseauSupport.c_nomTable;
		}


		/// ////////////////////////////////////////////////////////////
		public override Type GetTypeObjets()
		{
			return typeof(CTypeLienReseauSupport);
		}


    }
}
