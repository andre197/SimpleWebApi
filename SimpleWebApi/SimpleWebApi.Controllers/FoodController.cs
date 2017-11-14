namespace SimpleWebApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services;
    using Services.Contracts;
    using System;
    using System.Collections.Generic;
    using ViewModels;

    public class FoodController : Controller
    {
        private IFoodServices foodServices = new FoodServices();

        [HttpGet]
        public IEnumerable<FoodViewModel> GetAll()
        {
            IEnumerable<FoodViewModel> result = this.foodServices.ListFoods();

            return result;
        }

        [HttpGet]
        [Route("Food/GetById/{id}")]
        public IActionResult GetById(int id)
        {
            FoodViewModel result = this.foodServices.FindById(id);

            return new ObjectResult(result);
        }

        [HttpGet]
        public IActionResult AddFood()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddFood(AddOrUpdateFoodViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    foodServices.Insert(model);

                    return RedirectToRoute("/Home/Success");
                }
                catch (Exception)
                {
                    return RedirectToAction("/Food/AddFood");
                }
            }

            return BadRequest();
        }

        [HttpGet]
        public IActionResult Delete()
        {
            IEnumerable<FoodViewModel> allFoods = this.foodServices.ListFoods();

            return View(allFoods);
        }

        [HttpPost]
        [Route("Food/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                this.foodServices.Delete(id);

                return RedirectToRoute("/Home/Success");
            }
            catch (Exception)
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Update()
        {
            IEnumerable<FoodViewModel> allFoods = this.foodServices.ListFoods();

            return View(allFoods);
        }

        [HttpPost]
        public IActionResult Update(FoodViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this.foodServices.Update(model);

                    return RedirectToRoute("/Home/Success");
                }
            }
            catch (Exception)
            {
                return View();
            }

            return BadRequest();
        }
    }
}
