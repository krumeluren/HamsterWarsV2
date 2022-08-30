using HamsterWarsXamarinUI.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace HamsterWarsXamarinUI.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}