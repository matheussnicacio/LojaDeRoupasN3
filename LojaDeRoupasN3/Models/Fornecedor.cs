namespace LojaDeRoupas.Models;

public class Fornecedor
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    public string Endereco { get; set; }

    public Fornecedor(int id, string nome, string telefone, string email, string endereco)
    {
        Id = id;
        Nome = nome;
        Telefone = telefone;
        Email = email;
        Endereco = endereco;
    }

    public override string ToString()
    {
        return $"ID: {Id} | {Nome} | Tel: {Telefone} | Email: {Email}";
    }
}
