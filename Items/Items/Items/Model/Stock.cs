namespace Items.Model
{

    public class Stock : ViewStock
    {
        public List<Book>? Booking { get; set; }

    }

    public class ViewStock
    {
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public string ReturnMessage { get; set; }
    }
}
