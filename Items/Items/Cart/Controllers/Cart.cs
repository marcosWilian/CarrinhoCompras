using Cart.Model;
using Items.Model;
using Microsoft.AspNetCore.Mvc;

namespace Cart.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartController : ControllerBase
    {

        [HttpPost]
        [Route("AddItem")]
        public IActionResult AddItem([FromBody] ExternalCart item)
        {
            // VERIFICA SE CARRINHO EXISTE
            if (Carts.carts.Count(x => x.CartID == item.CartID) == 1)
            {
                int CartINDEX = Carts.carts.FindIndex(x => x.CartID == item.CartID);
                // VERIFICA SE ITEM EXISTE
                if (Carts.carts[CartINDEX].ItemList.Count(x => x.ItemID == item.ItemID) == 1)
                {
                    int ItemIndex = Carts.carts[CartINDEX].ItemList.FindIndex(x => x.ItemID == item.ItemID);
                    Carts.carts[CartINDEX].ItemList[ItemIndex].quantity += item.quantity;
                }
                else
                { // SE ITEM NÃO EXISTE NO CARRINHO ADICIONA
                    Carts.carts[CartINDEX]
                        .ItemList.Add(new CartModel
                        {
                            ItemID = item.ItemID,
                            quantity = item.quantity
                        });
                }
            }
            else
            { //ADICIONA UM NOVO CARRINHO SE NÃO EXISTIR
                Carts.carts.Add(new CartsModel 
                { 
                    CartID = item.CartID, ItemList = new List<CartModel>()
                    {
                       new CartModel
                       {
                           ItemID =item.ItemID,
                           quantity=item.quantity
                       },
                    }
                });
            }

            return Ok();

        }

        //[HttpPost]
        //[Route("GetItem")]
        //public ViewStock RemoveItem([FromQuery] int ItemID)
        //{
        //    return new ViewStock();
        //}

        //[HttpPost]
        //[Route("GetItem")]
        //public ViewStock UpdateItem([FromQuery] int ItemID)
        //{
        //    return new ViewStock();
        //}

        //[HttpPost]
        //[Route("GetItem")]
        //public ViewStock CleanCart([FromQuery] int ItemID)
        //{
        //    return new ViewStock();
        //}

        //[HttpPost]
        //[Route("GetItem")]
        //public ViewStock RecoverCart([FromQuery] int ItemID)
        //{
        //    return new ViewStock();
        //}


    }
}