using konzolapplikacio;

List<string> data = new List<string>();

var lines = File.ReadAllLines("vizibicikli.csv").Skip(1);
List<int> futas = new List<int>();
TimeSpan mennyitMent = TimeSpan.Zero;
    var biciklik = new List<Bicikli>();
double osszesKereset = 0;


foreach (var l in lines)
{
    data = l.Split(", ").ToList();
    var type = data[1].ToString();
    var nap = 12;
    if (int.Parse(data[2]) >= int.Parse(data[4]))
    {
        nap = 13;
    }
    DateTime kezdes = new DateTime(2025, 11, 12, int.Parse(data[2]), int.Parse(data[3]), 0);
    DateTime vegzes = new DateTime(2025, 11, nap, int.Parse(data[4]), int.Parse(data[5]), 0);
    var bicikli = new Bicikli(kezdes, vegzes, type);

    var kulonbseg = (vegzes - kezdes);
    mennyitMent += kulonbseg;
    bicikli.nev = data[0];
    bicikli.kezdes = kezdes;
    bicikli.vegzes = vegzes;
    bicikli.Type = type;
    var fizetendo = Math.Ceiling(kulonbseg.TotalMinutes / 30) * 1000;
    bicikli.osszeg = fizetendo;
    biciklik.Add(bicikli);
}
 
var groupedBiciklik = biciklik.GroupBy(x=> x.Type).Select(g=>new {id=g.Key, fizetendo = g.Sum(b=>b.osszeg)});
var legtobb = groupedBiciklik.MaxBy(x=>x.fizetendo);
Console.WriteLine("a legtobbet keresett bicikli:" + legtobb);
Console.WriteLine("melyik bicikli adatait szeretne lekerni?");
var keresendo = Console.ReadLine().ToUpper();
var talalat = groupedBiciklik.FirstOrDefault(a=>a.id.Equals(keresendo));
Console.WriteLine(talalat);