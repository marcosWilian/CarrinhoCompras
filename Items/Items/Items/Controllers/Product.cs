using Items.Model;
using Microsoft.AspNetCore.Mvc;

namespace Items.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Product : ControllerBase
    {
        [HttpGet]
        [Route("GetItem")]
        public ViewStock GetItem([FromQuery] int ItemID)
        {

            var Stock = Items.WareHouse.Estoque.FindAll(x => x.Item.Id == ItemID).FirstOrDefault();

            if (Stock == null) return new ViewStock { ReturnMessage = "Item não encontrado" };

            return new ViewStock
            {
                Item = Stock.Item,
                Quantity = Stock.Quantity,
            };
        }

        [HttpPost]
        [Route("BookItem")]
        public ViewStock BookItem([FromQuery] int ItemID, int Quantity, Guid CartID)
        {

            var Stock = Items.WareHouse.Estoque.FindAll(x => x.Item.Id == ItemID).FirstOrDefault();

            if (Stock == null) return new ViewStock { ReturnMessage = "Item não encontrado" };
            if (Stock.Quantity <= 0) return new ViewStock { ReturnMessage = "Item não possui Estoque" };
            if (Quantity > Stock.Quantity) return new ViewStock { ReturnMessage = "Quantidade de itens maior que quantidade de estoque existente" };

            lock (Stock)
            {

                int ProductINDEX = Items.WareHouse.Estoque.FindIndex(x => x.Item.Id == ItemID);

                Book booking = new Book()
                {
                    CartID = CartID,
                    Quantity = Quantity,
                };

                if (Stock.Booking is null)
                    Items.WareHouse.Estoque[ProductINDEX].Booking = new List<Book>{ booking };
                else
                    Items.WareHouse.Estoque[ProductINDEX].Booking.Add(booking);

                Items.WareHouse.Estoque[ProductINDEX].Quantity = Stock.Quantity - Quantity;

                return new ViewStock
                {
                    Item = Stock.Item,
                    Quantity = Stock.Booking.Find(x => x.CartID == CartID).Quantity,
                };
            }
        }
    }
}
