using System;
using LZGamesHub.Interfaces;

namespace LZGamesHub.Classes
{
    public class PagamentoPix : IPagamento
    {
        public void RealizarPagamento(decimal valor)
        {
            Console.WriteLine("Pagamento via PIX realizado com sucesso!");
            Console.WriteLine("Valor pago: R$ " + valor.ToString("F2"));
        }
    }
}