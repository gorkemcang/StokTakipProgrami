﻿using Microsoft.AspNetCore.Mvc;
using StokTakipProgrami.Concrate;
using StokTakipProgrami.Entity;
using StokTakipProgrami.Models;
using System.Diagnostics;

namespace StokTakipProgrami.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryManager _categoryManager;

        public CategoryController(CategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        // GET: Category List
        public IActionResult CategoryList()
        {
            var values = _categoryManager.GetListCategory();
            return View(values);
        }

        // GET: Add Category View
        public IActionResult CategoryAdd()
        {
            return View();
        }

        // POST: Add Category
        [HttpPost]
        public IActionResult CategoryAdd(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryManager.AddCategory(category);
                return RedirectToAction("CategoryList");
            }
            return View(category);
        }

        [HttpGet]
        public IActionResult CategoryEdit(int id)
        {
            var category = _categoryManager.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult CategoryEdit(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryManager.UpdateCategory(category);
                return RedirectToAction("CategoryList");
            }
            return View(category);
        }

        
        public IActionResult CategoryDelete(int id)
        {
			var category = _categoryManager.GetCategoryById(id);
            _categoryManager.DeleteCategory(category);
            return RedirectToAction("CategoryList");
		}
    }
}
