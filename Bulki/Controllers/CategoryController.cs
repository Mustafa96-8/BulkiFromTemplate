using Bulki.Data;
using Bulki.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bulki.Controllers
{
	public class CategoryController : Controller
	{

		private readonly ApplicationDbContext _context;

		public CategoryController(ApplicationDbContext context)
		{
			_context = context;		
		}
			
		public IActionResult Index()
		{
			var objCategoryList = _context.Categories.ToList();
			return View(objCategoryList);
		}

        public IActionResult GetOne(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _context.Categories.Find(id);
            //Category? categoryFromDb2 = _context.Categories.Where(u=>u.Id==id).FirstOrDefault();
            //Category? categoryFromDb3 = _context.Categories.FirstOrDefault(u=>u.Id==id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        
        
        /*public IActionResult GetOne(string name)
        {
            if (name == null || name == "")
            {
                return NotFound();
            }
            //Category? categoryFromDb = _context.Categories.Find(id);
            Category? categoryFromDb = _context.Categories.Where(u=>u.Name==name).FirstOrDefault();
            //Category? categoryFromDb3 = _context.Categories.FirstOrDefault(u=>u.Id==id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }*/

        //Create Block
        public IActionResult Create()
		{
			return View();
        }
        [HttpPost] 
		
		public IActionResult Create(Category obj)
		{
			if(obj.Name == obj.DisplayOrder.ToString())
			{
				ModelState.AddModelError("name", "The displayOrder cant be Name");	
			}
            
            if (ModelState.IsValid)
			{
                _context.Categories.Add(obj); //Добавление в локальную БД
                _context.SaveChanges(); //Сохранение в БД 
                TempData["success"] = "Категория успешно создана";
                return RedirectToAction("Index");
            }
			return View();
        }

        //Update Block

        public IActionResult Edit(int? id)
        {
            if(id == null||id == 0)
            {
                return NotFound(); 
            }
            Category? categoryFromDb = _context.Categories.Find(id);
            //Category? categoryFromDb2 = _context.Categories.Where(u=>u.Id==id).FirstOrDefault();
            //Category? categoryFromDb3 = _context.Categories.FirstOrDefault(u=>u.Id==id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost]

        public IActionResult Edit(Category obj)
        {

            if (ModelState.IsValid)
            {
                _context.Categories.Update(obj); //Обновленеи в локальную БД
                _context.SaveChanges(); //Сохранение в БД
                TempData["success"] = "Категория успешно изменена";
                return RedirectToAction("Index");
            }
            return View();
        }

        //Delete Block
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _context.Categories.Find(id);
            
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? obj = _context.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(obj);
            _context.SaveChanges();
            TempData["success"] = "Категория успешно удалена";
            return RedirectToAction("Index");
        }
    }
}
