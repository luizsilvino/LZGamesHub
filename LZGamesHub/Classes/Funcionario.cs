using System;

namespace LZGamesHub.Classes
{
    public class Funcionario : Pessoa
    {
        public string Cargo { get; set; }

        public Funcionario(int id, string nome, string telefone, string cargo)
            : base(id, nome, telefone)
        {
            this.Cargo = cargo;
        }

        public override void ExibirDados()
        {
            Console.WriteLine("=== DADOS DO FUNCIONÁRIO ===");
            base.ExibirDados();
            Console.WriteLine("Cargo: " + Cargo);
        }
    }
}