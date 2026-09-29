using System;
using System.IO;
using Newtonsoft.Json;

namespace LZGamesHub.Services
{
    public static class DadosService
    {
        private static string caminhoArquivo = "dados.json";

        public static void SalvarDados(LojaService loja)
        {
            try
            {
                string json = JsonConvert.SerializeObject(
                    loja,
                    Formatting.Indented
                );

                File.WriteAllText(caminhoArquivo, json);

                Console.WriteLine("Dados salvos com sucesso!");
            }
            catch (Exception erro)
            {
                Console.WriteLine("Erro ao salvar os dados: " + erro.Message);
            }
        }

        public static LojaService CarregarDados()
        {
            try
            {
                if (!File.Exists(caminhoArquivo))
                {
                    Console.WriteLine("Nenhum arquivo de dados encontrado.");
                    return new LojaService();
                }

                string json = File.ReadAllText(caminhoArquivo);

                LojaService loja = JsonConvert.DeserializeObject<LojaService>(json);

                if (loja == null)
                {
                    return new LojaService();
                }

                Console.WriteLine("Dados carregados com sucesso!");

                return loja;
            }
            catch (Exception erro)
            {
                Console.WriteLine("Erro ao carregar os dados: " + erro.Message);

                return new LojaService();
            }
        }
    }
}