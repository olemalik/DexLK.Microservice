using System.ComponentModel.DataAnnotations.Schema;

namespace DexLK.Exchange.Models
{
    public class Wallet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Balance { get; set; }
        public int createdUserId { get; set; }
    }
}