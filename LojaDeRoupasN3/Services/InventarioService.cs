using LojaDeRoupas.Models;

namespace LojaDeRoupas.Services;

public class InventarioService
    {
        private List<Roupa> roupas;
        private List<Tamanho> tamanhos;
        private List<Cor> cores;
        private List<Estoque> estoque;
        private List<Fornecedor> fornecedores;
        private List<Venda> vendas;
        private List<ItemVenda> itensVenda;
        private int proximoIdRoupa;
        private int proximoIdEstoque;
        private int proximoIdFornecedor;
        private int proximoIdVenda;
        private int proximoIdItemVenda;

        public InventarioService()
        {
            InicializarDados();
        }

        private void InicializarDados()
        {
            // Inicializar listas
            roupas = new List<Roupa>();
            tamanhos = new List<Tamanho>();
            cores = new List<Cor>();
            estoque = new List<Estoque>();
            fornecedores = new List<Fornecedor>();
            vendas = new List<Venda>();
            itensVenda = new List<ItemVenda>();

            // IDs iniciais
            proximoIdRoupa = 1;
            proximoIdEstoque = 1;
            proximoIdFornecedor = 1;
            proximoIdVenda = 1;
            proximoIdItemVenda = 1;

            // Dados iniciais
            CarregarDadosIniciais();
        }

        private void CarregarDadosIniciais()
        {
            // Tamanhos padrão
            tamanhos.Add(new Tamanho(1, "PP"));
            tamanhos.Add(new Tamanho(2, "P"));
            tamanhos.Add(new Tamanho(3, "M"));
            tamanhos.Add(new Tamanho(4, "G"));
            tamanhos.Add(new Tamanho(5, "GG"));

            // Cores padrão
            cores.Add(new Cor(1, "Preto"));
            cores.Add(new Cor(2, "Branco"));
            cores.Add(new Cor(3, "Azul"));
            cores.Add(new Cor(4, "Vermelho"));
            cores.Add(new Cor(5, "Verde"));

            // Algumas roupas iniciais
            roupas.Add(new Roupa(1, "Camiseta Básica", "Camiseta", "Casual", 29.90m, "Camiseta básica de algodão"));
            roupas.Add(new Roupa(2, "Calça Jeans", "Calça", "Jeans", 89.90m, "Calça jeans tradicional"));
            proximoIdRoupa = 3;

            // Fornecedores iniciais
            fornecedores.Add(new Fornecedor(1, "Confecções ABC", "(11) 1234-5678", "contato@abc.com", "Rua das Flores, 123"));
            fornecedores.Add(new Fornecedor(2, "Moda XYZ", "(11) 9876-5432", "vendas@xyz.com", "Av. Principal, 456"));
            proximoIdFornecedor = 3;

            // Estoque inicial
            estoque.Add(new Estoque(1, 1, 3, 1, 10)); // Camiseta M Preta - 10 unidades
            estoque.Add(new Estoque(2, 1, 3, 2, 15)); // Camiseta M Branca - 15 unidades
            estoque.Add(new Estoque(3, 2, 4, 3, 5));  // Calça Jeans G Azul - 5 unidades
            proximoIdEstoque = 4;
        }

        // ================================
        // MÉTODOS DE GERENCIAMENTO DE ROUPAS
        // ================================

        public void CadastrarRoupa()
        {
            Console.WriteLine("\n=== CADASTRAR NOVA ROUPA ===");
            
            Console.Write("Nome da roupa: ");
            string nome = Console.ReadLine();
            
            Console.Write("Tipo (Camiseta, Calça, Vestido, etc.): ");
            string tipo = Console.ReadLine();
            
            Console.Write("Modelo: ");
            string modelo = Console.ReadLine();
            
            Console.Write("Preço: R$ ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal preco))
            {
                Console.WriteLine("Preço inválido!");
                return;
            }
            
            Console.Write("Descrição: ");
            string descricao = Console.ReadLine();

            var novaRoupa = new Roupa(proximoIdRoupa++, nome, tipo, modelo, preco, descricao);
            roupas.Add(novaRoupa);
            
            Console.WriteLine($"Roupa cadastrada com sucesso! ID: {novaRoupa.Id}");
        }

        public void ListarRoupas()
        {
            Console.WriteLine("\n=== LISTA DE ROUPAS ===");
            if (roupas.Count == 0)
            {
                Console.WriteLine("Nenhuma roupa cadastrada.");
                return;
            }

            foreach (var roupa in roupas)
            {
                Console.WriteLine(roupa);
            }
        }

        // ================================
        // MÉTODOS DE CONTROLE DE ESTOQUE
        // ================================

        public void AdicionarEstoque()
        {
            Console.WriteLine("\n=== ADICIONAR AO ESTOQUE ===");
            
            ListarRoupas();
            Console.Write("ID da roupa: ");
            if (!int.TryParse(Console.ReadLine(), out int roupaId) || !roupas.Any(r => r.Id == roupaId))
            {
                Console.WriteLine("Roupa não encontrada!");
                return;
            }

            ListarTamanhos();
            Console.Write("ID do tamanho: ");
            if (!int.TryParse(Console.ReadLine(), out int tamanhoId) || !tamanhos.Any(t => t.Id == tamanhoId))
            {
                Console.WriteLine("Tamanho não encontrado!");
                return;
            }

            ListarCores();
            Console.Write("ID da cor: ");
            if (!int.TryParse(Console.ReadLine(), out int corId) || !cores.Any(c => c.Id == corId))
            {
                Console.WriteLine("Cor não encontrada!");
                return;
            }

            Console.Write("Quantidade: ");
            if (!int.TryParse(Console.ReadLine(), out int quantidade) || quantidade <= 0)
            {
                Console.WriteLine("Quantidade inválida!");
                return;
            }

            // Verificar se já existe estoque para essa combinação
            var estoqueExistente = estoque.FirstOrDefault(e => e.RoupaId == roupaId && e.TamanhoId == tamanhoId && e.CorId == corId);
            
            if (estoqueExistente != null)
            {
                estoqueExistente.Quantidade += quantidade;
                Console.WriteLine($"Estoque atualizado! Nova quantidade: {estoqueExistente.Quantidade}");
            }
            else
            {
                var novoEstoque = new Estoque(proximoIdEstoque++, roupaId, tamanhoId, corId, quantidade);
                estoque.Add(novoEstoque);
                Console.WriteLine("Item adicionado ao estoque!");
            }
        }

        public void ConsultarEstoque()
        {
            Console.WriteLine("\n=== CONSULTAR ESTOQUE ===");
            Console.WriteLine("1 - Ver todo o estoque");
            Console.WriteLine("2 - Consultar produto específico");
            Console.Write("Escolha uma opção: ");

            if (!int.TryParse(Console.ReadLine(), out int opcao))
                return;

            switch (opcao)
            {
                case 1:
                    ExibirEstoqueCompleto();
                    break;
                case 2:
                    ConsultarProdutoEspecifico();
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }

        private void ExibirEstoqueCompleto()
        {
            Console.WriteLine("\n=== ESTOQUE COMPLETO ===");
            if (estoque.Count == 0)
            {
                Console.WriteLine("Estoque vazio.");
                return;
            }

            foreach (var item in estoque)
            {
                var roupa = roupas.FirstOrDefault(r => r.Id == item.RoupaId);
                var tamanho = tamanhos.FirstOrDefault(t => t.Id == item.TamanhoId);
                var cor = cores.FirstOrDefault(c => c.Id == item.CorId);

                Console.WriteLine($"{roupa?.Nome} | {tamanho?.Descricao} | {cor?.Nome} | Qtd: {item.Quantidade}");
            }
        }

        private void ConsultarProdutoEspecifico()
        {
            ListarRoupas();
            Console.Write("ID da roupa: ");
            if (!int.TryParse(Console.ReadLine(), out int roupaId))
                return;

            var itensRoupa = estoque.Where(e => e.RoupaId == roupaId);
            if (!itensRoupa.Any())
            {
                Console.WriteLine("Produto não encontrado no estoque.");
                return;
            }

            var roupa = roupas.FirstOrDefault(r => r.Id == roupaId);
            Console.WriteLine($"\n=== ESTOQUE - {roupa?.Nome} ===");

            foreach (var item in itensRoupa)
            {
                var tamanho = tamanhos.FirstOrDefault(t => t.Id == item.TamanhoId);
                var cor = cores.FirstOrDefault(c => c.Id == item.CorId);
                Console.WriteLine($"{tamanho?.Descricao} | {cor?.Nome} | Qtd: {item.Quantidade}");
            }
        }

        // ================================
        // MÉTODOS DE VENDAS
        // ================================

        public void RegistrarVenda()
        {
            Console.WriteLine("\n=== REGISTRAR VENDA ===");
            
            Console.Write("Nome do cliente: ");
            string cliente = Console.ReadLine();
            
            Console.Write("Nome do vendedor: ");
            string vendedor = Console.ReadLine();

            var novaVenda = new Venda(proximoIdVenda++, DateTime.Now, cliente, vendedor);

            // Adicionar itens à venda
            bool continuarAdicionando = true;
            while (continuarAdicionando)
            {
                Console.WriteLine("\n--- Adicionar item à venda ---");
                
                ExibirEstoqueCompleto();
                Console.Write("ID da roupa: ");
                if (!int.TryParse(Console.ReadLine(), out int roupaId) || !roupas.Any(r => r.Id == roupaId))
                {
                    Console.WriteLine("Roupa não encontrada!");
                    continue;
                }

                // Mostrar opções disponíveis para a roupa
                var opcoesDisponiveis = estoque.Where(e => e.RoupaId == roupaId && e.Quantidade > 0);
                if (!opcoesDisponiveis.Any())
                {
                    Console.WriteLine("Produto indisponível no estoque!");
                    continue;
                }

                Console.WriteLine("Opções disponíveis:");
                foreach (var opcao in opcoesDisponiveis)
                {
                    var tamanho = tamanhos.FirstOrDefault(t => t.Id == opcao.TamanhoId);
                    var cor = cores.FirstOrDefault(c => c.Id == opcao.CorId);
                    Console.WriteLine($"Tamanho: {tamanho?.Descricao} | Cor: {cor?.Nome} | Qtd disponível: {opcao.Quantidade}");
                }

                ListarTamanhos();
                Console.Write("ID do tamanho: ");
                if (!int.TryParse(Console.ReadLine(), out int tamanhoId))
                    continue;

                ListarCores();
                Console.Write("ID da cor: ");
                if (!int.TryParse(Console.ReadLine(), out int corId))
                    continue;

                // Verificar disponibilidade
                var itemEstoque = estoque.FirstOrDefault(e => e.RoupaId == roupaId && e.TamanhoId == tamanhoId && e.CorId == corId);
                if (itemEstoque == null || itemEstoque.Quantidade == 0)
                {
                    Console.WriteLine("Item indisponível no estoque!");
                    continue;
                }

                Console.Write($"Quantidade (máx: {itemEstoque.Quantidade}): ");
                if (!int.TryParse(Console.ReadLine(), out int quantidade) || quantidade <= 0 || quantidade > itemEstoque.Quantidade)
                {
                    Console.WriteLine("Quantidade inválida!");
                    continue;
                }

                var roupa = roupas.FirstOrDefault(r => r.Id == roupaId);
                var itemVenda = new ItemVenda(proximoIdItemVenda++, novaVenda.Id, roupaId, tamanhoId, corId, quantidade, roupa.Preco);
                
                novaVenda.Itens.Add(itemVenda);
                itensVenda.Add(itemVenda);

                // Atualizar estoque
                itemEstoque.Quantidade -= quantidade;

                Console.WriteLine($"Item adicionado: {quantidade}x {roupa.Nome} - R$ {roupa.Preco * quantidade:F2}");

                Console.Write("Adicionar mais itens? (s/n): ");
                continuarAdicionando = Console.ReadLine()?.ToLower() == "s";
            }

            if (novaVenda.Itens.Count > 0)
            {
                novaVenda.CalcularValorTotal();
                vendas.Add(novaVenda);
                Console.WriteLine($"\nVenda registrada com sucesso!");
                Console.WriteLine($"Total da venda: R$ {novaVenda.ValorTotal:F2}");
            }
            else
            {
                Console.WriteLine("Venda cancelada - nenhum item adicionado.");
            }
        }

        public void ListarVendas()
        {
            Console.WriteLine("\n=== HISTÓRICO DE VENDAS ===");
            if (vendas.Count == 0)
            {
                Console.WriteLine("Nenhuma venda registrada.");
                return;
            }

            foreach (var venda in vendas.OrderByDescending(v => v.DataVenda))
            {
                Console.WriteLine(venda);
                Console.WriteLine($"  Vendedor: {venda.Vendedor} | Itens: {venda.Itens.Count}");
                Console.WriteLine();
            }
        }

        // ================================
        // MÉTODOS DE FORNECEDORES
        // ================================

        public void CadastrarFornecedor()
        {
            Console.WriteLine("\n=== CADASTRAR FORNECEDOR ===");
            
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            
            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();
            
            Console.Write("Email: ");
            string email = Console.ReadLine();
            
            Console.Write("Endereço: ");
            string endereco = Console.ReadLine();

            var novoFornecedor = new Fornecedor(proximoIdFornecedor++, nome, telefone, email, endereco);
            fornecedores.Add(novoFornecedor);
            
            Console.WriteLine("Fornecedor cadastrado com sucesso!");
        }

        public void ListarFornecedores()
        {
            Console.WriteLine("\n=== LISTA DE FORNECEDORES ===");
            if (fornecedores.Count == 0)
            {
                Console.WriteLine("Nenhum fornecedor cadastrado.");
                return;
            }

            foreach (var fornecedor in fornecedores)
            {
                Console.WriteLine(fornecedor);
                Console.WriteLine($"  Endereço: {fornecedor.Endereco}");
                Console.WriteLine();
            }
        }

        // ================================
        // MÉTODOS AUXILIARES
        // ================================

        private void ListarTamanhos()
        {
            Console.WriteLine("\nTamanhos disponíveis:");
            foreach (var tamanho in tamanhos)
            {
                Console.WriteLine($"  {tamanho}");
            }
        }

        private void ListarCores()
        {
            Console.WriteLine("\nCores disponíveis:");
            foreach (var cor in cores)
            {
                Console.WriteLine($"  {cor}");
            }
        }

        public void GerarRelatorioEstoque()
        {
            Console.WriteLine("\n=== RELATÓRIO DE ESTOQUE ===");
            
            Console.WriteLine("\n--- Produtos em Estoque ---");
            var produtosComEstoque = estoque.Where(e => e.Quantidade > 0);
            foreach (var item in produtosComEstoque)
            {
                var roupa = roupas.FirstOrDefault(r => r.Id == item.RoupaId);
                var tamanho = tamanhos.FirstOrDefault(t => t.Id == item.TamanhoId);
                var cor = cores.FirstOrDefault(c => c.Id == item.CorId);
                Console.WriteLine($"{roupa?.Nome} | {tamanho?.Descricao} | {cor?.Nome} | Qtd: {item.Quantidade}");
            }

            Console.WriteLine("\n--- Produtos em Falta ---");
            var produtosSemEstoque = estoque.Where(e => e.Quantidade == 0);
            if (!produtosSemEstoque.Any())
            {
                Console.WriteLine("Nenhum produto em falta.");
            }
            else
            {
                foreach (var item in produtosSemEstoque)
                {
                    var roupa = roupas.FirstOrDefault(r => r.Id == item.RoupaId);
                    var tamanho = tamanhos.FirstOrDefault(t => t.Id == item.TamanhoId);
                    var cor = cores.FirstOrDefault(c => c.Id == item.CorId);
                    Console.WriteLine($"{roupa?.Nome} | {tamanho?.Descricao} | {cor?.Nome} | FALTA");
                }
            }

            Console.WriteLine($"\nTotal de itens diferentes: {estoque.Count}");
            Console.WriteLine($"Total de peças em estoque: {estoque.Sum(e => e.Quantidade)}");
        }
        
    }
