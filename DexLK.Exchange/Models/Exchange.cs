namespace DexLK.Exchange.Models
{
    public class Exchange
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int FromWalletId { get; set; }
        public int ToWalletId { get; set; }
        public decimal Amount { get; set; }
        public int createdUserId { get; set; }
    }
}