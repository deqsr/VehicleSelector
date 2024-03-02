using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace VehicleSelector
{
    public partial class MainWindow : Window
    {
        private DataService _dataService;

        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            _dataService = new DataService();

            // Load unique vehicle models into the ComboBox
            List<string> vehicleModels = _dataService.GetUniqueVehicleModels();
            VehicleModelsComboBox.ItemsSource = vehicleModels;
            LoadCategories();
        }   


        private async void SearchPartsButton_Click(object sender, RoutedEventArgs e)
        {
            string name = PartNameTextBox.Text;
            string compatibleWith = CompatibleWithTextBox.Text;
            string category = CategoryComboBox.SelectedItem as string;
            decimal minPrice = decimal.TryParse(MinPriceTextBox.Text, out decimal minPriceValue) ? minPriceValue : 0;
            decimal maxPrice = decimal.TryParse(MaxPriceTextBox.Text, out decimal maxPriceValue) ? maxPriceValue : decimal.MaxValue;

            // Clear ComboBox selection when searching by text input
            VehicleModelsComboBox.SelectedItem = null;

            List<Part> parts = await Task.Run(() => _dataService.SearchParts(name, compatibleWith, minPrice, maxPrice, category));
            PartsListView.ItemsSource = parts;
        }



        private void PartsListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private async void VehicleModelsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedVehicleModel = VehicleModelsComboBox.SelectedItem as string;
            CompatibleWithTextBox.Text = selectedVehicleModel;

            string name = PartNameTextBox.Text;
            string category = CategoryComboBox.SelectedItem as string;
            decimal minPrice = decimal.TryParse(MinPriceTextBox.Text, out decimal minPriceValue) ? minPriceValue : 0;
            decimal maxPrice = decimal.TryParse(MaxPriceTextBox.Text, out decimal maxPriceValue) ? maxPriceValue : decimal.MaxValue;
            List<Part> parts = await Task.Run(() => _dataService.SearchParts(name, selectedVehicleModel, minPrice, maxPrice, category));
            PartsListView.ItemsSource = parts;
        }
        private async void ClearPartNameButton_Click(object sender, RoutedEventArgs e)
        {
            PartNameTextBox.Clear();
            CategoryComboBox.SelectedItem = null;
            await PerformSearch();
        }

        private async void ClearCompatibleWithButton_Click(object sender, RoutedEventArgs e)
        {
            CompatibleWithTextBox.Clear();
            VehicleModelsComboBox.SelectedItem = null;
            await PerformSearch();
        }

        private async void ClearPriceButton_Click(object sender, RoutedEventArgs e)
        {
            MinPriceTextBox.Clear();
            MaxPriceTextBox.Clear();
            await PerformSearch();
        }

        private async Task PerformSearch()
        {
            string name = PartNameTextBox.Text;
            string compatibleWith = CompatibleWithTextBox.Text;
            string category = CategoryComboBox.SelectedItem as string;
            decimal minPrice = decimal.TryParse(MinPriceTextBox.Text, out decimal minPriceValue) ? minPriceValue : 0;
            decimal maxPrice = decimal.TryParse(MaxPriceTextBox.Text, out decimal maxPriceValue) ? maxPriceValue : decimal.MaxValue;

            List<Part> parts = await Task.Run(() => _dataService.SearchParts(name, compatibleWith, minPrice, maxPrice, category));
            PartsListView.ItemsSource = parts;
        }
        private async void LoadCategories()
        {
            List<string> categories = await Task.Run(() => _dataService.GetUniqueCategories());
            CategoryComboBox.ItemsSource = categories;
        }

        private async void CategoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedCategory = CategoryComboBox.SelectedItem as string;
            PartNameTextBox.Text = selectedCategory;

            string name = PartNameTextBox.Text;
            string compatibleWith = CompatibleWithTextBox.Text;
            decimal minPrice = decimal.TryParse(MinPriceTextBox.Text, out decimal minPriceValue) ? minPriceValue : 0;
            decimal maxPrice = decimal.TryParse(MaxPriceTextBox.Text, out decimal maxPriceValue) ? maxPriceValue : decimal.MaxValue;
            List<Part> parts = await Task.Run(() => _dataService.SearchParts(name, compatibleWith, minPrice, maxPrice, selectedCategory));
            PartsListView.ItemsSource = parts;
        }

    }
}
