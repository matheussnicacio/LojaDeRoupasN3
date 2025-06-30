namespace LojaDeRoupas.Models;

public class Venda
{
    public int Id { get; set; }
    public DateTime DataVenda { get; set; }
    public string Cliente { get; set; }
    public string Vendedor { get; set; }
    public decimal ValorTotal { get; set; }
    public List<ItemVenda> Itens { get; set; }

    public Venda(int id, DateTime dataVenda, string cliente, string vendedor)
    {
        Id = id;
        DataVenda = dataVenda;
        Cliente = cliente;
        Vendedor = vendedor;
        ValorTotal = 0;
        Itens = new List<ItemVenda>();
    }

    public void CalcularValorTotal()
    {
        ValorTotal = Itens.Sum(item => item.Quantidade * item.PrecoUnitario);
    }

    public override string ToString()
    {
        return $"Venda ID: {Id} | Data: {DataVenda:dd/MM/yyyy} | Cliente: {Cliente} | Total: R$ {ValorTotal:F2}";
    }
}
