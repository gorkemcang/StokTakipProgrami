using Microsoft.AspNetCore.Mvc;
using StokTakipProgrami.Concrate;
using StokTakipProgrami.Entity;
using StokTakipProgrami.Models;
using System.Diagnostics;

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

		public IActionResult ProductDetail(int id)
		{
			var values = _productManager.GetProductById(id);
			return View(values);
		}
		// GET: Add Product View
		public IActionResult ProductAdd()
		{
			ViewBag.Categories = _categoryManager.GetListCategory();
			return View();
		}

		[HttpGet]
		public IActionResult ProductAdd(int id)
		{
			var product = _productManager.GetProductById(id);
			if (product == null)
			{
				// Handle the case when the product is not found
				return NotFound();
			}
			ViewBag.Categories = _categoryManager.GetListCategory();
			return View(product);

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
			ViewBag.Category = _categoryManager.GetListCategory();
			return View(product);
		}

		[HttpGet]
		public IActionResult ProductEdit(int id)
		{
			var product = _productManager.GetProductById(id);
			if (product == null)
			{
				// Handle the case when the product is not found
				return NotFound();
			}
			ViewBag.Categories = _categoryManager.GetListCategory();
			return View(product);

		}

		[HttpPost]
		public IActionResult ProductEdit(Product product)
		{
			if (ModelState.IsValid)
			{
				_productManager.UpdateProduct(product);
				return RedirectToAction("ProductList");
			}
			ViewBag.Category = _categoryManager.GetListCategory();
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

			try
			{
				_productManager.DeleteProduct(product);
				return RedirectToAction("ProductList");
			}
			catch (Exception ex)
			{
				// Hata durumunu yönetmek için bir logger kullanabilir veya hata mesajı gösterebilirsiniz.
				// Örneğin: Logger.LogError(ex, "Ürün silme işlemi sırasında bir hata oluştu.");
				return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
			}
		}
	}
}
