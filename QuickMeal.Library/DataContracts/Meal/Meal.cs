namespace QuickMeal.Library.DataContracts.Meal
{
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsBreakfast { get; set; }
        public bool IsLunch { get; set; }
        public bool IsDinner { get; set; }
        public bool IsSnack { get; set; }
    }
}