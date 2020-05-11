using System;
using System.Data;
using sc2i.data;
using sc2i.common;
using sc2i.data.serveur;
using spv.data;

namespace spv.data.serveur
{
	public class CSpvEvenementReseauServeur : CObjetServeur
	{
		
		///////////////////////////////////////////////////////////////
		public CSpvEvenementReseauServeur ( int nIdSession )
			:base(nIdSession)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public override string GetNomTable()
		{
			return CSpvEvenementReseau.c_nomTable;
		}
		
		///////////////////////////////////////////////////////////////
		public override CResultAErreur VerifieDonnees ( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				//TODO : Insérer la logique de vérification de donnée
                CSpvEvenementReseau alarm = (CSpvEvenementReseau)objet;
                if (! alarm.VerifieDateTexte())
                    result.EmpileErreur(I.T("Empty date or bad value in text date|50011"));
                
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
			return typeof(CSpvEvenementReseau);
		}

        public override bool ActivateQueryCache
        {
            get
            {
                return false;
            }
        }
	}
}
