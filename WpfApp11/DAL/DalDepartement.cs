using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ifrocean
{
    public class DalDepartement
    {
        private static MySqlConnection connection;
        public DalDepartement()
        {
            DALConnection.OpenConnection(); //  si la connexion est déjà ouverte, il ne la refera pas (voir code dans DALConnection)
            connection = DALConnection.connection;
        }
        public static ObservableCollection<DepartementDAO> selectDepartement()
        {

            ObservableCollection<DepartementDAO> l = new ObservableCollection<DepartementDAO>();
            string query = "SELECT * FROM Departement;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                DepartementDAO f = new DepartementDAO( reader.GetInt32(0), reader.GetString(1),reader.GetString(2));
                l.Add(f);
            }
            reader.Close();
            return l;
        }
        public static void insertDepartement(DepartementDAO d)
        {
           
            string query = "INSERT INTO departement (nom,NumeroDepartement) VALUES (@nomDepartement,@numeroDepartement);";
            MySqlCommand cmd1 = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd1.Parameters.AddWithValue("@nomDepartement", d.nomDepartementDAO);
            cmd1.Parameters.AddWithValue("@numeroDepartement", d.numeroDepartementDAO);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd1);
            cmd1.ExecuteNonQuery();
        }

        public static DepartementDAO getDepartement(int idDepartement)
        {
            string query = "SELECT * FROM Departement WHERE idDepartement=" + idDepartement + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            DepartementDAO departement = new DepartementDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
            reader.Close();
            return departement;
        }

        public static void updateDepartement(DepartementDAO d)
        {
            string query = "UPDATE Departement set nom=\"" + d.nomDepartementDAO + "\", NumeroDepartement=\"" + d.numeroDepartementDAO + "\" where idDepartement=" + d.idDepartementDAO + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void supprimerDepartement(int id)
        {
            string query = "DELETE FROM Departement WHERE idDepartement = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
       
    }
}
