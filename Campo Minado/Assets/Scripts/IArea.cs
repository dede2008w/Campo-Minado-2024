public interface IArea
{
    bool Bomba { get; set; }

    event Area.AreaClickedDelegate OnAreaClicked;

    void Clicado();
    void DefinirIndex(int i, int j);
    void RevelarBomba();
}