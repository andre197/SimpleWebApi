using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using AutoMapper;
using FitnessWebApi.DAL.Data.Models;
using FitnessWebApi.ViewModels;
using FitnessWebApi.AutoMapperHelper;
using FitnessWebApi.BindingModels;

namespace FitnessWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Food, FoodViewModel>().ConvertUsing<FoodToFoodViewModelConverter>();
                cfg.CreateMap<AddFoodBindingModel, Food>().ConvertUsing<AddFoodBindingModelToFoodConverter>();
            });

            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver
                = new CamelCasePropertyNamesContractResolver();
        }
    }
}
