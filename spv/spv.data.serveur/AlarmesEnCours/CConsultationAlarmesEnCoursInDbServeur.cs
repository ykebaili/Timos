using System;
using System.Data;
using sc2i.data;
using sc2i.common;
using sc2i.data.serveur;
using spv.data;
using System.Collections;

namespace spv.data.serveur
{
    public class CConsultationAlarmesEnCoursInDbServeur : CObjetServeurAvecBlob
    {

        ///////////////////////////////////////////////////////////////
        public CConsultationAlarmesEnCoursInDbServeur(int nIdSession)
            : base(nIdSession)
        {
        }

        ///////////////////////////////////////////////////////////////
        public override string GetNomTable()
        {
            return CConsultationAlarmesEnCoursInDb.c_nomTable;
        }

        ///////////////////////////////////////////////////////////////
        public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
        {
            CResultAErreur result = CResultAErreur.True;
            try
            {
                CConsultationAlarmesEnCoursInDb consultAl = objet as CConsultationAlarmesEnCoursInDb;

                if (consultAl.Libelle.Length == 0)
                    result.EmpileErreur(I.T("Consultation name should be defined|60007"));
                                
                if (!CObjetDonneeAIdNumerique.IsUnique(consultAl, CConsultationAlarmesEnCoursInDb.c_champLibelle, consultAl.Libelle))
                {
                    result.EmpileErreur(I.T("The consultation '@1' already exist|60007", consultAl.Libelle));
                }

                if (consultAl.Parametres.ListeColonnes.Length <= 0)
                {
                    result.EmpileErreur(I.T("Select data to display|60010"));
                }
               
            }
            catch (Exception e)
            {
                result.EmpileErreur(new CErreurException(e));
            }
            return result;
        }

        ///////////////////////////////////////////////////////////////
        public override Type GetTypeObjets()
        {
            return typeof(CConsultationAlarmesEnCoursInDb);
        }

    }
}
