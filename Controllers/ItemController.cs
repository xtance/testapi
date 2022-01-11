using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        public ItemController()
        {
            /* Добавление разных элементов теста ради */
            _ = new Item("Товар 0", 123, "Описание товара");
            _ = new Item("Товар 1", 123, "Описание товара");
            _ = new Item("Товар 2", 123, "Описание товара");
        }

        [HttpGet("all")]
        public IEnumerable<Item> GetAll()
        {
            return Item.GetAll();
        }

        [HttpGet]
        public ActionResult<Item> GetOne(Guid guid)
        {
            Item? item = Item.GetOne(guid);
            if (item == null) return NotFound($"Нет предмета с Guid {guid}");
            return Ok(item);
        }

        [HttpPost]
        public Item Create(string name, int price, string description)
        {
            return new Item(name, price, description);
        }

        [HttpDelete]
        public bool Remove(Guid guid)
        {
            Item? item = Item.GetOne(guid);
            if (item == null) return false;
            item.Remove();
            return true;
        }

        [HttpPatch]
        public ActionResult<Item?> SetCategory(Guid guid, int catID)
        {
            Item? item = Item.GetOne(guid);
            if (item == null) return NotFound($"Нет предмета с Guid {guid}");

            Category? cat = Category.GetOne(catID);
            if (cat == null) return NotFound($"Нет категории с ID {catID}");

            cat.AddItem(item);
            return Ok(item);
        }
    }
}
