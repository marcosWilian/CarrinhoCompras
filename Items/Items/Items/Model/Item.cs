namespace Items.Model
{
    public class Item
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string ImageURL { get; set; }
        public DateTime CreatedDate { get; set; }

        public static implicit operator Item?(Stock? v)
        {
            throw new NotImplementedException();
        }
    }
}
