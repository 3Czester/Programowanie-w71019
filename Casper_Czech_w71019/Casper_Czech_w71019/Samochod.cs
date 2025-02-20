class Samochod : Pojazd
{
    public Samochod(string nrRejestracyjny) : base(nrRejestracyjny, "samochód") { }

    public override void UstalMiejsca(int startX, int startY)
    {
        ZajmowanePola.Add((startX, startY));
        ZajmowanePola.Add((startX, startY + 1));
    }
}