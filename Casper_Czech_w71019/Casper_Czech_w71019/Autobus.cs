class Autobus : Pojazd
{
    public Autobus(string nrRejestracyjny) : base(nrRejestracyjny, "autobus") { }

    public override void UstalMiejsca(int startX, int startY)
    {
        ZajmowanePola.Add((startX, startY));
        ZajmowanePola.Add((startX, startY + 1));
        ZajmowanePola.Add((startX + 1, startY));
        ZajmowanePola.Add((startX + 1, startY + 1));
    }
}