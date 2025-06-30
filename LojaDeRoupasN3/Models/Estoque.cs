namespace LojaDeRoupas.Models;

public class Estoque
{
    public int Id { get; set; }
    public int RoupaId { get; set; }
    public int TamanhoId { get; set; }
    public int CorId { get; set; }
    public int Quantidade { get; set; }

    public Estoque(int id, int roupaId, int tamanhoId, int corId, int quantidade)
    {
        Id = id;
        RoupaId = roupaId;
        TamanhoId = tamanhoId;
        CorId = corId;
        Quantidade = quantidade;
    }
}
