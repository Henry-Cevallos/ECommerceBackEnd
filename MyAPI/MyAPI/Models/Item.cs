namespace MyAPI.Models
{
    public class Item
    {
        public int item_id { get; set; }
        public int user_id { get; set; }
        public string title { get; set; }
        public float price { get; set; }   
        public string description { get; set; }
    }
}
