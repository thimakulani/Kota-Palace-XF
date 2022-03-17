using Plugin.CloudFirestore.Attributes;
namespace Kota_Palace.Models
{
    public class CartModel
    {
        [MapTo("quantity")]
        public string Quantity { get; set; }
        [Id]
        public string Key { get; set; }
        [MapTo("shopId")]
        public string ShopId { get; set; }
        [MapTo("productId")]
        public string ItemId { get; set; }
        [MapTo("note")]
        public string Note { get; set; }
        [MapTo("productAddOns")]
        public string[] Extras { get; set; }
        //public Dictionary<string, string> ProductAddOns { get; set; }
    }
}