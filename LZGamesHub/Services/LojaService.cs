using System;
using System.Collections.Generic;
using LZGamesHub.Classes;

namespace LZGamesHub.Services
{
    public class LojaService
    {
        public List<Cliente> Clientes { get; set; }
        public List<Jogo> Jogos { get; set; }
        public List<Venda> Vendas { get; set; }

        public LojaService()
        {
            Clientes = new List<Cliente>();
            Jogos = new List<Jogo>();
            Vendas = new List<Venda>();
        }

        public void AdicionarCliente(Cliente cliente)
        {
            Clientes.Add(cliente);
        }

        public void AdicionarJogo(Jogo jogo)
        {
            Jogos.Add(jogo);
        }

        public void AdicionarVenda(Venda venda)
        {
            Vendas.Add(venda);
        }

        public Cliente BuscarClientePorId(int id)
        {
            foreach (Cliente cliente in Clientes)
            {
                if (cliente.Id == id)
                {
                    return cliente;
                }
            }

            return null;
        }

        public Jogo BuscarJogoPorId(int id)
        {
            foreach (Jogo jogo in Jogos)
            {
                if (jogo.Id == id)
                {
                    return jogo;
                }
            }

            return null;
        }

        public void ListarClientes()
        {
            if (Clientes.Count == 0)
            {
                Console.WriteLine("Nenhum cliente cadastrado.");
                return;
            }

            Console.WriteLine("=== CLIENTES CADASTRADOS ===");

            foreach (Cliente cliente in Clientes)
            {
                cliente.ExibirDados();
                Console.WriteLine();
            }
        }

        public void ListarJogos()
        {
            if (Jogos.Count == 0)
            {
                Console.WriteLine("Nenhum jogo cadastrado.");
                return;
            }

            Console.WriteLine("=== JOGOS CADASTRADOS ===");

            foreach (Jogo jogo in Jogos)
            {
                jogo.ExibirDados();
                Console.WriteLine();
            }
        }

        public void ListarVendas()
        {
            if (Vendas.Count == 0)
            {
                Console.WriteLine("Nenhuma venda registrada.");
                return;
            }

            foreach (Venda venda in Vendas)
            {
                venda.ExibirVenda();
                Console.WriteLine();
            }
        }

        public void ListarEstoqueBaixo()
        {
            Console.WriteLine("=== PRODUTOS COM ESTOQUE BAIXO ===");

            bool encontrou = false;

            foreach (Jogo jogo in Jogos)
            {
                if (jogo.QuantidadeEstoque <= 2)
                {
                    Console.WriteLine(
                        jogo.Nome + " - " +
                        jogo.QuantidadeEstoque + " unidade(s)"
                    );

                    encontrou = true;
                }
            }

            if (!encontrou)
            {
                Console.WriteLine("Nenhum produto com estoque baixo.");
            }
        }
        public bool ExcluirCliente(int id)
        {
            Cliente cliente = BuscarClientePorId(id);

            if (cliente == null)
            {
                return false;
            }

            Clientes.Remove(cliente);
            return true;
        }

        public bool ExcluirJogo(int id)
        {
            Jogo jogo = BuscarJogoPorId(id);

            if (jogo == null)
            {
                return false;
            }

            Jogos.Remove(jogo);
            return true;
        }
    }
}   