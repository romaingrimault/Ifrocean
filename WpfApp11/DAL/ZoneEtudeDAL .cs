using Ifrocean.DAO;
using Ifrocean.Erreur;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Ifrocean.DAL
{
    public class ZoneEtudeDAL
    {
        private static MySqlConnection connection;
        public ZoneEtudeDAL()
        {
            DALConnection.OpenConnection(); //  si la connexion est déjà ouverte, il ne la refera pas (voir code dans DALConnection)
            connection = DALConnection.connection;
        }
        public static ObservableCollection<ZoneEtudeDAO> selectZoneEtude()
        {
            ObservableCollection<ZoneEtudeDAO> l = new ObservableCollection<ZoneEtudeDAO>();
            string query = "SELECT * FROM ZoneEtude;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ZoneEtudeDAO c = new ZoneEtudeDAO(reader.GetDateTime(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetFloat(5), reader.GetInt32(6), reader.GetInt32(7), reader.GetInt32(8), reader.GetInt32(9));
                l.Add(c);
            }
            reader.Close();
            return l;
        }
        public static void insertZoneEtude(ZoneEtudeDAO c)
        {


                string query = "INSERT INTO ZoneEtude (CoordonneeA,CoordonneeB,CoordonneeC,CoordonneeD,SuperficieEtude,idZoneEtude,IdPersonne,idEtude,idPlage) VALUES (@CoordonneeA,@CoordonneeB,@CoordonneeC,@CoordonneeD,@SuperficieEtude,@idZoneEtude,@IdPersonne,@idEtude,@idPlage);";
                MySqlCommand cmd1 = new MySqlCommand(query, DALConnection.OpenConnection());
                cmd1.Parameters.AddWithValue("@CoordonneeA", c.CoordonnéeADAO);
                cmd1.Parameters.AddWithValue("@CoordonneeB", c.CoordonnéeBDAO);
                cmd1.Parameters.AddWithValue("@CoordonneeC", c.CoordonnéeCDAO);
                cmd1.Parameters.AddWithValue("@CoordonneeD", c.CoordonnéeDDAO);
                cmd1.Parameters.AddWithValue("@SuperficieEtude", c.superficieZoneEtudeDAO);
                cmd1.Parameters.AddWithValue("@idZoneEtude", c.idZoneEtudeDAO);
                cmd1.Parameters.AddWithValue("@IdPersonne", c.idPersonneDAO);
                cmd1.Parameters.AddWithValue("@idEtude", c.idEtudeDAO);
                cmd1.Parameters.AddWithValue("@idPlage", c.idPlageDAO);
                MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd1);
                cmd1.ExecuteNonQuery();
        }

        public static ZoneEtudeDAO getZoneEtude(int idZoneEtude)
        {
            string query = "SELECT * FROM ZoneEtude WHERE idZoneEtude=@idZoneEtude;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.Parameters.AddWithValue("@idZoneEtude", idZoneEtude);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            ZoneEtudeDAO ZoneEtude = new ZoneEtudeDAO(reader.GetDateTime(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetFloat(5), reader.GetInt32(6), reader.GetInt32(7), reader.GetInt32(8), reader.GetInt32(9));
            reader.Close();
            return ZoneEtude;
        }
        public static void supprimerZoneEtude(int id)
        {
            string query = "DELETE FROM ZoneEtude WHERE idZoneEtude =@idZoneEtude;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.Parameters.AddWithValue("@idZoneEtude", id);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdZone(int idEtude,int idPlage)
        {
            string query = "SELECT MAX(idZoneEtude) from zoneetude WHERE idEtude =@idEtude AND idPlage =@idPlage;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.Parameters.AddWithValue("@idEtude", idEtude);
            cmd.Parameters.AddWithValue("@idPlage", idPlage);
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int maxIdZone = 0;
            try
            {
                if (reader.GetInt32(0) != 0)
                    maxIdZone = reader.GetInt32(0);
            }
            catch (System.Data.SqlTypes.SqlNullValueException e) { }
            reader.Close();
            return maxIdZone;
        }
    }
}

