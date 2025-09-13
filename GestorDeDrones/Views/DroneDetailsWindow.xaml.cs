using System.Windows;
using GestorDeDrones.ViewModels;


namespace GestorDeDrones.Views
{
    public partial class DroneDetailsWindow : Window
    {
        public DroneDetailsWindow()
        {
            InitializeComponent();
        }

        public DroneDetailsWindow(DroneDetailsViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}