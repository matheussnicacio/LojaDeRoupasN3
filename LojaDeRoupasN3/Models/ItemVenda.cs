namespace LojaDeRoupas.Models;

public class ItemVenda
{
    public int Id { get; set; }
    public int VendaId { get; set; }
    public int RoupaId { get; set; }
    public int TamanhoId { get; set; }
    public int CorId { get; set; }
    public int Quantidade { get; set; }
    public decimal PrecoUnitario { get; set; }

    public ItemVenda(int id, int vendaId, int roupaId, int tamanhoId, int corId, int quantidade, decimal precoUnitario)
    {
        Id = id;
        VendaId = vendaId;
        RoupaId = roupaId;
        TamanhoId = tamanhoId;
        CorId = corId;
        Quantidade = quantidade;
        PrecoUnitario = precoUnitario;
    }
}
