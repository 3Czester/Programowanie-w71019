class Motocykl : Pojazd
{
    public Motocykl(string nrRejestracyjny) : base(nrRejestracyjny, "motocykl") { }

    public override void UstalMiejsca(int startX, int startY)
    {
        ZajmowanePola.Add((startX, startY));
    }
}