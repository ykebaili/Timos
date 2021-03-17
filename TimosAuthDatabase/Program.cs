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
        private const string c_champId = "USERID";
        private const string c_champPrenom = "FIRSTNAME";
        private const string c_champNom = "NAME";
        private const string c_champLogin = "LOGIN";
        private const string c_champMotDePasse = "PASSWORD";
        private const string c_champMobile = "MOBILE";
        private const string c_champEmail = "EMAIL";


        /// <summary>
        /// Exemple ligne de commande
        /// TimosAuthDataBase.exe 127.0.0.1 TIMOS_USERS_PREPROD "Data Source=DESKTOP-VMDEVYK\SQLEXPRESS;Initial Catalog=TIMOS_USERS_DB;Integrated Security=True;Pooling=False"
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            CResultAErreur result = CResultAErreur.True;

            string strURL = "tcp://127.0.0.1:8160";
            string strNomTable = "TIMOS_USERS_PREPROD";
            string strChaineDeConnexion = @"Data Source=DESKTOP-VMDEVYK\SQLEXPRESS;Initial Catalog=TIMOS_USERS_DB;Integrated Security=True;Pooling=False";

            if (args.Length > 0)
            {
                strURL = "tcp://" + args[0] + ":8160";
                if(args.Length > 1)
                    strNomTable = args[1];
                if (args.Length > 2)
                    strChaineDeConnexion = args[2];
            }
            try
            {
                result = CInitialiseurClientTimos.InitClientTimos(strURL, 0, "", null);
            }
            catch { }

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
                    if (result && result.Data != null)
                    {
                        DataSet dataSource = result.Data as DataSet;
                        result = UpdateDatabase(strChaineDeConnexion, strNomTable, dataSource);
                    }
                    session.CloseSession();
                }
            }
            if(!result)
            {
                Console.WriteLine(result.MessageErreur);
            }
            //Console.ReadKey();
        }

        //------------------------------------------------------------------------------------------------------------------------
        static CResultAErreur GetTimosUsers(int nIdSession, string strTableName)
        {
            CResultAErreur result = CResultAErreur.True;

            DataSet ds = new DataSet("TIMOS_USERS");
            DataTable dt = new DataTable(strTableName);
            dt.Columns.Add(c_champId, typeof(int));
            dt.Columns.Add(c_champPrenom, typeof(string));
            dt.Columns.Add(c_champNom, typeof(string));
            dt.Columns.Add(c_champLogin, typeof(string));
            dt.Columns.Add(c_champMotDePasse, typeof(string));
            dt.Columns.Add(c_champMobile, typeof(string));
            dt.Columns.Add(c_champEmail, typeof(string));
            ds.Tables.Add(dt);

            using (CContexteDonnee ctx = new CContexteDonnee(nIdSession, true, false))
            {
                CListeObjetDonneeGenerique<CDonneesActeurUtilisateur> listUsers = new CListeObjetDonneeGenerique<CDonneesActeurUtilisateur>(ctx);

                foreach (CDonneesActeurUtilisateur user in listUsers)
                {
                    int id = user.Acteur.Id;
                    string prenom = user.Acteur.Prenom;
                    string nom = user.Acteur.Nom;
                    string login = user.Login;
                    string pwd = user.PasswordClear;
                    string mobile = user.Acteur.Portable;
                    string email = user.Acteur.EMail;

                    Console.WriteLine(id.ToString() + "|" + prenom + "|" + nom + "|" + login + "|" + pwd + "|" + mobile);

                    DataRow newRow = dt.NewRow();
                    newRow[c_champId] = id;
                    newRow[c_champPrenom] = prenom;
                    newRow[c_champNom] = nom;
                    newRow[c_champLogin] = login;
                    newRow[c_champMotDePasse] = pwd;
                    newRow[c_champMobile] = mobile;
                    newRow[c_champEmail] = email;

                    dt.Rows.Add(newRow);
                }
            }

            result.Data = ds;
            return result;
        }

        //------------------------------------------------------------------------------------------------------------------------
        static CResultAErreur UpdateDatabase(string strConnectionString, string strTableName, DataSet dataSource)
        {
            CResultAErreur result = CResultAErreur.True;

            using (SqlConnection connexion = new SqlConnection(strConnectionString))
            {
                try
                {
                    connexion.Open();
                    Console.WriteLine("Connexion SQL Server OK : " + strConnectionString);

                    // Construction du DataSet cible
                    DataSet dataSet = new DataSet("TIMOS_USERS_DB");
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    // Select command
                    string strRequeteSelect = "SELECT * FROM " + strTableName;
                    adapter.SelectCommand = new SqlCommand(strRequeteSelect, connexion);
                    // Insert command
                    string strRequeteInsert = 
                        "INSERT INTO " + strTableName + 
                        " (USERID,FIRSTNAME,NAME,LOGIN,PASSWORD,MOBILE,EMAIL) VALUES (@id, @prenom, @nom, @login, CONVERT(NVARCHAR(32),HASHBYTES('SHA2_256', cast(@mdp as varchar)),2), @mobile, @email)";
                    adapter.InsertCommand = new SqlCommand(strRequeteInsert, connexion);
                    adapter.InsertCommand.Parameters.Add("@id", SqlDbType.Int, 32, c_champId);
                    adapter.InsertCommand.Parameters.Add("@prenom", SqlDbType.NVarChar, 50, c_champPrenom);
                    adapter.InsertCommand.Parameters.Add("@nom", SqlDbType.NVarChar, 50, c_champNom);
                    adapter.InsertCommand.Parameters.Add("@login", SqlDbType.NVarChar, 50, c_champLogin);
                    adapter.InsertCommand.Parameters.Add("@mdp", SqlDbType.NVarChar, 50, c_champMotDePasse);
                    adapter.InsertCommand.Parameters.Add("@mobile", SqlDbType.NVarChar, 50, c_champMobile);
                    adapter.InsertCommand.Parameters.Add("@email", SqlDbType.NVarChar, 50, c_champEmail);
                    // Update command
                    string strRequeteUpdate =
                        "UPDATE " + strTableName +
                        " SET FIRSTNAME=@prenom, NAME=@nom, LOGIN=@login, PASSWORD=CONVERT(NVARCHAR(32),HASHBYTES('SHA2_256', cast(@mdp as varchar)),2), MOBILE=@mobile, EMAIL=@email WHERE USERID=@id";
                    adapter.UpdateCommand = new SqlCommand(strRequeteUpdate, connexion);
                    adapter.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 32, c_champId);
                    adapter.UpdateCommand.Parameters.Add("@prenom", SqlDbType.NVarChar, 50, c_champPrenom);
                    adapter.UpdateCommand.Parameters.Add("@nom", SqlDbType.NVarChar, 50, c_champNom);
                    adapter.UpdateCommand.Parameters.Add("@login", SqlDbType.NVarChar, 50, c_champLogin);
                    adapter.UpdateCommand.Parameters.Add("@mdp", SqlDbType.NVarChar, 50, c_champMotDePasse);
                    adapter.UpdateCommand.Parameters.Add("@mobile", SqlDbType.NVarChar, 50, c_champMobile);
                    adapter.UpdateCommand.Parameters.Add("@email", SqlDbType.NVarChar, 50, c_champEmail);

                    adapter.Fill(dataSet, strTableName);

                    if (dataSource.Tables.Contains(strTableName) && dataSet.Tables.Contains(strTableName))
                    {
                        DataTable tableExistante = dataSet.Tables[strTableName];
                        foreach (DataRow rowSource in dataSource.Tables[strTableName].Rows)
                        {
                            int nIdUser = (int)rowSource[c_champId];
                            var collection = tableExistante.AsEnumerable().Where(row => (int)row[c_champId] == nIdUser);
                            if (collection.Count() > 0)
                            {
                                DataRow rowExistante = collection.First();
                                rowExistante.ItemArray = rowSource.ItemArray.Clone() as object[];
                            }
                            else
                            {
                                tableExistante.ImportRow(rowSource);
                            }

                        }

                        int nRep = adapter.Update(dataSet, strTableName);
                        
                    }

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
