namespace QuickMeal.Library.DataAccess.Meal.Lite
{
    public class LiteQueries
    {
        public const string Save = "INSERT INTO Meals (Id, Name, IsBreakfast, IsLunch, IsDinner, IsSnack) VALUES (NULL, @name, @isBreakfast, @isLunch, @isDinner, @isSnack);";
        public const string Get = "SELECT Id, Name, IsBreakfast, IsLunch, IsDinner, IsSnack FROM Meals;";
    }
}