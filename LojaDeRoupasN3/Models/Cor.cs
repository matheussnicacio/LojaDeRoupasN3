namespace LojaDeRoupas.Models;

public class Cor
{
    public int Id { get; set; }
    public string Nome { get; set; }

    public Cor(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }

    public override string ToString()
    {
        return $"{Id} - {Nome}";
    }
}
