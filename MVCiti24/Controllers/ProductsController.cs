using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCiti24.Models;

namespace MVCiti24.Controllers
{

    [Authorize]
    public class ProductsController : Controller
    {
        public IActionResult ShowAll()
        {
            ProductBL productBL = new ProductBL();
            List<Product> ListproductsModel = productBL.GetAll();
            return View("ShowAll", ListproductsModel);
        }

        public IActionResult GetProductDetails(int Id)
        {
            ProductBL productBL = new ProductBL();
            Product productsModel = productBL.GetProductById(Id);
            return View("Details", productsModel);
        }



    }
}
