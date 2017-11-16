namespace FitnessWebApi.Controllers
{
    using AutoMapper;
    using FitnessWebApi.BindingModels;
    using FitnessWebApi.DAL;
    using FitnessWebApi.DAL.Data;
    using FitnessWebApi.DAL.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Web.Http;
    using ViewModels;

    [RoutePrefix("api/Micronutrients")]
    public class MicronutrientsController : ApiController
    {
        private IFitnessRepository<Micronutrient> repository;

        public MicronutrientsController()
        {
            this.repository = new MicronutrientsRepository(new FitnessDbContext());
        }

        // GET api/<controller>
        [HttpGet]
        public IHttpActionResult Micronutrients()
        {
            IEnumerable<Micronutrient> data = this.repository.GetAll();
            List<MicronutrientViewModel> result = new List<MicronutrientViewModel>();

            return IEnumerableToViewModel(data, result);
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult MicronutrientById(int id)
        {
            MicronutrientViewModel result = Mapper.Map<Micronutrient, MicronutrientViewModel>(this.repository.GetById(id));

            if (result == null)
            {
                return NotFound();
            }

            return this.Ok(result);
        }

        [HttpGet]
        public IHttpActionResult MicronutrientByName([FromUri]string q)
        {
            if (string.IsNullOrWhiteSpace(q))
            {
                return this.BadRequest();
            }

            try
            {
                IEnumerable<Micronutrient> data = this.repository.GetAllContaining(q);
                List<MicronutrientViewModel> result = new List<MicronutrientViewModel>();

                return IEnumerableToViewModel(data, result);
            }
            catch (Exception)
            {
                return this.BadRequest();
            }
        }

        [HttpPost]
        public IHttpActionResult AddMicronutrient([FromBody]AddNutrientBindingModel value)
        {
            if (value == null)
            {
                return this.BadRequest();
            }

            Micronutrient micronutrient = Mapper.Map<AddNutrientBindingModel, Micronutrient>(value);

            this.repository.AddEntity(micronutrient);

            return this.Ok(micronutrient);
        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult UpdateMicronutrient(int id, [FromBody]UpdateMicronutrientBindingModel value)
        {
            if (value == null || id != value.Id)
            {
                return this.BadRequest();
            }

            try
            {

                Micronutrient newFood = Mapper.Map<UpdateMicronutrientBindingModel, Micronutrient>(value);

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

        private IHttpActionResult IEnumerableToViewModel(IEnumerable<Micronutrient> data, List<MicronutrientViewModel> result)
        {
            foreach (var item in data)
            {
                result.Add(Mapper.Map<Micronutrient, MicronutrientViewModel>(item));
            }

            return Json(result);
        }

        [HttpPatch]
        public IHttpActionResult AddFood([FromUri]int micronutrientId , [FromUri]int foodId)
        {
            try
            {
                this.repository.AddConnection(micronutrientId, foodId);

                return this.StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception)
            {
                return this.BadRequest();
            }
        }
    }
}