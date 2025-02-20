using System;
using System.Collections.Generic;










class Program
{
    static void Main()
    {
        Parking parking = new Parking(6, 6);
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n1. Dodaj pojazd\n2. Usuń pojazd\n3. Pokaż parking\n4. Znajdź pojazd\n5. Wyjdź");
            Console.Write("Wybierz opcję: ");
            string wybor = Console.ReadLine();

            switch (wybor)
            {
                case "1":
                    Console.Write("Podaj numer rejestracyjny: ");
                    string rejestracja = Console.ReadLine();
                    Console.Write("Typ pojazdu (motocykl/samochód/autobus): ");
                    string typ = Console.ReadLine();
                    Console.Write("Podaj współrzędne (x y): ");
                    int x = int.Parse(Console.ReadLine());
                    int y = int.Parse(Console.ReadLine());

                    Pojazd pojazd = typ switch
                    {
                        "motocykl" => new Motocykl(rejestracja),
                        "samochód" => new Samochod(rejestracja),
                        "autobus" => new Autobus(rejestracja),
                        _ => null
                    };

                    if (pojazd != null) parking.WprowadzPojazd(pojazd, x, y);
                    break;

                case "2":
                    Console.Write("Podaj numer rejestracyjny: ");
                    parking.UsunPojazd(Console.ReadLine());
                    break;

                case "3": parking.PokazParking(); break;
                case "4":
                    Console.Write("Podaj numer rejestracyjny: ");
                    parking.ZnajdzPojazd(Console.ReadLine());
                    break;
                case "5": running = false; break;
            }
        }
    }
}
