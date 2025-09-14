using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KINO_Degtinnikov.Modell
{
    public class Kinoteatr
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountZal { get; set; }
        public int Count { get; set; }
        public Kinoteatr( string Name, int CountZal,int Count) 
        {
            this.Name = Name;
            this.Count = Count;
            this.CountZal = CountZal;
            this.Count = Count;
        }
        public Kinoteatr(int Id, string Name, int CountZal, int Count)
        {
            this.Id = Id;
            this.Name = Name;
            this.Count = Count;
            this.CountZal = CountZal;
            this.Count = Count;
        }
    }
}
