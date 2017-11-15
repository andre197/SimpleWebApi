namespace FitnessWebApi.Controllers
{
    using AutoMapper;
    using AutoMapperHelper;
    using BindingModels;
    using DAL;
    using DAL.Data;
    using DAL.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Web.Http;
    using ViewModels;

    [RoutePrefix("api/Foods")]
    public class FoodsController : ApiController
    {
        private IFitnessRepository repository;

        public FoodsController()
        {
            this.repository = new FitnessRepository(new FitnessDbContext());
        }

        // GET api/<controller>
        [HttpGet]
        public IHttpActionResult Foods()
        {
            IEnumerable<Food> data = this.repository.Foods();
            List<FoodViewModel> result = new List<FoodViewModel>();

            foreach (var item in data)
            {
                result.Add(Mapper.Map<Food, FoodViewModel>(item));
            }

            return Json(result);
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult FoodById(int id)
        {
            FoodViewModel result = Mapper.Map<Food, FoodViewModel>(this.repository.FoodById(id));

            if (result == null)
            {
                return NotFound();
            }

            return this.Ok(result);
        }

        [HttpPost]
        public IHttpActionResult AddFood([FromBody]AddFoodBindingModel value)
        {
            if (value == null)
            {
                return this.BadRequest();
            }

            Food food = Mapper.Map<AddFoodBindingModel, Food>(value);

            this.repository.AddFood(food);

            return this.Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult UpdateFood(int id, [FromBody]FoodUpdateBindingModel value)
        {
            if (value == null || id != value.Id)
            {
                return this.BadRequest();
            }

            try
            {
                Food food = this.repository.FoodById(id);

                if (food == null)
                {
                    return this.NotFound();
                }

                food = Mapper.Map<FoodUpdateBindingModel, Food>(value);

                this.repository.UpdateFood(food);

                return this.StatusCode(HttpStatusCode.NoContent);
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

            this.repository.DeleteFood(id);

            return this.Ok();
        }
    }
}