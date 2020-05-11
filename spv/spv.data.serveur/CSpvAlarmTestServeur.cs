using System;
using System.Data;
using System.Collections;
using System.Data.OracleClient;

using sc2i.data;
using sc2i.common;
using sc2i.data.serveur;
using spv.data;


namespace spv.data.serveur
{
    public class CSpvAlarmTestServeur : CObjetServeur
    {

        ///////////////////////////////////////////////////////////////
        public CSpvAlarmTestServeur(int nIdSession)
            : base(nIdSession)
        {
        }

        ///////////////////////////////////////////////////////////////
        public override string GetNomTable()
        {
            return CSpvAlarmTest.c_nomTable;
        }



        public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
        {
            CResultAErreur result = CResultAErreur.True;
            DataTable dt = contexte.Tables[CSpvAlarmTest.c_nomTable];
            if (dt != null)
            {
                ArrayList rows = new ArrayList(dt.Rows);
                CSpvAlarmTest spvAlarmTest;

                foreach (DataRow row in rows)
                {
                    if (row.RowState == DataRowState.Added || row.RowState == DataRowState.Modified)
                    {
                        spvAlarmTest = new CSpvAlarmTest(row);
                        if (spvAlarmTest.AlarmNum == null)
                        {
                            spvAlarmTest.AlarmNum = 0;

                        }


                           
                            }
                    }
                }
                return result;
        }

        ///////////////////////////////////////////////////////////////
        public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
        {
            CResultAErreur result = CResultAErreur.True;
            try
            {
                //TODO : Insérer la logique de vérification de donnée
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
            return typeof(CSpvAlarmTest);
        }
    }
}
