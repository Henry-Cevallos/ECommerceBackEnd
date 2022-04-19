namespace MyAPI.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public int UserId { get; set; }
        public string title { get; set; }
        public float price { get; set; }   
        public string description { get; set; }
    }
}
