using System;

namespace LZGamesHub.Classes
{
    public class Jogo : Produto
    {
        public string Plataforma { get; set; }
        public string Genero { get; set; }

        public Jogo(int id, string nome, decimal preco, int quantidadeEstoque,
                    string plataforma, string genero)
            : base(id, nome, preco, quantidadeEstoque)
        {
            this.Plataforma = plataforma;
            this.Genero = genero;
        }

        public override void ExibirDados()
        {
            Console.WriteLine("=== JOGO ===");
            base.ExibirDados();
            Console.WriteLine("Plataforma: " + Plataforma);
            Console.WriteLine("Gênero: " + Genero);
        }
    }
}