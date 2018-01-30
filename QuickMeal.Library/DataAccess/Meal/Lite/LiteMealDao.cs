using Microsoft.Data.Sqlite;
using QuickMeal.Library.DataContracts.Meal;
using System.Collections.Generic;

namespace QuickMeal.Library.DataAccess.Meal.Lite
{
    public class LiteMealDao : DataAccessBase, IMealDao
    {
        public List<DataContracts.Meal.Meal> Get()
        {
            var result = new List<DataContracts.Meal.Meal>();

            using (var connection = GetConnection())
            {
                connection.Open();
                var command = GetCommand(LiteQueries.Get, connection);
                var query = command.ExecuteReader();
                var ordinals = new MealOrdinals(query);

                while (query.Read())
                {
                    result.Add(GetMeal(ordinals, query));
                }

                connection.Close();
            }

            return result;
        }

        public List<DataContracts.Meal.Meal> Search(MealSearchRequest request)
        {
            var result = new List<DataContracts.Meal.Meal>();

            using (var connection = GetConnection())
            {
                connection.Open();
                var command = GetCommand(LiteQueries.Get, connection);
                var query = command.ExecuteReader();
                var ordinals = new MealOrdinals(query);

                while (query.Read())
                {
                    result.Add(GetMeal(ordinals, query));
                }

                connection.Close();
            }

            return result;
        }

        public void Save(DataContracts.Meal.Meal meal)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = GetCommand(LiteQueries.Save, connection);
                command.Parameters.AddWithValue("@name", meal.Name);
                command.Parameters.AddWithValue("@isBreakfast", meal.IsBreakfast);
                command.Parameters.AddWithValue("@isLunch", meal.IsLunch);
                command.Parameters.AddWithValue("@isDinner", meal.IsDinner);
                command.Parameters.AddWithValue("@isSnack", meal.IsSnack);

                command.ExecuteReader();

                connection.Close();
            }
        }

        private static DataContracts.Meal.Meal GetMeal(MealOrdinals ordinals, SqliteDataReader query)
        {
            return new DataContracts.Meal.Meal
            {
                Id = query.GetInt32(ordinals.Id),
                Name = query.GetString(ordinals.Name),
                IsBreakfast = query.GetBoolean(ordinals.IsBreakfast),
                IsLunch = query.GetBoolean(ordinals.IsLunch),
                IsDinner = query.GetBoolean(ordinals.IsDinner),
                IsSnack = query.GetBoolean(ordinals.IsSnack)
            };
        }
    }
}