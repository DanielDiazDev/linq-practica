var autos = new List<Auto>()
{
    new Auto(){ Name = "Fer", Brand = "Ferari", Km = 23},
    new Auto(){ Name = "Che", Brand = "Chevrolet", Km = 5},
    new Auto(){ Name = "Mus", Brand = "Chevrolet", Km = 14},
    new Auto(){ Name = "For", Brand = "Ford", Km = 16}
};
var brand = new List<Brand>()
{
    new Brand(){ Name = "Nisan", Country = "Japon"},
    new Brand(){ Name = "Corsa", Country = "Argentina"}
};

//SELECT
var auto1 = from a in autos
            select new { a.Name, a.Brand };

//WHERE
var auto2 = from a in autos
            where a.Brand == "Chevrolet" || a.Km > 20
            select new { a.Name, a.Brand };
//WHERE METODO
var auto3 = autos.Where(a => a.Name == "Mus" || a.Km > 20)
    .Select(a => new
    {
        a.Name,
        a.Brand
    });
//ORDER BY
var auto4 = from a in autos
            where a.Brand == "Chevrolet" || a.Km > 2
            orderby a.Name
            select new { a.Name, a.Brand };
//GROUP BY
var auto5 = from a in autos
            group a by a.Brand into groupAutos
            select new
            {
                Brand = groupAutos.Key,
                Count = groupAutos.Count()
            };
//JOIN 
var auto6 = from a in autos
            join bra in brand on a.Brand equals bra.Name
            select new
            {
                Name = a.Name,
                Brand = a.Brand,
                Country = bra.Country
            };

foreach (var aut in auto6)
{
    Console.WriteLine($"{aut.Name} - {aut.Brand} - {aut.Country}");
}
public class Auto
{
    public string? Name { get; set; }
    public string? Brand { get; set; }
    public decimal Km { get; set; }

}
public class Brand
{
    public string? Name { get; set; }
    public string Country { get; set; }

}