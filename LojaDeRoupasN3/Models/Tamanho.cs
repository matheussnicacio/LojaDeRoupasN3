namespace LojaDeRoupas.Models;

public class Tamanho
{
    public int Id { get; set; }
    public string Descricao { get; set; }

    public Tamanho(int id, string descricao)
    {
        Id = id;
        Descricao = descricao;
    }

    public override string ToString()
    {
        return $"{Id} - {Descricao}";
    }
}
