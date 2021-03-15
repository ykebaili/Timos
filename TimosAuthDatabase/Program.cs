using sc2i.common;
using sc2i.data;
using sc2i.multitiers.client;
using sc2i.process;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using timos.client;
using timos.securite;

namespace TimosAuthDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            CResultAErreur result = CResultAErreur.True;

            result = UpdateDatabase();
            return;

            string strURL = "tcp://127.0.0.1:8160";
            string strNomTable = "TIMOS_USERS_PREPROD";
            string strChaineDeConnexion = @"Data Source=DESKTOP-VMDEVYK\SQLEXPRESS;Initial Catalog=UTILISATEURS_PROD;Integrated Security=True;Pooling=False";

            if (args.Length > 0)
            {
                strURL = "tcp://" + args[0] + ":8160";
                if(args.Length > 1)
                    strNomTable = args[1];
                if (args.Length > 2)
                    strChaineDeConnexion = args[2];
            }
            result = CInitialiseurClientTimos.InitClientTimos(strURL, 0, "", null);
            if (result)
            {
                CSessionClient session = CSessionClient.CreateInstance();
                result = session.OpenSession(new CAuthentificationSessionProcess(), "Timos Auth Database", ETypeApplicationCliente.Process);
                if (!result)
                {
                    result.EmpileErreur("Erreur lors de l'authentification");
                }
                if(result)
                {
                    Console.WriteLine("Argument 1 = " + strURL);
                    Console.WriteLine("Argument 2 = " + strNomTable);

                    result = GetTimosUsers(session.IdSession, strNomTable);
                    if(result)
                    {
                        result = UpdateDatabase();
                    }
                    session.CloseSession();
                }
            }
            if(!result)
            {
                Console.WriteLine(result.MessageErreur);
            }
            Console.ReadKey();
        }

        //------------------------------------------------------------------------------------------------------------------------
        static CResultAErreur GetTimosUsers(int nIdSession, string strTableName)
        {
            CResultAErreur result = CResultAErreur.True;

            using (CContexteDonnee ctx = new CContexteDonnee(nIdSession, true, false))
            {
                CListeObjetDonneeGenerique<CDonneesActeurUtilisateur> listUsers = new CListeObjetDonneeGenerique<CDonneesActeurUtilisateur>(ctx);

                foreach (CDonneesActeurUtilisateur user in listUsers)
                {
                    string nom = user.Acteur.Nom;
                    string prenom = user.Acteur.Prenom;
                    string login = user.Login;
                    string pwd = user.Password;
                    string mobile = user.Acteur.Portable;

                    Console.WriteLine(nom + "|" + prenom + "|" + login + "|" + pwd + "|" + mobile);
                }
            }

            return result;
        }

        //------------------------------------------------------------------------------------------------------------------------
        static CResultAErreur UpdateDatabase()
        {
            CResultAErreur result = CResultAErreur.True;

            string strConnexionString = @"Data Source=DESKTOP-VMDEVYK\SQLEXPRESS;Initial Catalog=UTILISATEURS_PROD;Integrated Security=True;Pooling=False";
            //string strConnexionString = @"Data Source=DESKTOP-VMDEVYK\SQLEXPRESS;Initial Catalog=UTILISATEURS_PROD;Integrated Security=False;Pooling=False;User ID=UserName;Password=Password";

            using (SqlConnection connexion = new SqlConnection(strConnexionString))
            {
                try
                {
                    connexion.Open();
                    Console.WriteLine("Connexion SQL Server OK : " + strConnexionString);

                    /*string strRequete = "SELECT * FROM TIMOS_USERS";
                    using (SqlCommand command = new SqlCommand(strRequete, connexion))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("{0} - {1} - {2} - {3}", reader.GetValue(0), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3));
                            }

                            reader.Close();
                        }
                    }*/

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    DataSet dataSet = new DataSet("UTILISATEURS");
                     // Select command
                    string strRequeteSelect = "SELECT * FROM TIMOS_USERS";
                    adapter.SelectCommand = new SqlCommand(strRequeteSelect, connexion);
                    adapter.Fill(dataSet, "TIMOS_USERS");

                    DataRow newRow = dataSet.Tables["TIMOS_USERS"].NewRow();
                    newRow["USERID"] = 12;
                    newRow["FIRSTNAME"] = "charlie";
                    newRow["PASSWORD"] = "charlie12";
                    dataSet.Tables["TIMOS_USERS"].Rows.Add(newRow);
                    newRow = dataSet.Tables["TIMOS_USERS"].NewRow();
                    newRow["USERID"] = 13;
                    newRow["FIRSTNAME"] = "delta";
                    newRow["PASSWORD"] = "delta13";
                    dataSet.Tables["TIMOS_USERS"].Rows.Add(newRow);

                    adapter.Fill(dataSet, "TIMOS_USERS");


                    /*/ Insert command
                    string strRequeteInsert = "INSERT INTO TIMOS_USERS (USERID,FIRSTNAME,PASSWORD) VALUES (@id, @prenom, @mdp)";
                    adapter.InsertCommand = new SqlCommand(strRequeteInsert, connexion);
                    adapter.InsertCommand.Parameters.Add("@id", SqlDbType.Int, 32, "USERID");
                    adapter.InsertCommand.Parameters.Add("@prenom", SqlDbType.NVarChar, 50, "FIRSTNAME");
                    adapter.InsertCommand.Parameters.Add("@mdp", SqlDbType.NVarChar, 50, "PASSWORD");
                    //*/

                    /*/
                    newRow = dataSet.Tables["TIMOS_USERS"].NewRow();
                    newRow["USERID"] = 12;
                    newRow["FIRSTNAME"] = "charlie";
                    newRow["PASSWORD"] = "charlie12";
                    dataSet.Tables["TIMOS_USERS"].Rows.Add(newRow);

                    adapter.Update(dataSet, "TIMOS_USERS");
                    dataSet.Clear();
                    adapter.Fill(dataSet, "TIMOS_USERS");
                    //*/
                }
                catch (Exception ex)
                {
                    result.EmpileErreur(ex.Message);
                }
                finally
                {
                    connexion.Close();
                }
            }

            return result;
        }


    }
}
