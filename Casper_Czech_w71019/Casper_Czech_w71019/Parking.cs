class Parking
{
    private int Wiersze;
    private int Kolumny;
    private Pojazd[,] Miejsca;
    private List<(string, Pojazd)> Historia;

    public Parking(int wiersze, int kolumny)
    {
        Wiersze = wiersze;
        Kolumny = kolumny;
        Miejsca = new Pojazd[wiersze, kolumny];
        Historia = new List<(string, Pojazd)>();
    }

    public bool SprawdzDostepnosc(List<(int, int)> zajmowanePola)
    {
        foreach (var (x, y) in zajmowanePola)
        {
            if (x < 0 || x >= Wiersze || y < 0 || y >= Kolumny || Miejsca[x, y] != null)
            {
                return false;
            }
        }
        return true;
    }

    public void WprowadzPojazd(Pojazd pojazd, int x, int y)
    {
        pojazd.UstalMiejsca(x, y);
        if (SprawdzDostepnosc(pojazd.ZajmowanePola))
        {
            foreach (var (px, py) in pojazd.ZajmowanePola)
            {
                Miejsca[px, py] = pojazd;
            }
            Historia.Add(("Przyjazd", pojazd));
            Console.WriteLine("Dodano: " + pojazd);
        }
        else
        {
            Console.WriteLine("Brak miejsca dla pojazdu!");
        }
    }

    public void UsunPojazd(string nrRejestracyjny)
    {
        for (int i = 0; i < Wiersze; i++)
        {
            for (int j = 0; j < Kolumny; j++)
            {
                if (Miejsca[i, j] != null && Miejsca[i, j].NrRejestracyjny == nrRejestracyjny)
                {
                    Historia.Add(("Odjazd", Miejsca[i, j]));
                    Miejsca[i, j] = null;
                }
            }
        }
        Console.WriteLine($"Pojazd {nrRejestracyjny} został usunięty.");
    }

    public void PokazParking()
    {
        for (int i = 0; i < Wiersze; i++)
        {
            for (int j = 0; j < Kolumny; j++)
            {
                Console.Write((Miejsca[i, j] != null ? Miejsca[i, j].Typ[0] : '.') + " ");
            }
            Console.WriteLine();
        }
    }

    public void ZnajdzPojazd(string nrRejestracyjny)
    {
        foreach (var (akcja, pojazd) in Historia)
        {
            if (pojazd.NrRejestracyjny == nrRejestracyjny)
            {
                Console.WriteLine($"{akcja}: {pojazd}");
            }
        }
    }
}
