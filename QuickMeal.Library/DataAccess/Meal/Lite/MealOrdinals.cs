using Microsoft.Data.Sqlite;

namespace QuickMeal.Library.DataAccess.Meal.Lite
{
    public class MealOrdinals
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int IsBreakfast { get; set; }
        public int IsLunch { get; set; }
        public int IsDinner { get; set; }
        public int IsSnack { get; set; }

        public MealOrdinals(SqliteDataReader reader)
        {
            Id = reader.GetOrdinal("Id");
            Name = reader.GetOrdinal("Name");
            IsBreakfast = reader.GetOrdinal("IsBreakfast");
            IsLunch = reader.GetOrdinal("IsLunch");
            IsDinner = reader.GetOrdinal("IsDinner");
            IsSnack = reader.GetOrdinal("IsSnack");
        }
    }
}