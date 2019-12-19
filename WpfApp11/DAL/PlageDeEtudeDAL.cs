using Ifrocean.DAO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Ifrocean.DAL
{
    public class PlageDeEtudeDAL
    {
        private static MySqlConnection connection;
        public PlageDeEtudeDAL()
        {
            DALConnection.OpenConnection(); //  si la connexion est déjà ouverte, il ne la refera pas (voir code dans DALConnection)
            connection = DALConnection.connection;
        }
        public static void insertPlageDeEtude(PlageDeEtudeDAO d)
        {
            
            string query = "INSERT INTO PlageDeEtude (idEtude,idPlage) VALUES (@idEtude,@idPlage);";
            MySqlCommand cmd1 = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd1.Parameters.AddWithValue("@idEtude", d.idEtudeDAO);
            cmd1.Parameters.AddWithValue("@idPlage", d.idPlageDAO);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd1);
            cmd1.ExecuteNonQuery();
        }
    }
}
