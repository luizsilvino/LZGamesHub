using System;
using LZGamesHub.Classes;
using LZGamesHub.Services;

namespace LZGamesHub
{
    internal class Program
    {
        static LojaService loja = new LojaService();

        static void Main(string[] args)
        {
            int opcao = -1;

            while (opcao != 0)
            {
                Console.Clear();

                Console.WriteLine("====================================");
                Console.WriteLine("          LZ GAMES HUB");
                Console.WriteLine("====================================");
                Console.WriteLine("1 - Cadastrar cliente");
                Console.WriteLine("2 - Cadastrar jogo");
                Console.WriteLine("3 - Listar clientes");
                Console.WriteLine("4 - Listar jogos");
                Console.WriteLine("5 - Consultar jogo");
                Console.WriteLine("6 - Registrar venda");
                Console.WriteLine("7 - Listar vendas");
                Console.WriteLine("8 - Ver produtos com estoque baixo");
                Console.WriteLine("9 - Excluir cadastro");
                Console.WriteLine("10 - Salvar dados");
                Console.WriteLine("11 - Carregar dados");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("====================================");
                Console.Write("Digite uma opção: ");

                try
                {
                    opcao = int.Parse(Console.ReadLine());

                    Console.Clear();

                    switch (opcao)
                    {
                        case 1:
                            CadastrarCliente();
                            break;

                        case 2:
                            CadastrarJogo();
                            break;

                        case 3:
                            loja.ListarClientes();
                            Pausar();
                            break;

                        case 4:
                            loja.ListarJogos();
                            Pausar();
                            break;

                        case 5:
                            ConsultarJogo();
                            break;

                        case 6:
                            RegistrarVenda();
                            break;

                        case 7:
                            loja.ListarVendas();
                            Pausar();
                            break;

                        case 8:
                            loja.ListarEstoqueBaixo();
                            Pausar();
                            break;

                        case 9:
                            ExcluirCadastro();
                            break;

                        case 10:
                            DadosService.SalvarDados(loja);
                            Pausar();
                            break;

                        case 11:
                            loja = DadosService.CarregarDados();
                            Pausar();
                            break;

                        case 0:
                            Console.WriteLine("Encerrando o LZ Games Hub...");
                            break;

                        default:
                            Console.WriteLine("Opção inválida.");
                            Pausar();
                            break;
                    }
                }
                catch (Exception erro)
                {
                    Console.WriteLine();
                    Console.WriteLine("Erro: " + erro.Message);
                    Pausar();
                }
            }
        }

        static void CadastrarCliente()
        {
            Console.WriteLine("=== CADASTRO DE CLIENTE ===");
            Console.WriteLine();

            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();

            Console.Write("CPF: ");
            string cpf = Console.ReadLine();

            Cliente cliente = new Cliente(id, nome, telefone, cpf);

            loja.AdicionarCliente(cliente);

            Console.WriteLine();
            Console.WriteLine("Cliente cadastrado com sucesso!");

            Pausar();
        }

        static void CadastrarJogo()
        {
            Console.WriteLine("=== CADASTRO DE JOGO ===");
            Console.WriteLine();

            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Nome do jogo: ");
            string nome = Console.ReadLine();

            Console.Write("Preço: R$ ");
            decimal preco = decimal.Parse(Console.ReadLine());

            Console.Write("Quantidade em estoque: ");
            int estoque = int.Parse(Console.ReadLine());

            Console.Write("Plataforma: ");
            string plataforma = Console.ReadLine();

            Console.Write("Gênero: ");
            string genero = Console.ReadLine();

            Jogo jogo = new Jogo(
                id,
                nome,
                preco,
                estoque,
                plataforma,
                genero
            );

            loja.AdicionarJogo(jogo);

            Console.WriteLine();
            Console.WriteLine("Jogo cadastrado com sucesso!");

            Pausar();
        }

        static void ConsultarJogo()
        {
            Console.WriteLine("=== CONSULTAR JOGO ===");
            Console.WriteLine();

            Console.Write("Digite o ID do jogo: ");
            int id = int.Parse(Console.ReadLine());

            Jogo jogo = loja.BuscarJogoPorId(id);

            Console.WriteLine();

            if (jogo == null)
            {
                Console.WriteLine("Jogo não encontrado.");
            }
            else
            {
                jogo.ExibirDados();
            }

            Pausar();
        }

        static void RegistrarVenda()
        {
            Console.WriteLine("=== REGISTRAR VENDA ===");
            Console.WriteLine();

            if (loja.Clientes.Count == 0)
            {
                Console.WriteLine("Nenhum cliente cadastrado.");
                Pausar();
                return;
            }

            if (loja.Jogos.Count == 0)
            {
                Console.WriteLine("Nenhum jogo cadastrado.");
                Pausar();
                return;
            }

            Console.Write("ID da venda: ");
            int idVenda = int.Parse(Console.ReadLine());

            Console.Write("ID do cliente: ");
            int idCliente = int.Parse(Console.ReadLine());

            Cliente cliente = loja.BuscarClientePorId(idCliente);

            if (cliente == null)
            {
                Console.WriteLine("Cliente não encontrado.");
                Pausar();
                return;
            }

            Venda venda = new Venda(idVenda, cliente);

            bool adicionarMais = true;

            while (adicionarMais)
            {
                Console.WriteLine();
                Console.Write("ID do jogo: ");
                int idJogo = int.Parse(Console.ReadLine());

                Jogo jogo = loja.BuscarJogoPorId(idJogo);

                if (jogo == null)
                {
                    Console.WriteLine("Jogo não encontrado.");
                }
                else
                {
                    Console.Write("Quantidade: ");
                    int quantidade = int.Parse(Console.ReadLine());

                    venda.AdicionarItem(jogo, quantidade);

                    Console.WriteLine("Produto adicionado à venda!");
                }

                Console.WriteLine();
                Console.Write("Deseja adicionar outro jogo? (S/N): ");
                string resposta = Console.ReadLine();

                if (resposta.ToUpper() != "S")
                {
                    adicionarMais = false;
                }
            }

            if (venda.Itens.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("A venda não possui nenhum item.");
                Pausar();
                return;
            }

            Console.Clear();

            venda.ExibirVenda();

            Console.WriteLine();
            Console.Write("Confirmar venda? (S/N): ");
            string confirmar = Console.ReadLine();

            if (confirmar.ToUpper() == "S")
            {
                loja.AdicionarVenda(venda);

                PagamentoPix pagamento = new PagamentoPix();
                pagamento.RealizarPagamento(venda.CalcularTotal());

                Console.WriteLine();
                Console.WriteLine("Venda registrada com sucesso!");
            }
            else
            {
                venda.CancelarVenda();

                Console.WriteLine();
                Console.WriteLine("Venda cancelada.");
                Console.WriteLine("Os produtos foram devolvidos ao estoque.");
            }

            Pausar();
        }

        static void ExcluirCadastro()
        {
            Console.WriteLine("=== EXCLUIR CADASTRO ===");
            Console.WriteLine();
            Console.WriteLine("1 - Excluir cliente");
            Console.WriteLine("2 - Excluir jogo");
            Console.Write("Escolha uma opção: ");

            int opcao = int.Parse(Console.ReadLine());

            Console.Write("Digite o ID: ");
            int id = int.Parse(Console.ReadLine());

            bool excluido = false;

            if (opcao == 1)
            {
                excluido = loja.ExcluirCliente(id);
            }
            else if (opcao == 2)
            {
                excluido = loja.ExcluirJogo(id);
            }
            else
            {
                Console.WriteLine("Opção inválida.");
                Pausar();
                return;
            }

            if (excluido)
            {
                Console.WriteLine("Cadastro excluído com sucesso!");
            }
            else
            {
                Console.WriteLine("Cadastro não encontrado.");
            }

            Pausar();
        }
        static void Pausar()
        {
            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}