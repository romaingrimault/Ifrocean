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
    public class AnimauxDAL
    {
        private static MySqlConnection connection;
        public AnimauxDAL()
        {
            DALConnection.OpenConnection(); //  si la connexion est déjà ouverte, il ne la refera pas (voir code dans DALConnection)
            connection = DALConnection.connection;
        }
        public static ObservableCollection<AnimauxDAO> selectAnimaux()
        {
            ObservableCollection<AnimauxDAO> l = new ObservableCollection<AnimauxDAO>();
            string query = "SELECT * FROM Animaux;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                AnimauxDAO d = new AnimauxDAO(reader.GetString(0));
                l.Add(d);
            }
            reader.Close();
            return l;
        }
        public static void insertAnimaux(AnimauxDAO d)
        {
            string query = "INSERT INTO Animaux (espece) VALUES (@nomAnimaux);";
            MySqlCommand cmd1 = new MySqlCommand(query, DALConnection.connection);
            cmd1.Parameters.AddWithValue("@nomAnimaux", d.nomAnimauxDAO);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd1);
            cmd1.ExecuteNonQuery();
        }

        public static AnimauxDAO getAnimaux(int idAnimaux)
        {
            string query = "SELECT * FROM Animaux WHERE idAnimaux=" + idAnimaux + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            AnimauxDAO Animaux = new AnimauxDAO(reader.GetString(0));
            reader.Close();
            return Animaux;
        }

        public static void updateAnimaux(AnimauxDAO d)
        {
            string query = "UPDATE Animaux set espece=@nomAnimaux where IdAnimaux=@idAnimaux;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@idAnimaux", d.idAnimauxDAO);
            cmd.Parameters.AddWithValue("@nomAnimaux", d.nomAnimauxDAO);

            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void supprimerAnimaux(int id)
        {
            string query = "DELETE FROM Animaux WHERE IdAnimaux = @idAnimaux;";

            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@adresseMailAnimaux",id);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }

    }
}
