abstract class Pojazd
{
    public string NrRejestracyjny { get; }
    public string Typ { get; }
    public List<(int, int)> ZajmowanePola { get; protected set; }
    public DateTime CzasPrzyjazdu { get; }

    protected Pojazd(string nrRejestracyjny, string typ)
    {
        NrRejestracyjny = nrRejestracyjny;
        Typ = typ;
        CzasPrzyjazdu = DateTime.Now;
        ZajmowanePola = new List<(int, int)>();
    }

    public abstract void UstalMiejsca(int startX, int startY);

    public override string ToString()
    {
        string pola = "";
        foreach (var (x, y) in ZajmowanePola)
        {
            pola += $"({x}, {y}) ";
        }
        return $"{Typ.ToUpper()} {NrRejestracyjny} zajmuje: {pola}, Przyjazd: {CzasPrzyjazdu}";
    }
}