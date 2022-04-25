using Items.Model;

namespace Items
{
    public static class WareHouse
    {
        public static List<Stock> Estoque = new List<Stock>
        {
            new Stock
            {
                Quantity = 100,
                Item = new Item
                {
                    Id = 1,
                    Category = "HeadPhones 1",
                    CreatedDate = DateTime.Now,
                    ImageURL = "https://m.media-amazon.com/images/I/71EHw68EScL._AC_SX679_.jpg",
                    Price = 100.00M,
                    ProductName = "Head Phone Ultra Maneiro"
                },
            },
            new Stock
            {
                Quantity = 50,
                Item = new Item
                {
                    Id = 2,
                    Category = "HeadPhones 2",
                    CreatedDate = DateTime.Now,
                    ImageURL = "https://m.media-amazon.com/images/I/71EHw68EScL._AC_SX679_.jpg",
                    Price = 100.00M,
                    ProductName = "Head Phone Ultra Maneiro"
                },
            },
            new Stock
            {
                Quantity = 10,
                Item = new Item
                {
                    Id = 3,
                    Category = "HeadPhones 3",
                    CreatedDate = DateTime.Now,
                    ImageURL = "https://m.media-amazon.com/images/I/71EHw68EScL._AC_SX679_.jpg",
                    Price = 100.00M,
                    ProductName = "Head Phone Ultra Maneiro"
                },
            },
        };
    }
}