namespace FitnessWebApi.Controllers
{
    using AutoMapper;
    using BindingModels;
    using DAL;
    using DAL.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Web.Http;
    using ViewModels;

    [RoutePrefix("api/Foods")]
    public class FoodsController : ApiController
    {
        private IFitnessRepository<Food> repository;

        public FoodsController(IFitnessRepository<Food> repository)
        {
            this.repository = repository;
        }
        
        [HttpGet]
        public IHttpActionResult Foods()
        {
            IEnumerable<Food> data = this.repository.GetAll();
            List<FoodViewModel> result = new List<FoodViewModel>();

            return IEnumerableToViewModel(data, result);
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult FoodById(int id)
        {
            FoodViewModel result = Mapper.Map<Food, FoodViewModel>(this.repository.GetById(id));

            if (result == null)
            {
                return NotFound();
            }

            return this.Ok(result);
        }

        [HttpGet]
        public IHttpActionResult FoodByName([FromUri]string q)
        {
            if (string.IsNullOrWhiteSpace(q))
            {
                return this.BadRequest();
            }

            try
            {
                IEnumerable<Food> data = this.repository.GetAllContaining(q);
                List<FoodViewModel> result = new List<FoodViewModel>();

                return IEnumerableToViewModel(data, result);
            }
            catch (Exception)
            {
                return this.BadRequest();
            }
        }

        [HttpPost]
        public IHttpActionResult AddFood([FromBody]AddFoodBindingModel value)
        {
            if (value == null)
            {
                return this.BadRequest();
            }

            Food food = Mapper.Map<AddFoodBindingModel, Food>(value);

            this.repository.AddEntity(food);

            return this.Ok(food);
        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult UpdateFood(int id, [FromBody]UpdateFoodBindingModel value)
        {
            if (value == null || id != value.Id)
            {
                return this.BadRequest();
            }

            try
            {
                Food newFood = Mapper.Map<UpdateFoodBindingModel, Food>(value);

                this.repository.UpdateEntity(id, newFood);

                return this.Ok(newFood);
            }
            catch (Exception)
            {
                return this.BadRequest();
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            if (id < 0)
            {
                return this.BadRequest();
            }

            this.repository.DeleteEntity(id);

            return this.Ok();
        }

        private IHttpActionResult IEnumerableToViewModel(IEnumerable<Food> data, List<FoodViewModel> result)
        {
            foreach (var item in data)
            {
                result.Add(Mapper.Map<Food, FoodViewModel>(item));
            }

            return Json(result);
        }

        [HttpPatch]
        public IHttpActionResult AddMicronutrient([FromUri]int foodId, [FromUri]int micronutrientId)
        {
            try
            {
                this.repository.AddConnection(foodId, micronutrientId);

                return this.Ok();
            }
            catch (Exception)
            {
                return this.BadRequest();
            }
        }
    }
}