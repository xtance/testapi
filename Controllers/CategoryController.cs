using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private static bool isFirstRun = true;

        public CategoryController()
        {
            /* Добавление разных элементов теста ради */
            if (CategoryController.isFirstRun)
            {
                _ = new Category("Диваны");
                _ = new Category("Пуфики");
                _ = new Category("Кровати");
                CategoryController.isFirstRun = false;
            }
        }

        [HttpGet("all")]
        public IEnumerable<Category> GetAll()
        {
            return Category.GetAll();
        }

        [HttpGet]
        public ActionResult<Category> GetOne(int id)
        {
            Category? cat = Category.GetOne(id);
            if (cat == null) return NotFound($"Нет категории с ID {id}");
            return Ok(cat);
        }

        [HttpPost]
        public Category Create(string name)
        {
            return new Category(name);
        }

        [HttpPatch]
        public ActionResult<Category> Update(int id, string newName)
        {
            Category? cat = Category.GetOne(id);
            if (cat == null) return NotFound($"Нет категории с ID {id}");
            cat.Name = newName;
            return Ok(cat);
        }

        [HttpDelete]
        public bool Remove(int id)
        {
            Category? cat = Category.GetOne(id);
            if (cat == null) return false;
            cat.Remove();
            return true;
        }
    }
}
