using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebLabsV06.DAL.Entities;
using WebLabsV06.DAL;
using System.Linq;
using WebLabsV06.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebLabsV06.Controllers
{

    public class ProductController : Controller
    {
        public List<Dish> _dishes;
        List<DishGroup> _dishGroups;

        int _pageSize;
        public ProductController()
        {
            _pageSize = 3;
            SetupData();
        }

        [Route("Catalog")]
        [Route("Catalog/Page_{pageNo}")]

        public IActionResult Index(int? group, int pageNo = 1)
        {
            var dishesFiltered = _dishes
.Where(d => !group.HasValue || d.DishGroupId == group.Value);
            // Поместить список групп во ViewData
            ViewData["Groups"] = _dishGroups;
            // Получить id текущей группы и поместить в TempData
            ViewData["CurrentGroup"] = group ?? 0;
            return View(ListViewModel<Dish>.GetModel(dishesFiltered, pageNo, _pageSize));
        }
        /// <summary>
        /// Инициализация списков
        /// </summary>
        private void SetupData()
        {
            _dishGroups = new List<DishGroup>
{
    new DishGroup {DishGroupId=1, GroupName="Пицца"},
    new DishGroup {DishGroupId=2, GroupName="Напитки"},
    new DishGroup {DishGroupId=3, GroupName="Алкоголь"},
    new DishGroup {DishGroupId=4, GroupName="Мороженое"},
    new DishGroup {DishGroupId=5, GroupName="Табачные изделия"}
};
            _dishes = new List<Dish>
{
    new Dish {DishId = 1, DishName="Пеперони",
    Description="Пицца с колбасой",
    Weight =330, DishGroupId=1, Image="Пеперони.jpg" },
    new Dish { DishId = 2, DishName="Маргарита",
    Description="Бюджетная пицца",
    Weight =355, DishGroupId=1, Image="Маргарита.jpg" },
    new Dish { DishId = 3, DishName="Сырная",
    Description="4 сыра",
    Weight =610, DishGroupId=1, Image="Сырная.jpg" },
    new Dish { DishId = 4, DishName="Кола",
    Description="Кола",
    Weight =500, DishGroupId=2, Image="Кола.jpg" },
    new Dish { DishId = 5, DishName="Фанта",
    Description="Фанта",
    Weight =500, DishGroupId=2, Image="Фанта.jpg" },
    new Dish { DishId = 6, DishName="Спрайт",
    Description="Спрайт",
    Weight =500, DishGroupId=2, Image="Спрайт.jpg" },
    new Dish { DishId = 7, DishName="Водка",
    Description="Водка",
    Weight =50, DishGroupId=3, Image="Водка.jpg" },
    new Dish {DishId = 8, DishName="Виски",
    Description="Виски",
    Weight =50, DishGroupId=3, Image="Виски.jpg" },
    new Dish { DishId = 9, DishName="Коньяк",
    Description="Коньяк",
    Weight =50, DishGroupId=3, Image="Коньяк.jpg" },
    new Dish { DishId = 10, DishName="Рожок",
    Description="Мороженое в рожке",
    Weight =120, DishGroupId=4, Image="Рожок.jpg" },
    new Dish { DishId = 11, DishName="Стаканчик",
    Description="Мороженое в стаканчике",
    Weight =100, DishGroupId=4, Image="Стаканчик.jpg" },
    new Dish { DishId = 12, DishName="Креманка",
    Description="Мороженное в креманке",
    Weight =250, DishGroupId=4, Image="Креманка.jpg" },
    new Dish { DishId = 13, DishName="Мальборо",
    Description="Сигареты Мальборо",
    Weight =0, DishGroupId=5, Image="Мальборо.jpg" },
    new Dish { DishId = 14, DishName="Винстон",
    Description="Сигареты Винстон",
    Weight =0, DishGroupId=5, Image="Винстон.jpg" },
    new Dish { DishId = 15, DishName="Парламент",
    Description="Сигареты Парламент",
    Weight =0, DishGroupId=5, Image="Парламент.jpg" }

};
        }
    }
}
