using System;

namespace LZGamesHub.Classes
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeEstoque { get; set; }

        public Produto(int id, string nome, decimal preco, int quantidadeEstoque)
        {
            this.Id = id;
            this.Nome = nome;
            this.Preco = preco;
            this.QuantidadeEstoque = quantidadeEstoque;
        }

        public virtual void ExibirDados()
        {
            Console.WriteLine("ID: " + Id);
            Console.WriteLine("Produto: " + Nome);
            Console.WriteLine("Preço: R$ " + Preco.ToString("F2"));
            Console.WriteLine("Estoque: " + QuantidadeEstoque);
        }

        public bool TemEstoque(int quantidade)
        {
            return QuantidadeEstoque >= quantidade;
        }

        public void RemoverDoEstoque(int quantidade)
        {
            if (quantidade <= 0)
            {
                throw new ArgumentException("A quantidade deve ser maior que zero.");
            }

            if (!TemEstoque(quantidade))
            {
                throw new InvalidOperationException("Estoque insuficiente.");
            }

            QuantidadeEstoque -= quantidade;
        }

        public void AdicionarAoEstoque(int quantidade)
        {
            if (quantidade <= 0)
            {
                throw new ArgumentException("A quantidade deve ser maior que zero.");
            }

            QuantidadeEstoque += quantidade;
        }
    }
}