using KINO_Degtinnikov.Modell;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace KINO_Degtinnikov.Classes
{
    public class AfishaContext : Afisha
    {
        public AfishaContext(int id, string name, int id_films, DateTime dateTime, decimal price):base(id,name,id_films,dateTime,price)
        {
        }

        public static List<AfishaContext> Select()
        {
            List<AfishaContext> AllAfisha = new List<AfishaContext>();
            string SQL = "SELECT * FROM `Afisha`;";
            MySqlConnection connection = Common.Connection.OpenConnection();
            MySqlDataReader Data = Common.Connection.Query(SQL, connection);

            while (Data.Read())
            {
                AllAfisha.Add(new AfishaContext(
                   Data.GetInt32(0),       
                   Data.GetString(1),
                   Data.GetInt32(2),
                   Data.GetDateTime(3),
                   Data.GetDecimal(4)
                ));
            }

            Common.Connection.CloseConnection(connection);
            return AllAfisha;
        }

        public void Add()
        {
            string SQL = "INSERT INTO `Afisha` (`kinoteatr`, `seans_time`, `price`, `id_films`) " +
                         "VALUES ('" + this.Name + "', " +
                         "'" + this.time.ToString("yyyy-MM-dd HH:mm:ss") + "', " +
                         this.price.ToString() + ", " +
                         this.id_films + ")";

            MySqlConnection connection = Common.Connection.OpenConnection();
            MySqlCommand command = new MySqlCommand(SQL, connection);
            command.ExecuteNonQuery();
            Common.Connection.CloseConnection(connection);
        }

        public void Update()
        {
            string escapedName = this.Name.Replace("'", "''");
            string formattedPrice = this.price.ToString().Replace(",", ".");

            string SQL = "UPDATE `Afisha` SET " +
                         "`kinoteatr` = '" + escapedName + "', " +
                         "`seans_time` = '" + this.time.ToString("yyyy-MM-dd HH:mm:ss") + "', " +
                         "`price` = " + formattedPrice + ", " +
                         "`id_films` = " + this.id_films + " " +
                         "WHERE `id` = " + this.Id;

            MySqlConnection connection = Common.Connection.OpenConnection();
            MySqlCommand command = new MySqlCommand(SQL, connection);
            command.ExecuteNonQuery();
            Common.Connection.CloseConnection(connection);
        }

        public void Delete()
        {
            string SQL = "DELETE FROM `Afisha` WHERE `id` = " + this.Id;

            MySqlConnection connection = Common.Connection.OpenConnection();
            MySqlCommand command = new MySqlCommand(SQL, connection);
            command.ExecuteNonQuery();
            Common.Connection.CloseConnection(connection);
        }
    }
}