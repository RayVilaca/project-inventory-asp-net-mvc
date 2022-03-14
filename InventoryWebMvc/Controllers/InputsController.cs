using InventoryWebMvc.Models;
using InventoryWebMvc.Models.ViewModels;
using InventoryWebMvc.Services;
using InventoryWebMvc.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InventoryWebMvc.Controllers
{
    public class InputsController : Controller
    {
        private readonly InputService _inputService;
        private readonly ProductService _productService;

        public InputsController(InputService inputService, ProductService productService)
        {
            _inputService = inputService;
            _productService = productService;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _inputService.FindAllAsync();
            return View(list);
        }

        public IActionResult Search()
        {
            return View();
        }

        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            if(!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            var result = await _inputService.FindByDateAsync(minDate, maxDate);
            return View(result);
        }

        public async Task<IActionResult> Create()
        {
            var products = await _productService.FindAllAsync();
            var viewModel = new InputFormViewModel { Products = products };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Input input)
        {
            await _inputService.InsertAsync(input);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new {Message = "Id not provided"});
            }

            var obj = await _inputService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "Id not found" });
            }

            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _inputService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "Id not provided" });
            }

            var obj = await _inputService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "Id not found" });
            }

            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "Id not provided" });
            }

            var obj = await _inputService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "Id not found" });
            }

            List<Product> products = await _productService.FindAllAsync();
            InputFormViewModel viewModel = new InputFormViewModel { Input = obj, Products = products };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Input input)
        {

            if (id != input.Id)
            {
                return RedirectToAction(nameof(Error), new { Message = "Id mismatch" });
            }

            try
            {
                await _inputService.UpdateAsync(input);
                return RedirectToAction(nameof(Index));
            }
            catch(ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { Message = e.Message });
            }
        }

        public IActionResult Error(String message)
        {
            var viewModel = new ErrorViewModel
            { 
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(viewModel);
        }
    }
}
