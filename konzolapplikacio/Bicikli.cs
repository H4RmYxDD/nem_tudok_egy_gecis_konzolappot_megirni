using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konzolapplikacio
{
    public class Bicikli
    {
    public List<Bicikli> BicikliList;
        public string nev;
    public DateTime kezdes;
    public DateTime vegzes;
    public string Type;
    public TimeSpan kulonbseg;
       public double osszeg;
    public Bicikli(DateTime kezdes1, DateTime vegzes1, string tipus) { 
        kezdes = kezdes1;
        vegzes = vegzes1;
        Type = tipus;
        TimeSpan mennyit = vegzes - kezdes;
    }
    }
}
