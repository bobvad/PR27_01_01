using KINO_Degtinnikov.Modell;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KINO_Degtinnikov.Classes
{
    public class KinoteatrContext : Kinoteatr
    {
        public KinoteatrContext(int Id, string Name, int CountZal, int Count):base(Id,Name,CountZal,Count)
        {
        }
        public KinoteatrContext( string Name, int CountZal, int Count) : base( Name, CountZal, Count)
        {
        }
        public static List<KinoteatrContext> Select()
        {
            List<KinoteatrContext> AllKinoteatrs = new List<KinoteatrContext>();
            string SQL = "SELECT * FROM `Films`;";
            MySqlConnection connection = Common.Connection.OpenConnection();
            MySqlDataReader Data = Common.Connection.Query(SQL,connection);
            while(Data.Read())
            {
                AllKinoteatrs.Add(new KinoteatrContext(
                    Data.GetInt32(0),
                    Data.GetString(1),
                    Data.GetInt32(2),
                    Data.GetInt32(3)
                ));
            }
            Common.Connection.CloseConnection(connection);
            return AllKinoteatrs;
        }
        public void Add()
        {
            string SQL = "INSERT INTO" +
                "`Films` (" +
                "`name`, " +
                "`count_zal`," +
                "`count_mesto`) " +
                "VALUES" +
                $"('{this.Name}', " +
                $"{ this.CountZal}," +
                $"{this.Count});";
            MySqlConnection connection = Common.Connection.OpenConnection();    
            Common.Connection.Query(SQL,connection);
            Common.Connection.CloseConnection(connection);
        }
        public void Update()
        {
            string SQL =
                "UPDATE " +
                   "`Films` " +
                "SET " +
                   $"`name` = '{this.Name}', " +
                   $"`count_zal` = {this.CountZal}, " +
                   $"`count_mesto` = {this.Count} " +
                "WHERE " +
                   $"idFilms = {this.Id}";

            MySqlConnection connection = Common.Connection.OpenConnection();
            Common.Connection.Query(SQL, connection);
            Common.Connection.CloseConnection(connection);
        }
        public void Delete()
        {
            string SQL = $"DELETE FROM `Films` WHERE idFilms = {this.Id}";
            MySqlConnection connection = Common.Connection.OpenConnection();
            Common.Connection.Query(SQL, connection);
            Common.Connection.CloseConnection(connection);
        }
    }
}
