namespace LojaDeRoupas.Models;

public class Roupa
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Tipo { get; set; }
    public string Modelo { get; set; }
    public decimal Preco { get; set; }
    public string Descricao { get; set; }

    public Roupa(int id, string nome, string tipo, string modelo, decimal preco, string descricao)
    {
        Id = id;
        Nome = nome;
        Tipo = tipo;
        Modelo = modelo;
        Preco = preco;
        Descricao = descricao;
    }

    public override string ToString()
    {
        return $"ID: {Id} | {Nome} - {Tipo} | Modelo: {Modelo} | Preço: R$ {Preco:F2}";
    }
}
