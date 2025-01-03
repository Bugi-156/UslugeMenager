using System;
using System.Collections.Generic;

public interface IUslugeManager
{
    void DodajUslugu(Usluga usluga);
    void ObrisiUslugu(int id);
    void IspisUsluga();
}

public class Usluga
{
    public int ID { get; set; }
    public string Naziv { get; set; }
    public decimal Cijena { get; set; }

    public Usluga(int id, string naziv, decimal cijena)
    {
        ID = id;
        Naziv = naziv;
        Cijena = cijena;
    }

    public void Ispis()
    {
        Console.WriteLine($"ID: {ID}, Naziv: {Naziv}, Cijena: {Cijena} EUR");
    }
}

public class UslugeManager : IUslugeManager
{
    private List<Usluga> usluge;

    public UslugeManager()
    {
        usluge = new List<Usluga>();
    }

    public void DodajUslugu(Usluga usluga)
    {
        usluge.Add(usluga);
        Console.WriteLine($"Usluga '{usluga.Naziv}' dodana.");
    }

    public void ObrisiUslugu(int id)
    {
        var usluga = usluge.Find(u => u.ID == id);
        if (usluga != null)
        {
            usluge.Remove(usluga);
            Console.WriteLine($"Usluga '{usluga.Naziv}' je obrisana.");
        }
        else
        {
            Console.WriteLine("Usluga sa zadanim ID-om nije pronađena.");
        }
    }

    public void IspisUsluga()
    {
        if (usluge.Count == 0)
        {
            Console.WriteLine("Nema usluga za ispis.");
            return;
        }

        Console.WriteLine("Popis svih usluga:");
        foreach (var usluga in usluge)
        {
            usluga.Ispis();
        }
    }
}

public class Program
{
    public static void Main()
    {
        UslugeManager manager = new UslugeManager();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Meni ===");
            Console.WriteLine("1. Dodaj uslugu");
            Console.WriteLine("2. Obrisi uslugu");
            Console.WriteLine("3. Ispis svih usluga");
            Console.Write("Odaberite opciju: ");
            var opcija = Console.ReadLine();

            switch (opcija)
            {
                case "1":
                    Console.Write("Unesite ID usluge: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("Unesite naziv usluge: ");
                    string naziv = Console.ReadLine();
                    Console.Write("Unesite cijenu usluge: ");
                    decimal cijena = decimal.Parse(Console.ReadLine());

                    Usluga novaUsluga = new Usluga(id, naziv, cijena);
                    manager.DodajUslugu(novaUsluga);
                    break;

                case "2":
                    Console.Write("Unesite ID usluge koju želite obrisati: ");
                    int idZaBrisanje = int.Parse(Console.ReadLine());
                    manager.ObrisiUslugu(idZaBrisanje);
                    break;

                case "3":
                    manager.IspisUsluga();
                    break;

                default:
                    Console.WriteLine("Nevažeća opcija, pokušajte ponovo.");
                    break;
            }

            Console.WriteLine("\nPritisnite bilo koju tipku za povratak u meni...");
            Console.ReadKey();
        }
    }
}
