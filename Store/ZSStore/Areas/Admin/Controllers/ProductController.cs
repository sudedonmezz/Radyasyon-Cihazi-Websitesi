using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contracts;

namespace ZSStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin,Editor")]
    public class ProductController:Controller
    {
        public readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var model=_manager.ProductService.GetAllproducts(false);
            return View(model);
        }

        private SelectList GetCategoriesSelectList()
        {
            return ViewBag.Categories=new SelectList(_manager.CategoryService.GetAllCategories(false),"CategoryId","CategoryName",1);
        }
        public IActionResult Create()
        {   
            
            ViewBag.Categories=GetCategoriesSelectList();
            
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] ProductDtoForInsertion productDto,IFormFile file)
        {
            if(ModelState.IsValid)
            {
                //dosya icin
                string path= Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","images",file.FileName);

                using(var stream=new FileStream(path,FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                productDto.ImageUrl=String.Concat("/images/",file.FileName);


            _manager.ProductService.CreateProduct(productDto);
            return RedirectToAction("Index");
            }
            return View();
            
        }

        public IActionResult Update([FromRoute(Name ="id")] int id)
        {
            ViewBag.Categories=GetCategoriesSelectList();
            var model=_manager.ProductService.GetOneProductForUpdate(id,false);
            return View(model);
        }

       [HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Update([FromForm] ProductDtoForUpdate productDto, IFormFile? file)
{
    if (ModelState.IsValid)
    {
        // Kullanıcı yeni bir görsel yüklediyse
        if (file != null && file.Length > 0)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            productDto.ImageUrl = "/images/" + file.FileName;
        }

        _manager.ProductService.UpdateOneProduct(productDto);
        return RedirectToAction("Index");
    }

    
    ViewBag.Categories = new SelectList(
        _manager.CategoryService.GetAllCategories(false),
        "CategoryId",
        "CategoryName",
        productDto.CategoryId
    );

    return View(productDto);
}

 [HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Delete(int id)
{
    _manager.ProductService.DeleteOneProduct(id);
    TempData["Message"] = "Ürün başarıyla silindi.";
    return RedirectToAction("Index");
}


    }
}