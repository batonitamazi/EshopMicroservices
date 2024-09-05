using Marten.Schema;

namespace BasketAPI.Models
{
    public class ShoppingCart
    {
        [Identity]
        public string UserName { get; set; } = default!;
        public List<ShoppingCartItem> Items { get; set; } = new();
        public decimal ToTalPrice => Items.Sum(x => x.Quantity * x.Price);
        
        public ShoppingCart(string userName)
        {
            UserName = userName;
        }
        public ShoppingCart()
        {
        }
    }
}
