using System;

namespace LZGamesHub.Classes
{
    public class Cliente : Pessoa
    {
        public string CPF { get; set; }

        public Cliente(int id, string nome, string telefone, string cpf)
            : base(id, nome, telefone)
        {
            this.CPF = cpf;
        }

        public override void ExibirDados()
        {
            Console.WriteLine("=== DADOS DO CLIENTE ===");
            base.ExibirDados();
            Console.WriteLine("CPF: " + CPF);
        }
    }
}