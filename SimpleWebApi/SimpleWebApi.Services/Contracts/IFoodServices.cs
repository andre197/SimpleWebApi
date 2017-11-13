namespace SimpleWebApi.Services.Contracts
{
    using System.Collections.Generic;
    using ViewModels;

    public interface IFoodServices
    {
        IEnumerable<FoodViewModel> ListFoods();

        FoodViewModel FindById(int id);

        void Insert(AddOrUpdateFoodViewModel food);

        void Delete(int foodId);

        void Update(FoodViewModel model);
    }
}
