using Microsoft.AspNetCore.Mvc;
using StokTakipProgrami.Concrate;
using StokTakipProgrami.Entity;

namespace StokTakipProgrami.Controllers
{
	public class ProductsController : Controller
	{
		private readonly ProductsManager _productManager;
		private readonly CategoryManager _categoryManager;

		public ProductsController(ProductsManager productManager, CategoryManager categoryManager)
		{
			_productManager = productManager;
			_categoryManager = categoryManager;
		}

		// GET: Product List
		public IActionResult ProductList()
		{
			var values = _productManager.GetListProduct();
			return View(values);
		}

		// GET: Add Product View
		public IActionResult ProductAdd()
		{
			ViewBag.Categories = _categoryManager.GetListCategory();
			return View();
		}

		// POST: Add Product
		[HttpPost]
		public IActionResult ProductAdd(Product product)
		{
			if (ModelState.IsValid)
			{
				_productManager.AddProduct(product);
				return RedirectToAction("ProductList");
			}
			ViewBag.Categories = _categoryManager.GetListCategory();
			return View(product);
		}

		// GET: Edit Product View
		public IActionResult ProductEdit(int id)
		{
			var product = _productManager.GetProductById(id);
			if (product == null)
			{
				return NotFound();
			}
			ViewBag.Categories = _categoryManager.GetListCategory();
			return View(product);
		}

		// POST: Edit Product
		[HttpPost]
		public IActionResult ProductEdit(Product product)
		{
			if (ModelState.IsValid)
			{
				_productManager.UpdateProduct(product);
				return RedirectToAction("ProductList");
			}
			ViewBag.Categories = _categoryManager.GetListCategory();
			return View(product);
		}

		// GET: Delete Product
		public IActionResult ProductDelete(int id)
		{
			var product = _productManager.GetProductById(id);
			if (product == null)
			{
				return NotFound();
			}
			return View(product);
		}

		// POST: Delete Product
		[HttpPost, ActionName("ProductDelete")]
		public IActionResult ProductDeleteConfirmed(int id)
		{
			var product = _productManager.GetProductById(id);
			if (product == null)
			{
				return NotFound();
			}
			_productManager.DeleteProduct(product);
			return RedirectToAction("ProductList");
		}
	}
}
