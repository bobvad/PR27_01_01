using KINO_Degtinnikov.Modell;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
namespace KINO_Degtinnikov.Classes
{
    public class AfishaContext : Afisha
    {
        public AfishaContext(int Id, int IdKinoteatr, string Name, DateTime Time, int Price) : base(Id, IdKinoteatr, Name, Time, Price)
        {
        }
        public AfishaContext( int IdKinoteatr, string Name, DateTime Time, int Price) : base( IdKinoteatr, Name, Time, Price)
        {
        }
        public static List<AfishaContext> Select()
        {
            List<AfishaContext> AllKinoteatrs = new List<AfishaContext>();
            string SQL = "SELECT * FROM `afisha`;";
            MySqlConnection connection = Common.Connection.OpenConnection();
            MySqlDataReader Data = Common.Connection.Query(SQL, connection);
            while (Data.Read())
            {
                AllKinoteatrs.Add(new AfishaContext(
                    Data.GetInt32(0),
                    Data.GetInt32(1),
                    Data.GetString(2),
                    Data.GetDateTime(3),
                    Data.GetInt32(4)
                ));
            }
            Common.Connection.CloseConnection(connection);
            return AllKinoteatrs;
        }
        public void Add()
        {
            string SQL = "INSERT INTO" +
                "`afisha` (" +
                "`name`, " +
                "`time`," +
                "`price` )" +
                "VALUES" +
                $"('{this.Name}', " +
                $"{this.Time}," +
                $"{this.Price});";
            MySqlConnection connection = Common.Connection.OpenConnection();
            Common.Connection.Query(SQL, connection);
            Common.Connection.CloseConnection(connection);
        }
        public void Update()
        {
            string SQL =
               "UPDATE" +
                  "`afisha`" +
               "SET" +
                  $"`name` = '{this.Name}'," +
                  $"`time` = `{this.Time}`," +
                  $"`price` = `{this.Price}`" +
               "WHERE" +
                  $"idafisha = {this.Id}";
            MySqlConnection connection = Common.Connection.OpenConnection();
            Common.Connection.Query(SQL, connection);
            Common.Connection.CloseConnection(connection);
        }
        public void Delete()
        {
            string SQL = $"DELETE FROM `afisha` WHERE idafisha= {this.Id}";
            MySqlConnection connection = Common.Connection.OpenConnection();
            Common.Connection.Query(SQL, connection);
            Common.Connection.CloseConnection(connection);
        }
    }
}
