using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using QuickMeal.Library.DataAccess;
using QuickMeal.Library.DataAccess.Meal;
using QuickMeal.Library.DataAccess.Meal.Lite;
using QuickMeal.Library.DataContracts.Meal;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace QuickMeal.UI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly IMealDao _mealDao;
        public MealViewModel ViewModel { get; set; }

        public MainPage()
        {
            this.InitializeComponent();

            ViewModel = new MealViewModel();
            _mealDao = new LiteMealDao();
        }

        private void AddData(object sender, RoutedEventArgs e)
        {
            var meal = new Meal
            {
                Name = TxtName.Text,
                IsBreakfast = CbIsBreakfast.IsChecked ?? false,
                IsLunch = CbIsLunch.IsChecked ?? false,
                IsDinner = CbIsDinner.IsChecked ?? false,
                IsSnack = CbIsSnack.IsChecked ?? false
            };

            _mealDao.Save(meal);

            var meals = _mealDao.Get();
            ViewModel.Meals.Clear();
            meals.ForEach(m => ViewModel.Meals.Add(m));

            TxtName.Text = string.Empty;
            TxtName.Focus(FocusState.Programmatic);
            CbIsBreakfast.IsChecked = false;
            CbIsLunch.IsChecked = false;
            CbIsDinner.IsChecked = false;
            CbIsSnack.IsChecked = false;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            var meals = _mealDao.Get();
            ViewModel.Meals.Clear();
            meals.ForEach(m => ViewModel.Meals.Add(m));
        }

        private void BtnRemoveItem_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }

    public class MealViewModel
    {
        public ObservableCollection<Meal> Meals { get; set; } = new ObservableCollection<Meal>();
    }
}
