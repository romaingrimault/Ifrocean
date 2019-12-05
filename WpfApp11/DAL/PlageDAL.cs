using Ifrocean.DAO;
using Ifrocean.Erreur;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ifrocean.DAL
{
    public class PlageDAL
    {
        private static MySqlConnection connection;
        public PlageDAL()
        {
            DALConnection.OpenConnection(); //  si la connexion est déjà ouverte, il ne la refera pas (voir code dans DALConnection)
            connection = DALConnection.connection;
        }
        public static ObservableCollection<PlageDAO> selectPlage()
        {
            ObservableCollection<PlageDAO> l = new ObservableCollection<PlageDAO>();
            string query = "SELECT * FROM Plage;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                PlageDAO c = new PlageDAO(reader.GetInt32(0),reader.GetString(1),reader.GetInt32(2));
                l.Add(c);
            }
            reader.Close();
            return l;
        }
        public static void insertPlage(PlageDAO c)
        {


                string query = "INSERT INTO Plage (nom,idCommune) VALUES (@nomPlage,@idCommune);";
                MySqlCommand cmd1 = new MySqlCommand(query, DALConnection.connection);
                cmd1.Parameters.AddWithValue("@nomPlage", c.nomPlageDAO);
                cmd1.Parameters.AddWithValue("@idCommune", c.idCommunePlageDAO);
                MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd1);
                cmd1.ExecuteNonQuery();

        }

        public static PlageDAO getPlage(int idPlage)
        {
            string query = "SELECT * FROM Plage WHERE idPlage=" + idPlage + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            PlageDAO Plage = new PlageDAO(reader.GetInt32(0), reader.GetString(1),reader.GetInt32(2));
            reader.Close();
            return Plage;
        }

        public static void updatePlage(PlageDAO c)
        {
            string query = "UPDATE Departement set nom=@nomDepartement where idPlage=@idPlage;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@nomDepartement", c.nomPlageDAO);
            cmd.Parameters.AddWithValue("@idPlage", c.idPlageDAO);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void supprimerPlage(int id)
        {
            string query = "DELETE FROM Plage WHERE idPlage =@idPlage;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@idPlage", id);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }

    }
}
