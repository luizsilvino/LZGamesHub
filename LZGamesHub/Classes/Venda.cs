using System;
using System.Collections.Generic;

namespace LZGamesHub.Classes
{
    public class Venda
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime Data { get; set; }
        public List<ItemVenda> Itens { get; set; }

        public Venda(int id, Cliente cliente)
        {
            this.Id = id;
            this.Cliente = cliente;
            this.Data = DateTime.Now;
            this.Itens = new List<ItemVenda>();
        }

        public void AdicionarItem(Produto produto, int quantidade)
        {
            if (quantidade <= 0)
            {
                throw new ArgumentException("A quantidade deve ser maior que zero.");
            }

            if (!produto.TemEstoque(quantidade))
            {
                throw new InvalidOperationException("Estoque insuficiente.");
            }

            produto.RemoverDoEstoque(quantidade);

            ItemVenda item = new ItemVenda(produto, quantidade);
            Itens.Add(item);
        }

        public decimal CalcularTotal()
        {
            decimal total = 0;

            foreach (ItemVenda item in Itens)
            {
                total += item.CalcularSubtotal();
            }

            return total;
        }

        public void ExibirVenda()
        {
            Console.WriteLine("================================");
            Console.WriteLine("VENDA Nº " + Id);
            Console.WriteLine("================================");
            Console.WriteLine("Cliente: " + Cliente.Nome);
            Console.WriteLine("Data: " + Data);
            Console.WriteLine();

            foreach (ItemVenda item in Itens)
            {
                Console.WriteLine(
                    item.Quantidade + "x " +
                    item.Produto.Nome +
                    " - R$ " +
                    item.CalcularSubtotal().ToString("F2")
                );
            }

            Console.WriteLine("--------------------------------");
            Console.WriteLine("TOTAL: R$ " + CalcularTotal().ToString("F2"));
            Console.WriteLine("================================");
        }

        public void CancelarVenda()
        {
            foreach (ItemVenda item in Itens)
            {
                item.Produto.AdicionarAoEstoque(item.Quantidade);
            }

            Itens.Clear();
        }
    }
}