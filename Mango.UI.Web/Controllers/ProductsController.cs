using Mango.UI.Web.Models.Dtos;
using Mango.UI.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Mango.UI.Web.Controllers;

public class ProductsController : Controller
{
    protected readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var response = await _productService.GetAllAsync<ResponseDto>();
        var result = default(IEnumerable<ProductDto>); 

        if (response is not null && response.IsSuccess)
            result = JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(Convert.ToString(response.Result));

        return View(result);
    }

    [HttpGet]
    public async Task<IActionResult> Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ProductDto productDto)
    {
        if (ModelState.IsValid)
        {
            var response = await _productService.CreateAsync<ResponseDto>(productDto);

            if (response is not null && response.IsSuccess)
                return RedirectToAction(nameof(Index));
        }
        
        return View(productDto);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var response = await _productService.GetByIdAsync<ResponseDto>(id);

        if (id > 0 && response is not null && response.IsSuccess)
        {
            var result = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
            return View(result);
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(ProductDto productDto)
    {
        if (ModelState.IsValid)
        {
            var response = await _productService.UpdateAsync<ResponseDto>(productDto);

            if (response is not null && response.IsSuccess)
                return RedirectToAction(nameof(Index));
        }

        return View(productDto);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _productService.GetByIdAsync<ResponseDto>(id);

        if (id > 0 && response is not null && response.IsSuccess)
        {
            var result = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
            return View(result);
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(ProductDto productDto)
    {
        var response = await _productService.DeleteAsync<ResponseDto>(productDto.Id);

        if (productDto.Id > 0 && response is not null && response.IsSuccess)
        {
            return RedirectToAction(nameof(Index));
        }

        return RedirectToAction(nameof(Index));
    }
}
