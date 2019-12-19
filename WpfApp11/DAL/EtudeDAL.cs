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
    public class EtudeDAL
    {
        private static MySqlConnection connection;
        public EtudeDAL()
        {
            DALConnection.OpenConnection(); //  si la connexion est déjà ouverte, il ne la refera pas (voir code dans DALConnection)
            connection = DALConnection.connection;
        }
        public static ObservableCollection<EtudeDAO> selectEtude()
        {
            ObservableCollection<EtudeDAO> l = new ObservableCollection<EtudeDAO>();
            string query = "SELECT * FROM Etude;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                EtudeDAO d = new EtudeDAO(reader.GetInt32(0),reader.GetString(1));
                l.Add(d);
            }
            reader.Close();
            return l;
        }
        public static void insertEtude(EtudeDAO d)
        {
            
            string query = "INSERT INTO Etude (nom) VALUES (@nomEtude);";
            MySqlCommand cmd1 = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd1.Parameters.AddWithValue("@nomEtude", d.nomEtudeDAO);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd1);
            cmd1.ExecuteNonQuery();
        }

        public static EtudeDAO getEtude(int idEtude)
        {
            string query = "SELECT * FROM Etude WHERE idEtude=" + idEtude + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            EtudeDAO Etude = new EtudeDAO(reader.GetInt32(0), reader.GetString(1));
            reader.Close();
            return Etude;
        }

        public static void updateEtude(EtudeDAO d)
        {
            string query = "UPDATE Etude set nom=@nomEtude where IdEtude=@idEtude;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.Parameters.AddWithValue("@idEtude", d.idEtudeDAO);
            cmd.Parameters.AddWithValue("@nomEtude", d.nomEtudeDAO);

            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void supprimerEtude(int id)
        {
            string query = "DELETE FROM Etude WHERE IdEtude = @idEtude;";

            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.Parameters.AddWithValue("@adresseMailEtude",id);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }

    }
}
