using System;
using MySql.Data.MySqlClient;

namespace Ifrocean
{
    class DALConnection
    {
        private static string server;
        private static string database;
        private static string uid;
        private static string password;
        public static MySqlConnection connection;

        public static MySqlConnection OpenConnection()
        {
            if (connection == null) //  si la connexion est déjà ouverte, il ne la refera pas 
            {

                server = "localhost";
                database = "Ifrocean";
                uid = "Projet";
                password = "Epsi2019";
                string connectionString;
                connectionString = "SERVER=" + server + ";" + "DATABASE=" +
                database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
                connection = new MySqlConnection(connectionString);
                connection.Open();
            }
            return connection;
        }
    }
}
