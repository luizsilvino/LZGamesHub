namespace LZGamesHub.Classes
{
    public class ItemVenda
    {
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }

        public ItemVenda(Produto produto, int quantidade)
        {
            this.Produto = produto;
            this.Quantidade = quantidade;
        }

        public decimal CalcularSubtotal()
        {
            return Produto.Preco * Quantidade;
        }
    }
}