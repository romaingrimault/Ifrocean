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
    public class PersonneDAL
    {
        private static MySqlConnection connection;
        public PersonneDAL()
        {
            DALConnection.OpenConnection(); //  si la connexion est déjà ouverte, il ne la refera pas (voir code dans DALConnection)
            connection = DALConnection.connection;
        }
        public static ObservableCollection<PersonneDAO> selectPersonne()
        {
            ObservableCollection<PersonneDAO> l = new ObservableCollection<PersonneDAO>();
            string query = "SELECT * FROM Personne;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                PersonneDAO d = new PersonneDAO(reader.GetInt32(0),reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(6), reader.GetByte(5));
                l.Add(d);
            }
            reader.Close();
            return l;
        }
        public static void insertPersonne(PersonneDAO d)
        {
            string query = "INSERT INTO Personne (nom,prenom,identifiant,motDePasse,admin,adresseMail) VALUES (@nomPersonne,@prenomPersonne,@identifiantPersonne,@motDePassePersonne,@adminPersonne,@adresseMailPersonne);";
            MySqlCommand cmd1 = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd1.Parameters.AddWithValue("@nomPersonne", d.nomPersonneDAO);
            cmd1.Parameters.AddWithValue("@prenomPersonne", d.prenomPersonneDAO);
            cmd1.Parameters.AddWithValue("@identifiantPersonne", d.identifiantPersonneDAO);
            cmd1.Parameters.AddWithValue("@motDePassePersonne", d.mdpPersonneDAO);
            cmd1.Parameters.AddWithValue("@adminPersonne", d.adminPersonneDAO);
            cmd1.Parameters.AddWithValue("@adresseMailPersonne", d.mailPersonneDAO);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd1);
            cmd1.ExecuteNonQuery();
        }

        public static PersonneDAO getPersonne(int idPersonne)
        {
            string query = "SELECT * FROM Personne WHERE idPersonne=@idPersonne;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.Parameters.AddWithValue("@idPersonne", idPersonne);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            PersonneDAO Personne = new PersonneDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(6), reader.GetByte(5));
            reader.Close();
            return Personne;
        }

        public static void updatePersonne(PersonneDAO d)
        {
            string query = "UPDATE Personne set nom=@nomPersonne,prenom=@prenomPersonne,identifient=,@identifiantPersonne,motDePasse=@motDePassePersonne,admin=@adminPersonne,adresseMail=@adresseMailPersonne where IdPersonne=@idPersonne;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.Parameters.AddWithValue("@idPersonne", d.idPersonneDAO);
            cmd.Parameters.AddWithValue("@nomPersonne", d.nomPersonneDAO);
            cmd.Parameters.AddWithValue("@prenomPersonne", d.prenomPersonneDAO);
            cmd.Parameters.AddWithValue("@identifiantPersonne", d.identifiantPersonneDAO);
            cmd.Parameters.AddWithValue("@motDePassePersonne", d.mdpPersonneDAO);
            cmd.Parameters.AddWithValue("@adminPersonne", d.adminPersonneDAO);
            cmd.Parameters.AddWithValue("@adresseMailPersonne", d.mailPersonneDAO);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void supprimerPersonne(int id)
        {
            string query = "DELETE FROM Personne WHERE IdPersonne = @idPersonne;";

            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.Parameters.AddWithValue("@adresseMailPersonne",id);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }

    }
}
