using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KINO_Degtinnikov.Modell
{
    public class Afisha
    {
        public int Id { get; set; }
        public int IdKinoteatr { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public int Price { get; set; }
        public Afisha(int Id, int IdKinoteatr, string Name, DateTime Time, int Price)
        {
            Id = Id;
            IdKinoteatr = IdKinoteatr;
            Name = Name;
            Time = Time;
            Price = Price;
        }
    }
}
