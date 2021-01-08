using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Jobs_Management
{
    class Database
    {
        private string server;

        private string port;

        private string username;

        private string password;

        private string database;

        private MySqlConnection connection;

        private static Database instance = null;
        private void connect()
        {
            string connstring = string.Format("Server={0};port={1};database={2};UID={3};password={4}", server, port, database, username, password);
            connection = new MySqlConnection(connstring);
            connection.Open();
        }

        private void close()
        {
            connection.Close();
        }
        public Database()
        {
            server   = ConfigurationManager.AppSettings.Get("server");
            port     = ConfigurationManager.AppSettings.Get("port");
            username = ConfigurationManager.AppSettings.Get("username");
            password = ConfigurationManager.AppSettings.Get("password");
            database = ConfigurationManager.AppSettings.Get("database");

            connect();
        }

        public static Database getInstance()
        {
            if (instance == null)
                instance = new Database();
            return instance;
        }
        public MySqlDataReader select(string sql)
        {
            MySqlCommand cmd = new MySqlCommand(sql,connection);
            MySqlDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }

        public void execute(string sql)
        {
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.ExecuteNonQuery();
        }

    }
}
