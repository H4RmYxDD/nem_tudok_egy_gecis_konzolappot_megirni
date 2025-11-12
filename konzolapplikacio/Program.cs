List<string> data = new List<string>();

var lines = File.ReadAllLines("vizibicikli.csv").Skip(1);
List<int> futas = new List<int>();
TimeSpan mennyitMent = TimeSpan.MinValue;


foreach (var l in lines)
{
    data = l.Split(',').ToList();
    var type = l[1].ToString();
    var nap = 12;
    if (int.Parse(data[2]) > int.Parse(data[4]))
    {
        nap = 13;
    }
    Console.WriteLine(data[2]);
    DateTime kezdes = new DateTime(2025, 11, 12, int.Parse(data[2]), int.Parse(data[3]), 0);
    DateTime vegzes = new DateTime(2025, 11, nap, int.Parse(data[4]), int.Parse(data[5]), 0);
    mennyitMent += (vegzes - kezdes);
    Bicikli bicikli = new Bicikli(kezdes, vegzes,type);
    Console.WriteLine(kezdes.ToString());
    Console.WriteLine(vegzes.ToString());
    Console.WriteLine(mennyitMent);
    //bicikli.BicikliList.Add(bicikli);
}

public class Bicikli
{
    public List<Bicikli> BicikliList;
    DateTime kezdes;
    DateTime vegzes;
    string Type;
    TimeSpan kulonbseg;
    public Bicikli(DateTime kezdes1, DateTime vegzes1, string tipus) { 
        kezdes = kezdes1;
        vegzes = vegzes1;
        Type = tipus;
        TimeSpan mennyit = vegzes - kezdes;
    }
}