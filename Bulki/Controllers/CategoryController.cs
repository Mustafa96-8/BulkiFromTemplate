using Bulki.Data;
using Bulki.Models;
using Bulki.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Bulki.Controllers
{
	public class CategoryController : Controller
	{

		private readonly ICategoryRepository _categoryRepo;

		public CategoryController(ICategoryRepository context)
		{
            _categoryRepo = context;		
		}
			
		public IActionResult Index()
		{
			var objCategoryList = _categoryRepo.GetAll().ToList();
			return View(objCategoryList);
		}

        public IActionResult GetOne(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _categoryRepo.Get(u=>u.Id==id);
            //Category? categoryFromDb2 = _context.Categories.Where(u=>u.Id==id).FirstOrDefault();
            //Category? categoryFromDb3 = _context.Categories.FirstOrDefault(u=>u.Id==id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        

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
                _categoryRepo.Add(obj); //Добавление в локальную БД
                _categoryRepo.Save(); //Сохранение в БД 
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
            Category? categoryFromDb = _categoryRepo.Get(u=>u.Id==id);
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
                _categoryRepo.Update(obj); //Обновленеи в локальную БД
                _categoryRepo.Save(); //Сохранение в БД
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
            Category? categoryFromDb = _categoryRepo.Get(u => u.Id == id);
            
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
            Category? obj = _categoryRepo.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _categoryRepo.Delete(obj);
            _categoryRepo.Save();
            TempData["success"] = "Категория успешно удалена";
            return RedirectToAction("Index");
        }
    }
}
