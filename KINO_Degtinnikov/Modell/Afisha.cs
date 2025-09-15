using System;

namespace KINO_Degtinnikov.Modell
{
    public class Afisha
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public int id_films { get; set; }
        public DateTime time { get; set; }
        public decimal price { get; set; }
        public Afisha(int Id,string Name,int id_films,DateTime time, decimal price)
        {
            this.Id = Id;
            this.Name = Name;
            this.id_films = id_films;
            this.time = time;
            this.price = price;
        }
    }
}
