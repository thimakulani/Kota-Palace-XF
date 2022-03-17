using Plugin.CloudFirestore.Attributes;

namespace Kota_Palace.Models
{
    public class ShopModel
    {
        [MapTo("businessName")]
        public string BusinessName { get; set; }
        [MapTo("address")]
        public string BusinessAddress { get; set; }
        [MapTo("businessDescription")]
        public string BusinessDescription { get; set; }
        [MapTo("businessPhoneNo")]
        public string BusinessPhoneNumber { get; set; }
        [MapTo("email")]
        public string BusinessEmail { get; set; }
        [MapTo("url")]
        public string ImgUrl { get; set; }
        [Id]
        public string Id { get; set; } 

        [MapTo("Mon-Fri")]
        public string BusinessMF { get; set; }
        public string BusinessMFOpen { get; set; }
        [MapTo("Saturday")]
        public string BusinessSat { get; set; }
        [MapTo("Sunday")]
        public string BusinessSun { get; set; }
        [MapTo("onlineStatus")]
        public string OnlineStatus { get; set; }

        [MapTo("latlong")]
        public string Coordinates { get; set; }
    }
}
