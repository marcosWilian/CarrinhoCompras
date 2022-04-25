namespace Items.Model
{
    public class Book
    {
        public Guid CartID { get; set; }
        public int Quantity { get; set; }

        public static implicit operator List<object>(Book v)
        {
            throw new NotImplementedException();
        }
    }
}
