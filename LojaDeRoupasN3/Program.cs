using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LojaDeRoupas.Services;

namespace LojaDeRoupas
{
   public class Program
    {
        private static InventarioService inventario = new InventarioService();

        public static void Main(string[] args)
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("  SISTEMA DE CONTROLE DE INVENTÁRIO");
            Console.WriteLine("        LOJA DE ROUPAS");
            Console.WriteLine("==============================================");

            bool continuar = true;
            while (continuar)
            {
                ExibirMenu();
                Console.Write("Escolha uma opção: ");
                
                if (int.TryParse(Console.ReadLine(), out int opcao))
                {
                    continuar = ProcessarOpcao(opcao);
                }
                else
                {
                    Console.WriteLine("Opção inválida! Digite um número.");
                }
                
                if (continuar)
                {
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        private static void ExibirMenu()
        {
            Console.WriteLine("\n============== MENU PRINCIPAL ==============");
            Console.WriteLine("1  - Cadastrar Roupa");
            Console.WriteLine("2  - Listar Roupas");
            Console.WriteLine("3  - Adicionar ao Estoque");
            Console.WriteLine("4  - Consultar Estoque");
            Console.WriteLine("5  - Registrar Venda");
            Console.WriteLine("6  - Listar Vendas");
            Console.WriteLine("7  - Cadastrar Fornecedor");
            Console.WriteLine("8  - Listar Fornecedores");
            Console.WriteLine("9  - Relatório de Estoque");
            Console.WriteLine("0  - Sair");
            Console.WriteLine("===========================================");
        }

        private static bool ProcessarOpcao(int opcao)
        {
            try
            {
                switch (opcao)
                {
                    case 1:
                        inventario.CadastrarRoupa();
                        break;
                    case 2:
                        inventario.ListarRoupas();
                        break;
                    case 3:
                        inventario.AdicionarEstoque();
                        break;
                    case 4:
                        inventario.ConsultarEstoque();
                        break;
                    case 5:
                        inventario.RegistrarVenda();
                        break;
                    case 6:
                        inventario.ListarVendas();
                        break;
                    case 7:
                        inventario.CadastrarFornecedor();
                        break;
                    case 8:
                        inventario.ListarFornecedores();
                        break;
                    case 9:
                        inventario.GerarRelatorioEstoque();
                        break;
                    case 0:
                        Console.WriteLine("\nObrigado por usar o Sistema de Inventário!");
                        Console.WriteLine("Sistema finalizado.");
                        return false;
                    default:
                        Console.WriteLine("Opção inválida! Escolha uma opção de 0 a 9.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
            
            return true;
        }
    }
}