using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;

using timos.securite;
using System.Collections.Generic;

namespace timos.data.projet.besoin
{
    /// <summary>
    /// Description résumée de CBesoinServeur.
    /// </summary>
    public class CBesoinServeur : CObjetServeurAvecBlob
    {
        //-------------------------------------------------------------------
#if PDA
		public CBesoinServeur()
			:base()
		{
		}
#endif
        //-------------------------------------------------------------------
        public CBesoinServeur(int nIdSession)
            : base(nIdSession)
        {
        }
        //-------------------------------------------------------------------
        public override string GetNomTable()
        {
            return CBesoin.c_nomTable;
        }
        //-------------------------------------------------------------------
        public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
        {
            CResultAErreur result = CResultAErreur.True;
            try
            {
                CBesoin besoin = (CBesoin)objet;

                if(besoin.Libelle == null || besoin.Libelle == "")
                    result.EmpileErreur(I.T( "The need label cannot be empty|20186"));
                if (besoin.PhaseSpecifications == null)
                    result.EmpileErreur(I.T("Need must belong to a need specification|20188"));
            }
            catch (Exception e)
            {
                result.EmpileErreur(new CErreurException(e));
            }
            return result;
        }
        //-------------------------------------------------------------------
        public override Type GetTypeObjets()
        {
            return typeof(CBesoin);
        }

        //-------------------------------------------------------------------
        public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
        {
            CResultAErreur result = CResultAErreur.True;
            try
            {
                result = base.TraitementAvantSauvegarde(contexte);
                if (result)
                    result = SObjetHierarchiqueServeur.TraitementAvantSauvegarde(contexte, GetNomTable());
            }
            catch (Exception e)
            {
                result.EmpileErreur(new CErreurException(e));
                return result;
            }
            if (!result)
                return result;
            DataTable table = contexte.Tables[GetNomTable()];
            if (table == null)
                return result;
            return result;                    
        }

        #region IObjetHierarchiqueACodeHierarchique Membres

        public string ChampCodeSystemeComplet
        {
            get { throw new NotImplementedException(); }
        }

        public string ChampCodeSystemePartiel
        {
            get { throw new NotImplementedException(); }
        }

        public string ChampIdParent
        {
            get { throw new NotImplementedException(); }
        }

        public string ChampNiveau
        {
            get { throw new NotImplementedException(); }
        }

        public void ChangeCodePartiel(string str_code)
        {
            throw new NotImplementedException();
        }

        public string CodePartielDefaut
        {
            get { throw new NotImplementedException(); }
        }

        public string CodeSystemeComplet
        {
            get { throw new NotImplementedException(); }
        }

        public string CodeSystemePartiel
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsChildOf(IObjetHierarchiqueACodeHierarchique objet)
        {
            throw new NotImplementedException();
        }

        public string Libelle
        {
            get { throw new NotImplementedException(); }
        }

        public int NbCarsParNiveau
        {
            get { throw new NotImplementedException(); }
        }

        public int Niveau
        {
            get { throw new NotImplementedException(); }
        }

        public IObjetHierarchiqueACodeHierarchique ObjetParent
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public CListeObjetsDonnees ObjetsFils
        {
            get { throw new NotImplementedException(); }
        }

        public void RecalculeCodeComplet()
        {
            throw new NotImplementedException();
        }

        public void RecalculeCodeCompletFils()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IObjetDonneeAutoReference Membres

        public string ChampParent
        {
            get { throw new NotImplementedException(); }
        }

        public string ProprieteListeFils
        {
            get { throw new NotImplementedException(); }
        }

        #endregion

        #region IObjetDonneeAIdNumerique Membres

        public string GetChampId()
        {
            throw new NotImplementedException();
        }

        public int Id
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool ReadIfExists(int nId)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IObjetDonnee Membres

        public CResultAErreur CommitEdit()
        {
            throw new NotImplementedException();
        }

        public void CreateNew(params object[] valeursCles)
        {
            throw new NotImplementedException();
        }

        public void CreateNewInCurrentContexte(object[] valeursCles)
        {
            throw new NotImplementedException();
        }

        public CResultAErreur Delete()
        {
            throw new NotImplementedException();
        }

        public string DescriptionElement
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsDependanceChargee(string strNomTable, params string[] strChampsFille)
        {
            throw new NotImplementedException();
        }

        public bool ReadIfExists(object[] keys)
        {
            throw new NotImplementedException();
        }

        public bool ReadIfExists(CFiltreData filtre)
        {
            throw new NotImplementedException();
        }

        public C2iDataRow Row
        {
            get { throw new NotImplementedException(); }
        }

        #endregion

        #region IObjetAContexteDonnee Membres

        public CContexteDonnee ContexteDonnee
        {
            get { throw new NotImplementedException(); }
        }

        #endregion

        #region IObjetAModificationContextuelle Membres

        public string ContexteDeModification
        {
            get { throw new NotImplementedException(); }
        }

        #endregion

        #region IObjetDonneeAIdNumeriqueAuto Membres

        public void CreateNew()
        {
            throw new NotImplementedException();
        }

        public void CreateNewInCurrentContexte()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
