namespace SimpleWebApi.Services.Contracts
{
    using System.Collections.Generic;
    using ViewModels;

    public interface IFoodServices
    {
        List<FoodViewModel> ListFoods();

        FoodViewModel FindById(int id);
    }
}
