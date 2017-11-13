namespace SimpleWebApi
{
    using AutoMapper;
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using SimpleWebApi.AutoMapperHelper;
    using SimpleWebApi.Data.Models;
    using SimpleWebApi.ViewModels;

    public class Program
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Food, FoodViewModel>()
                        .ConvertUsing<FoodToFoodViewModelConverter>();

                cfg.CreateMap<AddOrUpdateFoodViewModel, Food>()
                        .ConvertUsing<AddOrUpdateFoodViewModelToFoodConverter>();

                cfg.CreateMap<FoodViewModel, Food>()
                        .ConvertUsing<FoodViewModelToFoodConverter>();
            });

            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
