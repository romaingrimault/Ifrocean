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
    public class CommuneDAL
    {
        private static MySqlConnection connection;
        public CommuneDAL()
        {
            DALConnection.OpenConnection(); //  si la connexion est déjà ouverte, il ne la refera pas (voir code dans DALConnection)
            connection = DALConnection.connection;
        }
        public static ObservableCollection<CommuneDAO> selectCommune()
        {
            ObservableCollection<CommuneDAO> l = new ObservableCollection<CommuneDAO>();
            string query = "SELECT * FROM commune;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                CommuneDAO c = new CommuneDAO(reader.GetInt32(0),reader.GetString(1), reader.GetString(2),reader.GetInt32(3));
                l.Add(c);
            }
            reader.Close();
            return l;
        }
        public static void insertCommune(CommuneDAO c)
        {


                string query = "INSERT INTO commune (nom,codePostal,idDepartement) VALUES (@nomCommune,@codePostal,@idDepartement);";
                MySqlCommand cmd1 = new MySqlCommand(query, DALConnection.connection);
                cmd1.Parameters.AddWithValue("@nomCommune", c.nomCommuneDAO);
                cmd1.Parameters.AddWithValue("@codePostal", c.codePostalDAO);
                cmd1.Parameters.AddWithValue("@idDepartement", c.idDepartementCommuneDAO);
                MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd1);
                cmd1.ExecuteNonQuery();

        }

        public static CommuneDAO getCommune(int idCommune)
        {
            string query = "SELECT * FROM commune WHERE idCommune=" + idCommune + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            CommuneDAO commune = new CommuneDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
            reader.Close();
            return commune;
        }

        public static void updateCommune(CommuneDAO c)
        {
            string query = "UPDATE Departement set nom=@nomDepartement NumeroDepartement=@numeroDepartement where idCommune=@idCommune;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@nomDepartement", c.nomCommuneDAO);
            cmd.Parameters.AddWithValue("@numeroDepartement", c.codePostalDAO);
            cmd.Parameters.AddWithValue("@idCommune", c.idCommuneDAO);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void supprimerCommune(int id)
        {
            string query = "DELETE FROM commune WHERE idCommune =@idCommune;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@idCommune", id);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }

    }
}
