using Plugin.CloudFirestore.Attributes;
using System.Collections.Generic;

namespace Kota_Palace.Models
{
    public class MenuModel
    {
        [MapTo("name")]
        public string Name { get; set; }
        [MapTo("price")]
        public string Price { get; set; }
        [MapTo("url")]
        public string ImgUrl { get; set; }
        [MapTo("status")]
        public string Status { get; set; }
        [Id]
        public string Id { get; set; }
        
        public string ItemId { get; set; }
        [MapTo("extras")]
        public string [] Extras { get; set; }

    }
}