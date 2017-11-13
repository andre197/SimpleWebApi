namespace SimpleWebApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services;
    using Services.Contracts;
    using System.Collections.Generic;
    using ViewModels;

    public class FoodController : Controller
    {
        private IFoodServices foodServices = new FoodServices();

        [HttpGet]
        public IActionResult GetAll()
        {
            List<FoodViewModel> result = this.foodServices.ListFoods();

            return View(result);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            FoodViewModel result = this.foodServices.FindById(id);

            return View(result);
        }
    }
}
