using System.Collections.Generic;
using QuickMeal.Library.DataContracts.Meal;

namespace QuickMeal.Library.DataAccess.Meal
{
    public interface IMealDao
    {
        List<DataContracts.Meal.Meal> Get();
        List<DataContracts.Meal.Meal> Search(MealSearchRequest request);
        void Save(DataContracts.Meal.Meal meal);
    }
}